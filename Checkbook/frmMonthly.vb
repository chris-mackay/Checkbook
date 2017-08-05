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

Public Class frmMonthly

    'NEW INSTANCES OF CLASSES
    Private FileCon As New clsLedgerDBConnector

    Private groupTextboxesList As New List(Of TextBox)

    Private Sub frmMonthly_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtDate As Date
        Dim intYear As Integer
        Dim yearList As New List(Of Integer)
        Dim strPayment As String

        dgvMonthly.Rows.Clear()
        m_MonthCollection.Clear()
        m_myMonthsCollection.Clear()

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            Dim intMonth As Integer
            i = row.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value
            intMonth = dtDate.Month

            If Not yearList.Contains(intYear) Then

                yearList.Add(intYear)

            End If

            If Not cbYear.Items.Contains(intYear) Then

                cbYear.Items.Add(intYear)

            End If

            If Not m_myMonthsCollection.Contains(ConvertMonthFromIntegerToString(intMonth)) And Not strPayment = "" Then

                m_myMonthsCollection.Add(ConvertMonthFromIntegerToString(intMonth))

            End If

        Next

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

        cbYear.SelectedIndex = cbYear.FindStringExact(yearList.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

        dgvMonthly.ClearSelection()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged

        CalculateMonthlyIncome()

        Dim selectedYearStatus As Double
        selectedYearStatus = GetTotalDepositsFromMonthlyGrid(Me.dgvMonthly) - GetTotalPaymentsFromMonthlyGrid(Me.dgvMonthly)
        txtLedgerStatus.Text = FormatCurrency(selectedYearStatus)

        groupTextboxesList.Add(txtLedgerStatus)

        ColorTextboxes(groupTextboxesList)

    End Sub

    Sub CalculateMonthlyIncome()

        dgvMonthly.Rows.Clear()
        dgvMonthly.Columns.Clear()

        CreateMonthlyGridColumns(dgvMonthly)

        Dim SelectedYear As Integer
        SelectedYear = cbYear.SelectedItem

        For Each _Month As String In m_MonthCollection

            dgvMonthly.Rows.Add(_Month, SumPaymentsMonthly_FromMainFromLedger(_Month, SelectedYear), SumDepositsMonthly_FromMainFormLedger(_Month, SelectedYear))

        Next

        CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, SelectedYear)

        dgvMonthly.ClearSelection()

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim webAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/monthly_income.html"
        Process.Start(webAddress)

    End Sub

End Class