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

Public Class frmEditPayment

    'NEW INSTANCES OF CLASSES
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtNewValue.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewValue.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub txtNewValue_TextChanged(sender As Object, e As EventArgs) Handles txtNewValue.TextChanged

        If Len(txtNewValue.Text) = 0 Or txtNewValue.Text = "." Then

            btnUpdate.Enabled = False

        Else

            btnUpdate.Enabled = True

        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If CheckbookMsg.ShowMessage("Are you sure you want to make the selected payment(s) " & FormatCurrency(txtNewValue.Text) & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

            Try

                Dim strNewValue As String = txtNewValue.Text
                Me.Dispose()
                UIManager.SetCursor(MainForm, Cursors.WaitCursor)
                DataCon.UpdateSelectedLedgerData(clsLedgerDataManager.enumTransactionProperties.Payment, strNewValue)
                UIManager.SetCursor(MainForm, Cursors.Default)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Edit Error", MsgButtons.OK, "An error occurred while attempting to edit the selected payments(s)" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                FileCon.Close()
                UIManager.SetCursor(Me, Cursors.Default)

            End Try

        End If

    End Sub

    Private Sub frmEditPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileCon.caller_frmEditPayment = Me
        DataCon.caller_frmEditPayment = Me

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

End Class