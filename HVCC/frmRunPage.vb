'Imports System.Runtime.InteropServices
'Imports System.IO
' Imports System.Configuration
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports System.Text
'Imports System.Data
Imports ZM400Print

Public Class frmRunPage
    Dim cnt1 As Integer = 0
    Dim cnt2 As String
    Dim cnt3 As String
    Dim AL As New Collection
    Dim RunNumber As String
    Dim RunCounter As String
    Dim sqlRunNumber As String
    Dim ZM400_Name As String
    Dim pText As New StringBuilder
    Dim bConnectFlg As Boolean 'ConnectFlg
#Region " [[[Additional Initialization]]] "

    Const ELEMENT_SIZE_WORD = 10        'Size of elements, when write/read 'Word' data to the PLC.
    Const ELEMENT_SIZE_32BITINTEGER = 2 'Size of elements, when write/read '32bit Integer' data to the PLC.
    Const ELEMENT_SIZE_REALNUMBER = 2   'Size of elements, when write/read 'Real Number' data to the PLC.

    Dim objAsciiCodePageEncoding As Encoding = Encoding.Default  'Create an instance for encoding to(or decoding from) ASCII Code Page.

#End Region
    Private Sub frmRunPage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall
                e.Cancel = False
            Case CloseReason.FormOwnerClosing
                e.Cancel = False
            Case CloseReason.MdiFormClosing
                e.Cancel = False
            Case CloseReason.None
                e.Cancel = False
            Case CloseReason.TaskManagerClosing
                e.Cancel = False
            Case CloseReason.UserClosing
                e.Cancel = True
                Me.Visible = False
                Me.NotifyIcon1.Visible = True
                Me.NotifyIcon1.BalloonTipText = "ZM400 Printer Still Running in Background Process..."
                Me.NotifyIcon1.ShowBalloonTip(1000)
            Case CloseReason.WindowsShutDown
                e.Cancel = False
        End Select
    End Sub
    Private Sub frmRunPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadRounting()
        ShowDataLog()
        tbPrint.Enabled = False
        LoadShiftDate()
        UpdateShift()
        TabDatalogger.TabPages.Remove(TabManual)
        TabBarcode.TabPages.Remove(TabInfo)
        bConnectFlg = False
        ShowPrinter()
    End Sub
#Region "[[  Transection Zone  ]]"
    Private Sub ShowModel()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT ModelID,Model FROM tbModel;")
        Dim sqlModel As String = sb.ToString()
        With cmd
            .CommandText = sqlModel
            .CommandType = CommandType.Text
            .Connection = Conndb
            dr = cmd.ExecuteReader()
        End With
        If dr.HasRows Then
            Dim dtModel = New DataTable()
            dtModel.Load(dr)
            With cmbModel
                .BeginUpdate()
                .DisplayMember = "Model"
                .ValueMember = "ModelID"
                .DataSource = dtModel
                .EndUpdate()
            End With
        End If
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        sb.Remove(0, sb.Length)
        sb.Append("SELECT OrderID,OrderNo FROM tbOrderNo;")
        Dim sqlOrder As String = sb.ToString()
        With cmd
            .CommandText = sqlOrder
            .CommandType = CommandType.Text
            .Connection = Conndb
            dr = cmd.ExecuteReader()
        End With
        If dr.HasRows Then
            Dim dtOrder = New DataTable()
            dtOrder.Load(dr)
            With cmbOrder
                .BeginUpdate()
                .DisplayMember = "OrderNo"
                .ValueMember = "OrderID"
                .DataSource = dtOrder
                .EndUpdate()
            End With
        End If
        dr.Close()
    End Sub
    Private Sub ShowPrintManual()
        On Error Resume Next
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT t1.Model,t1.Order,t0.CustomerPartNo,t0.CustomerPartNo2,t2.PartNo,t2.PartNoDetail,t2.Code,t1.LeakTest,t2.Quantity,t2.LotSize,t1.Serial,t1.EachCount,t2.AutoModel")
        sb.Append(" FROM (tbPrintLabel t1")
        sb.Append(" INNER JOIN tbPartNo t2")
        sb.Append(" ON t1.PartNo = t2.PartID)")
        sb.Append(" INNER JOIN tbCustomer t0")
        sb.Append(" ON t0.CusID = t1.CustomerNo")
        sb.Append(" WHERE t1.Model='" & cmbModel.Text & "'")
        sb.Append(" AND t1.Order='" & cmbOrder.Text & "'")
        Dim sqlOrder As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlOrder
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.Read() Then
                cmbCustomer1.Text = dr.GetString(2)
                cmbCustomer2.Text = dr.GetString(3)
                cmbPartNo.Text = dr.GetString(4)
                cmbDetail.Text = dr.GetString(5)
                cmbCode.Text = dr.GetString(6)
                cmbLeakTest.Text = dr.GetString(7)
                cmbQuantity.Text = dr.GetInt32(8)
                cmbLotSize.Text = dr.GetInt32(9)
                cmbSerial.Text = dr.GetString(10)
                cmbSerial2.Text = dr.GetString(10)
                cmbCounter.Text = dr.GetString(11)
                cmbCounter2.Text = dr.GetString(11)
                cmbAutomodel.Text = dr.GetString(12)
            Else
                cmbCustomer1.Text = Nothing
                cmbCustomer2.Text = Nothing
                cmbPartNo.Text = Nothing
                cmbDetail.Text = Nothing
                cmbCode.Text = Nothing
                cmbQuantity.Text = Nothing
                cmbLotSize.Text = Nothing
                cmbSerial.Text = Nothing
                cmbSerial2.Text = Nothing
                cmbLeakTest.Text = Nothing
                cmbCounter.Text = Nothing
                cmbCounter2.Text = Nothing
                cmbAutomodel.Text = Nothing
            End If
        End With
        dr.Close()
    End Sub
    Private Sub ShowDataLog()
        On Error Resume Next
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT TOP 500 timestamp,Shift,Routing,PartNo,CustomerNo1,CustomerNo2,Code,Counter,LeakTest,PrintMode")
        sb.Append(" FROM tbDataLog")
        sb.Append(" ORDER BY timestamp DESC")
        Dim sqlOrder As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlOrder
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.HasRows Then
                dt = New DataTable()
                dt.Load(dr)
                dgvLabelPrint.DataSource = dt
            Else
                dgvLabelPrint.DataSource = Nothing
            End If
        End With
        dr.Close()
        Conndb.Close()
        PrintView()
    End Sub
    Private Sub ShowPrintQueue()
        On Error Resume Next
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim datReader As OleDbDataReader
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT t1.Model,t1.Order,t0.CustomerPartNo,t0.CustomerPartNo2,t2.PartNo,t2.PartNoDetail,t2.Code,t1.LeakTest,t2.Quantity,t2.LotSize,t1.Counter,t1.Serial,t2.AutoModel,t1.EachCount,t1.Print")
        sb.Append(" FROM (tbPrintLabel t1")
        sb.Append(" INNER JOIN tbPartNo t2")
        sb.Append(" ON t1.PartNo = t2.PartID)")
        sb.Append(" INNER JOIN tbCustomer t0")
        sb.Append(" ON t0.CusID = t1.CustomerNo")
        sb.Append(" WHERE t1.Model='" & lbModel.Text.Trim() & "'")
        sb.Append(" AND t1.Order='" & lbOrder.Text.Trim() & "'")
        Dim sqlOrder As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlOrder
            .Connection = Conndb
            datReader = .ExecuteReader()
            Do While datReader.Read()
                Dim objListItem As New ListViewItem(datReader.Item(0).ToString)
                For c = 1 To datReader.FieldCount - 1
                    objListItem.SubItems.Add(datReader.Item(c).ToString)
                Next
                objListItem.ImageIndex = 5
                lvPrint.Items.Add(objListItem)
                txtCustomer1.Text = objListItem.SubItems(2).Text
                txtCustomer2.Text = objListItem.SubItems(3).Text
                txtPartNo1.Text = objListItem.SubItems(4).Text
                txtPartDetail1.Text = objListItem.SubItems(5).Text
                lbCode.Text = objListItem.SubItems(6).Text
                txtLeakTest.Text = objListItem.SubItems(7).Text
                txtSetquantity1.Text = objListItem.SubItems(8).Text
                txtLotSize1.Text = objListItem.SubItems(9).Text
                txtCounter1.Text = objListItem.SubItems(10).Text
                lbSerialNo1.Text = objListItem.SubItems(11).Text
                lbAutoModel.Text = objListItem.SubItems(12).Text
                lbCounter.Text = objListItem.SubItems(13).Text
                lbPrintUse.Text = objListItem.SubItems(14).Text
                Dim i As Integer = 0
                While (i < lvPrint.Items.Count)
                    lvPrint.BeginUpdate()
                    RemoveListViewLine(i, lvPrint.Items(i).SubItems(0).Text, lvPrint.Items(i).SubItems(1).Text)
                    i = i + 1
                    lvPrint.EndUpdate()
                End While
            Loop
        End With
        Conndb.Close()
        datReader.Close()
    End Sub
    Private Sub RemoveListViewLine(ByVal n As Integer, ByVal TextCrit As String, ByVal SubCrit As String)
        Dim li As ListViewItem
        n = n + 1
        While (n < lvPrint.Items.Count)
            li = lvPrint.Items(n)
            If li.SubItems(0).Text = TextCrit And li.SubItems(1).Text = SubCrit Then
                lvPrint.Items.Remove(li)
            Else
                n = n + 1
            End If
        End While
    End Sub
    Private Sub PrintView()
        On Error Resume Next
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvLabelPrint
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Date Time"
                .Columns(2).HeaderText = "Shift"
                .Columns(3).HeaderText = "Routing"
                .Columns(4).HeaderText = "Part No"
                .Columns(5).HeaderText = "Customer Part No.1"
                .Columns(6).HeaderText = "Customer Part No.2"
                .Columns(7).HeaderText = "Code"
                .Columns(8).HeaderText = "Counter"
                .Columns(9).HeaderText = "Leak Test"
                .Columns(10).HeaderText = "Print Mode"
                .Columns(0).Width = 60
                .Columns(1).Width = 150
                .Columns(2).Width = 60
                .Columns(3).Width = 100
                .Columns(4).Width = 120
                .Columns(5).Width = 180
                .Columns(6).Width = 180
                .Columns(7).Width = 80
                .Columns(8).Width = 100
                .Columns(9).Width = 100
            End If
        End With
    End Sub
    Private Sub LoadRounting()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT RoutingName,GSDB")
        sb.Append(" FROM tbRouting")
        Dim sqlClient As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlClient
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.Read() Then
                lbRouting.Text = dr.GetString(0)
                lbgsdb.Text = dr.GetString(1)
            Else
                lbRouting.Text = Nothing
                lbgsdb.Text = Nothing
            End If
        End With
        Conndb.Close()
        dr.Close()
    End Sub
    Private Sub LoadShiftDate()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT BarcodeDate")
        sb.Append(" FROM tbRouting")
        Dim sqlClient As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlClient
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.Read() Then
                lbShiftDate.Text = dr.GetString(0)
            Else
                lbShiftDate.Text = Nothing
            End If
            dr.Close()
        End With
        Conndb.Close()
    End Sub
    Private Sub LoadShiftA()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT Shift,Start,Finish")
        sb.Append(" FROM tbShift")
        sb.Append(" WHERE Shift ='A'")
        Dim sqlClient As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlClient
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.Read() Then
                lbShift.Text = dr.GetString(0)
                lbShiftStart.Text = "Day : " & dr.GetDateTime(1)
                lbShiftFinish.Text = "- " & dr.GetDateTime(2)
            Else
                lbShift.Text = Nothing
                lbShiftStart.Text = Nothing
                lbShiftFinish.Text = Nothing
            End If
            dr.Close()
        End With
        Conndb.Close()
    End Sub
    Private Sub LoadShiftB()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT Shift,Start,Finish")
        sb.Append(" FROM tbShift")
        sb.Append(" WHERE Shift ='B'")
        Dim sqlClient As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlClient
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.Read() Then
                lbShift.Text = dr.GetString(0)
                lbShiftStart.Text = "Night : " & dr.GetDateTime(1)
                lbShiftFinish.Text = "- " & dr.GetDateTime(2)
            Else
                lbShift.Text = Nothing
                lbShiftStart.Text = Nothing
                lbShiftFinish.Text = Nothing
            End If
            dr.Close()
        End With
        Conndb.Close()
    End Sub
    Private Sub AutoCheckDate()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Sql = "SELECT BarcodeDate,TodayDate FROM tbRouting"
        da = New OleDbDataAdapter(Sql, Conndb)
        da.Fill(ds, "tbRouting")
        For Each row As DataRow In ds.Tables("tbRouting").Rows
            If ds.Tables("tbRouting").Rows(0)("TodayDate").ToString < Date.Today.Date.ToString Then
                sqlRunNumber = "Update tbRouting SET BarcodeDate='" & lbShiftDate.Text & "',TodayDate='" & DateTime.Today.ToString("yyyy-MM-dd") & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlRunNumber, Conndb)
                cmdUpdate.ExecuteNonQuery()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub UpdateShift()
        Dim day As String = Format(Microsoft.VisualBasic.Mid(Date.Today.ToString("yyyy-MM-dd"), 9))
        Dim m As String = Format(Microsoft.VisualBasic.Mid$(Date.Today.ToString("yyyy-MM-dd"), 6, 2))
        Dim y As String = Format(Microsoft.VisualBasic.Mid$(Date.Today.ToString("yyyy-MM-dd"), 3, 2))
        Dim CurrentDate = day & m & y
        lbShiftDate.Refresh()
        lbShiftDate.Text = CurrentDate
    End Sub
    Private Sub SaveDataLogAuto()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        Dim dmy As DateTime = tsToday.Text.ToString()
        sb.Append("INSERT INTO tbDataLog([timestamp],[Shift],[Routing],[PartNo],[CustomerNo1],[CustomerNo2],[Counter],[Code],[LeakTest],[PrintMode])")
        sb.Append(" Values('" & dmy.ToString("yyyy-MM-dd HH:mm:ss") & "','" & lbShift.Text & "','" & lbRouting.Text & "',")
        sb.Append("'" & txtPartNo1.Text & "','" & txtCustomer1.Text & "','" & txtCustomer2.Text & "','" & lbCounter.Text & "','" & lbCode.Text & "','" & txtLeakTest.Text & "','Auto')")
        Dim sqlPrint As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlPrint, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub SaveDataLogManual()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        Dim dmy As DateTime = tsToday.Text.ToString()
        sb.Append("INSERT INTO tbDataLog([timestamp],[Shift],[Routing],[PartNo],[CustomerNo1],[CustomerNo2],[Counter],[Code],[LeakTest],[PrintMode])")
        sb.Append(" Values('" & dmy.ToString("yyyy-MM-dd HH:mm:ss") & "','" & lbShift.Text & "','" & lbRouting.Text & "',")
        sb.Append("'" & cmbPartNo.Text & "','" & cmbCustomer1.Text & "','" & cmbCustomer2.Text & "','" & cmbCounter.Text & "','" & cmbCode.Text & "','" & cmbLeakTest.Text & "','Manual')")
        Dim sqlPrint As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlPrint, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
