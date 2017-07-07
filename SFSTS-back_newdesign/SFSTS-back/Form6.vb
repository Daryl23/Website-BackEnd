Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form6
    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String

    Private Sub FAQSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAQSaveButton.Click
        If FAQQuestionTextBox.Text = "" Or FAQAnswerTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Form1.Form6AddEdit = 1 Then
                SQlString = "insert into tblfaq " & _
                                       "VALUES('','" & FAQQuestionTextBox.Text & "','" & FAQAnswerTextBox.Text & "')"

                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                mycommand.ExecuteNonQuery()
                myconn.Close()
                FAQQuestionTextBox.Clear()
                FAQAnswerTextBox.Clear()

                Form1.FAQ()
                Me.Close()
                MessageBox.Show("FAQ has been added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    SQlString = "UPDATE tblfaq " & " SET  question='" & FAQQuestionTextBox.Text & "'  WHERE faqid='" & Form1.FAQSelectedid + 1 & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    SQlString = " UPDATE tblfaq " & " SET  answer='" & FAQAnswerTextBox.Text & "'  WHERE faqid='" & Form1.FAQSelectedid + 1 & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    Form1.FAQ()
                    Me.Close()
                    MessageBox.Show("FAQ has been updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "UnSafe Character Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    myconn.Close()
                End Try
            End If
            End If
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.Form6AddEdit = 1 Then
            InstructionLabel.Text = "   Add FAQ"
            FAQQuestionTextBox.Clear()
            FAQAnswerTextBox.Clear()
        Else
            InstructionLabel.Text = "   Edit FAQ"
            FAQQuestionTextBox.Text = Form1.FAQListView.SelectedItems(Form1.FAQSelectedid).SubItems(2).Text
            FAQAnswerTextBox.Text = Form1.FAQListView.SelectedItems(Form1.FAQSelectedid).SubItems(3).Text
        End If
    End Sub

    Private Sub FAQCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAQCancelButton.Click
        Form1.FAQ()
        Me.Close()
    End Sub

    Private Sub GroupBox10_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class