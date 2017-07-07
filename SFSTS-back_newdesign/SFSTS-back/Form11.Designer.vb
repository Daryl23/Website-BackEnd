<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
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
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CourseTaughtTextBox = New System.Windows.Forms.TextBox()
        Me.AddCourseTaughtButton = New System.Windows.Forms.Button()
        Me.CancelCourseTaughtButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 17)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(88, 15)
        Me.Label24.TabIndex = 32
        Me.Label24.Text = "Course Taught:"
        '
        'CourseTaughtTextBox
        '
        Me.CourseTaughtTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CourseTaughtTextBox.Location = New System.Drawing.Point(11, 35)
        Me.CourseTaughtTextBox.Name = "CourseTaughtTextBox"
        Me.CourseTaughtTextBox.Size = New System.Drawing.Size(201, 23)
        Me.CourseTaughtTextBox.TabIndex = 31
        '
        'AddCourseTaughtButton
        '
        Me.AddCourseTaughtButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddCourseTaughtButton.Location = New System.Drawing.Point(92, 64)
        Me.AddCourseTaughtButton.Name = "AddCourseTaughtButton"
        Me.AddCourseTaughtButton.Size = New System.Drawing.Size(57, 23)
        Me.AddCourseTaughtButton.TabIndex = 65
        Me.AddCourseTaughtButton.Text = "&Add"
        Me.AddCourseTaughtButton.UseVisualStyleBackColor = True
        '
        'CancelCourseTaughtButton
        '
        Me.CancelCourseTaughtButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelCourseTaughtButton.Location = New System.Drawing.Point(155, 64)
        Me.CancelCourseTaughtButton.Name = "CancelCourseTaughtButton"
        Me.CancelCourseTaughtButton.Size = New System.Drawing.Size(57, 23)
        Me.CancelCourseTaughtButton.TabIndex = 66
        Me.CancelCourseTaughtButton.Text = "&Cancel"
        Me.CancelCourseTaughtButton.UseVisualStyleBackColor = True
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(220, 92)
        Me.Controls.Add(Me.CancelCourseTaughtButton)
        Me.Controls.Add(Me.AddCourseTaughtButton)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.CourseTaughtTextBox)
        Me.MaximizeBox = False
        Me.Name = "Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Course Taught"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CourseTaughtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddCourseTaughtButton As System.Windows.Forms.Button
    Friend WithEvents CancelCourseTaughtButton As System.Windows.Forms.Button
End Class