#End Region
#Region "[[[   Run Serial   ]]]"
    Private Sub AutoSerialUp()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        ds.Clear()
        sqlRunNumber = "SELECT Serial FROM tbPrintLabel WHERE [Model]='" & lbModel.Text & "' AND [Order]='" & lbOrder.Text & "'"
        da = New OleDbDataAdapter(sqlRunNumber, Conndb)
        da.Fill(ds, "tbPrintLabel")
        For Each row As DataRow In ds.Tables("tbPrintLabel").Rows
            If ds.Tables("tbPrintLabel").Rows(0)("Serial").ToString = "" Then
                ds.Tables("tbPrintLabel").Rows(0)("Serial") = "0000"
                RunNumber = "0000"
            Else
                RunNumber = Format(Microsoft.VisualBasic.Right(ds.Tables("tbPrintLabel").Rows(0)("Serial").ToString, 4) + 1, "0000")
            End If
        Next
        lbSerialNo1.Text = RunNumber
        Conndb.Close()
    End Sub
    Private Sub UpdateSerial()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sqlSerial As String = "SELECT Serial FROM tbPrintLabel WHERE [Model]='" & lbModel.Text & "' AND [Order]='" & lbOrder.Text & "'"
        da = New OleDbDataAdapter(sqlSerial, Conndb)
        da.Fill(ds, "tbPrintLabel")
        For Each row As DataRow In ds.Tables("tbPrintLabel").Rows
            If ds.Tables("tbPrintLabel").Rows(0)("Serial").ToString <> "" Then
                Sql = "Update tbPrintLabel SET [Serial]='" & lbSerialNo1.Text & "'"
                Sql = Sql & " WHERE [Model]='" & lbModel.Text & "' AND [Order]='" & lbOrder.Text & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(Sql, Conndb)
                cmdUpdate.ExecuteNonQuery()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub UpdateManualSerial()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sqlSerial As String = "SELECT Serial FROM tbPrintLabel WHERE [Model]='" & cmbModel.Text & "' AND [Order]='" & cmbOrder.Text & "'"
        da = New OleDbDataAdapter(sqlSerial, Conndb)
        da.Fill(ds, "tbPrintLabel")
        For Each row As DataRow In ds.Tables("tbPrintLabel").Rows
            If ds.Tables("tbPrintLabel").Rows(0)("Serial").ToString <> "" Then
                Sql = "Update tbPrintLabel SET [Serial]='" & cmbSerial.Text & "'"
                Sql = Sql & " WHERE [Model]='" & cmbModel.Text & "' AND [Order]='" & cmbOrder.Text & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(Sql, Conndb)
                cmdUpdate.ExecuteNonQuery()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub AutoCounterUp()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        dsECount.Clear()
        sqlRunNumber = "SELECT EachCount FROM tbPrintLabel WHERE [Model]='" & lbModel.Text & "' AND [Order]='" & lbOrder.Text & "'"
        da = New OleDbDataAdapter(sqlRunNumber, Conndb)
        da.Fill(dsECount, "tbPrintLabel")
        For Each row As DataRow In dsECount.Tables("tbPrintLabel").Rows
            If dsECount.Tables("tbPrintLabel").Rows(0)("EachCount").ToString = "" Then
                dsECount.Tables("tbPrintLabel").Rows(0)("EachCount") = "0000"
                RunCounter = "0000"
            Else
                RunCounter = Format(Microsoft.VisualBasic.Right(dsECount.Tables("tbPrintLabel").Rows(0)("EachCount").ToString, 4) + 1, "0000")
            End If
        Next
        lbCounter.Text = RunCounter
        Conndb.Close()
    End Sub
    Private Sub UpdateCounter()
        dsCount.Clear()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sqlCounter As String = "SELECT Counter,EachCount FROM tbPrintLabel WHERE [Model]='" & lbModel.Text & "' AND [Order]='" & lbOrder.Text & "'"
        da = New OleDbDataAdapter(sqlCounter, Conndb)
        da.Fill(dsCount, "tbPrintLabel")
        For Each row As DataRow In dsCount.Tables("tbPrintLabel").Rows
            If dsCount.Tables("tbPrintLabel").Rows(0)("Counter").ToString <> "" Then
                Dim sqlupdteCount As String = "Update tbPrintLabel SET [Counter]='" & txtCounter1.Text & "',[EachCount]='" & lbCounter.Text & "'"
                sqlupdteCount = sqlupdteCount & " WHERE [Model]='" & lbModel.Text & "' AND [Order]='" & lbOrder.Text & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlupdteCount, Conndb)
                cmdUpdate.ExecuteNonQuery()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub UpdateManualCounter()
        dsCount.Clear()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sqlCounter As String = "SELECT EachCount,Counter FROM tbPrintLabel WHERE [Model]='" & cmbModel.Text & "' AND [Order]='" & cmbOrder.Text & "'"
        da = New OleDbDataAdapter(sqlCounter, Conndb)
        da.Fill(dsCount, "tbPrintLabel")
        For Each row As DataRow In dsCount.Tables("tbPrintLabel").Rows
            If dsCount.Tables("tbPrintLabel").Rows(0)("EachCount").ToString <> "" Then
                Dim sqlupdteCount As String = "Update tbPrintLabel SET [EachCount]='" & cmbCounter.Text & "',[Counter]='" & txtCounter1.Text & "'"
                sqlupdteCount = sqlupdteCount & " WHERE [Model]='" & cmbModel.Text & "'  AND [Order]='" & cmbOrder.Text & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlupdteCount, Conndb)
                cmdUpdate.ExecuteNonQuery()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub EjectSerial()
        Dim lv0 As String
        Dim lv1 As String
        If lvPrint.SelectedItems.Count > 0 Then
            lv0 = lvPrint.SelectedItems(0).SubItems(0).Text
            lv1 = lvPrint.SelectedItems(0).SubItems(1).Text
        Else
            lv0 = String.Empty
            lv1 = String.Empty
        End If
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sqlSerial As String = "SELECT Serial FROM tbPrintLabel WHERE [Model]='" & lv0.ToString & "' AND [Order]='" & lv1.ToString & "'"
        da = New OleDbDataAdapter(sqlSerial, Conndb)
        da.Fill(ds, "tbPrintLabel")
        For Each row As DataRow In ds.Tables("tbPrintLabel").Rows
            If ds.Tables("tbPrintLabel").Rows(0)("Serial").ToString <> "" Then
                Sql = "Update tbPrintLabel SET [Serial]='0000',[Counter]='0',[EachCount]='0000'"
                Sql = Sql & " WHERE [Model]='" & lv0.ToString & "' AND [Order]='" & lv1.ToString & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(Sql, Conndb)
                cmdUpdate.ExecuteNonQuery()
                ClearDisplay()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub ResetCounter()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        ds.Clear()
        Dim sqlSerial As String = "SELECT Serial FROM tbPrintLabel " ' WHERE [Model]='" & lv0.ToString & "' AND [Order]='" & lv1.ToString & "'"
        da = New OleDbDataAdapter(sqlSerial, Conndb)
        da.Fill(ds, "tbPrintLabel")
        For Each row As DataRow In ds.Tables("tbPrintLabel").Rows
            If ds.Tables("tbPrintLabel").Rows(0)("Serial").ToString <> "" Then
                Dim SqlReset = "Update tbPrintLabel SET [Serial]='0000',[Counter]='0',[EachCount]='0000'"
                'Sql = Sql & " WHERE [Model]='" & lv0.ToString & "' AND [Order]='" & lv1.ToString & "'"
                Dim cmdUpdate As OleDbCommand = New OleDbCommand(SqlReset, Conndb)
                cmdUpdate.ExecuteNonQuery()
                ClearCounter()
                lvPrint.Items.Clear()
            End If
        Next
        Conndb.Close()
    End Sub
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvLabelPrint.RowCount - 2
            dgvLabelPrint.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub ClearCounter()
        'Clear TextBox of 'ReturnCode','Data'
        'Text_ReturnValue.Text = ""
        'txtModel.Text = ""
        'txtOrder.Text = ""
        lbModel.Text = "Model"
        lbOrder.Text = "Order"
        lbCode.Text = "Code"
        lbAutoModel.Text = "Auto Model"
        lbSerialNo1.Text = "0000"
        lbCounter.Text = "0000"
        txtCustomer1.Text = ""
        txtCustomer2.Text = ""
        txtPartNo1.Text = ""
        txtPartDetail1.Text = ""
        txtLeakTest.Text = ""
        txtSetquantity1.Text = 0
        txtLotSize1.Text = 0
        txtCounter1.Text = 0
        'btOK.BackColor = Color.Gray
    End Sub
