Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeMyTimer()
    End Sub

    Private time As New Timer()
    ' Call this method from the constructor of the form. 
    Private Sub InitializeMyTimer()
        ' Set the interval for the timer.
        time.Interval = 100
        ' Connect the Tick event of the timer to its event handler. 
        AddHandler time.Tick, AddressOf IncreaseProgressBar
        ' Start the timer.
        time.Start()
    End Sub

    Private Sub IncreaseProgressBar(ByVal sender As Object, ByVal e As EventArgs)
        ' Increment the value of the ProgressBar a value of one each time.
        ProgressBar1.Increment(1000)
        ' Display the textual value of the ProgressBar in the StatusBar control's first panel.

        ' Determine if we have completed by comparing the value of the Value property to the Maximum value. 
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ' Stop the timer.
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class