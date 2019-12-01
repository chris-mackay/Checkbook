'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2019 Christopher Mackay

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

Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds
Public Class frmAbout

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub pb_Click(sender As Object, e As EventArgs) Handles pbCheckbookApp.Click

        Dim webAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/"
        Process.Start(webAddress)

    End Sub

    Private Sub lblIcons_Click(sender As Object, e As EventArgs) Handles lblIcons.Click

        Dim strWebAddress As String = "http://www.fatcow.com/free-icons"
        Process.Start(strWebAddress)

    End Sub

    Private Sub lblCCLisense_Click(sender As Object, e As EventArgs) Handles lblCCLisense.Click

        Dim strWebAddress As String = "http://creativecommons.org/licenses/by/3.0/us/"
        Process.Start(strWebAddress)

    End Sub

    Private Sub lblLicenseAgreement_Click(sender As Object, e As EventArgs) Handles lblLicenseAgreement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strLicenseFilePath As String = String.Empty

        Dim viewLicenseProcess As New Process

        strLicenseFilePath = Application.StartupPath() & "\LICENSE.txt"

        Dim processInfo As New ProcessStartInfo(strLicenseFilePath)

        viewLicenseProcess.StartInfo = processInfo

        If IO.File.Exists(strLicenseFilePath) Then

            viewLicenseProcess.Start()

        Else

            CheckbookMsg.ShowMessage("License File Missing", MsgButtons.OK, "The license agreement file has been moved or deleted. Please notify the developer at the email address below." & vbNewLine & vbNewLine & "chkbookapp@gmail.com", Exclamation)

        End If

    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblVersion.Text = "Version " & CheckbookProductInfo.Version

    End Sub

    Private Sub lblChangelog_Click(sender As Object, e As EventArgs) Handles lblChangelog.Click

        Dim webAddress As String = CheckbookProductInfo.Changelog
        Process.Start(webAddress)

    End Sub

End Class