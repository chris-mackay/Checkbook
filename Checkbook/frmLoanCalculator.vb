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

Public Class frmLoanCalculator

    Private dblCompoundingPeriods As Double = 0.0
    Private UIManager As New clsUIManager

    Private Sub CalculateMonthlyPayment()

        Dim dblTotalAccruedAmount As Double = 0
        Dim dblTermYears As Double = 0
        Dim dblMonths As Double = 0
        Dim dblMonthlyPayment As Double = 0

        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblTermYears = txtTermYears.Text
        dblMonths = dblTermYears * 12

        dblMonthlyPayment = dblTotalAccruedAmount / dblMonths

        txtMonthlyPayment.Text = FormatCurrency(Math.Round(dblMonthlyPayment, 2))

    End Sub

#Region "SimpleInterestFunctions"

    Private Sub CalculateInterestRate_Simple() '(1 / t) * ((A / P) - 1)

        Dim dblTotalAccruedAmount As Double = 0
        Dim dblPrincipleAmount As Double = 0
        Dim dblTermYears As Double = 0

        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblPrincipleAmount = txtLoanAmount.Text
        dblTermYears = txtTermYears.Text

        Dim dblInterestRate As Double = 0 'VALUE TO CALCULATE

        dblInterestRate = ((1 / dblTermYears) * ((dblTotalAccruedAmount / dblPrincipleAmount) - 1)) * 100

        txtInterestRate.Text = Math.Round(dblInterestRate, 2)

    End Sub

    Private Sub CalculateTerms_Simple() '(1 / r) * ((A / P) - 1)

        Dim dblInterestRate As Double = 0
        Dim dblTotalAccruedAmount As Double = 0
        Dim dblPrincipleAmount As Double = 0

        dblInterestRate = txtInterestRate.Text / 100
        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblPrincipleAmount = txtLoanAmount.Text

        Dim dblTermYears As Double = 0 'VALUE TO CALCULATE

        dblTermYears = (1 / dblInterestRate) * ((dblTotalAccruedAmount / dblPrincipleAmount) - 1)

        txtTermYears.Text = Math.Round(dblTermYears, 2)

    End Sub

    Private Sub CalculatePrincipleAmount_Simple() 'P = A / (1 + (rt))

        Dim dblInterestRate As Double = 0
        Dim dblTermYears As Double = 0
        Dim dblTotalAccruedAmount As Double = 0

        dblInterestRate = txtInterestRate.Text / 100
        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblTermYears = txtTermYears.Text

        Dim dblPrincipleAmount As Double = 0 'VALUE TO CALCULATE

        dblPrincipleAmount = dblTotalAccruedAmount / (1 + (dblInterestRate * dblTermYears))

        txtLoanAmount.Text = FormatCurrency(Math.Round(dblPrincipleAmount, 2))

    End Sub

    Private Sub CalculateTotalAccruedAmount_Simple() 'A = P(1 + (rt))

        Dim dblPrincipleAmount As Double = 0
        Dim dblInterestRate As Double = 0
        Dim dblTermYears As Double = 0

        dblInterestRate = txtInterestRate.Text / 100
        dblPrincipleAmount = txtLoanAmount.Text
        dblTermYears = txtTermYears.Text

        Dim dblTotalAccruedAmount As Double = 0 'VALUE TO CALCULATE

        dblTotalAccruedAmount = dblPrincipleAmount * (1 + (dblInterestRate * dblTermYears))

        txtTotalAccruedAmount.Text = FormatCurrency(Math.Round(dblTotalAccruedAmount, 2))

    End Sub

#End Region

