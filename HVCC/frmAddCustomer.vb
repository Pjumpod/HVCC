Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmAddCustomer
    Dim connStr As String = ConfigurationSettings.AppSettings("dbConn")
    Dim Conndb As New OleDb.OleDbConnection(connStr)
    Private Sub frmAddCustomer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowCustomer()
    End Sub
#Region "Transection area"
    Private Sub ShowCustomer()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT CustomerPartNo,CustomerPartNo2,CusID")
        sb.Append(" FROM tbCustomer")
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
                dgvAddCustomer.DataSource = dt
            Else
                dgvAddCustomer.DataSource = Nothing
            End If
        End With
        CusView()
    End Sub
    Private Sub UpdateModel()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbCustomer SET CustomerPartNo='" & txtCustomerNo.Text & "',CustomerPartNo2='" & txtCustomerNo2.Text & "'")
        sb.Append(" WHERE CusID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdUpdate.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub SaveModelNo()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("INSERT INTO tbCustomer(CustomerPartNo,CustomerPartNo2)")
        sb.Append(" Values ('" & txtCustomerNo.Text & "','" & txtCustomerNo2.Text & "')")
        Dim sqlOrder As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlOrder, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub DeleteModel()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("DELETE FROM tbCustomer")
        sb.Append(" WHERE CusID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdDelete As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdDelete.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub CusView()
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvAddCustomer
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Customer Part No.1"
                .Columns(2).HeaderText = "Customer Part No.2"
                .Columns(3).HeaderText = "ID"
                .Columns(0).Width = 60
                .Columns(1).Width = 350
                .Columns(2).Width = 350
                .Columns(3).Width = 60
            End If
        End With
        Conndb.Close()
    End Sub
#End Region
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvAddCustomer.RowCount - 2
            dgvAddCustomer.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub dgvAddCustomer_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAddCustomer.CellMouseClick
        On Error Resume Next
        dgvAddCustomer.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvAddCustomer.CurrentRow.Index.ToString)
        txtCustomerNo.Text = dgvAddCustomer.Rows(x).Cells(1).Value()
        txtCustomerNo2.Text = dgvAddCustomer.Rows(x).Cells(2).Value()
        lbID.Text = dgvAddCustomer.Rows(x).Cells(3).Value()
    End Sub
    Private Sub dgvAddCustomer_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddCustomer.RowLeave
        On Error Resume Next
        dgvAddCustomer.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvAddCustomer_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAddCustomer.RowsAdded
        RunItemNo()
    End Sub
    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save model no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtCustomerNo.Text = "" Then
                    MsgBox("Please fill model no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtCustomerNo.Focus()
                    Exit Sub
                Else
                    SaveModelNo()
                    txtCustomerNo.Clear()
                    ds.Clear()
                    ShowCustomer()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        Try
            If MessageBox.Show("Do you want to delete model no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtCustomerNo.Text = "" Then
                    MsgBox("Please fill model no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtCustomerNo.Focus()
                    Exit Sub
                Else
                    DeleteModel()
                    txtCustomerNo.Clear()
                    txtCustomerNo.Focus()
                    ds.Clear()
                    ShowCustomer()
                    'ShowOrder()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Delete Data")
        End Try
    End Sub
    Private Sub tbUpdate_Click(sender As System.Object, e As System.EventArgs) Handles tbUpdate.Click
        Try
            If MessageBox.Show("Do you want to update model no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtCustomerNo.Text = "" Then
                    MsgBox("Please fill model no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtCustomerNo.Focus()
                    Exit Sub
                Else
                    UpdateModel()
                    txtCustomerNo.Clear()
                    txtCustomerNo.Focus()
                    ds.Clear()
                    ShowCustomer()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tbRefresh.Click
        ShowCustomer()
        txtCustomerNo.Clear()
    End Sub
End Class