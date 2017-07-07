Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form10
    Public CONNECTION_STRING As String = "Data Source=localhost;Database=sfsts;User ID=root;Password=;"
    Private myconn As New MySqlConnection
    Private mycommand As New MySqlCommand
    Private myreader As MySqlDataReader
    Dim SQlString As String

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AlbumTextBox.Text = Form9.AlbumNameTextBox.Text()
        DateDateTimePicker.Text = Form9.DateDateTimePicker.Text
        PicturePictureBox.Image = Nothing
        If Form9.Form10AddEdit = 1 Then
            TextBox2.BringToFront()
            Label1.BringToFront()
            TitleTextBox.Clear()
            PicturePictureBox.Image = Nothing
        Else
            SQlString = "Select * from tblgallery WHERE galleryid='" & Form9.GalleryId & "'"
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                TitleTextBox.Text = myreader("title").ToString
                Dim bImage As Byte() = CType(myreader("photo"), Byte())
                Using ms As New System.IO.MemoryStream(bImage)
                    PicturePictureBox.Image = Image.FromStream(ms)
                    ImageData = bImage
                End Using
            Loop
            myconn.Close()

            Label1.SendToBack()
            TextBox2.SendToBack()
        End If
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
                PicturePictureBox.Image = Image.FromFile(fd.FileName)
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

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        If TitleTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim DateAdded As Date = CDate(DateDateTimePicker.Text)
            If Form9.Form10AddEdit = 1 Then
                SQlString = "DELETE FROM tblgallery WHERE albumname='" & AlbumTextBox.Text & "' AND title=''"
                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                mycommand.ExecuteNonQuery()
                myconn.Close()
                SQlString = "insert into tblgallery " & _
                "VALUES('','" & AlbumTextBox.Text & "',@Image,'" & TitleTextBox.Text & "','" & DateAdded.ToString("yyyy/MM/dd") & "')"
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
                        .ExecuteNonQuery()
                    End With
                    myconn.Close()
                    Form9.Gallery()
                    Form1.Gallery()
                    MessageBox.Show("Picture successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try

            Else
                Try
                    SQlString = " UPDATE tblgallery " & " SET  photo=@image WHERE galleryid='" & Form9.GalleryId & "'"
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

                    SQlString = " UPDATE tblgallery " & " SET  title='" & TitleTextBox.Text & "' WHERE galleryid='" & Form9.GalleryId & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    Form9.Gallery()
                    Form1.Gallery()
                    MessageBox.Show("Picture successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub TextBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        Attach()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Attach()
    End Sub

    Private Sub PicturePictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicturePictureBox.Click
        Attach()
    End Sub
End Class