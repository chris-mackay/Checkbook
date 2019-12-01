'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2019 Christopher Mackay

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

    Private FileCon As New clsLedgerDBConnector
    Private lstGroupTextboxes As New List(Of TextBox)

    Private Sub frmMonthly_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtDate As Date = Nothing
        Dim intYear As Integer = 0
        Dim lstYearsInLedger As New List(Of Integer)
        Dim strPayment As String = String.Empty

        dgvMonthly.Rows.Clear()
        m_colMonths.Clear()
        m_colUsedMonths.Clear()

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer = 0
            Dim intMonth As Integer = 0
            i = row.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value
            intMonth = dtDate.Month

            If Not lstYearsInLedger.Contains(intYear) Then

                lstYearsInLedger.Add(intYear)

            End If

            If Not cbYear.Items.Contains(intYear) Then

                cbYear.Items.Add(intYear)

            End If

            If Not m_colUsedMonths.Contains(ConvertMonthFromIntegerToString(intMonth)) And Not strPayment = "" Then

                m_colUsedMonths.Add(ConvertMonthFromIntegerToString(intMonth))

            End If

        Next

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

        cbYear.SelectedIndex = cbYear.FindStringExact(lstYearsInLedger.Max.ToString) 'SELECTS THE MOST RECENT YEAR FROM YEAR LIST

        dgvMonthly.ClearSelection()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged

        CalculateMonthlyIncome()

        Dim dblSelectedYearStatus As Double = 0
        dblSelectedYearStatus = GetTotalDepositsFromMonthlyGrid(Me.dgvMonthly) - GetTotalPaymentsFromMonthlyGrid(Me.dgvMonthly)
        txtLedgerStatus.Text = FormatCurrency(dblSelectedYearStatus)

        lstGroupTextboxes.Add(txtLedgerStatus)

        ColorTextboxes(lstGroupTextboxes)

    End Sub

    Sub CalculateMonthlyIncome()

        dgvMonthly.Rows.Clear()
        dgvMonthly.Columns.Clear()

        CreateMonthlyGridColumns(dgvMonthly)

        Dim intSelectedYear As Integer = 0
        intSelectedYear = cbYear.SelectedItem

        For Each strMonth As String In m_colMonths

            dgvMonthly.Rows.Add(strMonth, SumPaymentsMonthly_FromMainFromLedger(strMonth, intSelectedYear), SumDepositsMonthly_FromMainFormLedger(strMonth, intSelectedYear))

        Next

        CalculateMonthlyIncome_And_AverageIncome_And_Balance(dgvMonthly, intSelectedYear)

        dgvMonthly.ClearSelection()

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/monthly_income.html"
        Process.Start(strWebAddress)

    End Sub

End Class