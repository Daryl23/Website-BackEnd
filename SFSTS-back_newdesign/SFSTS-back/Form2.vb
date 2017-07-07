Option Strict On
Imports MySql.Data.MySqlClient

Public Class Form2
    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.Form2AddEdit = 1 Then
            InstructionLabel.Text = "   Add Account"
            NameTextBox.Enabled = True
            UserNameTextBox.Enabled = True
            NameTextBox.Clear()
            UserNameTextBox.Clear()
            PasswordTextBox.Clear()
        Else
            InstructionLabel.Text = "   Edit Account"
            NameTextBox.Enabled = False
            UserNameTextBox.Enabled = False
            NameTextBox.Text = Form1.AccountListView.Items(Form1.AccountSelectedId).SubItems(2).Text
            UserNameTextBox.Text = Form1.AccountListView.Items(Form1.AccountSelectedId).SubItems(3).Text
            PasswordTextBox.Text = Form1.AccountListView.Items(Form1.AccountSelectedId).SubItems(4).Text
        End If
    End Sub

   
    Private Sub AccountSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountSaveButton.Click
        If NameTextBox.Text = "" Or UserNameTextBox.Text = "" Or PasswordTextBox.Text = "" Or ConfirmPasswordTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf PasswordTextBox.Text = ConfirmPasswordTextBox.Text Then
            If Form1.Form2AddEdit = 1 Then

                SQlString = "insert into tblaccount " & _
                                        "VALUES('" & NameTextBox.Text & "','" & UserNameTextBox.Text & "','" & PasswordTextBox.Text & "')"
                Try
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    Form1.Account()
                    MessageBox.Show("Account successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            Else
                Try
                    SQlString = " UPDATE tblaccount" & " SET  pass='" & PasswordTextBox.Text & "' WHERE name='" & NameTextBox.Text & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    Form1.Account()
                    MessageBox.Show("Account successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Password doen't match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub AccountCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountCancelButton.Click
        Form1.Account()
        Me.Close()
    End Sub
End Class