#Region "CompoundInterestFunctions"

    Private Sub CalculateInterestRate_Compound() '((A / P)^(1/n)) - 1

        Dim dblTotalAccruedAmount As Double = 0
        Dim dblPrincipleAmount As Double = 0
        Dim dblTermYears As Double = 0

        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblPrincipleAmount = txtLoanAmount.Text
        dblTermYears = txtTermYears.Text

        Dim dblInterestRate As Double = 0 'VALUE TO CALCULATE

        dblInterestRate = ((((dblTotalAccruedAmount / dblPrincipleAmount) ^ (1 / (dblTermYears * dblCompoundingPeriods))) - 1)) * dblCompoundingPeriods * 100

        txtInterestRate.Text = Math.Round(dblInterestRate, 2)

    End Sub

    Private Sub CalculateTerms_Compound() 'ln(A / P) / ln(1 + r)

        Dim dblInterestRate As Double = 0
        Dim dblTotalAccruedAmount As Double = 0
        Dim dblPrincipleAmount As Double = 0

        dblInterestRate = (txtInterestRate.Text / 100) / dblCompoundingPeriods
        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblPrincipleAmount = txtLoanAmount.Text

        Dim dblTermYears As Double = 0 'VALUE TO CALCULATE

        dblTermYears = (Math.Log(dblTotalAccruedAmount / dblPrincipleAmount) / Math.Log(1 + dblInterestRate)) / dblCompoundingPeriods
        dblTermYears = Math.Round(dblTermYears, 2)

        txtTermYears.Text = dblTermYears

    End Sub

    Private Sub CalculatePrincipleAmount_Compound() 'P = A / (1 + r)^n 

        Dim dblInterestRate As Double = 0
        Dim dblTermYears As Double = 0
        Dim dblTotalAccruedAmount As Double = 0

        dblInterestRate = (txtInterestRate.Text / 100) / dblCompoundingPeriods
        dblTotalAccruedAmount = txtTotalAccruedAmount.Text
        dblTermYears = txtTermYears.Text

        Dim dblPrincipleAmount As Double = 0 'VALUE TO CALCULATE

        dblPrincipleAmount = dblTotalAccruedAmount / ((1 + dblInterestRate) ^ (dblTermYears * dblCompoundingPeriods))

        txtLoanAmount.Text = FormatCurrency(Math.Round(dblPrincipleAmount, 2))

    End Sub

    Private Sub CalculateTotalAccruedAmount_Compound() 'A = P(1 + r)^n

        Dim dblPrincipleAmount As Double = 0
        Dim dblInterestRate As Double = 0
        Dim dblTermYears As Double = 0

        dblInterestRate = (txtInterestRate.Text / 100) / dblCompoundingPeriods
        dblPrincipleAmount = txtLoanAmount.Text
        dblTermYears = txtTermYears.Text

        Dim dblTotalAccruedAmount As Double = 0 'VALUE TO CALCULATE

        dblTotalAccruedAmount = dblPrincipleAmount * ((1 + dblInterestRate) ^ (dblTermYears * dblCompoundingPeriods))

        txtTotalAccruedAmount.Text = FormatCurrency(Math.Round(dblTotalAccruedAmount, 2))

    End Sub

