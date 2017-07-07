
Imports MySql.Data.MySqlClient

Public Class Form12
    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String

    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EducationalAttainmentTextBox.Clear()
        SchoolTextBox.Clear()
        AddressTextBox.Clear()
    End Sub

    Private Sub AddEducationalAttainmentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEducationalAttainmentButton.Click
        Dim n As Integer = Form7.EducationalAttainmentListView.Items.Count + 1
        Form7.EducationalAttainmentListView.Items.Add("")
        Form7.EducationalAttainmentListView.Items(Form7.EducationalAttainmentListView.Items.Count - 1).SubItems.Add(n.ToString)
        Form7.EducationalAttainmentListView.Items(Form7.EducationalAttainmentListView.Items.Count - 1).SubItems.Add(EducationalAttainmentTextBox.Text)
        Form7.EducationalAttainmentListView.Items(Form7.EducationalAttainmentListView.Items.Count - 1).SubItems.Add(SchoolTextBox.Text)
        Form7.EducationalAttainmentListView.Items(Form7.EducationalAttainmentListView.Items.Count - 1).SubItems.Add(AddressTextBox.Text)
        Me.Close()
    End Sub

    Private Sub CancelEducationalAttainmentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelEducationalAttainmentButton.Click

        Me.Close()
    End Sub

End Class