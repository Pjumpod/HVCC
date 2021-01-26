Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmPrinting
    Private Sub frmPrinting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowModel()
        ShowPrint()
    End Sub
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
        sb.Remove(0, sb.Length)
        'sb.Append("SELECT OrderID,OrderNo FROM tbOrderNo;")
        'Dim sqlOrder As String = sb.ToString()
        'With cmd
        '    .CommandText = sqlOrder
        '    .CommandType = CommandType.Text
        '    .Connection = Conndb
        '    dr = cmd.ExecuteReader()
        'End With
        'If dr.HasRows Then
        '    Dim dtOrder = New DataTable()
        '    dtOrder.Load(dr)
        '    With cmbOrder
        '        .BeginUpdate()
        '        .DisplayMember = "OrderNo"
        '        .ValueMember = "OrderID"
        '        .DataSource = dtOrder
        '        .EndUpdate()
        '    End With
        'End If
        sb.Remove(0, sb.Length)
        sb.Append("SELECT CusID,CustomerPartNo,CustomerPartNo2 FROM tbCustomer; ")
        Dim sqlCus As String = sb.ToString()
        With cmd
            .CommandText = sqlCus
            .CommandType = CommandType.Text
            .Connection = Conndb
            dr = cmd.ExecuteReader()
        End With
        If dr.HasRows Then
            Dim dtCus = New DataTable()
            dtCus.Load(dr)
            With cmbCusNo1
                .BeginUpdate()
                .DisplayMember = "CustomerPartNo"
                .ValueMember = "CusID"
                .DataSource = dtCus
                .EndUpdate()
            End With
            With cmbCusNo2
                .BeginUpdate()
                .DisplayMember = "CustomerPartNo2"
                .ValueMember = "CusID"
                .DataSource = dtCus
                .EndUpdate()
            End With
            With cmbCusID
                .BeginUpdate()
                .DisplayMember = "CusID"
                .ValueMember = "CusID"
                .DataSource = dtCus
                .EndUpdate()
            End With
        End If
        sb.Remove(0, sb.Length)
        sb.Append("SELECT PartID,PartNo FROM tbPartNo")
        Dim sqlPart As String = sb.ToString()
        With cmd
            .CommandText = sqlPart
            .CommandType = CommandType.Text
            .Connection = Conndb
            dr = cmd.ExecuteReader()
        End With
        If dr.HasRows Then
            Dim dtPart = New DataTable()
            dtPart.Load(dr)
            With cmbPartNo
                .BeginUpdate()
                .DisplayMember = "PartNo"
                .ValueMember = "PartID"
                .DataSource = dtPart
                .EndUpdate()
            End With
            With cmbPartID
                .BeginUpdate()
                .DisplayMember = "PartID"
                .ValueMember = "PartID"
                .DataSource = dtPart
                .EndUpdate()
            End With
        End If
        dr.Close()
    End Sub