#End Region

    Private Sub txtLoanAmount_TextChanged(sender As Object, e As EventArgs) Handles txtLoanAmount.TextChanged

        PerformCalculations()

    End Sub

    Private Sub txtInterestRate_TextChanged(sender As Object, e As EventArgs) Handles txtInterestRate.TextChanged

        PerformCalculations()

    End Sub

    Private Sub txtTermYears_TextChanged(sender As Object, e As EventArgs) Handles txtTermYears.TextChanged

        PerformCalculations()

    End Sub

    Private Sub txtMonthlyPayment_TextChanged(sender As Object, e As EventArgs) Handles txtMonthlyPayment.TextChanged

        PerformCalculations()

    End Sub

    Private Sub txtTotalAccruedAmount_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAccruedAmount.TextChanged

        PerformCalculations()

    End Sub

    Private Sub PerformCalculations()

        If rbCalcLoanAmount.Checked Then

            If Not txtInterestRate.Text = String.Empty And Not txtTermYears.Text = String.Empty And Not txtTotalAccruedAmount.Text = String.Empty Then

                If rbSimple.Checked Then

                    CalculatePrincipleAmount_Simple()

                Else

                    CalculatePrincipleAmount_Compound()

                End If

                CalculateMonthlyPayment()

            Else

                txtLoanAmount.Text = String.Empty
                txtMonthlyPayment.Text = String.Empty

            End If

        End If

        If rbCalcInterestRate.Checked Then

            If Not txtLoanAmount.Text = String.Empty And Not txtTermYears.Text = String.Empty And Not txtTotalAccruedAmount.Text = String.Empty Then

                If rbSimple.Checked Then

                    CalculateInterestRate_Simple()

                Else

                    CalculateInterestRate_Compound()

                End If

                CalculateMonthlyPayment()

            Else

                txtInterestRate.Text = String.Empty
                txtMonthlyPayment.Text = String.Empty

            End If

        End If

        If rbCalculateTerm.Checked Then

            If Not txtLoanAmount.Text = String.Empty And Not txtInterestRate.Text = String.Empty And Not txtTotalAccruedAmount.Text = String.Empty Then

                If rbSimple.Checked Then

                    CalculateTerms_Simple()

                Else

                    CalculateTerms_Compound()

                End If

                CalculateMonthlyPayment()

            Else

                txtTermYears.Text = String.Empty
                txtMonthlyPayment.Text = String.Empty

            End If

        End If

        If rbCalcTotalAccruedAmount.Checked Then

            If Not txtLoanAmount.Text = String.Empty And Not txtInterestRate.Text = String.Empty And Not txtTermYears.Text = String.Empty Then

                If rbSimple.Checked Then

                    CalculateTotalAccruedAmount_Simple()

                Else

                    CalculateTotalAccruedAmount_Compound()

                End If

                CalculateMonthlyPayment()

            Else

                txtTotalAccruedAmount.Text = String.Empty
                txtMonthlyPayment.Text = String.Empty

            End If

        End If

    End Sub

    Private Sub rbCalcLoanAmount_CheckedChanged(sender As Object, e As EventArgs) Handles rbCalcLoanAmount.CheckedChanged

        SetEnabled(txtLoanAmount)

    End Sub

    Private Sub rbCalcInterestRate_CheckedChanged(sender As Object, e As EventArgs) Handles rbCalcInterestRate.CheckedChanged

        SetEnabled(txtInterestRate)

    End Sub

    Private Sub rbCalculateTerm_CheckedChanged(sender As Object, e As EventArgs) Handles rbCalculateTerm.CheckedChanged

        SetEnabled(txtTermYears)

    End Sub

    Private Sub rbCalcMonthlyPayment_CheckedChanged(sender As Object, e As EventArgs)

        SetEnabled(txtMonthlyPayment)
        txtTotalAccruedAmount.Enabled = False
        txtTotalAccruedAmount.Text = String.Empty

    End Sub

    Private Sub rbCalcTotalAccruedAmount_CheckedChanged(sender As Object, e As EventArgs) Handles rbCalcTotalAccruedAmount.CheckedChanged

        SetEnabled(txtTotalAccruedAmount)
        txtMonthlyPayment.Enabled = False
        txtMonthlyPayment.Text = String.Empty

    End Sub

    Private Sub SetEnabled(_textBox As TextBox)

        For Each ctrl As Control In Me.Controls

            If TypeOf ctrl Is TextBox Then

                If ctrl.Name = _textBox.Name Then

                    ctrl.Enabled = False
                    ctrl.Text = String.Empty
                    txtMonthlyPayment.Enabled = False
                    txtMonthlyPayment.Text = String.Empty

                Else

                    ctrl.Enabled = True
                    ctrl.Text = String.Empty
                    txtMonthlyPayment.Enabled = False
                    txtMonthlyPayment.Text = String.Empty

                End If

            End If

        Next

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        For Each ctrl As Control In Me.Controls

            If TypeOf ctrl Is TextBox Then

                ctrl.Text = String.Empty

            End If

        Next

    End Sub

    Private Sub frmLoanCalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbCalcTotalAccruedAmount.Checked = True
        rbSimple.Checked = True
        cbCompoundingPeriods.SelectedIndex = 0

    End Sub

    Private Sub rbSimple_CheckedChanged(sender As Object, e As EventArgs) Handles rbSimple.CheckedChanged

        cbCompoundingPeriods.Enabled = False
        lblCompoundingPeriods.Enabled = False
        PerformCalculations()

    End Sub

    Private Sub rbCompound_CheckedChanged(sender As Object, e As EventArgs) Handles rbCompound.CheckedChanged

        cbCompoundingPeriods.Enabled = True
        lblCompoundingPeriods.Enabled = True
        PerformCalculations()

    End Sub

    Private Sub cbCompoundingPeriods_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCompoundingPeriods.SelectedIndexChanged

        Dim strSelectedCompoundingPeriod As String = String.Empty
        strSelectedCompoundingPeriod = cbCompoundingPeriods.SelectedItem

        Select Case strSelectedCompoundingPeriod
            Case "Daily"

                dblCompoundingPeriods = 365

            Case "Monthly"

                dblCompoundingPeriods = 12

            Case Else

                dblCompoundingPeriods = 1

        End Select

        PerformCalculations()

    End Sub

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtLoanAmount.Validated, txtTotalAccruedAmount.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInterestRate.KeyPress, txtLoanAmount.KeyPress, txtTermYears.KeyPress, txtTotalAccruedAmount.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/loan_calculator.html"
        Process.Start(strWebAddress)

    End Sub

End Class