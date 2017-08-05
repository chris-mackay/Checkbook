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

Public Class frmNewCheckbookLedger

    'NEW INSTANCES OF CLASSES
    Private File As New clsLedgerDBFileManager
    Private UIManager As New clsUIManager

    Private Sub frmNewLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNewLedger.Text = ""
        txtStartBalance.Text = ""

        txtNewLedger.Focus()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtStartBalance.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStartBalance.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub txtNewLedger_TextChanged(sender As Object, e As EventArgs) Handles txtNewLedger.TextChanged

        If Len(txtNewLedger.Text) = 0 Or Len(txtStartBalance.Text) = 0 Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub txtStartBalance_TextChanged(sender As Object, e As EventArgs) Handles txtStartBalance.TextChanged

        If Len(txtNewLedger.Text) = 0 Or Len(txtStartBalance.Text) = 0 Or txtStartBalance.Text = "." Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

End Class