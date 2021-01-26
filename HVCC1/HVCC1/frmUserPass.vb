Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Configuration
Imports System.Data.OleDb
Public Class frmUserPass
    Dim user As String
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        ds.Clear()
        If Conndb.State = ConnectionState.Open Then Conndb.Close()
        Conndb.Open()
        cmd.CommandText = "SELECT User,Password FROM tbUser Where [User]='" & txtID.Text & "' AND [Password]='" & txtPass.Text & "'"
        cmd.Connection = Conndb
        da.SelectCommand = cmd
        da.Fill(ds, "tbUser")
        Dim count = ds.Tables("tbUser").Rows.Count
        If count > 0 Then
            frmRunPage.TabDatalogger.TabPages.Remove(frmRunPage.TabAuto)
            frmRunPage.TabDatalogger.TabPages.Remove(frmRunPage.TabManual)
            frmRunPage.TabDatalogger.TabPages.Add(frmRunPage.TabManual)
            frmRunPage.cmbModel.Text = frmRunPage.lbModel.Text
            frmRunPage.cmbOrder.Text = frmRunPage.lbOrder.Text
            Try
                Dim sqlSave As String
                Dim dmy As DateTime = lbToday.Text.ToString()
                sqlSave = "INSERT INTO tbUserLog ([timestamp],[UserName])"
                sqlSave = sqlSave & " Values ('" & dmy.ToString("yyyy-MM-dd HH:mm:ss") & "','" & Trim(txtID.Text) & "')"
                Dim cmdInsert As OleDbCommand = New OleDbCommand(sqlSave, Conndb)
                cmdInsert.ExecuteNonQuery()  ' Enable when Use Save
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            Finally
                Conndb.Close()
            End Try
            Me.Hide()
        Else
            MsgBox("Incorrect Login Please Check Username and Passwords", MsgBoxStyle.Critical, "Please Recheck Username and Passwords")
            'txtID.Clear()
            txtPass.Clear()
            txtID.Focus()
            Me.txtID.BackColor = System.Drawing.SystemColors.Info
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Sub SaveUser()
        Dim cmd = New OleDb.OleDbCommand()
        cmd.CommandText = "SELECT * FROM tbUserRecord"
        cmd.Connection = Conndb
        If Me.txtID.Text <> vbNullString And Me.txtPass.Text <> vbNullString Then
        End If
    End Sub
    Private Sub frmUserPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbToday.Text = Now
    End Sub
End Class
