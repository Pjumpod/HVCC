Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmAddModel
    Dim connStr As String = ConfigurationSettings.AppSettings("dbConn")
    Dim Conndb As New OleDb.OleDbConnection(connStr)
    Private Sub frmAddModel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowModel()
    End Sub
#Region "Transection area"
    Private Sub ShowModel()
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT Model,ModelID")
        sb.Append(" FROM tbModel")
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
                dgvAddModel.DataSource = dt
            Else
                dgvAddModel.DataSource = Nothing
            End If
        End With
        ModelView()
    End Sub
    Private Sub UpdateModel()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbModel SET Model='" & txtModelNo.Text & "'")
        sb.Append(" WHERE ModelID=" & CInt(lbID.Text) & "")
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
        sb.Append("INSERT INTO tbModel(Model)")
        sb.Append(" Values ('" & txtModelNo.Text & "')")
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
        sb.Append("DELETE FROM tbModel")
        sb.Append(" WHERE ModelID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdDelete As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdDelete.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub ModelView()
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvAddModel
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Model"
                .Columns(2).HeaderText = "ID"
                .Columns(0).Width = 60
                .Columns(1).Width = 650
                .Columns(2).Width = 60
            End If
        End With
        Conndb.Close()
    End Sub
#End Region
    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save model no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtModelNo.Text = "" Then
                    MsgBox("Please fill model no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtModelNo.Focus()
                    Exit Sub
                Else
                    SaveModelNo()
                    txtModelNo.Clear()
                    ds.Clear()
                    ShowModel()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub dgvAddModel_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAddModel.CellMouseClick
        On Error Resume Next
        dgvAddModel.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvAddModel.CurrentRow.Index.ToString)
        txtModelNo.Text = dgvAddModel.Rows(x).Cells(1).Value()
        lbID.Text = dgvAddModel.Rows(x).Cells(2).Value()
    End Sub
    Private Sub dgvAddModel_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddModel.RowLeave
        On Error Resume Next
        dgvAddModel.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvAddModel_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAddModel.RowsAdded
        RunItemNo()
    End Sub
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvAddModel.RowCount - 2
            dgvAddModel.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
    Private Sub tbUpdte_Click(sender As System.Object, e As System.EventArgs) Handles tbUpdte.Click
        Try
            If MessageBox.Show("Do you want to update model no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtModelNo.Text = "" Then
                    MsgBox("Please fill model no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtModelNo.Focus()
                    Exit Sub
                Else
                    UpdateModel()
                    txtModelNo.Clear()
                    txtModelNo.Focus()
                    ds.Clear()
                    ShowModel()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        Try
            If MessageBox.Show("Do you want to delete model no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtModelNo.Text = "" Then
                    MsgBox("Please fill model no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtModelNo.Focus()
                    Exit Sub
                Else
                    DeleteModel()
                    txtModelNo.Clear()
                    txtModelNo.Focus()
                    ds.Clear()
                    ShowModel()
                    'ShowOrder()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Delete Data")
        End Try
    End Sub
    Private Sub tbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tbRefresh.Click
        ShowModel()
        txtModelNo.Clear()
    End Sub
End Class