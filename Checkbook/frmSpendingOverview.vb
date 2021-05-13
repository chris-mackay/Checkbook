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
Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmSpendingOverview

    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager

    Private lstMonthlyTotals As New List(Of String)
    Private lstGroupTextboxes As New List(Of TextBox)
    Private intYearsInLedger As New List(Of Integer)
    Private colColumnIndexList As New List(Of Integer)
    Private blnIsCalculatingScenario As Boolean = False
    Private blnSelectedYearIsMostRecentYear As Boolean = False
    Private blnFormIsLoading As Boolean = False
    Private blnIsCalculatingCurrentYear As Boolean = True
    Private intCurrentHypotheticalYear As Integer = 0
    Private blnIsWorkingInScenario As Boolean = False
    Public strCurrentScenarioPath As String = String.Empty
    Public strCurrentScenarioName As String = String.Empty

    Private dblOverallTotalPayments_Saved As Double = 0
    Private dblOverallTotalDeposits_Saved As Double = 0
    Private dblOverallBalance_Saved As Double = 0

    Private dblCurrentYearPayments_Saved As Double = 0
    Private dblCurrentYearDeposits_Saved As Double = 0

    Private Sub frmSpendingOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        strCurrentScenarioPath = String.Empty
        strCurrentScenarioName = String.Empty

        blnFormIsLoading = True
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

        Clear_Add_FormatCategoryPayeeColumns()

        lstGroupTextboxes.Add(txtOverallBalance)
        lstGroupTextboxes.Add(txtCurrentYearStatus)
        lstGroupTextboxes.Add(txtOverallLedgerStatus)

        Me.dgvCategory.Rows.Clear()
        Me.dgvMonthly.Rows.Clear()
        m_colMonths.Clear()

        GetAllYearsFromDataGridView_FillList_ComboBox(intYearsInLedger, cbYear)

        m_colMonths.Add("January")
        m_colMonths.Add("February")
        m_colMonths.Add("March")
        m_colMonths.Add("April")
        m_colMonths.Add("May")
        m_colMonths.Add("June")
        m_colMonths.Add("July")
        m_colMonths.Add("August")
        m_colMonths.Add("September")
        m_colMonths.Add("October")
        m_colMonths.Add("November")
        m_colMonths.Add("December")

        cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max.ToString)

        dgvMonthly.ClearSelection()

        UIManager.SetGroupObjects_List_Visible(spendingOverviewControlsList, True)
        MainModule.DrawingControl.ResumeDrawing_ListControls(spendingOverviewControlsList)

        blnFormIsLoading = False
        UIManager.SetCursor(Me, Cursors.Default)

        DisableScenarioCommands()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, mnuClose.Click

        m_strCategoriesPayees = String.Empty
        m_strCategoriesPayees = Nothing
        Me.Dispose()
        Me.Dispose()

    End Sub

    Private Sub Clear_Add_FormatCategoryPayeeColumns()

        DrawingControl.SetDoubleBuffered(Me.dgvCategory)
        DrawingControl.SuspendDrawing(Me.dgvCategory)

        Me.dgvCategory.DataSource = Nothing
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

        DrawingControl.ResumeDrawing(Me.dgvCategory)

    End Sub

    Public Sub ResetSpendingOverview()

        strCurrentScenarioPath = String.Empty
        strCurrentScenarioName = String.Empty

        dgvCategory.ScrollBars = ScrollBars.None

        m_strCategoriesPayees = cbCategoriesPayees.SelectedItem.ToString

        blnIsCalculatingScenario = False
        blnIsCalculatingCurrentYear = True
        blnIsWorkingInScenario = False

        If Not intYearsInLedger.Count = 0 Then

            If Not CInt(cbYear.SelectedItem) = intYearsInLedger.Max Then

                If Not cbYear.SelectedIndex < 0 Then

                    gbCurrentYear.Text = "Current Year Details (" & cbYear.SelectedItem.ToString & ")"
                    gbOverallDetails.Text = "Overall Account Details (" & cbYear.SelectedItem.ToString & ")"

                End If

                blnSelectedYearIsMostRecentYear = False

            Else

                If Not cbYear.SelectedIndex < 0 Then

                    intCurrentHypotheticalYear = cbYear.SelectedItem

                    gbCurrentYear.Text = "Current Year Details (" & intCurrentHypotheticalYear & ")"
                    gbOverallDetails.Text = "Overall Account Details (" & intCurrentHypotheticalYear & ")"

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

            Else

                mnuCreateExpense.Text = "Create Monthly Income"
                cxmnuCreateExpense.Text = "Create Monthly Income"
                mnuEditExpense.Text = "Edit Incomes"
                cxmnuEditExpense.Text = "Edit Incomes"
                mnuRemoveExpenses.Text = "Remove Incomes"
                cxmnuRemoveExpenses.Text = "Remove Incomes"

            End If

        End If

        Clear_Add_FormatCategoryPayeeColumns()

        Me.dgvCategory.Rows.Clear()

        Dim intSelectedYear As Integer = Nothing
        intSelectedYear = cbYear.SelectedItem

        If Not blnFormIsLoading Then
            UIManager.SetCursor(Me, Cursors.WaitCursor)
        End If

        If cbPaymentsDeposits.Text = "Payments" Then

            DetermineCategoriesAndPayeesbyYear_Payments(intSelectedYear)

        Else

            DetermineCategoriesAndPayeesbyYear_Deposits(intSelectedYear)

        End If

        CalculateMonthlyIncomeFromLedger()
        CalculateAccountDetails()

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
        Dim strDecemeber As String = String.Empty
        Dim strTotal As String = String.Empty

        If cbCategoriesPayees.Text = "Categories" Then

            For Each strCategory As String In m_colGlobalUsedCategories

                SumMonthly(strCategory, intSelectedYear, strJanuary, strFebruary, strMarch, strApril, strMay, strJune, strJuly, strAugust, strSeptember, strOctober, strNovember, strDecemeber, strTotal)

                dgvCategory.Rows.Add(strCategory, strJanuary, strFebruary, strMarch, strApril, strMay, strJune, strJuly, strAugust, strSeptember, strOctober, strNovember, strDecemeber, strTotal, CalculatePercentageOfTotal(strTotal, GetTotalPaymentsFromMonthlyGrid(dgvMonthly), GetTotalDepositsFromMonthlyGrid(dgvMonthly)))

            Next

        Else

            For Each strPayee As String In m_colGlobalUsedPayees

                SumMonthly(strPayee, intSelectedYear, strJanuary, strFebruary, strMarch, strApril, strMay, strJune, strJuly, strAugust, strSeptember, strOctober, strNovember, strDecemeber, strTotal)

                dgvCategory.Rows.Add(strPayee, strJanuary, strFebruary, strMarch, strApril, strMay, strJune, strJuly, strAugust, strSeptember, strOctober, strNovember, strDecemeber, strTotal, CalculatePercentageOfTotal(strTotal, GetTotalPaymentsFromMonthlyGrid(dgvMonthly), GetTotalDepositsFromMonthlyGrid(dgvMonthly)))

            Next

        End If

        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

        If Not blnFormIsLoading Then
            UIManager.SetCursor(Me, Cursors.Default)
        End If

        dgvCategory.ClearSelection()

        dgvCategory.ScrollBars = ScrollBars.Both

    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged, mnuResetSpendingOverview.Click, cxmnuResetSpendingOverview.Click, cbCategoriesPayees.SelectedIndexChanged, cbPaymentsDeposits.SelectedIndexChanged

        ResetSpendingOverview()

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

            Dim strPayment As String = String.Empty
            Dim strDeposit As String = String.Empty

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If cbCategoriesPayees.Text = "Categories" Then
                strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            Else
                strCategory = MainForm.dgvLedger.Item("Payee", i).Value.ToString
            End If

            If cbPaymentsDeposits.Text = "Payments" Then
                strTransactionAmount = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            Else
                strTransactionAmount = MainForm.dgvLedger.Item("Deposit", i).Value.ToString
            End If

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If strTransactionAmount = String.Empty Then
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

            If jan = 0 Then _jan = String.Empty Else _jan = FormatCurrency(jan)
            If feb = 0 Then _feb = String.Empty Else _feb = FormatCurrency(feb)
            If mar = 0 Then _mar = String.Empty Else _mar = FormatCurrency(mar)
            If apr = 0 Then _apr = String.Empty Else _apr = FormatCurrency(apr)
            If may = 0 Then _may = String.Empty Else _may = FormatCurrency(may)
            If jun = 0 Then _jun = String.Empty Else _jun = FormatCurrency(jun)
            If jul = 0 Then _jul = String.Empty Else _jul = FormatCurrency(jul)
            If aug = 0 Then _aug = String.Empty Else _aug = FormatCurrency(aug)
            If sep = 0 Then _sep = String.Empty Else _sep = FormatCurrency(sep)
            If oct = 0 Then _oct = String.Empty Else _oct = FormatCurrency(oct)
            If nov = 0 Then _nov = String.Empty Else _nov = FormatCurrency(nov)
            If dec = 0 Then _dec = String.Empty Else _dec = FormatCurrency(dec)

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

        colColumnIndexList.Clear()

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        colColumnIndexList = colColumnIndexList.Distinct.ToList

        Try

            If dgvCategory.SelectedCells.Count = 0 Then

                CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Contains(0) Or colColumnIndexList.Contains(13) Or colColumnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Count = 1 And colColumnIndexList.Contains(12) Then

                CheckbookMsg.ShowMessage("There are no months to copy December to.", MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Count > 1 Then

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

                    Dim lstMonthstoCopyTo As New List(Of Integer)

                    If blnJan Then lstMonthstoCopyTo.Add(1)
                    If blnFeb Then lstMonthstoCopyTo.Add(2)
                    If blnMar Then lstMonthstoCopyTo.Add(3)
                    If blnApr Then lstMonthstoCopyTo.Add(4)
                    If blnMay Then lstMonthstoCopyTo.Add(5)
                    If blnJun Then lstMonthstoCopyTo.Add(6)
                    If blnJul Then lstMonthstoCopyTo.Add(7)
                    If blnAug Then lstMonthstoCopyTo.Add(8)
                    If blnSep Then lstMonthstoCopyTo.Add(9)
                    If blnOct Then lstMonthstoCopyTo.Add(10)
                    If blnNov Then lstMonthstoCopyTo.Add(11)
                    If blnDec Then lstMonthstoCopyTo.Add(12)

                    For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                        Dim intCurrentColumn As Integer = 0
                        intCurrentColumn = dgvSelectedCell.ColumnIndex

                        Dim intCurrentRow As Integer = 0
                        intCurrentRow = dgvSelectedCell.RowIndex

                        For Each intMonth As Integer In lstMonthstoCopyTo

                            Dim intNextColumn As Integer = 0
                            intNextColumn = intMonth
                            dgvCategory.Item(intNextColumn, intCurrentRow).Value = dgvCategory.Item(intCurrentColumn, intCurrentRow).Value

                        Next

                    Next

                    PerformScenarioCalculations()

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

        colColumnIndexList.Clear()

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        colColumnIndexList = colColumnIndexList.Distinct.ToList

        Try

            If dgvCategory.SelectedCells.Count = 0 Then

                CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Contains(0) Or colColumnIndexList.Contains(13) Or colColumnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Count = 1 And colColumnIndexList.Contains(12) Then

                CheckbookMsg.ShowMessage("There are no months to copy December to.", MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Count > 1 Then

                CheckbookMsg.ShowMessage("You may only copy one month at a time.", MsgButtons.OK, "", Exclamation)

            Else

                For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                    Dim intCurrentColumn As Integer = 0
                    intCurrentColumn = dgvSelectedCell.ColumnIndex

                    Dim intCurrentRow As Integer = 0
                    intCurrentRow = dgvSelectedCell.RowIndex

                    Dim intNextColumn As Integer = 0
                    intNextColumn = intCurrentColumn + 1

                    dgvCategory.Item(intNextColumn, intCurrentRow).Value = dgvCategory.Item(intCurrentColumn, intCurrentRow).Value

                Next

                PerformScenarioCalculations()

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

        colColumnIndexList.Clear()

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexList.Add(dgvSelectedCell.ColumnIndex)

        Next

        colColumnIndexList = colColumnIndexList.Distinct.ToList

        Try

            If dgvCategory.SelectedCells.Count = 0 Then

                CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Contains(0) Or colColumnIndexList.Contains(13) Or colColumnIndexList.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Count = 1 And colColumnIndexList.Contains(12) Then

                CheckbookMsg.ShowMessage("There are no months to copy December to.", MsgButtons.OK, "", Exclamation)

            ElseIf colColumnIndexList.Count > 1 Then

                CheckbookMsg.ShowMessage("You may only copy one month at a time.", MsgButtons.OK, "", Exclamation)

            Else

                For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                    Dim intCurrentColumn As Integer = 0
                    intCurrentColumn = dgvSelectedCell.ColumnIndex

                    Dim intCurrentRow As Integer = 0
                    intCurrentRow = dgvSelectedCell.RowIndex

                    Dim intNextColumn As Integer = 0
                    intNextColumn = intCurrentColumn + 1

                    Dim intNextRow As Integer = 0
                    intNextRow = intCurrentRow

                    Do While intNextColumn < 13

                        dgvCategory.Item(intNextColumn, intCurrentRow).Value = dgvCategory.Item(intCurrentColumn, intCurrentRow).Value
                        intNextColumn += 1

                    Loop

                    intNextRow += 1

                Next

                PerformScenarioCalculations()

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Copy Error", MsgButtons.OK, "An error occurred while copying the amounts", Exclamation)

        End Try

    End Sub

    Function SumbyCategory(ByVal _Category As String, ByVal _Year As Integer)

        Dim dblTotal As Double = 0
        Dim dtDate As Date = Nothing

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strCategory As String = String.Empty
            Dim strTransactionAmount As String = String.Empty

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If cbCategoriesPayees.Text = "Categories" Then

                strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString

            Else

                strCategory = MainForm.dgvLedger.Item("Payee", i).Value.ToString

            End If

            If cbPaymentsDeposits.Text = "Payments" Then

                strTransactionAmount = MainForm.dgvLedger.Item("Payment", i).Value.ToString

            Else

                strTransactionAmount = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            End If

            If strTransactionAmount = "" Then
                strTransactionAmount = 0
            Else
                strTransactionAmount = CDbl(strTransactionAmount)
            End If

            If strCategory = _Category And dtDate.Year = _Year Then
                dblTotal += strTransactionAmount
            End If

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Sub Sum_Category_Payee_Datagridview()

        Dim dblTotal As Double = 0
        Dim strPayment As String = String.Empty
        Dim dblNewTotal As Double = 0

        For j As Integer = 0 To dgvCategory.Rows.Count - 1

            dblTotal = 0

            For i As Integer = 1 To dgvCategory.Columns.Count - 3

                strPayment = dgvCategory.Item(i, j).Value.ToString()

                If strPayment = String.Empty Then
                    strPayment = 0
                Else
                    strPayment = CDbl(strPayment)
                End If

                dblTotal += strPayment

            Next

            dblNewTotal += dblTotal

            dgvCategory.Item("Totals", j).Value = FormatCurrency(dblTotal)

        Next

        For k As Integer = 0 To dgvCategory.Rows.Count - 1

            Dim dblCategoryTotal As Double = dgvCategory.Item("Totals", k).Value

            dgvCategory.Item("Percent", k).Value = CatPercent_Scenario(dblCategoryTotal, dblNewTotal)

        Next

    End Sub

    Function CalculatePercentageOfTotal(ByVal _CategoryTotal As Double, ByVal _TotalPayments As Double, _TotalDeposits As Double) As String

        Dim dblPercent As Double = 0

        If cbPaymentsDeposits.Text = "Payments" Then

            dblPercent = Math.Round((_CategoryTotal / _TotalPayments) * 100, 2).ToString

        Else

            dblPercent = Math.Round((_CategoryTotal / _TotalDeposits) * 100, 2).ToString

        End If

        Return dblPercent & "%"
    End Function

    Function CatPercent_Scenario(ByVal _CategoryTotal As Double, ByVal _NewTotal As Double) As String

        Dim dblPercent As Double = 0

        dblPercent = Math.Round((_CategoryTotal / _NewTotal) * 100, 2).ToString

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

        End With

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

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            Dim new_TransCategory As New clsTransaction

            Try

                Dim strCategory As String = String.Empty
                Dim strExpense As String = String.Empty

                strCategory = new_frmCreateExpense.cbCategoriesPayees.Text
                strExpense = new_frmCreateExpense.txtMonthlyExpense.Text

                new_TransCategory.Category = strCategory

                strExpense = FormatCurrency(strExpense)

                dgvCategory.Rows.Add(new_TransCategory.Category, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense, strExpense)

                PerformScenarioCalculations()

            Catch ex As Exception

                CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & "Make sure you entered a valid amount" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                UIManager.SetCursor(Me, Cursors.Default)
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

        Dim colColumnIndexes As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexes.Add(dgvSelectedCell.ColumnIndex)

        Next

        If dgvCategory.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If colColumnIndexes.Contains(0) Or colColumnIndexes.Contains(13) Or colColumnIndexes.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, strAdvice, Exclamation)

            Else

                Dim new_frmEditValues As New frmEditValues
                new_frmEditValues.Text = strFormTitle

                If new_frmEditValues.ShowDialog = Windows.Forms.DialogResult.OK Then

                    If CheckbookMsg.ShowMessage(strConfirmRemoveMessage & FormatCurrency(new_frmEditValues.txtNewExpenseValue.Text) & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                        Try

                            UIManager.SetCursor(Me, Cursors.WaitCursor)

                            For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                                dgvSelectedCell.Value = FormatCurrency(new_frmEditValues.txtNewExpenseValue.Text)

                            Next

                            PerformScenarioCalculations()

                        Catch ex As Exception

                            CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & "Make sure you entered a valid amount" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                        Finally

                            UIManager.SetCursor(Me, Cursors.Default)

                        End Try

                    End If

                End If

            End If

        End If

        UIManager.SetCursor(Me, Cursors.Default)

    End Sub

    Sub CalculateMonthlyIncomeFromLedger()

        dgvMonthly.Rows.Clear()
        dgvMonthly.Columns.Clear()

        CreateMonthlyGridColumns(dgvMonthly)

        Dim intSelectedYear As Integer = 0
        intSelectedYear = cbYear.SelectedItem

        For Each strMonth As String In m_colMonths

            Dim strPayments As String = String.Empty
            Dim strDeposits As String = String.Empty

            Dim dblPayments As Double = 0
            Dim dblDeposits As Double = 0

            SumMonthlyPaymentAndDeposits_FromLedger(strMonth, intSelectedYear, dblPayments, dblDeposits)

            strPayments = FormatCurrency(dblPayments)
            strDeposits = FormatCurrency(dblDeposits)

            dgvMonthly.Rows.Add(strMonth, strPayments, strDeposits)

        Next

        CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

        dgvMonthly.ClearSelection()

    End Sub

    Sub CalculateMonthlyIncome_Scenario()

        Dim dblTotalPayments As Double = 0
        Dim dblTotalDeposits As Double = 0
        Dim strMonth As String = String.Empty

        Dim intSelectedYear As Integer = 0
        intSelectedYear = cbYear.SelectedItem

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

    End Sub

    Function SumAmountsMonthly_SpendingOverview(ByVal _Month As String)

        Dim dblTotal As Double = Nothing

        For i As Integer = 0 To dgvCategory.RowCount - 1

            Dim strAmount As String = String.Empty

            strAmount = dgvCategory.Item(_Month, i).Value.ToString

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

        Dim colColumnIndexes As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexes.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvCategory.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If colColumnIndexes.Contains(0) Or colColumnIndexes.Contains(13) Or colColumnIndexes.Contains(14) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, strAdvice, Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor)

                    Try

                        For Each dgvSelectedCell As DataGridViewCell In dgvCategory.SelectedCells

                            dgvSelectedCell.Value = String.Empty

                        Next

                        PerformScenarioCalculations()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default)

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

        Dim colColumnIndexes As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexes.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvCategory.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, "", Exclamation)

        Else

            Dim intTotal As Integer = 0

            For Each intColumnIndex As Integer In colColumnIndexes

                intTotal += intColumnIndex

            Next

            If Not intTotal = 0 Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor)

                    Try

                        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

                            Me.dgvCategory.Rows.RemoveAt(dgvSelectedCell.RowIndex)

                        Next

                        PerformScenarioCalculations()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default)

                    End Try

                End If

            End If

        End If

    End Sub

    Sub CalculateAccountDetails()

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

        If blnIsCalculatingCurrentYear Then

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

        Else

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

        ColorTextboxes(lstGroupTextboxes)

    End Sub

    Sub PerformScenarioCalculations()

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvCategory)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvCategory)

        MainModule.DrawingControl.SetDoubleBuffered(Me.dgvMonthly)
        MainModule.DrawingControl.SuspendDrawing(Me.dgvMonthly)

        blnIsCalculatingScenario = True 'THIS VARIABLE IS USED IN MONTHLY GRID CURRENT CELL CHANGED SO IT DOESNT RUN CALCULATION WHEN ITS NOT SUPPOSED TO

        UIManager.SetCursor(Me, Cursors.WaitCursor)

        Sum_Category_Payee_Datagridview() 'RECALCULATES TOTALS FROM DATAGRIDVIEW VALUES

        CalculateMonthlyIncome_Scenario() 'RECALCULATES THE MONTHLY INCOME DATAGRIDVIEW

        CalculateAccountDetails()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

        UIManager.SetCursor(Me, Cursors.Default)

        blnIsCalculatingScenario = False

        dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)

        MainModule.DrawingControl.ResumeDrawing(Me.dgvCategory)
        MainModule.DrawingControl.ResumeDrawing(Me.dgvMonthly)

        dgvCategory.ClearSelection()

    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSaveScenario.Click, cxmnuSaveScenario.Click

        WriteScenarioData()

    End Sub

    Private Sub mnuMyScenarios_Click(sender As Object, e As EventArgs) Handles mnuMyScenarios.Click

        Dim strCurrentFile As String = String.Empty
        strCurrentFile = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)

        Dim strMyScenarios As String = String.Empty
        strMyScenarios = AppendDirectory(AppendLedgerDirectory(strCurrentFile), "Scenarios")

        If Not IO.Directory.Exists(strMyScenarios) Then
            IO.Directory.CreateDirectory(strMyScenarios)
        End If

        Dim intSelectedYear As Integer = 0
        intSelectedYear = CInt(cbYear.SelectedItem.ToString)

        If intSelectedYear < intYearsInLedger.Max Then

            Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

            Dim strMessage As String = String.Empty
            strMessage = "The selected year in Filter Options is not the most recent year in your ledger."

            Dim strAdvice As String = String.Empty
            strAdvice = "Select " & intYearsInLedger.Max & " in Filter Options to enable 'Create New Scenario'. Do you want to reset Spending Overview?"

            If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strAdvice, Exclamation) = DialogResult.Yes Then

                cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max)

            End If

        Else

            If System.IO.Directory.GetDirectories(strMyScenarios).Count = 0 Then

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                If CheckbookMsg.ShowMessage(strCurrentFile & " does not have any scenarios saved", MsgButtons.YesNo, "Do you want to create a new scenario?", Question) = DialogResult.Yes Then

                    CreateNewScenario()

                End If

            Else

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
                Dim strScenarioName As String = String.Empty

                Dim new_frmMyScenarios As New frmMyScenarios
                new_frmMyScenarios.caller_frmSpendingOverview = Me

                If new_frmMyScenarios.ShowDialog = DialogResult.OK Then

                    Dim intSelectedRowCount As Integer
                    intSelectedRowCount = new_frmMyScenarios.dgvMyScenarios.SelectedRows.Count

                    If intSelectedRowCount < 1 Then

                        CheckbookMsg.ShowMessage("There is no scenario selected to open", MsgButtons.OK, "", Exclamation)

                    Else

                        strScenarioName = new_frmMyScenarios.dgvMyScenarios.SelectedCells(0).Value.ToString

                        Dim scenario As String = String.Empty
                        scenario = AppendScenarioPath(strCurrentFile, strScenarioName)

                        strCurrentScenarioPath = scenario
                        strCurrentScenarioName = strScenarioName

                        LoadScenarioData(scenario)

                    End If

                End If

            End If

        End If

    End Sub

    Sub LoadTXTDataIntoDGV(ByVal _Path As String, ByVal _DataGridView As DataGridView)

        _DataGridView.Rows.Clear()

        Dim strTextLine As String = String.Empty
        Dim arrSplitLine() As String = Nothing

        Dim objReader As New System.IO.StreamReader(_Path)

        Do While objReader.Peek() <> -1

            strTextLine = objReader.ReadLine()

            arrSplitLine = Split(strTextLine, vbTab)

            _DataGridView.Rows.Add(arrSplitLine)

        Loop

        Dim strAmount As String = String.Empty

        For j As Integer = 0 To _DataGridView.Rows.Count - 1

            For i As Integer = 1 To _DataGridView.Columns.Count - 2

                strAmount = _DataGridView.Item(i, j).Value.ToString()
                strAmount = strAmount.Replace("""", "")

                If strAmount = String.Empty Then
                    strAmount = 0
                Else

                    strAmount = CDbl(strAmount)

                    _DataGridView.Item(i, j).Value = FormatCurrency(strAmount)

                End If

            Next

        Next

        objReader.Close()
        objReader = Nothing

    End Sub

    Sub LoadScenarioData(ByVal _ScenarioPath As String)

        Dim CheckbookMsg_Scenario_Name_Check As New CheckbookMessage.CheckbookMessage

        strCurrentScenarioPath = _ScenarioPath

        If Not cbYear.SelectedItem.ToString = intYearsInLedger.Max.ToString Then

            cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max.ToString) 'SELECT THE MOST RECENT YEAR IN YEARLIST

        End If

        Dim strCategoryTablePath As String = String.Empty
        Dim strMonthlyTablePath As String = String.Empty
        Dim strSelectedItem_Category_PayeePath As String = String.Empty
        Dim strSelectedItem_Payment_DepositPath As String = String.Empty

        strSelectedItem_Category_PayeePath = AppendFileName(strCurrentScenarioPath, "SelectedItem_Categories_Payees.whf")
        strSelectedItem_Payment_DepositPath = AppendFileName(strCurrentScenarioPath, "SelectedItem_Payments_Deposits.whf")

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If Not ReadLineFromFile(strSelectedItem_Category_PayeePath) = cbCategoriesPayees.Text Or Not ReadLineFromFile(strSelectedItem_Payment_DepositPath) = cbPaymentsDeposits.Text Then

            Dim strAdvice As String = String.Empty

            strAdvice = "The selected Scenario has the following 'Filter Options': " _
                        & vbNewLine & vbNewLine & ReadLineFromFile(strSelectedItem_Category_PayeePath) _
                        & vbNewLine & ReadLineFromFile(strSelectedItem_Payment_DepositPath)

            CheckbookMsg.ShowMessage("The Scenario you have selected has different 'Filter Options' than you currently have selected. This Scenario cannot be loaded.", MsgButtons.OK, strAdvice, Exclamation)

        Else

            Try

                Dim new_frmOpenScenario As New frmOpenScenario
                Dim strSelectedYear As String = String.Empty

                Dim lst As List(Of String) = New List(Of String)
                lst = YearList()
                new_frmOpenScenario.cbYears.Items.Clear()

                For Each strYear As String In lst
                    new_frmOpenScenario.cbYears.Items.Add(strYear)
                Next

                If new_frmOpenScenario.ShowDialog = DialogResult.OK Then

                    strSelectedYear = new_frmOpenScenario.cbYears.SelectedItem.ToString()
                    intCurrentHypotheticalYear = strSelectedYear

                    If intCurrentHypotheticalYear = intYearsInLedger.Max Then
                        blnIsCalculatingCurrentYear = True
                    Else
                        blnIsCalculatingCurrentYear = False
                    End If

                    strCategoryTablePath = AppendFileName(AppendDirectory(strCurrentScenarioPath, intCurrentHypotheticalYear), "CategoryTableScenario.whf")
                    strMonthlyTablePath = AppendFileName(AppendDirectory(strCurrentScenarioPath, intCurrentHypotheticalYear), "MonthlyTableScenario.whf")

                    If Not blnIsCalculatingCurrentYear Then

                        Dim currentYearPayments As String = FormatCurrency(CurrentYearPaymentsFromScenario(YearDirectory(intCurrentHypotheticalYear - 1)))
                        Dim currentYearDeposits As String = FormatCurrency(CurrentYearDepositsFromScenario(YearDirectory(intCurrentHypotheticalYear - 1)))
                        Dim overallPayments As String = FormatCurrency(OverallPaymentsFromScenario(intCurrentHypotheticalYear - 1))
                        Dim overallDeposists As String = FormatCurrency(OverallDepositsFromScenario(intCurrentHypotheticalYear - 1))
                        Dim overallBalance As String = FormatCurrency(OverallBalanceFromScenario(intCurrentHypotheticalYear - 1))

                        dblCurrentYearPayments_Saved = currentYearPayments
                        dblCurrentYearDeposits_Saved = currentYearDeposits
                        dblOverallTotalPayments_Saved = overallPayments
                        dblOverallTotalDeposits_Saved = overallDeposists
                        dblOverallBalance_Saved = overallBalance

                    End If

                    LoadTXTDataIntoDGV(strCategoryTablePath, dgvCategory)

                    Format_Category_Payee_Datagridview()

                    LoadTXTDataIntoDGV(strMonthlyTablePath, dgvMonthly)

                    Dim intSelectedYear As Integer = 0
                    intSelectedYear = cbYear.SelectedItem

                    If blnIsCalculatingCurrentYear Then

                        CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

                    Else

                        CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved)

                    End If

                    CalculateAccountDetails()

                    dgvCategory.Sort(dgvCategory.Columns(0), ListSortDirection.Ascending)
                    ColorTextboxes(lstGroupTextboxes)

                    UpdateAccountDetailGroupBoxText()

                    Dim modelingOptionFile As String = String.Empty
                    modelingOptionFile = AppendFileName(AppendDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strCurrentScenarioName), strSelectedYear), "ModelingOption.whf")

                    lblModelingOption.Text = ReadLineFromFile(modelingOptionFile)

                    EnableScenarioCommands()

                    dgvCategory.ClearSelection()
                    dgvMonthly.ClearSelection()


                Else

                    strCurrentScenarioName = String.Empty
                    strCurrentScenarioPath = String.Empty

                End If

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Load Error", MsgButtons.OK, "An error occurred while loading the Scenario file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

            Finally

                dgvCategory.ClearSelection()
                dgvMonthly.ClearSelection()

            End Try

        End If

    End Sub

    Sub WriteScenarioData()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Try

            Dim strYearDirectory As String = String.Empty
            Dim strCategoryTablePath As String = String.Empty
            Dim strMonthlyTablePath As String = String.Empty
            Dim strSelectedItem_Category_PayeePath As String = String.Empty
            Dim strSelectedItem_Payment_DepositPath As String = String.Empty
            Dim strScenarioDirectory As String = String.Empty

            Dim strCurrentFile As String = String.Empty
            strCurrentFile = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)

            strYearDirectory = AppendDirectory(AppendScenarioPath(strCurrentFile, strCurrentScenarioName), intCurrentHypotheticalYear)
            strScenarioDirectory = AppendScenarioPath(strCurrentFile, strCurrentScenarioName)

            strCategoryTablePath = AppendFileName(strYearDirectory, "CategoryTableScenario.whf")
            strMonthlyTablePath = AppendFileName(strYearDirectory, "MonthlyTableScenario.whf")
            strSelectedItem_Category_PayeePath = AppendFileName(strScenarioDirectory, "SelectedItem_Categories_Payees.whf")
            strSelectedItem_Payment_DepositPath = AppendFileName(strScenarioDirectory, "SelectedItem_Payments_Deposits.whf")

            If System.IO.Directory.Exists(strYearDirectory) Then

                If CheckbookMsg.ShowMessage(strCurrentScenarioName & " already contains " & intCurrentHypotheticalYear, MsgButtons.YesNo, "Do you want to overwrite " & intCurrentHypotheticalYear & "?", Question) = DialogResult.Yes Then

                    DeleteAllFilesInDirectory(strYearDirectory)

                    WriteDGVDataToTextFile(dgvCategory, strCategoryTablePath)
                    WriteDGVDataToTextFile(dgvMonthly, strMonthlyTablePath)

                    Dim strSelectedItem As String = String.Empty

                    strSelectedItem = cbCategoriesPayees.Text
                    WriteLineToFile(strSelectedItem, strSelectedItem_Category_PayeePath)

                    strSelectedItem = cbPaymentsDeposits.Text
                    WriteLineToFile(strSelectedItem, strSelectedItem_Payment_DepositPath)

                    Dim modelingOption As String = String.Empty
                    modelingOption = lblModelingOption.Text

                    Dim modelingOptionFile As String = String.Empty
                    modelingOptionFile = AppendFileName(AppendDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strCurrentScenarioName), intCurrentHypotheticalYear), "ModelingOption.whf")

                    WriteLineToFile(modelingOption, modelingOptionFile)

                    CheckbookMsg.ShowMessage(intCurrentHypotheticalYear & " was saved successfully.", MsgButtons.OK, "")

                End If

            Else

                My.Computer.FileSystem.CreateDirectory(strYearDirectory)

                WriteDGVDataToTextFile(dgvCategory, strCategoryTablePath)
                WriteDGVDataToTextFile(dgvMonthly, strMonthlyTablePath)

                Dim strSelectedItem As String = String.Empty

                strSelectedItem = cbCategoriesPayees.Text
                WriteLineToFile(strSelectedItem, strSelectedItem_Category_PayeePath)

                strSelectedItem = cbPaymentsDeposits.Text
                WriteLineToFile(strSelectedItem, strSelectedItem_Payment_DepositPath)

                Dim modelingOption As String = String.Empty
                modelingOption = lblModelingOption.Text

                Dim modelingOptionFile As String = String.Empty
                modelingOptionFile = AppendFileName(AppendDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strCurrentScenarioName), intCurrentHypotheticalYear), "ModelingOption.whf")

                WriteLineToFile(modelingOption, modelingOptionFile)

                CheckbookMsg.ShowMessage(intCurrentHypotheticalYear & " was saved successfully.", MsgButtons.OK, "")

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Save Error", MsgButtons.OK, "An error occurred while saving the Scenario file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

        Finally

            FileClose(1)

        End Try

    End Sub

    Sub WriteDGVDataToTextFile(ByVal _DataGridView As DataGridView, ByVal _Path As String)

        Dim I As Integer = 0
        Dim j As Integer = 0
        Dim strCellValue As String = String.Empty
        Dim strRowLine As String = String.Empty

        Dim objWriter As New System.IO.StreamWriter(_Path, True)

        For j = 0 To (_DataGridView.Rows.Count - 1)

            For I = 0 To (_DataGridView.Columns.Count - 1)

                If Not TypeOf _DataGridView.CurrentRow.Cells.Item(I).Value Is DBNull Then

                    strCellValue = _DataGridView.Item(I, j).Value

                Else
                    strCellValue = String.Empty
                End If

                strRowLine = strRowLine & strCellValue & vbTab

            Next

            objWriter.WriteLine(strRowLine)

            strRowLine = String.Empty

        Next

        objWriter.Close()
        objWriter = Nothing

    End Sub

    Private Sub dgvMonthly_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvMonthly.CurrentCellChanged

        dgvMonthly.EndEdit(True)
        dgvMonthly.ReadOnly = True

        Dim intSelectedYear As Integer = 0
        intSelectedYear = cbYear.SelectedItem

        If blnIsCalculatingScenario = True Then

            If blnIsCalculatingCurrentYear Then

                CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

            Else

                CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved)

            End If

            CalculateAccountDetails()

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

    Private Sub SaveCurrentYear(ByVal _CheckbookLedgerPath As String, ByVal _ScenarioName As String)

        Dim strYearDirectory As String = String.Empty
        strYearDirectory = AppendDirectory(AppendScenarioPath(_CheckbookLedgerPath, _ScenarioName), intYearsInLedger.Max)

        If Not IO.Directory.Exists(strYearDirectory) Then
            IO.Directory.CreateDirectory(strYearDirectory)
        End If

        Dim strScenarioDirectory As String = String.Empty
        Dim strSelectedItem_Category_PayeePath As String = String.Empty
        Dim strSelectedItem_Payment_DepositPath As String = String.Empty

        strScenarioDirectory = AppendScenarioPath(_CheckbookLedgerPath, _ScenarioName)
        strSelectedItem_Category_PayeePath = AppendFileName(strScenarioDirectory, "SelectedItem_Categories_Payees.whf")
        strSelectedItem_Payment_DepositPath = AppendFileName(strScenarioDirectory, "SelectedItem_Payments_Deposits.whf")

        Dim strSelectedItem As String = String.Empty

        strSelectedItem = cbCategoriesPayees.Text
        WriteLineToFile(strSelectedItem, strSelectedItem_Category_PayeePath)

        strSelectedItem = cbPaymentsDeposits.Text
        WriteLineToFile(strSelectedItem, strSelectedItem_Payment_DepositPath)

        Dim strCategoryTablePath As String = String.Empty
        Dim strMonthlyTablePath As String = String.Empty

        strCategoryTablePath = AppendFileName(strYearDirectory, "CategoryTableScenario.whf")
        strMonthlyTablePath = AppendFileName(strYearDirectory, "MonthlyTableScenario.whf")

        WriteDGVDataToTextFile(dgvCategory, strCategoryTablePath)
        WriteDGVDataToTextFile(dgvMonthly, strMonthlyTablePath)

        Dim modelingOption As String = String.Empty
        modelingOption = "Modeling Option: Model (" & intYearsInLedger.Max & ") in current state"

        Dim modelingOptionFile As String = String.Empty
        modelingOptionFile = AppendFileName(AppendDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), _ScenarioName), intYearsInLedger.Max), "ModelingOption.whf")

        WriteLineToFile(modelingOption, modelingOptionFile)

    End Sub

    Private Sub CreateNewScenario() Handles mnuCreateNewScenario.Click, cxmnuCreateNewScenario.Click

        If strCurrentScenarioName = String.Empty Then

            Dim new_frmSaveScenario As New frmCreate
            new_frmSaveScenario.Icon = My.Resources.scenario
            new_frmSaveScenario.Text = "Save Scenario"
            new_frmSaveScenario.lblNew.Text = "Scenario Name"

            If new_frmSaveScenario.ShowDialog = DialogResult.OK Then

                Dim strScenarioName As String = String.Empty
                strScenarioName = new_frmSaveScenario.txtEnter.Text

                Dim strCurrentFile As String = String.Empty
                strCurrentFile = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)

                Dim strScenarioPath As String = AppendScenarioPath(strCurrentFile, strScenarioName)

                If IO.Directory.Exists(strScenarioPath) Then

                    Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
                    CheckbookMsg.ShowMessage("Scenario already exists", MsgButtons.OK, "Provide a unique scenario name", Exclamation)
                    Exit Sub

                Else

                    Try

                        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
                        Dim new_frmScenario As New frmCreateNewScenario

                        Dim strModelCurrentYearKeepValues As String = String.Empty
                        Dim strModelCurrentYearFromScratch As String = String.Empty
                        Dim strModelNextYearKeepValues As String = String.Empty
                        Dim strModelNextYearFromScratch As String = String.Empty
                        Dim strCurrentModelingOptionSelected As String = String.Empty

                        strModelCurrentYearKeepValues = "Model (" & intYearsInLedger.Max & ") in current state"
                        strModelCurrentYearFromScratch = "Model (" & intYearsInLedger.Max & ") from scratch"
                        strModelNextYearKeepValues = "Model next year (" & intCurrentHypotheticalYear + 1 & ") and keep 'Current Year Details' as a starting point"
                        strModelNextYearFromScratch = "Model next year (" & intCurrentHypotheticalYear + 1 & ") from scratch"

                        new_frmScenario.rbModelCurrentYearKeepValues.Text = strModelCurrentYearKeepValues
                        new_frmScenario.rbModelCurrentYearFromScratch.Text = strModelCurrentYearFromScratch
                        new_frmScenario.rbModelNextYearAndOverallDetails.Text = strModelNextYearKeepValues
                        new_frmScenario.rbModelNextYearFromScratch.Text = strModelNextYearFromScratch

                        new_frmScenario.rbModelCurrentYearKeepValues.Checked = False
                        new_frmScenario.rbModelCurrentYearFromScratch.Checked = False
                        new_frmScenario.rbModelNextYearAndOverallDetails.Checked = False
                        new_frmScenario.rbModelNextYearFromScratch.Checked = False

                        If intCurrentHypotheticalYear > intYearsInLedger.Max Then
                            new_frmScenario.rbModelCurrentYearKeepValues.Enabled = False
                            new_frmScenario.rbModelCurrentYearFromScratch.Enabled = False
                        Else
                            new_frmScenario.rbModelCurrentYearKeepValues.Enabled = True
                            new_frmScenario.rbModelCurrentYearFromScratch.Enabled = True
                        End If

                        If new_frmScenario.ShowDialog = DialogResult.OK Then

                            If Not IO.Directory.Exists(strScenarioPath) Then
                                IO.Directory.CreateDirectory(strScenarioPath)
                            End If

                            blnIsWorkingInScenario = True

                            'GET MODELING OPTION CHOICE FROM USER
                            If new_frmScenario.rbModelCurrentYearKeepValues.Checked Then 'MODEL CURRENT YEAR AND KEEP CATEGORY VALUES

                                blnIsCalculatingCurrentYear = True
                                intCurrentHypotheticalYear = intYearsInLedger.Max

                                gbCurrentYear.Text = "Current Year Details (" & intYearsInLedger.Max & ")"
                                gbOverallDetails.Text = "Overall Account Details (" & intYearsInLedger.Max & ")"

                                lblModelingOption.Text = "Modeling Option: " & strModelCurrentYearKeepValues

                                SaveCurrentYear(strCurrentFile, strScenarioName)

                                EnableScenarioCommands()

                            ElseIf new_frmScenario.rbModelCurrentYearFromScratch.Checked Then 'MODEL CURRENT YEAR FROM SCRATCH

                                blnIsCalculatingCurrentYear = True
                                intCurrentHypotheticalYear = intYearsInLedger.Max

                                gbCurrentYear.Text = "Current Year Details (" & intYearsInLedger.Max & ")"
                                gbOverallDetails.Text = "Overall Account Details (" & intYearsInLedger.Max & ")"

                                lblModelingOption.Text = "Modeling Option: " & strModelCurrentYearFromScratch

                                dgvCategory.Rows.Clear()

                                For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                                    dgvRow.Cells("Payments").Value = "$0.00"
                                    dgvRow.Cells("Deposits").Value = "$0.00"
                                    dgvRow.Cells("Monthly").Value = "$0.00"
                                    dgvRow.Cells("AveMonthlyIncome").Value = "$0.00"
                                    dgvRow.Cells("OverallBalance").Value = "$0.00"

                                Next

                                SaveCurrentYear(strCurrentFile, strScenarioName)

                                FormatMonthlyGrid(dgvMonthly)

                                PerformScenarioCalculations()

                                AddMonthlyPaymentsOrDeposits()

                                PerformScenarioCalculations()

                                EnableScenarioCommands()

                            ElseIf new_frmScenario.rbModelNextYearAndOverallDetails.Checked Then 'MODEL NEXT YEAR AND KEEP CURRENT VALUES AS STARTING POINT

                                cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

                                blnIsCalculatingCurrentYear = False

                                intCurrentHypotheticalYear += 1
                                gbCurrentYear.Text = "Current Year Details (" & intCurrentHypotheticalYear & ")"
                                gbOverallDetails.Text = "Overall Account Details (" & intCurrentHypotheticalYear & ")"

                                lblModelingOption.Text = "Modeling Option: " & strModelNextYearKeepValues

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

                                SaveCurrentYear(strCurrentFile, strScenarioName)

                                'USE CURRENT DATAGRIDVIEW VALUES AS A STARTING POINT
                                PerformScenarioCalculations()

                                EnableScenarioCommands()

                            ElseIf new_frmScenario.rbModelNextYearFromScratch.Checked Then 'MODEL NEXT YEAR FROM SCRATCH

                                cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

                                blnIsCalculatingCurrentYear = False

                                intCurrentHypotheticalYear += 1
                                gbCurrentYear.Text = "Current Year Details (" & intCurrentHypotheticalYear & ")"
                                gbOverallDetails.Text = "Overall Account Details (" & intCurrentHypotheticalYear & ")"

                                lblModelingOption.Text = "Modeling Option: " & strModelNextYearFromScratch

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

                                SaveCurrentYear(strCurrentFile, strScenarioName)

                                dgvCategory.Rows.Clear()

                                For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                                    dgvRow.Cells("Payments").Value = "$0.00"
                                    dgvRow.Cells("Deposits").Value = "$0.00"
                                    dgvRow.Cells("Monthly").Value = "$0.00"
                                    dgvRow.Cells("AveMonthlyIncome").Value = "$0.00"
                                    dgvRow.Cells("OverallBalance").Value = "$0.00"

                                Next

                                FormatMonthlyGrid(dgvMonthly)

                                PerformScenarioCalculations()

                                AddMonthlyPaymentsOrDeposits()

                                PerformScenarioCalculations()

                                ColorTextboxes(lstGroupTextboxes)

                                EnableScenarioCommands()

                            End If

                            strCurrentScenarioName = strScenarioName
                            strCurrentScenarioPath = strScenarioPath

                            UpdateAccountDetailGroupBoxText()

                        End If

                        MyBase.Update()

                    Catch ex As Exception

                        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
                        CheckbookMsg.ShowMessage("Save Error", MsgButtons.OK, "An error occurred while saving the Scenario file" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                    End Try

                End If

            End If

        Else

            If Not Directory.Exists(AppendDirectory(AppendScenarioPath(m_strCurrentFile, strCurrentScenarioName), intCurrentHypotheticalYear)) Then

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                CheckbookMsg.ShowMessage(intCurrentHypotheticalYear & " must be saved before continuing", MsgButtons.OK, "", Exclamation)

            Else

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
                Dim new_frmScenario As New frmCreateNewScenario

                Dim strModelCurrentYearKeepValues As String = String.Empty
                Dim strModelCurrentYearFromScratch As String = String.Empty
                Dim strModelNextYearKeepValues As String = String.Empty
                Dim strModelNextYearFromScratch As String = String.Empty
                Dim strCurrentModelingOptionSelected As String = String.Empty

                strModelCurrentYearKeepValues = "Model (" & intYearsInLedger.Max & ") in current state"
                strModelCurrentYearFromScratch = "Model (" & intYearsInLedger.Max & ") from scratch"
                strModelNextYearKeepValues = "Model next year (" & intCurrentHypotheticalYear + 1 & ") and keep 'Current Year Details' as a starting point"
                strModelNextYearFromScratch = "Model next year (" & intCurrentHypotheticalYear + 1 & ") from scratch"

                new_frmScenario.rbModelCurrentYearKeepValues.Text = strModelCurrentYearKeepValues
                new_frmScenario.rbModelCurrentYearFromScratch.Text = strModelCurrentYearFromScratch
                new_frmScenario.rbModelNextYearAndOverallDetails.Text = strModelNextYearKeepValues
                new_frmScenario.rbModelNextYearFromScratch.Text = strModelNextYearFromScratch

                new_frmScenario.rbModelCurrentYearKeepValues.Checked = False
                new_frmScenario.rbModelCurrentYearFromScratch.Checked = False
                new_frmScenario.rbModelNextYearAndOverallDetails.Checked = False
                new_frmScenario.rbModelNextYearFromScratch.Checked = False

                If intCurrentHypotheticalYear + 1 > intYearsInLedger.Max Then
                    new_frmScenario.rbModelCurrentYearKeepValues.Enabled = False
                    new_frmScenario.rbModelCurrentYearFromScratch.Enabled = False
                Else
                    new_frmScenario.rbModelCurrentYearKeepValues.Enabled = True
                    new_frmScenario.rbModelCurrentYearFromScratch.Enabled = True
                End If

                If new_frmScenario.ShowDialog = DialogResult.OK Then

                    blnIsWorkingInScenario = True

                    'GET MODELING OPTION CHOICE FROM USER
                    If new_frmScenario.rbModelCurrentYearKeepValues.Checked Then 'MODEL CURRENT YEAR AND KEEP CATEGORY VALUES

                        blnIsCalculatingCurrentYear = True
                        intCurrentHypotheticalYear = intYearsInLedger.Max

                        gbCurrentYear.Text = "Current Year Details (" & intYearsInLedger.Max & ")"
                        gbOverallDetails.Text = "Overall Account Details (" & intYearsInLedger.Max & ")"

                        lblModelingOption.Text = "Modeling Option: " & strModelCurrentYearKeepValues

                        EnableScenarioCommands()

                    ElseIf new_frmScenario.rbModelCurrentYearFromScratch.Checked Then 'MODEL CURRENT YEAR FROM SCRATCH

                        blnIsCalculatingCurrentYear = True
                        intCurrentHypotheticalYear = intYearsInLedger.Max

                        gbCurrentYear.Text = "Current Year Details (" & intYearsInLedger.Max & ")"
                        gbOverallDetails.Text = "Overall Account Details (" & intYearsInLedger.Max & ")"

                        lblModelingOption.Text = "Modeling Option: " & strModelCurrentYearFromScratch

                        dgvCategory.Rows.Clear()

                        For Each dgvRow As DataGridViewRow In dgvMonthly.Rows

                            dgvRow.Cells("Payments").Value = "$0.00"
                            dgvRow.Cells("Deposits").Value = "$0.00"
                            dgvRow.Cells("Monthly").Value = "$0.00"
                            dgvRow.Cells("AveMonthlyIncome").Value = "$0.00"
                            dgvRow.Cells("OverallBalance").Value = "$0.00"

                        Next

                        FormatMonthlyGrid(dgvMonthly)

                        PerformScenarioCalculations()

                        AddMonthlyPaymentsOrDeposits()

                        PerformScenarioCalculations()

                        EnableScenarioCommands()

                    ElseIf new_frmScenario.rbModelNextYearAndOverallDetails.Checked Then 'MODEL NEXT YEAR AND KEEP CURRENT VALUES AS STARTING POINT

                        cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

                        blnIsCalculatingCurrentYear = False

                        intCurrentHypotheticalYear += 1
                        gbCurrentYear.Text = "Current Year Details (" & intCurrentHypotheticalYear & ")"
                        gbOverallDetails.Text = "Overall Account Details (" & intCurrentHypotheticalYear & ")"

                        lblModelingOption.Text = "Modeling Option: " & strModelNextYearKeepValues

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
                        PerformScenarioCalculations()

                        EnableScenarioCommands()

                    ElseIf new_frmScenario.rbModelNextYearFromScratch.Checked Then 'MODEL NEXT YEAR FROM SCRATCH

                        cbYear.SelectedIndex = cbYear.FindStringExact(intYearsInLedger.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

                        blnIsCalculatingCurrentYear = False

                        intCurrentHypotheticalYear += 1
                        gbCurrentYear.Text = "Current Year Details (" & intCurrentHypotheticalYear & ")"
                        gbOverallDetails.Text = "Overall Account Details (" & intCurrentHypotheticalYear & ")"

                        lblModelingOption.Text = "Modeling Option: " & strModelNextYearFromScratch

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

                        PerformScenarioCalculations()

                        AddMonthlyPaymentsOrDeposits()

                        PerformScenarioCalculations()

                        ColorTextboxes(lstGroupTextboxes)

                        EnableScenarioCommands()
                        UpdateAccountDetailGroupBoxText()

                    End If

                    UpdateAccountDetailGroupBoxText()

                End If

                MyBase.Update()

            End If

        End If

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
            Dim dblMonthlyAmount As Double = 0

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
    ''' <param name="_Path"></param>
    Private Sub WriteLineToFile(ByVal _Line As String, ByVal _Path As String)

        Dim writer As New IO.StreamWriter(_Path, True)

        writer.WriteLine(_Line)

        writer.Close()
        writer = Nothing

    End Sub

    ''' <summary>
    ''' Returns the last line of text in a specified file. Only useful for reading a file with one line.
    ''' </summary>
    ''' <param name="_file"></param>
    Private Function ReadLineFromFile(ByVal _File As String) As String

        Dim reader As New IO.StreamReader(_File)
        Dim strLine As String = String.Empty

        Do While reader.Peek() <> -1

            strLine = reader.ReadLine

        Loop

        reader.Close()
        reader = Nothing

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

        Dim colColumnIndexes As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvMonthly.SelectedCells

            colColumnIndexes.Add(dgvSelectedCell.ColumnIndex)

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

            If colColumnIndexes.Contains(0) Or colColumnIndexes.Contains(intPaymentOrDepositColumnIndex) Or colColumnIndexes.Contains(3) Or colColumnIndexes.Contains(4) Or colColumnIndexes.Contains(5) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                Dim new_frmEditValues As New frmEditValues
                new_frmEditValues.Text = "Edit Monthly Totals"
                Dim strNewValue As String = String.Empty

                If new_frmEditValues.ShowDialog = Windows.Forms.DialogResult.OK Then

                    strNewValue = FormatCurrency(new_frmEditValues.txtNewExpenseValue.Text)

                    If CheckbookMsg.ShowMessage(strConfirmRemoveMessage & strNewValue & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                        UIManager.SetCursor(Me, Cursors.WaitCursor)

                        Try

                            EditMonthlyIncomeCells(strNewValue)

                        Catch ex As Exception

                            CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                        Finally

                            UIManager.SetCursor(Me, Cursors.Default)

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

        Dim colColumnIndexes As New List(Of Integer)

        Dim intPaymentOrDepositColumnIndex As Integer = 0

        If cbPaymentsDeposits.Text = "Payments" Then
            intPaymentOrDepositColumnIndex = 1
            strInvalidSelectionMessage = "Select only the deposits you want to remove"
        Else
            intPaymentOrDepositColumnIndex = 2
            strInvalidSelectionMessage = "Select only the payments you want to remove"
        End If

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvMonthly.SelectedCells

            colColumnIndexes.Add(dgvSelectedCell.ColumnIndex)

        Next

        If Me.dgvMonthly.SelectedCells.Count = 0 Then

            CheckbookMsg.ShowMessage(strNoneSelectedMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            If colColumnIndexes.Contains(0) Or colColumnIndexes.Contains(intPaymentOrDepositColumnIndex) Or colColumnIndexes.Contains(3) Or colColumnIndexes.Contains(4) Or colColumnIndexes.Contains(5) Then

                CheckbookMsg.ShowMessage(strInvalidSelectionMessage, MsgButtons.OK, "", Exclamation)

            Else

                If CheckbookMsg.ShowMessage(strConfirmRemoveMessage, MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    UIManager.SetCursor(Me, Cursors.WaitCursor)

                    Try

                        EditMonthlyIncomeCells("$0.00")

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage(strErrorMessageTitle, MsgButtons.OK, strErrorMessage & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default)

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub EditMonthlyIncomeCells(ByVal _NewValue As String)

        Dim intSelectedYear As Integer = 0
        intSelectedYear = cbYear.SelectedItem

        For Each dgvSelectedCell As DataGridViewCell In dgvMonthly.SelectedCells

            dgvSelectedCell.Value = _NewValue

        Next

        If blnIsCalculatingCurrentYear Then

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        Else

            CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear, True, dblOverallBalance_Saved) 'ONLY CALCULATES MONTHLY INCOME AND AVERAGE INCOME. DOES NOT CALCULATE TOTAL PAYMENTS AND DEPOSITS

        End If

        CalculateAccountDetails()  'CALCULATES NEW ACCOUNT DETAILS BASED ON HYPOTHETICAL VALUES

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/spending_overview.html"
        Process.Start(strWebAddress)

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

                Dim strExportPath As String = String.Empty
                strExportPath = sfdDialog.FileName

                If CheckbookMsg.ShowMessage("Are you sure you want to export your monthly totals to " & strExportPath & "?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        UIManager.SetCursor(Me, Cursors.WaitCursor)

                        ExportSpendingOverview(strExportPath)

                        UIManager.SetCursor(Me, Cursors.Default)

                        If CheckbookMsg.ShowMessage("Your monthly totals have exported successfully.", MsgButtons.YesNo, "Would you like to open the file now?", Question) = DialogResult.Yes Then

                            Process.Start(strExportPath)

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

    Private Sub ExportSpendingOverview(ByVal _Path As String)

        Dim writer As New StreamWriter(_Path)

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
        writer = Nothing

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

        Dim colColumnIndexes As New List(Of Integer)

        For Each dgvSelectedCell As DataGridViewCell In Me.dgvCategory.SelectedCells

            colColumnIndexes.Add(dgvSelectedCell.ColumnIndex)

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

            If colColumnIndexes.Contains(0) Or colColumnIndexes.Contains(13) Or colColumnIndexes.Contains(14) Then

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
        mnuSaveScenario.Enabled = True
        mnuOpenScenario.Enabled = True
        mnuCloseScenario.Enabled = True
        cxmnuSaveScenario.Enabled = True
        cxmnuOpenScenario.Enabled = True
        cxmnuCloseScenario.Enabled = True

        'EDIT MENU
        mnuCreateExpense.Enabled = True
        mnuEditExpense.Enabled = True
        mnuRemoveExpenses.Enabled = True
        mnuRemoveCategory.Enabled = True
        mnuCopyToNextMonth.Enabled = True
        mnuCopyToSelectedMonths.Enabled = True
        mnuCopyToRestOfYear.Enabled = True
        mnuCreateNewScenario.Enabled = True
        mnuResetSpendingOverview.Enabled = True

        'CONTEXT MENU
        cxmnuCreateExpense.Enabled = True
        cxmnuEditExpense.Enabled = True
        cxmnuRemoveExpenses.Enabled = True
        cxmnuRemoveCategories.Enabled = True
        cxmnuCopyToNextMonth.Enabled = True
        cxmnuCopyToSelectedMonths.Enabled = True
        cxmnuCopyToRestOfYear.Enabled = True
        cxmnuCreateNewScenario.Enabled = True
        cxmnuResetSpendingOverview.Enabled = True

        'MONTHLY INCOME TABLE
        cxmnuMonthlyIncomeTable.Enabled = True

        gbFilterOptions.Enabled = False

    End Sub

    Private Sub DisableScenarioCommands()

        'FILE MENU
        mnuSaveScenario.Enabled = False
        mnuOpenScenario.Enabled = False
        mnuCloseScenario.Enabled = False
        cxmnuSaveScenario.Enabled = False
        cxmnuOpenScenario.Enabled = False
        cxmnuCloseScenario.Enabled = False

        'EDIT MENU
        mnuCreateExpense.Enabled = False
        mnuEditExpense.Enabled = False
        mnuRemoveExpenses.Enabled = False
        mnuRemoveCategory.Enabled = False
        mnuCopyToNextMonth.Enabled = False
        mnuCopyToSelectedMonths.Enabled = False
        mnuCopyToRestOfYear.Enabled = False
        mnuResetSpendingOverview.Enabled = False

        'CONTEXT MENU
        cxmnuCreateExpense.Enabled = False
        cxmnuEditExpense.Enabled = False
        cxmnuRemoveExpenses.Enabled = False
        cxmnuRemoveCategories.Enabled = False
        cxmnuCopyToNextMonth.Enabled = False
        cxmnuCopyToSelectedMonths.Enabled = False
        cxmnuCopyToRestOfYear.Enabled = False
        cxmnuResetSpendingOverview.Enabled = False

        'MONTHLY INCOME TABLE
        cxmnuMonthlyIncomeTable.Enabled = False

        If Not CInt(cbYear.SelectedItem) = intYearsInLedger.Max Then

            mnuCreateNewScenario.Enabled = False
            cxmnuCreateNewScenario.Enabled = False

            lblScenario.Text = "Scenario: "
            lblModelingOption.Text = "Modeling Option: Select (" & intYearsInLedger.Max & ") in 'Filter Options' to enable 'Create New Scenario'"

        Else

            mnuCreateNewScenario.Enabled = True
            cxmnuCreateNewScenario.Enabled = True

            lblScenario.Text = "Scenario: "
            lblModelingOption.Text = "Modeling Option: Select 'Create New Scenario' to start a new scenario or open an existing one"

        End If

        gbFilterOptions.Enabled = True

        MyBase.Update()

    End Sub

    Private Function OverallBalanceFromScenario(ByVal _SelectedYear As String) As Double

        Dim total As Double = 0
        Dim startingBalance As Double = 0
        startingBalance = MainForm.txtStartingBalance.Text

        total = startingBalance - OverallPaymentsFromScenario(_SelectedYear) + OverallDepositsFromScenario(_SelectedYear)

        Return total
    End Function

    Private Function OverallDepositsFromScenario(ByVal _SelectedYear As String) As Double

        Dim dblTotal As Double = 0
        Dim lst As List(Of String) = New List(Of String)
        lst = YearList()

        Dim dblTotalPaymentsPrior As Double = 0
        Dim dblTotalDepositsPrior As Double = 0

        CalculateTotalPayments_Deposits_BeforeProvidedYear(Integer.Parse(intYearsInLedger.Max), dblTotalPaymentsPrior, dblTotalDepositsPrior)

        If _SelectedYear = intYearsInLedger.Max Then
            dblTotal = dblTotalDepositsPrior + CurrentYearDepositsFromScenario(YearDirectory(_SelectedYear))
        ElseIf _SelectedYear > intYearsInLedger.Max Then

            For Each Dir As String In System.IO.Directory.GetDirectories(strCurrentScenarioPath)

                Dim dirInfo As New System.IO.DirectoryInfo(Dir)
                Dim year As Integer = Integer.Parse(dirInfo.Name)

                If year <= _SelectedYear Then

                    dblTotal += CurrentYearDepositsFromScenario(YearDirectory(year.ToString()))

                End If

            Next

            dblTotal += dblTotalDepositsPrior

        End If

        Return dblTotal
    End Function

    Private Function OverallPaymentsFromScenario(ByVal _SelectedYear As String) As Double

        Dim dblTotal As Double = 0
        Dim lst As List(Of String) = New List(Of String)
        lst = YearList()

        Dim dblTotalPaymentsPrior As Double = 0
        Dim dblTotalDepositsPrior As Double = 0

        CalculateTotalPayments_Deposits_BeforeProvidedYear(Integer.Parse(intYearsInLedger.Max), dblTotalPaymentsPrior, dblTotalDepositsPrior)

        If _SelectedYear = intYearsInLedger.Max Then
            dblTotal = dblTotalPaymentsPrior + CurrentYearPaymentsFromScenario(YearDirectory(_SelectedYear))
        ElseIf _SelectedYear > intYearsInLedger.Max Then

            For Each Dir As String In System.IO.Directory.GetDirectories(strCurrentScenarioPath)

                Dim dirInfo As New System.IO.DirectoryInfo(Dir)
                Dim year As Integer = Integer.Parse(dirInfo.Name)

                If year <= _SelectedYear Then

                    dblTotal += CurrentYearPaymentsFromScenario(YearDirectory(year.ToString()))

                End If

            Next

            dblTotal += dblTotalPaymentsPrior

        End If

        Return dblTotal
    End Function

    Private Function CurrentYearDepositsFromScenario(ByVal _ScenarioPath As String) As Double

        Dim dblTotal As Double = 0

        Dim objReader As StreamReader = New System.IO.StreamReader(_ScenarioPath)
        Dim line As String = ""

        Do While objReader.Peek() <> -1

            line = objReader.ReadLine()
            Dim chrSep As Char() = New Char() {vbTab}
            Dim arr As String() = line.Split(chrSep, StringSplitOptions.None)

            Dim monthTotal As Double = arr(2)

            dblTotal += monthTotal

        Loop

        objReader.Close()
        objReader = Nothing

        Return dblTotal
    End Function

    Private Function CurrentYearPaymentsFromScenario(ByVal _ScenarioPath As String) As Double

        Dim dblTotal As Double = 0

        Dim objReader As StreamReader = New System.IO.StreamReader(_ScenarioPath)
        Dim line As String = ""

        Do While objReader.Peek() <> -1

            line = objReader.ReadLine()
            Dim chrSep As Char() = New Char() {vbTab}
            Dim arr As String() = line.Split(chrSep, StringSplitOptions.None)

            Dim monthTotal As Double = arr(1)

            dblTotal += monthTotal

        Loop

        objReader.Close()
        objReader = Nothing

        Return dblTotal
    End Function

    Private Function YearList() As List(Of String)

        Dim lst As List(Of String) = New List(Of String)

        For Each Dir As String In System.IO.Directory.GetDirectories(strCurrentScenarioPath)
            Dim dirInfo As New System.IO.DirectoryInfo(Dir)
            lst.Add(dirInfo.Name)
        Next

        Return lst
    End Function

    Private Function YearDirectory(ByVal _YearToCalculate As String) As String

        Dim file As String = ""

        file = strCurrentScenarioPath & "\" & _YearToCalculate & "\MonthlyTableScenario.whf"

        Return file
    End Function

    Private Sub UpdateAccountDetailGroupBoxText()

        Dim strOverallGroupBoxText As String = gbOverallDetails.Text
        Dim strCurrentGroupBoxText As String = gbCurrentYear.Text
        Dim strModelingOptionText As String = lblModelingOption.Text
        Dim strYearToReplace As String = String.Empty

        strYearToReplace = Regex.Match(strOverallGroupBoxText, "(?<=\().+?(?=\))").Value

        strOverallGroupBoxText = strOverallGroupBoxText.Replace(strYearToReplace, intCurrentHypotheticalYear)
        strCurrentGroupBoxText = strCurrentGroupBoxText.Replace(strYearToReplace, intCurrentHypotheticalYear)
        strModelingOptionText = strModelingOptionText.Replace(strYearToReplace, intCurrentHypotheticalYear)

        gbOverallDetails.Text = strOverallGroupBoxText
        gbCurrentYear.Text = strCurrentGroupBoxText

        lblScenario.Text = "Scenario: " & strCurrentScenarioName
        lblModelingOption.Text = strModelingOptionText

    End Sub

    Private Sub mnuCloseScenario_Click(sender As Object, e As EventArgs) Handles mnuCloseScenario.Click, cxmnuCloseScenario.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strMessage As String = "Are you sure you want to close " & strCurrentScenarioName & "? Any unsaved data will be lost."
        Dim strAdvice As String = "Spending Overview will be reset to it's original state"

        If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strAdvice, Question) = DialogResult.Yes Then

            ResetSpendingOverview()

        End If

    End Sub

    Private Sub mnuOpenScenario_Click(sender As Object, e As EventArgs) Handles mnuOpenScenario.Click, cxmnuOpenScenario.Click

        Dim scenario As String = String.Empty
        scenario = AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strCurrentScenarioName)

        LoadScenarioData(scenario)

    End Sub

End Class