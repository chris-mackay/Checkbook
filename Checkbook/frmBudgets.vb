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

Public Class frmBudgets

    Private Sub AddColumns()

        Dim colCategory As New DataGridViewTextBoxColumn
        Dim colBudget As New DataGridViewTextBoxColumn
        Dim colCurrentAmount As New DataGridViewTextBoxColumn
        Dim colBudgetStatus As New DataGridViewTextBoxColumn

        colCategory.CellTemplate = New DataGridViewTextBoxCell
        colCategory.Name = "category"
        colCategory.HeaderText = "Category"
        colCategory.ReadOnly = True

        colBudget.CellTemplate = New DataGridViewTextBoxCell
        colBudget.Name = "budget"
        colBudget.HeaderText = "Monthly Budget"
        colBudget.ReadOnly = True

        colCurrentAmount.CellTemplate = New DataGridViewTextBoxCell
        colCurrentAmount.Name = "currentAmount"
        colCurrentAmount.HeaderText = "Current Month"
        colCurrentAmount.ReadOnly = True

        colBudgetStatus.CellTemplate = New DataGridViewTextBoxCell
        colBudgetStatus.Name = "budgetStatus"
        colBudgetStatus.HeaderText = "Remaining"
        colBudgetStatus.ReadOnly = True

        dgvBudgets.Columns.Add(colCategory)
        dgvBudgets.Columns.Add(colBudget)
        dgvBudgets.Columns.Add(colCurrentAmount)
        dgvBudgets.Columns.Add(colBudgetStatus)

    End Sub

    Private Sub AddRow(ByVal _category As String, ByVal _budget As String)

        dgvBudgets.Rows.Add(_category, _budget)
        dgvBudgets.ClearSelection()

    End Sub

    Private Sub LoadSavedBudgets()

        Dim strEntry As String = String.Empty

        Dim strBudgets_DIRECTORY As String = String.Empty
        strBudgets_DIRECTORY = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\"

        Dim strFileName As String = String.Empty
        strFileName = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & ".bgt"

        Dim file As String = String.Empty
        file = strBudgets_DIRECTORY & strFileName

        dgvBudgets.Rows.Clear()

        If My.Computer.FileSystem.FileExists(file) Then

            Dim objReader As New System.IO.StreamReader(file)

            Do While objReader.Peek() <> -1

                strEntry = objReader.ReadLine()

                Dim chrSeparator As Char() = New Char() {","c}
                Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                Dim strCategory As String = arrValues(0)
                Dim strBudget As String = arrValues(1)
                strBudget = FormatCurrency(strBudget)

                dgvBudgets.Rows.Add(strCategory, strBudget)

            Loop

            objReader.Close()

            UpdateCalculationsAndFormat()
            dgvBudgets.ClearSelection()

        End If

    End Sub

    Private Sub UpdateCalculationsAndFormat()

        For Each dgvRow As DataGridViewRow In dgvBudgets.Rows

            Dim strCategory As String = dgvRow.Cells.Item("category").Value.ToString
            Dim strBudget As String = dgvRow.Cells.Item("budget").Value.ToString
            strBudget = strBudget.Replace("$", "")
            strBudget = strBudget.Replace(",", "")

            strBudget = CDbl(strBudget)

            Dim strCurrentTotal As String = SumMonthly(strCategory)

            If strCurrentTotal = "" Then
                strCurrentTotal = 0
            Else
                strCurrentTotal = CDbl(strCurrentTotal)
            End If

            Dim strStatus As String = strBudget - strCurrentTotal

            strBudget = FormatCurrency(strBudget)
            strCurrentTotal = FormatCurrency(strCurrentTotal)
            strStatus = FormatCurrency(strStatus)

            dgvRow.Cells.Item("budget").Value = strBudget
            dgvRow.Cells.Item("currentAmount").Value = strCurrentTotal
            dgvRow.Cells.Item("budgetStatus").Value = strStatus

            If strStatus < 0 Then

                dgvRow.DefaultCellStyle.BackColor = m_myRed

            Else

                dgvRow.DefaultCellStyle.BackColor = Nothing

            End If

        Next

        dgvBudgets.ClearSelection()

    End Sub

    Private Sub SaveBudgets()

        'CREATE A NEW FOLDER IN MY CHECKBOOK LEDGERS CALLED BUDGETS IF IT DOESNT EXIST
        'SAVE BUDGETS IN TEXT FILES LIKE THIS "fast food,$25.00"
        'ALLOW USER TO EDIT EACH ROW IN DATAEGRIDVIEW THEN REWRITE ALL BUDGETS AND OVERWRITE FILE

        Dim strBudgets_DIRECTORY As String = String.Empty
        strBudgets_DIRECTORY = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\"

        Dim strFileName As String = String.Empty
        strFileName = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & ".bgt"

        Dim file As String = String.Empty
        file = strBudgets_DIRECTORY & strFileName

        If dgvBudgets.Rows.Count = 0 And My.Computer.FileSystem.FileExists(file) Then

            My.Computer.FileSystem.DeleteFile(file, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)

        ElseIf Not dgvBudgets.Rows.Count = 0 Then

            If My.Computer.FileSystem.FileExists(file) Then

                My.Computer.FileSystem.DeleteFile(file, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                WriteToFile(file)

            Else

                WriteToFile(file)

            End If

        End If

    End Sub

    Private Sub WriteToFile(ByVal _file As String)

        Dim writer As New System.IO.StreamWriter(_file, True)

        For Each dgvRow As DataGridViewRow In dgvBudgets.Rows

            Dim strCategory As String = String.Empty
            Dim strBudget As String = String.Empty
            Dim entry As String = String.Empty

            strCategory = dgvRow.Cells.Item("category").Value.ToString
            strBudget = dgvRow.Cells.Item("budget").Value.ToString
            strBudget = strBudget.Replace(",", "")

            entry = strCategory & "," & strBudget

            writer.WriteLine(entry)

        Next

        writer.Close()

    End Sub

    Private Function CategoryExists(ByVal _category As String) As Boolean

        Dim blnCategoryExists As Boolean = False

        If dgvBudgets.SelectedRows.Count = 0 Then

            For Each dgvRow As DataGridViewRow In dgvBudgets.Rows

                Dim category As String = String.Empty
                category = dgvRow.Cells.Item("category").Value.ToString
                If _category = category Then blnCategoryExists = True

            Next

        Else

            Dim intRowIndex As Integer = 0

            For Each dgvRow As DataGridViewRow In dgvBudgets.SelectedRows

                intRowIndex = dgvRow.Index

            Next

            For Each dgvRow As DataGridViewRow In dgvBudgets.Rows

                Dim strCategory As String = String.Empty
                strCategory = dgvRow.Cells.Item("category").Value.ToString
                If _category = strCategory And Not dgvRow.Index = intRowIndex Then blnCategoryExists = True

            Next

        End If

        Return blnCategoryExists
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        dgvBudgets.ClearSelection()

        Dim new_frmCreateBudget As New frmCreateBudget
        new_frmCreateBudget.caller_frmBudgets = Me

        If new_frmCreateBudget.ShowDialog = DialogResult.OK Then

            Dim strCategory As String = String.Empty
            Dim strBudget As String = String.Empty

            strCategory = new_frmCreateBudget.cbCategory.SelectedItem.ToString
            strBudget = new_frmCreateBudget.txtBudget.Text

            If Not CategoryExists(strCategory) Then

                AddRow(strCategory, strBudget)
                UpdateCalculationsAndFormat()

            Else

                CheckbookMsg.ShowMessage("There is already a budget for " & strCategory, MsgButtons.OK, "", Exclamation)

            End If

        End If

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim new_frmCreateBudget As New frmCreateBudget
        new_frmCreateBudget.caller_frmBudgets = Me

        If Not dgvBudgets.SelectedRows.Count = 0 Then

            If new_frmCreateBudget.ShowDialog = DialogResult.OK Then

                Dim strCategory As String = String.Empty
                Dim strBudget As String = String.Empty

                    strCategory = new_frmCreateBudget.cbCategory.SelectedItem.ToString
                    strBudget = new_frmCreateBudget.txtBudget.Text

                    For Each dgvRow As DataGridViewRow In dgvBudgets.SelectedRows

                        If Not CategoryExists(strCategory) Then

                            dgvRow.Cells.Item("category").Value = strCategory
                            dgvRow.Cells.Item("budget").Value = strBudget
                            UpdateCalculationsAndFormat()

                        Else

                            CheckbookMsg.ShowMessage("There is already a budget for " & strCategory, MsgButtons.OK, "", Exclamation)

                        End If

                    Next

                End If

            Else

            CheckbookMsg.ShowMessage("There are no budgets selected to edit", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

    Private Sub frmBudgets_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddColumns()
        LoadSavedBudgets()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If Not dgvBudgets.SelectedRows.Count = 0 Then

            For Each dgvRow As DataGridViewRow In dgvBudgets.SelectedRows

                Dim strCategory As String = dgvRow.Cells.Item("category").Value.ToString

                If CheckbookMsg.ShowMessage("Are you sure you want to delete the budget for " & strCategory & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    dgvBudgets.Rows.Remove(dgvRow)
                    dgvBudgets.ClearSelection()
                    UpdateCalculationsAndFormat()

                End If

            Next

        Else

            CheckbookMsg.ShowMessage("There are no budgets selected to delete", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        SaveBudgets()
        FileClose(1)

    End Sub

    Function SumMonthly(ByVal _item As String) 'THIS SUMS TOTAL PAYMENTS PER MONTH PER YEAR FROM THE LEDGER. VALUES ARE DISPLAYED FROM JANUARY THRU DECEMBER IN THE DATAGRIDVIEW

        Dim dblTotal As Double = Nothing
        Dim strEmpty As String = String.Empty

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strCategory As String = String.Empty
            Dim strTransactionAmount As String = String.Empty
            Dim dtDate As Date = Nothing

            dtDate = dgvRow.Cells.Item("TransDate").Value
            strCategory = dgvRow.Cells.Item("Category").Value.ToString
            strTransactionAmount = dgvRow.Cells.Item("Payment").Value.ToString

            If strTransactionAmount = "" Then
                strTransactionAmount = 0
            Else
                strTransactionAmount = CDbl(strTransactionAmount)
            End If

            If strCategory = _item And dtDate.Month = Now.Month And dtDate.Year = Now.Year Then
                dblTotal += strTransactionAmount
            End If

        Next

        If dblTotal = 0 Then
            Return strEmpty
        Else

            Return FormatCurrency(dblTotal)
        End If
    End Function

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Help.ShowHelp(Me, m_helpProvider.HelpNamespace, "budgets.html")

    End Sub

End Class