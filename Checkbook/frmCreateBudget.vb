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

Public Class frmCreateBudget

    'NEW INSTANCES OF CLASSES
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager

    Public caller_frmBudgets As frmBudgets

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtBudget.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBudget.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        If Not cbCategory.SelectedIndex >= 0 Or Len(txtBudget.Text) = 0 Or txtBudget.Text = "." Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub txtMonthlyExpense_TextChanged(sender As Object, e As EventArgs) Handles txtBudget.TextChanged

        If Not cbCategory.SelectedIndex >= 0 Or Len(txtBudget.Text) = 0 Or txtBudget.Text = "." Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub frmCreateBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        FileCon.caller_frmCreateBudget = Me

        Try

            FileCon.Connect()
            FileCon.SQLread_FillcbBudgetCategories("SELECT * FROM Categories")
            FileCon.Close()

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        If caller_frmBudgets.dgvBudgets.SelectedRows.Count = 0 Then

            Me.Text = "Create Budget"
            Me.btnCreate.Text = "Create"

            Me.cbCategory.SelectedIndex = -1
            Me.txtBudget.Text = ""

        Else

            Dim strCategory As String = String.Empty
            Dim strBudget As String = String.Empty

            Me.Text = "Edit Budget"
            Me.btnCreate.Text = "Update"

            For Each row As DataGridViewRow In caller_frmBudgets.dgvBudgets.SelectedRows

                strCategory = row.Cells.Item("category").Value.ToString
                strBudget = row.Cells.Item("budget").Value.ToString

                Me.cbCategory.SelectedIndex = cbCategory.FindStringExact(strCategory)
                Me.txtBudget.Text = strBudget

            Next

        End If

    End Sub

End Class