Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form8
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
            AuthorityPhotoPictureBox.Image = Image.FromFile(fd.FileName)
            ImageData = br.ReadBytes(CType(fs.Length, Integer))
            br.Close()
            fs.Close()
            TextBox2.SendToBack()
            Label1.SendToBack()
        End If
    End Sub
    Private Sub AuthorityPhotoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuthorityPhotoPictureBox.Click
        Attach()
    End Sub

    Private Sub TextBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Click
        Attach()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Attach()
    End Sub


    Private Sub AuthoritySaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuthoritySaveButton.Click

        If AuthorityNameTextBox.Text = "" Or AuthorityPositionTitleTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Form1.Form8AddEdit = 1 Then
                SQlString = "insert into tblauthority " & _
                "VALUES('','" & AuthorityNameTextBox.Text & "'" & _
                ",'" & AuthorityPositionTitleTextBox.Text & "',@Image)"

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
                    Form1.Authorities()
                    Me.Close()
                    MessageBox.Show("Authority successfully added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            Else
                Try
                    SQlString = " UPDATE tblauthority " & " SET  photo=@image WHERE authorityid='" & Form1.AuthorityId.Item(Form1.AuthorityDataGridView.CurrentCell.RowIndex) & "'"
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

                    SQlString = " UPDATE tblauthority " & " SET  name='" & AuthorityNameTextBox.Text & "' WHERE authorityid='" & Form1.AuthorityId.Item(Form1.AuthorityDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    SQlString = " UPDATE tblauthority " & " SET  title='" & AuthorityPositionTitleTextBox.Text & "' WHERE authorityid='" & Form1.AuthorityId.Item(Form1.AuthorityDataGridView.CurrentCell.RowIndex) & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()

                    Form1.Authorities()
                    Me.Close()
                    MessageBox.Show("Authority successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MsgBox(ex.Message)
                    myconn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.BringToFront()
        Label1.BringToFront()
        If Form1.Form8AddEdit = 1 Then
            InstructionLabel.Text = "   Add Authority"
            AuthorityNameTextBox.Enabled = True
            AuthorityNameTextBox.Clear()
            AuthorityPositionTitleTextBox.Clear()
            AuthorityPhotoPictureBox.Image = Nothing

        Else
            InstructionLabel.Text = "   Edit Authority"
            AuthorityNameTextBox.Enabled = False
            AuthorityNameTextBox.Text = Form1.AuthorityDataGridView.Rows.Item(Form1.Authorityy).Cells(2).Value.ToString
            AuthorityPositionTitleTextBox.Text = Form1.AuthorityDataGridView.Rows.Item(Form1.Authorityy).Cells(3).Value.ToString
            SQlString = "Select photo from tblauthority WHERE authorityid='" & Form1.AuthorityId(Form1.Authorityy) & "'"
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                Dim bImage As Byte() = CType(myreader("photo"), Byte())
                Using ms As New System.IO.MemoryStream(bImage)
                    AuthorityPhotoPictureBox.Image = Image.FromStream(ms)
                    ImageData = bImage
                End Using
            Loop
            myconn.Close()
            TextBox2.SendToBack()
            Label1.SendToBack()
        End If
    End Sub

    Private Sub AuthorityCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuthorityCancelButton.Click
        Form1.Authorities()
        Me.Close()
    End Sub
End Class