'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2018 Christopher Mackay

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
    Private blnIsCalculatingScenario As Boolean = False
    Private blnSelectedYearIsMostRecentYear As Boolean = False
    Private blnFORM_IS_LOADING As Boolean = False
    Private blnIsCalculatingCurrentYear As Boolean = True
    Private currentHypotheticalYear As Integer = 0
    Private blnIsWorkingInScenario As Boolean = False

    'OVERALL ACCOUNT DETAILS
    Private dblOverallTotalPayments_Saved As Double = 0
    Private dblOverallTotalDeposits_Saved As Double = 0
    Private dblOverallBalance_Saved As Double = 0

    'CURRENT YEAR DETAILS
    Private dblCurrentYearPayments_Saved As Double = 0
    Private dblCurrentYearDeposits_Saved As Double = 0

    Private Sub frmSpendingOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        blnFORM_IS_LOADING = True
        UIManager.SetCursor(Me, Cursors.WaitCursor)

        Dim colorRenderer_Professional As New clsUIManager.MyProfessionalRenderer

        mnuMenuStrip.Renderer = colorRenderer_Professional
        cxmnuScenario.Renderer = colorRenderer_Professional

        Dim spendingOverviewControlsList As New List(Of Control)

        For Each ctrl As Control In Me.Controls

            spendingOverviewControlsList.Add(ctrl)

        Next

        UIManager.SetGroupObjects_List_Visible(spendingOverviewControlsList, False)
        MainModule.DrawingControl.SetDoubleBuffered_ListControls(spendingOverviewControlsList)
        MainModule.DrawingControl.SuspendDrawing_ListControls(spendingOverviewControlsList)

        cxmnuScenario.Renderer = colorRenderer_Professional
        cxmnuMonthlyIncomeTable.Renderer = colorRenderer_Professional

        cbCategoriesPayees.Text = "Categories"
        cbPaymentsDeposits.Text = "Payments"

        Clear_Add_FormatCategoryPayeeColumns() 'CLEARS ALL THE COLUMNS AND CREATES THEM PROGRAMMATICALLY

        'ADDS ALL TEXTBOXES THAT NEED TO BE COLORED INTO A GROUP
        groupTextboxesList.Add(txtOverallBalance)
        groupTextboxesList.Add(txtCurrentYearStatus)
        groupTextboxesList.Add(txtOverallLedgerStatus)

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

        '-----------------------------------------------
        'SET ALL SCENARIO CONTROLS TO DISABLED
        DisableScenarioCommands()
        '-----------------------------------------------

    End Sub

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

        dgvCategory.Columns.Add(colCategory_Payee)
        dgvCategory.Columns.Add(colJanuary)
        dgvCategory.Columns.Add(colFebruary)
        dgvCategory.Columns.Add(colMarch)
        dgvCategory.Columns.Add(colApril)
        dgvCategory.Columns.Add(colMay)
        dgvCategory.Columns.Add(colJune)
        dgvCategory.Columns.Add(colJuly)
        dgvCategory.Columns.Add(colAugust)
        dgvCategory.Columns.Add(colSeptember)
        dgvCategory.Columns.Add(colOctober)
        dgvCategory.Columns.Add(colNovember)
        dgvCategory.Columns.Add(colDecember)
        dgvCategory.Columns.Add(colTotals)
        dgvCategory.Columns.Add(colPercent)

        Format_Category_Payee_Datagridview()

        MainModule.DrawingControl.ResumeDrawing(Me.dgvCategory)

    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged, mnuResetToLedgerData.Click, cxmnuResetToLedgerData.Click, cbCategoriesPayees.SelectedIndexChanged, cbPaymentsDeposits.SelectedIndexChanged

        dgvCategory.ScrollBars = ScrollBars.None

        m_CategoriesPayees = cbCategoriesPayees.SelectedItem.ToString

        blnIsCalculatingScenario = False 'SETS THIS BECAUSE IT IS NOT CALCULATING SCENARIO TOTALS
        blnIsCalculatingCurrentYear = True
        blnIsWorkingInScenario = False

        If Not yearList.Count = 0 Then

            If Not CInt(cbYear.SelectedItem) = yearList.Max Then 'GREATEST YEAR IN LEDGER IS NOT SELECTED

                If Not cbYear.SelectedIndex < 0 Then

                    gbCurrentYear.Text = "Current Year Details (" & cbYear.SelectedItem.ToString & ")"
                    gbOverallDetails.Text = "Overall Account Details (" & cbYear.SelectedItem.ToString & ")"

                End If

                blnSelectedYearIsMostRecentYear = False

            Else 'GREATEST YEAR IN LEDGER IS SELECTED

                If Not cbYear.SelectedIndex < 0 Then

                    currentHypotheticalYear = cbYear.SelectedItem

                    gbCurrentYear.Text = "Current Year Details (" & currentHypotheticalYear & ")"
                    gbOverallDetails.Text = "Overall Account Details (" & currentHypotheticalYear & ")"

                End If

                blnSelectedYearIsMostRecentYear = True

            End If

            DisableScenarioCommands()

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
                mnuResetToLedgerData.Text = "Reset Expenses Back To " & yearList.Max
                cxmnuResetToLedgerData.Text = "Reset Expenses Back To " & yearList.Max

            Else

                mnuCreateExpense.Text = "Create Monthly Income"
                cxmnuCreateExpense.Text = "Create Monthly Income"
                mnuEditExpense.Text = "Edit Incomes"
                cxmnuEditExpense.Text = "Edit Incomes"
                mnuRemoveExpenses.Text = "Remove Incomes"
                cxmnuRemoveExpenses.Text = "Remove Incomes"
                mnuResetToLedgerData.Text = "Reset Incomes Back To " & yearList.Max
                cxmnuResetToLedgerData.Text = "Reset Incomes Back To " & yearList.Max

            End If

        End If

        Clear_Add_FormatCategoryPayeeColumns() 'CLEARS ALL THE COLUMNS AND CREATES THEM PROGRAMMATICALLY

        Me.dgvCategory.Rows.Clear()

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        If Not blnFORM_IS_LOADING Then
            UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR
        End If

        If cbPaymentsDeposits.Text = "Payments" Then

            DetermineCategoriesAndPayeesbyYear_Payments(intSelectedYear)

        Else

            DetermineCategoriesAndPayeesbyYear_Deposits(intSelectedYear)

        End If

        CalculateMonthlyIncome_FromLedger()
        CalculateAccountDetails_andDisplay()

        Dim jan As String = ""
        Dim feb As String = ""
        Dim mar As String = ""
        Dim apr As String = ""
        Dim may As String = ""
        Dim jun As String = ""
        Dim jul As String = ""
        Dim aug As String = ""
        Dim sep As String = ""
        Dim oct As String = ""
        Dim nov As String = ""
        Dim dec As String = ""
        Dim tot As String = ""

        If cbCategoriesPayees.Text = "Categories" Then

            For Each strCategory As String In m_globalUsedCategoryCollection

                SumMonthly(strCategory, intSelectedYear, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec, tot)

                dgvCategory.Rows.Add(strCategory, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec, tot, Calculate_Category_Payee_Percentage(tot, GetTotalPaymentsFromMonthlyGrid(dgvMonthly), GetTotalDepositsFromMonthlyGrid(dgvMonthly)))

            Next

        Else

            For Each strPayee As String In m_globalUsedPayeeCollection

                SumMonthly(strPayee, intSelectedYear, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec, tot)

                dgvCategory.Rows.Add(strPayee, jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec, tot, Calculate_Category_Payee_Percentage(tot, GetTotalPaymentsFromMonthlyGrid(dgvMonthly), GetTotalDepositsFromMonthlyGrid(dgvMonthly)))

            Next

        End If

        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

        If Not blnFORM_IS_LOADING Then
            UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR
        End If

        dgvCategory.ClearSelection()

        dgvCategory.ScrollBars = ScrollBars.Both

    End Sub

    Sub SumMonthly(ByVal _item As String, ByVal _year As Integer, ByRef _jan As String,
                                                                  ByRef _feb As String,
                                                                  ByRef _mar As String,
                                                                  ByRef _apr As String,
                                                                  ByRef _may As String,
                                                                  ByRef _jun As String,
                                                                  ByRef _jul As String,
                                                                  ByRef _aug As String,
                                                                  ByRef _sep As String,
                                                                  ByRef _oct As String,
                                                                  ByRef _nov As String,
                                                                  ByRef _dec As String,
                                                                  ByRef _total As String)

        Dim jan As Double = 0
        Dim feb As Double = 0
        Dim mar As Double = 0
        Dim apr As Double = 0
        Dim may As Double = 0
        Dim jun As Double = 0
        Dim jul As Double = 0
        Dim aug As Double = 0
        Dim sep As Double = 0
        Dim oct As Double = 0
        Dim nov As Double = 0
        Dim dec As Double = 0
        Dim tot As Double = 0

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strCategory As String = String.Empty
            Dim strPayee As String = String.Empty
            Dim strTransactionAmount As String = String.Empty
            Dim dtDate As Date = Nothing

            Dim strPayment As String = ""
            Dim strDeposit As String = ""

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

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If strTransactionAmount = "" Then
                strTransactionAmount = 0
            Else
                strTransactionAmount = CDbl(strTransactionAmount)
            End If

            If strCategory = _item And dtDate.Month = 1 And dtDate.Year = _year Then
                jan += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 2 And dtDate.Year = _year Then
                feb += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 3 And dtDate.Year = _year Then
                mar += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 4 And dtDate.Year = _year Then
                apr += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 5 And dtDate.Year = _year Then
                may += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 6 And dtDate.Year = _year Then
                jun += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 7 And dtDate.Year = _year Then
                jul += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 8 And dtDate.Year = _year Then
                aug += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 9 And dtDate.Year = _year Then
                sep += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 10 And dtDate.Year = _year Then
                oct += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 11 And dtDate.Year = _year Then
                nov += strTransactionAmount
                tot += strTransactionAmount
            ElseIf strCategory = _item And dtDate.Month = 12 And dtDate.Year = _year Then
                dec += strTransactionAmount
                tot += strTransactionAmount
            End If

            If jan = 0 Then _jan = "" Else _jan = FormatCurrency(jan)
            If feb = 0 Then _feb = "" Else _feb = FormatCurrency(feb)
            If mar = 0 Then _mar = "" Else _mar = FormatCurrency(mar)
            If apr = 0 Then _apr = "" Else _apr = FormatCurrency(apr)
            If may = 0 Then _may = "" Else _may = FormatCurrency(may)
            If jun = 0 Then _jun = "" Else _jun = FormatCurrency(jun)
            If jul = 0 Then _jul = "" Else _jul = FormatCurrency(jul)
            If aug = 0 Then _aug = "" Else _aug = FormatCurrency(aug)
            If sep = 0 Then _sep = "" Else _sep = FormatCurrency(sep)
            If oct = 0 Then _oct = "" Else _oct = FormatCurrency(oct)
            If nov = 0 Then _nov = "" Else _nov = FormatCurrency(nov)
            If dec = 0 Then _dec = "" Else _dec = FormatCurrency(dec)

            If tot = 0 Then _total = String.Empty Else _total = FormatCurrency(tot)

        Next

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

                    PerformScenarioCalculations_DisplayData()

                End If

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try


    End Sub

    Private Sub CopyToNextMonth(sender As Object, e As EventArgs) Handles mnuCopyToNextMonth.Click, cxmnuCopyToNextMonth.Click

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

                PerformScenarioCalculations_DisplayData()

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try

    End Sub

    Private Sub CopyToRestOfYear(sender As Object, e As EventArgs) Handles mnuCopyToRestOfYear.Click, cxmnuCopyToRestOfYear.Click

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

                PerformScenarioCalculations_DisplayData()

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try

    End Sub

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

    Sub Sum_Category_Payee_Datagridview() 'CALCULATES TOTALS PER CATEGORY FROM THE CATEGORY DATAGRIDVIEW. USED TO CALCULATE NEW HYPOTHETICAL PAYMENT TOTALS

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

            dgvCategory.Item("Percent", k).Value = CatPercent_Scenario(dblCategoryTotal, dblNewTotal) 'CALCULATES NEW PERCENT BY CATEGORY AND SETS ITS VALUE IN THE "PERCENT" COLUMN

        Next

    End Sub

    Function Calculate_Category_Payee_Percentage(ByVal _categoryTotal As Double, ByVal _totalPayments As Double, _totalDeposits As Double) As String

        Dim dblPercent As Double = 0

        If cbPaymentsDeposits.Text = "Payments" Then

            dblPercent = Math.Round((_categoryTotal / _totalPayments) * 100, 2).ToString

        Else

            dblPercent = Math.Round((_categoryTotal / _totalDeposits) * 100, 2).ToString

        End If

        Return dblPercent & "%"
    End Function

    Function CatPercent_Scenario(ByVal categoryTotal As Double, ByVal newTotal As Double) As String 'CALCULATES NEW CATEGORY PERCENT BASED ON NEW TOTAL PAYMENTS

        Dim dblPercent As Double = Nothing

        dblPercent = Math.Round((categoryTotal / newTotal) * 100, 2).ToString

        Return dblPercent & "%"
    End Function

    Sub Format_Category_Payee_Datagridview()

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

                PerformScenarioCalculations_DisplayData() 'PERFORMS ALL CALCULATIONS AND DISPLAYS THE NEW HYPOTHETICAL DATA

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
        Dim strAdvice As String = String.Empty

        strAdvice = "Select values ranging from January to December"

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

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, strAdvice, Exclamation)

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

                            PerformScenarioCalculations_DisplayData() 'PERFORMS ALL CALCULATIONS AND DISPLAYS THE NEW HYPOTHETICAL DATA

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

            Dim strPayments As String
            Dim strDeposits As String

            Dim dblPayments As Double
            Dim dblDeposits As Double

            SumMonthlyPaymentAndDeposits_FromLedger(strMonth, intSelectedYear, dblPayments, dblDeposits)

            strPayments = FormatCurrency(dblPayments)
            strDeposits = FormatCurrency(dblDeposits)

            'FILLS MONTHLY DATAGRID VIEW WITH MONTH, TOTAL PAYMENTS PER MONTH, TOTAL DEPOSITS PER MONTH, MONTHLY STATUS
            dgvMonthly.Rows.Add(strMonth, strPayments, strDeposits)

        Next

        CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

        dgvMonthly.ClearSelection()

    End Sub 'CALCULATES MONTHLY INCOME BASED ON YEAR

    Sub CalculateMonthlyIncome_Scenario()

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

        If blnIsCalculatingCurrentYear Then

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        Else

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        End If

        dgvMonthly.ClearSelection()

    End Sub  'RECALCULATES MONTHLY INCOME BASED ON NEWLY CREATED MONTHLY EXPENSE

    Function SumAmountsMonthly_SpendingOverview(ByVal _month As String)

        Dim dblTotal As Double = Nothing

        For i As Integer = 0 To dgvCategory.RowCount - 1

            Dim strAmount As String = String.Empty

            strAmount = dgvCategory.Item(_month, i).Value.ToString 'GET TOTALS BY CATEGORY

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
        Dim strAdvice As String = String.Empty

        strAdvice = "Select values ranging from January to December"

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

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, strAdvice, Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

                    Try

                        For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                            dgvSelectedCell.Value = ""

                        Next

                        PerformScenarioCalculations_DisplayData()

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

                        PerformScenarioCalculations_DisplayData()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

                    End Try

                End If

            End If

        End If

    End Sub

    Sub CalculateAccountDetails_andDisplay()

        Dim intSelectedYear As Integer = 0
        Dim dblOverallTotalPayments_Prior_To_Selected_Year As Double = 0
        Dim dblOverallTotalDeposits_Prior_To_Selected_Year As Double = 0

        intSelectedYear = cbYear.SelectedItem

        'THE VALUES IN THE CATEGORY/PAYEE DATAGRIDVIEW REPLACE THE VALUES FROM THE MOST RECENT YEAR IN THE LEDGER
        'CALCULATES TOTAL PAYMENTS AND DEPOSITS PRIOR TO THE MOST RECENT YEAR
        'THESE ARE ADDED TO THE NEW VALUES PROVIDED IN THE DATAGRIDVIEW
        'FOR EXAMPLE IF 2015, 2016, AND 2017 EXIST IN THE LEDGER, TOTAL PAYMENTS AND DEPOSITS FROM 2015 AND 2016 ARE STORED IN dblOverallTotalPayments_Prior_To_Selected_Year & dblOverallTotalDeposits_Prior_To_Selected_Year
        '2017 WOULD BE THE YEAR THAT IS BEING EDITED IN THE DATAGRIDVIEW
        CalculateTotalPayments_Deposits_BeforeProvidedYear(intSelectedYear, dblOverallTotalPayments_Prior_To_Selected_Year, dblOverallTotalDeposits_Prior_To_Selected_Year)

