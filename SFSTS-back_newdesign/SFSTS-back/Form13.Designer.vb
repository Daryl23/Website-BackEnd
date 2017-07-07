<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form13
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AccountCancelButton = New System.Windows.Forms.Button()
        Me.AccountSaveButton = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ProgramTextBox = New System.Windows.Forms.TextBox()
        Me.InstructionLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.AccountCancelButton)
        Me.Panel1.Controls.Add(Me.AccountSaveButton)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.ProgramTextBox)
        Me.Panel1.Location = New System.Drawing.Point(2, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(563, 90)
        Me.Panel1.TabIndex = 62
        '
        'AccountCancelButton
        '
        Me.AccountCancelButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccountCancelButton.Location = New System.Drawing.Point(483, 61)
        Me.AccountCancelButton.Name = "AccountCancelButton"
        Me.AccountCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.AccountCancelButton.TabIndex = 33
        Me.AccountCancelButton.Text = "&Cancel"
        Me.AccountCancelButton.UseVisualStyleBackColor = True
        '
        'AccountSaveButton
        '
        Me.AccountSaveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AccountSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AccountSaveButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccountSaveButton.ForeColor = System.Drawing.Color.White
        Me.AccountSaveButton.Location = New System.Drawing.Point(402, 60)
        Me.AccountSaveButton.Name = "AccountSaveButton"
        Me.AccountSaveButton.Size = New System.Drawing.Size(75, 24)
        Me.AccountSaveButton.TabIndex = 20
        Me.AccountSaveButton.Text = "&Save"
        Me.AccountSaveButton.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(9, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 15)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Program Offered:"
        '
        'ProgramTextBox
        '
        Me.ProgramTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgramTextBox.Location = New System.Drawing.Point(116, 8)
        Me.ProgramTextBox.MaxLength = 16
        Me.ProgramTextBox.Multiline = True
        Me.ProgramTextBox.Name = "ProgramTextBox"
        Me.ProgramTextBox.Size = New System.Drawing.Size(442, 47)
        Me.ProgramTextBox.TabIndex = 18
        '
        'InstructionLabel
        '
        Me.InstructionLabel.BackColor = System.Drawing.SystemColors.Control
        Me.InstructionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.InstructionLabel.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.InstructionLabel.Location = New System.Drawing.Point(2, 2)
        Me.InstructionLabel.Name = "InstructionLabel"
        Me.InstructionLabel.Size = New System.Drawing.Size(563, 45)
        Me.InstructionLabel.TabIndex = 61
        Me.InstructionLabel.Text = "Maintains the website to the latest trends that is happening within your communit" & _
            "y."
        Me.InstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 141)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.InstructionLabel)
        Me.Name = "Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programs Offered"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents AccountCancelButton As System.Windows.Forms.Button
    Friend WithEvents AccountSaveButton As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ProgramTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InstructionLabel As System.Windows.Forms.Label
End Class
