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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFilter))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.gbDates = New System.Windows.Forms.GroupBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.rbExactDate = New System.Windows.Forms.RadioButton()
        Me.rbRange = New System.Windows.Forms.RadioButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.gbCategoriesPayess = New System.Windows.Forms.GroupBox()
        Me.rbBoth = New System.Windows.Forms.RadioButton()
        Me.lblPayee = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.rbCategories = New System.Windows.Forms.RadioButton()
        Me.rbPayees = New System.Windows.Forms.RadioButton()
        Me.cbPayees = New System.Windows.Forms.ComboBox()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.ckbCategoriesPayees = New System.Windows.Forms.CheckBox()
        Me.ckbDates = New System.Windows.Forms.CheckBox()
        Me.gbCleared = New System.Windows.Forms.GroupBox()
        Me.rbUncleared = New System.Windows.Forms.RadioButton()
        Me.rbCleared = New System.Windows.Forms.RadioButton()
        Me.rbNoReceipt = New System.Windows.Forms.RadioButton()
        Me.rbReceipt = New System.Windows.Forms.RadioButton()
        Me.gbReceipts = New System.Windows.Forms.GroupBox()
        Me.ckbReceipts = New System.Windows.Forms.CheckBox()
        Me.ckbClearedAndUncleared = New System.Windows.Forms.CheckBox()
        Me.gbFilterOptions = New System.Windows.Forms.GroupBox()
        Me.ckbStatement = New System.Windows.Forms.CheckBox()
        Me.gbStatements = New System.Windows.Forms.GroupBox()
        Me.lblStatementName = New System.Windows.Forms.Label()
        Me.cbStatements = New System.Windows.Forms.ComboBox()
        Me.gbDates.SuspendLayout()
        Me.gbCategoriesPayess.SuspendLayout()
        Me.gbCleared.SuspendLayout()
        Me.gbReceipts.SuspendLayout()
        Me.gbFilterOptions.SuspendLayout()
        Me.gbStatements.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(271, 559)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(189, 559)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(109, 559)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Location = New System.Drawing.Point(27, 559)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 3
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'gbDates
        '
        Me.gbDates.Controls.Add(Me.lblEndDate)
        Me.gbDates.Controls.Add(Me.lblStartDate)
        Me.gbDates.Controls.Add(Me.rbExactDate)
        Me.gbDates.Controls.Add(Me.rbRange)
        Me.gbDates.Controls.Add(Me.dtpEndDate)
        Me.gbDates.Controls.Add(Me.dtpStartDate)
        Me.gbDates.Location = New System.Drawing.Point(12, 202)
        Me.gbDates.Name = "gbDates"
        Me.gbDates.Size = New System.Drawing.Size(333, 124)
        Me.gbDates.TabIndex = 4
        Me.gbDates.TabStop = False
        Me.gbDates.Text = "Dates"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(15, 73)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(52, 13)
        Me.lblEndDate.TabIndex = 8
        Me.lblEndDate.Text = "End Date"
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(15, 29)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(55, 13)
        Me.lblStartDate.TabIndex = 6
        Me.lblStartDate.Text = "Start Date"
        '
        'rbExactDate
        '
        Me.rbExactDate.AutoSize = True
        Me.rbExactDate.Location = New System.Drawing.Point(236, 44)
        Me.rbExactDate.Name = "rbExactDate"
        Me.rbExactDate.Size = New System.Drawing.Size(78, 17)
        Me.rbExactDate.TabIndex = 6
        Me.rbExactDate.TabStop = True
        Me.rbExactDate.Text = "Exact Date"
        Me.rbExactDate.UseVisualStyleBackColor = True
        '
        'rbRange
        '
        Me.rbRange.AutoSize = True
        Me.rbRange.Location = New System.Drawing.Point(236, 67)
        Me.rbRange.Name = "rbRange"
        Me.rbRange.Size = New System.Drawing.Size(57, 17)
        Me.rbRange.TabIndex = 6
        Me.rbRange.TabStop = True
        Me.rbRange.Text = "Range"
        Me.rbRange.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(18, 89)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEndDate.TabIndex = 7
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(18, 45)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartDate.TabIndex = 6
        '
        'gbCategoriesPayess
        '
        Me.gbCategoriesPayess.Controls.Add(Me.rbBoth)
        Me.gbCategoriesPayess.Controls.Add(Me.lblPayee)
        Me.gbCategoriesPayess.Controls.Add(Me.lblCategory)
        Me.gbCategoriesPayess.Controls.Add(Me.rbCategories)
        Me.gbCategoriesPayess.Controls.Add(Me.rbPayees)
        Me.gbCategoriesPayess.Controls.Add(Me.cbPayees)
        Me.gbCategoriesPayess.Controls.Add(Me.cbCategory)
        Me.gbCategoriesPayess.Location = New System.Drawing.Point(12, 332)
        Me.gbCategoriesPayess.Name = "gbCategoriesPayess"
        Me.gbCategoriesPayess.Size = New System.Drawing.Size(333, 124)
        Me.gbCategoriesPayess.TabIndex = 5
        Me.gbCategoriesPayess.TabStop = False
        Me.gbCategoriesPayess.Text = "Categories && Payees"
        '
        'rbBoth
        '
        Me.rbBoth.AutoSize = True
        Me.rbBoth.Location = New System.Drawing.Point(236, 88)
        Me.rbBoth.Name = "rbBoth"
        Me.rbBoth.Size = New System.Drawing.Size(47, 17)
        Me.rbBoth.TabIndex = 12
        Me.rbBoth.TabStop = True
        Me.rbBoth.Text = "Both"
        Me.rbBoth.UseVisualStyleBackColor = True
        '
        'lblPayee
        '
        Me.lblPayee.AutoSize = True
        Me.lblPayee.Location = New System.Drawing.Point(15, 67)
        Me.lblPayee.Name = "lblPayee"
        Me.lblPayee.Size = New System.Drawing.Size(42, 13)
        Me.lblPayee.TabIndex = 11
        Me.lblPayee.Text = "Payees"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(15, 27)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(57, 13)
        Me.lblCategory.TabIndex = 9
        Me.lblCategory.Text = "Categories"
        '
        'rbCategories
        '
        Me.rbCategories.AutoSize = True
        Me.rbCategories.Location = New System.Drawing.Point(236, 42)
        Me.rbCategories.Name = "rbCategories"
        Me.rbCategories.Size = New System.Drawing.Size(75, 17)
        Me.rbCategories.TabIndex = 9
        Me.rbCategories.TabStop = True
        Me.rbCategories.Text = "Categories"
        Me.rbCategories.UseVisualStyleBackColor = True
        '
        'rbPayees
        '
        Me.rbPayees.AutoSize = True
        Me.rbPayees.Location = New System.Drawing.Point(236, 65)
        Me.rbPayees.Name = "rbPayees"
        Me.rbPayees.Size = New System.Drawing.Size(60, 17)
        Me.rbPayees.TabIndex = 10
        Me.rbPayees.TabStop = True
        Me.rbPayees.Text = "Payees"
        Me.rbPayees.UseVisualStyleBackColor = True
        '
        'cbPayees
        '
        Me.cbPayees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPayees.FormattingEnabled = True
        Me.cbPayees.Location = New System.Drawing.Point(18, 83)
        Me.cbPayees.Name = "cbPayees"
        Me.cbPayees.Size = New System.Drawing.Size(202, 21)
        Me.cbPayees.Sorted = True
        Me.cbPayees.TabIndex = 6
        '
        'cbCategory
        '
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(18, 43)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(202, 21)
        Me.cbCategory.Sorted = True
        Me.cbCategory.TabIndex = 5
        '
        'ckbCategoriesPayees
        '
        Me.ckbCategoriesPayees.AutoSize = True
        Me.ckbCategoriesPayees.Location = New System.Drawing.Point(18, 61)
        Me.ckbCategoriesPayees.Name = "ckbCategoriesPayees"
        Me.ckbCategoriesPayees.Size = New System.Drawing.Size(123, 17)
        Me.ckbCategoriesPayees.TabIndex = 11
        Me.ckbCategoriesPayees.Text = "Categories && Payees"
        Me.ckbCategoriesPayees.UseVisualStyleBackColor = True
        '
        'ckbDates
        '
        Me.ckbDates.AutoSize = True
        Me.ckbDates.Location = New System.Drawing.Point(18, 38)
        Me.ckbDates.Name = "ckbDates"
        Me.ckbDates.Size = New System.Drawing.Size(54, 17)
        Me.ckbDates.TabIndex = 7
        Me.ckbDates.Text = "Dates"
        Me.ckbDates.UseVisualStyleBackColor = True
        '
        'gbCleared
        '
        Me.gbCleared.Controls.Add(Me.rbUncleared)
        Me.gbCleared.Controls.Add(Me.rbCleared)
        Me.gbCleared.Location = New System.Drawing.Point(180, 12)
        Me.gbCleared.Margin = New System.Windows.Forms.Padding(2)
        Me.gbCleared.Name = "gbCleared"
        Me.gbCleared.Padding = New System.Windows.Forms.Padding(2)
        Me.gbCleared.Size = New System.Drawing.Size(165, 90)
        Me.gbCleared.TabIndex = 12
        Me.gbCleared.TabStop = False
        Me.gbCleared.Text = "Cleared or Uncleared"
        '
        'rbUncleared
        '
        Me.rbUncleared.AutoSize = True
        Me.rbUncleared.Location = New System.Drawing.Point(45, 48)
        Me.rbUncleared.Name = "rbUncleared"
        Me.rbUncleared.Size = New System.Drawing.Size(74, 17)
        Me.rbUncleared.TabIndex = 10
        Me.rbUncleared.TabStop = True
        Me.rbUncleared.Text = "Uncleared"
        Me.rbUncleared.UseVisualStyleBackColor = True
        '
        'rbCleared
        '
        Me.rbCleared.AutoSize = True
        Me.rbCleared.Location = New System.Drawing.Point(45, 26)
        Me.rbCleared.Name = "rbCleared"
        Me.rbCleared.Size = New System.Drawing.Size(61, 17)
        Me.rbCleared.TabIndex = 9
        Me.rbCleared.TabStop = True
        Me.rbCleared.Text = "Cleared"
        Me.rbCleared.UseVisualStyleBackColor = True
        '
        'rbNoReceipt
        '
        Me.rbNoReceipt.AutoSize = True
        Me.rbNoReceipt.Location = New System.Drawing.Point(43, 48)
        Me.rbNoReceipt.Name = "rbNoReceipt"
        Me.rbNoReceipt.Size = New System.Drawing.Size(79, 17)
        Me.rbNoReceipt.TabIndex = 12
        Me.rbNoReceipt.TabStop = True
        Me.rbNoReceipt.Text = "No Receipt"
        Me.rbNoReceipt.UseVisualStyleBackColor = True
        '
        'rbReceipt
        '
        Me.rbReceipt.AutoSize = True
        Me.rbReceipt.Location = New System.Drawing.Point(43, 26)
        Me.rbReceipt.Name = "rbReceipt"
        Me.rbReceipt.Size = New System.Drawing.Size(62, 17)
        Me.rbReceipt.TabIndex = 11
        Me.rbReceipt.TabStop = True
        Me.rbReceipt.Text = "Receipt"
        Me.rbReceipt.UseVisualStyleBackColor = True
        '
        'gbReceipts
        '
        Me.gbReceipts.Controls.Add(Me.rbNoReceipt)
        Me.gbReceipts.Controls.Add(Me.rbReceipt)
        Me.gbReceipts.Location = New System.Drawing.Point(180, 106)
        Me.gbReceipts.Margin = New System.Windows.Forms.Padding(2)
        Me.gbReceipts.Name = "gbReceipts"
        Me.gbReceipts.Padding = New System.Windows.Forms.Padding(2)
        Me.gbReceipts.Size = New System.Drawing.Size(165, 90)
        Me.gbReceipts.TabIndex = 13
        Me.gbReceipts.TabStop = False
        Me.gbReceipts.Text = "Receipt"
        '
        'ckbReceipts
        '
        Me.ckbReceipts.AutoSize = True
        Me.ckbReceipts.Location = New System.Drawing.Point(18, 107)
        Me.ckbReceipts.Name = "ckbReceipts"
        Me.ckbReceipts.Size = New System.Drawing.Size(68, 17)
        Me.ckbReceipts.TabIndex = 15
        Me.ckbReceipts.Text = "Receipts"
        Me.ckbReceipts.UseVisualStyleBackColor = True
        '
        'ckbClearedAndUncleared
        '
        Me.ckbClearedAndUncleared.AutoSize = True
        Me.ckbClearedAndUncleared.Location = New System.Drawing.Point(18, 84)
        Me.ckbClearedAndUncleared.Name = "ckbClearedAndUncleared"
        Me.ckbClearedAndUncleared.Size = New System.Drawing.Size(126, 17)
        Me.ckbClearedAndUncleared.TabIndex = 14
        Me.ckbClearedAndUncleared.Text = "Cleared or Uncleared"
        Me.ckbClearedAndUncleared.UseVisualStyleBackColor = True
        '
        'gbFilterOptions
        '
        Me.gbFilterOptions.Controls.Add(Me.ckbDates)
        Me.gbFilterOptions.Controls.Add(Me.ckbStatement)
        Me.gbFilterOptions.Controls.Add(Me.ckbReceipts)
        Me.gbFilterOptions.Controls.Add(Me.ckbCategoriesPayees)
        Me.gbFilterOptions.Controls.Add(Me.ckbClearedAndUncleared)
        Me.gbFilterOptions.Location = New System.Drawing.Point(12, 12)
        Me.gbFilterOptions.Name = "gbFilterOptions"
        Me.gbFilterOptions.Size = New System.Drawing.Size(163, 184)
        Me.gbFilterOptions.TabIndex = 16
        Me.gbFilterOptions.TabStop = False
        Me.gbFilterOptions.Text = "Filter Options"
        '
        'ckbStatement
        '
        Me.ckbStatement.AutoSize = True
        Me.ckbStatement.Location = New System.Drawing.Point(18, 130)
        Me.ckbStatement.Name = "ckbStatement"
        Me.ckbStatement.Size = New System.Drawing.Size(74, 17)
        Me.ckbStatement.TabIndex = 15
        Me.ckbStatement.Text = "Statement"
        Me.ckbStatement.UseVisualStyleBackColor = True
        '
        'gbStatements
        '
        Me.gbStatements.Controls.Add(Me.lblStatementName)
        Me.gbStatements.Controls.Add(Me.cbStatements)
        Me.gbStatements.Location = New System.Drawing.Point(12, 462)
        Me.gbStatements.Name = "gbStatements"
        Me.gbStatements.Size = New System.Drawing.Size(333, 90)
        Me.gbStatements.TabIndex = 5
        Me.gbStatements.TabStop = False
        Me.gbStatements.Text = "Statement"
        '
        'lblStatementName
        '
        Me.lblStatementName.AutoSize = True
        Me.lblStatementName.Location = New System.Drawing.Point(15, 28)
        Me.lblStatementName.Name = "lblStatementName"
        Me.lblStatementName.Size = New System.Drawing.Size(86, 13)
        Me.lblStatementName.TabIndex = 9
        Me.lblStatementName.Text = "Statement Name"
        '
        'cbStatements
        '
        Me.cbStatements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatements.FormattingEnabled = True
        Me.cbStatements.Location = New System.Drawing.Point(18, 44)
        Me.cbStatements.Name = "cbStatements"
        Me.cbStatements.Size = New System.Drawing.Size(296, 21)
        Me.cbStatements.Sorted = True
        Me.cbStatements.TabIndex = 5
        '
        'frmFilter
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(357, 594)
        Me.Controls.Add(Me.gbFilterOptions)
        Me.Controls.Add(Me.gbReceipts)
        Me.Controls.Add(Me.gbCleared)
        Me.Controls.Add(Me.gbStatements)
        Me.Controls.Add(Me.gbCategoriesPayess)
        Me.Controls.Add(Me.gbDates)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFilter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advanced Filter"
        Me.gbDates.ResumeLayout(False)
        Me.gbDates.PerformLayout()
        Me.gbCategoriesPayess.ResumeLayout(False)
        Me.gbCategoriesPayess.PerformLayout()
        Me.gbCleared.ResumeLayout(False)
        Me.gbCleared.PerformLayout()
        Me.gbReceipts.ResumeLayout(False)
        Me.gbReceipts.PerformLayout()
        Me.gbFilterOptions.ResumeLayout(False)
        Me.gbFilterOptions.PerformLayout()
        Me.gbStatements.ResumeLayout(False)
        Me.gbStatements.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents btnApply As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents gbDates As GroupBox
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblStartDate As Label
    Friend WithEvents rbExactDate As RadioButton
    Friend WithEvents rbRange As RadioButton
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents gbCategoriesPayess As GroupBox
    Friend WithEvents ckbCategoriesPayees As CheckBox
    Friend WithEvents ckbDates As CheckBox
    Friend WithEvents lblPayee As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents rbCategories As RadioButton
    Friend WithEvents rbPayees As RadioButton
    Friend WithEvents cbPayees As ComboBox
    Friend WithEvents cbCategory As ComboBox
    Friend WithEvents rbBoth As RadioButton
    Friend WithEvents gbCleared As GroupBox
    Friend WithEvents rbUncleared As RadioButton
    Friend WithEvents rbCleared As RadioButton
    Friend WithEvents rbNoReceipt As RadioButton
    Friend WithEvents rbReceipt As RadioButton
    Friend WithEvents gbReceipts As GroupBox
    Friend WithEvents ckbReceipts As CheckBox
    Friend WithEvents ckbClearedAndUncleared As CheckBox
    Friend WithEvents gbFilterOptions As GroupBox
    Friend WithEvents gbStatements As GroupBox
    Friend WithEvents lblStatementName As Label
    Friend WithEvents cbStatements As ComboBox
    Friend WithEvents ckbStatement As CheckBox
End Class