#Region "Current Year Details"

        Dim dblStartBalance As Double = 0
        dblStartBalance = MainForm.txtStartingBalance.Text

        Dim dblCurrentYearPayments As Double = 0
        Dim dblCurrentYearDeposits As Double = 0
        Dim dblOverallBalance As Double = 0

        dblCurrentYearPayments = GetTotalPaymentsFromMonthlyGrid(dgvMonthly)
        dblCurrentYearDeposits = GetTotalDepositsFromMonthlyGrid(dgvMonthly)

        dblOverallBalance = dblStartBalance - (dblOverallTotalPayments_Prior_To_Selected_Year + dblCurrentYearPayments) + (dblOverallTotalDeposits_Prior_To_Selected_Year + dblCurrentYearDeposits)

        Dim dblCurrentYearStatus As Double = 0
        dblCurrentYearStatus = dblCurrentYearDeposits - dblCurrentYearPayments

        'SET CURRENT YEAR DETAILS
        txtCurrentYearPayments.Text = FormatCurrency(dblCurrentYearPayments)    'CURRENT YEAR PAYMENTS
        txtCurrentYearDeposits.Text = FormatCurrency(dblCurrentYearDeposits)    'CURRENT YEAR DEPOSITS
        txtCurrentYearStatus.Text = FormatCurrency(dblCurrentYearStatus)        'CURRENT YEAR STATUS

