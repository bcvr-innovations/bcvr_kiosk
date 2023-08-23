Public Class Reminder

    Private Sub Reminder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_reminder.Text = passedID
        close_timer.Start()

    End Sub

    Private Sub close_timer_Tick(sender As Object, e As EventArgs) Handles close_timer.Tick
        close_timer.Stop()
        Me.Close()
    End Sub
End Class