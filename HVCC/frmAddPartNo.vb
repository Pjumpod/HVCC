Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmAddPartNo
    Dim connStr As String = ConfigurationSettings.AppSettings("dbConn")
    Dim Conndb As New OleDb.OleDbConnection(connStr)
    Private Sub frmAddPartNo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowPartNo()
    End Sub
#Region "Transection area"
    Private Sub ShowPartNo()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT PartNo,PartNoDetail,Quantity,LotSize,Code,AutoModel,PartID")
        sb.Append(" FROM tbPartNo")
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
                dgvAddPartNo.DataSource = dt
            Else
                dgvAddPartNo.DataSource = Nothing
            End If
        End With
        PartNoView()
    End Sub
    Private Sub UpdatePartNo()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbPartNo SET PartNo='" & txtPartNo.Text & "',PartNoDetail='" & txtDetail.Text & "',Quantity='" & numQuantity.Value & "',LotSize='" & numLotSize.Value & "',")
        sb.Append("Code='" & txtCode.Text & "',AutoModel='" & txtAutoModel.Text & "'")
        sb.Append(" WHERE PartID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdUpdate.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub SavePartNo()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("INSERT INTO tbPartNo(PartNo,PartNoDetail,Quantity,LotSize,Code,AutoModel)")
        sb.Append(" Values ('" & txtPartNo.Text & "','" & txtDetail.Text & "','" & numQuantity.Value & "','" & numLotSize.Value & "',")
        sb.Append("'" & txtCode.Text & "','" & txtAutoModel.Text & "')")
        Dim sqlPart As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlPart, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub DeletePartNo()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("DELETE FROM tbPartNo")
        sb.Append(" WHERE PartID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdDelete As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdDelete.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub PartNoView()
        On Error Resume Next
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvAddPartNo
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Part No."
                .Columns(2).HeaderText = "Part No. Detail"
                .Columns(3).HeaderText = "Quantity"
                .Columns(4).HeaderText = "Lot Size"
                .Columns(5).HeaderText = "Code"
                .Columns(6).HeaderText = "Auto Model"
                .Columns(0).Width = 60
                .Columns(1).Width = 250
                .Columns(2).Width = 300
                .Columns(3).Width = 100
                .Columns(4).Width = 100
                .Columns(5).Width = 100
                .Columns(6).Width = 100
            End If
        End With
        Conndb.Close()
    End Sub
#End Region
    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save part no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtPartNo.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtPartNo.Focus()
                    Exit Sub
                Else
                    SavePartNo()
                    txtPartNo.Clear()
                    txtDetail.Clear()
                    txtPartNo.Focus()
                    numQuantity.Value = 0
                    numLotSize.Value = 0
                    ds.Clear()
                    ShowPartNo()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbUpdate_Click(sender As System.Object, e As System.EventArgs) Handles tbUpdate.Click
        Try
            If MessageBox.Show("Do you want to update part no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtPartNo.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtPartNo.Focus()
                    Exit Sub
                Else
                    UpdatePartNo()
                    txtPartNo.Clear()
                    txtDetail.Clear()
                    txtPartNo.Focus()
                    txtPartNo.Focus()
                    numQuantity.Value = 0
                    numLotSize.Value = 0
                    ds.Clear()
                    ShowPartNo()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        Try
            If MessageBox.Show("Do you want to delete part no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                If txtPartNo.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtPartNo.Focus()
                    Exit Sub
                Else
                    DeletePartNo()
                    txtPartNo.Clear()
                    txtDetail.Clear()
                    txtPartNo.Focus()
                    numQuantity.Value = 0
                    numLotSize.Value = 0
                    ds.Clear()
                    ShowPartNo()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Delete Data")
        End Try
    End Sub
    Private Sub dgvAddPartNo_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAddPartNo.CellMouseClick
        On Error Resume Next
        dgvAddPartNo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvAddPartNo.CurrentRow.Index.ToString)
        txtPartNo.Text = dgvAddPartNo.Rows(x).Cells(1).Value()
        txtDetail.Text = dgvAddPartNo.Rows(x).Cells(2).Value()
        numQuantity.Value = dgvAddPartNo.Rows(x).Cells(3).Value()
        numLotSize.Value = dgvAddPartNo.Rows(x).Cells(4).Value()
        txtCode.Text = dgvAddPartNo.Rows(x).Cells(5).Value()
        txtAutoModel.Text = dgvAddPartNo.Rows(x).Cells(6).Value()
        lbID.Text = dgvAddPartNo.Rows(x).Cells(7).Value()
    End Sub
    Private Sub dgvAddPartNo_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddPartNo.RowLeave
        On Error Resume Next
        dgvAddPartNo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvAddPartNo_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAddPartNo.RowsAdded
        RunItemNo()
    End Sub
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvAddPartNo.RowCount - 2
            dgvAddPartNo.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub tbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tbRefresh.Click
        ShowPartNo()
        txtPartNo.Clear()
        txtDetail.Clear()
        txtPartNo.Focus()
        numQuantity.Value = 0
        numLotSize.Value = 0
    End Sub

    Private Sub BrowserInPN_Click(sender As System.Object, e As System.EventArgs) Handles BrowserInPN.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        ' Dim strFileName As String

        fd.Title = "Find ZPL/PRN file"
        fd.InitialDirectory = "C:\"
        fd.Filter = "PRN files (*.prn)|*.prn|ZPL files (*.zpl)|*.zpl"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            txtAutoModel.Text = fd.FileName
        End If
    End Sub
End Class