#End Region
#Region "[[[[  ZPL  ]]]"
#Region "[[[LOT Print]]]"
    Private Sub rbMatrix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMatrix.CheckedChanged
        If rbMatrix.Checked = True Then
            PictureBox1.Image = My.Resources.barcode_image1
        Else
            PictureBox1.Image = My.Resources._AS
        End If
    End Sub
    Private Sub AutoPrintLabel()
        If rbMatrix.Checked = True Then
            Label30X550Matrix()
        Else
            Label30X550QR()
        End If
        SaveDataLogAuto()
        ShowDataLog()
    End Sub
    Private Sub Label30X550Matrix()
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=50
        pText.AppendLine("^FWR") ' Rotate 90
        pText.AppendLine("^FO500,80") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FDHalla Visteon Climate Control(Thailand)Co.,Ltd.^FS") ' 

        pText.AppendLine("^FO430,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDRounting:^FS") ' Rounting No.

        pText.AppendLine("^FO420,300") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & lbRouting.Text & "^FS") ' Rounting No.

        pText.AppendLine("^FO440,600") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & txtLeakTest.Text & "^FS") ' Leak Test

        pText.AppendLine("^FO360,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDPart No.:^FS") ' Part No.

        pText.AppendLine("^FO350,300") ' X,Y position
        pText.AppendLine("^A0,65,60")  ' font h,w
        pText.AppendLine("^FD" & "" & txtPartNo1.Text & "^FS") ' Part No.

        pText.AppendLine("^FO360,730") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & txtPartDetail1.Text & "^FS") ' Part No. Detail

        pText.AppendLine("^FO290,300") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FD" & "" & txtCustomer2.Text & "^FS") ' Customer part NO.

        pText.AppendLine("^FO240,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDOption:^FS") ' Option

        pText.AppendLine("^FO220,680") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDQ'ty:^FS") ' Q'ty

        pText.AppendLine("^FO220,850") ' X,Y position
        pText.AppendLine("^A0,65,55")  ' font h,w
        pText.AppendLine("^FD" & "" & txtSetquantity1.Text & "^FS") ' Q'ty:

        pText.AppendLine("^FO160,650") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDSerial:^FS") ' Serial

        pText.AppendLine("^FO160,850") ' X,Y position
        pText.AppendLine("^A0,40,30")  ' font h,w
        pText.AppendLine("^FD" & "" & lbSerialNo1.Text & "^FS") ' Serial no

        pText.AppendLine("^FO120,280") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDLot Size: " & "" & txtLotSize1.Text & "^FS") ' Lot Size

        pText.AppendLine("^FO50,280") ' X,Y position
        pText.AppendLine("^A0,45,40")  ' font h,w
        pText.AppendLine("^FDLot No.: " & "" & lbShiftDate.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & lbSerialNo1.Text & "^FS") ' Lot No.
        'Bar Code-------------------------------------------------
        pText.AppendLine("^FO50,80") ' X,Y position
        'pText.AppendLine("^BX,5,200")  ' Matrix Code
        'pText.AppendLine("^FD" & "" & txtCustomer1.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "|Auto ^FS") 'Reserve new barcode
        pText.AppendLine("^BX,8,200")  ' Matrix Code
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "^FS") 'Current barcode
        pText.AppendLine("^FO50,1300") ' X,Y position
        'pText.AppendLine("^BXB,4,200")  ' Matrix Code Rotate 90
        'pText.AppendLine("^FD" & "" & txtCustomer1.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "|Auto ^FS") 'Reserve new barcode
        pText.AppendLine("^BXB,5,200")  ' Matrix Code
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "^FS") 'Current barcode
        '-----------------------------------------------------------
        pText.AppendLine("^FO200,1300^A0N,30,35") ' X,Y position
        pText.AppendLine("^FD" & "" & txtPartNo1.Text & "   Q'ty. " & "" & txtSetquantity1.Text & "^FS") ' part No.
        pText.AppendLine("^FO200,1350^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & txtPartDetail1.Text & "^FS") ' Lot No.
        pText.AppendLine("^FO200,1400^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & " " & "" & txtPartNo1.Text & " " & "" & lbRouting.Text & " " & "" & lbSerialNo1.Text & "^FS") ' part No.

        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL) (Copy 1)") 'print the string USB   ZDesigner ZM400 300 dpi (ZPL)     
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbLotPrinter.Text) 'print the string USB HVCC---Zebra ZM400 (300 dpi) - ZPL----
    End Sub
    Private Sub Label30X550QR()
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=50
        pText.AppendLine("^FWR") ' Rotate 90
        pText.AppendLine("^FO500,80") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FDHalla Visteon Climate Control(Thailand)Co.,Ltd.^FS") ' 

        pText.AppendLine("^FO430,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDRounting:^FS") ' Rounting No.

        pText.AppendLine("^FO420,300") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & lbRouting.Text & "^FS") ' Rounting No.

        pText.AppendLine("^FO440,600") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & txtLeakTest.Text & "^FS") ' Leak Test

        pText.AppendLine("^FO360,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDPart No.:^FS") ' Part No.

        pText.AppendLine("^FO350,300") ' X,Y position
        pText.AppendLine("^A0,65,60")  ' font h,w
        pText.AppendLine("^FD" & "" & txtPartNo1.Text & "^FS") ' Part No.

        pText.AppendLine("^FO360,730") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & txtPartDetail1.Text & "^FS") ' Part No. Detail

        pText.AppendLine("^FO290,300") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FD" & "" & txtCustomer2.Text & "^FS") ' Customer part NO.

        pText.AppendLine("^FO240,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDOption:^FS") ' Option

        pText.AppendLine("^FO220,680") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDQ'ty:^FS") ' Q'ty

        pText.AppendLine("^FO220,850") ' X,Y position
        pText.AppendLine("^A0,65,55")  ' font h,w
        pText.AppendLine("^FD" & "" & txtSetquantity1.Text & "^FS") ' Q'ty:

        pText.AppendLine("^FO160,650") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDSerial:^FS") ' Serial

        pText.AppendLine("^FO160,850") ' X,Y position
        pText.AppendLine("^A0,40,30")  ' font h,w
        pText.AppendLine("^FD" & "" & lbSerialNo1.Text & "^FS") ' Serial no

        pText.AppendLine("^FO120,280") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDLot Size: " & "" & txtLotSize1.Text & "^FS") ' Lot Size

        pText.AppendLine("^FO50,280") ' X,Y position
        pText.AppendLine("^A0,45,40")  ' font h,w
        pText.AppendLine("^FDLot No.: " & "" & lbShiftDate.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & lbSerialNo1.Text & "^FS") ' Lot No.
        'Barcode----------------------------------------------------------
        pText.AppendLine("^FO50,80") ' X,Y position
        'pText.AppendLine("^BQ,2,4")  ' QRcode model,magnify
        'pText.AppendLine("^FDQA," & "" & txtCustomer1.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "|Auto ^FS") 'New
        pText.AppendLine("^BQ,2,6")  ' QRcode model,magnify
        pText.AppendLine("^FDQA," & "" & lbShiftDate.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "^FS") 'Current barcode
        pText.AppendLine("^FO50,1300") ' X,Y position
        'pText.AppendLine("^BQ,2,3")  ' QRcode model,magnify
        'pText.AppendLine("^FDQA," & "" & txtCustomer1.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "|Auto ^FS") 'New
        pText.AppendLine("^BQ,2,4")  ' QRcode model,magnify
        pText.AppendLine("^FDQA," & "" & lbShiftDate.Text & "|" & txtPartNo1.Text & "|" & lbRouting.Text & "|" & lbSerialNo1.Text & "|" & txtSetquantity1.Text & "^FS") 'Current barcode
        '------------------------------------------------------------------
        pText.AppendLine("^FO200,1300^A0N,30,35") ' X,Y position
        pText.AppendLine("^FD" & "" & txtPartNo1.Text & "   Q'ty. " & "" & txtSetquantity1.Text & "^FS") ' part No.
        pText.AppendLine("^FO200,1350^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & txtPartDetail1.Text & "^FS") ' Lot No.
        pText.AppendLine("^FO200,1400^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & " " & "" & txtPartNo1.Text & " " & "" & lbRouting.Text & " " & "" & lbSerialNo1.Text & "^FS") ' part No.

        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL) (Copy 1)") 'print the string USB
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbLotPrinter.Text) 'print the string USB
    End Sub
    Private Sub ManualPrintLabel()
        Dim k As Integer = cmbSerial.Text
        Dim l As Integer = cmbSerial2.Text
        For count As Integer = k To l
            If count >= k And count <= l Then
                If rbMatrix.Checked = True Then
                    Label30X550MatrixManual()
                Else
                    Label30X550QRManual()
                End If
                SaveDataLogManual()
                'UpdateManualSerial()
                'AutoSerialUp()
                'ListviewAdd()
                cnt3 = cmbSerial.Text
                cnt3 = Format(Microsoft.VisualBasic.Right(cnt3.ToString, 4) + 1, "0000")
                cmbSerial.Text = cnt3
                ShowDataLog()
                Continue For
            End If
        Next
        ShowPrintManual()
    End Sub
    Private Sub ManualPrintLabelByCount()
        Dim k As Integer = cmbSerial.Text
        Dim l As Integer = cmbSerial2.Text
        For count As Integer = k To l
            If count >= k And count <= l Then
                If rbMatrix.Checked = True Then
                    Label30X550MatrixManual()
                Else
                    Label30X550QRManual()
                End If
                SaveDataLogManual()
                ListviewAdd()
                cnt3 = cmbSerial.Text
                cnt3 = Format(Microsoft.VisualBasic.Right(cnt3.ToString, 4) + 1, "0000")
                cmbSerial.Text = cnt3
                ShowDataLog()
                Continue For
            End If
        Next
        ShowPrintManual()
    End Sub
    Private Sub Label30X550MatrixManual()
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=50
        pText.AppendLine("^FWR") ' Rotate 90
        pText.AppendLine("^FO500,80") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FDHalla Visteon Climate Control(Thailand)Co.,Ltd.^FS") ' 

        pText.AppendLine("^FO430,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDRounting:^FS") ' Rounting No.

        pText.AppendLine("^FO420,300") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & lbRouting.Text & "^FS") ' Rounting No.

        pText.AppendLine("^FO440,600") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbLeakTest.Text & "^FS") ' Leak Test

        pText.AppendLine("^FO360,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDPart No.:^FS") ' Part No.

        pText.AppendLine("^FO350,300") ' X,Y position
        pText.AppendLine("^A0,65,60")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbPartNo.Text & "^FS") ' Part No.

        pText.AppendLine("^FO360,730") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbDetail.Text & "^FS") ' Part No. Detail

        pText.AppendLine("^FO290,300") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbCustomer2.Text & "^FS") ' Customer part NO.

        pText.AppendLine("^FO240,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDOption:^FS") ' Option

        pText.AppendLine("^FO220,680") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDQ'ty:^FS") ' Q'ty

        pText.AppendLine("^FO220,850") ' X,Y position
        pText.AppendLine("^A0,65,55")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbQuantity.Text & "^FS") ' Q'ty:

        pText.AppendLine("^FO160,650") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDSerial:^FS") ' Serial

        pText.AppendLine("^FO160,850") ' X,Y position
        pText.AppendLine("^A0,40,30")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbSerial.Text & "^FS") ' Serial no

        pText.AppendLine("^FO120,280") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDLot Size: " & "" & cmbLotSize.Text & "^FS") ' Lot Size

        pText.AppendLine("^FO50,280") ' X,Y position
        pText.AppendLine("^A0,45,40")  ' font h,w
        pText.AppendLine("^FDLot No.: " & "" & lbShiftDate.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & cmbSerial.Text & "^FS") ' Lot No.
        'Bar Code-------------------------------------------------
        pText.AppendLine("^FO50,80") ' X,Y position
        'pText.AppendLine("^BX,5,200")  ' Matrix Code
        'pText.AppendLine("^FD" & "" & cmbCustomer.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "|Manual ^FS") '
        pText.AppendLine("^BX,8,200")  ' Matrix Code
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "^FS") 'Current barcode
        pText.AppendLine("^FO50,1300") ' X,Y position
        'pText.AppendLine("^BXB,4,200")  ' Matrix Code Rotate 90
        'pText.AppendLine("^FD" & "" & cmbCustomer.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "|Manual ^FS") '
        pText.AppendLine("^BXB,5,200")  ' Matrix Code Rotate 90
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "^FS") 'Current barcode
        '-----------------------------------------------------------
        pText.AppendLine("^FO200,1300^A0N,30,35") ' X,Y position
        pText.AppendLine("^FD" & "" & cmbPartNo.Text & "   Q'ty. " & "" & cmbLotSize.Text & "^FS") ' part No.
        pText.AppendLine("^FO200,1350^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & cmbDetail.Text & "^FS") ' Lot No.
        pText.AppendLine("^FO200,1400^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & " " & "" & cmbPartNo.Text & " " & "" & lbRouting.Text & " " & "" & cmbSerial.Text & "^FS") ' part No.

        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL) (Copy 1)") 'print the string USB
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbLotPrinter.Text) 'print the string USB HVCC
    End Sub
    Private Sub Label30X550QRManual()
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=50
        pText.AppendLine("^FWR") ' Rotate 90
        pText.AppendLine("^FO500,80") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FDHalla Visteon Climate Control(Thailand)Co.,Ltd.^FS") ' 

        pText.AppendLine("^FO430,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDRounting:^FS") ' Rounting No.

        pText.AppendLine("^FO420,300") ' X,Y position
        pText.AppendLine("^A0,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & lbRouting.Text & "^FS") ' Rounting No.

        pText.AppendLine("^FO440,600") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbLeakTest.Text & "^FS") ' Leak Test

        pText.AppendLine("^FO360,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDPart No.:^FS") ' Part No.

        pText.AppendLine("^FO350,300") ' X,Y position
        pText.AppendLine("^A0,65,60")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbPartNo.Text & "^FS") ' Part No.

        pText.AppendLine("^FO360,730") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbDetail.Text & "^FS") ' Part No. Detail

        pText.AppendLine("^FO290,300") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbCustomer2.Text & "^FS") ' Customer part NO.

        pText.AppendLine("^FO240,80") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDOption:^FS") ' Option

        pText.AppendLine("^FO220,680") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDQ'ty:^FS") ' Q'ty

        pText.AppendLine("^FO220,850") ' X,Y position
        pText.AppendLine("^A0,65,55")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbQuantity.Text & "^FS") ' Q'ty:

        pText.AppendLine("^FO160,650") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDSerial:^FS") ' Serial

        pText.AppendLine("^FO160,850") ' X,Y position
        pText.AppendLine("^A0,40,30")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbSerial.Text & "^FS") ' Serial no

        pText.AppendLine("^FO120,280") ' X,Y position
        pText.AppendLine("^A0,40,35")  ' font h,w
        pText.AppendLine("^FDLot Size: " & "" & cmbLotSize.Text & "^FS") ' Lot Size

        pText.AppendLine("^FO50,280") ' X,Y position
        pText.AppendLine("^A0,45,40")  ' font h,w
        pText.AppendLine("^FDLot No.: " & "" & lbShiftDate.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & cmbSerial.Text & "^FS") ' Lot No.
        'Barcode----------------------------------------------------------
        pText.AppendLine("^FO50,80") ' X,Y position
        'pText.AppendLine("^BQ,2,4")  ' QRcode model,magnify
        'pText.AppendLine("^FDQA," & "" & cmbCustomer.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "|Manual ^FS") '
        pText.AppendLine("^BQ,2,6")  ' QRcode model,magnify
        pText.AppendLine("^FDQA," & "" & lbShiftDate.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "^FS") 'Current barcode
        pText.AppendLine("^FO50,1300") ' X,Y position
        'pText.AppendLine("^BQ,2,3")  ' QRcode model,magnify
        'pText.AppendLine("^FDQA," & "" & cmbCustomer.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & tsToday.Text & "|" & lbShift.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "|Manual ^FS") '
        pText.AppendLine("^BQ,2,4")  ' QRcode model,magnify
        pText.AppendLine("^FDQA," & "" & lbShiftDate.Text & "|" & cmbPartNo.Text & "|" & lbRouting.Text & "|" & cmbSerial.Text & "|" & cmbQuantity.Text & "^FS") 'Current barcode
        '------------------------------------------------------------------

        pText.AppendLine("^FO200,1300^A0N,30,35") ' X,Y position
        pText.AppendLine("^FD" & "" & cmbPartNo.Text & "   Q'ty. " & "" & cmbLotSize.Text & "^FS") ' part No.
        pText.AppendLine("^FO200,1350^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & cmbDetail.Text & "^FS") ' Lot No.
        pText.AppendLine("^FO200,1400^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD" & "" & lbShiftDate.Text & " " & "" & cmbPartNo.Text & " " & "" & lbRouting.Text & " " & "" & cmbSerial.Text & "^FS") ' part No.

        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL) (Copy 1)") 'print the string USB
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbLotPrinter.Text) 'print the string USB
    End Sub
