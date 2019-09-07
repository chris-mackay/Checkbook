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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoanCalculator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoanCalculator))
        Me.txtLoanAmount = New System.Windows.Forms.TextBox()
        Me.lblLoanAmount = New System.Windows.Forms.Label()
        Me.lblInterestRate = New System.Windows.Forms.Label()
        Me.txtInterestRate = New System.Windows.Forms.TextBox()
        Me.lblTermYears = New System.Windows.Forms.Label()
        Me.txtTermYears = New System.Windows.Forms.TextBox()
        Me.lblMonthlyPayment = New System.Windows.Forms.Label()
        Me.txtMonthlyPayment = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblTotalAccruedAmount = New System.Windows.Forms.Label()
        Me.txtTotalAccruedAmount = New System.Windows.Forms.TextBox()
        Me.rbCalcLoanAmount = New System.Windows.Forms.RadioButton()
        Me.rbCalcInterestRate = New System.Windows.Forms.RadioButton()
        Me.rbCalculateTerm = New System.Windows.Forms.RadioButton()
        Me.rbCalcTotalAccruedAmount = New System.Windows.Forms.RadioButton()
        Me.rbCompound = New System.Windows.Forms.RadioButton()
        Me.rbSimple = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCompoundingPeriods = New System.Windows.Forms.Label()
        Me.cbCompoundingPeriods = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.SuspendLayout
        '
        'txtLoanAmount
        '
        Me.txtLoanAmount.Location = New System.Drawing.Point(356, 46)
        Me.txtLoanAmount.Name = "txtLoanAmount"
        Me.txtLoanAmount.ShortcutsEnabled = false
        Me.txtLoanAmount.Size = New System.Drawing.Size(161, 20)
        Me.txtLoanAmount.TabIndex = 1
        '
        'lblLoanAmount
        '
        Me.lblLoanAmount.AutoSize = true
        Me.lblLoanAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.lblLoanAmount.Location = New System.Drawing.Point(356, 30)
        Me.lblLoanAmount.Name = "lblLoanAmount"
        Me.lblLoanAmount.Size = New System.Drawing.Size(86, 13)
        Me.lblLoanAmount.TabIndex = 0
        Me.lblLoanAmount.Text = "Principle Amount"
        '
        'lblInterestRate
        '
        Me.lblInterestRate.AutoSize = true
        Me.lblInterestRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.lblInterestRate.Location = New System.Drawing.Point(356, 69)
        Me.lblInterestRate.Name = "lblInterestRate"
        Me.lblInterestRate.Size = New System.Drawing.Size(118, 13)
        Me.lblInterestRate.TabIndex = 2
        Me.lblInterestRate.Text = "Interest Rate (% / Year)"
        '
        'txtInterestRate
        '
        Me.txtInterestRate.Location = New System.Drawing.Point(356, 85)
        Me.txtInterestRate.Name = "txtInterestRate"
        Me.txtInterestRate.ShortcutsEnabled = false
        Me.txtInterestRate.Size = New System.Drawing.Size(161, 20)
        Me.txtInterestRate.TabIndex = 3
        '
        'lblTermYears
        '
        Me.lblTermYears.AutoSize = true
        Me.lblTermYears.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.lblTermYears.Location = New System.Drawing.Point(356, 108)
        Me.lblTermYears.Name = "lblTermYears"
        Me.lblTermYears.Size = New System.Drawing.Size(67, 13)
        Me.lblTermYears.TabIndex = 4
        Me.lblTermYears.Text = "Term (Years)"
        '
        'txtTermYears
        '
        Me.txtTermYears.Location = New System.Drawing.Point(356, 124)
        Me.txtTermYears.Name = "txtTermYears"
        Me.txtTermYears.ShortcutsEnabled = false
        Me.txtTermYears.Size = New System.Drawing.Size(161, 20)
        Me.txtTermYears.TabIndex = 5
        '
        'lblMonthlyPayment
        '
        Me.lblMonthlyPayment.AutoSize = true
        Me.lblMonthlyPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.lblMonthlyPayment.Location = New System.Drawing.Point(356, 147)
        Me.lblMonthlyPayment.Name = "lblMonthlyPayment"
        Me.lblMonthlyPayment.Size = New System.Drawing.Size(88, 13)
        Me.lblMonthlyPayment.TabIndex = 6
        Me.lblMonthlyPayment.Text = "Monthly Payment"
        '
        'txtMonthlyPayment
        '
        Me.txtMonthlyPayment.Location = New System.Drawing.Point(356, 163)
        Me.txtMonthlyPayment.Name = "txtMonthlyPayment"
        Me.txtMonthlyPayment.ShortcutsEnabled = false
        Me.txtMonthlyPayment.Size = New System.Drawing.Size(161, 20)
        Me.txtMonthlyPayment.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(450, 300)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(369, 300)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = true
        '
        'lblTotalAccruedAmount
        '
        Me.lblTotalAccruedAmount.AutoSize = true
        Me.lblTotalAccruedAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.lblTotalAccruedAmount.Location = New System.Drawing.Point(356, 186)
        Me.lblTotalAccruedAmount.Name = "lblTotalAccruedAmount"
        Me.lblTotalAccruedAmount.Size = New System.Drawing.Size(114, 13)
        Me.lblTotalAccruedAmount.TabIndex = 8
        Me.lblTotalAccruedAmount.Text = "Total Payment Amount"
        '
        'txtTotalAccruedAmount
        '
        Me.txtTotalAccruedAmount.Location = New System.Drawing.Point(356, 202)
        Me.txtTotalAccruedAmount.Name = "txtTotalAccruedAmount"
        Me.txtTotalAccruedAmount.ShortcutsEnabled = false
        Me.txtTotalAccruedAmount.Size = New System.Drawing.Size(161, 20)
        Me.txtTotalAccruedAmount.TabIndex = 9
        '
        'rbCalcLoanAmount
        '
        Me.rbCalcLoanAmount.AutoSize = true
        Me.rbCalcLoanAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.rbCalcLoanAmount.Location = New System.Drawing.Point(25, 31)
        Me.rbCalcLoanAmount.Name = "rbCalcLoanAmount"
        Me.rbCalcLoanAmount.Size = New System.Drawing.Size(151, 17)
        Me.rbCalcLoanAmount.TabIndex = 0
        Me.rbCalcLoanAmount.TabStop = true
        Me.rbCalcLoanAmount.Text = "Calculate Principle Amount"
        Me.rbCalcLoanAmount.UseVisualStyleBackColor = true
        '
        'rbCalcInterestRate
        '
        Me.rbCalcInterestRate.AutoSize = true
        Me.rbCalcInterestRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.rbCalcInterestRate.Location = New System.Drawing.Point(25, 54)
        Me.rbCalcInterestRate.Name = "rbCalcInterestRate"
        Me.rbCalcInterestRate.Size = New System.Drawing.Size(183, 17)
        Me.rbCalcInterestRate.TabIndex = 1
        Me.rbCalcInterestRate.TabStop = true
        Me.rbCalcInterestRate.Text = "Calculate Interest Rate (% / Year)"
        Me.rbCalcInterestRate.UseVisualStyleBackColor = true
        '
        'rbCalculateTerm
        '
        Me.rbCalculateTerm.AutoSize = true
        Me.rbCalculateTerm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.rbCalculateTerm.Location = New System.Drawing.Point(25, 77)
        Me.rbCalculateTerm.Name = "rbCalculateTerm"
        Me.rbCalculateTerm.Size = New System.Drawing.Size(132, 17)
        Me.rbCalculateTerm.TabIndex = 2
        Me.rbCalculateTerm.TabStop = true
        Me.rbCalculateTerm.Text = "Calculate Term (Years)"
        Me.rbCalculateTerm.UseVisualStyleBackColor = true
        '
        'rbCalcTotalAccruedAmount
        '
        Me.rbCalcTotalAccruedAmount.AutoSize = true
        Me.rbCalcTotalAccruedAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.rbCalcTotalAccruedAmount.Location = New System.Drawing.Point(25, 100)
        Me.rbCalcTotalAccruedAmount.Name = "rbCalcTotalAccruedAmount"
        Me.rbCalcTotalAccruedAmount.Size = New System.Drawing.Size(179, 17)
        Me.rbCalcTotalAccruedAmount.TabIndex = 3
        Me.rbCalcTotalAccruedAmount.TabStop = true
        Me.rbCalcTotalAccruedAmount.Text = "Calculate Total Payment Amount"
        Me.rbCalcTotalAccruedAmount.UseVisualStyleBackColor = true
        '
        'rbCompound
        '
        Me.rbCompound.AutoSize = true
        Me.rbCompound.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.rbCompound.Location = New System.Drawing.Point(25, 56)
        Me.rbCompound.Name = "rbCompound"
        Me.rbCompound.Size = New System.Drawing.Size(114, 17)
        Me.rbCompound.TabIndex = 1
        Me.rbCompound.TabStop = true
        Me.rbCompound.Text = "Compound Interest"
        Me.rbCompound.UseVisualStyleBackColor = true
        '
        'rbSimple
        '
        Me.rbSimple.AutoSize = true
        Me.rbSimple.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.rbSimple.Location = New System.Drawing.Point(25, 33)
        Me.rbSimple.Name = "rbSimple"
        Me.rbSimple.Size = New System.Drawing.Size(94, 17)
        Me.rbSimple.TabIndex = 0
        Me.rbSimple.TabStop = true
        Me.rbSimple.Text = "Simple Interest"
        Me.rbSimple.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCalcLoanAmount)
        Me.GroupBox1.Controls.Add(Me.rbCalcInterestRate)
        Me.GroupBox1.Controls.Add(Me.rbCalculateTerm)
        Me.GroupBox1.Controls.Add(Me.rbCalcTotalAccruedAmount)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(26, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 140)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Select value to calculate"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCompoundingPeriods)
        Me.GroupBox2.Controls.Add(Me.cbCompoundingPeriods)
        Me.GroupBox2.Controls.Add(Me.rbSimple)
        Me.GroupBox2.Controls.Add(Me.rbCompound)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(26, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 121)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Select type of interest to calculate"
        '
        'lblCompoundingPeriods
        '
        Me.lblCompoundingPeriods.AutoSize = true
        Me.lblCompoundingPeriods.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21,Byte),Integer), CType(CType(66,Byte),Integer), CType(CType(139,Byte),Integer))
        Me.lblCompoundingPeriods.Location = New System.Drawing.Point(182, 87)
        Me.lblCompoundingPeriods.Name = "lblCompoundingPeriods"
        Me.lblCompoundingPeriods.Size = New System.Drawing.Size(110, 13)
        Me.lblCompoundingPeriods.TabIndex = 3
        Me.lblCompoundingPeriods.Text = "Compounding Periods"
        '
        'cbCompoundingPeriods
        '
        Me.cbCompoundingPeriods.FormattingEnabled = true
        Me.cbCompoundingPeriods.Items.AddRange(New Object() {"Daily", "Monthly", "Yearly"})
        Me.cbCompoundingPeriods.Location = New System.Drawing.Point(25, 79)
        Me.cbCompoundingPeriods.Name = "cbCompoundingPeriods"
        Me.cbCompoundingPeriods.Size = New System.Drawing.Size(151, 21)
        Me.cbCompoundingPeriods.TabIndex = 2
        '
        'frmLoanCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234,Byte),Integer), CType(CType(242,Byte),Integer), CType(CType(251,Byte),Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(537, 335)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTotalAccruedAmount)
        Me.Controls.Add(Me.txtTotalAccruedAmount)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblMonthlyPayment)
        Me.Controls.Add(Me.txtMonthlyPayment)
        Me.Controls.Add(Me.lblTermYears)
        Me.Controls.Add(Me.txtTermYears)
        Me.Controls.Add(Me.lblInterestRate)
        Me.Controls.Add(Me.txtInterestRate)
        Me.Controls.Add(Me.lblLoanAmount)
        Me.Controls.Add(Me.txtLoanAmount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = true
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmLoanCalculator"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Calculator"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtLoanAmount As TextBox
    Friend WithEvents lblLoanAmount As Label
    Friend WithEvents lblInterestRate As Label
    Friend WithEvents txtInterestRate As TextBox
    Friend WithEvents lblTermYears As Label
    Friend WithEvents txtTermYears As TextBox
    Friend WithEvents lblMonthlyPayment As Label
    Friend WithEvents txtMonthlyPayment As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblTotalAccruedAmount As Label
    Friend WithEvents txtTotalAccruedAmount As TextBox
    Friend WithEvents rbCalcLoanAmount As RadioButton
    Friend WithEvents rbCalcInterestRate As RadioButton
    Friend WithEvents rbCalculateTerm As RadioButton
    Friend WithEvents rbCalcTotalAccruedAmount As RadioButton
    Friend WithEvents rbCompound As RadioButton
    Friend WithEvents rbSimple As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblCompoundingPeriods As Label
    Friend WithEvents cbCompoundingPeriods As ComboBox
End Class
