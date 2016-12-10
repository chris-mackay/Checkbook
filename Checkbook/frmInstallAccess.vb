'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016 Christopher Mackay

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
Imports System.Net

Public Class frmInstallAccess

    Private UIManager As New clsUIManager

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub frmInstallAccess_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.Closed

        MainForm.Close()

    End Sub

    Private Sub btnDownloadAccess_Click(sender As Object, e As EventArgs) Handles btnDownloadAccess.Click

        DownloadAccessRuntime()

    End Sub

    Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Me.Cursor = Cursors.WaitCursor

        If MainModule.AccessIsInstalled() = True Then

            Me.Cursor = Cursors.Default

            Me.Hide()
            MainForm.Show()
            Exit Sub

        Else

            CheckbookMsg.ShowMessage("Install Access Runtime", MsgButtons.OK, "Microsoft Office Access Runtime (English) 2007 must be installed before continuing. Your transaction data is stored in Microsoft databases.", Exclamation)

            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub DownloadAccessRuntime()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim webClient As New System.Net.WebClient

        Dim strAccessRuntimeFileToDownload As String = String.Empty
        Dim strDirectLinkReplacementText As String = String.Empty

        strDirectLinkReplacementText = "dl.dropboxusercontent.com"

        strAccessRuntimeFileToDownload = "https://www.dropbox.com/s/tv9412p2f8lxspv/AccessRuntime.exe?dl=1"

        strAccessRuntimeFileToDownload = strAccessRuntimeFileToDownload.Replace("www.dropbox.com", strDirectLinkReplacementText)

        Dim dlgFolderDialog As New FolderBrowserDialog
        dlgFolderDialog.ShowNewFolderButton = True
        dlgFolderDialog.Description = "Select a location to download the Microsoft Office Access Runtime (English) 2007 installer."

        Dim strDownloadPath As String = String.Empty

        If dlgFolderDialog.ShowDialog = DialogResult.OK Then

            btnDownloadAccess.Enabled = False
            btnFinish.Enabled = False

            Dim strDownloadedFile As String = String.Empty
            Dim strFileName As String = String.Empty

            strFileName = "AccessRuntime.exe"

            strDownloadPath = dlgFolderDialog.SelectedPath

            strDownloadedFile = strDownloadPath & "\" & strFileName

            If Not System.IO.File.Exists(strDownloadedFile) Then

                DownloadAccessProgressBar.Value = 0
                DownloadAccessProgressBar.Visible = True

                AddHandler webClient.DownloadProgressChanged, AddressOf client_ProgressChanged
                AddHandler webClient.DownloadFileCompleted, AddressOf client_DownloadCompleted

                webClient.DownloadFileAsync(New Uri(strAccessRuntimeFileToDownload), strDownloadedFile)

            Else

                CheckbookMsg.ShowMessage("'" & strFileName & "' already exists.", MsgButtons.OK, "You already have a copy of this file saved in this location.", Media.SystemSounds.Exclamation)

            End If

        End If

    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        Dim dblBytesIn As Double = Double.Parse(e.BytesReceived.ToString())

        Dim dblTotalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())

        Dim dblPercentage As Double = dblBytesIn / dblTotalBytes * 100

        DownloadAccessProgressBar.Value = Int32.Parse(Math.Truncate(dblPercentage).ToString())

    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        CheckbookMsg.ShowMessage("Downloading has completed. Before Checkbook can open you must run 'AccessRuntime.exe' to install Microsoft Office Access Runtime (English) 2007.", MsgButtons.OK, "", Media.SystemSounds.Exclamation)

        DownloadAccessProgressBar.Value = 0
        DownloadAccessProgressBar.Visible = False
        btnDownloadAccess.Enabled = True
        btnFinish.Enabled = True

    End Sub

End Class