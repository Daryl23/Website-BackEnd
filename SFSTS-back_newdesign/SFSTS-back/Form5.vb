Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form5

    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String
    Private Sub BoldButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldButton.Click
        If HomeContentRichTextBox.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = HomeContentRichTextBox.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If HomeContentRichTextBox.SelectionFont.Bold = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
                BoldButton.FlatStyle = FlatStyle.Standard
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
                BoldButton.FlatStyle = FlatStyle.Popup
            End If

            HomeContentRichTextBox.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub ItalicButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicButton.Click
        If HomeContentRichTextBox.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = HomeContentRichTextBox.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If HomeContentRichTextBox.SelectionFont.Italic = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Italic
                ItalicButton.FlatStyle = FlatStyle.Standard
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Italic
                ItalicButton.FlatStyle = FlatStyle.Popup
            End If

            HomeContentRichTextBox.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub UnderlineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineButton.Click
        If HomeContentRichTextBox.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = HomeContentRichTextBox.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle

            If HomeContentRichTextBox.SelectionFont.Underline = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
                UnderlineButton.FlatStyle = FlatStyle.Standard
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
                UnderlineButton.FlatStyle = FlatStyle.Popup
            End If

            HomeContentRichTextBox.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub

    Private Sub HomeContentRichTextBox_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeContentRichTextBox.SelectionChanged
        BoldButton.FlatStyle = FlatStyle.Standard
        ItalicButton.FlatStyle = FlatStyle.Standard
        UnderlineButton.FlatStyle = FlatStyle.Standard
        If HomeContentRichTextBox.SelectionFont.Bold = True Then
            BoldButton.FlatStyle = FlatStyle.Popup
        End If
        If HomeContentRichTextBox.SelectionFont.Italic = True Then
            ItalicButton.FlatStyle = FlatStyle.Popup
        End If
        If HomeContentRichTextBox.SelectionFont.Underline = True Then
            UnderlineButton.FlatStyle = FlatStyle.Popup
        End If
    End Sub

    Private Sub ClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButton.Click
        HomeContentRichTextBox.Clear()
    End Sub

    Private Sub Undo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HomeContentRichTextBox.Undo()
    End Sub

    Private Sub Redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HomeContentRichTextBox.Redo()
    End Sub
    Dim filename As String
    Dim FileSize As UInt32
    Dim ImageData() As Byte
    Dim fs As FileStream
    Dim br As BinaryReader
    Public Sub Attach()
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        'BrowseTextBox.Text = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*" ', .Multiselect = False, .Title = "Select Image"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True
        Try
            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
                Dim FileName As String = strFileName
                fs = New FileStream(FileName, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                PostAttachmentPictureBox.Image = Image.FromFile(fd.FileName)
                ImageData = br.ReadBytes(CType(fs.Length, Integer))
                br.Close()
                fs.Close()
                TextBox2.SendToBack()
                Label1.SendToBack()
            End If
        Catch
            MessageBox.Show("The file you are trying to insert might be too large.", "Insufficient Memory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub




    Private Sub PostAttachmentPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostAttachmentPictureBox.Click
        Attach()
    End Sub

    Private Sub TextBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        Attach()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Attach()
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.BringToFront()
        Label1.BringToFront()
        If Form1.Form5AddEdit = 1 Then
            InstructionLabel.Text = "   Add Post"
            HomeTitleTextBox.Clear()
            HomeAuthorTextBox.Clear()
            HomeCategoryComboBox.SelectedIndex = -1
            HomeDateDateTimePicker.Text = Date.Now
            HomeContentRichTextBox.Text = ""
            PostAttachmentPictureBox.Image = Nothing
        Else
            InstructionLabel.Text = "   Edit Post"
            HomeTitleTextBox.Text = Form1.HomePostsDataGridView.Rows.Item(Form1.Homey).Cells(2).Value.ToString
            HomeAuthorTextBox.Text = Form1.HomePostsDataGridView.Rows.Item(Form1.Homey).Cells(3).Value.ToString
            HomeCategoryComboBox.Text = Form1.HomePostsDataGridView.Rows.Item(Form1.Homey).Cells(4).Value.ToString
            HomeDateDateTimePicker.Text = Form1.HomePostsDataGridView.Rows.Item(Form1.Homey).Cells(5).Value.ToString
            'HomeContentRichTextBox.Text = Form1.HomePostsDataGridView.Rows.Item(Form1.Homey).Cells(6).Value.ToString
            SQlString = "Select content,attachment from tblpost WHERE postid='" & Form1.PostId(Form1.Homey) & "'"
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                Dim bImage As Byte() = CType(myreader("attachment"), Byte())
                Using ms As New System.IO.MemoryStream(bImage)
                    PostAttachmentPictureBox.Image = Image.FromStream(ms)
                    ImageData = bImage
                End Using
                Dim rtfcontent As Byte() = DirectCast(myreader("content"), Byte())
                If Not rtfcontent Is Nothing Then
                    Using stream As New System.IO.MemoryStream(rtfcontent)
                        HomeContentRichTextBox.LoadFile(stream, RichTextBoxStreamType.RichText)
                    End Using
                End If
            Loop
            myconn.Close()
            TextBox2.SendToBack()
            Label1.SendToBack()
        End If
    End Sub

    Private Sub HomeSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeSaveButton.Click
        Dim rtfstring As String = FromRtf(HomeContentRichTextBox)
        If HomeTitleTextBox.Text = "" Or HomeCategoryComboBox.Text = "" Or HomeContentRichTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim ms As MemoryStream = New MemoryStream
            'initializing picture
            HomeContentRichTextBox.SaveFile(ms, RichTextBoxStreamType.RichText)
            Dim bytBlobData(ms.Length - 1) As Byte
            ms.Position = 0
            ms.Read(bytBlobData, 0, ms.Length)
            Dim DatabaseParameter As New MySql.Data.MySqlClient.MySqlParameter("@BlobData", MySql.Data.MySqlClient.MySqlDbType.Blob, bytBlobData.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, bytBlobData)

            Dim PostDate As Date = CDate(HomeDateDateTimePicker.Text)
            If Form1.Form5AddEdit = 1 Then

                SQlString = "insert into tblpost " & _
                                        "VALUES('','" & HomeTitleTextBox.Text & "','" & HomeAuthorTextBox.Text & "','" & HomeCategoryComboBox.Text & "','" & PostDate.ToString("yyyy/MM/dd") & "',@BlobData,'" & rtfstring & "',@Image)"
                Try
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
                        mycommand.Parameters.Add(DatabaseParameter)
                        'mycommand.Parameters("@BlobData").Value = HomeContentRichTextBox.Rtf
                        .ExecuteNonQuery()
                    End With
                    myconn.Close()
                    Form1.HomeLoad()
                    MessageBox.Show("Post successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try

            Else
                Try
                    SQlString = " UPDATE tblpost " & " SET  attachment=@image WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
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

                    SQlString = " UPDATE tblpost " & " SET  category='" & HomeCategoryComboBox.Text & "' WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE tblpost " & " SET  title='" & HomeTitleTextBox.Text & "' WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE tblpost " & " SET  author='" & HomeAuthorTextBox.Text & "' WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE tblpost " & " SET  date='" & PostDate.ToString("yyyy/MM/dd") & "' WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE tblpost " & " SET  content=@blobdata WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
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

                    SQlString = " UPDATE tblpost " & " SET  contenthtml='" & rtfstring & "' WHERE postid='" & Form1.PostId.Item(Form1.Homey) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    Form1.HomeLoad()
                    MessageBox.Show("Post successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub HomeCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeCancelButton.Click
        Me.Close()
    End Sub


    Public Shared Function FromRtf(ByVal rtf As RichTextBox) As String
        Dim b, i, u As Boolean
        b = False : i = False : u = False
        Dim htmlstr As String = ""
        Dim x As Integer = 0
        While x < rtf.Text.Length
            rtf.Select(x, 1)
            If rtf.SelectionFont.Bold AndAlso (Not b) Then
                htmlstr &= "<b>"
                b = True
            ElseIf (Not rtf.SelectionFont.Bold) AndAlso b Then
                htmlstr &= "</b>"
                b = False
            End If
            If rtf.SelectionFont.Italic AndAlso (Not i) Then
                htmlstr &= "<i>"
                i = True
            ElseIf (Not rtf.SelectionFont.Italic) AndAlso i Then
                htmlstr &= "</i>"
                i = False
            End If
            If rtf.SelectionFont.Underline AndAlso (Not u) Then
                htmlstr &= "<u>"
                u = True
            ElseIf (Not rtf.SelectionFont.Underline) AndAlso u Then
                htmlstr &= "</u>"
                u = False
            End If

            htmlstr &= rtf.Text.Chars(x)
            x += 1
        End While
        Return htmlstr
    End Function
End Class