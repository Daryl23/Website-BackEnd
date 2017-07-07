<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.UnderlineButton = New System.Windows.Forms.Button()
        Me.ItalicButton = New System.Windows.Forms.Button()
        Me.BoldButton = New System.Windows.Forms.Button()
        Me.PostAttachmentPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HomeDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.HomeCategoryComboBox = New System.Windows.Forms.ComboBox()
        Me.HomeAuthorTextBox = New System.Windows.Forms.TextBox()
        Me.HomeTitleTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.HomeContentRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.HomeCancelButton = New System.Windows.Forms.Button()
        Me.HomeSaveButton = New System.Windows.Forms.Button()
        Me.InstructionLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PostAttachmentPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TextBox2.Font = New System.Drawing.Font("Cambria", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TextBox2.Location = New System.Drawing.Point(658, 49)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(29, 50)
        Me.TextBox2.TabIndex = 51
        Me.TextBox2.Text = "+"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(635, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 44)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "INSERT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PHOTO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ClearButton
        '
        Me.ClearButton.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearButton.Location = New System.Drawing.Point(240, 133)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(49, 23)
        Me.ClearButton.TabIndex = 29
        Me.ClearButton.Text = "Clr"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'UnderlineButton
        '
        Me.UnderlineButton.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnderlineButton.Location = New System.Drawing.Point(185, 133)
        Me.UnderlineButton.Name = "UnderlineButton"
        Me.UnderlineButton.Size = New System.Drawing.Size(49, 23)
        Me.UnderlineButton.TabIndex = 28
        Me.UnderlineButton.Text = "U"
        Me.UnderlineButton.UseVisualStyleBackColor = True
        '
        'ItalicButton
        '
        Me.ItalicButton.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItalicButton.Location = New System.Drawing.Point(130, 133)
        Me.ItalicButton.Name = "ItalicButton"
        Me.ItalicButton.Size = New System.Drawing.Size(49, 23)
        Me.ItalicButton.TabIndex = 27
        Me.ItalicButton.Text = "I"
        Me.ItalicButton.UseVisualStyleBackColor = True
        '
        'BoldButton
        '
        Me.BoldButton.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoldButton.Location = New System.Drawing.Point(75, 133)
        Me.BoldButton.Name = "BoldButton"
        Me.BoldButton.Size = New System.Drawing.Size(49, 23)
        Me.BoldButton.TabIndex = 26
        Me.BoldButton.Text = "B"
        Me.BoldButton.UseVisualStyleBackColor = True
        '
        'PostAttachmentPictureBox
        '
        Me.PostAttachmentPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PostAttachmentPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PostAttachmentPictureBox.Location = New System.Drawing.Point(609, 46)
        Me.PostAttachmentPictureBox.Name = "PostAttachmentPictureBox"
        Me.PostAttachmentPictureBox.Size = New System.Drawing.Size(124, 110)
        Me.PostAttachmentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PostAttachmentPictureBox.TabIndex = 23
        Me.PostAttachmentPictureBox.TabStop = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(561, 54)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(42, 15)
        Me.Label40.TabIndex = 20
        Me.Label40.Text = "Photo:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(3, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 15)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "*Required Fields"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(56, 159)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 15)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(311, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 15)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(59, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 15)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Content:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(278, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Category:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Author:"
        '
        'HomeDateDateTimePicker
        '
        Me.HomeDateDateTimePicker.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeDateDateTimePicker.Location = New System.Drawing.Point(325, 46)
        Me.HomeDateDateTimePicker.Name = "HomeDateDateTimePicker"
        Me.HomeDateDateTimePicker.Size = New System.Drawing.Size(199, 23)
        Me.HomeDateDateTimePicker.TabIndex = 4
        '
        'HomeCategoryComboBox
        '
        Me.HomeCategoryComboBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeCategoryComboBox.FormattingEnabled = True
        Me.HomeCategoryComboBox.Items.AddRange(New Object() {"News", "Feature", "Reflection", "Column", "Editorial"})
        Me.HomeCategoryComboBox.Location = New System.Drawing.Point(73, 44)
        Me.HomeCategoryComboBox.Name = "HomeCategoryComboBox"
        Me.HomeCategoryComboBox.Size = New System.Drawing.Size(201, 23)
        Me.HomeCategoryComboBox.TabIndex = 3
        '
        'HomeAuthorTextBox
        '
        Me.HomeAuthorTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeAuthorTextBox.Location = New System.Drawing.Point(73, 104)
        Me.HomeAuthorTextBox.Name = "HomeAuthorTextBox"
        Me.HomeAuthorTextBox.Size = New System.Drawing.Size(201, 23)
        Me.HomeAuthorTextBox.TabIndex = 2
        '
        'HomeTitleTextBox
        '
        Me.HomeTitleTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeTitleTextBox.Location = New System.Drawing.Point(73, 75)
        Me.HomeTitleTextBox.Name = "HomeTitleTextBox"
        Me.HomeTitleTextBox.Size = New System.Drawing.Size(451, 23)
        Me.HomeTitleTextBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Title:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(59, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 15)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "*"
        '
        'HomeContentRichTextBox
        '
        Me.HomeContentRichTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeContentRichTextBox.Location = New System.Drawing.Point(73, 162)
        Me.HomeContentRichTextBox.Name = "HomeContentRichTextBox"
        Me.HomeContentRichTextBox.Size = New System.Drawing.Size(660, 172)
        Me.HomeContentRichTextBox.TabIndex = 25
        Me.HomeContentRichTextBox.Text = ""
        '
        'HomeCancelButton
        '
        Me.HomeCancelButton.FlatAppearance.BorderSize = 5
        Me.HomeCancelButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeCancelButton.Location = New System.Drawing.Point(658, 340)
        Me.HomeCancelButton.Name = "HomeCancelButton"
        Me.HomeCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.HomeCancelButton.TabIndex = 24
        Me.HomeCancelButton.Text = "&Cancel"
        Me.HomeCancelButton.UseVisualStyleBackColor = True
        '
        'HomeSaveButton
        '
        Me.HomeSaveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.HomeSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.HomeSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.HomeSaveButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeSaveButton.ForeColor = System.Drawing.Color.White
        Me.HomeSaveButton.Location = New System.Drawing.Point(577, 340)
        Me.HomeSaveButton.Name = "HomeSaveButton"
        Me.HomeSaveButton.Size = New System.Drawing.Size(75, 23)
        Me.HomeSaveButton.TabIndex = 7
        Me.HomeSaveButton.Text = "&Save"
        Me.HomeSaveButton.UseVisualStyleBackColor = False
        '
        'InstructionLabel
        '
        Me.InstructionLabel.BackColor = System.Drawing.SystemColors.Control
        Me.InstructionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.InstructionLabel.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.InstructionLabel.Location = New System.Drawing.Point(2, 1)
        Me.InstructionLabel.Name = "InstructionLabel"
        Me.InstructionLabel.Size = New System.Drawing.Size(745, 45)
        Me.InstructionLabel.TabIndex = 57
        Me.InstructionLabel.Text = "Maintains the website to the latest trends that is happening within your communit" & _
            "y."
        Me.InstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.HomeCancelButton)
        Me.Panel1.Controls.Add(Me.HomeContentRichTextBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.HomeSaveButton)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.HomeTitleTextBox)
        Me.Panel1.Controls.Add(Me.HomeAuthorTextBox)
        Me.Panel1.Controls.Add(Me.ClearButton)
        Me.Panel1.Controls.Add(Me.HomeCategoryComboBox)
        Me.Panel1.Controls.Add(Me.UnderlineButton)
        Me.Panel1.Controls.Add(Me.HomeDateDateTimePicker)
        Me.Panel1.Controls.Add(Me.ItalicButton)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.BoldButton)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.PostAttachmentPictureBox)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Location = New System.Drawing.Point(2, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 370)
        Me.Panel1.TabIndex = 52
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 421)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.InstructionLabel)
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Post"
        CType(Me.PostAttachmentPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HomeContentRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents HomeCancelButton As System.Windows.Forms.Button
    Friend WithEvents PostAttachmentPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents HomeSaveButton As System.Windows.Forms.Button
    Friend WithEvents HomeDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents HomeCategoryComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents HomeAuthorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HomeTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UnderlineButton As System.Windows.Forms.Button
    Friend WithEvents ItalicButton As System.Windows.Forms.Button
    Friend WithEvents BoldButton As System.Windows.Forms.Button
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents InstructionLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