#End Region
#Region "[[[Each Print]]]"
    Private Sub rbEachQR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEachQR.CheckedChanged
        If rbEachQR.Checked = True Then
            PictureBox2.Image = My.Resources._AS
        Else
            PictureBox2.Image = My.Resources.barcode_image1
        End If
    End Sub
    Private Sub AutoPrintOneByOne()
        If lbPrintUse.Text = "NO" Then
            Exit Sub
        Else
            If rbEachQR.Checked = True Then
                Label55X25QR()
            Else
                Label55X25Matrix()
            End If
            NotifyIcon1.BalloonTipText = "Print Each Label in Progress...."
            NotifyIcon1.ShowBalloonTip(100)
            SaveDataLogAuto()
            ShowDataLog()
        End If
    End Sub
    Private Sub Label55X25Matrix()
        Dim Cus21 As String = Format(Microsoft.VisualBasic.Left(txtCustomer2.Text, 4))
        Dim Cus22 As String = Format(Microsoft.VisualBasic.Right(txtCustomer2.Text, 1))
        Dim Cus11 As String = Format(Microsoft.VisualBasic.Mid$(txtCustomer1.Text, 5, 6))
        Dim Cus12 As String = Format(Microsoft.VisualBasic.Mid$(txtCustomer1.Text, 12)) ', 2))
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=100

        pText.AppendLine("^FO30,100") ' X,Y position
        pText.AppendLine("^A0N,150,130")  ' font h,w
        pText.AppendLine("^FD" & "" & lbCode.Text & "^FS") ' Code

        pText.AppendLine("^FO150,120") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus21 & "^FS") ' Customer No.2 UC9P

        pText.AppendLine("^FO150,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus11 & "^FS") ' Customer No.1 19B5555

        pText.AppendLine("^FO330,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus12 & "^FS") ' Customer No.1 CG

        'Bar Code-------------------------------------------------
        pText.AppendLine("^FO400,40") ' X,Y position
        pText.AppendLine("^BX,5,200")  ' Matrix Code
        pText.AppendLine("^FD" & "" & Cus21 & "-" & Cus11 & "-" & Cus12 & " " & txtPartNo1.Text & " " & tsToday.Text & " " & lbCounter.Text & " " & lbShift.Text & " " & lbgsdb.Text & "^FS") 'Current Matrix barcode
        '-----------------------------------------------------------
        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL)") 'print the string USB AS
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbEachPrinter.Text) 'print the string USB HVCC printer
    End Sub
    Private Sub Label55X25QR()
        Dim Cus21 As String = Format(Microsoft.VisualBasic.Left(txtCustomer2.Text, 4))
        Dim Cus22 As String = Format(Microsoft.VisualBasic.Right(txtCustomer2.Text, 1))
        Dim Cus11 As String = Format(Microsoft.VisualBasic.Mid$(txtCustomer1.Text, 5, 6))
        Dim Cus12 As String = Format(Microsoft.VisualBasic.Mid$(txtCustomer1.Text, 12)) ', 2))
        Dim Cus13 As String = Format(Microsoft.VisualBasic.Left(txtCustomer1.Text, 4))
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=100

        pText.AppendLine("^FO30,100") ' X,Y position
        pText.AppendLine("^A0N,150,130")  ' font h,w
        pText.AppendLine("^FD" & "" & lbCode.Text & "^FS") ' Code

        pText.AppendLine("^FO150,120") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus21 & "^FS") ' Customer No.2 UC9P

        pText.AppendLine("^FO330,120") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus22 & "^FS") ' Customer No.2 E

        pText.AppendLine("^FO150,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus11 & "^FS") ' Customer No.1 19B5555

        pText.AppendLine("^FO330,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus12 & "^FS") ' Customer No.1 CG

        'Barcode----------------------------------------------------------
        pText.AppendLine("^FO400,40") ' X,Y position
        pText.AppendLine("^BQ,2,5")  ' QRcode model,magnify
        'pText.AppendLine("^FDQA," & "" & Cus13 & "-" & Cus11 & " " & cmbPartNo.Text & " " & tsToday.Text & " " & cmbSerial.Text & " " & lbShift.Text & " " & lbgsdb.Text & "^FS") 'Spare QR barcode
        pText.AppendLine("^FDQA," & "" & txtPartNo1.Text & " " & tsToday.Text & " " & lbCounter.Text & " " & lbShift.Text & "^FS") 'Current QR barcode
        '------------------------------------------------------------------
        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL)") 'print the string USB     
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbEachPrinter.Text) 'print the string USB HVCC---Zebra ZM400 (300 dpi) - ZPL---
    End Sub
    Private Sub ManualPrintOneByOne()
        Dim i As Integer = cmbCounter.Text
        Dim j As Integer = cmbCounter2.Text
        For count As Integer = i To j
            If count >= i And count <= j Then
                If rbEachQR.Checked = True Then
                    Label55X25QRManual()
                Else
                    Label55X25MatrixManual()
                End If
                SaveDataLogManual()
                'UpdateManualCounter()
                'CountQuantityManual()
                'AutoCounterUp()
                'ListviewAdd()
                cnt2 = cmbCounter.Text
                cnt2 = Format(Microsoft.VisualBasic.Right(cnt2.ToString, 4) + 1, "0000")
                cmbCounter.Text = cnt2
                NotifyIcon1.BalloonTipText = "Print Each Label in Progress...."
                NotifyIcon1.ShowBalloonTip(100)
                ShowDataLog()
                Continue For
            End If
        Next
        ShowPrintManual()
    End Sub
    Private Sub Label55X25MatrixManual()
        Dim Cus21 As String = Format(Microsoft.VisualBasic.Left(cmbCustomer2.Text, 4))
        Dim Cus22 As String = Format(Microsoft.VisualBasic.Right(cmbCustomer2.Text, 1))
        Dim Cus11 As String = Format(Microsoft.VisualBasic.Mid$(cmbCustomer1.Text, 5, 6))
        Dim Cus12 As String = Format(Microsoft.VisualBasic.Mid$(cmbCustomer1.Text, 12)) ', 2))
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=100

        pText.AppendLine("^FO30,100") ' X,Y position
        pText.AppendLine("^A0N,150,130")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbCode.Text & "^FS") ' Code

        pText.AppendLine("^FO150,120") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus21 & "^FS") ' Customer No.2 UC9P

        'pText.AppendLine("^FO330,120") ' X,Y position
        'pText.AppendLine("^A0,50,55")  ' font h,w
        'pText.AppendLine("^FD" & "" & Cus22 & "^FS") ' Customer No.2 E

        pText.AppendLine("^FO150,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus11 & "^FS") ' Customer No.1 19B5555

        pText.AppendLine("^FO330,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus12 & "^FS") ' Customer No.1 CG

        'Bar Code-------------------------------------------------
        pText.AppendLine("^FO400,40") ' X,Y position
        pText.AppendLine("^BX,5,200")  ' Matrix Code
        pText.AppendLine("^FD" & "" & Cus21 & "-" & Cus11 & "-" & Cus12 & " " & cmbPartNo.Text & " " & tsToday.Text & " " & cmbCounter.Text & " " & lbShift.Text & " " & lbgsdb.Text & "^FS") 'Current Matrix barcode
        'pText.AppendLine("^FD" & "" & cmbPartNo.Text & " " & tsToday.Text & " " & cmbSerial.Text & " " & lbShift.Text & "^FS") 'Current QR barcode
        '-----------------------------------------------------------
        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL)") 'print the string USB AS
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbEachPrinter.Text) 'print the string USB HVCC printer
    End Sub
    Private Sub Label55X25QRManual()
        Dim Cus21 As String = Format(Microsoft.VisualBasic.Left(cmbCustomer2.Text, 4))
        Dim Cus22 As String = Format(Microsoft.VisualBasic.Right(cmbCustomer2.Text, 1))
        Dim Cus11 As String = Format(Microsoft.VisualBasic.Mid$(cmbCustomer1.Text, 5, 6))
        Dim Cus12 As String = Format(Microsoft.VisualBasic.Mid$(cmbCustomer1.Text, 12)) ', 2))
        Dim Cus13 As String = Format(Microsoft.VisualBasic.Left(cmbCustomer1.Text, 4))
        pText.Remove(0, pText.Length)
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=100
        'pText.AppendLine("^FWR") ' Rotate 90
        pText.AppendLine("^FO30,100") ' X,Y position
        pText.AppendLine("^A0N,150,130")  ' font h,w
        pText.AppendLine("^FD" & "" & cmbCode.Text & "^FS") ' Code

        pText.AppendLine("^FO150,120") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus21 & "^FS") ' Customer No.2 UC9P

        pText.AppendLine("^FO330,120") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus22 & "^FS") ' Customer No.2 E

        pText.AppendLine("^FO150,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus11 & "^FS") ' Customer No.1 19B5555

        pText.AppendLine("^FO330,200") ' X,Y position
        pText.AppendLine("^A0N,50,55")  ' font h,w
        pText.AppendLine("^FD" & "" & Cus12 & "^FS") ' Customer No.1 CG

        'Barcode----------------------------------------------------------
        pText.AppendLine("^FO400,40") ' X,Y position
        pText.AppendLine("^BQ,2,5")  ' QRcode model,magnify
        'pText.AppendLine("^FDQA," & "" & Cus13 & "-" & Cus11 & " " & cmbPartNo.Text & " " & tsToday.Text & " " & cmbSerial.Text & " " & lbShift.Text & " " & lbgsdb.Text & "^FS") 'Spare QR barcode
        pText.AppendLine("^FDQA," & "" & cmbPartNo.Text & " " & tsToday.Text & " " & cmbCounter.Text & " " & lbShift.Text & "^FS") 'Current QR barcode
        '------------------------------------------------------------------
        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        'SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL)") 'print the string USB
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, cmbEachPrinter.Text) 'print the string USB HVCC printer
    End Sub
