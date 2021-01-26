Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Public Class frmRouting
    Private Sub frmRounting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowRouting()
    End Sub
#Region "Transection area"
    Private Sub ShowRouting()
        On Error Resume Next
        With Conndb
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("SELECT RoutingName,GSDB")
        sb.Append(" FROM tbRouting")
        Dim sqlOrder As String = sb.ToString()
        cmd = New OleDbCommand()
        With cmd
            .CommandType = CommandType.Text
            .CommandText = sqlOrder
            .Connection = Conndb
            dr = .ExecuteReader()
            If dr.Read() Then
                txtRouting.Text = dr.GetString(0)
                txtgsdb.Text = dr.GetString(1)
            Else
                txtRouting.Text = Nothing
                txtGSDB.Text = Nothing
            End If
        End With
        dr.Close()
    End Sub
    Private Sub UpdateRouting()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        Dim sb As New StringBuilder()
        sb.Remove(0, sb.Length)
        sb.Append("UPDATE tbRouting SET RoutingName='" & txtRouting.Text & "',GSDB='" & txtGSDB.Text & "'")
        'sb.Append(" WHERE RoutID=" & CInt(lbID.Text) & "")
        Dim sqlModel As String = sb.ToString()
        Dim cmdUpdate As OleDbCommand = New OleDbCommand(sqlModel, Conndb)
        cmdUpdate.ExecuteNonQuery()
        Beep()
        Conndb.Close()
    End Sub
#End Region
    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs) Handles tbSave.Click
        Try
            If MessageBox.Show("Do you want to save part no. into database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If txtRouting.Text = "" Then
                    MsgBox("Please fill part no. in textbox... ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning!")
                    txtRouting.Focus()
                    Exit Sub
                Else
                    UpdateRouting()
                    txtRouting.Clear()
                    txtRouting.Focus()
                    ds.Clear()
                    ShowRouting()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error from " + ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Save Data")
        End Try
    End Sub  
    Private Sub tbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tbRefresh.Click
        ShowRouting()
    End Sub
End Class