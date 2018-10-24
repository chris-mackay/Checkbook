Public Class frmCopyScenarioYear

    Private Sub Disable_Enable_OK_Button(sender As Object, e As EventArgs) Handles cbYears.SelectedIndexChanged, cbScenario.SelectedIndexChanged

        If cbScenario.SelectedIndex >= 0 And cbYears.SelectedIndex >= 0 Then

            btnOK.Enabled = True

        Else

            btnOK.Enabled = False

        End If

    End Sub

End Class