#End Region
    Private Sub ShowPrinter()
        Dim pkInstalledPrinters As String
        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            cmbLotPrinter.Items.Add(pkInstalledPrinters)
            cmbEachPrinter.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        ' Set the combo to the first printer in the list
        cmbLotPrinter.SelectedIndex = 0
        cmbEachPrinter.SelectedIndex = 0
    End Sub
#End Region
#Region " [[[Processing of WriteDeviceBlock2]]] "
    Private Sub WriteDeviceBlock2()

        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'

        'Displayed output data is cleared.
        ClearDisplay()

        szDeviceName = String.Join(vbLf, Text_DeviceName.Lines)

        'Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        If GetIntValue(Text_Size, iNumberOfDeviceName) = False Then
            'If failed, this process is end.
            Exit Sub
        End If

        'Check the 'DeviceValue'.(If succeeded, the value is gotten.)
        ReDim sharrDeviceValue(iNumberOfDeviceName - 1)
        If GetShortArray(txt_DeviceDataBlock, sharrDeviceValue) = False Then
            'If failed, this process is end.
            Exit Sub
        End If

        '
        'Processing of WriteDeviceBlock2 method
        '
        Try
            iReturnCode = AxActUtlType1.WriteDeviceBlock2(szDeviceName, _
                                                         iNumberOfDeviceName, _
                                                         sharrDeviceValue(0))
        Catch exception As Exception
            MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'The return code of the method is displayed by the hexadecimal.
        Text_ReturnValue.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

    End Sub
