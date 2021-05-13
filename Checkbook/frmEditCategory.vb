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

Public Class frmEditCategory

    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager

    Private Sub frmMultiEditCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        FileCon.caller_frmEditCategory = Me
        DataCon.caller_frmEditCategory = Me

        Try

            FileCon.Connect()
            FileCon.SQLread_FillcbEditCategories("SELECT * FROM Categories")
            FileCon.Close()

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If cbCategory.SelectedIndex = -1 Then

            CheckbookMsg.ShowMessage("Please select a category from the dropdown list", MsgButtons.OK, "", Exclamation)
            Exit Sub

        ElseIf CheckbookMsg.ShowMessage("Are you sure you want to update the selected item(s) with '" & cbCategory.Text & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

            Try

                Dim strCategory As String = String.Empty
                strCategory = cbCategory.SelectedItem.ToString
                Me.Dispose()
                UIManager.SetCursor(MainForm, Cursors.WaitCursor)
                DataCon.UpdateSelectedLedgerData(clsLedgerDataManager.enumTransactionProperties.Category, strCategory)
                UIManager.SetCursor(MainForm, Cursors.Default)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Edit Category Error", MsgButtons.OK, "An error occurred while editing categories" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            End Try

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        If cbCategory.SelectedIndex >= 0 Then

            btnOK.Enabled = True

        Else

            btnOK.Enabled = False

        End If

    End Sub

End Class