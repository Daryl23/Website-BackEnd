Option Strict On
Imports MySql.Data.MySqlClient
Public Class Form13
    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String
    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.Form13AddEdit = 1 Then
            InstructionLabel.Text = "   Add Program"
            ProgramTextBox.Clear()
        Else
            InstructionLabel.Text = "   Edit Program"
            ProgramTextBox.Text = Form1.ProgramListView.Items(Form1.ProgramSelectedId).SubItems(2).Text
        End If
    End Sub

    Private Sub AccountCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountCancelButton.Click
        Form1.Programs()
        Me.Close()
    End Sub

    Private Sub AccountSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountSaveButton.Click
        If ProgramTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Form1.Form13AddEdit = 1 Then

                SQlString = "insert into tblprogram " & _
                                        "VALUES('','" & ProgramTextBox.Text & "')"
                Try
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    Form1.Programs()
                    MessageBox.Show("Program successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            Else
                Try
                    SQlString = " UPDATE tblprogram" & " SET  program='" & ProgramTextBox.Text & "' WHERE programid='" & Form1.ProgramID(Form1.ProgramSelectedId) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    Form1.Programs()
                    MessageBox.Show("Program successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            End If
        End If
    End Sub
End Class