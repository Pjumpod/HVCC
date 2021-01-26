Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmShift

    Private Sub frmShift_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowShift()
    End Sub
#Region "Transection area"
    Private Sub ShowShift()
        On Error Resume Next
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT Shift,Start,Finish,ID")
        sb.Append(" FROM tbShift")
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
                dgvAddShift.DataSource = dt
            Else
                dgvAddShift.DataSource = Nothing
            End If
        End With
        ShiftView()
    End Sub
    Private Sub UpdateRouting()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        Dim Startdatetime As DateTime = dtpStart.Value.ToString("yyyy-MM-dd HH:mm")
        Dim Finishdatetime As DateTime = dtpFinish.Value.ToString("yyyy-MM-dd HH:mm")
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbShift SET Shift='" & txtShift.Text & "',Start='" & Startdatetime & "',Finish='" & Finishdatetime & "'")
        sb.Append(" WHERE ID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdUpdate.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub SaveRouting()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        Dim Startdatetime As DateTime = dtpStart.Value.ToString("yyyy-MM-dd HH:mm")
        Dim Finishdatetime As DateTime = dtpFinish.Value.AddDays(1).ToString("yyyy-MM-dd HH:mm")
        sb.Append("INSERT INTO tbShift(Shift,Start,Finish)")
        sb.Append(" Values('" & txtShift.Text & "',")
        sb.Append("'" & Startdatetime & "','" & Finishdatetime & "')")
        Dim sqlRount As String = sb.ToString()
        Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlRount, Conndb)
        cmdInsert.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub DeleteRouting()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("DELETE FROM tbShift")
        sb.Append(" WHERE ID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdDelete As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdDelete.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
    Private Sub ShiftView()
        On Error Resume Next
        Dim cs As New DataGridViewCellStyle()
        cs.Font = New Font("Ms Sans Serif", 10, FontStyle.Bold)
        With dgvAddShift
            If .RowCount > 0 Then
                .ColumnHeadersDefaultCellStyle = cs
                .Columns(2).DefaultCellStyle.Format = "HH:mm"
                .Columns(3).DefaultCellStyle.Format = "HH:mm"
                .Columns(0).HeaderText = "No."
                .Columns(1).HeaderText = "Shift"
                .Columns(2).HeaderText = "Shift Time Start"
                .Columns(3).HeaderText = "Shift Time Finish"
                .Columns(4).HeaderText = "ID"
                .Columns(0).Width = 60
                .Columns(1).Width = 150
                .Columns(2).Width = 180
                .Columns(3).Width = 180
                .Columns(4).Width = 60

            End If


        End With
        Conndb.Close()
    End Sub
#End Region
    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save shift into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtShift.Text = "" Then
                    MsgBox("Please fill shift in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtShift.Focus()
                    Exit Sub
                Else
                    SaveRouting()
                    txtShift.Clear()
                    txtShift.Focus()
                    dtpFinish.Refresh()
                    dtpStart.Value = Now
                    dtpFinish.Value = Now
                    ds.Clear()
                    ShowShift()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub
    Private Sub tbUpdate_Click(sender As System.Object, e As System.EventArgs) Handles tbUpdate.Click
        Try
            If MessageBox.Show("Do you want to update shift into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtShift.Text = "" Then
                    MsgBox("Please fill shift in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtShift.Focus()
                    Exit Sub
                Else
                    UpdateRouting()
                    txtShift.Clear()
                    txtShift.Focus()
                    ds.Clear()
                    ShowShift()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Update Data")
        End Try
    End Sub
    Private Sub tbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tbDelete.Click
        Try
            If MessageBox.Show("Do you want to delete shift into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                If txtShift.Text = "" Then
                    MsgBox("Please fill shift in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtShift.Focus()
                    Exit Sub
                Else
                    DeleteRouting()
                    txtShift.Clear()
                    txtShift.Focus()
                    ds.Clear()
                    ShowShift()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Delete Data")
        End Try
    End Sub
    Private Sub tbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tbRefresh.Click
        ShowShift()
        txtShift.Clear()
        dtpStart.Value = Now
        dtpFinish.Value = Now
    End Sub
    Private Sub dgvAddShift_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAddShift.CellMouseClick
        On Error Resume Next
        dgvAddShift.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
        Dim x As Integer = Val(dgvAddShift.CurrentRow.Index.ToString)
        txtShift.Text = dgvAddShift.Rows(x).Cells(1).Value()
        dtpStart.Value = dgvAddShift.Rows(x).Cells(2).Value()
        dtpFinish.Value = dgvAddShift.Rows(x).Cells(3).Value()
        lbID.Text = dgvAddShift.Rows(x).Cells(4).Value()
    End Sub
    Private Sub dgvAddShift_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddShift.RowLeave
        On Error Resume Next
        dgvAddShift.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub dgvAddShift_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAddShift.RowsAdded
        RunItemNo()
    End Sub
    Private Sub RunItemNo()
        Dim row As Integer = 0
        For row = 0 To dgvAddShift.RowCount - 2
            dgvAddShift.Rows(row).Cells(0).Value = row + 1
        Next
    End Sub
End Class