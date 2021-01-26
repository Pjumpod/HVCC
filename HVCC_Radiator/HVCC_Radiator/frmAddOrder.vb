Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmAddOrder
    Dim connStr As String = ConfigurationSettings.AppSettings("dbConn")
    Dim Conndb As New OleDb.OleDbConnection(connStr)
    Private Sub frmAddOrder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowOrder()
    End Sub
    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save order no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtOrderNo.Text = "" Then
                    MsgBox("Please fill order no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtOrderNo.Focus()
                    Exit Sub
                Else
                    SaveOrderNo()
                    txtOrderNo.Clear()
                    ds.Clear()
                    'ShowModel()
                    ShowOrder()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbUpdate_Click(sender As System.Object, e As System.EventArgs) Handles tbUpdate.Click
        Try
            If MessageBox.Show("Do you want to update order no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtOrderNo.Text = "" Then
                    MsgBox("Please fill order no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtOrderNo.Focus()
                    Exit Sub
                Else
                    UpdateOrder()
                    txtOrderNo.Clear()
                    txtOrderNo.Focus()
                    ds.Clear()
                    'ShowModel()
                    ShowOrder()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Update Data")
        End Try
    End Sub
#Region "Transection area"
    Private Sub ShowOrder()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT OrderNo,OrderID")
        sb.Append(" FROM tbOrderNo")
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
                dgvAddOrder.DataSource = dt
            Else
                dgvAddOrder.DataSource = Nothing
            End If
        End With
        ModelView()
    End Sub
    Private Sub UpdateOrder()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbOrderNo SET OrderNo='" & txtOrderNo.Text & "'")
        sb.Append(" WHERE OrderID=" & CInt(lbID.Text) & "")
        Dim sqlOrder As String = sb.ToString()
        Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlOrder, Conndb)
        cmdUpdate.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub SaveOrderNo()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("INSERT INTO tbOrderNo(OrderNo)")
        sb.Append(" Values ('" & txtOrderNo.Text & "')")
        Dim sqlOrder As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlOrder, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub DeleteOrder()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("DELETE FROM tbOrderNo")
        sb.Append(" WHERE OrderID=" & CInt(lbID.Text) & "")
        Dim sqlOrder As String = sb.ToString()
        Dim cmdDelete As OleDbCommand = New OleDbCommand(sqlOrder, Conndb)
        cmdDelete.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub ModelView()
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvAddOrder
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Order No."
                .Columns(2).HeaderText = "ID"
                .Columns(0).Width = 60
                .Columns(1).Width = 550
                .Columns(2).Width = 50
            End If
        End With
        Conndb.Close()
    End Sub
#End Region
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvAddOrder.RowCount - 2
            dgvAddOrder.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub dgvAddOrder_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAddOrder.CellMouseClick
        On Error Resume Next
        dgvAddOrder.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvAddOrder.CurrentRow.Index.ToString)
        lbID.Text = dgvAddOrder.Rows(x).Cells(2).Value()
        txtOrderNo.Text = dgvAddOrder.Rows(x).Cells(1).Value()
    End Sub
    Private Sub dgvAddOrder_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddOrder.RowLeave
        On Error Resume Next
        dgvAddOrder.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvAddOrder_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAddOrder.RowsAdded
        RunItemNo()
    End Sub
    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        Try
            If MessageBox.Show("Do you want to delete order no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtOrderNo.Text = "" Then
                    MsgBox("Please fill order no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtOrderNo.Focus()
                    Exit Sub
                Else
                    DeleteOrder()
                    txtOrderNo.Clear()
                    txtOrderNo.Focus()
                    ds.Clear()
                    'ShowModel()
                    ShowOrder()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Delete Data")
        End Try
    End Sub
    Private Sub tbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tbRefresh.Click
        ShowOrder()
        txtOrderNo.Clear()
    End Sub
End Class
