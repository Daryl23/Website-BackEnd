<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
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
        Me.CancelEducationalAttainmentButton = New System.Windows.Forms.Button()
        Me.AddEducationalAttainmentButton = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.EducationalAttainmentTextBox = New System.Windows.Forms.TextBox()
        Me.SchoolTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CancelEducationalAttainmentButton
        '
        Me.CancelEducationalAttainmentButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelEducationalAttainmentButton.Location = New System.Drawing.Point(199, 153)
        Me.CancelEducationalAttainmentButton.Name = "CancelEducationalAttainmentButton"
        Me.CancelEducationalAttainmentButton.Size = New System.Drawing.Size(57, 23)
        Me.CancelEducationalAttainmentButton.TabIndex = 70
        Me.CancelEducationalAttainmentButton.Text = "&Cancel"
        Me.CancelEducationalAttainmentButton.UseVisualStyleBackColor = True
        '
        'AddEducationalAttainmentButton
        '
        Me.AddEducationalAttainmentButton.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddEducationalAttainmentButton.Location = New System.Drawing.Point(136, 153)
        Me.AddEducationalAttainmentButton.Name = "AddEducationalAttainmentButton"
        Me.AddEducationalAttainmentButton.Size = New System.Drawing.Size(57, 23)
        Me.AddEducationalAttainmentButton.TabIndex = 69
        Me.AddEducationalAttainmentButton.Text = "&Add"
        Me.AddEducationalAttainmentButton.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(7, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(139, 15)
        Me.Label24.TabIndex = 68
        Me.Label24.Text = "Educational Attainment:"
        '
        'EducationalAttainmentTextBox
        '
        Me.EducationalAttainmentTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EducationalAttainmentTextBox.Location = New System.Drawing.Point(10, 33)
        Me.EducationalAttainmentTextBox.Name = "EducationalAttainmentTextBox"
        Me.EducationalAttainmentTextBox.Size = New System.Drawing.Size(246, 23)
        Me.EducationalAttainmentTextBox.TabIndex = 67
        '
        'SchoolTextBox
        '
        Me.SchoolTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SchoolTextBox.Location = New System.Drawing.Point(9, 80)
        Me.SchoolTextBox.Name = "SchoolTextBox"
        Me.SchoolTextBox.Size = New System.Drawing.Size(246, 23)
        Me.SchoolTextBox.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "School:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Address:"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddressTextBox.Location = New System.Drawing.Point(9, 124)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(246, 23)
        Me.AddressTextBox.TabIndex = 74
        '
        'Form12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 182)
        Me.Controls.Add(Me.AddressTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SchoolTextBox)
        Me.Controls.Add(Me.CancelEducationalAttainmentButton)
        Me.Controls.Add(Me.AddEducationalAttainmentButton)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.EducationalAttainmentTextBox)
        Me.MaximizeBox = False
        Me.Name = "Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Educational Attainment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CancelEducationalAttainmentButton As System.Windows.Forms.Button
    Friend WithEvents AddEducationalAttainmentButton As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents EducationalAttainmentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SchoolTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
End Class
