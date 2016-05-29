Public Class frmMostUsedCategoriesPayees

    Private yearList As New List(Of Integer)

    Private Sub frmMostUsedCategoriesPayees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddColumns()
        DetermineYearsInLedger()
        cbCategoriesPayees.Text = "Categories"
        cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST. THIS

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

            If Not cbYear.Items.Contains(intYear) Then

                cbYear.Items.Add(intYear) 'IF THE YEAR DOESNT ALREADY EXIST WITHIN THE LIST THEN IT WILL BE ADDED

            End If

        Next

    End Sub

End Class