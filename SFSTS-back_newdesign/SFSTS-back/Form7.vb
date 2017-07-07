
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form7

    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String

    Dim filename As String
    Dim FileSize As UInt32
    Dim ImageData() As Byte
    Dim fs As FileStream
    Dim br As BinaryReader

    Private Sub BoldButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldButton.Click
        If CommunityRichTextBox.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = CommunityRichTextBox.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If CommunityRichTextBox.SelectionFont.Bold = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
                BoldButton.FlatStyle = FlatStyle.Standard
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
                BoldButton.FlatStyle = FlatStyle.Popup
            End If

            CommunityRichTextBox.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub ItalicButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicButton.Click
        If CommunityRichTextBox.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = CommunityRichTextBox.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If CommunityRichTextBox.SelectionFont.Italic = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Italic
                ItalicButton.FlatStyle = FlatStyle.Standard
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Italic
                ItalicButton.FlatStyle = FlatStyle.Popup
            End If

            CommunityRichTextBox.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub UnderlineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineButton.Click
        If CommunityRichTextBox.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = CommunityRichTextBox.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If CommunityRichTextBox.SelectionFont.Underline = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
                UnderlineButton.FlatStyle = FlatStyle.Standard
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
                UnderlineButton.FlatStyle = FlatStyle.Popup
            End If

            CommunityRichTextBox.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub CommunityRichTextBox_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommunityRichTextBox.SelectionChanged
        BoldButton.FlatStyle = FlatStyle.Standard
        ItalicButton.FlatStyle = FlatStyle.Standard
        UnderlineButton.FlatStyle = FlatStyle.Standard
        If CommunityRichTextBox.SelectionFont.Bold = True Then
            BoldButton.FlatStyle = FlatStyle.Popup
        End If
        If CommunityRichTextBox.SelectionFont.Italic = True Then
            ItalicButton.FlatStyle = FlatStyle.Popup
        End If
        If CommunityRichTextBox.SelectionFont.Underline = True Then
            UnderlineButton.FlatStyle = FlatStyle.Popup
        End If
    End Sub

    Private Sub ClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButton.Click
        CommunityRichTextBox.Clear()
    End Sub

    Private Sub Undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CommunityRichTextBox.Undo()
    End Sub

    Private Sub Redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CommunityRichTextBox.Redo()
    End Sub
    Public Sub Attach()
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        'BrowseTextBox.Text = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*" ', .Multiselect = False, .Title = "Select Image"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            Dim FileName As String = strFileName
            fs = New FileStream(FileName, FileMode.Open, FileAccess.Read)
            br = New BinaryReader(fs)
            OurPeoplePhotoPictureBox.Image = Image.FromFile(fd.FileName)
            ImageData = br.ReadBytes(CType(fs.Length, Integer))
            br.Close()
            fs.Close()
            TextBox2.SendToBack()
            Label1.SendToBack()
        End If

    End Sub
    Private Sub OurPeoplePhotoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OurPeoplePhotoPictureBox.Click
        Attach()
    End Sub

    Private Sub TextBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        Attach()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Attach()
    End Sub

    Private Sub OurPeopleSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OurPeopleSaveButton.Click
        Dim rtfstring As String = FromRtf(CommunityRichTextBox)
        If OurPeopleNameTextBox.Text = "" Or OurPeopleTitleComboBox.Text = "" Or CommunityRichTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim ms As MemoryStream = New MemoryStream
            'initializing picture
            CommunityRichTextBox.SaveFile(ms, RichTextBoxStreamType.RichText)
            Dim bytBlobData(ms.Length - 1) As Byte
            ms.Position = 0
            ms.Read(bytBlobData, 0, ms.Length)
            Dim DatabaseParameter As New MySql.Data.MySqlClient.MySqlParameter("@BlobData", MySql.Data.MySqlClient.MySqlDbType.Blob, bytBlobData.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, bytBlobData)

            If Form1.Form7AddEdit = 1 Then
                SQlString = "insert into ourpeople " & _
                                        "VALUES('','" & OurPeopleNameTextBox.Text & "','" & OurPeopleTitleComboBox.Text & "',@Image,@blobdata,'" & rtfstring & "')"
                Try
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    With mycommand
                        .Parameters.Clear()
                        .CommandText = SQlString
                        .Connection = myconn
                        .Parameters.Add(New MySqlParameter("@Image", MySqlDbType.MediumBlob))
                        .Parameters("@Image").Value = ImageData
                        .Parameters.Add(DatabaseParameter)
                        .ExecuteNonQuery()
                    End With
                    myconn.Close()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try

                Dim OurPeopleId As Integer
                SQlString = "Select MAX(ourpeopleid) As ourpeopleid from ourpeople where name='" & OurPeopleNameTextBox.Text & "'"
                Try
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    myreader = mycommand.ExecuteReader
                    Do While myreader.Read
                        OurPeopleId = CInt(myreader("ourpeopleid").ToString)
                    Loop
                    myconn.Close()
                Catch ex As Exception
                    MessageBox.Show("Error Post.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    myconn.Close()
                End Try
                For i = 0 To CourseTaughtListView.Items.Count - 1
                    SQlString = "insert into tblcoursestaught " & _
                    "VALUES('','" & OurPeopleId & "','" & CourseTaughtListView.Items(i).SubItems(2).Text & "')"

                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                Next

                For i = 0 To EducationalAttainmentListView.Items.Count - 1
                    SQlString = "insert into tbleducationalattainment " & _
                    "VALUES('','" & OurPeopleId & "','" & EducationalAttainmentListView.Items(i).SubItems(2).Text & "','" & EducationalAttainmentListView.Items(i).SubItems(3).Text & "','" & EducationalAttainmentListView.Items(i).SubItems(4).Text & "')"

                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                Next

                Form1.About_People()
                Me.Close()
                MessageBox.Show("Community successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Try
                    SQlString = " UPDATE ourpeople " & " SET  photo=@image WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    With mycommand
                        mycommand.Parameters.Clear()
                        .CommandText = SQlString
                        .Connection = myconn
                        mycommand.Parameters.Add(New MySqlParameter("@Image", MySqlDbType.MediumBlob))
                        mycommand.Parameters("@Image").Value = ImageData
                        .ExecuteNonQuery()
                    End With
                    myconn.Close()

                    SQlString = " UPDATE ourpeople " & " SET  name='" & OurPeopleNameTextBox.Text & "' WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE ourpeople " & " SET  title='" & OurPeopleTitleComboBox.Text & "' WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE ourpeople " & " SET  profile=@blobdata WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    With mycommand
                        mycommand.Parameters.Clear()
                        .CommandText = SQlString
                        .Connection = myconn
                        mycommand.Parameters.Add(DatabaseParameter)
                        .ExecuteNonQuery()
                    End With
                    myconn.Close()

                    SQlString = " UPDATE ourpeople " & " SET  profilehtml='" & rtfstring & "' WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = "DELETE FROM tblcoursestaught WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = "DELETE FROM tbleducationalattainment WHERE ourpeopleid='" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    For i = 0 To CourseTaughtListView.Items.Count - 1
                        SQlString = "insert into tblcoursestaught " & _
                        "VALUES('','" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "','" & CourseTaughtListView.Items(i).SubItems(2).Text & "')"

                        myconn.ConnectionString = CONNECTION_STRING
                        myconn.Open()
                        mycommand.Connection = myconn
                        mycommand.CommandText = SQlString
                        mycommand.ExecuteNonQuery()
                        myconn.Close()
                    Next

                    For i = 0 To EducationalAttainmentListView.Items.Count - 1
                        SQlString = "insert into tbleducationalattainment " & _
                        "VALUES('','" & Form1.PeopleId.Item(Form1.OurPeopleDataGridView.CurrentCell.RowIndex) & "','" & EducationalAttainmentListView.Items(i).SubItems(2).Text & "','" & EducationalAttainmentListView.Items(i).SubItems(3).Text & "','" & EducationalAttainmentListView.Items(i).SubItems(4).Text & "')"

                        myconn.ConnectionString = CONNECTION_STRING
                        myconn.Open()
                        mycommand.Connection = myconn
                        mycommand.CommandText = SQlString
                        mycommand.ExecuteNonQuery()
                        myconn.Close()
                    Next


                    CommunityPanel.Enabled = False
                    Form1.About_People()
                    Me.Close()
                    MessageBox.Show("Community successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub CommunityCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommunityCancelButton.Click
        Form1.About_People()
        Me.Close()
    End Sub


    Dim n As Integer = 0

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CourseGroupBox.Enabled = False
        EducationGroupBox.Enabled = False
        If Form1.Form7AddEdit = 1 Then
            InstructionLabel.Text = "   Add Community"
            OurPeopleNameTextBox.Enabled = True
            TextBox2.BringToFront()
            Label1.BringToFront()
            DeleteCourseTaughtButton.Enabled = False
            DeleteEducationalAttainmentButton.Enabled = False
            OurPeoplePhotoPictureBox.Image = Nothing
            CommunityRichTextBox.Text = ""
        Else
            InstructionLabel.Text = "   Edit Community"
            OurPeopleNameTextBox.Enabled = False
            OurPeopleNameTextBox.Text = Form1.OurPeopleDataGridView.Rows.Item(Form1.Peopley).Cells(2).Value.ToString
            OurPeopleTitleComboBox.Text = Form1.OurPeopleDataGridView.Rows.Item(Form1.Peopley).Cells(3).Value.ToString
            CommunityRichTextBox.Text = Form1.OurPeopleDataGridView.Rows.Item(Form1.Peopley).Cells(5).Value.ToString

            SQlString = "Select profile,photo from ourpeople WHERE ourpeopleid='" & Form1.PeopleId(Form1.Peopley) & "'"
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                Dim bImage As Byte() = CType(myreader("photo"), Byte())
                Using ms As New System.IO.MemoryStream(bImage)
                    OurPeoplePhotoPictureBox.Image = Image.FromStream(ms)
                    ImageData = bImage
                End Using
                Dim rtfcontent As Byte() = DirectCast(myreader("profile"), Byte())
                If Not rtfcontent Is Nothing Then
                    Using stream As New System.IO.MemoryStream(rtfcontent)
                        CommunityRichTextBox.LoadFile(stream, RichTextBoxStreamType.RichText)
                    End Using
                End If
            Loop
            myconn.Close()

            TextBox2.SendToBack()
            Label1.SendToBack()

            Courses()
            Edu()
            
        End If

    End Sub

    Sub Courses()
        n = 0

        CourseTaughtListView.Items.Clear()
        SQlString = "Select * from tblcoursestaught WHERE ourpeopleid='" & Form1.PeopleId(Form1.Peopley) & "'"
        myconn.ConnectionString = CONNECTION_STRING
        myconn.Open()
        mycommand.Connection = myconn
        mycommand.CommandText = SQlString
        myreader = mycommand.ExecuteReader
        Do While myreader.Read
            n = n + 1

            CourseTaughtListView.Items.Add("")
            CourseTaughtListView.Items(CourseTaughtListView.Items.Count - 1).SubItems.Add(n.ToString)
            CourseTaughtListView.Items(CourseTaughtListView.Items.Count - 1).SubItems.Add(myreader("course").ToString)
        Loop
        myconn.Close()
    End Sub

    Sub Edu()
        n = 0

        EducationalAttainmentListView.Items.Clear()
        SQlString = "Select * from tbleducationalattainment WHERE ourpeopleid='" & Form1.PeopleId(Form1.Peopley) & "'"
        myconn.ConnectionString = CONNECTION_STRING
        myconn.Open()
        mycommand.Connection = myconn
        mycommand.CommandText = SQlString
        myreader = mycommand.ExecuteReader
        Do While myreader.Read
            n = n + 1

            EducationalAttainmentListView.Items.Add("")
            EducationalAttainmentListView.Items(CourseTaughtListView.Items.Count - 1).SubItems.Add(n.ToString)
            EducationalAttainmentListView.Items(CourseTaughtListView.Items.Count - 1).SubItems.Add(myreader("educationalattainment").ToString)
            EducationalAttainmentListView.Items(CourseTaughtListView.Items.Count - 1).SubItems.Add(myreader("school").ToString)
            EducationalAttainmentListView.Items(CourseTaughtListView.Items.Count - 1).SubItems.Add(myreader("address").ToString)
        Loop
        myconn.Close()
    End Sub

    Private Sub AddCourseTaughtButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCourseTaughtButton.Click
        Form11.ShowDialog()
    End Sub

    Private Sub AddEducationalAttainmentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEducationalAttainmentButton.Click
        Form12.ShowDialog()
    End Sub

    Private Sub EducationalAttainmentListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EducationalAttainmentListView.ItemChecked
        If EducationalAttainmentListView.CheckedItems.Count > 0 Then
            DeleteEducationalAttainmentButton.Enabled = True
        Else
            DeleteEducationalAttainmentButton.Enabled = False
        End If
    End Sub
    Private Sub EducationalAttainmentCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EducationalAttainmentCheckBox.CheckedChanged
        If EducationalAttainmentCheckBox.Checked = True Then
            For i = 0 To EducationalAttainmentListView.Items.Count - 1
                EducationalAttainmentListView.Items(i).Checked = True
            Next
        Else
            For i = 0 To EducationalAttainmentListView.Items.Count - 1
                EducationalAttainmentListView.Items(i).Checked = False
            Next
        End If

    End Sub

    Private Sub CourseTaughtListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CourseTaughtListView.ItemChecked
        If CourseTaughtListView.CheckedItems.Count > 0 Then
            DeleteCourseTaughtButton.Enabled = True
        Else
            DeleteCourseTaughtButton.Enabled = False
        End If
    End Sub

    Private Sub CourseTaughtCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CourseTaughtCheckBox.CheckedChanged
        If CourseTaughtCheckBox.Checked = True Then
            For i = 0 To CourseTaughtListView.Items.Count - 1
                CourseTaughtListView.Items(i).Checked = True
            Next
        Else
            For i = 0 To CourseTaughtListView.Items.Count - 1
                CourseTaughtListView.Items(i).Checked = False
            Next
        End If

    End Sub

    Private Sub DeleteCourseTaughtButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCourseTaughtButton.Click
            For i = CourseTaughtListView.Items.Count - 1 To 0 Step -1
                If CourseTaughtListView.Items(i).Checked = True Then
                    CourseTaughtListView.Items(i).Remove()
                End If
            Next
    End Sub

    Private Sub DeleteEducationalAttainmentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteEducationalAttainmentButton.Click
        For i = EducationalAttainmentListView.Items.Count - 1 To 0 Step -1
            If EducationalAttainmentListView.Items(i).Checked = True Then
                EducationalAttainmentListView.Items(i).Remove()
            End If
        Next
    End Sub

    Private Sub CommunityPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles CommunityPanel.Paint

    End Sub

    Public Shared Function FromRtf(ByVal rtf As RichTextBox) As String
        Dim b, i, u As Boolean
        b = False : i = False : u = False
        Dim htmlstr As String = ""
        Dim x As Integer = 0
        While x < Rtf.Text.Length
            Rtf.Select(x, 1)
            If Rtf.SelectionFont.Bold AndAlso (Not b) Then
                htmlstr &= "<b>"
                b = True
            ElseIf (Not Rtf.SelectionFont.Bold) AndAlso b Then
                htmlstr &= "</b>"
                b = False
            End If
            If Rtf.SelectionFont.Italic AndAlso (Not i) Then
                htmlstr &= "<i>"
                i = True
            ElseIf (Not Rtf.SelectionFont.Italic) AndAlso i Then
                htmlstr &= "</i>"
                i = False
            End If
            If Rtf.SelectionFont.Underline AndAlso (Not u) Then
                htmlstr &= "<u>"
                u = True
            ElseIf (Not Rtf.SelectionFont.Underline) AndAlso u Then
                htmlstr &= "</u>"
                u = False
            End If
            htmlstr &= Rtf.Text.Chars(x)
            x += 1
        End While
        Return htmlstr
    End Function

    Private Sub OurPeopleTitleComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OurPeopleTitleComboBox.SelectedIndexChanged
        If OurPeopleTitleComboBox.SelectedIndex = 0 Then
            CourseTaughtListView.Items.Clear()
            EducationalAttainmentListView.Items.Clear()
            CourseGroupBox.Enabled = True
            EducationGroupBox.Enabled = True
        Else
            CourseTaughtListView.Items.Clear()
            EducationalAttainmentListView.Items.Clear()
            CourseGroupBox.Enabled = False
            EducationGroupBox.Enabled = False
        End If
    End Sub
End Class