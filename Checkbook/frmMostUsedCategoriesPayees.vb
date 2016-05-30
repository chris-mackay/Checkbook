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

Public Class frmMostUsedCategoriesPayees

    Private UIManager As New clsUIManager

    Private usedPayeesFromLedgerCollection_NoDuplicates_EntireLedger As New Collection
    Private usedCategoriesFromLedgerCollection_NoDuplicates_EntireLedger As New Collection
    Private usedPayeesFromLedgerList_WithDuplicates_EntireLedger As New List(Of String)
    Private usedCategoriesFromLedgerList_WithDuplicates_EntireLedger As New List(Of String)

    Private usedPayeesFromLedgerCollection_NoDuplicates_SelectedYear As New Collection
    Private usedCategoriesFromLedgerCollection_NoDuplicates_SelectedYear As New Collection
    Private usedPayeesFromLedgerList_WithDuplicates_SelectedYear As New List(Of String)
    Private usedCategoriesFromLedgerList_WithDuplicates_SelectedYear As New List(Of String)

    Private Sub frmMostUsedCategoriesPayees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UIManager.SetCursor(Me, Cursors.WaitCursor)

        MainModule.DrawingControl.SetDoubleBuffered(dgvMostUsed)
        MainModule.DrawingControl.SuspendDrawing(dgvMostUsed)

        AddColumns()

        DetermineYearsInLedger()

        cbCategoriesPayees.SelectedIndex = cbCategoriesPayees.FindStringExact("Categories") 'TRIGGERS CALCULATIONS
        cbYear.SelectedIndex = cbYear.FindStringExact("Entire Ledger") 'TRIGGERS CALCULATIONS

        MainModule.DrawingControl.ResumeDrawing(dgvMostUsed)

        UIManager.SetCursor(Me, Cursors.Default)

    End Sub

    Private Sub dgvMostUsed_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgvMostUsed.CellFormatting

        If Me.dgvMostUsed.Columns(e.ColumnIndex).Name = "payments" Then
            If e.Value = "$0.00" Then
                e.CellStyle.ForeColor = Color.Transparent
                e.CellStyle.SelectionForeColor = Color.Transparent
            End If
        End If

        If Me.dgvMostUsed.Columns(e.ColumnIndex).Name = "deposits" Then
            If e.Value = "$0.00" Then
                e.CellStyle.ForeColor = Color.Transparent
                e.CellStyle.SelectionForeColor = Color.Transparent
            End If
        End If

    End Sub

    Private Sub AddColumns()

        Dim colNumberOfTransations As New DataGridViewTextBoxColumn
        Dim colItem As New DataGridViewTextBoxColumn
        Dim colTotalPayments As New DataGridViewTextBoxColumn
        Dim colTotalDeposits As New DataGridViewTextBoxColumn

        '# TRANSACTIONS
        colNumberOfTransations.CellTemplate = New DataGridViewTextBoxCell
        colNumberOfTransations.Name = "numberOfTransactions"
        colNumberOfTransations.HeaderText = "# Transactions"
        colNumberOfTransations.ReadOnly = True

        'CATEGORY OR PAYEE
        colItem.CellTemplate = New DataGridViewTextBoxCell
        colItem.Name = "category"
        colItem.HeaderText = "Category"
        colItem.ReadOnly = True

        'TOTAL PAYMENTS
        colTotalPayments.CellTemplate = New DataGridViewTextBoxCell
        colTotalPayments.Name = "payments"
        colTotalPayments.HeaderText = "Payments"
        colTotalPayments.ReadOnly = True
        colTotalPayments.DefaultCellStyle.Format = "c"

        'TOTAL DEPOSITS
        colTotalDeposits.CellTemplate = New DataGridViewTextBoxCell
        colTotalDeposits.Name = "deposits"
        colTotalDeposits.HeaderText = "Deposits"
        colTotalDeposits.ReadOnly = True
        colTotalDeposits.DefaultCellStyle.Format = "c"

        'ADD COLLUMNS TO DATAGRIDVIEW
        dgvMostUsed.Columns.Add(colNumberOfTransations)
        dgvMostUsed.Columns.Add(colItem)
        dgvMostUsed.Columns.Add(colTotalPayments)
        dgvMostUsed.Columns.Add(colTotalDeposits)

    End Sub

    Private Sub AddRow(ByVal _numOccurences As Integer, ByVal _category As String, ByVal _payments As Double, ByVal _deposits As Double)

        dgvMostUsed.Rows.Add(_numOccurences, _category, _payments, _deposits)
        dgvMostUsed.ClearSelection()

    End Sub

    Private Sub cbCategoriesPayees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoriesPayees.SelectedIndexChanged, cbYear.SelectedIndexChanged

        UIManager.SetCursor(Me, Cursors.WaitCursor)

        MainModule.DrawingControl.SetDoubleBuffered(dgvMostUsed)
        MainModule.DrawingControl.SuspendDrawing(dgvMostUsed)

        dgvMostUsed.Rows.Clear()

        If cbCategoriesPayees.Text = "Categories" Then

            If cbYear.Text = "Entire Ledger" Then 'CALCULATE FOR ENTIRE LEDGER

                DetermineUsedCategories_EntireLedger()

                For Each strCategory As String In usedCategoriesFromLedgerCollection_NoDuplicates_EntireLedger

                    Dim intCategoryCount As Integer
                    intCategoryCount = usedCategoriesFromLedgerList_WithDuplicates_EntireLedger.Where(Function(value) value = strCategory).Count

                    AddRow(intCategoryCount, strCategory, CalculateTotalPayments_EnitreLedger(strCategory), CalculateTotalDeposits_EntireLedger(strCategory))

                Next

            Else 'CALCULATE FOR SELECTED YEAR

                Dim intSelectedYear As Integer
                intSelectedYear = cbYear.SelectedItem
                intSelectedYear = Integer.Parse(intSelectedYear)

                DetermineUsedCategoriesbyYear(intSelectedYear)

                For Each strCategory As String In usedCategoriesFromLedgerCollection_NoDuplicates_SelectedYear

                    Dim intCategoryCount As Integer
                    intCategoryCount = usedCategoriesFromLedgerList_WithDuplicates_SelectedYear.Where(Function(value) value = strCategory).Count

                    AddRow(intCategoryCount, strCategory, CalculateTotalPayments_SelectedYear(strCategory, intSelectedYear), CalculateTotalDeposits_SelectedYear(strCategory, intSelectedYear))

                Next

            End If

        Else

            If cbYear.Text = "Entire Ledger" Then 'CALCULATE FOR ENTIRE LEDGER

                DetermineUsedPayees_EntireLedger()

                For Each strPayee As String In usedPayeesFromLedgerCollection_NoDuplicates_EntireLedger

                    Dim intPayeeCount As Integer
                    intPayeeCount = usedPayeesFromLedgerList_WithDuplicates_EntireLedger.Where(Function(value) value = strPayee).Count

                    AddRow(intPayeeCount, strPayee, CalculateTotalPayments_EnitreLedger(strPayee), CalculateTotalDeposits_EntireLedger(strPayee))

                Next

            Else 'CALCULATE FOR SELECTED YEAR

                Dim intSelectedYear As Integer
                intSelectedYear = cbYear.SelectedItem
                intSelectedYear = Integer.Parse(intSelectedYear)

                DetermineUsedPayeesbyYear(intSelectedYear)

                For Each strPayee As String In usedPayeesFromLedgerCollection_NoDuplicates_SelectedYear

                    Dim intPayeeCount As Integer
                    intPayeeCount = usedPayeesFromLedgerList_WithDuplicates_SelectedYear.Where(Function(value) value = strPayee).Count

                    AddRow(intPayeeCount, strPayee, CalculateTotalPayments_SelectedYear(strPayee, intSelectedYear), CalculateTotalDeposits_SelectedYear(strPayee, intSelectedYear))

                Next

            End If

        End If

        dgvMostUsed.Sort(dgvMostUsed.Columns("numberOfTransactions"), System.ComponentModel.ListSortDirection.Descending)
        dgvMostUsed.ClearSelection()

        MainModule.DrawingControl.ResumeDrawing(dgvMostUsed)

        UIManager.SetCursor(Me, Cursors.Default)

    End Sub

    Private Sub DetermineYearsInLedger()

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows 'FINDS ALL THE YEARS THAT EXIST IN THE LEDGER AND LOADS THEM INTO THE LIST

            Dim intYear As Integer
            Dim i As Integer = Nothing
            Dim dtDate As Date
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            If Not cbYear.Items.Contains(intYear) Then

                cbYear.Items.Add(intYear)

            End If

        Next

        cbYear.Items.Add("Entire Ledger")

    End Sub

    Private Function CalculateTotalPayments_EnitreLedger(ByVal _item As String) As Double

        Dim dblTotalPayments As Double = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strItem As String
            Dim strPayment As String
            Dim i As Integer = Nothing
            i = dgvRow.Index

            If cbCategoriesPayees.Text = "Categories" Then
                strItem = MainForm.dgvLedger.Item("Category", i).Value
            Else
                strItem = MainForm.dgvLedger.Item("Payee", i).Value
            End If

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value

            If strPayment = "" Then
                strPayment = 0
            Else
                strPayment = CDbl(strPayment)
            End If

            If strItem = _item Then
                dblTotalPayments += strPayment
            End If

        Next

        Return dblTotalPayments
    End Function

    Private Function CalculateTotalPayments_SelectedYear(ByVal _item As String, ByVal _year As Integer) As Double

        Dim dblTotalPayments As Double = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strItem As String
            Dim strPayment As String
            Dim dtDate As Date
            Dim intYear As Integer
            Dim i As Integer = Nothing
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            If cbCategoriesPayees.Text = "Categories" Then
                strItem = MainForm.dgvLedger.Item("Category", i).Value
            Else
                strItem = MainForm.dgvLedger.Item("Payee", i).Value
            End If

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value

            If strPayment = "" Then
                strPayment = 0
            Else
                strPayment = CDbl(strPayment)
            End If

            If strItem = _item And intYear = _year Then
                dblTotalPayments += strPayment
            End If

        Next

        Return dblTotalPayments
    End Function

    Private Function CalculateTotalDeposits_EntireLedger(ByVal _item As String) As Double

        Dim dblTotalDeposits As Double = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strItem As String
            Dim strDeposit As String
            Dim i As Integer = Nothing
            i = dgvRow.Index

            If cbCategoriesPayees.Text = "Categories" Then
                strItem = MainForm.dgvLedger.Item("Category", i).Value
            Else
                strItem = MainForm.dgvLedger.Item("Payee", i).Value
            End If

            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value

            If strDeposit = "" Then
                strDeposit = 0
            Else
                strDeposit = CDbl(strDeposit)
            End If

            If strItem = _item Then
                dblTotalDeposits += strDeposit
            End If

        Next

        Return dblTotalDeposits
    End Function

    Private Function CalculateTotalDeposits_SelectedYear(ByVal _item As String, ByVal _year As Integer) As Double

        Dim dblTotalDeposits As Double = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strItem As String
            Dim strDeposit As String
            Dim dtDate As Date
            Dim intYear As Integer
            Dim i As Integer = Nothing
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            If cbCategoriesPayees.Text = "Categories" Then
                strItem = MainForm.dgvLedger.Item("Category", i).Value
            Else
                strItem = MainForm.dgvLedger.Item("Payee", i).Value
            End If

            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value

            If strDeposit = "" Then
                strDeposit = 0
            Else
                strDeposit = CDbl(strDeposit)
            End If

            If strItem = _item And intYear = _year Then
                dblTotalDeposits += strDeposit
            End If

        Next

        Return dblTotalDeposits
    End Function

    Public Sub DetermineUsedCategories_EntireLedger()

        usedCategoriesFromLedgerList_WithDuplicates_EntireLedger.Clear()
        usedCategoriesFromLedgerCollection_NoDuplicates_EntireLedger.Clear()

        'DETERMINES CATEGORIES USED IN LEDGER
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strCategory As String
            Dim i As Integer
            i = dgvRow.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString

            If Not strCategory = "Uncategorized" Then

                usedCategoriesFromLedgerList_WithDuplicates_EntireLedger.Add(strCategory)

            End If

        Next

        For Each strCategory As String In usedCategoriesFromLedgerList_WithDuplicates_EntireLedger

            usedCategoriesFromLedgerCollection_NoDuplicates_EntireLedger.Add(strCategory)

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedCategoriesFromLedgerCollection_NoDuplicates_EntireLedger)

    End Sub

    Public Sub DetermineUsedCategoriesbyYear(ByVal _year As Integer)

        usedCategoriesFromLedgerList_WithDuplicates_SelectedYear.Clear()
        usedCategoriesFromLedgerCollection_NoDuplicates_SelectedYear.Clear()

        Dim dtDate As Date
        Dim strPayment As String

        'DETERMINES CATEGORIES BASED ON YEAR
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strCategory As String
            Dim i As Integer
            i = dgvRow.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _year And Not strCategory = "Uncategorized" Then

                usedCategoriesFromLedgerList_WithDuplicates_SelectedYear.Add(strCategory)

            End If

        Next

        For Each strCategory As String In usedCategoriesFromLedgerList_WithDuplicates_SelectedYear

            usedCategoriesFromLedgerCollection_NoDuplicates_SelectedYear.Add(strCategory)

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedCategoriesFromLedgerCollection_NoDuplicates_SelectedYear)

    End Sub

    Public Sub DetermineUsedPayees_EntireLedger()

        usedPayeesFromLedgerList_WithDuplicates_EntireLedger.Clear()
        usedPayeesFromLedgerCollection_NoDuplicates_EntireLedger.Clear()

        'DETERMINES PAYEES USED IN LEDGER
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strPayee As String
            Dim i As Integer
            i = dgvRow.Index

            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString

            If Not strPayee = "Unknown" Then

                usedPayeesFromLedgerList_WithDuplicates_EntireLedger.Add(strPayee)

            End If

        Next

        For Each strPayee As String In usedPayeesFromLedgerList_WithDuplicates_EntireLedger

            usedPayeesFromLedgerCollection_NoDuplicates_EntireLedger.Add(strPayee)

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedPayeesFromLedgerCollection_NoDuplicates_EntireLedger)

    End Sub

    Public Sub DetermineUsedPayeesbyYear(ByVal _year As Integer)

        usedPayeesFromLedgerList_WithDuplicates_SelectedYear.Clear()
        usedPayeesFromLedgerCollection_NoDuplicates_SelectedYear.Clear()

        Dim dtDate As Date
        Dim strPayment As String

        'DETERMINES PAYEES BASED ON YEAR
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strPayee As String
            Dim i As Integer
            i = dgvRow.Index

            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _year And Not strPayee = "Unknown" Then

                usedPayeesFromLedgerList_WithDuplicates_SelectedYear.Add(strPayee)

            End If

        Next

        For Each strPayee As String In usedPayeesFromLedgerList_WithDuplicates_SelectedYear

            usedPayeesFromLedgerCollection_NoDuplicates_SelectedYear.Add(strPayee)

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedPayeesFromLedgerCollection_NoDuplicates_SelectedYear)

    End Sub

End Class