#End Region
#Region " [[[Processing of getting ShortType array from StringType array of multiline TextBox]]] "
    Private Function GetShortArray(ByVal txt_SourceOfShortArray As TextBox, ByRef sharrShortArrayValue() As Short) As Boolean

        Dim iSizeOfShortArray As Integer        'Size of ShortType array
        Dim iNumber As Integer                  'Loop counter

        'Get the size of ShortType array.
        iSizeOfShortArray = txt_SourceOfShortArray.Lines.Length

        'Get each element of ShortType array.
        For iNumber = 0 To iSizeOfShortArray - 1
            Try
                sharrShortArrayValue(iNumber) = Convert.ToInt16(txt_SourceOfShortArray.Lines(iNumber))

            Catch exExcepion As Exception
                'When the value is nothing or out of the range, the exception is processed.
                MessageBox.Show(exExcepion.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        Next iNumber

        Return True

    End Function
#End Region
#Region " [[[Processing of Read Value for 32bit Integer]]] "
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Dim lReturnValue As Integer 'Return value
        Dim szDeviceName As String 'Device name
        Dim lSize As Integer 'Size
        Dim lData() As Integer 'Device Value
        Dim szList As String 'Data for ListBox
        Dim lMod As Integer 'Surplus
        Dim lCount As Integer 'Counter

        'The device name is set in szDeviceName.
        szDeviceName = Text_DeviceName.Text
        'The size is set in lSize.
        lSize = CInt(Text_Size.Text)
        'The array for the read device value for the size is secured.
        ReDim lData(lSize)
        'The content of ListBox is cleared.
        List1.Items.Clear()
        'The first line is displayed.
        List1.Items.Add((Chr(9) & "+0" & Chr(9) & "+1" & Chr(9) & "+2" & Chr(9) & "+3" & Chr(9) & "+4" & Chr(9) & "+5" & Chr(9) & "+6" & Chr(9) & "+7"))
        'The second line is displayed.
        List1.Items.Add(("--------------------------------------------------------------------------------------------------------------------------------------------------"))
        'ReadDeviceBlock is executed.
        lReturnValue = AxActUtlType1.ReadDeviceBlock(szDeviceName, lSize, lData(0))
        'Whether ReadDeviceBlock succeeded is checked.
        If lReturnValue <> 0 Then
            Text_ReturnValue.Text = Hex(lReturnValue)
            MsgBox("Failed in ReadDeviceBlock.")
        End If
        For lCount = 0 To lSize
            lMod = lCount Mod 8
            If lMod = 0 Then
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                szList = szList & Str(lCount) & ":" & Chr(9) & Str(lData(lCount)) & Chr(9)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            ElseIf lMod = 7 Then
                szList = szList & Str(lData(lCount)) & Chr(9)
                List1.Items.Add((szList))
                szList = ""
            Else
                szList = szList & Str(lData(lCount)) & Chr(9)
            End If
        Next
        txtModel.Text = Str(lData(0)).ToString.Trim()
        txtOrder.Text = Str(lData(1)).ToString.Trim()
        CountQuantity()
    End Sub
    Private Sub ReadPLC()
        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        Dim szarrData() As String               'Array for 'Data'
        Dim iNumber As Integer                  'Loop counter

        'Displayed output data is cleared.
        ClearDisplay()

        szDeviceName = String.Join(vbLf, Text_DeviceName.Lines)

        'Check the 'DeviceSize'.(If succeeded, the value is gotten.)
        If GetIntValue(Text_Size, iNumberOfDeviceName) = False Then
            'If failed, this process is end.
            Exit Sub
        End If

        'Assign the array for 'DeviceValue'.
        ReDim sharrDeviceValue(iNumberOfDeviceName - 1)

        '
        'Processing of ReadDeviceBlock2 method
        '
        Try

            iReturnCode = AxActUtlType1.ReadDeviceBlock2(szDeviceName, _
                                                        iNumberOfDeviceName, _
                                                        sharrDeviceValue(0))


        Catch exException As Exception
            'Exception processing
            MessageBox.Show(exException.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'The return code of the method is displayed by the hexadecimal.
        Text_ReturnValue.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

        '
        'Display the read data
        '
        'When the ReadDeviceBlock2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            'Assign array for the read data.
            ReDim szarrData(iNumberOfDeviceName - 1)

            'Copy the read data to the 'lpszarrData'.
            For iNumber = 0 To iNumberOfDeviceName - 1
                szarrData(iNumber) = sharrDeviceValue(iNumber).ToString()
            Next iNumber

            'Set the read data to the 'Data', and display it.
            txtModel.Lines = szarrData
        End If
    End Sub
    Private Function GetIntValue(ByVal txt_SourceOfIntValue As TextBox, ByRef iGottenIntValue As Integer) As Boolean
        'Get the value as 32bit integer from TextBox
        Try
            iGottenIntValue = Convert.ToInt32(txt_SourceOfIntValue.Text)
        Catch exExcepion As Exception
            'When the value is nothing or out of the range, the exception is processed.
            MessageBox.Show(exExcepion.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function
    Private Sub ClearDisplay()
        'Clear TextBox of 'ReturnCode','Data'
        Text_ReturnValue.Text = ""
        txtModel.Text = ""
        txtOrder.Text = ""
        lbModel.Text = "Model"
        lbOrder.Text = "Order"
        lbCode.Text = "Code"
        lbAutoModel.Text = "Auto Model"
        lbSerialNo1.Text = "0000"
        lbCounter.Text = "0000"
        txtCustomer1.Text = ""
        txtCustomer2.Text = ""
        txtPartNo1.Text = ""
        txtPartDetail1.Text = ""
        txtLeakTest.Text = ""
        txtSetquantity1.Text = 0
        txtLotSize1.Text = 0
        txtCounter1.Text = 0
        btOK.BackColor = Color.Gray
    End Sub
#End Region
#Region " [[[Processing of displaying error message]]] "
    Private Sub DisplayErrorMessage(ByVal iActReturnCode As Integer)

        Dim szActErrorMessage As String     'Message as the return code of ActUtlType
        Dim iSupportReturnCode As Integer   'Return code of ActSupportMsg
        szActErrorMessage = String.Empty

        'The GetErrorMessage method is executed
        iSupportReturnCode = AxActSupportMsg1.GetErrorMessage(iActReturnCode, szActErrorMessage)

        'When ActSupportMsg returns error code, display error code of ActUtlType.
        If iSupportReturnCode <> 0 Then
            MsgBox("Cannot get the string data of error message." & vbLf & _
                   "  Error code = 0x" & Hex(iActReturnCode), _
                   MsgBoxStyle.Critical)
        Else
            MsgBox(szActErrorMessage, MsgBoxStyle.Critical)
        End If

    End Sub
    Private Sub GetErrorMessage()
        Dim lReturnValue As Integer 'ReturnValue
        Dim szMessage As String 'Message
        Dim lLength As Integer 'Length of ReturnValue string
        szMessage = String.Empty

        'Check whether the value of ReturnValue is a numerical value within the range of the LONG type.
        lLength = Len(Trim(Text_ReturnValue.Text))
        If (lLength > 8) Or (lLength = 0) Then
            MsgBox("Please input error code by the hexadecimal number. ( Range: To LONG type maximum value )")
            Exit Sub
        End If

        'The GetErrorMessage method is executed.
        lReturnValue = AxActSupportMsg1.GetErrorMessage(Val("&H" & Trim(Text_ReturnValue.Text)), szMessage)
        'The trouble shot message is displayed in the message box when succeeding in
        'GetErrorMessage.
        'Whether GetErrorMessage succeeded is checked.
        If lReturnValue = 0 Then
            'When succeeding in GetErrorMessage
            'The trouble shot message is displayed.
            MsgBox(szMessage)
        Else
            'When failing in GetErrorMessage
            MsgBox("Failed in Disconnect.")
        End If
    End Sub
#End Region
#Region " [[[Processing of Open button]]] "
    Private Sub tbConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbConnect.Click
        MonitorStart()
    End Sub
    Private Sub MonitorStart()
        Dim lReturnValue As Integer 'ReturnValue
        'The logical station number is set.
        AxActUtlType1.ActLogicalStationNumber = CInt(Text_LogicalStationNumber.Text)
        'The password is set
        AxActUtlType1.ActPassword = txt_DeviceDataBlock.Text
        'The line is connected.
        lReturnValue = AxActUtlType1.Connect()
        'bConnectFlg is set in True when Connect is executed and succeeds.
        If lReturnValue = 0 Then
            bConnectFlg = True
        End If
        'The return value is checked.
        If lReturnValue = 0 Or lReturnValue = &HF0000007 Then
            'When the return value is 0 or F00000007(Hex)
            'The Open method is executed.
            lReturnValue = AxActUtlType1.Open()
            NotifyIcon1.BalloonTipText = "PLC Connection is Now Open...."
            NotifyIcon1.ShowBalloonTip(500)
            tbConnect.Enabled = False
            tbDisconnect.Enabled = True
            'Whether Open succeeded is checked.
            If lReturnValue <> 0 Then
                'When failing in Open
                'The return value is displayed.
                Text_ReturnValue.Text = Hex(lReturnValue)
                MsgBox("Failed in Open.")
                Exit Sub
            End If
        Else
            'When the return value is not 0 or F0000007(Hex)
            'The return value displays the return value of Connect.
            MsgBox("Failed in Connect.")
            Text_ReturnValue.Text = Hex(lReturnValue)
            Exit Sub
        End If
        'The return value of Open is displayed.
        Text_ReturnValue.Text = Hex(lReturnValue)
        'The interval of the timer is set.
        Timer3.Interval = CInt(Text_MonitorInterval.Text) * 1000
        'The timer processing begins.
        Timer3.Enabled = True
    End Sub
#End Region
#Region " [[[Processing of Close button]]] "
    Private Sub tbDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDisconnect.Click
        MonitorStop()
        ClearDisplay()
        tbConnect.Enabled = True
        tbDisconnect.Enabled = False
    End Sub
    Private Sub MonitorStop()
        Dim lReturnValue As Integer 'Return value
        'The Close method is executed.
        lReturnValue = AxActUtlType1.Close()
        NotifyIcon1.BalloonTipText = "PLC Connection is Now Close...."
        NotifyIcon1.ShowBalloonTip(500)
        'Whether the close succeeded is checked.
        If lReturnValue <> 0 Then
            'When the close fails, the message is displayed.
            MsgBox("Failed in Close.")
        Else
            'When the close succeeds
            'Whether the line was connected is checked.
            If bConnectFlg = True Then
                'The disconnect is executed.
                lReturnValue = AxActUtlType1.Disconnect()
                'When failing in Disconnect
                'The return value of Disconnect is displayed.
                If lReturnValue <> 0 Then
                    Text_ReturnValue.Text = Hex(lReturnValue)
                    MsgBox("Failed in Disconnect.")
                Else
                    'When succeeding in Disconnect
                    bConnectFlg = False
                End If
            End If
        End If
        'The return value is displayed.
        Text_ReturnValue.Text = Hex(lReturnValue)
        'The timer processing is ended.
        Timer3.Enabled = False
    End Sub
#End Region
#Region "[[  Model, Order, Counter  ]]"
    Private Sub CountQuantity()
        If Val(txtOrder.Text) <> 0 Then
            If Val(txtCounter1.Text) < Val(txtSetquantity1.Text) - 1 Then
                cnt1 = Val(txtCounter1.Text)
                cnt1 += 1
                txtCounter1.Text = cnt1
                For Each li In lvPrint.Items
                    If li.SubItems(0).Text = txtModel.Text And li.SubItems(1).Text = txtOrder.Text Then
                        li.SubItems(10).Text() = cnt1
                        li.subitems(11).text() = lbSerialNo1.Text
                        li.subitems(13).text() = lbCounter.Text
                        li.BackColor = Color.LightGreen
                    Else
                        li.BackColor = Color.White
                    End If
                Next
                AutoPrintOneByOne() ' Print each label
                UpdateCounter()
                lbCounter.Refresh()
            Else
                NotifyIcon1.BalloonTipText = "Automatic Lot Print in Progress...."
                NotifyIcon1.ShowBalloonTip(500)
                txtCounter1.Clear()
                txtCounter1.Text = 0
                cnt1 = 0
                For Each li In lvPrint.Items
                    If li.SubItems(0).Text = txtModel.Text And li.SubItems(1).Text = txtOrder.Text Then
                        li.SubItems(10).Text() = 0
                        li.subitems(11).text() = lbSerialNo1.Text
                        li.subitems(13).text() = lbCounter.Text
                        li.BackColor = Color.White
                    End If
                Next
                AutoPrintOneByOne() ' Print each label
                AutoPrintLabel() 'Auto Print Label
                UpdateSerial()
                lbSerialNo1.Refresh()
                AutoSerialUp()
                UpdateCounter()
                lbCounter.Refresh()
            End If
        End If
    End Sub
    Private Sub CountQuantityManual()
        If Val(txtOrder.Text) <> 0 Then
            If Val(txtCounter1.Text) < Val(txtSetquantity1.Text) - 1 Then
                cnt1 = Val(txtCounter1.Text)
                cnt1 += 1
                txtCounter1.Text = cnt1
                For Each li In lvPrint.Items
                    If li.SubItems(0).Text = txtModel.Text And li.SubItems(1).Text = txtOrder.Text Then
                        li.SubItems(10).Text() = cnt1
                        li.subitems(11).text() = lbSerialNo1.Text
                        li.subitems(13).text() = lbCounter.Text

                        li.BackColor = Color.LightGreen
                    Else
                        li.BackColor = Color.White
                    End If
                Next
                'ManualPrintOneByOne() ' Print each label
                'UpdateManualCounter()
                lbCounter.Refresh()
            Else
                NotifyIcon1.BalloonTipText = "Manual Lot Print in Progress...."
                NotifyIcon1.ShowBalloonTip(500)
                txtCounter1.Clear()
                txtCounter1.Text = 0
                cnt1 = 0
                For Each li In lvPrint.Items
                    If li.SubItems(0).Text = txtModel.Text And li.SubItems(1).Text = txtOrder.Text Then
                        li.SubItems(10).Text() = 0
                        li.subitems(11).text() = lbSerialNo1.Text
                        li.subitems(13).text() = lbCounter.Text
                        li.BackColor = Color.White
                    End If
                Next
                ManualPrintLabelByCount()
                UpdateSerial()
                lbSerialNo1.Refresh()
                AutoSerialUp()
               
            End If
        End If
    End Sub
    Private Sub txtOrder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrder.TextChanged
        If Val(txtOrder.Text) <> 0 Then
            btOK.BackColor = Color.Lime
            lbModel.Text = txtModel.Text
            lbOrder.Text = txtOrder.Text
            ShowPrintQueue()
            Dim chk As Integer = CInt(lbAutoModel.Text)
            If chk > 15 Then
                rbEachMatrix.Checked = True
            Else
                rbEachQR.Checked = True
            End If
            AutoSerialUp()
            AutoCounterUp()
          ListviewAdd()
        Else
            btOK.BackColor = Color.LightGreen
        End If
    End Sub
    Private Sub ListviewAdd()
        For Each li In lvPrint.Items
            If li.SubItems(0).Text = txtModel.Text And li.SubItems(1).Text = txtOrder.Text Then
                li.SubItems(10).Text() = txtCounter1.Text
                li.subitems(11).text() = lbSerialNo1.Text
                li.subitems(13).text() = lbCounter.Text
                li.BackColor = Color.LightGreen
            Else
                li.BackColor = Color.White
            End If
        Next
    End Sub
#End Region
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tsToday.Text = Now
        If TimeString >= "08:00:00" And TimeString < "20:00:00" Then
            LoadShiftA()
        Else
            LoadShiftB()
        End If
        AutoCheckDate()
        If TimeString >= "08:00:00" And TimeString < "08:00:06" Then
            UpdateShift()
            ResetCounter()
        End If
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub
    Private Sub lvPrint_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        lvPrint.FullRowSelect = True
    End Sub
    Private Sub dgvLabelPrint_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLabelPrint.CellMouseClick
        On Error Resume Next
        dgvLabelPrint.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
    End Sub
    Private Sub dgvLabelPrint_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabelPrint.RowLeave
        On Error Resume Next
        dgvLabelPrint.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvLabelPrint_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvLabelPrint.RowsAdded
        RunItemNo()
    End Sub
#Region "[[ menubar ]]"
    Private Sub mnuZPLIIManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZPLIIManual.Click
        Dim proc As New Process()
        ZM400_Name = My.Application.Info.DirectoryPath
        'ZM400_Name = "D:\ASEnC\Tax_Invoice"
        If Microsoft.VisualBasic.Right(ZM400_Name, 1) <> "\" Then
            ZM400_Name = ZM400_Name & "\"
        End If
        ZM400_Name = ZM400_Name & "ZPL_II_Code.pdf"
        With proc.StartInfo
            .Arguments = ZM400_Name '"C:\A.pdf"
            .UseShellExecute = True
            .WindowStyle = ProcessWindowStyle.Maximized
            .WorkingDirectory = "C:\Program Files (x86)\Adobe\Acrobat 10.0\Acrobat" '<----- Set Acrobat Install Path
            'C:\Program Files\Adobe\Reader 9.0\Reader
            .FileName = "Acrobat.exe" '<----- Set Acrobat Exe Name
        End With
        proc.Start()
        proc.Close()
        proc.Dispose()
    End Sub
    Private Sub mnuZM400Manual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZM400Manual.Click
        Dim proc As New Process()
        ZM400_Name = My.Application.Info.DirectoryPath
        'ZM400_Name = "D:\ASEnC\Tax_Invoice"
        If Microsoft.VisualBasic.Right(ZM400_Name, 1) <> "\" Then
            ZM400_Name = ZM400_Name & "\"
        End If
        ZM400_Name = ZM400_Name & "ZM400_UG.pdf"
        With proc.StartInfo
            .Arguments = ZM400_Name '"C:\A.pdf"
            .UseShellExecute = True
            .WindowStyle = ProcessWindowStyle.Maximized
            .WorkingDirectory = "C:\Program Files (x86)\Adobe\Acrobat 10.0\Acrobat" '<----- Set Acrobat Install Path
            'C:\Program Files\Adobe\Reader 9.0\Reader
            .FileName = "Acrobat.exe" '<----- Set Acrobat Exe Name
        End With
        proc.Start()
        proc.Close()
        proc.Dispose()
    End Sub
    Private Sub mnuZM400Quick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZM400Quick.Click
        Dim proc As New Process()
        ZM400_Name = My.Application.Info.DirectoryPath
        'ZM400_Name = "D:\ASEnC\Tax_Invoice"
        If Microsoft.VisualBasic.Right(ZM400_Name, 1) <> "\" Then
            ZM400_Name = ZM400_Name & "\"
        End If
        ZM400_Name = ZM400_Name & "ZM400_Quick_Guide.pdf"

        With proc.StartInfo
            .Arguments = ZM400_Name '"C:\A.pdf"
            .UseShellExecute = True
            .WindowStyle = ProcessWindowStyle.Maximized
            .WorkingDirectory = "C:\Program Files (x86)\Adobe\Acrobat 10.0\Acrobat" '<----- Set Acrobat Install Path
            'C:\Program Files\Adobe\Reader 9.0\Reader
            .FileName = "Acrobat.exe" '<----- Set Acrobat Exe Name
        End With
        proc.Start()
        proc.Close()
        proc.Dispose()
    End Sub
    Private Sub mnuModelNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModelNo.Click
        frmAddModel.Show()
    End Sub
    Private Sub mnuAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddOrder.Click
        frmAddOrder.Show()
    End Sub
    Private Sub mnuPartNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPartNo.Click
        frmAddPartNo.Show()
    End Sub
    Private Sub mnuCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCustomer.Click
        frmAddCustomer.Show()
    End Sub
    Private Sub mnuRounting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRounting.Click
        frmRouting.Show()
    End Sub
    Private Sub mnuShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShift.Click
        frmShift.Show()
    End Sub
    Private Sub mnuPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintLabel.Click
        frmPrinting.Show()
    End Sub
    Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        LoadRounting()
        LoadShiftDate()
        ShowDataLog()
    End Sub
    Private Sub mnuManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManual.Click
        mnuManual.Checked = Not mnuManual.Checked
        ManualAuto(mnuManual.Checked)
        frmUserPass.Show()
    End Sub
    Private Sub mnuAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAuto.Click
        mnuAuto.Checked = Not mnuAuto.Checked
        ManualAuto(Not mnuAuto.Checked)
        TabDatalogger.TabPages.Remove(TabManual)
        TabDatalogger.TabPages.Remove(TabAuto)
        TabDatalogger.TabPages.Add(TabAuto)
        frmUserPass.txtID.Clear()
        frmUserPass.txtPass.Clear()
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Do you want to quit ?"   ' Define message.
        style = MsgBoxStyle.DefaultButton2 Or _
           MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        title = "Close windows.."   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then   ' User chose Yes.
            Beep()
            If bConnectFlg = True Then
                AxActUtlType1.Close()
                AxActUtlType1.Disconnect()
            End If
            NotifyIcon1.Icon.Dispose()
            Application.Exit()
        End If
    End Sub
    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        tbPrint_Click(e, e)
    End Sub
#End Region
#Region "[[ toolbar ]]"
    Private Sub tbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPrint.Click
        'Try
        '    If MessageBox.Show("Do you want to print label?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        ManualPrintLabel()
        '        NotifyIcon1.BalloonTipText = "Printer Manual Mode in Progress...."
        '        NotifyIcon1.ShowBalloonTip(500)
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error to Print Label")
        'End Try
    End Sub
    Private Sub tbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbExit.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Do you want to quit ?"   ' Define message.
        style = MsgBoxStyle.DefaultButton2 Or _
           MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        title = "Close windows.."   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then   ' User chose Yes.
            Beep()
            If bConnectFlg = True Then
                AxActUtlType1.Close()
                AxActUtlType1.Disconnect()
            End If
            NotifyIcon1.Icon.Dispose()
            NotifyIcon1.Dispose()
            Application.Exit()
        End If
    End Sub
    Private Sub tbExitmenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbExitmenu.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Do you want to quit ?"   ' Define message.
        style = MsgBoxStyle.DefaultButton2 Or _
           MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        title = "Close windows.."   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then   ' User chose Yes.
            Beep()
            If bConnectFlg = True Then
                AxActUtlType1.Close()
                AxActUtlType1.Disconnect()
            End If
            NotifyIcon1.Icon.Dispose()
            NotifyIcon1.Dispose()
            Application.Exit()
        End If
    End Sub
    Private Sub tbEject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEject.Click
        Try
            If MessageBox.Show("Do you want to eject model from list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For Each lvItem As ListViewItem In lvPrint.SelectedItems
                    EjectSerial()
                    lvItem.Remove()
                Next
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Eject Model")
        End Try

    End Sub
    Private Sub tbConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbConfig.Click
        frmPrinting.Show()
    End Sub
#End Region
    Private Sub ManualAuto(ByVal bManual As Boolean)
        mnuManual.Checked = bManual
        mnuAuto.Checked = Not bManual
        tbPrint.Enabled = bManual
        mnuPrint.Enabled = bManual
    End Sub
    Private Sub lvPrint_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPrint.KeyUp
        If lvPrint.SelectedItems.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                lvPrint.SelectedItems(0).Remove()
            End If
        End If
    End Sub
    Private Sub cmbModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModel.SelectedIndexChanged
        ShowPrintManual()
        If cmbAutomodel.Text <> "" Then
            Dim chk As Integer = CInt(cmbAutomodel.Text)
            If chk > 15 Then
                rbEachMatrix.Checked = True
            Else
                rbEachQR.Checked = True
            End If
        End If
    End Sub
    Private Sub cmbOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrder.SelectedIndexChanged
        ShowPrintManual()
        If cmbAutomodel.Text <> "" Then
            Dim chk As Integer = CInt(cmbAutomodel.Text)
            If chk > 15 Then
                rbEachMatrix.Checked = True
            Else
                rbEachQR.Checked = True
            End If
        End If
    End Sub
    Private Sub TabManual_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabManual.ControlAdded
        ShowModel()
        ShowPrintManual()
    End Sub
    Private Sub lvPrint_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPrint.LostFocus
        lvPrint.BackColor = Color.White
    End Sub
    Private Sub tbLotPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLotPrint.Click
        Try
            If MessageBox.Show("Do you want to print label?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ManualPrintLabel()
                NotifyIcon1.BalloonTipText = "Printer Manual Mode in Progress...."
                NotifyIcon1.ShowBalloonTip(500)
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error to Print Label")
        End Try
    End Sub
    Private Sub tbEachPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEachPrint.Click
        Try
            If MessageBox.Show("Do you want to print label?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ManualPrintOneByOne()
                NotifyIcon1.BalloonTipText = "Printer Manual Mode in Progress...."
                NotifyIcon1.ShowBalloonTip(500)
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error to Print Label")
        End Try
    End Sub
End Class