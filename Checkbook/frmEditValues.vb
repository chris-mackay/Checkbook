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

Public Class frmEditValues

    Private UIManager As New clsUIManager

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtNewExpenseValue.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewExpenseValue.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtNewExpenseValue.TextChanged

        If Len(txtNewExpenseValue.Text) = 0 Or txtNewExpenseValue.Text = "." Then

            btnUpdate.Enabled = False

        Else

            btnUpdate.Enabled = True

        End If

    End Sub

End Class