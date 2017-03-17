'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2017 Christopher Mackay

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

Public Class frmCreateExpense

    'NEW INSTANCES OF CLASSES
    Private UIManager As New clsUIManager
    Private FileCon As New clsLedgerDBConnector

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtMonthlyExpense.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonthlyExpense.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub cbCategory_TextChanged(sender As Object, e As EventArgs) Handles cbCategoriesPayees.TextChanged, cbCategoriesPayees.SelectedIndexChanged

        If Len(cbCategoriesPayees.Text) = 0 Or Len(txtMonthlyExpense.Text) = 0 Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub txtMonthlyExpense_TextChanged(sender As Object, e As EventArgs) Handles txtMonthlyExpense.TextChanged

        If Len(cbCategoriesPayees.Text) = 0 Or Len(txtMonthlyExpense.Text) = 0 Or txtMonthlyExpense.Text = "." Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub frmCreateExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        FileCon.caller_frmCreateExpense = Me

        If m_CategoriesPayees = "Categories" Then

            Try

                FileCon.Connect()
                FileCon.SQLread_FillcbCategoriesPayees("SELECT * FROM Categories")
                FileCon.Close()

            Catch ex As Exception

                Me.Dispose()
                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            Finally

                FileCon.Close()

            End Try

        Else

            Try

                FileCon.Connect()
                FileCon.SQLread_FillcbCategoriesPayees("SELECT * FROM Payees")
                FileCon.Close()

            Catch ex As Exception

                Me.Dispose()
                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            Finally

                FileCon.Close()

            End Try

        End If

    End Sub

End Class