#End Region

#Region "Overall Account Details"

        'OVERALL ACCOUNT DETAILS
        If blnIsCalculatingCurrentYear Then 'CALCULATING CURRENT YEAR

            Dim dblOverallLedgerStatus As Double = 0
            Dim dblOverallTotalPayments As Double = 0
            Dim dblOverallTotalDeposits As Double = 0

            dblOverallTotalPayments = dblOverallTotalPayments_Prior_To_Selected_Year + dblCurrentYearPayments
            dblOverallTotalDeposits = dblOverallTotalDeposits_Prior_To_Selected_Year + dblCurrentYearDeposits
            dblOverallLedgerStatus = dblOverallTotalDeposits - dblOverallTotalPayments

            txtOverallTotalPayments.Text = FormatCurrency(dblOverallTotalPayments)
            txtOverallTotalDeposits.Text = FormatCurrency(dblOverallTotalDeposits)
            txtOverallBalance.Text = FormatCurrency(dblOverallBalance)
            txtOverallLedgerStatus.Text = FormatCurrency(dblOverallLedgerStatus)

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear) 'CALCULATES AND FILLS THE MONTHLY INCOME DATAGRIDVIEW

        Else 'CALCULATING NEXT YEAR

            Dim dblOverallLedgerStatus As Double = 0
            Dim dblOverallTotalPayments As Double = 0
            Dim dblOverallTotalDeposits As Double = 0

            dblOverallTotalPayments = dblOverallTotalPayments_Saved + dblCurrentYearPayments
            dblOverallTotalDeposits = dblOverallTotalDeposits_Saved + dblCurrentYearDeposits
            dblOverallBalance = dblStartBalance - dblOverallTotalPayments + dblOverallTotalDeposits
            dblOverallLedgerStatus = dblOverallTotalDeposits - dblOverallTotalPayments

            txtOverallTotalPayments.Text = FormatCurrency(dblOverallTotalPayments)
            txtOverallTotalDeposits.Text = FormatCurrency(dblOverallTotalDeposits)
            txtOverallBalance.Text = FormatCurrency(dblOverallBalance)
            txtOverallLedgerStatus.Text = FormatCurrency(dblOverallLedgerStatus)

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved) 'CALCULATES AND FILLS THE MONTHLY INCOME DATAGRIDVIEW

        End If

