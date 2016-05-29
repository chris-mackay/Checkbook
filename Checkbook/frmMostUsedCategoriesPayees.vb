Public Class frmMostUsedCategoriesPayees

    Private yearList As New List(Of Integer)
    Private totalMonthList As New List(Of Integer)
    Private actualMonthList As New List(Of Integer)
    Private intYearCount As Integer
    Private intMonthCount As Integer
    Private usedPayeesFromLedgerCollection As New Collection
    Private usedCategoriesFromLedgerCollection As New Collection

    Private Sub frmMostUsedCategoriesPayees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddColumns()

        DetermineYearsInLedger_And_CountYears()
        DetermineMonthsInLedger_And_CountMonths()
        DetermineUsedCategoriesFromLedger()
        DetermineUsedPayeesFromLedger()

        cbCategoriesPayees.Text = "Categories"
        cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST. THIS

        MessageBox.Show("year count: " & intYearCount & " month count: " & intMonthCount)

    End Sub

    Private Sub AddColumns()

        Dim colNumberOfTransations As New DataGridViewTextBoxColumn
        Dim colItem As New DataGridViewTextBoxColumn
        Dim colTotalPayments As New DataGridViewTextBoxColumn
        Dim colTotalDeposits As New DataGridViewTextBoxColumn
        Dim colAveragePerMonth As New DataGridViewTextBoxColumn
        Dim colAveragePerYear As New DataGridViewTextBoxColumn

        colItem.CellTemplate = New DataGridViewTextBoxCell
        colItem.Name = "category"
        colItem.HeaderText = "Category"
        colItem.ReadOnly = True

        colTotalPayments.CellTemplate = New DataGridViewTextBoxCell
        colTotalPayments.Name = "payments"
        colTotalPayments.HeaderText = "Payments"
        colTotalPayments.ReadOnly = True

        colTotalDeposits.CellTemplate = New DataGridViewTextBoxCell
        colTotalDeposits.Name = "deposits"
        colTotalDeposits.HeaderText = "Deposits"
        colTotalDeposits.ReadOnly = True

        colAveragePerMonth.CellTemplate = New DataGridViewTextBoxCell
        colAveragePerMonth.Name = "averagePerMonth"
        colAveragePerMonth.HeaderText = "Ave. Monthly"
        colAveragePerMonth.ReadOnly = True

        colAveragePerYear.CellTemplate = New DataGridViewTextBoxCell
        colAveragePerYear.Name = "averagePerYear"
        colAveragePerYear.HeaderText = "Ave. Yearly"
        colAveragePerYear.ReadOnly = True

        colNumberOfTransations.CellTemplate = New DataGridViewTextBoxCell
        colNumberOfTransations.Name = "numberOfTransactions"
        colNumberOfTransations.HeaderText = "# Transactions"
        colNumberOfTransations.ReadOnly = True

        dgvMostUsed.Columns.Add(colItem)
        dgvMostUsed.Columns.Add(colTotalPayments)
        dgvMostUsed.Columns.Add(colTotalDeposits)
        dgvMostUsed.Columns.Add(colAveragePerMonth)
        dgvMostUsed.Columns.Add(colAveragePerYear)
        dgvMostUsed.Columns.Add(colNumberOfTransations)

    End Sub

    Private Sub AddRow(ByVal _category As String, ByVal _budget As String)

        dgvMostUsed.Rows.Add(_category, _budget)
        dgvMostUsed.ClearSelection()

    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged

        'CLEAR ALL ROWS FROM GRIDVIEW

        'TRIGGER CALCULATIONS FOR:
        'TOTAL PAYMENTS
        'TOTAL DEPOSITS
        'AVERAGE MONTHLY
        'AVERAGE YEARLY

        'ADD ROWS

    End Sub

    Private Sub DetermineYearsInLedger_And_CountYears()

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows 'FINDS ALL THE YEARS THAT EXIST IN THE LEDGER AND LOADS THEM INTO THE LIST

            Dim intYear As Integer
            Dim i As Integer = Nothing
            Dim dtDate As Date
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            If Not yearList.Contains(intYear) Then

                yearList.Add(intYear)

            End If

            If Not cbYear.Items.Contains(intYear) Then

                cbYear.Items.Add(intYear) 'IF THE YEAR DOESNT ALREADY EXIST WITHIN THE LIST THEN IT WILL BE ADDED
                intYearCount += 1

            End If

        Next

        cbYear.Items.Add("Entire Ledger")

    End Sub

    Private Sub DetermineMonthsInLedger_And_CountMonths()

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim intMonth As Integer
            Dim i As Integer = Nothing
            Dim dtDate As Date
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intMonth = dtDate.Month

            totalMonthList.Add(intMonth)

        Next

        'For Each month As Integer In totalMonthList

        '    intMonthCount += 1

        'Next

        intMonthCount = totalMonthList.Where(Function(value) value = 1).Count


        'For Each month As Integer In totalMonthList

        '    Dim itemCount As Integer
        '    itemCount = totalMonthList.Where(Function(value) value = month).Count

        '    If itemCount <= intYearCount Then

        '        actualMonthList.Add(month)

        '    End If

        'Next

        'For Each month As Integer In actualMonthList

        '    intMonthCount += 1

        'Next

    End Sub

    Private Function CalculateTotalPayments()

        Dim dblTotalPayments As Double

        'NEED TO CHECK IF 'Entire Ledger' is selected
        'IF ONLY A YEAR IS SELECTED THEN CALCULATE FOR THAT YEAR



        Return dblTotalPayments
    End Function

    Private Function CalculateTotalDeposits()

        Dim dblTotalDeposits As Double

        'NEED TO CHECK IF 'Entire Ledger' is selected
        'IF ONLY A YEAR IS SELECTED THEN CALCULATE FOR THAT YEAR


        Return dblTotalDeposits
    End Function

    Private Function CalculateAveMonthly()

        Dim dblAveMonthly As Double

        'NEED TO CHECK IF 'Entire Ledger' is selected
        'IF ONLY A YEAR IS SELECTED THEN CALCULATE FOR THAT YEAR


        Return dblAveMonthly
    End Function

    Private Function CalculateAveYearly()

        Dim dblAveYearly As Double

        'NEED TO CHECK IF 'Entire Ledger' is selected
        'IF ONLY A YEAR IS SELECTED THEN CALCULATE FOR THAT YEAR



        Return dblAveYearly
    End Function

    Public Sub DetermineUsedCategoriesFromLedger()

        usedCategoriesFromLedgerCollection.Clear()

        Dim strCategory As String

        'DETERMINES CATEGORIES USED IN LEDGER
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString

            If Not strCategory = "Uncategorized" Then

                usedCategoriesFromLedgerCollection.Add(strCategory)

            End If

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedCategoriesFromLedgerCollection)

    End Sub

    Public Sub DetermineUsedPayeesFromLedger()

        usedPayeesFromLedgerCollection.Clear()

        Dim strPayee As String

        'DETERMINES PAYEES USED IN LEDGER
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index

            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString

            If Not strPayee = "Unknown" Then

                usedPayeesFromLedgerCollection.Add(strPayee)

            End If

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedPayeesFromLedgerCollection)

    End Sub

End Class