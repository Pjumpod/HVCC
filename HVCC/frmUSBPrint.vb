Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text
Imports System.Data
Imports ZM400Print
Imports System.Configuration
Imports System.Data.OleDb
Public Class frmUSBPrint
    Dim ZM400_Name As String
    Dim pText As New StringBuilder
    Dim connStr As String = ConfigurationSettings.AppSettings("dbConn")
    Dim Conndb As New OleDb.OleDbConnection(connStr)
    Private Sub tbPrint_Click(sender As System.Object, e As System.EventArgs) Handles tbPrint.Click
        frmRunPage.Show()
    End Sub
#Region "ZPL"
    Private Sub Label70X100()
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1200")   ' Print W=120

        pText.AppendLine("^FO30,80") ' X,Y position
        pText.AppendLine("^A0N,60,55")  ' font h,w
        pText.AppendLine("^FDHalla Visteon Climate Control(Thailand)Co.,Ltd.^FS") ' 

        pText.AppendLine("^FO30,150") ' X,Y position
        pText.AppendLine("^ADN,32,20")  ' font h,w
        pText.AppendLine("^FDRounting:^FS") ' Rounting No.

        pText.AppendLine("^FO280,150") ' X,Y position
        pText.AppendLine("^ADN,50,40")  ' font h,w
        pText.AppendLine("^FD6PARC^FS") ' Rounting No.

        pText.AppendLine("^FO30,220") ' X,Y position
        pText.AppendLine("^ADN,32,20")  ' font h,w
        pText.AppendLine("^FDPart No.:^FS") ' Part No.

        pText.AppendLine("^FO280,220") ' X,Y position
        pText.AppendLine("^ADN,55,35")  ' font h,w
        pText.AppendLine("^FDF200LQ9RA02^FS") ' Part No.

        pText.AppendLine("^FO830,230") ' X,Y position
        pText.AppendLine("^A0N,30,30")  ' font h,w
        pText.AppendLine("^FDConden^FS") ' Part No. Detail

        pText.AppendLine("^FO280,290") ' X,Y position
        pText.AppendLine("^ADN,32,20")  ' font h,w
        pText.AppendLine("^FDDN32-61-480B^FS") ' Customer part NO.

        pText.AppendLine("^FO30,330") ' X,Y position
        pText.AppendLine("^ADN,32,20")  ' font h,w
        pText.AppendLine("^FDOption:^FS") ' Option

        pText.AppendLine("^FO650,330") ' X,Y position
        pText.AppendLine("^ADN,32,18")  ' font h,w
        pText.AppendLine("^FDQ'ty:^FS") ' Q'ty:

        pText.AppendLine("^FO830,330") ' X,Y position
        pText.AppendLine("^ADN,50,40")  ' font h,w
        pText.AppendLine("^FD20^FS") ' Q'ty:

        pText.AppendLine("^FO650,400") ' X,Y position
        pText.AppendLine("^ADN,32,18")  ' font h,w
        pText.AppendLine("^FDSerial: 0042^FS") ' Serial:

        pText.AppendLine("^FO230,400") ' X,Y position
        pText.AppendLine("^ADN,32,15")  ' font h,w
        pText.AppendLine("^FDLot Size: 20^FS") ' Lot Size

        pText.AppendLine("^FO230,470") ' X,Y position
        pText.AppendLine("^ADN,32,15")  ' font h,w
        pText.AppendLine("^FDLot No.: 191214|F200LQ9RA02|6PARC|0042^FS") ' Lot No.

        'pText.AppendLine("^FO100,500") ' X,Y position
        'pText.AppendLine("^BQ,2,6")  ' QRcode model,magnify
        'pText.AppendLine("^FDQM,0123456789ABCD 2D code^FS") ' 
        pText.AppendLine("^FO30,370") ' X,Y position
        pText.AppendLine("^BXN,8,200")  ' Matrix Code
        pText.AppendLine("^FDTESTING ZM400 LABEL PRINTER^FS") '

        'pText.AppendLine("^FWB") ' Rotate 90
        pText.AppendLine("^FO650,550^A0,20,20") ' X,Y position
        pText.AppendLine("^FDF200LQ9RA02|Q'ty.20^FS") ' Lot No.
        pText.AppendLine("^FO680,550^A0,20,20") ' X,Y position
        pText.AppendLine("^FDCONDENSER ASSY^FS") ' Lot No.

        pText.AppendLine("^FO450,600") ' X,Y position
        pText.AppendLine("^BXB,5,200")  ' Matrix Code Rotate 90
        pText.AppendLine("^FDTESTING ZM400 LABEL PRINTER^FS") '

        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL)") 'print the string USB
    End Sub
    Private Sub Label30X550()
        pText.AppendLine("^XA")   ' Start new document
        pText.AppendLine("^PW1000")   ' Print W=50
        pText.AppendLine("^FWR") ' Rotate 90
        pText.AppendLine("^FO500,80") ' X,Y position
        pText.AppendLine("^A0,60,55")  ' font h,w
        pText.AppendLine("^FDHalla Visteon Climate Control(Thailand)Co.,Ltd.^FS") ' 

        pText.AppendLine("^FO430,80") ' X,Y position
        pText.AppendLine("^AD,32,20")  ' font h,w
        pText.AppendLine("^FDRounting:^FS") ' Rounting No.

        pText.AppendLine("^FO420,300") ' X,Y position
        pText.AppendLine("^AD,50,30")  ' font h,w
        pText.AppendLine("^FD6PARC^FS") ' Rounting No.

        pText.AppendLine("^FO360,80") ' X,Y position
        pText.AppendLine("^AD,32,20")  ' font h,w
        pText.AppendLine("^FDPart No.:^FS") ' Part No.

        pText.AppendLine("^FO350,300") ' X,Y position
        pText.AppendLine("^AD,55,30")  ' font h,w
        pText.AppendLine("^FDF200LQ9RA02^FS") ' Part No.

        pText.AppendLine("^FO360,730") ' X,Y position
        pText.AppendLine("^A0,30,25")  ' font h,w
        pText.AppendLine("^FDCONDENSER ASSY (DN32-61480-A) SIGMA^FS") ' Part No. Detail

        pText.AppendLine("^FO290,300") ' X,Y position
        pText.AppendLine("^AD,32,20")  ' font h,w
        pText.AppendLine("^FDDN32-61-480B^FS") ' Customer part NO.

        pText.AppendLine("^FO220,80") ' X,Y position
        pText.AppendLine("^AD,32,20")  ' font h,w
        pText.AppendLine("^FDOption:^FS") ' Option

        pText.AppendLine("^FO220,680") ' X,Y position
        pText.AppendLine("^AD,32,18")  ' font h,w
        pText.AppendLine("^FDQ'ty:^FS") ' Q'ty

        pText.AppendLine("^FO220,850") ' X,Y position
        pText.AppendLine("^AD,50,40")  ' font h,w
        pText.AppendLine("^FD20^FS") ' Q'ty:

        pText.AppendLine("^FO160,630") ' X,Y position
        pText.AppendLine("^AD,32,18")  ' font h,w
        pText.AppendLine("^FDSerial:^FS") ' Serial

        pText.AppendLine("^FO160,850") ' X,Y position
        pText.AppendLine("^AD,32,18")  ' font h,w
        pText.AppendLine("^FD0042^FS") ' Serial no

        pText.AppendLine("^FO120,280") ' X,Y position
        pText.AppendLine("^AD,32,15")  ' font h,w
        pText.AppendLine("^FDLot Size: 20^FS") ' Lot Size

        pText.AppendLine("^FO50,280") ' X,Y position
        pText.AppendLine("^AD,32,15")  ' font h,w
        pText.AppendLine("^FDLot No.: 191214|F200LQ9RA02|6PARC|0042^FS") ' Lot No.

        ''pText.AppendLine("^FO100,500") ' X,Y position
        ''pText.AppendLine("^BQ,2,6")  ' QRcode model,magnify
        ''pText.AppendLine("^FDQM,0123456789ABCD 2D code^FS") ' 
        pText.AppendLine("^FO50,80") ' X,Y position
        pText.AppendLine("^BX,8,200")  ' Matrix Code
        pText.AppendLine("^FDTESTING ZM400 LABEL PRINTER^FS") '


        pText.AppendLine("^FO180,1300^A0N,30,35") ' X,Y position
        pText.AppendLine("^FDF200LQ9RA02   Q'ty.20^FS") ' part No.
        pText.AppendLine("^FO180,1350^A0N,20,20") ' X,Y position
        pText.AppendLine("^FDCONDENSER ASSY (DN32-61480-A) SIGMA^FS") ' Lot No.
        pText.AppendLine("^FO180,1400^A0N,20,20") ' X,Y position
        pText.AppendLine("^FD191214 F200LQ9RA02 6PARC 0041^FS") ' part No.

        pText.AppendLine("^FO50,1300") ' X,Y position
        pText.AppendLine("^BXB,5,200")  ' Matrix Code Rotate 90
        pText.AppendLine("^FDTESTING ZM400 LABEL PRINTER^FS") '

        'pText.AppendLine("^PQ2") ' Print Quantity 2 copy
        pText.AppendLine("^XZ") ' End Print
        SendToPrinter("ZEBRA ZM400 printing", pText.ToString, "ZDesigner ZM400 300 dpi (ZPL)") 'print the string USB
    End Sub
