'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2018 Christopher Mackay

'    This program Is free software: you can redistribute it And/Or modify
'    it under the terms Of the GNU General Public License As published by
'    the Free Software Foundation, either version 3 Of the License, Or
'    (at your option) any later version.

'    This program Is distributed In the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty Of
'    MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE. See the
'    GNU General Public License For more details.

'    You should have received a copy Of the GNU General Public License
'    along with this program. If Not, see <http: //www.gnu.org/licenses/>.

Public Class frmCreateNewScenario

    Private Sub rbModelCurrentYearKeepValues_CheckedChanged(sender As Object, e As EventArgs) Handles rbModelCurrentYearKeepValues.CheckedChanged, rbModelCurrentYearFromScratch.CheckedChanged, rbModelNextYearAndOverallDetails.CheckedChanged, rbModelNextYearFromScratch.CheckedChanged

        If rbModelCurrentYearKeepValues.Checked = False And rbModelCurrentYearFromScratch.Checked = False And rbModelNextYearAndOverallDetails.Checked = False And rbModelNextYearFromScratch.Checked = False Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/create_new_scenario.html"
        Process.Start(strWebAddress)

    End Sub

End Class