#Region "Transection area"
    Private Sub ShowPrint()
        On Error Resume Next
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT t1.Model,t0.CustomerPartNo,t0.CustomerPartNo2,t2.PartNo,t2.PartNoDetail,t1.LeakTest,t2.Quantity,t2.LotSize,t1.Print,t1.PrintID,t2.PartID,t0.CusID")
        sb.Append(" FROM (tbPrintLabel t1")
        sb.Append(" INNER JOIN tbPartNo t2")
        sb.Append(" ON t1.PartNo = t2.PartID)")
        sb.Append(" INNER JOIN tbCustomer t0")
        sb.Append(" ON t0.CusID = t1.CustomerNo")
        sb.Append(" ORDER BY t2.AutoModel")
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
                dgvAddPrinting.DataSource = dt
            Else
                dgvAddPrinting.DataSource = Nothing
            End If
        End With
        PrintView()
    End Sub
    Private Sub UpdatePrint()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbPrintLabel SET PartNo=" & Val(cmbPartID.Text) & ",CustomerNo=" & Val(cmbCusID.Text) & ",")
        sb.Append("[Model]='" & cmbModel.Text & "',[LeakTest]='" & txtLeakTest.Text & "',")
        sb.Append("[Print]='" & cmbPrintUse.Text & "'")
        sb.Append(" WHERE PrintID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdUpdate.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub SavePrint()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("INSERT INTO tbPrintLabel([PartNo],[CustomerNo],[Model],[LeakTest],[Counter],[Serial],[EachCount],[Print])")
        sb.Append(" Values (" & Val(cmbPartID.Text) & "," & Val(cmbCusID.Text) & ",'" & cmbModel.Text & "','" & txtLeakTest.Text & "','0','0000','0000','" & cmbPrintUse.Text & "')")
        Dim sqlPrint As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlPrint, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub DeletePrint()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("DELETE FROM tbPrintLabel")
        sb.Append(" WHERE PrintID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdDelete As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdDelete.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub PrintView()
        On Error Resume Next
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 8, FontStyle.Bold)
        With dgvAddPrinting
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Model"
                '.Columns(2).HeaderText = "Order"
                .Columns(2).HeaderText = "Customer Part No.1"
                .Columns(3).HeaderText = "Customer Part No.2"
                .Columns(4).HeaderText = "Part No"
                .Columns(5).HeaderText = "Part No. Detail"
                .Columns(6).HeaderText = "Leak Test"
                .Columns(7).HeaderText = "Quantity"
                .Columns(8).HeaderText = "Lot Size"
                .Columns(9).HeaderText = "Print"
                .Columns(0).Width = 60
                .Columns(1).Width = 60
                '.Columns(2).Width = 60
                .Columns(2).Width = 150
                .Columns(3).Width = 150
                .Columns(4).Width = 150
                .Columns(5).Width = 200
                .Columns(6).Width = 200
                .Columns(7).Width = 80
                .Columns(8).Width = 80
            End If
        End With
        Conndb.Close()
    End Sub
#End Region
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvAddPrinting.RowCount - 2
            dgvAddPrinting.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub tbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save print setup into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cmbPartNo.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    cmbPartNo.Focus()
                    Exit Sub
                Else
                    SavePrint()
                    cmbPartNo.Focus()
                    ds.Clear()
                    ShowPrint()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub dgvAddPrinting_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAddPrinting.CellMouseClick
        On Error Resume Next
        dgvAddPrinting.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvAddPrinting.CurrentRow.Index.ToString)
        cmbModel.Text = dgvAddPrinting.Rows(x).Cells(1).Value()
        'cmbOrder.Text = dgvAddPrinting.Rows(x).Cells(2).Value()
        cmbCusNo1.Text = dgvAddPrinting.Rows(x).Cells(2).Value()
        cmbCusNo2.Text = dgvAddPrinting.Rows(x).Cells(3).Value()
        cmbPartNo.Text = dgvAddPrinting.Rows(x).Cells(4).Value()
        txtLeakTest.Text = dgvAddPrinting.Rows(x).Cells(6).Value()
        cmbPrintUse.Text = dgvAddPrinting.Rows(x).Cells(9).Value()
        lbID.Text = dgvAddPrinting.Rows(x).Cells(10).Value()
        cmbPartID.Text = dgvAddPrinting.Rows(x).Cells(11).Value()
        cmbCusID.Text = dgvAddPrinting.Rows(x).Cells(12).Value()
    End Sub
    Private Sub dgvAddPrinting_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddPrinting.RowLeave
        On Error Resume Next
        dgvAddPrinting.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        'txtLeakTest.Text = Nothing
    End Sub
    Private Sub dgvAddPrinting_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAddPrinting.RowsAdded
        RunItemNo()
    End Sub
    Private Sub tbUpdate_Click(sender As System.Object, e As System.EventArgs) Handles tbUpdate.Click
        Try
            If MessageBox.Show("Do you want to update print setup into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cmbPartNo.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    cmbPartNo.Focus()
                    Exit Sub
                Else
                    UpdatePrint()
                    cmbPartNo.Focus()
                    ds.Clear()
                    ShowPrint()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Update Data")
        End Try
    End Sub
    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        Try
            If MessageBox.Show("Do you want to delete print setup into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cmbPartNo.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    cmbPartNo.Focus()
                    Exit Sub
                Else
                    DeletePrint()
                    cmbPartNo.Focus()
                    ds.Clear()
                    ShowPrint()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Delete Data")
        End Try
    End Sub
End Class