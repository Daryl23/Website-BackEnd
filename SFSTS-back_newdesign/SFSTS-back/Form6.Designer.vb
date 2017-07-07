<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Me.FAQCancelButton = New System.Windows.Forms.Button()
        Me.FAQSaveButton = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.FAQAnswerTextBox = New System.Windows.Forms.TextBox()
        Me.FAQQuestionTextBox = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.InstructionLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FAQCancelButton
        '
        Me.FAQCancelButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FAQCancelButton.Location = New System.Drawing.Point(289, 181)
        Me.FAQCancelButton.Name = "FAQCancelButton"
        Me.FAQCancelButton.Size = New System.Drawing.Size(75, 25)
        Me.FAQCancelButton.TabIndex = 26
        Me.FAQCancelButton.Text = "&Cancel"
        Me.FAQCancelButton.UseVisualStyleBackColor = True
        '
        'FAQSaveButton
        '
        Me.FAQSaveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FAQSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FAQSaveButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FAQSaveButton.ForeColor = System.Drawing.Color.White
        Me.FAQSaveButton.Location = New System.Drawing.Point(208, 181)
        Me.FAQSaveButton.Name = "FAQSaveButton"
        Me.FAQSaveButton.Size = New System.Drawing.Size(75, 25)
        Me.FAQSaveButton.TabIndex = 24
        Me.FAQSaveButton.Text = "&Save"
        Me.FAQSaveButton.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(11, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 15)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Answer:"
        '
        'FAQAnswerTextBox
        '
        Me.FAQAnswerTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FAQAnswerTextBox.Location = New System.Drawing.Point(70, 101)
        Me.FAQAnswerTextBox.Multiline = True
        Me.FAQAnswerTextBox.Name = "FAQAnswerTextBox"
        Me.FAQAnswerTextBox.Size = New System.Drawing.Size(294, 72)
        Me.FAQAnswerTextBox.TabIndex = 20
        '
        'FAQQuestionTextBox
        '
        Me.FAQQuestionTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FAQQuestionTextBox.Location = New System.Drawing.Point(70, 23)
        Me.FAQQuestionTextBox.Multiline = True
        Me.FAQQuestionTextBox.Name = "FAQQuestionTextBox"
        Me.FAQQuestionTextBox.Size = New System.Drawing.Size(294, 72)
        Me.FAQQuestionTextBox.TabIndex = 19
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(3, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 15)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Question:"
        '
        'InstructionLabel
        '
        Me.InstructionLabel.BackColor = System.Drawing.SystemColors.Control
        Me.InstructionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.InstructionLabel.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.InstructionLabel.Location = New System.Drawing.Point(0, 1)
        Me.InstructionLabel.Name = "InstructionLabel"
        Me.InstructionLabel.Size = New System.Drawing.Size(379, 45)
        Me.InstructionLabel.TabIndex = 57
        Me.InstructionLabel.Text = "Maintains the website to the latest trends that is happening within your communit" & _
            "y."
        Me.InstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.FAQCancelButton)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.FAQSaveButton)
        Me.Panel1.Controls.Add(Me.FAQQuestionTextBox)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.FAQAnswerTextBox)
        Me.Panel1.Location = New System.Drawing.Point(0, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 214)
        Me.Panel1.TabIndex = 58
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 263)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.InstructionLabel)
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAQ"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FAQCancelButton As System.Windows.Forms.Button
    Friend WithEvents FAQSaveButton As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents FAQAnswerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FAQQuestionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents InstructionLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
