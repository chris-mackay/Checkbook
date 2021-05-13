'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2021 Christopher Mackay

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

Public Class frmImportPayees

    Private FileCon As New clsLedgerDBConnector
    Private File As New clsLedgerDBFileManager

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

    Private Sub frmImportPayees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Me.Text = "Import Payees into " & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)

        FileCon.caller_frmImportPayees = Me

        File.LoadMyCheckbookLedgers_IntoComboBox(cbMyLedgers)

        Try

            FileCon.Connect()
            FileCon.SQLread_Fill_lstMyPayees("SELECT * FROM Payees")
            FileCon.Close()

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

    End Sub

    Private Sub cbMyLedgers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMyLedgers.SelectedIndexChanged

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Me.lstImportPayees.Items.Clear()

        Dim strSelectedFile As String = String.Empty
        strSelectedFile = AppendLedgerPath(Me.cbMyLedgers.SelectedItem.ToString())

        Try

            FileCon.ConnectMenu(strSelectedFile)
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Me.Dispose()
            Exit Sub

        End Try

        Try

            FileCon.SQL_Connect_read_Fill_ImportlstPayees(strSelectedFile, "SELECT * FROM Payees")

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            lstImportPayees.Items.Clear()
            Exit Sub

        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If lstImportPayees.SelectedIndex = -1 Then

            Dim strMessage As String = "Select payees from the list on the left and click 'Add'." & vbNewLine

            Dim strAdvice As String = "Make sure you have selected a ledger from the dropdown list" & vbNewLine &
                                      "that contains the payees you want to import."

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            For Each strPayee As String In lstImportPayees.SelectedItems

                If Not lstMyPayees.Items.Contains(strPayee) Then

                    lstMyPayees.Items.Add(strPayee)

                End If

            Next

        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If CheckbookMsg.ShowMessage("Are you sure you want to import the new payees into your ledger?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

            Try

                FileCon.Connect()
                FileCon.SQLdelete("DELETE * FROM Payees")

                For Each payee As String In lstMyPayees.Items

                    FileCon.SQLinsert("INSERT INTO Payees (Payee) VALUES ('" & payee & "')")

                Next

                FileCon.Close()
                Me.Dispose()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Import Payees Error", MsgButtons.OK, "An error occurred while importing payees." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                FileCon.Close()

            Finally

                FileCon.Close()

            End Try

        End If

    End Sub

    Private Sub btnAdd_MouseHover(sender As Object, e As EventArgs) Handles btnAdd.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnAdd, "Add")

    End Sub

    Private Sub btnSelectAll_MouseHover(sender As Object, e As EventArgs) Handles btnSelectAll.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnSelectAll, "Select All")

    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If cbMyLedgers.SelectedIndex = -1 Then

            CheckbookMsg.ShowMessage("Select a ledger from the dropdown list to load payees", MsgButtons.OK, "", Exclamation)

        Else

            For i As Integer = 0 To Me.lstImportPayees.Items.Count - 1

                Me.lstImportPayees.SetSelected(i, True)

            Next

        End If

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/import_categories_payees.html"
        Process.Start(strWebAddress)

    End Sub

End Class