#End Region
    Private Sub frmUSBPrint_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        ds.Clear()
        Opacity = 1
        Load_treeview()
        lvData.Items.Clear()
        lvData.Update()
        FillListView(Conndb, "tbPartNO")
        lvData.EndUpdate()
    End Sub
    Private Sub frmUSBPrint_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Opacity = 0.5
    End Sub
    Private Sub frmUSBPrint_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim msg As String
        'Dim title As String
        'Dim style As MsgBoxStyle
        'Dim response As MsgBoxResult
        'msg = "Do you want to quit ?"   ' Define message.
        'style = MsgBoxStyle.DefaultButton2 Or _
        '   MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        'title = "Close windows.."   ' Define title.
        '' Display message.
        'response = MsgBox(msg, style, title)
        'If response = MsgBoxResult.Yes Then   ' User chose Yes.
        '    Beep()
        '    Application.Exit()
        'End If
        NotifyIcon1.Dispose()
    End Sub
    Private Sub frmUSBPrint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        ShowAllDatalog()
        'Load_treeview()
        'FillListView(Conndb, "tbPartNO")
    End Sub
    Private Sub ShowAllDatalog()
        ds.Clear()
        dgvLabelPrint.DataBindings.Clear()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT t1.Model,t1.Order,t0.CustomerPartNo,t2.PartNo,t2.PartNoDetail,t2.Quantity,t2.LotSize")
        sb.Append(" FROM (tbPrintLabel t1")
        sb.Append(" INNER JOIN tbPartNo t2")
        sb.Append(" ON t1.PartNo = t2.PartID)")
        sb.Append(" INNER JOIN tbCustomer t0")
        sb.Append(" ON t0.CusID = t1.CustomerNo")
        Dim sqlClient As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlClient
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
        AllDatalogView()
        dr.Close()
    End Sub
    Private Sub AllDatalogView()
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvLabelPrint
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Model"
                .Columns(2).HeaderText = "Order"
                .Columns(3).HeaderText = "Customer Part No."
                .Columns(4).HeaderText = "Part No"
                .Columns(5).HeaderText = "Part No. Detail"
                .Columns(6).HeaderText = "Quantity"
                .Columns(7).HeaderText = "Lot Size"
                '.Columns(8).HeaderText = "PrintID"
                .Columns(0).Width = 60
                .Columns(1).Width = 60
                .Columns(2).Width = 60
                .Columns(3).Width = 250
                .Columns(4).Width = 250
                .Columns(5).Width = 350
                .Columns(6).Width = 200
                .Columns(7).Width = 200
                '.Columns(8).Width = 60
            End If
        End With
        Conndb.Close()
    End Sub
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvLabelPrint.RowCount - 2
            dgvLabelPrint.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lbToday.Text = Now
    End Sub
    Private Sub dgvLabelPrint_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLabelPrint.CellMouseClick
        On Error Resume Next
        dgvLabelPrint.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvLabelPrint.CurrentRow.Index.ToString)
        'txtRouting.Text = dgvLabelPrint.Rows(x).Cells(1).Value()
        'lbID.Text = dgvLabelPrint.Rows(x).Cells(2).Value()
    End Sub
    Private Sub dgvLabelPrint_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabelPrint.RowLeave
        On Error Resume Next
        dgvLabelPrint.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvLabelPrint_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvLabelPrint.RowsAdded
        RunItemNo()
    End Sub
    Private Sub mnuZPLIIManual_Click(sender As System.Object, e As System.EventArgs) Handles mnuZPLIIManual.Click
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
    Private Sub mnuZM400Manual_Click(sender As System.Object, e As System.EventArgs) Handles mnuZM400Manual.Click
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
    Private Sub mnuZM400Quick_Click(sender As System.Object, e As System.EventArgs) Handles mnuZM400Quick.Click
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
    Private Sub mnuAddOrder_Click(sender As System.Object, e As System.EventArgs) Handles mnuAddOrder.Click
        frmAddOrder.Show()
    End Sub
    Private Sub mnuModelNo_Click(sender As System.Object, e As System.EventArgs) Handles mnuModelNo.Click
        frmAddModel.Show()
    End Sub
    Private Sub mnuCustomer_Click(sender As System.Object, e As System.EventArgs) Handles mnuCustomer.Click
        frmAddCustomer.Show()
    End Sub
    Private Sub mnuPartNo_Click(sender As System.Object, e As System.EventArgs) Handles mnuPartNo.Click
        frmAddPartNo.Show()
    End Sub
    Private Sub mnuRounting_Click(sender As System.Object, e As System.EventArgs) Handles mnuRounting.Click
        frmRouting.Show()
    End Sub
    Private Sub mnuShift_Click(sender As System.Object, e As System.EventArgs) Handles mnuShift.Click
        frmShift.Show()
    End Sub
    Private Sub Load_treeview()
        Dim recCount As Integer
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT PartNo,PartNoDetail,Quantity,LotSize")
        sb.Append(" FROM tbPartNo")
        Dim sqlClient As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlClient
            .Connection = Conndb
        End With
        da.SelectCommand = cmd
        da.Fill(ds)
        If Not ds.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("There were no results found.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            'NotifyIcon1.BalloonTipText = "TOTAL NUMBER OF PART NO. IS: " & ds.Tables(0).Rows.Count
            'NotifyIcon1.ShowBalloonTip(300)
            recCount = ds.Tables(0).Rows.Count
            tvData.Nodes.Clear()  'Clear any nodes so we don't load a tree into a tree
            Dim parentRow As DataRow
            Dim tbl As New DataTable
            Dim rowNdx As Integer
            rowNdx = 0
            da.Fill(tbl)
            Dim strLease As String
            For Each parentRow In tbl.Rows
                If rowNdx = recCount Then
                    Exit For
                End If
                strLease = ds.Tables(0).Rows(rowNdx)("PartNo").ToString() 'set the next name 
                Dim pnode As TreeNode
                pnode = tvData.Nodes.Add(ds.Tables(0).Rows(rowNdx)("PartNo").ToString())
                Dim cnode As TreeNode
                cnode = New TreeNode
                Do While ds.Tables(0).Rows(rowNdx)("PartNo").ToString() = strLease And rowNdx < recCount
                    'if it changes we need to kick out of Do While
                    cnode = pnode.Nodes.Add(ds.Tables(0).Rows(rowNdx)("PartNoDetail").ToString())
                    cnode = pnode.Nodes.Add(ds.Tables(0).Rows(rowNdx)("Quantity").ToString())
                    cnode = pnode.Nodes.Add(ds.Tables(0).Rows(rowNdx)("LotSize").ToString())
                    rowNdx = rowNdx + 1
                    If rowNdx = recCount Then
                        Exit Do
                    End If
                Loop
            Next parentRow
            Conndb.Close()
        End If
    End Sub
    Private Sub FillListView(ByVal cnn As OleDbConnection, ByVal tabName As String)
        Dim cmdRead As OleDbCommand
        Dim datReader As OleDbDataReader
        Dim strField As String
        Dim c As Integer
        'lblTableName.Text = tabName
        'strField = "SELECT * FROM [" & tabName & "]"
        strField = "SELECT PartNO,PartNoDetail,Quantity,LotSize FROM [" & tabName & "]"
        'Initialize cmdRead object
        cmdRead = New OleDbCommand(strField, cnn)
        cnn.Open()
        datReader = cmdRead.ExecuteReader()
        ' fill ListView
        Do While datReader.Read()
            Dim objListItem As New ListViewItem(datReader.Item(0).ToString)
            For c = 1 To datReader.FieldCount - 1
                objListItem.SubItems.Add(datReader.Item(c).ToString)
            Next
            objListItem.ImageIndex = 5
            lvData.Items.Add(objListItem)
        Loop
        datReader.Close()
        cnn.Close()
    End Sub
    Private Sub mnuExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuExit.Click
        'Dim msg As String
        'Dim title As String
        'Dim style As MsgBoxStyle
        'Dim response As MsgBoxResult
        'msg = "Do you want to quit ?"   ' Define message.
        'style = MsgBoxStyle.DefaultButton2 Or _
        '   MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        'title = "Close windows.."   ' Define title.
        '' Display message.
        'response = MsgBox(msg, style, title)
        'If response = MsgBoxResult.Yes Then   ' User chose Yes.
        '    Beep()
        Application.Exit()
        'End If
    End Sub
    Private Sub tvData_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvData.AfterSelect
        Dim x As String
        x = tvData.SelectedNode.Text
        lvData.Items.Clear()
        lvData.BeginUpdate()
        Dim cmdRead As OleDbCommand
        Dim datReader As OleDbDataReader
        Dim strField As String
        Dim c As Integer
        strField = "SELECT PartNO,PartNoDetail,Quantity,LotSize FROM [tbPartNo] WHERE PartNO='" & x.ToString & "'"
        'Initialize cmdRead object
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        cmdRead = New OleDbCommand(strField, Conndb)
        datReader = cmdRead.ExecuteReader()
        ' fill ListView
        Do While datReader.Read()
            Dim objListItem As New ListViewItem(datReader.Item(0).ToString)
            For c = 1 To datReader.FieldCount - 1
                objListItem.SubItems.Add(datReader.Item(c).ToString)
            Next
            objListItem.ImageIndex = 5
            lvData.Items.Add(objListItem)
        Loop
        datReader.Close()
        Conndb.Close()
        lvData.Update()
        lvData.EndUpdate()
    End Sub
    Private Sub mnuRefresh_Click(sender As System.Object, e As System.EventArgs) Handles mnuRefresh.Click
        ds.Clear()
        Load_treeview()
        lvData.Items.Clear()
        lvData.Update()
        FillListView(Conndb, "tbPartNO")
        lvData.EndUpdate()
    End Sub
    Private Sub mnuPrint_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrint.Click
        frmRunPage.Show()
    End Sub
    Private Sub mnuPrintLabel_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrintLabel.Click
        frmPrinting.Show()
    End Sub
End Class