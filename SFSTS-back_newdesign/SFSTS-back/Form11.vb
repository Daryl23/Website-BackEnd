Public Class Form11

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CourseTaughtTextBox.Clear()
    End Sub

    Private Sub AddCourseTaughtButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCourseTaughtButton.Click
        Dim n As Integer = Form7.CourseTaughtListView.Items.Count + 1
        Form7.CourseTaughtListView.Items.Add("")
        Form7.CourseTaughtListView.Items(Form7.CourseTaughtListView.Items.Count - 1).SubItems.Add(n.ToString)
        Form7.CourseTaughtListView.Items(Form7.CourseTaughtListView.Items.Count - 1).SubItems.Add(CourseTaughtTextBox.Text)
        Me.Close()
    End Sub

    Private Sub CancelCourseTaughtButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelCourseTaughtButton.Click

        Me.Close()
    End Sub

End Class