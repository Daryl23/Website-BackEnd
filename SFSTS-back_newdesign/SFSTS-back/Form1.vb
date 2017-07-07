
Option Strict On
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

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

    Public PostId As New List(Of Integer)
    Sub HomeLoad()
        PostId.Clear()
        PostCheckAllCheckBox.Checked = False
        HomePostsDataGridView.Rows.Clear()
        PostDeleteButton.Enabled = False
        HomeEditButton.Enabled = False
        SQlString = "Select * from tblpost"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                Dim n As Integer = HomePostsDataGridView.Rows.Add
                PostId.Add(CInt(myreader("postid").ToString))
                'HomePostsDataGridView.Rows.Item(n).Cells(0).Value = ""
                HomePostsDataGridView.Rows.Item(n).Cells(1).Value = (n + 1).ToString
                HomePostsDataGridView.Rows.Item(n).Cells(2).Value = myreader("title").ToString
                HomePostsDataGridView.Rows.Item(n).Cells(3).Value = myreader("author").ToString
                HomePostsDataGridView.Rows.Item(n).Cells(4).Value = myreader("category").ToString
                HomePostsDataGridView.Rows.Item(n).Cells(5).Value = myreader("date").ToString
                HomePostsDataGridView.Rows.Item(n).Cells(6).Value = "VIEW CONTENT"
                Dim bImage As Byte() = CType(myreader("attachment"), Byte())
                Using ms As New IO.MemoryStream(bImage)
                    HomePostsDataGridView.Rows.Item(n).Cells(7).Value = Image.FromStream(ms)
                End Using
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error Post.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

   

    Public Homex As Integer
    Public Homey As Integer
    Private Sub HomePostsDataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles HomePostsDataGridView.CellClick
        HomeEditButton.Enabled = True
        Try
            Homex = HomePostsDataGridView.CurrentCellAddress.X
            Homey = HomePostsDataGridView.CurrentCellAddress.Y
            Dim chk As Integer = 0
            If Homex = 0 Then
                If CBool(HomePostsDataGridView.Rows(Homey).Cells(0).Value) = True Then
                    HomePostsDataGridView.Rows(Homey).Cells(Homex).Value = False
                Else
                    HomePostsDataGridView.Rows(Homey).Cells(Homex).Value = True
                End If
                For i = 0 To HomePostsDataGridView.Rows.Count - 1
                    If CBool(HomePostsDataGridView.Rows(i).Cells(0).Value) = True Then
                        chk = chk + 1
                    End If
                Next
                If chk > 0 Then
                    PostDeleteButton.Enabled = True
                Else
                    PostDeleteButton.Enabled = False
                End If

            End If
        Catch ex As Exception
            myconn.Close()
        End Try
    End Sub

    Private Sub StatementSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatementSaveButton.Click
        If HistoryTextBox.Text = "" Or MissionTextBox.Text = "" Or VisionTextBox.Text = "" Then
            MessageBox.Show("Please fill in the required fields.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you want to saved statements changes? ", "Change Statement?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                Try
                    SQlString = "UPDATE tblstatements " & " SET  history='" & HistoryTextBox.Text & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    SQlString = " UPDATE tblstatements " & " SET  mission='" & MissionTextBox.Text & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    SQlString = " UPDATE tblstatements " & " SET  vision='" & VisionTextBox.Text & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    SQlString = " UPDATE tblstatements " & " SET  corevalues='" & CoreValuesTextBox.Text & "'"
                    myconn.ConnectionString = CONNECTION_STRING
                    myconn.Open()
                    mycommand.Connection = myconn
                    mycommand.CommandText = SQlString
                    mycommand.ExecuteNonQuery()
                    myconn.Close()
                    MessageBox.Show("Statements successfully updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    'Use of quote, double quote, backslash,underscore and percent are not allowed.
                    MessageBox.Show(ex.Message, "UnSafe Character Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    myconn.Close()
                End Try
            End If
        End If
    End Sub

    Sub About_Statements()
        HistoryTextBox.Clear()
        MissionTextBox.Clear()
        VisionTextBox.Clear()
        CoreValuesTextBox.Clear()

        SQlString = "Select * from tblstatements"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                HistoryTextBox.Text = myreader("history").ToString
                MissionTextBox.Text = myreader("mission").ToString
                VisionTextBox.Text = myreader("vision").ToString
                CoreValuesTextBox.Text = myreader("corevalues").ToString
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error Statement.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Public PeopleId As New List(Of Integer)
    Sub About_People()
        PeopleId.Clear()
        CommunityCheckBox.Checked = False
        OurPeopleDataGridView.Rows.Clear()
        DeleteCommunityButton.Enabled = False
        EditPeopleButton.Enabled = False
        SQlString = "Select * from ourpeople"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                Dim n As Integer = OurPeopleDataGridView.Rows.Add
                PeopleId.Add(CInt(myreader("ourpeopleid").ToString))
                OurPeopleDataGridView.Rows.Item(n).Cells(1).Value = (n + 1).ToString
                OurPeopleDataGridView.Rows.Item(n).Cells(2).Value = myreader("name").ToString
                OurPeopleDataGridView.Rows.Item(n).Cells(3).Value = myreader("title").ToString
                OurPeopleDataGridView.Rows.Item(n).Cells(5).Value = "VIEW FULL DETAILS"
                Dim bImage As Byte() = CType(myreader("photo"), Byte())
                Using ms As New IO.MemoryStream(bImage)
                    OurPeopleDataGridView.Rows.Item(n).Cells(4).Value = Image.FromStream(ms)
                End Using
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error People.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Public ContactId As New List(Of Integer)
    Sub ContactInfo()
        ContactCheckBox.Checked = False
        ContactNumberListView.Items.Clear()
        ContactNumberTextBox.Clear()
        ContactDeleteButton.Enabled = False
        ContactId.Clear()
        Dim n As Integer = 0
        SQlString = "Select * from tblcontactinfo"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                n = n + 1
                ContactId.Add(CInt(myreader("contactid").ToString))
                ContactNumberListView.Items.Add("")
                ContactNumberListView.Items(ContactNumberListView.Items.Count - 1).SubItems.Add(n.ToString)
                ContactNumberListView.Items(ContactNumberListView.Items.Count - 1).SubItems.Add(myreader("contactno").ToString)
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error ContactInfo.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try

        SQlString = "Select * from tbladdress"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                AddressTextBox.Text = myreader("address").ToString
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error ContactInfo.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try

        SQlString = "Select * from tblemail"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                EmailTextBox.Text = myreader("email").ToString
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error ContactInfo.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Public AuthorityId As New List(Of Integer)
    Sub Authorities()
        AuthorityDataGridView.Rows.Clear()
        AuthoritiesCheckBox.Checked = False
        DeleteAuthorityButton.Enabled = False
        EditAuthorityButton.Enabled = False
        AuthorityId.Clear()
        SQlString = "Select * from tblauthority"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                Dim n As Integer = AuthorityDataGridView.Rows.Add
                AuthorityId.Add(CInt(myreader("authorityid").ToString))
                AuthorityDataGridView.Rows.Item(n).Cells(1).Value = (n + 1).ToString
                AuthorityDataGridView.Rows.Item(n).Cells(2).Value = myreader("name").ToString
                AuthorityDataGridView.Rows.Item(n).Cells(3).Value = myreader("title").ToString
                Dim bImage As Byte() = CType(myreader("photo"), Byte())
                Using ms As New IO.MemoryStream(bImage)
                    AuthorityDataGridView.Rows.Item(n).Cells(4).Value = Image.FromStream(ms)
                End Using
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error ContactInfo.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Public Form5AddEdit As Integer = 0
    Private Sub HomeAddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeAddButton.Click
        'HomeAddButton.Enabled = False
        ' HomeEditButton.Enabled = True
        'HomePostsDataGridView.BackgroundColor = Color.Gainsboro
        'PostListsGroupBox.Enabled = False
        'PostMaintenanceGroupBox.Enabled = True
        'PostCheckAllCheckBox.Checked = False
        'HomeClear()
        'HomeLoad()
        Form5AddEdit = 1
        Form5.ShowDialog()
    End Sub

    Private Sub HomeEditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeEditButton.Click
        'HomeEditButton.Enabled = False
        'HomeAddButton.Enabled = True
        'HomePostsDataGridView.BackgroundColor = Color.White
        'PostListsGroupBox.Enabled = True
        'PostMaintenanceGroupBox.Enabled = False
        'HomeClear()
        Form5AddEdit = 2
        Form5.ShowDialog()
    End Sub

   

    Public FAQSelectedid As Integer
    Private Sub FAQListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAQListView.SelectedIndexChanged
        For a = 0 To FAQListView.Items.Count - 1
            If FAQListView.Items.Item(a).Selected = True Then
                FAQSelectedid = a
                ViewEditFAQButton.Enabled = True
                Exit For
            Else
                ViewEditFAQButton.Enabled = False
            End If
        Next
    End Sub

    Private Sub StatementsClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatementsCancelButton.Click
        About_Statements()
    End Sub

    Private Sub AuthoritySaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Form6AddEdit As Integer
    Private Sub AddFAQButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFAQButton.Click
        'AddFAQButton.Enabled = False
        'ViewEditFAQButton.Enabled = True
        'FAQCheckBox.Enabled = False
        'FAQListView.Enabled = False
        'FAQDeleteButton.Enabled = False
        'FAQQuestionTextBox.Clear()
        'FAQCheckBox.Checked = False
        'FAQQuestionTextBox.Enabled = True
        'FAQAnswerTextBox.Clear()
        'FAQAnswerTextBox.Enabled = True
        'FAQSaveButton.Enabled = True
        'FAQCancelButton.Enabled = True
        'FAQ()
        Form6AddEdit = 1
        Form6.ShowDialog()
    End Sub

    Dim FAQId As New List(Of Integer)
    Sub FAQ()
        FAQId.Clear()
        FAQCheckBox.Checked = False
        FAQListView.Items.Clear()
        FAQDeleteButton.Enabled = False
        ViewEditFAQButton.Enabled = False
        Dim n As Integer = 0
        SQlString = "Select * from tblfaq"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                n = n + 1
                FAQId.Add(CInt(myreader("faqid").ToString))
                FAQListView.Items.Add("")
                FAQListView.Items(FAQListView.Items.Count - 1).SubItems.Add(n.ToString)
                FAQListView.Items(FAQListView.Items.Count - 1).SubItems.Add(myreader("question").ToString)
                FAQListView.Items(FAQListView.Items.Count - 1).SubItems.Add(myreader("answer").ToString)
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error ContactInfo.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Private Sub ViewEditFAQButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewEditFAQButton.Click
        'AddFAQButton.Enabled = True
        'ViewEditFAQButton.Enabled = False
        'FAQCheckBox.Enabled = True
        'FAQListView.Enabled = True
        'FAQQuestionTextBox.Clear()
        'FAQQuestionTextBox.Enabled = False
        'FAQAnswerTextBox.Clear()
        'FAQAnswerTextBox.Enabled = False
        'FAQSaveButton.Enabled = False
        'FAQCancelButton.Enabled = False
        'FAQ()
        Form6AddEdit = 2
        Form6.ShowDialog()
    End Sub


    Private Sub FAQDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAQDeleteButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected frequently asked question(s)? ", "Delete FAQ(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = FAQListView.Items.Count - 1 To 0 Step -1
                If FAQListView.Items(i).Checked = True Then
                    Try
                        SQlString = "DELETE FROM tblfaq WHERE faqid='" & FAQId.Item(i) & "'"
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
           
            FAQ()
            MessageBox.Show("FAQ has been deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FAQDeleteButton.Enabled = False
        End If
    End Sub

    Private Sub FAQListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAQListView.ItemChecked
        If FAQListView.CheckedItems.Count > 0 Then
            FAQDeleteButton.Enabled = True
        Else
            FAQDeleteButton.Enabled = False
        End If

    End Sub

    Private Sub FAQCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FAQCheckBox.CheckedChanged
        If FAQCheckBox.Checked = True Then
            For i = 0 To FAQListView.Items.Count - 1
                FAQListView.Items(i).Checked = True
            Next
        Else
            For i = 0 To FAQListView.Items.Count - 1
                FAQListView.Items(i).Checked = False
            Next
        End If

    End Sub

    Private Sub PostDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostDeleteButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected post(s)? ", "Delete Post(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = 0 To HomePostsDataGridView.Rows.Count - 1
                If CBool(HomePostsDataGridView.Rows(i).Cells(0).Value) = True Then
                    Try
                        SQlString = "DELETE FROM tblpost WHERE postid='" & PostId.Item(i) & "'"
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
            HomeLoad()
            MessageBox.Show("Post successfully deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ContactSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactSaveButton.Click
        If ContactNumberTextBox.Text = "" Then
            MessageBox.Show("Please enter a valid contact number before saving.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                SQlString = "insert into tblcontactinfo " & _
                                        "VALUES('','" & ContactNumberTextBox.Text & "')"

                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                mycommand.ExecuteNonQuery()
                myconn.Close()
                ContactInfo()
                MessageBox.Show("Contact Information has been added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                myconn.Close()
            End Try
        End If
    End Sub

   

    Public Peoplex As Integer
    Public Peopley As Integer
    Private Sub OurPeopleDataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OurPeopleDataGridView.CellClick
        EditPeopleButton.Enabled = True
        Peoplex = OurPeopleDataGridView.CurrentCellAddress.X
        Peopley = OurPeopleDataGridView.CurrentCellAddress.Y

        Dim chk As Integer = 0
        If Peoplex = 0 Then

            If CBool(OurPeopleDataGridView.Rows(Peopley).Cells(Peoplex).Value) = True Then
                OurPeopleDataGridView.Rows(Peopley).Cells(Peoplex).Value = False
            Else
                OurPeopleDataGridView.Rows(Peopley).Cells(Peoplex).Value = True
            End If
            For i = 0 To OurPeopleDataGridView.Rows.Count - 1
                If CBool(OurPeopleDataGridView.Rows(i).Cells(0).Value) = True Then
                    chk = chk + 1
                End If
            Next
            If chk > 0 Then
                DeleteCommunityButton.Enabled = True
            Else
                DeleteCommunityButton.Enabled = False
            End If
        End If

    End Sub

    Public Authorityx As Integer
    Public Authorityy As Integer
    Private Sub AuthorityDataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AuthorityDataGridView.CellClick
        EditAuthorityButton.Enabled = True
        Authorityx = AuthorityDataGridView.CurrentCellAddress.X
        Authorityy = AuthorityDataGridView.CurrentCellAddress.Y
        Dim chk As Integer
        If Authorityx = 0 Then
            If CBool(AuthorityDataGridView.Rows(Authorityy).Cells(Authorityx).Value) = True Then
                AuthorityDataGridView.Rows(Authorityy).Cells(Authorityx).Value = False
            Else
                AuthorityDataGridView.Rows(Authorityy).Cells(Authorityx).Value = True
            End If
            For i = 0 To AuthorityDataGridView.Rows.Count - 1
                If CBool(AuthorityDataGridView.Rows(i).Cells(0).Value) = True Then
                    chk = chk + 1
                End If
            Next
            If chk > 0 Then
                DeleteAuthorityButton.Enabled = True
            Else
                DeleteAuthorityButton.Enabled = False
            End If
        End If
    End Sub

    Public Form7AddEdit As Integer
    Private Sub AddPeopleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPeopleButton.Click
        Form7AddEdit = 1
        Form7.ShowDialog()
    End Sub

    Private Sub EditPeopleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPeopleButton.Click
        Form7AddEdit = 2
        Form7.ShowDialog()
    End Sub

    Private Sub PostCheckAllCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostCheckAllCheckBox.CheckedChanged
        If PostCheckAllCheckBox.Checked = True Then
            PostDeleteButton.Enabled = True
            For i = 0 To HomePostsDataGridView.Rows.Count - 1
                HomePostsDataGridView.Rows(i).Cells(0).Value = True
            Next
        Else
            PostDeleteButton.Enabled = False
            For i = 0 To HomePostsDataGridView.Rows.Count - 1
                HomePostsDataGridView.Rows(i).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub GoToWebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start("http://www.google.com")
        ' Or use this to open a website >>>>NavigateWebURL(http://www.google.com, "default")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Integer = MessageBox.Show("Are you sure you want to log out? ", "Log out?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ClearHistoryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearHistoryButton.Click
        HistoryTextBox.Clear()
    End Sub

    Private Sub ClearMissionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearMissionButton.Click
        MissionTextBox.Clear()
    End Sub

    Private Sub ClearVisionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearVisionButton.Click
        VisionTextBox.Clear()
    End Sub

    Private Sub ClearCoreValuesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearCoreValuesButton.Click
        CoreValuesTextBox.Clear()
    End Sub

    Private Sub StatementsCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        About_Statements()
    End Sub

    Private Sub CommunityCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommunityCheckBox.CheckedChanged
        If CommunityCheckBox.Checked = True Then
            DeleteCommunityButton.Enabled = True
            For i = 0 To OurPeopleDataGridView.Rows.Count - 1
                OurPeopleDataGridView.Rows(i).Cells(0).Value = True
            Next
        Else
            DeleteCommunityButton.Enabled = False
            For i = 0 To OurPeopleDataGridView.Rows.Count - 1
                OurPeopleDataGridView.Rows(i).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub DeleteCommunityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCommunityButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected community? ", "Delete Community?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = 0 To OurPeopleDataGridView.Rows.Count - 1
                If CBool(OurPeopleDataGridView.Rows(i).Cells(0).Value) = True Then
                    Try
                        SQlString = "DELETE FROM ourpeople WHERE ourpeopleid='" & PeopleId.Item(i) & "'"
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
            About_People()
            MessageBox.Show("Person's Data successfully deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub AuthoritiesCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuthoritiesCheckBox.CheckedChanged
        If AuthoritiesCheckBox.Checked = True Then
            DeleteAuthorityButton.Enabled = True
            For i = 0 To AuthorityDataGridView.Rows.Count - 1
                AuthorityDataGridView.Rows(i).Cells(0).Value = True
            Next
        Else
            DeleteAuthorityButton.Enabled = False
            For i = 0 To AuthorityDataGridView.Rows.Count - 1
                AuthorityDataGridView.Rows(i).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Integer = MessageBox.Show("Are you sure you want to log out? ", "Log Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    'Gallery
    Dim GalleryId As New List(Of Integer)
    Public AlbumName As String
    Dim AlbumList As New List(Of String)
    Dim GalleryBtn As New List(Of Control)
    Dim GalleryChk As New List(Of CheckBox)
    Dim GalleryPhoto As New List(Of Control)

    Sub Gallery()
        GalleryCheckBox.Checked = False
        GalleryDeleteButton.Enabled = False
        GalleryBtn.Clear()
        GalleryId.Clear()
        GalleryChk.Clear()
        GalleryPanel.Controls.Clear()
        AlbumList.Clear()
        Dim x As Integer = 6
        Dim y As Integer = 0
        Dim z As Integer = 0

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
        ToolTip1.SetToolTip(lbl, "Insert New Album")
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
        .Text = "Insert New Album",
                   .Cursor = Cursors.Hand
    }
        ToolTip1.SetToolTip(lbl2, "Insert New Album")
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

        SQlString = "Select distinct albumname from tblgallery"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                AlbumList.Add(myreader("albumname").ToString)
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error Post.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try

        Dim i As Integer = 0
        For j = 0 To AlbumList.Count - 1
            SQlString = "Select * from tblgallery WHERE albumname='" & AlbumList.Item(j) & "' LIMIT 1"
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
                    If (i) Mod 5 = 0 Then
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
                             .Tag = AlbumList.Item(j),
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
                    .Tag = AlbumList.Item(j),
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
                  .Text = AlbumList.Item(j),
                  .TextAlign = HorizontalAlignment.Center,
                    .Font = New Drawing.Font("Cambria", 9.75)
                }
                    GalleryPanel.Controls.Add(txtbox1)
                    Dim picbox1 As PictureBox
                    Try
                        Dim bImage As Byte() = CType(myreader("photo"), Byte())
                        Using ms As New IO.MemoryStream(bImage)
                            picbox1 = New PictureBox With
                                         {
                                             .Tag = AlbumList.Item(j),
                                  .Size = New Size(125, 110),
                                  .Location = New Point(x + 6,
                                                        y + 20),
                                  .BackColor = Color.White,
                            .Cursor = Cursors.Hand,
                                  .Image = Image.FromStream(ms),
                                  .SizeMode = PictureBoxSizeMode.StretchImage}
                            ToolTip1.SetToolTip(picbox1, "View/Edit")
                        End Using
                    Catch
                        picbox1 = New PictureBox With
                                     {
                                         .Tag = AlbumList.Item(j),
                              .Size = New Size(125, 110),
                              .Location = New Point(x + 6,
                                                    y + 20),
                              .BackColor = Color.White,
                        .Cursor = Cursors.Hand,
                              .Image = Nothing,
                              .SizeMode = PictureBoxSizeMode.StretchImage}
                            ToolTip1.SetToolTip(picbox1, "View/Edit")
                    End Try
                    AddHandler picbox1.Click, AddressOf picbox1_Click
                    GalleryPanel.Controls.Add(picbox1)

                Loop
                myconn.Close()
            Catch ex As Exception
                MessageBox.Show("Error Post.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                myconn.Close()
            End Try
        Next
    End Sub

    Private Sub picbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AlbumName = ""
        Form9.ShowDialog()
    End Sub

    Private Sub lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AlbumName = ""
        Form9.ShowDialog()
    End Sub

    Private Sub lbl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AlbumName = ""
        Form9.ShowDialog()
    End Sub

    Private Sub picbox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(sender, Control).Tag IsNot Nothing Then
            AlbumName = CType(sender, PictureBox).Tag.ToString
            Form9.ShowDialog()
        End If
    End Sub

    Private Sub chkbox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As Integer = 0
        If CType(sender, Control).Tag IsNot Nothing Then
            For i = 0 To GalleryChk.Count - 1
                If GalleryChk(i).Checked = True Then
                    a = 1
                    Exit For
                End If
            Next
            If a = 1 Then
                GalleryDeleteButton.Enabled = True
            Else
                GalleryDeleteButton.Enabled = False
            End If
        End If
    End Sub

    Sub DynamicEvent()
        'If CType(sender, Control).Tag IsNot Nothing Then
        'MessageBox.Show("Button ahahahah.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete this album? ", "Delete Album?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                'SQlString = "DELETE FROM tblgallery WHERE albumname='" & CType(sender, Button).Tag.ToString & "'"
                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                mycommand.ExecuteNonQuery()
                myconn.Close()
                Gallery()
                MessageBox.Show("Album successfully deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                'Use of quote, double quote, backslash,underscore and percent are not allowed.
                MessageBox.Show(ex.Message, "UnSafe Character Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                myconn.Close()
            End Try
        End If
        ' End If
        ' CODE TO HANDLE CLICK EVENT
    End Sub

    Public Form8AddEdit As Integer
    Private Sub AddAuthorityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAuthorityButton.Click
        Form8AddEdit = 1
        Form8.ShowDialog()
    End Sub

    Private Sub EditAuthorityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditAuthorityButton.Click
        Form8AddEdit = 2
        Form8.ShowDialog()
    End Sub

     Private Sub SaveEmailButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveEmailButton.Click
        Dim regExPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
        Dim emailAddressMatch As System.Text.RegularExpressions.Match = Regex.Match(EmailTextBox.Text, regExPattern)

        If EmailTextBox.Text = "" Or emailAddressMatch.Success = False Then
            MessageBox.Show("Please enter a valid email before saving.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                SQlString = " UPDATE tblemail " & "SET  email='" & EmailTextBox.Text & "'"
                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                mycommand.ExecuteNonQuery()
                myconn.Close()
                ContactInfo()
                MessageBox.Show("Email has been updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                myconn.Close()
            End Try
        End If
    End Sub

    Private Sub SaveAddressButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAddressButton.Click
        If AddressTextBox.Text = "" Then
            MessageBox.Show("Please enter a valid address before saving.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                SQlString = " UPDATE tbladdress " & "SET  address='" & AddressTextBox.Text & "'"
                myconn.ConnectionString = CONNECTION_STRING
                myconn.Open()
                mycommand.Connection = myconn
                mycommand.CommandText = SQlString
                mycommand.ExecuteNonQuery()
                myconn.Close()
                ContactInfo()
                MessageBox.Show("Address has been updated.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
                myconn.Close()
            End Try
        End If
    End Sub

    Private Sub ContactNumberListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactNumberListView.ItemChecked
        If ContactNumberListView.CheckedItems.Count > 0 Then
            ContactDeleteButton.Enabled = True
        Else
            ContactDeleteButton.Enabled = False
        End If
    End Sub

    Private Sub ContactDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactDeleteButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected contact number(s)? ", "Delete Contact Number(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = ContactNumberListView.Items.Count - 1 To 0 Step -1
                If ContactNumberListView.Items(i).Checked = True Then
                    Try
                        SQlString = "DELETE FROM tblcontactinfo WHERE contactid='" & ContactId.Item(i) & "'"
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
            ContactInfo()
            MessageBox.Show("Contact number has been deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ContactDeleteButton.Enabled = False
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        If TreeView1.Nodes(0).IsSelected = True Then
            InstructionLabel.Text = "HOME."
            HomePanel.BringToFront()
        ElseIf TreeView1.Nodes(0).Nodes(0).IsSelected = True Then
            InstructionLabel.Text = "POST."
            HomeLoad()
            PostPanel.BringToFront()
        ElseIf TreeView1.Nodes(0).Nodes(1).IsSelected = True Then
            InstructionLabel.Text = "PROGRAMS OFFERED."
            Programs()
            ProgramsPanel.BringToFront()

        ElseIf TreeView1.Nodes(1).IsSelected = True Then
        ElseIf TreeView1.Nodes(1).Nodes(0).IsSelected = True Then
            InstructionLabel.Text = "STATEMENTS."
            About_Statements()
            StatementPanel.BringToFront()
        ElseIf TreeView1.Nodes(1).Nodes(1).IsSelected = True Then
            InstructionLabel.Text = "COMMUNITIES."
            About_People()
            CommunityPanel.BringToFront()

        ElseIf TreeView1.Nodes(2).IsSelected = True Then
        ElseIf TreeView1.Nodes(2).Nodes(0).IsSelected = True Then
            InstructionLabel.Text = "CONTACT INFOS."
            ContactInfo()
            ContactPanel.BringToFront()
        ElseIf TreeView1.Nodes(2).Nodes(1).IsSelected = True Then
            InstructionLabel.Text = "AUTHORITIES."
            Authorities()
            AuthorityPanel.BringToFront()
        ElseIf TreeView1.Nodes(3).IsSelected = True Then
            InstructionLabel.Text = "GALLERY."
            Gallery()
            GalleryWithButtonPanel.BringToFront()
        ElseIf TreeView1.Nodes(4).IsSelected = True Then
            InstructionLabel.Text = "FAQ."
            FAQ()
            FAQPanel.BringToFront()

        ElseIf TreeView1.Nodes(5).IsSelected = True Then
            InstructionLabel.Text = "ACCOUNT."
            Account()
            AccountPanel.BringToFront()
        ElseIf TreeView1.Nodes(6).IsSelected = True Then
            TreeView1.SelectedNode = TreeView1.Nodes(0)
            InstructionLabel.Text = "Log out?"
            LogOutPanel.BringToFront()
            Dim result As Integer = MessageBox.Show("Are you sure you want to log out? ", "Log Out?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub SFSTSPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SFSTSPictureBox.Click
        System.Diagnostics.Process.Start("http://www.google.com")
    End Sub

    Private Sub ContactNumberListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ContactNumberListView.ItemChecked

    End Sub

    Sub Account()
        AccountCheckBox.Checked = False
        AccountListView.Items.Clear()
        DeleteAccountButton.Enabled = False
        EditAccountButton.Enabled = False
        Dim n As Integer = 0
        SQlString = "Select * from tblaccount"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                n = n + 1

                AccountListView.Items.Add("")
                AccountListView.Items(AccountListView.Items.Count - 1).SubItems.Add(n.ToString)
                AccountListView.Items(AccountListView.Items.Count - 1).SubItems.Add(myreader("name").ToString)
                AccountListView.Items(AccountListView.Items.Count - 1).SubItems.Add(myreader("uname").ToString)
                AccountListView.Items(AccountListView.Items.Count - 1).SubItems.Add(myreader("pass").ToString)
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error Account.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Public AccountSelectedId As Integer
    Private Sub AccountListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountListView.SelectedIndexChanged
        For a = 0 To AccountListView.Items.Count - 1
            If AccountListView.Items.Item(a).Selected = True Then

            End If
        Next

        For a = 0 To AccountListView.Items.Count - 1
            If AccountListView.Items.Item(a).Selected = True Then
                AccountSelectedId = a
                EditAccountButton.Enabled = True
                Exit For
            Else
                EditAccountButton.Enabled = False
            End If
        Next
    End Sub

    Public Form2AddEdit As Integer
    Private Sub AddAccountButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAccountButton.Click
        Form2AddEdit = 1
        Form2.ShowDialog()
    End Sub

    Private Sub EditAccountButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditAccountButton.Click
        Form2AddEdit = 2
        Form2.ShowDialog()
    End Sub

    Private Sub DeleteAccountButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAccountButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected account(s)? ", "Delete Account(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = AccountListView.Items.Count - 1 To 0 Step -1
                If AccountListView.Items(i).Checked = True Then
                    Try
                        SQlString = "DELETE FROM tblaccount WHERE uname='" & AccountListView.Items(i).SubItems(3).Text & "'"
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
            Account()
            MessageBox.Show("Account(s) has been deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DeleteAccountButton.Enabled = False
        End If
    End Sub

    Private Sub AccountListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountListView.ItemChecked
        If AccountListView.CheckedItems.Count > 0 Then
            DeleteAccountButton.Enabled = True
        Else
            DeleteAccountButton.Enabled = False
        End If
    End Sub

    Private Sub GalleryDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GalleryDeleteButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected album(s)? ", "Delete Album(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = 0 To GalleryChk.Count - 1
                If GalleryChk(i).Checked = True Then
                    Try
                        SQlString = "DELETE FROM tblgallery WHERE albumname='" & GalleryChk(i).Tag.ToString & "'"
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
            Gallery()
            MessageBox.Show("Album(s) has been successfully deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DeleteAuthorityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteAuthorityButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected authority? ", "Delete Authority?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = 0 To AuthorityDataGridView.Rows.Count - 1
                If CBool(AuthorityDataGridView.Rows(i).Cells(0).Value) = True Then
                    Try
                        SQlString = "DELETE FROM tblauthority WHERE authorityid='" & AuthorityId.Item(i) & "'"
                        myconn.ConnectionString = CONNECTION_STRING
                        myconn.Open()
                        mycommand.Connection = myconn
                        mycommand.CommandText = SQlString
                        mycommand.ExecuteNonQuery()
                        myconn.Close()
                        Authorities()
                        MessageBox.Show("Authority has been successfully deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("No records found." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
            Next
        End If
    End Sub


    Private Sub ContactCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactCheckBox.CheckedChanged
        If ContactCheckBox.Checked = True Then
            For i = 0 To ContactNumberListView.Items.Count - 1
                ContactNumberListView.Items(i).Checked = True
            Next
        Else
            For i = 0 To ContactNumberListView.Items.Count - 1
                ContactNumberListView.Items(i).Checked = False
            Next
        End If
    End Sub

    Private Sub GalleryCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GalleryCheckBox.CheckedChanged
        If GalleryCheckBox.Checked = True Then
            For i = 0 To GalleryChk.Count - 1
                GalleryChk(i).Checked = True
            Next
        Else
            For i = 0 To GalleryChk.Count - 1
                GalleryChk(i).Checked = False
            Next
        End If
    End Sub

    Private Sub GalleryWithButtonPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GalleryWithButtonPanel.Paint

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AccountListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles AccountListView.ItemChecked

    End Sub
    Public ProgramID As New List(Of Integer)
    Sub Programs()
        ProgramID.Clear()
        ProgramCheckBox.Checked = False
        ProgramListView.Items.Clear()
        DeleteProgramButton.Enabled = False
        EditProgramButton.Enabled = False
        Dim n As Integer = 0
        SQlString = "Select * from tblprogram"
        Try
            myconn.ConnectionString = CONNECTION_STRING
            myconn.Open()
            mycommand.Connection = myconn
            mycommand.CommandText = SQlString
            myreader = mycommand.ExecuteReader
            Do While myreader.Read
                n = n + 1
                ProgramID.Add(CInt(myreader("programid").ToString))
                ProgramListView.Items.Add("")
                ProgramListView.Items(ProgramListView.Items.Count - 1).SubItems.Add(n.ToString)
                ProgramListView.Items(ProgramListView.Items.Count - 1).SubItems.Add(myreader("program").ToString)
            Loop
            myconn.Close()
        Catch ex As Exception
            MessageBox.Show("Error Program.Please try again." & ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myconn.Close()
        End Try
    End Sub

    Private Sub DeleteProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteProgramButton.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete selected program(s) offered? ", "Delete Program(s) Offered?", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            For i = ProgramListView.Items.Count - 1 To 0 Step -1
                If ProgramListView.Items(i).Checked = True Then
                    Try
                        SQlString = "DELETE FROM tblprogram WHERE programid='" & ProgramID.Item(i) & "'"
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

            Programs()
            MessageBox.Show("Program has been deleted.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DeleteProgramButton.Enabled = False
        End If
    End Sub
    Public ProgramSelectedId As Integer
    Private Sub ProgramListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramListView.SelectedIndexChanged
        For a = 0 To ProgramListView.Items.Count - 1
            If ProgramListView.Items.Item(a).Selected = True Then

            End If
        Next

        For a = 0 To ProgramListView.Items.Count - 1
            If ProgramListView.Items.Item(a).Selected = True Then
                ProgramSelectedId = a
                EditProgramButton.Enabled = True
                Exit For
            Else
                EditProgramButton.Enabled = False
            End If
        Next
    End Sub
    Private Sub ProgramListView_ItemChecked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramListView.ItemChecked
        If ProgramListView.CheckedItems.Count > 0 Then
            DeleteProgramButton.Enabled = True
        Else
            DeleteProgramButton.Enabled = False
        End If
    End Sub
     
    Public Form13AddEdit As Integer
    Private Sub AddProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddProgramButton.Click
        Form13AddEdit = 1
        Form13.ShowDialog()
    End Sub

    Private Sub EditProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditProgramButton.Click
        Form13AddEdit = 2
        Form13.ShowDialog()
    End Sub

    Private Sub ProgramCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgramCheckBox.CheckedChanged
        If ProgramCheckBox.Checked = True Then
            For i = 0 To ProgramListView.Items.Count - 1
                ProgramListView.Items(i).Checked = True
            Next
        Else
            For i = 0 To ProgramListView.Items.Count - 1
                ProgramListView.Items(i).Checked = False
            Next
        End If
    End Sub
End Class