#End Region

        ColorTextboxes(groupTextboxesList)

    End Sub

    Sub PerformScenarioCalculations_DisplayData()

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvCategory)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvCategory)

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvMonthly)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvMonthly)

        blnIsCalculatingScenario = True 'THIS VARIABLE IS USED IN MONTHLY GRID CURRENT CELL CHANGED SO IT DOESNT RUN  CALCULATION WHEN ITS NOT SUPPOSED TO.

        UIManager.SetCursor(Me, Cursors.WaitCursor) 'SETS ALL CONTROLS ON THE FORM TO WAIT CURSOR

        Sum_Category_Payee_Datagridview() 'RECALCULATES TOTALS FROM DATAGRIDVIEW VALUES

        CalculateMonthlyIncome_Scenario() 'RECALCULATES THE MONTHLY INCOME DATAGRIDVIEW

        CalculateAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

        UIManager.SetCursor(Me, Cursors.Default) 'SETS ALL CONTROLS ON THE FORM TO DEFAULT CURSOR

        blnIsCalculatingScenario = False

        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

        MainModule.DrawingControl.ResumeDrawing(Me.dgvCategory)
        MainModule.DrawingControl.ResumeDrawing(Me.dgvMonthly)

        dgvCategory.ClearSelection()

    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click

        WriteScenarioData()

    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click

        LoadScenarioData()

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

    Sub LoadScenarioData()

        Dim CheckbookMsg_Scenario_Name_Check As New CheckbookMessage.CheckbookMessage

        Dim dlgFolderDialog As New FolderBrowserDialog

        dlgFolderDialog.ShowNewFolderButton = True
        dlgFolderDialog.Description = "Select a folder titled 'month-day-year_" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_Scenario'."

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory) = String.Empty Then

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

        Else

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory)

        End If


        If dlgFolderDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim strFilePath As String = String.Empty
            strFilePath = dlgFolderDialog.SelectedPath

            Dim scenarioWasCreatedWithThisLedger As Boolean = False

            Dim message As String = String.Empty
            Dim secondaryMessage As String = String.Empty

            If Not strFilePath.Contains(System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)) Then

                scenarioWasCreatedWithThisLedger = False
                message = "The Scenario you selected was not created with this ledger"
                secondaryMessage = "Do you want to load the Scenario anyway?"

            Else

                scenarioWasCreatedWithThisLedger = True
                message = "Are you sure you want to load the Scenario below?"
                secondaryMessage = strFilePath

            End If

            If CheckbookMsg_Scenario_Name_Check.ShowMessage(message, MsgButtons.YesNo, secondaryMessage, Question) = DialogResult.Yes Then

                If Not cbYear.SelectedItem.ToString = yearList.Max.ToString Then

                    cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECT THE MOST RECENT YEAR IN YEARLIST

                End If

                Dim strCategoryTableFile_fullFile As String = String.Empty
                Dim strMonthlyTableFile_fullFile As String = String.Empty
                Dim strSelectedItem_Category_Payee_fullFile As String = String.Empty
                Dim strSelectedItem_Payment_Deposit_fullFile As String = String.Empty

                strCategoryTableFile_fullFile = strFilePath & "\CategoryTableScenario.whf"
                strMonthlyTableFile_fullFile = strFilePath & "\MonthlyTableScenario.whf"
                strSelectedItem_Category_Payee_fullFile = strFilePath & "\SelectedItem_Categories_Payees.whf"
                strSelectedItem_Payment_Deposit_fullFile = strFilePath & "\SelectedItem_Payments_Deposits.whf"

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                If Not ReadLineFromFile(strSelectedItem_Category_Payee_fullFile) = cbCategoriesPayees.Text Or Not ReadLineFromFile(strSelectedItem_Payment_Deposit_fullFile) = cbPaymentsDeposits.Text Then

                    Dim strAdvice As String = String.Empty

                    strAdvice = "The selected Scenario has the following 'Filter Options': " _
                                & vbNewLine & vbNewLine & ReadLineFromFile(strSelectedItem_Category_Payee_fullFile) _
                                & vbNewLine & ReadLineFromFile(strSelectedItem_Payment_Deposit_fullFile)

                    CheckbookMsg.ShowMessage("The Scenario you have selected has different 'Filter Options' than you currently have selected. This Scenario cannot be loaded.", MsgButtons.OK, strAdvice, Exclamation)

                Else

                    Try

                        LoadTXTDataIntoDGV(strCategoryTableFile_fullFile, dgvCategory)

                        Format_Category_Payee_Datagridview()

                        LoadTXTDataIntoDGV(strMonthlyTableFile_fullFile, dgvMonthly)

                        Dim intSelectedYear As Integer = Nothing
                        intSelectedYear = cbYear.SelectedItem

                        If blnIsCalculatingCurrentYear Then

                            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

                        Else

                            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved)

                        End If

                        CalculateAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

                        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Load Error", MsgButtons.OK, "An error occurred while loading the Scenario file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                    Finally

                        EnableScenarioCommands()

                        dgvCategory.ClearSelection()
                        dgvMonthly.ClearSelection()

                    End Try

                End If

            End If

        End If

    End Sub

    Sub WriteScenarioData()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dlgFolderDialog As New FolderBrowserDialog

        dlgFolderDialog.ShowNewFolderButton = True
        dlgFolderDialog.Description = "Select a location to save your Scenario"

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory) = String.Empty Then

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

        Else

            dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
            dlgFolderDialog.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory)

        End If

        If dlgFolderDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Try

                Dim strFilePath As String = String.Empty
                Dim strCategoryTableFile_fullFile As String = String.Empty
                Dim strMonthlyTableFile_fullFile As String = String.Empty
                Dim strSelectedItem_Category_Payee_fullFile As String = String.Empty
                Dim strSelectedItem_Payment_Deposit_fullFile As String = String.Empty

                Dim strScenarioFolderName As String = String.Empty
                strScenarioFolderName = Date.Now.ToShortDateString.Replace("/", "-") & "_" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_Scenario"

                strFilePath = dlgFolderDialog.SelectedPath & "\" & strScenarioFolderName
                strCategoryTableFile_fullFile = strFilePath & "\CategoryTableScenario.whf"
                strMonthlyTableFile_fullFile = strFilePath & "\MonthlyTableScenario.whf"
                strSelectedItem_Category_Payee_fullFile = strFilePath & "\SelectedItem_Categories_Payees.whf"
                strSelectedItem_Payment_Deposit_fullFile = strFilePath & "\SelectedItem_Payments_Deposits.whf"

                If System.IO.Directory.Exists(strFilePath) Then

                    If CheckbookMsg.ShowMessage(strFilePath & " already exists", MsgButtons.YesNo, "Do you want to overwrite this Scenario?", Question) = DialogResult.Yes Then

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

                        CheckbookMsg.ShowMessage("The Scenario was overwritten successfully.", MsgButtons.OK, "")

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

                    CheckbookMsg.ShowMessage("The Scenario was saved successfully.", MsgButtons.OK, "")

                End If

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Save Error", MsgButtons.OK, "An error occurred while saving the Scenario file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

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

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        If blnIsCalculatingScenario = True Then

            If blnIsCalculatingCurrentYear Then

                CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

            Else

                CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved)

            End If

            CalculateAccountDetails_andDisplay()

        End If

    End Sub

    Private Sub dgvMonthly_DoubleClick(sender As Object, e As EventArgs) Handles dgvMonthly.DoubleClick

        If blnIsWorkingInScenario Then

            blnIsCalculatingScenario = True

            dgvMonthly.ReadOnly = False

            If cbPaymentsDeposits.Text = "Payments" Then

                dgvMonthly.Columns("Payments").ReadOnly = True
                dgvMonthly.Columns("Deposits").ReadOnly = False

            Else

                dgvMonthly.Columns("Payments").ReadOnly = False
                dgvMonthly.Columns("Deposits").ReadOnly = True

            End If

            dgvMonthly.CurrentCell.Style.ForeColor = Color.Black

            dgvMonthly.Columns("Month").ReadOnly = True
            dgvMonthly.Columns("Monthly").ReadOnly = True
            dgvMonthly.Columns("AveMonthlyIncome").ReadOnly = True
            dgvMonthly.Columns("OverallBalance").ReadOnly = True

            dgvMonthly.BeginEdit(True)

        End If

    End Sub

    Private Sub CreateNewScenario() Handles mnuCreateNewScenario.Click, cxmnuCreateNewScenario.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
        Dim new_frmScenario As New frmScenario

        Dim strModelCurrentYearKeepValues As String = String.Empty
        Dim strModelCurrentYearFromScratch As String = String.Empty
        Dim strModelNextYearKeepValues As String = String.Empty
        Dim strModelNextYearFromScratch As String = String.Empty
        Dim strCurrentModelingOptionSelected As String = String.Empty

        strModelCurrentYearKeepValues = "Model (" & yearList.Max & ") in current state"
        strModelCurrentYearFromScratch = "Model (" & yearList.Max & ") from scratch"
        strModelNextYearKeepValues = "Model next year (" & currentHypotheticalYear + 1 & ") and keep 'Current Year Details' as a starting point"
        strModelNextYearFromScratch = "Model next year (" & currentHypotheticalYear + 1 & ") from scratch"

        new_frmScenario.rbModelCurrentYearKeepValues.Text = strModelCurrentYearKeepValues
        new_frmScenario.rbModelCurrentYearFromScratch.Text = strModelCurrentYearFromScratch
        new_frmScenario.rbModelNextYearAndOverallDetails.Text = strModelNextYearKeepValues
        new_frmScenario.rbModelNextYearFromScratch.Text = strModelNextYearFromScratch

        new_frmScenario.rbModelCurrentYearKeepValues.Checked = False
        new_frmScenario.rbModelCurrentYearFromScratch.Checked = False
        new_frmScenario.rbModelNextYearAndOverallDetails.Checked = False
        new_frmScenario.rbModelNextYearFromScratch.Checked = False

        If blnIsWorkingInScenario Then
            new_frmScenario.rbModelCurrentYearKeepValues.Enabled = False
        Else
            new_frmScenario.rbModelCurrentYearKeepValues.Enabled = True
        End If

        If new_frmScenario.ShowDialog = DialogResult.OK Then

            blnIsWorkingInScenario = True

            'GET MODELING OPTION CHOICE FROM USER
            If new_frmScenario.rbModelCurrentYearKeepValues.Checked Then 'MODEL CURRENT YEAR AND KEEP CATEGORY VALUES

                blnIsCalculatingCurrentYear = True
                currentHypotheticalYear = yearList.Max

                gbCurrentYear.Text = "Current Year Details (" & yearList.Max & ")"
                gbOverallDetails.Text = "Overall Account Details (" & yearList.Max & ")"

                lblScenario.Text = "Modeling Option: " & strModelCurrentYearKeepValues

                EnableScenarioCommands()

            ElseIf new_frmScenario.rbModelCurrentYearFromScratch.Checked Then 'MODEL CURRENT YEAR FROM SCRATCH

                blnIsCalculatingCurrentYear = True
                currentHypotheticalYear = yearList.Max

                gbCurrentYear.Text = "Current Year Details (" & yearList.Max & ")"
                gbOverallDetails.Text = "Overall Account Details (" & yearList.Max & ")"

                lblScenario.Text = "Modeling Option: " & strModelCurrentYearFromScratch

                dgvCategory.Rows.Clear()

                For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                    dgvRow.Cells("Payments").Value = "$0.00"
                    dgvRow.Cells("Deposits").Value = "$0.00"
                    dgvRow.Cells("Monthly").Value = "$0.00"
                    dgvRow.Cells("AveMonthlyIncome").Value = "$0.00"
                    dgvRow.Cells("OverallBalance").Value = "$0.00"

                Next

                FormatMonthlyGrid(dgvMonthly)

                PerformScenarioCalculations_DisplayData()

                AddMonthlyPaymentsOrDeposits()

                PerformScenarioCalculations_DisplayData()

                EnableScenarioCommands()

            ElseIf new_frmScenario.rbModelNextYearAndOverallDetails.Checked Then 'MODEL NEXT YEAR AND KEEP CURRENT VALUES AS STARTING POINT

                cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

                blnIsCalculatingCurrentYear = False

                currentHypotheticalYear += 1
                gbCurrentYear.Text = "Current Year Details (" & currentHypotheticalYear & ")"
                gbOverallDetails.Text = "Overall Account Details (" & currentHypotheticalYear & ")"

                lblScenario.Text = "Modeling Option: " & strModelNextYearKeepValues

                'SAVE OVERALL ACCOUNT DETAILS FOR CALCULATING IN CalculateAccountDetails_andDisplay()
                dblOverallTotalPayments_Saved = 0
                dblOverallTotalDeposits_Saved = 0
                dblOverallBalance_Saved = 0

                dblOverallTotalPayments_Saved = txtOverallTotalPayments.Text
                dblOverallTotalDeposits_Saved = txtOverallTotalDeposits.Text
                dblOverallBalance_Saved = txtOverallBalance.Text

                'SAVE CURRENT YEAR DETAILS FOR CALCULATING IN CalculateAccountDetails_andDisplay()
                dblCurrentYearPayments_Saved = 0
                dblCurrentYearDeposits_Saved = 0

                dblCurrentYearPayments_Saved = txtCurrentYearPayments.Text
                dblCurrentYearDeposits_Saved = txtCurrentYearDeposits.Text

                'USE CURRENT DATAGRIDVIEW VALUES AS A STARTING POINT
                PerformScenarioCalculations_DisplayData()

                EnableScenarioCommands()

            ElseIf new_frmScenario.rbModelNextYearFromScratch.Checked Then 'MODEL NEXT YEAR FROM SCRATCH

                cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

                blnIsCalculatingCurrentYear = False

                currentHypotheticalYear += 1
                gbCurrentYear.Text = "Current Year Details (" & currentHypotheticalYear & ")"
                gbOverallDetails.Text = "Overall Account Details (" & currentHypotheticalYear & ")"

                lblScenario.Text = "Modeling Option: " & strModelNextYearFromScratch

                'SAVE OVERALL ACCOUNT DETAILS FOR CALCULATING IN CalculateAccountDetails_andDisplay()
                dblOverallTotalPayments_Saved = 0
                dblOverallTotalDeposits_Saved = 0
                dblOverallBalance_Saved = 0

                dblOverallTotalPayments_Saved = txtOverallTotalPayments.Text
                dblOverallTotalDeposits_Saved = txtOverallTotalDeposits.Text
                dblOverallBalance_Saved = txtOverallBalance.Text

                'SAVE CURRENT YEAR DETAILS FOR CALCULATING IN CalculateAccountDetails_andDisplay()
                dblCurrentYearPayments_Saved = 0
                dblCurrentYearDeposits_Saved = 0

                dblCurrentYearPayments_Saved = txtCurrentYearPayments.Text
                dblCurrentYearDeposits_Saved = txtCurrentYearDeposits.Text

                dgvCategory.Rows.Clear()

                For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                    dgvRow.Cells("Payments").Value = "$0.00"
                    dgvRow.Cells("Deposits").Value = "$0.00"
                    dgvRow.Cells("Monthly").Value = "$0.00"
                    dgvRow.Cells("AveMonthlyIncome").Value = "$0.00"
                    dgvRow.Cells("OverallBalance").Value = "$0.00"

                Next

                FormatMonthlyGrid(dgvMonthly)

                PerformScenarioCalculations_DisplayData()

                AddMonthlyPaymentsOrDeposits()

                PerformScenarioCalculations_DisplayData()

                ColorTextboxes(groupTextboxesList)

                EnableScenarioCommands()

            End If

        End If

        MyBase.Update()

    End Sub

    Private Sub AddMonthlyPaymentsOrDeposits()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strConfirmationMessage As String = String.Empty
        Dim strSaveDataAsStartingPointMessage As String = String.Empty
        Dim strInfoMessage As String = String.Empty
        Dim strModelingOptionMessage As String = String.Empty
        Dim strFormTitle As String = String.Empty

        If cbPaymentsDeposits.Text = "Payments" Then

            strFormTitle = "Monthly Deposits"
            strConfirmationMessage = "Would you like to include your monthly deposits? If you know how much you make each month you can enter it now."

        Else

            strFormTitle = "Monthly Payments"
            strConfirmationMessage = "Would you like to include your monthly payments? If you know how much you spend each month you can enter it now."

        End If

        strInfoMessage = "This monthly total will be applied to each month for inclusion in your calculations." _
                         & vbNewLine & vbNewLine & "You can edit the values in the monthly income table at any time. Select the values in the monthly income table you want to edit, right click and select 'Edit Selected Totals'."

        If CheckbookMsg.ShowMessage(strConfirmationMessage, MsgButtons.YesNo, strInfoMessage, Question) = DialogResult.Yes Then

            Dim new_frmEditValues As New frmEditValues
            Dim dblMonthlyAmount As Double = Nothing

            new_frmEditValues.Text = strFormTitle
            new_frmEditValues.lblNewAmount.Text = "Amount"
            new_frmEditValues.btnUpdate.Text = "OK"

            If new_frmEditValues.ShowDialog() = DialogResult.OK Then

                dblMonthlyAmount = new_frmEditValues.txtNewExpenseValue.Text

                If cbPaymentsDeposits.Text = "Payments" Then

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
        Dim strAdvice As String = String.Empty

        strAdvice = "Select values from the Payments and/or Deposits columns"
        strErrorMessageTitle = "Edit Monthly Total Error"
        strNoneSelectedMessage = "There are no totals selected to edit"
        strConfirmRemoveMessage = "Are you sure you want to make all the selected monthly totals "
        strErrorMessage = "An error occurred while editing the monthly totals"

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvMonthly.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvMonthly.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            Dim intPaymentOrDepositColumnIndex As Integer = 0

            If cbPaymentsDeposits.Text = "Payments" Then
                intPaymentOrDepositColumnIndex = 1
                strInvalidSelectionMessage = "Select only the deposits you want to edit"
            Else
                intPaymentOrDepositColumnIndex = 2
                strInvalidSelectionMessage = "Select only the payments you want to edit"
            End If

            If columnIndexList.Contains(0) Or columnIndexList.Contains(intPaymentOrDepositColumnIndex) Or columnIndexList.Contains(3) Or columnIndexList.Contains(4) Or columnIndexList.Contains(5) Then

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
        Dim strAdvice As String = String.Empty

        strAdvice = "Select values from the Payments and/or Deposits columns"
        strErrorMessageTitle = "Remove Monthly Total Error"
        strNoneSelectedMessage = "There are no totals selected to remove"
        strConfirmRemoveMessage = "Are you sure you want to remove the selected totals?"
        strErrorMessage = "An error occurred while removing the monthly totals"

        Dim columnIndexList As New List(Of Integer)

        Dim intPaymentOrDepositColumnIndex As Integer = 0

        If cbPaymentsDeposits.Text = "Payments" Then
            intPaymentOrDepositColumnIndex = 1
            strInvalidSelectionMessage = "Select only the deposits you want to remove"
        Else
            intPaymentOrDepositColumnIndex = 2
            strInvalidSelectionMessage = "Select only the payments you want to remove"
        End If

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvMonthly.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvMonthly.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(intPaymentOrDepositColumnIndex) Or columnIndexList.Contains(3) Or columnIndexList.Contains(4) Or columnIndexList.Contains(5) Then

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

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        For Each dgvSelectedCell As DataGridViewCell In dgvMonthly.SelectedCells

            dgvSelectedCell.Value = newValue

        Next

        If blnIsCalculatingCurrentYear Then

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        Else

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        End If

        CalculateAccountDetails_andDisplay()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

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

        Dim intSelectedItemCount As Integer = 0
        intSelectedItemCount = dgvCategory.SelectedCells.Count

        Dim strNoneSelectedMessage As String = String.Empty
        Dim strInvalidSelectionMessage As String = String.Empty
        Dim strAdvice As String = String.Empty

        Dim dblTotal As Double = 0
        Dim dblAverage As Double = 0
        Dim intItemCounter As Integer = 0

        strAdvice = "Select values ranging from January to December"

        Dim columnIndexList As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            columnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        If cbPaymentsDeposits.Text = "Payments" Then

            strNoneSelectedMessage = "There are no expenses selected to sum"
            strInvalidSelectionMessage = "Select only the expenses you want to sum"

        Else

            strNoneSelectedMessage = "There are no incomes selected to sum"
            strInvalidSelectionMessage = "Select only the incomes you want to sum"

        End If

        If intSelectedItemCount = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If columnIndexList.Contains(0) Or columnIndexList.Contains(13) Or columnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, strAdvice, Exclamation)

            Else

                For Each cell As DataGridViewCell In dgvCategory.SelectedCells

                    If Not cell.Value = Nothing Then

                        dblTotal += cell.Value
                        intItemCounter += 1

                    End If

                Next

                If dblTotal = 0 And dblAverage = 0 Then

                    dblTotal = 0
                    dblAverage = 0

                Else

                    dblAverage = dblTotal / intItemCounter

                End If

                Dim strMessage As String = "Total: " & FormatCurrency(dblTotal) & vbNewLine & "Average: " & FormatCurrency(dblAverage)

                CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, "")

            End If

        End If

    End Sub

    Private Sub EnableScenarioCommands()

        'FILE MENU
        mnuSave.Enabled = True
        mnuOpen.Enabled = True

        'EDIT MENU
        mnuCreateExpense.Enabled = True
        mnuEditExpense.Enabled = True
        mnuRemoveExpenses.Enabled = True
        mnuRemoveCategory.Enabled = True
        mnuCopyToNextMonth.Enabled = True
        mnuCopyToSelectedMonths.Enabled = True
        mnuCopyToRestOfYear.Enabled = True
        mnuCreateNewScenario.Enabled = True
        mnuResetToLedgerData.Enabled = True

        'CONTEXT MENU
        cxmnuCreateExpense.Enabled = True
        cxmnuEditExpense.Enabled = True
        cxmnuRemoveExpenses.Enabled = True
        cxmnuRemoveCategories.Enabled = True
        cxmnuCopyToNextMonth.Enabled = True
        cxmnuCopyToSelectedMonths.Enabled = True
        cxmnuCopyToRestOfYear.Enabled = True
        cxmnuCreateNewScenario.Enabled = True
        cxmnuResetToLedgerData.Enabled = True

        'MONTHLY INCOME TABLE
        cxmnuMonthlyIncomeTable.Enabled = True

        gbFilterOptions.Enabled = False

    End Sub

    Private Sub DisableScenarioCommands()

        'FILE MENU
        mnuSave.Enabled = False
        mnuOpen.Enabled = False

        'EDIT MENU
        mnuCreateExpense.Enabled = False
        mnuEditExpense.Enabled = False
        mnuRemoveExpenses.Enabled = False
        mnuRemoveCategory.Enabled = False
        mnuCopyToNextMonth.Enabled = False
        mnuCopyToSelectedMonths.Enabled = False
        mnuCopyToRestOfYear.Enabled = False
        mnuResetToLedgerData.Enabled = False

        'CONTEXT MENU
        cxmnuCreateExpense.Enabled = False
        cxmnuEditExpense.Enabled = False
        cxmnuRemoveExpenses.Enabled = False
        cxmnuRemoveCategories.Enabled = False
        cxmnuCopyToNextMonth.Enabled = False
        cxmnuCopyToSelectedMonths.Enabled = False
        cxmnuCopyToRestOfYear.Enabled = False
        cxmnuResetToLedgerData.Enabled = False

        'MONTHLY INCOME TABLE
        cxmnuMonthlyIncomeTable.Enabled = False

        If Not CInt(cbYear.SelectedItem) = yearList.Max Then

            mnuCreateNewScenario.Enabled = False
            cxmnuCreateNewScenario.Enabled = False

            lblScenario.Text = "Modeling Option: Select (" & yearList.Max & ") in 'Filter Options' to enable 'Create New Scenario'"

        Else

            mnuCreateNewScenario.Enabled = True
            cxmnuCreateNewScenario.Enabled = True

            lblScenario.Text = "Modeling Option: Select 'Create New Scenario' to start a new scenario"

        End If

        gbFilterOptions.Enabled = True

        MyBase.Update()

    End Sub

End Class