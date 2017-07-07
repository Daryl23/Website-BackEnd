
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form9

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

    'Dim GalleryId As New List(Of Integer)
    Dim AlbumName As String
    Public GalleryId As Integer

    Dim GalleryBtn As New List(Of Control)
    Dim GalleryChk As New List(Of CheckBox)
    Public GalleryPhoto As New List(Of PictureBox)


    Dim NewPictureList As New List(Of PictureBox)
    Dim NewTitleList As New List(Of String)

    Public Form10AddEdit As Integer = 0

    Dim i As Integer
    Dim x As Integer
    Dim y As Integer

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AlbumName = Form1.AlbumName
        AlbumNameTextBox.Clear()
        GalleryPanel.Controls.Clear()
        If Form1.AlbumName = "" Then
            InstructionLabel.Text = "Add New Album."
            AlbumNameTextBox.Enabled = True
            DateDateTimePicker.Text = Date.Now
            DateDateTimePicker.Enabled = True
        Else
            InstructionLabel.Text = "Edit Album."
            AlbumNameTextBox.Enabled = False
            AlbumNameTextBox.Text = AlbumName
            DateDateTimePicker.Enabled = False
            SQlString = "Select dateadded from tblgallery WHERE albumname='" & AlbumName & "'"
                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                myreader = mycommand.ExecuteReader
                Do While myreader.Read
                DateAdded = myreader("dateadded").ToString
                Loop
            myconn.Close()
            DateDateTimePicker.Text = DateAdded.ToString("yyyy/MM/dd")
        End If
        DeleteAlbumButton.Enabled = False
        If AlbumNameTextBox.Enabled = False Then
            AddAlbumButton.Enabled = False
            Gallery()
        Else
            AddAlbumButton.Enabled = True
        End If
    End Sub

    Sub Gallery()
        x = 6
        y = 0
        GalleryBtn.Clear()
        'GalleryId.Clear()
        GalleryChk.Clear()
        GalleryPanel.Controls.Clear()
        Dim lbl As New Label With
              {
        .Size = New Size(38, 38),
       .Location = New Point(57, 22),
       .Font = New Font("Cambria", 30, FontStyle.Bold),
        .BackColor = Color.White,
        .ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
        .TextAlign = CType(HorizontalAlignment.Center, ContentAlignment),
       .Text = "+",
        .Cursor = Cursors.Hand
                }
        ToolTip1.SetToolTip(lbl, "Insert New Picture")
        AddHandler lbl.Click, AddressOf lbl_Click
        GalleryPanel.Controls.Add(lbl)
        Dim lbl2 As New Label With
               {
                   .Size = New Size(110, 50),
        .Location = New Point(20,
                              75),
        .Font = New Font("Cambria", 15, FontStyle.Bold),
          .BackColor = Color.White,
                   .ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
                   .TextAlign = CType(HorizontalAlignment.Center, ContentAlignment),
        .Text = "Insert New Picture",
                   .Cursor = Cursors.Hand
    }
        ToolTip1.SetToolTip(lbl2, "Insert New Picture")
        AddHandler lbl2.Click, AddressOf lbl2_Click
        GalleryPanel.Controls.Add(lbl2)

        Dim picbox As PictureBox
        ' Dim bImage As Byte() = CType(myreader("photo"), Byte())
        'Using ms As New IO.MemoryStream(bImage)
        picbox = New PictureBox With
                     {
              .Size = New Size(125, 112),
              .Location = New Point(12,
                                    20),
            .BorderStyle = BorderStyle.Fixed3D,
              .BackColor = Color.White,
        .Cursor = Cursors.Hand}
        'End Using
        ToolTip1.SetToolTip(picbox, "Insert New Album")
        AddHandler picbox.Click, AddressOf picbox_Click
        GalleryPanel.Controls.Add(picbox)

        If InstructionLabel.Text = "Edit Album." Then
            i = 0
            SQlString = "Select * from tblgallery WHERE albumname='" & AlbumName & "' AND title!=''"
            Try
                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                myreader = mycommand.ExecuteReader
                Do While myreader.Read
                    'z = 140
                    x = x + 130
                    i = i + 1
                    If (i) Mod 7 = 0 Then
                        x = 6
                        y = y + 140
                    End If

                    Dim lbl1 As New Label With
                         {
                  .Location = New Point(x + 6,
                                        y + 25),
                  .Size = New Size(100, 17),
                  .Font = New Font("Cambria", 9.75),
                    .BorderStyle = BorderStyle.FixedSingle,
                    .BackColor = Color.White,
                  .Text = myreader("title").ToString,
                  .ForeColor = Color.DimGray}


                    'GalleryPanel.Controls.Add(lbl1)

                    Dim chkbox1 As New CheckBox With
                         {
                             .Tag = myreader("galleryid").ToString,
                    .Location = New Point(x + 118, y + 117),
                    .AutoSize = True,
                    .BackColor = Color.FromKnownColor(KnownColor.Control),
                    .Cursor = Cursors.Hand
                  }
                    AddHandler chkbox1.CheckedChanged, AddressOf chkbox1_CheckedChanged
                    GalleryChk.Add(chkbox1)
                    GalleryPanel.Controls.Add(chkbox1)

                    Dim btn1 As New Button With
                {
                    .Name = "btn" & i.ToString,
                  .Size = New Size(24, 25),
                  .Location = New Point(x + 106, y + 125),
                  .Text = "X",
                  .FlatStyle = FlatStyle.Popup,
                  .ForeColor = Color.Red,
                    .Cursor = Cursors.Hand
                }
                    GalleryBtn.Add(btn1)
                    'AddHandler btn1.Click, AddressOf btn1_Click
                    'GalleryPanel.Controls.Add(btn1)

                    Dim txtbox1 As New TextBox With
                {
                  .Size = New Size(125, 23),
                  .Location = New Point(x + 7,
                                      y + 131),
                  .BorderStyle = BorderStyle.None,
                  .Enabled = False,
                  .Text = myreader("title").ToString,
                  .TextAlign = HorizontalAlignment.Center,
                    .Font = New Drawing.Font("Cambria", 9.75)
                }
                    GalleryPanel.Controls.Add(txtbox1)
                    GalleryPhoto.Clear()
                    Dim picbox1 As PictureBox
                    Dim bImage As Byte() = CType(myreader("photo"), Byte())
                    Using ms As New IO.MemoryStream(bImage)
                        picbox1 = New PictureBox With
                                     {
                                         .Tag = myreader("galleryid").ToString,
                              .Size = New Size(125, 110),
                              .Location = New Point(x + 6,
                                                    y + 20),
                              .BackColor = Color.White,
                        .Cursor = Cursors.Hand,
                              .Image = Image.FromStream(ms),
                              .SizeMode = PictureBoxSizeMode.StretchImage}
                        ToolTip1.SetToolTip(picbox1, "View/Edit")
                    End Using
                    GalleryPhoto.Add(picbox1)
                    AddHandler picbox1.Click, AddressOf picbox1_Click
                    GalleryPanel.Controls.Add(picbox1)

                Loop
                myconn.Close()
            Catch ex As Exception
                MessageBox.Show("Error Post.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                myconn.Close()
            End Try

        End If
    End Sub

    Public Sub Attach()
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String
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

            x = x + 130
            i = i + 1
            If (i) Mod 3 = 0 Then
                x = 6
                y = y + 140
            End If

            Dim chkbox1 As New CheckBox With
                 {
            .Location = New Point(x + 118, y + 117),
            .AutoSize = True,
            .BackColor = Color.FromKnownColor(KnownColor.Control),
            .Cursor = Cursors.Hand
          }
            AddHandler chkbox1.CheckedChanged, AddressOf chkbox1_CheckedChanged
            GalleryChk.Add(chkbox1)
            GalleryPanel.Controls.Add(chkbox1)

            Dim btn1 As New Button With
        {
            .Name = "btn" & i.ToString,
          .Size = New Size(24, 25),
          .Location = New Point(x + 106, y + 125),
          .Text = "X",
          .FlatStyle = FlatStyle.Popup,
          .ForeColor = Color.Red,
            .Cursor = Cursors.Hand
        }
            GalleryBtn.Add(btn1)
            'AddHandler btn1.Click, AddressOf btn1_Click
            'GalleryPanel.Controls.Add(btn1)

            Dim txtbox1 As New TextBox With
        {
          .Size = New Size(125, 23),
          .Location = New Point(x + 7,
                              y + 131),
          .BorderStyle = BorderStyle.None,
          .Enabled = True,
          .TextAlign = HorizontalAlignment.Center,
            .Font = New Drawing.Font("Cambria", 9.75)
        }
            txtbox1.Focus()
            NewTitleList.Add(txtbox1.Text)
            AddHandler txtbox1.TextChanged, AddressOf txtbox1_TextChanged
            GalleryPanel.Controls.Add(txtbox1)

            Dim picbox1 As PictureBox
            picbox1 = New PictureBox With
                         {
                  .Size = New Size(125, 110),
                  .Location = New Point(x + 6,
                                        y + 20),
                  .BackColor = Color.White,
            .Cursor = Cursors.Hand,
                  .Image = Image.FromFile(fd.FileName),
                  .SizeMode = PictureBoxSizeMode.StretchImage}
            ToolTip1.SetToolTip(picbox1, "View/Edit")
            'AddHandler picbox1.Click, AddressOf picbox1_Click
            NewPictureList.Add(picbox1)
            GalleryPanel.Controls.Add(picbox1)
            ImageData = br.ReadBytes(CType(fs.Length, Integer))
            br.Close()
            fs.Close()
        End If
    End Sub

    Private Sub picbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AlbumNameTextBox.Enabled = False Then
            Form10AddEdit = 1
            Form10.ShowDialog()
        Else
            'MessageBox.Show("Error Post.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        'Attach()
    End Sub

    Private Sub lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form10AddEdit = 1
        Form10.ShowDialog()
        'Attach()
    End Sub

    Private Sub lbl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form10AddEdit = 1
        Form10.ShowDialog()
        'Attach()
    End Sub

    Private Sub picbox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form10AddEdit = 2
        GalleryId = CType(sender, Control).Tag
        Form10.ShowDialog()
    End Sub

    Private Sub chkbox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As Integer = 0
        If CType(sender, Control).Tag IsNot Nothing Then
            For j = 0 To GalleryChk.Count - 1
                If GalleryChk(j).Checked = True Then
                    a = 1
                    Exit For
                End If
            Next
            If a = 1 Then
                DeleteAlbumButton.Enabled = True
            Else
                DeleteAlbumButton.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtbox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to cancel editing? ", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Form1.Gallery()
            Me.Close()
        End If
    End Sub

    Private Sub DeleteAlbumButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAlbumButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected picture(s)? ", "Delete Album(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For j = 0 To GalleryChk.Count - 1
                If GalleryChk(j).Checked = True Then
                    Try
                        SQlString = "DELETE FROM tblgallery WHERE galleryid='" & GalleryChk(j).Tag.ToString & "'"
                        myconn.ConnectionString = CONNECTION_STRING
                        myconn.Open()
                        mycommand.Connection = myconn
                        mycommand.CommandText = SQlString
                        mycommand.ExecuteNonQuery()
                        myconn.Close()
                    Catch ex As Exception
                        MessageBox.Show("No records found." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Next
            MessageBox.Show("Picture(s) has been deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Gallery()
        End If
    End Sub
    Dim DateAdded As Date
    Private Sub AddAlbumButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAlbumButton.Click
        DateAdded = CDate(DateDateTimePicker.Text)
        AlbumName = AlbumNameTextBox.Text
        'If InstructionLabel.Text = "Add New Album." Then
        'If NewPictureList.Count = 0 Then
        'MessageBox.Show("Please insert picture(s) first before saving.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        'Else
        'Dim a As Integer = 0
        'For j = 0 To NewPictureList.Count - 1
        'If NewTitleList.Item(j) = "" Then
        'a = 1
        'MessageBox.Show("Please input a necessary title for the pictures to be saved.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Exit For
        'End If
        'Next
        'If a = 0 Then
        'For j = 0 To NewPictureList.Count - 1
        'ImageData = br.ReadBytes(NewPictureList(j))
        SQlString = "insert into tblgallery " & _
                                "VALUES('','" & AlbumName & "',NULL,'','" & DateAdded.ToString("yyyy/MM/dd") & "')"
        myconn.ConnectionString = CONNECTION_STRING
        myconn.Open()
        mycommand.Connection = myconn
        mycommand.CommandText = SQlString
        With mycommand
            mycommand.Parameters.Clear()
            .CommandText = SQlString
            .Connection = myconn
            .ExecuteNonQuery()
        End With
        myconn.Close()
        'Form1.HomeLoad()
        MessageBox.Show("Album successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Gallery()
        AlbumNameTextBox.Enabled = False
        DateDateTimePicker.Enabled = False
        InstructionLabel.Text = "Edit Album."
        'Me.Close()
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'myconn.Close()
        'End Try
        'Next
        'End If

    End Sub

End Class