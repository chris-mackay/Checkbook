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

    Private yearList As New List(Of Integer)
    Private usedPayeesFromLedgerCollection_NoDuplicates As New Collection
    Private usedCategoriesFromLedgerCollection_NoDuplicates As New Collection
    Private usedPayeesFromLedgerList_WithDuplicates As New List(Of String)
    Private usedCategoriesFromLedgerList_WithDuplicates As New List(Of String)

    Private Sub frmMostUsedCategoriesPayees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UIManager.SetCursor(Me, Cursors.WaitCursor)

        MainModule.DrawingControl.SetDoubleBuffered(dgvMostUsed)
        MainModule.DrawingControl.SuspendDrawing(dgvMostUsed)

        AddColumns()

        DetermineYearsInLedger()
        DetermineUsedCategoriesFromLedger()
        DetermineUsedPayeesFromLedger()

        cbCategoriesPayees.Text = "Categories" 'TRIGGERS CALCULATIONS

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

    Private Sub cbCategoriesPayees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoriesPayees.SelectedIndexChanged

        UIManager.SetCursor(Me, Cursors.WaitCursor)

        MainModule.DrawingControl.SetDoubleBuffered(dgvMostUsed)
        MainModule.DrawingControl.SuspendDrawing(dgvMostUsed)

        dgvMostUsed.Rows.Clear()

        If cbCategoriesPayees.Text = "Categories" Then

            For Each strCategory As String In usedCategoriesFromLedgerCollection_NoDuplicates

                Dim intCategoryCount As Integer
                intCategoryCount = usedCategoriesFromLedgerList_WithDuplicates.Where(Function(value) value = strCategory).Count

                AddRow(intCategoryCount, strCategory, CalculateTotalPayments(strCategory), CalculateTotalDeposits(strCategory))

            Next

        Else

            For Each strPayee As String In usedPayeesFromLedgerCollection_NoDuplicates

                Dim intPayeeCount As Integer
                intPayeeCount = usedPayeesFromLedgerList_WithDuplicates.Where(Function(value) value = strPayee).Count

                AddRow(intPayeeCount, strPayee, CalculateTotalPayments(strPayee), CalculateTotalDeposits(strPayee))

            Next

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

            If Not yearList.Contains(intYear) Then

                yearList.Add(intYear)

            End If

        Next

    End Sub

    Private Function CalculateTotalPayments(ByVal _item As String) As Double

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

    Private Function CalculateTotalDeposits(ByVal _item As String) As Double

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

    Public Sub DetermineUsedCategoriesFromLedger()

        usedCategoriesFromLedgerList_WithDuplicates.Clear()

        'DETERMINES CATEGORIES USED IN LEDGER
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strCategory As String
            Dim i As Integer
            i = dgvRow.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString

            If Not strCategory = "Uncategorized" Then

                usedCategoriesFromLedgerList_WithDuplicates.Add(strCategory)

            End If

        Next

        For Each strCategory As String In usedCategoriesFromLedgerList_WithDuplicates

            usedCategoriesFromLedgerCollection_NoDuplicates.Add(strCategory)

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedCategoriesFromLedgerCollection_NoDuplicates)

    End Sub

    Public Sub DetermineUsedPayeesFromLedger()

        usedPayeesFromLedgerList_WithDuplicates.Clear()

        'DETERMINES PAYEES USED IN LEDGER
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim strPayee As String
            Dim i As Integer
            i = dgvRow.Index

            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString

            If Not strPayee = "Unknown" Then

                usedPayeesFromLedgerList_WithDuplicates.Add(strPayee)

            End If

        Next

        For Each strPayee As String In usedPayeesFromLedgerList_WithDuplicates

            usedPayeesFromLedgerCollection_NoDuplicates.Add(strPayee)

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(usedPayeesFromLedgerCollection_NoDuplicates)

    End Sub

End Class