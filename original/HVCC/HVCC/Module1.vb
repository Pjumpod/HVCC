﻿Imports System.Configuration
Imports System.Data.OleDb
Imports System.Text
Module Module1
    Public int As Integer = 0
    Public cmd As New OleDb.OleDbCommand
    Public dr As OleDb.OleDbDataReader
    Public dt As DataTable
    Public ds As New DataSet()
    Public dsCount As New DataSet()
    Public dsECount As New DataSet()
    Public da As New OleDb.OleDbDataAdapter
    Public Sql As String
    Public connStr As String = ConfigurationSettings.AppSettings("dbConn")
    Public Conndb As New OleDb.OleDbConnection(connStr)
End Module
