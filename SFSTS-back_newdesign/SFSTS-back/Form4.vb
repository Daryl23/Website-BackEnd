Option Strict On
Imports MySql.Data.MySqlClient
Public Class Form4
    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim unamelist As New List(Of String)
        Dim passlist As New List(Of String)

        SQlString = "Select * from tblaccount"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                unamelist.Add(myreader("uname").ToString)
                passlist.Add(myreader("pass").ToString)
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error Account.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
        Dim a As String = "a"
        For i = 0 To unamelist.Count - 1
            If TextBox1.Text = unamelist(i) Then
                a = "a"
                If TextBox2.Text = passlist(i) Then
                    a = "c"
                    Exit For
                Else
                    a = "b"
                End If
            End If
        Next

        If a = "a" Then
            MessageBox.Show("User Name or Password Doesn't Found.", "Log in Error.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf a = "b" Then
            MessageBox.Show("User Name and Password Doesn't Match.", "Log in Error.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Form1.Show()
            Me.Hide()
        End If
     
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

End Class