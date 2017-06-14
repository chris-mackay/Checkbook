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
Imports System.ComponentModel
Imports System.IO

Public Class frmSpendingOverview

    'NEW INSTANCES OF CLASSES
    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager

    'SPENDING OVERVIEW VARIABLES
    Private monthlyTotalList As New List(Of String)
    Private groupTextboxesList As New List(Of TextBox)
    Private yearList As New List(Of Integer)
    Private columnIndexList As New List(Of Integer)
    Private blnCalculatingWhatif As Boolean = False
    Private dblOriginalCurrentYearTotalPayments As Double
    Private dblOriginalCurrentYearTotalDeposits As Double
    Private blnSelectedYearIsMostRecentYear As Boolean
    Private blnFORM_IS_LOADING As Boolean

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, mnuClose.Click

        m_CategoriesPayees = ""
        m_CategoriesPayees = Nothing
        Me.Dispose()

    End Sub

    Private Sub Clear_Add_FormatCategoryPayeeColumns()

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvCategory)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvCategory)

        Me.dgvCategory.DataSource = Nothing 'RELEASES THE DATASOURCE TO LOAD IN LEDGER DATA
        Me.dgvCategory.Columns.Clear()

        Dim colCategory_Payee As New DataGridViewTextBoxColumn
        Dim colJanuary As New DataGridViewTextBoxColumn
        Dim colFebruary As New DataGridViewTextBoxColumn
        Dim colMarch As New DataGridViewTextBoxColumn
        Dim colApril As New DataGridViewTextBoxColumn
        Dim colMay As New DataGridViewTextBoxColumn
        Dim colJune As New DataGridViewTextBoxColumn
        Dim colJuly As New DataGridViewTextBoxColumn
        Dim colAugust As New DataGridViewTextBoxColumn
        Dim colSeptember As New DataGridViewTextBoxColumn
        Dim colOctober As New DataGridViewTextBoxColumn
        Dim colNovember As New DataGridViewTextBoxColumn
        Dim colDecember As New DataGridViewTextBoxColumn
        Dim colTotals As New DataGridViewTextBoxColumn
        Dim colPercent As New DataGridViewTextBoxColumn

        If cbCategoriesPayees.Text = "Categories" Then

            colCategory_Payee.Name = "Category"

        Else

            colCategory_Payee.Name = "Payee"

        End If

        colJanuary.Name = "January"
        colFebruary.Name = "February"
        colMarch.Name = "March"
        colApril.Name = "April"
        colMay.Name = "May"
        colJune.Name = "June"
        colJuly.Name = "July"
        colAugust.Name = "August"
        colSeptember.Name = "September"
        colOctober.Name = "October"
        colNovember.Name = "November"
        colDecember.Name = "December"
        colTotals.Name = "Totals"
        colPercent.Name = "Percent"

        Me.dgvCategory.Columns.Add(colCategory_Payee)
        Me.dgvCategory.Columns.Add(colJanuary)
        Me.dgvCategory.Columns.Add(colFebruary)
        Me.dgvCategory.Columns.Add(colMarch)
        Me.dgvCategory.Columns.Add(colApril)
        Me.dgvCategory.Columns.Add(colMay)
        Me.dgvCategory.Columns.Add(colJune)
        Me.dgvCategory.Columns.Add(colJuly)
        Me.dgvCategory.Columns.Add(colAugust)
        Me.dgvCategory.Columns.Add(colSeptember)
        Me.dgvCategory.Columns.Add(colOctober)
        Me.dgvCategory.Columns.Add(colNovember)
        Me.dgvCategory.Columns.Add(colDecember)
        Me.dgvCategory.Columns.Add(colTotals)
        Me.dgvCategory.Columns.Add(colPercent)

        FormatCategoryPayeeGrid()

        MainModule.DrawingControl.ResumeDrawing(Me.dgvCategory)

    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged, mnuResetYearTotals.Click, cxmnuResetYearTotals.Click, cbCategoriesPayees.SelectedIndexChanged, cbPaymentsDeposits.SelectedIndexChanged

        m_CategoriesPayees = cbCategoriesPayees.SelectedItem.ToString

        blnCalculatingWhatif = False 'SETS THIS BECAUSE IT IS NOT CALCULATING WHATIF TOTALS
        gbFilterOptions.Enabled = True

        If Not yearList.Count = 0 Then

            If Not CInt(cbYear.SelectedItem) = yearList.Max Then

                blnSelectedYearIsMostRecentYear = False

                mnuCreateExpense.Enabled = False
                mnuEditExpense.Enabled = False
                mnuRemoveExpenses.Enabled = False
                mnuRemoveCategory.Enabled = False
                mnuCopyToNextMonth.Enabled = False
                mnuCopyToSelectedMonths.Enabled = False
                mnuCopyToRestOfYear.Enabled = False

                cxmnuCreateExpense.Enabled = False
                cxmnuEditExpense.Enabled = False
                cxmnuRemoveExpenses.Enabled = False
                cxmnuRemoveCategories.Enabled = False
                cxmnuCopyToNextMonth.Enabled = False
                cxmnuCopyToSelectedMonths.Enabled = False
                cxmnuCopyToRestOfYear.Enabled = False

                cxmnuMonthlyIncomeTable.Enabled = False

            Else

                blnSelectedYearIsMostRecentYear = True

                mnuCreateExpense.Enabled = True
                mnuEditExpense.Enabled = True
                mnuRemoveExpenses.Enabled = True
                mnuRemoveCategory.Enabled = True
                mnuCopyToNextMonth.Enabled = True
                mnuCopyToSelectedMonths.Enabled = True
                mnuCopyToRestOfYear.Enabled = True

                cxmnuCreateExpense.Enabled = True
                cxmnuEditExpense.Enabled = True
                cxmnuRemoveExpenses.Enabled = True
                cxmnuRemoveCategories.Enabled = True
                cxmnuCopyToNextMonth.Enabled = True
                cxmnuCopyToSelectedMonths.Enabled = True
                cxmnuCopyToRestOfYear.Enabled = True

                cxmnuMonthlyIncomeTable.Enabled = True

            End If

        End If

        If cbCategoriesPayees.Text = "Categories" Then

            mnuRemoveCategory.Text = "Remove Categories"
            cxmnuRemoveCategories.Text = "Remove Categories"

        Else

            mnuRemoveCategory.Text = "Remove Payees"
            cxmnuRemoveCategories.Text = "Remove Payees"

        End If

        If cbPaymentsDeposits.Text = "Payments" Then

            mnuCreateExpense.Text = "Create Monthly Expense"
            cxmnuCreateExpense.Text = "Create Monthly Expense"
            mnuEditExpense.Text = "Edit Expenses"
            cxmnuEditExpense.Text = "Edit Expenses"
            mnuRemoveExpenses.Text = "Remove Expenses"
            cxmnuRemoveExpenses.Text = "Remove Expenses"
            mnuResetYearTotals.Text = "Reset All Expenses"
            cxmnuResetYearTotals.Text = "Reset All Expenses"

        Else

            mnuCreateExpense.Text = "Create Monthly Income"
            cxmnuCreateExpense.Text = "Create Monthly Income"
            mnuEditExpense.Text = "Edit Incomes"
            cxmnuEditExpense.Text = "Edit Incomes"
            mnuRemoveExpenses.Text = "Remove Incomes"
            cxmnuRemoveExpenses.Text = "Remove Incomes"
            mnuResetYearTotals.Text = "Reset All Incomes"
            cxmnuResetYearTotals.Text = "Reset All Incomes"

        End If

        Clear_Add_FormatCategoryPayeeColumns() 'CLEARS ALL THE COLUMNS AND CREATES THEM PROGRAMMATICALLY

        Me.dgvCategory.Rows.Clear()

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        If Not blnFORM_IS_LOADING Then
            UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR
        End If

        If cbPaymentsDeposits.Text = "Payments" Then

            DetermineCategoriesbyYear_Payments(intSelectedYear)
            DeterminePayeesbyYear_Payments(intSelectedYear)

        Else

            DetermineCategoriesbyYear_Deposits(intSelectedYear)
            DeterminePayeesbyYear_Deposits(intSelectedYear)

        End If

        '--------------
        CalculateMonthlyIncome_FromLedger() 'CALCULATES MONTHLY INCOME

        CalculateAccountDetailsforSelectedYear_andDisplay() 'SETS THE ACCOUNT DETAILS TEXTBOXES TO VALUES BASED ON SELECTED YEAR
        '--------------

        If cbCategoriesPayees.Text = "Categories" Then

            For Each strCategory As String In m_globalUsedCategoryCollection

                dgvCategory.Rows.Add(strCategory, SumMonthly(strCategory, 1, intSelectedYear), SumMonthly(strCategory, 2, intSelectedYear), SumMonthly(strCategory, 3, intSelectedYear), SumMonthly(strCategory, 4, intSelectedYear), SumMonthly(strCategory, 5, intSelectedYear), SumMonthly(strCategory, 6, intSelectedYear), SumMonthly(strCategory, 7, intSelectedYear), SumMonthly(strCategory, 8, intSelectedYear), SumMonthly(strCategory, 9, intSelectedYear), SumMonthly(strCategory, 10, intSelectedYear), SumMonthly(strCategory, 11, intSelectedYear), SumMonthly(strCategory, 12, intSelectedYear), SumbyCategory(strCategory, intSelectedYear), CatPercent(SumbyCategory(strCategory, intSelectedYear)))

            Next

        Else

            For Each strPayee As String In m_globalUsedPayeeCollection

                dgvCategory.Rows.Add(strPayee, SumMonthly(strPayee, 1, intSelectedYear), SumMonthly(strPayee, 2, intSelectedYear), SumMonthly(strPayee, 3, intSelectedYear), SumMonthly(strPayee, 4, intSelectedYear), SumMonthly(strPayee, 5, intSelectedYear), SumMonthly(strPayee, 6, intSelectedYear), SumMonthly(strPayee, 7, intSelectedYear), SumMonthly(strPayee, 8, intSelectedYear), SumMonthly(strPayee, 9, intSelectedYear), SumMonthly(strPayee, 10, intSelectedYear), SumMonthly(strPayee, 11, intSelectedYear), SumMonthly(strPayee, 12, intSelectedYear), SumbyCategory(strPayee, intSelectedYear), CatPercent(SumbyCategory(strPayee, intSelectedYear)))

            Next

        End If

        rbCurrentYear.Checked = True
        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

        If Not blnFORM_IS_LOADING Then
            UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR
        End If

        dgvCategory.ClearSelection()

    End Sub

    Private Sub CopyToSelectedMonths() Handles mnuCopyToSelectedMonths.Click, cxmnuCopyToSelectedMonths.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strNoneSelectedMessage = "There are no expenses selected to edit"
            strInvalidSelectionMessage = "Select only the expenses you want to copy"
            strErrorMessage = "An error occurred while copying the expenses"

        Else

            strNoneSelectedMessage = "There are no incomes selected to edit"
            strInvalidSelectionMessage = "Select only the incomes you want to copy"
            strErrorMessage = "An error occurred while copying the incomes"

        End If

        columnIndexList.Clear()

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        columnIndexList = columnIndexList.Distinct.ToList

        Try

            If dgvCategory.SelectedCells.Count = 0 Then

                CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Count = 1 And columnIndexList.Contains(12) Then

                CheckbookMsg.ShowMessage("There are no months to copy December to.", MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Count > 1 Then

                CheckbookMsg.ShowMessage("You may only copy one month at a time.", MsgButtons.OK, "", Exclamation)

            Else

                Dim new_frmCopyToSelectedMonths As New frmCopyToSelectedMonths

                If new_frmCopyToSelectedMonths.ShowDialog = DialogResult.OK Then

                    Dim blnJan As Boolean = False
                    Dim blnFeb As Boolean = False
                    Dim blnMar As Boolean = False
                    Dim blnApr As Boolean = False
                    Dim blnMay As Boolean = False
                    Dim blnJun As Boolean = False
                    Dim blnJul As Boolean = False
                    Dim blnAug As Boolean = False
                    Dim blnSep As Boolean = False
                    Dim blnOct As Boolean = False
                    Dim blnNov As Boolean = False
                    Dim blnDec As Boolean = False

                    With new_frmCopyToSelectedMonths

                        blnJan = .ckbJan.Checked
                        blnFeb = .ckbFeb.Checked
                        blnMar = .ckbMar.Checked
                        blnApr = .ckbApr.Checked
                        blnMay = .ckbMay.Checked
                        blnJun = .ckbJun.Checked
                        blnJul = .ckbJul.Checked
                        blnAug = .ckbAug.Checked
                        blnSep = .ckbSep.Checked
                        blnOct = .ckbOct.Checked
                        blnNov = .ckbNov.Checked
                        blnDec = .ckbDec.Checked

                    End With

                    Dim monthstoCopyToList As New List(Of Integer)

                    If blnJan Then monthstoCopyToList.Add(1)
                    If blnFeb Then monthstoCopyToList.Add(2)
                    If blnMar Then monthstoCopyToList.Add(3)
                    If blnApr Then monthstoCopyToList.Add(4)
                    If blnMay Then monthstoCopyToList.Add(5)
                    If blnJun Then monthstoCopyToList.Add(6)
                    If blnJul Then monthstoCopyToList.Add(7)
                    If blnAug Then monthstoCopyToList.Add(8)
                    If blnSep Then monthstoCopyToList.Add(9)
                    If blnOct Then monthstoCopyToList.Add(10)
                    If blnNov Then monthstoCopyToList.Add(11)
                    If blnDec Then monthstoCopyToList.Add(12)

                    For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                        Dim intCurrentColumn As Integer = dgvSelectedCell.ColumnIndex
                        Dim intCurrentRow As Integer = dgvSelectedCell.RowIndex

                        For Each intMonth As Integer In monthstoCopyToList

                            Dim intNextColumn As Integer = intMonth
                            dgvCategory.Item(intNextColumn, intCurrentRow).Value = dgvCategory.Item(intCurrentColumn, intCurrentRow).Value

                        Next

                    Next

                    PerformWhatifScenarioCalculations_DisplayData()

                End If

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try


    End Sub

    Private Sub copyToNextMonth(sender As Object, e As EventArgs) Handles mnuCopyToNextMonth.Click, cxmnuCopyToNextMonth.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strNoneSelectedMessage = "There are no expenses selected to edit"
            strInvalidSelectionMessage = "Select only the expenses you want to copy"
            strErrorMessage = "An error occurred while copying the expenses"

        Else

            strNoneSelectedMessage = "There are no incomes selected to edit"
            strInvalidSelectionMessage = "Select only the incomes you want to copy"
            strErrorMessage = "An error occurred while copying the incomes"

        End If

        columnIndexList.Clear()

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        columnIndexList = columnIndexList.Distinct.ToList

        Try

            If dgvCategory.SelectedCells.Count = 0 Then

                CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Count = 1 And columnIndexList.Contains(12) Then

                CheckbookMsg.ShowMessage("There are no months to copy December to.", MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Count > 1 Then

                CheckbookMsg.ShowMessage("You may only copy one month at a time.", MsgButtons.OK, "", Exclamation)

            Else

                For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                    Dim intCurrentColumn As Integer = dgvSelectedCell.ColumnIndex
                    Dim intCurrentRow As Integer = dgvSelectedCell.RowIndex
                    Dim intNextColumn As Integer = intCurrentColumn + 1

                    dgvCategory.Item(intNextColumn, intCurrentRow).Value = dgvCategory.Item(intCurrentColumn, intCurrentRow).Value

                Next

                PerformWhatifScenarioCalculations_DisplayData()

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try

    End Sub

    Private Sub copyToRestOfYear(sender As Object, e As EventArgs) Handles mnuCopyToRestOfYear.Click, cxmnuCopyToRestOfYear.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strNoneSelectedMessage = "There are no expenses selected to edit"
            strInvalidSelectionMessage = "Select only the expenses you want to copy"
            strErrorMessage = "An error occurred while copying the expenses"

        Else

            strNoneSelectedMessage = "There are no incomes selected to edit"
            strInvalidSelectionMessage = "Select only the incomes you want to copy"
            strErrorMessage = "An error occurred while copying the incomes"

        End If

        columnIndexList.Clear()

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        columnIndexList = columnIndexList.Distinct.ToList

        Try

            If dgvCategory.SelectedCells.Count = 0 Then

                CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Count = 1 And columnIndexList.Contains(12) Then

                CheckbookMsg.ShowMessage("There are no months to copy December to.", MsgButtons.OK, "", Exclamation)

            ElseIf columnIndexList.Count > 1 Then

                CheckbookMsg.ShowMessage("You may only copy one month at a time.", MsgButtons.OK, "", Exclamation)

            Else

                For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                    Dim intCurrentColumn As Integer = dgvSelectedCell.ColumnIndex
                    Dim intCurrentRow As Integer = dgvSelectedCell.RowIndex
                    Dim intNextColumn As Integer = intCurrentColumn + 1
                    Dim intNextRow As Integer = intCurrentRow

                    Do While intNextColumn < 13

                        dgvCategory.Item(intNextColumn, intCurrentRow).Value = dgvCategory.Item(intCurrentColumn, intCurrentRow).Value
                        intNextColumn += 1

                    Loop

                    intNextRow += 1

                Next

                PerformWhatifScenarioCalculations_DisplayData()

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try

    End Sub

    Private Sub frmSpendingOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        blnFORM_IS_LOADING = True
        UIManager.SetCursor(Me, Cursors.WaitCursor)

        Dim colorRenderer_Professional As New clsUIManager.MyProfessionalRenderer

        mnuMenuStrip.Renderer = colorRenderer_Professional
        cxmnuWhatIf.Renderer = colorRenderer_Professional

        Dim spendingOverviewControlsList As New List(Of Control)

        For Each ctrl As Control In Me.Controls

            spendingOverviewControlsList.Add(ctrl)

        Next

        UIManager.SetGroupObjects_List_Visible(spendingOverviewControlsList, False)
        MainModule.DrawingControl.SetDoubleBuffered_ListControls(spendingOverviewControlsList)
        MainModule.DrawingControl.SuspendDrawing_ListControls(spendingOverviewControlsList)

        cxmnuWhatIf.Renderer = colorRenderer_Professional
        cxmnuMonthlyIncomeTable.Renderer = colorRenderer_Professional

        cbCategoriesPayees.Text = "Categories"
        cbPaymentsDeposits.Text = "Payments"

        Clear_Add_FormatCategoryPayeeColumns() 'CLEARS ALL THE COLUMNS AND CREATES THEM PROGRAMMATICALLY

        'ADDS ALL TEXTBOXES THAT NEED TO BE COLORED INTO A GROUP
        groupTextboxesList.Add(txtOverallBalance)
        groupTextboxesList.Add(txtYearStatus)
        groupTextboxesList.Add(txtLedgerStatus)

        Me.dgvCategory.Rows.Clear()
        Me.dgvMonthly.Rows.Clear()
        m_MonthCollection.Clear()

        GetAllYearsFromDataGridView_FillList_ComboBox(yearList, cbYear)

        m_MonthCollection.Add("January")
        m_MonthCollection.Add("February")
        m_MonthCollection.Add("March")
        m_MonthCollection.Add("April")
        m_MonthCollection.Add("May")
        m_MonthCollection.Add("June")
        m_MonthCollection.Add("July")
        m_MonthCollection.Add("August")
        m_MonthCollection.Add("September")
        m_MonthCollection.Add("October")
        m_MonthCollection.Add("November")
        m_MonthCollection.Add("December")

        cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST. THIS TRIGGERS THE CALCULATION

        dgvMonthly.ClearSelection()

        UIManager.SetGroupObjects_List_Visible(spendingOverviewControlsList, True)
        MainModule.DrawingControl.ResumeDrawing_ListControls(spendingOverviewControlsList)

        blnFORM_IS_LOADING = False
        UIManager.SetCursor(Me, Cursors.Default)

    End Sub

    Function SumMonthly(ByVal _item As String, ByVal _month As Integer, ByVal _year As Integer) 'THIS SUMS TOTAL PAYMENTS PER MONTH PER YEAR FROM THE LEDGER. VALUES ARE DISPLAYED FROM JANUARY THRU DECEMBER IN THE DATAGRIDVIEW

        Dim dblTotal As Double = Nothing
        Dim strEmpty As String = String.Empty

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strCategory As String = String.Empty
            Dim strTransactionAmount As String = String.Empty
            Dim dtDate As Date = Nothing

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If cbCategoriesPayees.Text = "Categories" Then 'CHECKS WHETHER CATEGORIES OR PAYEES ARE SELECTED

                strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString

            Else

                strCategory = MainForm.dgvLedger.Item("Payee", i).Value.ToString

            End If

            If cbPaymentsDeposits.Text = "Payments" Then 'CHECKS WHETHER PAYMENTS OR DEPOSITS ARE SELECTED

                strTransactionAmount = MainForm.dgvLedger.Item("Payment", i).Value.ToString

            Else

                strTransactionAmount = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            End If

            If strTransactionAmount = "" Then
                strTransactionAmount = 0
            Else
                strTransactionAmount = CDbl(strTransactionAmount)
            End If

            If strCategory = _item And dtDate.Month = _month And dtDate.Year = _year Then
                dblTotal += strTransactionAmount
            End If

        Next

        If dblTotal = 0 Then
            Return strEmpty
        Else

            Return FormatCurrency(dblTotal)
        End If
    End Function

    Function SumbyCategory(ByVal _category As String, ByVal _year As Integer) 'THIS SUMS PER CATEGORY PER YEAR FROM THE LEDGER. VALUES ARE DISPLAYED IN THE "TOTALS" COLUMN

        Dim dblTotal As Double = Nothing
        Dim dtDate As Date = Nothing

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strCategory As String = String.Empty
            Dim strTransactionAmount As String = String.Empty

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If cbCategoriesPayees.Text = "Categories" Then 'CHECKS WHETHER CATEGORIES OR PAYEES ARE SELECTED

                strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString

            Else

                strCategory = MainForm.dgvLedger.Item("Payee", i).Value.ToString

            End If

            If cbPaymentsDeposits.Text = "Payments" Then 'CHECKS WHETHER PAYMENTS OR DEPOSITS ARE SELECTED

                strTransactionAmount = MainForm.dgvLedger.Item("Payment", i).Value.ToString

            Else

                strTransactionAmount = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            End If

            If strTransactionAmount = "" Then
                strTransactionAmount = 0
            Else
                strTransactionAmount = CDbl(strTransactionAmount)
            End If

            If strCategory = _category And dtDate.Year = _year Then
                dblTotal += strTransactionAmount
            End If

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Sub SumbyCategory_Whatif() 'CALCULATES TOTALS PER CATEGORY FROM THE CATEGORY DATAGRIDVIEW. USED TO CALCULATE NEW HYPOTHETICAL PAYMENT TOTALS

        Dim dblTotal As Double = Nothing
        Dim strPayment As String = String.Empty
        Dim dblNewTotal As Double = Nothing

        For j As Integer = 0 To dgvCategory.Rows.Count - 1

            dblTotal = 0 'SETS TOTAL EQUAL TO ZERO EVERYTIME IT GOES TO THE NEXT LINE

            For i As Integer = 1 To dgvCategory.Columns.Count - 3

                strPayment = dgvCategory.Item(i, j).Value.ToString()

                If strPayment = "" Then
                    strPayment = 0
                Else
                    strPayment = CDbl(strPayment)
                End If

                dblTotal += strPayment

            Next

            dblNewTotal += dblTotal

            dgvCategory.Item("Totals", j).Value = FormatCurrency(dblTotal) 'SETS NEW CATEGORY TOTAL TO COLUMN TOTAL 

        Next

        For k As Integer = 0 To dgvCategory.Rows.Count - 1

            Dim dblCategoryTotal As Double = dgvCategory.Item("Totals", k).Value 'GETS TOTAL PAYMENTS PER CATEGORY

            dgvCategory.Item("Percent", k).Value = CatPercent_Whatif(dblCategoryTotal, dblNewTotal) 'CALCULATES NEW PERCENT BY CATEGORY AND SETS ITS VALUE IN THE "PERCENT" COLUMN

        Next

    End Sub

    Function CatPercent(ByVal categoryTotal As Double) As String

        Dim dblPercent As Double = Nothing
        Dim dblTotalPayments As Double = Nothing
        Dim dblTotalDeposits As Double = Nothing

        dblTotalPayments = GetTotalPaymentsFromMonthlyGrid(dgvMonthly)

        dblTotalDeposits = GetTotalDepositsFromMonthlyGrid(dgvMonthly)

        If cbPaymentsDeposits.Text = "Payments" Then

            dblPercent = Math.Round((categoryTotal / dblTotalPayments) * 100, 2).ToString

        Else

            dblPercent = Math.Round((categoryTotal / dblTotalDeposits) * 100, 2).ToString

        End If

        Return dblPercent & "%"
    End Function

    Function CatPercent_Whatif(ByVal categoryTotal As Double, ByVal newTotal As Double) As String 'CALCULATES NEW CATEGORY PERCENT BASED ON NEW TOTAL PAYMENTS

        Dim dblPercent As Double = Nothing

        dblPercent = Math.Round((categoryTotal / newTotal) * 100, 2).ToString

        Return dblPercent & "%"
    End Function

    Sub FormatCategoryPayeeGrid()

        With dgvCategory

            If cbCategoriesPayees.Text = "Categories" Then

                'CATEGORY
                .Columns("Category").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Columns("Category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Category").Width = 200

            Else

                'PAYEE
                .Columns("Payee").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Columns("Payee").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Payee").Width = 200

            End If

            'JANUARY
            .Columns("January").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("January").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("January").Width = 70
            .Columns("January").SortMode = False

            'FEBRUARY
            .Columns("February").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("February").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("February").Width = 70
            .Columns("February").SortMode = False

            'MARCH
            .Columns("March").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("March").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("March").Width = 70
            .Columns("March").SortMode = False

            'APRIL
            .Columns("April").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("April").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("April").Width = 70
            .Columns("April").SortMode = False

            'MAY
            .Columns("May").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("May").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("May").Width = 70
            .Columns("May").SortMode = False

            'JUNE
            .Columns("June").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("June").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("June").Width = 70
            .Columns("June").SortMode = False

            'JULY
            .Columns("July").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("July").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("July").Width = 70
            .Columns("July").SortMode = False

            'AUGUST
            .Columns("August").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("August").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("August").Width = 70
            .Columns("August").SortMode = False

            'SEPTEMBER
            .Columns("September").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("September").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("September").Width = 70
            .Columns("September").SortMode = False

            'OCTOBER
            .Columns("October").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("October").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("October").Width = 70
            .Columns("October").SortMode = False

            'NOVEMBER
            .Columns("November").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("November").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("November").Width = 70
            .Columns("November").SortMode = False

            'DECEMBER
            .Columns("December").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("December").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("December").Width = 70
            .Columns("December").SortMode = False

            'TOTALS
            .Columns("Totals").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Totals").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Totals").Width = 70
            .Columns("Totals").SortMode = False

            'PERCENT
            .Columns("Percent").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Percent").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Percent").Width = 70
            .Columns("Percent").SortMode = False

            .ClearSelection()

        End With 'FORMATS DATAGRID

    End Sub

    Private Sub mnuCreateExpense_Click(sender As Object, e As EventArgs) Handles mnuCreateExpense.Click, cxmnuCreateExpense.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
        Dim new_frmCreateExpense As New frmCreateExpense

        Dim strErrorMessage As String = String.Empty
        Dim strErrorMessageTitle As String = String.Empty
        Dim strFormTitle As String = String.Empty
        Dim strTopLabel As String = String.Empty
        Dim strBottomLabel As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strFormTitle = "Create Monthly Expense"
            strErrorMessageTitle = "Create Expense Error"
            strErrorMessage = "An error occurred while creating the expense"
            strBottomLabel = "Monthly Expense"

        Else

            strFormTitle = "Create Monthly Income"
            strErrorMessageTitle = "Create Income Error"
            strErrorMessage = "An error occurred while creating the monthly income"
            strBottomLabel = "Monthly Income"

        End If

        If cbCategoriesPayees.Text = "Categories" Then

            strTopLabel = "Category"

        Else

            strTopLabel = "Payee"

        End If

        new_frmCreateExpense.Text = strFormTitle
        new_frmCreateExpense.lblCategory.Text = strTopLabel
        new_frmCreateExpense.lblMonthlyExpense.Text = strBottomLabel

        If new_frmCreateExpense.ShowDialog = Windows.Forms.DialogResult.OK Then

            UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

            Dim new_TransCategory As New clsTransaction

            Try

                Dim strCategory As String = String.Empty
                Dim strExpense As String = String.Empty

                strCategory = new_frmCreateExpense.cbCategoriesPayees.Text
                strExpense = new_frmCreateExpense.txtMonthlyExpense.Text

                new_TransCategory.Category = strCategory

                strExpense = FormatCurrency(strExpense)

                'CREATES A NEW MOTHLY EXPENSE AND APPLIES IT TO EVERY MONTH IN THE DATAGRIDVIEW
                dgvCategory.Rows.Add(new_TransCategory.Category, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense)

                PerformWhatifScenarioCalculations_DisplayData() 'PERFORMS ALL CALCULATIONS AND DISPLAYS THE NEW HYPOTHETICAL DATA

            Catch ex As Exception

                CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & "Make sure you entered a valid amount" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR
                new_TransCategory = Nothing

            End Try

        End If

    End Sub

    Private Sub mnuEditExpense_Click(sender As Object, e As EventArgs) Handles mnuEditExpense.Click, cxmnuEditExpense.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strConfirmRemoveMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty
        Dim strErrorMessageTitle As String = String.Empty
        Dim strFormTitle As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strFormTitle = "Edit Expenses"
            strErrorMessageTitle = "Edit Expenses Error"
            strNoneSelectedMessage = "There are no expenses selected to edit"
            strInvalidSelectionMessage = "Select only the expenses you want to edit"
            strConfirmRemoveMessage = "Are you sure you want to make all the selected expenses "
            strErrorMessage = "An error occurred while editing the expenses"

        Else

            strFormTitle = "Edit Incomes"
            strErrorMessageTitle = "Edit Incomes Error"
            strNoneSelectedMessage = "There are no incomes selected to edit"
            strInvalidSelectionMessage = "Select only the incomes you want to edit"
            strConfirmRemoveMessage = "Are you sure you want to make all the selected incomes "
            strErrorMessage = "An error occurred while editing the incomes"

        End If

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If dgvCategory.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                Dim new_frmEditValues As New frmEditValues
                new_frmEditValues.Text = strFormTitle

                If new_frmEditValues.ShowDialog = Windows.Forms.DialogResult.OK Then

                    If CheckbookMsg.ShowMessage(strConfirmRemoveMessage & FormatCurrency(new_frmEditValues.txtNewExpenseValue.Text) & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                        Try

                            UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

                            For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                                dgvSelectedCell.Value = FormatCurrency(new_frmEditValues.txtNewExpenseValue.Text)

                            Next

                            PerformWhatifScenarioCalculations_DisplayData() 'PERFORMS ALL CALCULATIONS AND DISPLAYS THE NEW HYPOTHETICAL DATA

                        Catch ex As Exception

                            CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & "Make sure you entered a valid amount" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                        Finally

                            UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

                        End Try

                    End If

                End If

            End If

        End If

        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

    End Sub

    Sub CalculateMonthlyIncome_FromLedger()

        dgvMonthly.Rows.Clear()
        dgvMonthly.Columns.Clear()

        CreateMonthlyGridColumns(dgvMonthly)

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        For Each strMonth As String In m_MonthCollection

            'FILLS MONTHLY DATAGRID VIEW WITH MONTH, TOTAL PAYMENTS PER MONTH, TOTAL DEPOSITS PER MONTH, MONTHLY STATUS
            dgvMonthly.Rows.Add(strMonth, SumPaymentsMonthly_FromMainFromLedger(strMonth, intSelectedYear), SumDepositsMonthly_FromMainFormLedger(strMonth, intSelectedYear))

        Next

        CalculateMonthlyIncome_And_AverageIncome(dgvMonthly)

        dgvMonthly.ClearSelection()

    End Sub 'CALCULATES MONTHLY INCOME BASED ON YEAR

    Sub CalculateMonthlyIncome_Whatif()

        Dim dblTotalPayments As Double = Nothing
        Dim dblTotalDeposits As Double = Nothing
        Dim strMonth As String = String.Empty

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        'CALCULATES TOTAL AMOUNTS FROM CATEGORY/PAYEE TABLE
        If cbPaymentsDeposits.Text = "Payments" Then

            For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                strMonth = dgvRow.Cells("Month").Value
                dblTotalPayments = SumAmountsMonthly_SpendingOverview(strMonth)
                dgvRow.Cells("Payments").Value = dblTotalPayments

            Next

        Else

            For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                strMonth = dgvRow.Cells("Month").Value
                dblTotalDeposits = SumAmountsMonthly_SpendingOverview(strMonth)
                dgvRow.Cells("Deposits").Value = dblTotalDeposits

            Next

        End If

        CalculateMonthlyIncome_And_AverageIncome(dgvMonthly) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        dgvMonthly.ClearSelection()

    End Sub  'RECALCULATES MONTHLY INCOME BASED ON NEWLY CREATED MONTHLY EXPENSE

    Function SpendingbyCategory_WhatifMonthlyStatus(ByVal _month As String, ByVal _year As Integer)

        Dim dblMonthlyStatus As Double = Nothing

        dblMonthlyStatus = SumDepositsMonthly_FromMainFormLedger(_month, _year) - SumAmountsMonthly_SpendingOverview(_month)

        Return FormatCurrency(dblMonthlyStatus)
    End Function  'SPENDING BY CATEGORY WHATIF MONTHLY EXPENSE

    Function SumAmountsMonthly_SpendingOverview(ByVal _month As String)

        Dim dblTotal As Double = Nothing

        For i As Integer = 0 To dgvCategory.RowCount - 1

            Dim strAmount As String = String.Empty

            strAmount = dgvCategory.Item(ConvertMonthFromStringToInteger(_month), i).Value.ToString 'GET TOTALS BY CATEGORY

            If strAmount = "" Then
                strAmount = 0
            Else
                strAmount = CDbl(strAmount)
            End If

            dblTotal += strAmount

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Private Sub mnuRemoveExpenses_Click(sender As Object, e As EventArgs) Handles mnuRemoveExpenses.Click, cxmnuRemoveExpenses.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strConfirmRemoveMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty
        Dim strErrorMessageTitle As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strErrorMessageTitle = "Remove Expenses Error"
            strNoneSelectedMessage = "There are no expenses selected to remove"
            strInvalidSelectionMessage = "Select only the expenses you want to remove"
            strConfirmRemoveMessage = "Are you sure you want to remove the selected expenses?"
            strErrorMessage = "An error occurred while removing the expenses"

        Else

            strErrorMessageTitle = "Remove Incomes Error"
            strNoneSelectedMessage = "There are no incomes selected to remove"
            strInvalidSelectionMessage = "Select only the incomes you want to remove"
            strConfirmRemoveMessage = "Are you sure you want to remove the selected incomes?"
            strErrorMessage = "An error occurred while removing the incomes"

        End If

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvCategory.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

                    Try

                        For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                            dgvSelectedCell.Value = ""

                        Next

                        PerformWhatifScenarioCalculations_DisplayData()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub mnuRemoveCategory_Click(sender As Object, e As EventArgs) Handles mnuRemoveCategory.Click, cxmnuRemoveCategories.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strConfirmRemoveMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty
        Dim strErrorMessageTitle As String = String.Empty

        If cbCategoriesPayees.Text = "Categories" Then

            strErrorMessageTitle = "Remove Categories Error"
            strNoneSelectedMessage = "There are no categories selected to remove"
            strInvalidSelectionMessage = "Select only the categories you want to remove"
            strConfirmRemoveMessage = "Are you sure you want to remove the selected categories?"
            strErrorMessage = "An error occurred while removing the categories"

        Else

            strErrorMessageTitle = "Remove Payees Error"
            strNoneSelectedMessage = "There are no payees selected to remove"
            strInvalidSelectionMessage = "Select only the payees you want to remove"
            strConfirmRemoveMessage = "Are you sure you want to remove the selected payees?"
            strErrorMessage = "An error occurred while removing the payees"

        End If

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvCategory.SelectedCells.Count = 0 Then 'CHECK TO MAKE SURE AT LEAST ONE CELL IS SELECTED

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

        Else

            Dim intTotal As Integer = Nothing

            For Each intColumnIndex As Integer In columnIndexList

                intTotal += intColumnIndex

            Next

            If Not intTotal = 0 Then 'CHECK TO MAKE SURE ONLY THE CATEGORY COLUMN IS SELECTED.

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

                    Try

                        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

                            Me.dgvCategory.Rows.RemoveAt(dgvSelectedCell.RowIndex)

                        Next

                        PerformWhatifScenarioCalculations_DisplayData()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

                    End Try

                End If

            End If

        End If

    End Sub

    Sub CalculateAccountDetailsforSelectedYear_andDisplay()

        Dim dblCurrentOverallBalance As Double = Nothing
        Dim dblSelectedYearStatus As Double = Nothing
        Dim dblOriginalLedgerStatus As Double = Nothing
        Dim dblCurrentYearTotalPayments As Double = Nothing
        Dim dblCurrentYearTotalDeposits As Double = Nothing

        dblCurrentOverallBalance = MainForm.txtOverallBalance.Text

        dblOriginalLedgerStatus = MainForm.txtLedgerStatus.Text

        dblCurrentYearTotalPayments = FormatCurrency(GetTotalPaymentsFromMonthlyGrid(dgvMonthly))

        dblCurrentYearTotalDeposits = FormatCurrency(GetTotalDepositsFromMonthlyGrid(dgvMonthly))

        dblSelectedYearStatus = dblCurrentYearTotalDeposits - dblCurrentYearTotalPayments

        dblOriginalCurrentYearTotalPayments = dblCurrentYearTotalPayments 'Sets originalCurrentYearTotalPayments to accessible variable to use with calculateWhatifAccountDetails_andDisplay()
        dblOriginalCurrentYearTotalDeposits = dblCurrentYearTotalDeposits 'Sets originalCurrentYearTotalDeposits to accessible variable to use with calculateWhatifAccountDetails_andDisplay()

        'CURRENT YEAR ACCOUNT DETAILS
        Me.txtTotalPayments.Text = FormatCurrency(dblCurrentYearTotalPayments)
        Me.txtTotalDeposits.Text = FormatCurrency(dblCurrentYearTotalDeposits)
        Me.txtYearStatus.Text = FormatCurrency(dblSelectedYearStatus)

        'OVERALL ACCOUNT DETAILS
        Me.txtOverallBalance.Text = FormatCurrency(dblCurrentOverallBalance)
        Me.txtLedgerStatus.Text = FormatCurrency(dblOriginalLedgerStatus)

        ColorTextboxes(groupTextboxesList)

    End Sub

    Sub CalculateWhatifAccountDetails_andDisplay()

        Dim dblOriginalOverallTotalPayments As Double = Nothing
        Dim dblOriginalOverallTotalDeposits As Double = Nothing
        Dim dblOriginalOverallBalance As Double = Nothing
        Dim dblStartBalance As Double = Nothing
        Dim dblOriginalLedgerStatus As Double = Nothing

        Dim dblCurrentTotalPayments_Whatif As Double = Nothing
        Dim dblCurrentTotalDeposits_Whatif As Double = Nothing

        Dim dblNewOverallTotalPayments_Whatif As Double = Nothing
        Dim dblNewOverallTotalDeposits_Whatif As Double = Nothing
        Dim dblPaymentDifference_Whatif As Double = Nothing
        Dim dblDepositDifference_Whatif As Double = Nothing
        Dim dblNewOverallBalance_Whatif As Double = Nothing
        Dim dblLedgerStatus_Whatif As Double = Nothing
        Dim dblSelectedYearStatus_Whatif As Double = Nothing

        dblOriginalOverallTotalPayments = MainForm.txtTotalPayments.Text
        dblOriginalOverallTotalDeposits = MainForm.txtTotalDeposits.Text
        dblOriginalOverallBalance = MainForm.txtOverallBalance.Text
        dblStartBalance = MainForm.txtStartingBalance.Text
        dblOriginalLedgerStatus = MainForm.txtLedgerStatus.Text

        dblCurrentTotalPayments_Whatif = GetTotalPaymentsFromMonthlyGrid(dgvMonthly)

        dblCurrentTotalDeposits_Whatif = GetTotalDepositsFromMonthlyGrid(dgvMonthly)


        dblPaymentDifference_Whatif = dblCurrentTotalPayments_Whatif - dblOriginalCurrentYearTotalPayments 'GETS THE DIFFERENCE BETWEEN THE NEW TOTAL PAYMENTS AND THE ORIGINAL TOTAL PAYMENTS

        dblDepositDifference_Whatif = dblCurrentTotalDeposits_Whatif - dblOriginalCurrentYearTotalDeposits


        'CURRENT YEAR ACCOUNT DETAILS
        dblNewOverallTotalPayments_Whatif = dblOriginalOverallTotalPayments + dblPaymentDifference_Whatif 'ADDS THE NEW HYPOTHETICAL PAYMENT DIFFERENCE FROM ABOVE TO THE ORIGINAL OVERALL PAYMENTS

        dblNewOverallTotalDeposits_Whatif = dblOriginalOverallTotalDeposits + dblDepositDifference_Whatif

        dblSelectedYearStatus_Whatif = dblCurrentTotalDeposits_Whatif - dblCurrentTotalPayments_Whatif

        'OVERALL ACCOUNT DETAILS
        If rbCurrentYear.Checked Then

            dblNewOverallBalance_Whatif = dblStartBalance + dblNewOverallTotalDeposits_Whatif - dblNewOverallTotalPayments_Whatif 'CALCULATES THE NEW OVERALL BALANCE FOR THE LEDGER AFTER ALL THE NEW HYPOTHETICAL PAYMENTS HAVE BEEN ADDED

            dblLedgerStatus_Whatif = dblOriginalLedgerStatus + (dblDepositDifference_Whatif - dblPaymentDifference_Whatif)

        Else

            dblNewOverallBalance_Whatif = dblOriginalOverallBalance + dblCurrentTotalDeposits_Whatif - dblCurrentTotalPayments_Whatif

            dblLedgerStatus_Whatif = dblOriginalLedgerStatus + dblCurrentTotalDeposits_Whatif - dblCurrentTotalPayments_Whatif

        End If

        'CURRENT YEAR ACCOUNT DETAILS
        Me.txtTotalPayments.Text = FormatCurrency(dblCurrentTotalPayments_Whatif)
        Me.txtTotalDeposits.Text = FormatCurrency(dblCurrentTotalDeposits_Whatif)
        Me.txtYearStatus.Text = FormatCurrency(dblSelectedYearStatus_Whatif)

        'OVERALL ACCOUNT DETAILS
        Me.txtOverallBalance.Text = FormatCurrency(dblNewOverallBalance_Whatif)
        Me.txtLedgerStatus.Text = FormatCurrency(dblLedgerStatus_Whatif)

        ColorTextboxes(groupTextboxesList)

    End Sub

    Sub PerformWhatifScenarioCalculations_DisplayData()

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvCategory)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvCategory)

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvMonthly)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvMonthly)

        blnCalculatingWhatif = True 'THIS VARIABLE IS USED IN MONTHLY GRID CURRENT CELL CHANGED SO IT DOESNT RUN WHATIF CALCULATION WHEN ITS NOT SUPPOSED TO.

        UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

        SumbyCategory_Whatif() 'RECALCULATES TOTALS FROM DATAGRIDVIEW VALUES

        CalculateMonthlyIncome_Whatif() 'RECALCULATES THE MONTHLY INCOME DATAGRIDVIEW

        CalculateWhatifAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

        blnCalculatingWhatif = False

        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

        MainModule.DrawingControl.ResumeDrawing(Me.dgvCategory)
        MainModule.DrawingControl.ResumeDrawing(Me.dgvMonthly)

        dgvCategory.ClearSelection()

    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click

        WriteWhatifData()

    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click

        LoadWhatifData()

    End Sub

    Sub LoadTXTDataIntoDGV(ByVal _filename As String, ByVal _dgv As DataGridView)

        _dgv.Rows.Clear()

        Dim strTextLine As String = String.Empty
        Dim arrSplitLine() As String = Nothing

        Dim objReader As New System.IO.StreamReader(_filename)

        Do While objReader.Peek() <> -1

            strTextLine = objReader.ReadLine()

            arrSplitLine = Split(strTextLine, ",")

            _dgv.Rows.Add(arrSplitLine)

        Loop

        'REFORMATS MONTHLY EXPENSES TO CURRENCY. RE-INSERTS THE COMMAS THAT WERE REPLACED WHILE WRITING TO THE COMMA SEPARATED TEXT FILE
        Dim strAmount As String = Nothing

        For j As Integer = 0 To _dgv.Rows.Count - 1

            For i As Integer = 1 To _dgv.Columns.Count - 2

                strAmount = _dgv.Item(i, j).Value.ToString()

                If strAmount = "" Then
                    strAmount = 0
                Else

                    strAmount = CDbl(strAmount)

                    _dgv.Item(i, j).Value = FormatCurrency(strAmount)

                End If

            Next

        Next

    End Sub

    Sub LoadWhatifData()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dlgFolderDialog As New FolderBrowserDialog

        dlgFolderDialog.ShowNewFolderButton = True
        dlgFolderDialog.Description = "Select a folder titled 'month-day-year_" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_Whatif Scenario'."

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory) = String.Empty Then

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

        Else

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory)

        End If

        If dlgFolderDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim strFilePath As String = String.Empty
            strFilePath = dlgFolderDialog.SelectedPath

            If Not strFilePath.Contains(System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)) Then

                CheckbookMsg.ShowMessage("The What if Scenario you selected does not belong to this ledger.", MsgButtons.OK, "", Exclamation)

            Else

                Try

                    cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECT THE MOST RECENT YEAR IN YEARLIST

                    Dim strCategoryTableFile_fullFile As String = String.Empty
                    Dim strMonthlyTableFile_fullFile As String = String.Empty
                    Dim strSelectedItem_Category_Payee_fullFile As String = String.Empty
                    Dim strSelectedItem_Payment_Deposit_fullFile As String = String.Empty

                    strCategoryTableFile_fullFile = strFilePath & "\" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_CategoryTableWhatif.whf"
                    strMonthlyTableFile_fullFile = strFilePath & "\" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_MonthlyTableWhatif.whf"
                    strSelectedItem_Category_Payee_fullFile = strFilePath & "\" & IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_SelectedItem_Categories_Payees.whf"
                    strSelectedItem_Payment_Deposit_fullFile = strFilePath & "\" & IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_SelectedItem_Payments_Deposits.whf"

                    cbCategoriesPayees.Text = ReadLineFromFile(strSelectedItem_Category_Payee_fullFile)
                    cbPaymentsDeposits.Text = ReadLineFromFile(strSelectedItem_Payment_Deposit_fullFile)

                    LoadTXTDataIntoDGV(strCategoryTableFile_fullFile, dgvCategory)

                    FormatCategoryPayeeGrid()

                    LoadTXTDataIntoDGV(strMonthlyTableFile_fullFile, dgvMonthly)

                    'IF THE USER MADE CHANGES TO THE MONTHLY INCOME TABLE BEFORE SAVING THIS CALCULATES IT AS TO INCLUDE THOSE CHANGES. 
                    'IF performWhatifScenarioCalculations_DisplayData() WAS USED, THE MONTHLY INCOME TABLE WOULD REFLECT THE CATEGORY/PAYEE TABLE 
                    CalculateMonthlyIncome_And_AverageIncome(dgvMonthly)

                    CalculateWhatifAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES
                    dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Load Error", MsgButtons.OK, "An error occurred while loading the Whatif file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                Finally

                    mnuCreateExpense.Enabled = True
                    mnuEditExpense.Enabled = True
                    mnuRemoveExpenses.Enabled = True
                    mnuRemoveCategory.Enabled = True
                    mnuCopyToNextMonth.Enabled = True
                    mnuCopyToSelectedMonths.Enabled = True
                    mnuCopyToRestOfYear.Enabled = True

                    cxmnuCreateExpense.Enabled = True
                    cxmnuEditExpense.Enabled = True
                    cxmnuRemoveExpenses.Enabled = True
                    cxmnuRemoveCategories.Enabled = True
                    cxmnuCopyToNextMonth.Enabled = True
                    cxmnuCopyToSelectedMonths.Enabled = True
                    cxmnuCopyToRestOfYear.Enabled = True

                    dgvCategory.ClearSelection()
                    dgvMonthly.ClearSelection()

                End Try

            End If

        End If

    End Sub

    Sub WriteWhatifData()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dlgFolderDialog As New FolderBrowserDialog

        dlgFolderDialog.ShowNewFolderButton = True
        dlgFolderDialog.Description = "Select a location to save your What if Scenario"

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory) = String.Empty Then

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

        Else

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory)

        End If

        If dlgFolderDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Try

                Dim strFilePath As String = String.Empty
                Dim strCategoryTableFile_fullFile As String = String.Empty
                Dim strMonthlyTableFile_fullFile As String = String.Empty
                Dim strSelectedItem_Category_Payee_fullFile As String = String.Empty
                Dim strSelectedItem_Payment_Deposit_fullFile As String = String.Empty

                Dim strWhatIfFolderName As String = String.Empty
                strWhatIfFolderName = Date.Now.ToShortDateString.Replace("/", "-") & "_" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_Whatif Scenario"

                strFilePath = dlgFolderDialog.SelectedPath & "\" & strWhatIfFolderName
                strCategoryTableFile_fullFile = strFilePath & "\" & IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_CategoryTableWhatif.whf"
                strMonthlyTableFile_fullFile = strFilePath & "\" & IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_MonthlyTableWhatif.whf"
                strSelectedItem_Category_Payee_fullFile = strFilePath & "\" & IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_SelectedItem_Categories_Payees.whf"
                strSelectedItem_Payment_Deposit_fullFile = strFilePath & "\" & IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_SelectedItem_Payments_Deposits.whf"

                If System.IO.Directory.Exists(strFilePath) Then

                    If CheckbookMsg.ShowMessage(strFilePath & " already exists", MsgButtons.YesNo, "Do you want to overwrite this Whatif Scenario?", Question) = DialogResult.Yes Then

                        My.Computer.FileSystem.DeleteFile(strCategoryTableFile_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                        My.Computer.FileSystem.DeleteFile(strMonthlyTableFile_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                        My.Computer.FileSystem.DeleteFile(strSelectedItem_Category_Payee_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                        My.Computer.FileSystem.DeleteFile(strSelectedItem_Payment_Deposit_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)

                        WriteDGVDataToTextFile(dgvCategory, strCategoryTableFile_fullFile)
                        WriteDGVDataToTextFile(dgvMonthly, strMonthlyTableFile_fullFile)

                        Dim strSelectedItem As String = String.Empty

                        strSelectedItem = cbCategoriesPayees.Text
                        WriteLineToFile(strSelectedItem, strSelectedItem_Category_Payee_fullFile)

                        strSelectedItem = cbPaymentsDeposits.Text
                        WriteLineToFile(strSelectedItem, strSelectedItem_Payment_Deposit_fullFile)

                        CheckbookMsg.ShowMessage("The Whatif Scenario was overwritten successfully.", MsgButtons.OK, "")

                    End If

                Else

                    My.Computer.FileSystem.CreateDirectory(strFilePath)

                    WriteDGVDataToTextFile(dgvCategory, strCategoryTableFile_fullFile)
                    WriteDGVDataToTextFile(dgvMonthly, strMonthlyTableFile_fullFile)

                    Dim strSelectedItem As String = String.Empty

                    strSelectedItem = cbCategoriesPayees.Text
                    WriteLineToFile(strSelectedItem, strSelectedItem_Category_Payee_fullFile)

                    strSelectedItem = cbPaymentsDeposits.Text
                    WriteLineToFile(strSelectedItem, strSelectedItem_Payment_Deposit_fullFile)

                    CheckbookMsg.ShowMessage("The Whatif Scenario was saved successfully.", MsgButtons.OK, "")

                End If

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Save Error", MsgButtons.OK, "An error occurred while saving the Whatif file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

            Finally

                FileClose(1)

            End Try

        End If

    End Sub

    Sub WriteDGVDataToTextFile(ByVal _dgv As DataGridView, ByVal _filename As String)

        Dim I As Integer = 0
        Dim j As Integer = 0
        Dim strCellValue As String = String.Empty
        Dim strRowLine As String = String.Empty

        Dim objWriter As New System.IO.StreamWriter(_filename, True)

        For j = 0 To (_dgv.Rows.Count - 1)

            For I = 0 To (_dgv.Columns.Count - 1)

                If Not TypeOf _dgv.CurrentRow.Cells.Item(I).Value Is DBNull Then

                    strCellValue = _dgv.Item(I, j).Value
                    strCellValue = strCellValue.Replace(",", "")

                Else
                    strCellValue = ""
                End If

                strRowLine = strRowLine & strCellValue & ","

            Next

            objWriter.WriteLine(strRowLine)

            strRowLine = ""

        Next

        objWriter.Close()

    End Sub

    Private Sub dgvMonthly_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvMonthly.CurrentCellChanged

        dgvMonthly.EndEdit(True)
        dgvMonthly.ReadOnly = True

        If blnCalculatingWhatif = True Then

            CalculateMonthlyIncome_And_AverageIncome(dgvMonthly)

            CalculateWhatifAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

        End If

    End Sub

    Private Sub dgvMonthly_DoubleClick(sender As Object, e As EventArgs) Handles dgvMonthly.DoubleClick

        If blnSelectedYearIsMostRecentYear Then

            blnCalculatingWhatif = True

            dgvMonthly.ReadOnly = False

            dgvMonthly.Columns("Payments").ReadOnly = False
            dgvMonthly.Columns("Deposits").ReadOnly = False

            dgvMonthly.CurrentCell.Style.ForeColor = Color.Black

            dgvMonthly.Columns("Month").ReadOnly = True
            dgvMonthly.Columns("Monthly").ReadOnly = True
            dgvMonthly.Columns("AveMonthlyIncome").ReadOnly = True

            dgvMonthly.BeginEdit(True)

        End If

    End Sub

    Private Sub rbCurrentYear_CheckedChanged(sender As Object, e As EventArgs) Handles rbCurrentYear.CheckedChanged

        CalculateWhatifAccountDetails_andDisplay()

    End Sub

    Private Sub rbNextYear_CheckedChanged(sender As Object, e As EventArgs) Handles rbNextYear.CheckedChanged

        CalculateWhatifAccountDetails_andDisplay()

    End Sub

    Private Sub CreateEmptyScenario() Handles mnuCreateEmptyWhatif.Click, cxmnuCreateEmptyScenario.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strConfirmationMessage As String = String.Empty
        Dim strInfoMessage As String = String.Empty
        Dim strPaymentsOrDeposits As String = String.Empty
        Dim strFormTitle As String = String.Empty

        strPaymentsOrDeposits = cbPaymentsDeposits.Text
        strInfoMessage = "This monthly total will be applied to each month for inclusion in your calculations."

        cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

        gbFilterOptions.Enabled = False

        dgvCategory.Rows.Clear()

        If strPaymentsOrDeposits = "Payments" Then

            strFormTitle = "Monthly Deposits"
            strConfirmationMessage = "Would you like to include your monthly deposits? If you know how much you make each month you can enter it now." & vbNewLine & vbNewLine & "You can edit the values in the monthly income table at any time. Select the values in the monthly income table you want to edit, right click and select 'Edit Selected Totals'."

            For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                dgvRow.Cells("Deposits").Value = "$0.00"

            Next

        Else

            strFormTitle = "Monthly Payments"
            strConfirmationMessage = "Would you like to include your monthly payments? If you know how much you spend each month you can enter it now." & vbNewLine & vbNewLine & "You can edit the values in the monthly income table at any time. Select the values in the monthly income table you want to edit, right click and select 'Edit Selected Totals'."

            For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                dgvRow.Cells("Payments").Value = "$0.00"

            Next

        End If

        PerformWhatifScenarioCalculations_DisplayData()

        If CheckbookMsg.ShowMessage(strConfirmationMessage, MsgButtons.YesNo, strInfoMessage, Question) = DialogResult.Yes Then

            Dim new_frmEditValues As New frmEditValues
            Dim dblMonthlyAmount As Double = Nothing

            new_frmEditValues.Text = strFormTitle
            new_frmEditValues.lblNewAmount.Text = "Amount"
            new_frmEditValues.btnUpdate.Text = "OK"

            If new_frmEditValues.ShowDialog() = DialogResult.OK Then

                dblMonthlyAmount = new_frmEditValues.txtNewExpenseValue.Text

                If strPaymentsOrDeposits = "Payments" Then

                    For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                        dgvRow.Cells("Deposits").Value = FormatCurrency(dblMonthlyAmount)

                    Next

                Else

                    For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                        dgvRow.Cells("Payments").Value = FormatCurrency(dblMonthlyAmount)

                    Next

                End If

            End If

        End If

        PerformWhatifScenarioCalculations_DisplayData()

    End Sub

    ''' <summary>
    ''' Writes a line of text to a specified file. Can be used to write multiple lines to a file.
    ''' </summary>
    ''' <param name="_line"></param>
    ''' <param name="_file"></param>
    Private Sub WriteLineToFile(ByVal _line As String, ByVal _file As String)

        Dim writer As New IO.StreamWriter(_file, True)

        writer.WriteLine(_line)

        writer.Close()

    End Sub

    ''' <summary>
    ''' Returns the last line of text in a specified file. Only useful for reading a file with one line.
    ''' </summary>
    ''' <param name="_file"></param>
    Private Function ReadLineFromFile(ByVal _file As String) As String

        Dim reader As New IO.StreamReader(_file)
        Dim strLine As String = String.Empty

        Do While reader.Peek() <> -1

            strLine = reader.ReadLine

        Loop

        reader.Close()

        Return strLine
    End Function

    Private Sub cxmnuEditValues_Click(sender As Object, e As EventArgs) Handles cxmnuEditValues.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strConfirmRemoveMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty
        Dim strErrorMessageTitle As String = String.Empty

        strInvalidSelectionMessage = "Select only the monthly totals you want to edit"
        strErrorMessageTitle = "Edit Monthly Total Error"
        strNoneSelectedMessage = "There are no totals selected to edit"
        strConfirmRemoveMessage = "Are you sure you want to make all the selected monthly totals "
        strErrorMessage = "An error occurred while editing the monthly totals"

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvMonthly.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvMonthly.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(3) Or columnIndexList.Contains(4) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                Dim new_frmEditValues As New frmEditValues
                new_frmEditValues.Text = "Edit Monthly Totals"
                Dim strNewValue As String = String.Empty

                If new_frmEditValues.ShowDialog = Windows.Forms.DialogResult.OK Then

                    strNewValue = FormatCurrency(new_frmEditValues.txtNewExpenseValue.Text)

                    If CheckbookMsg.ShowMessage(strConfirmRemoveMessage & strNewValue & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                        UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

                        Try

                            EditMonthlyIncomeCells(strNewValue)

                        Catch ex As Exception

                            CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                        Finally

                            UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

                        End Try

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub cxmnuRemoveValues_Click(sender As Object, e As EventArgs) Handles cxmnuRemoveValues.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strConfirmRemoveMessage As String = String.Empty
        Dim strErrorMessage As String = String.Empty
        Dim strErrorMessageTitle As String = String.Empty

        strInvalidSelectionMessage = "Select only the monthly totals you want to remove"
        strErrorMessageTitle = "Remove Monthly Total Error"
        strNoneSelectedMessage = "There are no totals selected to remove"
        strConfirmRemoveMessage = "Are you sure you want to remove the selected totals?"
        strErrorMessage = "An error occurred while removing the monthly totals"

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvMonthly.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvMonthly.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(3) Or columnIndexList.Contains(4) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

                    Try

                        EditMonthlyIncomeCells("$0.00")

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub EditMonthlyIncomeCells(ByVal newValue As String)

        For Each dgvSelectedCell As DataGridViewCell In dgvMonthly.SelectedCells

            dgvSelectedCell.Value = newValue

        Next

        CalculateMonthlyIncome_And_AverageIncome(dgvMonthly)

        CalculateWhatifAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim webAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/spending_overview.html"
        Process.Start(webAddress)

    End Sub

    Private Sub mnuDonutChart_Click(sender As Object, e As EventArgs) Handles mnuCharts.Click

        Dim new_frmDonutChart As New frmCharts
        new_frmDonutChart.caller_frmSpendingOverview = Me
        new_frmDonutChart.ShowDialog()

    End Sub

    Private Sub mnuExportCategoryPayeeTable_Click(sender As Object, e As EventArgs) Handles mnuExportCategoryPayeeTable.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If dgvCategory.Rows.Count = 0 Then

            CheckbookMsg.ShowMessage("Your table does not have any totals to export", MsgButtons.OK, "", Exclamation)

        Else

            Dim strCurrentFile As String = String.Empty
            strCurrentFile = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)

            Dim sfdDialog As New SaveFileDialog
            sfdDialog.Title = "Export monthly totals to csv file"
            sfdDialog.FileName = strCurrentFile & "_Export"
            sfdDialog.Filter = "csv files (*.csv)|*.csv"

            If GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory) = String.Empty Then

                sfdDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            Else

                sfdDialog.InitialDirectory = GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory)

            End If

            If sfdDialog.ShowDialog = DialogResult.OK Then

                Dim file As String = String.Empty
                file = sfdDialog.FileName

                If CheckbookMsg.ShowMessage("Are you sure you want to export your monthly totals to " & file & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        UIManager.SetCursor(Me, Cursors.WaitCursor)

                        ExportSpendingOverview(file)

                        UIManager.SetCursor(Me, Cursors.Default)

                        If CheckbookMsg.ShowMessage("Your monthly totals have exported successfully.", MsgButtons.YesNo, "Would you like to open the file now?", Question) = DialogResult.Yes Then

                            Process.Start(file)

                        End If

                    Catch exIOException As System.IO.IOException

                        CheckbookMsg.ShowMessage("Export Error", MsgButtons.OK, "The file you are trying to export to may be open. Make sure the file is closed and try exporting again. If it is not open  please see the message below." & vbNewLine & vbNewLine & exIOException.Message & vbNewLine & vbNewLine & exIOException.Source, Exclamation)

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Export Error", MsgButtons.OK, "An error occurred while exporting your monthly totals. Please see the message below." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default)

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub ExportSpendingOverview(ByVal _file As String)

        Dim writer As New StreamWriter(_file)

        'EXPORT CATEGORY/PAYEE TABLE
        Dim strColumnHeaders_Category_Payee_Table As String = String.Empty

        Dim category_payee As String = String.Empty
        Dim category_payee_column_name As String = String.Empty

        If cbCategoriesPayees.SelectedItem.ToString = "Categories" Then
            category_payee = "CATEGORY"
            category_payee_column_name = "Category"
        Else
            category_payee = "PAYEE"
            category_payee_column_name = "Payee"
        End If

        strColumnHeaders_Category_Payee_Table = category_payee & ",JANUARY,FEBRUARY,MARCH,APRIL,MAY,JUNE,JULY,AUGUST,SEPTEMBER,OCTOBER,NOVEMBER,DECEMBER" & Environment.NewLine

        writer.Write(strColumnHeaders_Category_Payee_Table)

        For Each dgvRow As DataGridViewRow In dgvCategory.Rows

            Dim strEntry As String = String.Empty

            Dim strCategoryPayee As String = String.Empty
            Dim strJanuary As String = String.Empty
            Dim strFebruary As String = String.Empty
            Dim strMarch As String = String.Empty
            Dim strApril As String = String.Empty
            Dim strMay As String = String.Empty
            Dim strJune As String = String.Empty
            Dim strJuly As String = String.Empty
            Dim strAugust As String = String.Empty
            Dim strSeptember As String = String.Empty
            Dim strOctober As String = String.Empty
            Dim strNovember As String = String.Empty
            Dim strDecember As String = String.Empty

            strCategoryPayee = dgvRow.Cells.Item(category_payee_column_name).Value.ToString
            strJanuary = dgvRow.Cells.Item("January").Value.ToString
            strFebruary = dgvRow.Cells.Item("February").Value.ToString
            strMarch = dgvRow.Cells.Item("March").Value.ToString
            strApril = dgvRow.Cells.Item("April").Value.ToString
            strMay = dgvRow.Cells.Item("May").Value.ToString
            strJune = dgvRow.Cells.Item("June").Value.ToString
            strJuly = dgvRow.Cells.Item("July").Value.ToString
            strAugust = dgvRow.Cells.Item("August").Value.ToString
            strSeptember = dgvRow.Cells.Item("September").Value.ToString
            strOctober = dgvRow.Cells.Item("October").Value.ToString
            strNovember = dgvRow.Cells.Item("November").Value.ToString
            strDecember = dgvRow.Cells.Item("December").Value.ToString

            strCategoryPayee = strCategoryPayee.Replace(",", "")
            strJanuary = strJanuary.Replace(",", "")
            strFebruary = strFebruary.Replace(",", "")
            strMarch = strMarch.Replace(",", "")
            strApril = strApril.Replace(",", "")
            strMay = strMay.Replace(",", "")
            strJune = strJune.Replace(",", "")
            strJuly = strJuly.Replace(",", "")
            strAugust = strAugust.Replace(",", "")
            strSeptember = strSeptember.Replace(",", "")
            strOctober = strOctober.Replace(",", "")
            strNovember = strNovember.Replace(",", "")
            strDecember = strDecember.Replace(",", "")

            strEntry = strCategoryPayee & "," & strJanuary & "," & strFebruary & "," & strMarch & "," & strApril & "," & strMay & "," & strJune & "," & strJuly & "," & strAugust & "," & strSeptember & "," & strOctober & "," & strNovember & "," & strDecember & Environment.NewLine

            writer.Write(strEntry)

        Next

        'EXPORT SPACES BETWEEN TABLES
        writer.WriteLine("")
        writer.WriteLine("")
        writer.WriteLine("")
        writer.WriteLine("")

        'EXPORT MONTHY INCOME TABLE
        Dim strColumnHeaders_Monthly_Income As String = String.Empty

        strColumnHeaders_Monthly_Income = "MONTH,PAYMENTS,DEPOSITS,MONTHY INCOME,AVERAGE INCOME" & Environment.NewLine

        writer.Write(strColumnHeaders_Monthly_Income)

        For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

            Dim strEntry As String = String.Empty

            Dim strMonth As String = String.Empty
            Dim strPayments As String = String.Empty
            Dim strDeposits As String = String.Empty
            Dim strMonthlyIncome As String = String.Empty
            Dim strAverageIncome As String = String.Empty

            strMonth = dgvRow.Cells.Item("Month").Value.ToString
            strPayments = dgvRow.Cells.Item("Payments").Value.ToString
            strDeposits = dgvRow.Cells.Item("Deposits").Value.ToString
            strMonthlyIncome = dgvRow.Cells.Item("Monthly").Value.ToString
            strAverageIncome = dgvRow.Cells.Item("AveMonthlyIncome").Value.ToString

            strMonth = strMonth.Replace(",", "")
            strPayments = strPayments.Replace(",", "")
            strDeposits = strDeposits.Replace(",", "")
            strMonthlyIncome = strMonthlyIncome.Replace(",", "")
            strAverageIncome = strAverageIncome.Replace(",", "")

            strEntry = strMonth & "," & strPayments & "," & strDeposits & "," & strMonthlyIncome & "," & strAverageIncome & Environment.NewLine

            writer.Write(strEntry)

        Next

        writer.Close()

    End Sub

    Private Sub mnuSumSelected_Click(sender As Object, e As EventArgs) Handles mnuSumSelected.Click, cxmnuSumSelected.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedItemCount As Integer = Nothing
        intSelectedItemCount = dgvCategory.SelectedCells.Count
        
        Dim dblTotal As Double = Nothing
        Dim dblAverage As Double = Nothing
        Dim intItemCounter As Integer = Nothing

        If intSelectedItemCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to calculate", MsgButtons.OK, "", Exclamation)

        Else
            
            For each cell As DataGridViewCell In dgvCategory.SelectedCells

                If Not cell.Value = Nothing Then

                    dblTotal += cell.Value
                    intItemCounter += 1

                End If
                
            Next

            dblAverage = dblTotal / intItemCounter

            Dim strMessage As String = "Total: " & FormatCurrency(dblTotal) & vbNewLine & "Average: " & FormatCurrency(dblAverage)

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, "")

        End If
        
    End Sub

End Class