<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
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
        Me.components = New System.ComponentModel.Container()
        Me.GalleryPanel = New System.Windows.Forms.Panel()
        Me.InstructionLabel = New System.Windows.Forms.Label()
        Me.AlbumTitlePanel = New System.Windows.Forms.Panel()
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AlbumNameTextBox = New System.Windows.Forms.TextBox()
        Me.AddAlbumButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.DeleteAlbumButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AlbumTitlePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'GalleryPanel
        '
        Me.GalleryPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GalleryPanel.AutoScroll = True
        Me.GalleryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GalleryPanel.Location = New System.Drawing.Point(2, 162)
        Me.GalleryPanel.Name = "GalleryPanel"
        Me.GalleryPanel.Size = New System.Drawing.Size(485, 508)
        Me.GalleryPanel.TabIndex = 0
        '
        'InstructionLabel
        '
        Me.InstructionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstructionLabel.BackColor = System.Drawing.SystemColors.Control
        Me.InstructionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.InstructionLabel.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.InstructionLabel.Location = New System.Drawing.Point(2, 2)
        Me.InstructionLabel.Name = "InstructionLabel"
        Me.InstructionLabel.Size = New System.Drawing.Size(485, 45)
        Me.InstructionLabel.TabIndex = 60
        Me.InstructionLabel.Text = "Maintains the website to the latest trends that is happening within your communit" & _
            "y."
        Me.InstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AlbumTitlePanel
        '
        Me.AlbumTitlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AlbumTitlePanel.Controls.Add(Me.DateDateTimePicker)
        Me.AlbumTitlePanel.Controls.Add(Me.Label7)
        Me.AlbumTitlePanel.Controls.Add(Me.Label1)
        Me.AlbumTitlePanel.Controls.Add(Me.AlbumNameTextBox)
        Me.AlbumTitlePanel.Location = New System.Drawing.Point(2, 50)
        Me.AlbumTitlePanel.Name = "AlbumTitlePanel"
        Me.AlbumTitlePanel.Size = New System.Drawing.Size(485, 77)
        Me.AlbumTitlePanel.TabIndex = 62
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(91, 40)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(202, 23)
        Me.DateDateTimePicker.TabIndex = 66
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(50, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 15)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Date:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Album Name:"
        '
        'AlbumNameTextBox
        '
        Me.AlbumNameTextBox.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlbumNameTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AlbumNameTextBox.Location = New System.Drawing.Point(91, 12)
        Me.AlbumNameTextBox.Name = "AlbumNameTextBox"
        Me.AlbumNameTextBox.Size = New System.Drawing.Size(381, 22)
        Me.AlbumNameTextBox.TabIndex = 0
        '
        'AddAlbumButton
        '
        Me.AddAlbumButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAlbumButton.Location = New System.Drawing.Point(85, 133)
        Me.AddAlbumButton.Name = "AddAlbumButton"
        Me.AddAlbumButton.Size = New System.Drawing.Size(74, 23)
        Me.AddAlbumButton.TabIndex = 64
        Me.AddAlbumButton.Text = "&Save"
        Me.AddAlbumButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(165, 133)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(75, 23)
        Me.ExitButton.TabIndex = 65
        Me.ExitButton.Text = "&Cancel"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'DeleteAlbumButton
        '
        Me.DeleteAlbumButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteAlbumButton.Location = New System.Drawing.Point(4, 133)
        Me.DeleteAlbumButton.Name = "DeleteAlbumButton"
        Me.DeleteAlbumButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteAlbumButton.TabIndex = 63
        Me.DeleteAlbumButton.Text = "&Delete"
        Me.DeleteAlbumButton.UseVisualStyleBackColor = True
        '
        'Form9
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 671)
        Me.Controls.Add(Me.AddAlbumButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.DeleteAlbumButton)
        Me.Controls.Add(Me.AlbumTitlePanel)
        Me.Controls.Add(Me.InstructionLabel)
        Me.Controls.Add(Me.GalleryPanel)
        Me.Name = "Form9"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gallery"
        Me.AlbumTitlePanel.ResumeLayout(False)
        Me.AlbumTitlePanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GalleryPanel As System.Windows.Forms.Panel
    Friend WithEvents InstructionLabel As System.Windows.Forms.Label
    Friend WithEvents AlbumTitlePanel As System.Windows.Forms.Panel
    Friend WithEvents AddAlbumButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents DeleteAlbumButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AlbumNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
