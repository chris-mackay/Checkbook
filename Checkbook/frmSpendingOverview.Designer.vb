<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSpendingOverview
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpendingOverview))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cxmnuWhatIf = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuCreateExpense = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditExpense = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveExpenses = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyToNextMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyToRestOfYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyToSelectedMonths = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cxmnuResetYearTotals = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCreateEmptyScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.lblYearStatus = New System.Windows.Forms.Label()
        Me.lblOverallBalance = New System.Windows.Forms.Label()
        Me.lblTotalPayments = New System.Windows.Forms.Label()
        Me.txtTotalPayments = New System.Windows.Forms.TextBox()
        Me.txtOverallBalance = New System.Windows.Forms.TextBox()
        Me.txtYearStatus = New System.Windows.Forms.TextBox()
        Me.btnResetYearTotals = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnCreateExpense = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRemoveCategory = New System.Windows.Forms.Button()
        Me.btnEditExpense = New System.Windows.Forms.Button()
        Me.btnRemoveExpenses = New System.Windows.Forms.Button()
        Me.lblTotalDeposits = New System.Windows.Forms.Label()
        Me.txtTotalDeposits = New System.Windows.Forms.TextBox()
        Me.dgvCategory = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.January = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.February = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.March = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.April = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.May = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.June = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.July = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.August = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.September = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.October = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.November = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.December = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Totals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Percent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbWhatif = New System.Windows.Forms.GroupBox()
        Me.btnCopyToSelectedMonths = New System.Windows.Forms.Button()
        Me.btnCopyToRestOfYear = New System.Windows.Forms.Button()
        Me.btnCopyToNextMonth = New System.Windows.Forms.Button()
        Me.gbModelOptions = New System.Windows.Forms.GroupBox()
        Me.rbCurrentYear = New System.Windows.Forms.RadioButton()
        Me.rbNextYear = New System.Windows.Forms.RadioButton()
        Me.btnCreateEmptyWhatif = New System.Windows.Forms.Button()
        Me.cbCategoriesPayees = New System.Windows.Forms.ComboBox()
        Me.lblFilterCategoriesPayees = New System.Windows.Forms.Label()
        Me.dgvMonthly = New System.Windows.Forms.DataGridView()
        Me.Month = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Payments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deposits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monthly = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AveMonthlyIncome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cxmnuMonthlyIncomeTable = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuEditValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblFilterPaymentsDeposits = New System.Windows.Forms.Label()
        Me.cbPaymentsDeposits = New System.Windows.Forms.ComboBox()
        Me.lblLedgerStatus = New System.Windows.Forms.Label()
        Me.txtLedgerStatus = New System.Windows.Forms.TextBox()
        Me.gbCurrentYear = New System.Windows.Forms.GroupBox()
        Me.gbOverallDetails = New System.Windows.Forms.GroupBox()
        Me.gbFilterOptions = New System.Windows.Forms.GroupBox()
        Me.cxmnuWhatIf.SuspendLayout()
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbWhatif.SuspendLayout()
        Me.gbModelOptions.SuspendLayout()
        CType(Me.dgvMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxmnuMonthlyIncomeTable.SuspendLayout()
        Me.gbCurrentYear.SuspendLayout()
        Me.gbOverallDetails.SuspendLayout()
        Me.gbFilterOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'cxmnuWhatIf
        '
        Me.cxmnuWhatIf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cxmnuWhatIf.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuCreateExpense, Me.cxmnuEditExpense, Me.cxmnuRemoveExpenses, Me.cxmnuRemoveCategories, Me.cxmnuCopyToNextMonth, Me.cxmnuCopyToRestOfYear, Me.cxmnuCopyToSelectedMonths, Me.ToolStripSeparator1, Me.cxmnuResetYearTotals, Me.cxmnuCreateEmptyScenario})
        Me.cxmnuWhatIf.Name = "cxmnuWhatIf"
        Me.cxmnuWhatIf.Size = New System.Drawing.Size(198, 208)
        '
        'cxmnuCreateExpense
        '
        Me.cxmnuCreateExpense.Image = CType(resources.GetObject("cxmnuCreateExpense.Image"), System.Drawing.Image)
        Me.cxmnuCreateExpense.Name = "cxmnuCreateExpense"
        Me.cxmnuCreateExpense.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuCreateExpense.Text = "Create Monthly Expense"
        '
        'cxmnuEditExpense
        '
        Me.cxmnuEditExpense.Image = CType(resources.GetObject("cxmnuEditExpense.Image"), System.Drawing.Image)
        Me.cxmnuEditExpense.Name = "cxmnuEditExpense"
        Me.cxmnuEditExpense.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuEditExpense.Text = "Edit Expenses"
        '
        'cxmnuRemoveExpenses
        '
        Me.cxmnuRemoveExpenses.Image = CType(resources.GetObject("cxmnuRemoveExpenses.Image"), System.Drawing.Image)
        Me.cxmnuRemoveExpenses.Name = "cxmnuRemoveExpenses"
        Me.cxmnuRemoveExpenses.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuRemoveExpenses.Text = "Remove Expenses"
        '
        'cxmnuRemoveCategories
        '
        Me.cxmnuRemoveCategories.Image = CType(resources.GetObject("cxmnuRemoveCategories.Image"), System.Drawing.Image)
        Me.cxmnuRemoveCategories.Name = "cxmnuRemoveCategories"
        Me.cxmnuRemoveCategories.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuRemoveCategories.Text = "Remove Categories"
        '
        'cxmnuCopyToNextMonth
        '
        Me.cxmnuCopyToNextMonth.Image = CType(resources.GetObject("cxmnuCopyToNextMonth.Image"), System.Drawing.Image)
        Me.cxmnuCopyToNextMonth.Name = "cxmnuCopyToNextMonth"
        Me.cxmnuCopyToNextMonth.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuCopyToNextMonth.Text = "Copy to Next Month"
        '
        'cxmnuCopyToRestOfYear
        '
        Me.cxmnuCopyToRestOfYear.Image = CType(resources.GetObject("cxmnuCopyToRestOfYear.Image"), System.Drawing.Image)
        Me.cxmnuCopyToRestOfYear.Name = "cxmnuCopyToRestOfYear"
        Me.cxmnuCopyToRestOfYear.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuCopyToRestOfYear.Text = "Copy to Rest of Year"
        '
        'cxmnuCopyToSelectedMonths
        '
        Me.cxmnuCopyToSelectedMonths.Image = CType(resources.GetObject("cxmnuCopyToSelectedMonths.Image"), System.Drawing.Image)
        Me.cxmnuCopyToSelectedMonths.Name = "cxmnuCopyToSelectedMonths"
        Me.cxmnuCopyToSelectedMonths.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuCopyToSelectedMonths.Text = "Copy To Selected Months"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(194, 6)
        '
        'cxmnuResetYearTotals
        '
        Me.cxmnuResetYearTotals.Image = CType(resources.GetObject("cxmnuResetYearTotals.Image"), System.Drawing.Image)
        Me.cxmnuResetYearTotals.Name = "cxmnuResetYearTotals"
        Me.cxmnuResetYearTotals.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuResetYearTotals.Text = "Reset All Expenses"
        '
        'cxmnuCreateEmptyScenario
        '
        Me.cxmnuCreateEmptyScenario.Image = CType(resources.GetObject("cxmnuCreateEmptyScenario.Image"), System.Drawing.Image)
        Me.cxmnuCreateEmptyScenario.Name = "cxmnuCreateEmptyScenario"
        Me.cxmnuCreateEmptyScenario.Size = New System.Drawing.Size(197, 22)
        Me.cxmnuCreateEmptyScenario.Text = "Create Empty Scenario"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1140, 766)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(25, 21)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 1
        Me.lblYear.Text = "Year"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(25, 37)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(121, 21)
        Me.cbYear.TabIndex = 2
        '
        'lblYearStatus
        '
        Me.lblYearStatus.AutoSize = True
        Me.lblYearStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYearStatus.Location = New System.Drawing.Point(248, 21)
        Me.lblYearStatus.Name = "lblYearStatus"
        Me.lblYearStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblYearStatus.TabIndex = 4
        Me.lblYearStatus.Text = "Status"
        '
        'lblOverallBalance
        '
        Me.lblOverallBalance.AutoSize = True
        Me.lblOverallBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblOverallBalance.Location = New System.Drawing.Point(28, 21)
        Me.lblOverallBalance.Name = "lblOverallBalance"
        Me.lblOverallBalance.Size = New System.Drawing.Size(82, 13)
        Me.lblOverallBalance.TabIndex = 0
        Me.lblOverallBalance.Text = "Overall Balance"
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.AutoSize = True
        Me.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalPayments.Location = New System.Drawing.Point(36, 21)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Size = New System.Drawing.Size(80, 13)
        Me.lblTotalPayments.TabIndex = 0
        Me.lblTotalPayments.Text = "Total Payments"
        '
        'txtTotalPayments
        '
        Me.txtTotalPayments.Enabled = False
        Me.txtTotalPayments.Location = New System.Drawing.Point(36, 37)
        Me.txtTotalPayments.Name = "txtTotalPayments"
        Me.txtTotalPayments.ReadOnly = True
        Me.txtTotalPayments.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPayments.TabIndex = 1
        '
        'txtOverallBalance
        '
        Me.txtOverallBalance.Enabled = False
        Me.txtOverallBalance.Location = New System.Drawing.Point(28, 37)
        Me.txtOverallBalance.Name = "txtOverallBalance"
        Me.txtOverallBalance.ReadOnly = True
        Me.txtOverallBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtOverallBalance.TabIndex = 1
        '
        'txtYearStatus
        '
        Me.txtYearStatus.Enabled = False
        Me.txtYearStatus.Location = New System.Drawing.Point(248, 37)
        Me.txtYearStatus.Name = "txtYearStatus"
        Me.txtYearStatus.ReadOnly = True
        Me.txtYearStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtYearStatus.TabIndex = 5
        '
        'btnResetYearTotals
        '
        Me.btnResetYearTotals.BackColor = System.Drawing.Color.White
        Me.btnResetYearTotals.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnResetYearTotals.FlatAppearance.BorderSize = 2
        Me.btnResetYearTotals.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnResetYearTotals.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnResetYearTotals.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetYearTotals.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnResetYearTotals.Image = CType(resources.GetObject("btnResetYearTotals.Image"), System.Drawing.Image)
        Me.btnResetYearTotals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetYearTotals.Location = New System.Drawing.Point(227, 61)
        Me.btnResetYearTotals.Name = "btnResetYearTotals"
        Me.btnResetYearTotals.Size = New System.Drawing.Size(180, 30)
        Me.btnResetYearTotals.TabIndex = 8
        Me.btnResetYearTotals.Text = "Reset All Expenses"
        Me.btnResetYearTotals.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnResetYearTotals.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.Color.White
        Me.btnOpen.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnOpen.FlatAppearance.BorderSize = 2
        Me.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpen.Location = New System.Drawing.Point(227, 133)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(180, 30)
        Me.btnOpen.TabIndex = 10
        Me.btnOpen.Text = "Open What If Scenario"
        Me.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnCreateExpense
        '
        Me.btnCreateExpense.BackColor = System.Drawing.Color.White
        Me.btnCreateExpense.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCreateExpense.FlatAppearance.BorderSize = 2
        Me.btnCreateExpense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCreateExpense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCreateExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateExpense.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnCreateExpense.Image = CType(resources.GetObject("btnCreateExpense.Image"), System.Drawing.Image)
        Me.btnCreateExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateExpense.Location = New System.Drawing.Point(41, 25)
        Me.btnCreateExpense.Name = "btnCreateExpense"
        Me.btnCreateExpense.Size = New System.Drawing.Size(180, 30)
        Me.btnCreateExpense.TabIndex = 0
        Me.btnCreateExpense.Text = "Create Monthly Expense"
        Me.btnCreateExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateExpense.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSave.FlatAppearance.BorderSize = 2
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(227, 97)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(180, 30)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save What If Scenario"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnRemoveCategory
        '
        Me.btnRemoveCategory.BackColor = System.Drawing.Color.White
        Me.btnRemoveCategory.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRemoveCategory.FlatAppearance.BorderSize = 2
        Me.btnRemoveCategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnRemoveCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRemoveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnRemoveCategory.Image = CType(resources.GetObject("btnRemoveCategory.Image"), System.Drawing.Image)
        Me.btnRemoveCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveCategory.Location = New System.Drawing.Point(41, 133)
        Me.btnRemoveCategory.Name = "btnRemoveCategory"
        Me.btnRemoveCategory.Size = New System.Drawing.Size(180, 30)
        Me.btnRemoveCategory.TabIndex = 3
        Me.btnRemoveCategory.Text = "Remove Categories"
        Me.btnRemoveCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoveCategory.UseVisualStyleBackColor = False
        '
        'btnEditExpense
        '
        Me.btnEditExpense.BackColor = System.Drawing.Color.White
        Me.btnEditExpense.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnEditExpense.FlatAppearance.BorderSize = 2
        Me.btnEditExpense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnEditExpense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnEditExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditExpense.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnEditExpense.Image = CType(resources.GetObject("btnEditExpense.Image"), System.Drawing.Image)
        Me.btnEditExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditExpense.Location = New System.Drawing.Point(41, 61)
        Me.btnEditExpense.Name = "btnEditExpense"
        Me.btnEditExpense.Size = New System.Drawing.Size(180, 30)
        Me.btnEditExpense.TabIndex = 1
        Me.btnEditExpense.Text = "Edit Expenses"
        Me.btnEditExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditExpense.UseVisualStyleBackColor = False
        '
        'btnRemoveExpenses
        '
        Me.btnRemoveExpenses.BackColor = System.Drawing.Color.White
        Me.btnRemoveExpenses.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRemoveExpenses.FlatAppearance.BorderSize = 2
        Me.btnRemoveExpenses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnRemoveExpenses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRemoveExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveExpenses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnRemoveExpenses.Image = CType(resources.GetObject("btnRemoveExpenses.Image"), System.Drawing.Image)
        Me.btnRemoveExpenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveExpenses.Location = New System.Drawing.Point(41, 97)
        Me.btnRemoveExpenses.Name = "btnRemoveExpenses"
        Me.btnRemoveExpenses.Size = New System.Drawing.Size(180, 30)
        Me.btnRemoveExpenses.TabIndex = 2
        Me.btnRemoveExpenses.Text = "Remove Expenses"
        Me.btnRemoveExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoveExpenses.UseVisualStyleBackColor = False
        '
        'lblTotalDeposits
        '
        Me.lblTotalDeposits.AutoSize = True
        Me.lblTotalDeposits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalDeposits.Location = New System.Drawing.Point(142, 21)
        Me.lblTotalDeposits.Name = "lblTotalDeposits"
        Me.lblTotalDeposits.Size = New System.Drawing.Size(75, 13)
        Me.lblTotalDeposits.TabIndex = 2
        Me.lblTotalDeposits.Text = "Total Deposits"
        '
        'txtTotalDeposits
        '
        Me.txtTotalDeposits.Enabled = False
        Me.txtTotalDeposits.Location = New System.Drawing.Point(142, 37)
        Me.txtTotalDeposits.Name = "txtTotalDeposits"
        Me.txtTotalDeposits.ReadOnly = True
        Me.txtTotalDeposits.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDeposits.TabIndex = 3
        '
        'dgvCategory
        '
        Me.dgvCategory.AllowUserToAddRows = False
        Me.dgvCategory.AllowUserToDeleteRows = False
        Me.dgvCategory.AllowUserToResizeColumns = False
        Me.dgvCategory.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCategory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCategory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCategory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.January, Me.February, Me.March, Me.April, Me.May, Me.June, Me.July, Me.August, Me.September, Me.October, Me.November, Me.December, Me.Totals, Me.Percent})
        Me.dgvCategory.ContextMenuStrip = Me.cxmnuWhatIf
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCategory.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCategory.GridColor = System.Drawing.Color.LightGray
        Me.dgvCategory.Location = New System.Drawing.Point(12, 97)
        Me.dgvCategory.Name = "dgvCategory"
        Me.dgvCategory.ReadOnly = True
        Me.dgvCategory.RowHeadersVisible = False
        Me.dgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCategory.Size = New System.Drawing.Size(1203, 401)
        Me.dgvCategory.TabIndex = 3
        '
        'Item
        '
        Me.Item.HeaderText = "Category"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'January
        '
        Me.January.HeaderText = "January"
        Me.January.Name = "January"
        Me.January.ReadOnly = True
        Me.January.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'February
        '
        Me.February.HeaderText = "February"
        Me.February.Name = "February"
        Me.February.ReadOnly = True
        Me.February.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'March
        '
        Me.March.HeaderText = "March"
        Me.March.Name = "March"
        Me.March.ReadOnly = True
        Me.March.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'April
        '
        Me.April.HeaderText = "April"
        Me.April.Name = "April"
        Me.April.ReadOnly = True
        Me.April.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'May
        '
        Me.May.HeaderText = "May"
        Me.May.Name = "May"
        Me.May.ReadOnly = True
        Me.May.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'June
        '
        Me.June.HeaderText = "June"
        Me.June.Name = "June"
        Me.June.ReadOnly = True
        Me.June.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'July
        '
        Me.July.HeaderText = "July"
        Me.July.Name = "July"
        Me.July.ReadOnly = True
        Me.July.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'August
        '
        Me.August.HeaderText = "August"
        Me.August.Name = "August"
        Me.August.ReadOnly = True
        Me.August.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'September
        '
        Me.September.HeaderText = "September"
        Me.September.Name = "September"
        Me.September.ReadOnly = True
        Me.September.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'October
        '
        Me.October.HeaderText = "October"
        Me.October.Name = "October"
        Me.October.ReadOnly = True
        Me.October.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'November
        '
        Me.November.HeaderText = "November"
        Me.November.Name = "November"
        Me.November.ReadOnly = True
        Me.November.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'December
        '
        Me.December.HeaderText = "December"
        Me.December.Name = "December"
        Me.December.ReadOnly = True
        Me.December.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Totals
        '
        Me.Totals.HeaderText = "Totals"
        Me.Totals.Name = "Totals"
        Me.Totals.ReadOnly = True
        Me.Totals.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Percent
        '
        Me.Percent.HeaderText = "Percent"
        Me.Percent.Name = "Percent"
        Me.Percent.ReadOnly = True
        Me.Percent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gbWhatif
        '
        Me.gbWhatif.Controls.Add(Me.btnCopyToSelectedMonths)
        Me.gbWhatif.Controls.Add(Me.btnCopyToRestOfYear)
        Me.gbWhatif.Controls.Add(Me.btnCopyToNextMonth)
        Me.gbWhatif.Controls.Add(Me.gbModelOptions)
        Me.gbWhatif.Controls.Add(Me.btnCreateEmptyWhatif)
        Me.gbWhatif.Controls.Add(Me.btnResetYearTotals)
        Me.gbWhatif.Controls.Add(Me.btnCreateExpense)
        Me.gbWhatif.Controls.Add(Me.btnOpen)
        Me.gbWhatif.Controls.Add(Me.btnRemoveExpenses)
        Me.gbWhatif.Controls.Add(Me.btnEditExpense)
        Me.gbWhatif.Controls.Add(Me.btnRemoveCategory)
        Me.gbWhatif.Controls.Add(Me.btnSave)
        Me.gbWhatif.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbWhatif.Location = New System.Drawing.Point(503, 504)
        Me.gbWhatif.Name = "gbWhatif"
        Me.gbWhatif.Size = New System.Drawing.Size(449, 285)
        Me.gbWhatif.TabIndex = 5
        Me.gbWhatif.TabStop = False
        Me.gbWhatif.Text = "What if...Create a hypothetical monthly scenario"
        '
        'btnCopyToSelectedMonths
        '
        Me.btnCopyToSelectedMonths.BackColor = System.Drawing.Color.White
        Me.btnCopyToSelectedMonths.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCopyToSelectedMonths.FlatAppearance.BorderSize = 2
        Me.btnCopyToSelectedMonths.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCopyToSelectedMonths.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCopyToSelectedMonths.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToSelectedMonths.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnCopyToSelectedMonths.Image = CType(resources.GetObject("btnCopyToSelectedMonths.Image"), System.Drawing.Image)
        Me.btnCopyToSelectedMonths.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopyToSelectedMonths.Location = New System.Drawing.Point(41, 241)
        Me.btnCopyToSelectedMonths.Name = "btnCopyToSelectedMonths"
        Me.btnCopyToSelectedMonths.Size = New System.Drawing.Size(180, 30)
        Me.btnCopyToSelectedMonths.TabIndex = 6
        Me.btnCopyToSelectedMonths.Text = "Copy to Selected Months"
        Me.btnCopyToSelectedMonths.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCopyToSelectedMonths.UseVisualStyleBackColor = False
        '
        'btnCopyToRestOfYear
        '
        Me.btnCopyToRestOfYear.BackColor = System.Drawing.Color.White
        Me.btnCopyToRestOfYear.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCopyToRestOfYear.FlatAppearance.BorderSize = 2
        Me.btnCopyToRestOfYear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCopyToRestOfYear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCopyToRestOfYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToRestOfYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnCopyToRestOfYear.Image = CType(resources.GetObject("btnCopyToRestOfYear.Image"), System.Drawing.Image)
        Me.btnCopyToRestOfYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopyToRestOfYear.Location = New System.Drawing.Point(41, 205)
        Me.btnCopyToRestOfYear.Name = "btnCopyToRestOfYear"
        Me.btnCopyToRestOfYear.Size = New System.Drawing.Size(180, 30)
        Me.btnCopyToRestOfYear.TabIndex = 5
        Me.btnCopyToRestOfYear.Text = "Copy to Rest of Year"
        Me.btnCopyToRestOfYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCopyToRestOfYear.UseVisualStyleBackColor = False
        '
        'btnCopyToNextMonth
        '
        Me.btnCopyToNextMonth.BackColor = System.Drawing.Color.White
        Me.btnCopyToNextMonth.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCopyToNextMonth.FlatAppearance.BorderSize = 2
        Me.btnCopyToNextMonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCopyToNextMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCopyToNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopyToNextMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnCopyToNextMonth.Image = CType(resources.GetObject("btnCopyToNextMonth.Image"), System.Drawing.Image)
        Me.btnCopyToNextMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopyToNextMonth.Location = New System.Drawing.Point(41, 169)
        Me.btnCopyToNextMonth.Name = "btnCopyToNextMonth"
        Me.btnCopyToNextMonth.Size = New System.Drawing.Size(180, 30)
        Me.btnCopyToNextMonth.TabIndex = 4
        Me.btnCopyToNextMonth.Text = "Copy to Next Month"
        Me.btnCopyToNextMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCopyToNextMonth.UseVisualStyleBackColor = False
        '
        'gbModelOptions
        '
        Me.gbModelOptions.Controls.Add(Me.rbCurrentYear)
        Me.gbModelOptions.Controls.Add(Me.rbNextYear)
        Me.gbModelOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbModelOptions.Location = New System.Drawing.Point(227, 169)
        Me.gbModelOptions.Name = "gbModelOptions"
        Me.gbModelOptions.Size = New System.Drawing.Size(180, 102)
        Me.gbModelOptions.TabIndex = 11
        Me.gbModelOptions.TabStop = False
        Me.gbModelOptions.Text = "Modeling Options"
        '
        'rbCurrentYear
        '
        Me.rbCurrentYear.AutoSize = True
        Me.rbCurrentYear.Checked = True
        Me.rbCurrentYear.Location = New System.Drawing.Point(23, 30)
        Me.rbCurrentYear.Name = "rbCurrentYear"
        Me.rbCurrentYear.Size = New System.Drawing.Size(84, 17)
        Me.rbCurrentYear.TabIndex = 0
        Me.rbCurrentYear.TabStop = True
        Me.rbCurrentYear.Text = "Current Year"
        Me.rbCurrentYear.UseVisualStyleBackColor = True
        '
        'rbNextYear
        '
        Me.rbNextYear.AutoSize = True
        Me.rbNextYear.Location = New System.Drawing.Point(23, 53)
        Me.rbNextYear.Name = "rbNextYear"
        Me.rbNextYear.Size = New System.Drawing.Size(72, 17)
        Me.rbNextYear.TabIndex = 1
        Me.rbNextYear.TabStop = True
        Me.rbNextYear.Text = "Next Year"
        Me.rbNextYear.UseVisualStyleBackColor = True
        '
        'btnCreateEmptyWhatif
        '
        Me.btnCreateEmptyWhatif.BackColor = System.Drawing.Color.White
        Me.btnCreateEmptyWhatif.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCreateEmptyWhatif.FlatAppearance.BorderSize = 2
        Me.btnCreateEmptyWhatif.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCreateEmptyWhatif.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCreateEmptyWhatif.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateEmptyWhatif.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnCreateEmptyWhatif.Image = CType(resources.GetObject("btnCreateEmptyWhatif.Image"), System.Drawing.Image)
        Me.btnCreateEmptyWhatif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateEmptyWhatif.Location = New System.Drawing.Point(227, 25)
        Me.btnCreateEmptyWhatif.Name = "btnCreateEmptyWhatif"
        Me.btnCreateEmptyWhatif.Size = New System.Drawing.Size(180, 30)
        Me.btnCreateEmptyWhatif.TabIndex = 7
        Me.btnCreateEmptyWhatif.Text = "Create Empty Scenario"
        Me.btnCreateEmptyWhatif.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateEmptyWhatif.UseVisualStyleBackColor = False
        '
        'cbCategoriesPayees
        '
        Me.cbCategoriesPayees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoriesPayees.FormattingEnabled = True
        Me.cbCategoriesPayees.Items.AddRange(New Object() {"Categories", "Payees"})
        Me.cbCategoriesPayees.Location = New System.Drawing.Point(152, 37)
        Me.cbCategoriesPayees.Name = "cbCategoriesPayees"
        Me.cbCategoriesPayees.Size = New System.Drawing.Size(182, 21)
        Me.cbCategoriesPayees.TabIndex = 4
        '
        'lblFilterCategoriesPayees
        '
        Me.lblFilterCategoriesPayees.AutoSize = True
        Me.lblFilterCategoriesPayees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblFilterCategoriesPayees.Location = New System.Drawing.Point(152, 21)
        Me.lblFilterCategoriesPayees.Name = "lblFilterCategoriesPayees"
        Me.lblFilterCategoriesPayees.Size = New System.Drawing.Size(107, 13)
        Me.lblFilterCategoriesPayees.TabIndex = 3
        Me.lblFilterCategoriesPayees.Text = "Categories or Payees"
        '
        'dgvMonthly
        '
        Me.dgvMonthly.AllowUserToAddRows = False
        Me.dgvMonthly.AllowUserToDeleteRows = False
        Me.dgvMonthly.AllowUserToResizeColumns = False
        Me.dgvMonthly.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMonthly.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMonthly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMonthly.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMonthly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMonthly.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMonthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMonthly.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Month, Me.Payments, Me.Deposits, Me.Monthly, Me.AveMonthlyIncome})
        Me.dgvMonthly.ContextMenuStrip = Me.cxmnuMonthlyIncomeTable
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMonthly.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMonthly.GridColor = System.Drawing.Color.LightGray
        Me.dgvMonthly.Location = New System.Drawing.Point(12, 504)
        Me.dgvMonthly.Name = "dgvMonthly"
        Me.dgvMonthly.ReadOnly = True
        Me.dgvMonthly.RowHeadersVisible = False
        Me.dgvMonthly.Size = New System.Drawing.Size(485, 285)
        Me.dgvMonthly.TabIndex = 4
        '
        'Month
        '
        Me.Month.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Month.HeaderText = "Month"
        Me.Month.Name = "Month"
        Me.Month.ReadOnly = True
        Me.Month.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Month.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Payments
        '
        Me.Payments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Payments.HeaderText = "Payments"
        Me.Payments.Name = "Payments"
        Me.Payments.ReadOnly = True
        Me.Payments.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Payments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Deposits
        '
        Me.Deposits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Deposits.HeaderText = "Deposits"
        Me.Deposits.Name = "Deposits"
        Me.Deposits.ReadOnly = True
        Me.Deposits.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Deposits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Monthly
        '
        Me.Monthly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Monthly.HeaderText = "Monthly"
        Me.Monthly.Name = "Monthly"
        Me.Monthly.ReadOnly = True
        Me.Monthly.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Monthly.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AveMonthlyIncome
        '
        Me.AveMonthlyIncome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.AveMonthlyIncome.HeaderText = "Average Income"
        Me.AveMonthlyIncome.Name = "AveMonthlyIncome"
        Me.AveMonthlyIncome.ReadOnly = True
        Me.AveMonthlyIncome.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AveMonthlyIncome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cxmnuMonthlyIncomeTable
        '
        Me.cxmnuMonthlyIncomeTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cxmnuMonthlyIncomeTable.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuEditValues, Me.cxmnuRemoveValues})
        Me.cxmnuMonthlyIncomeTable.Name = "cxmnuMonthlyIncomeTable"
        Me.cxmnuMonthlyIncomeTable.Size = New System.Drawing.Size(192, 48)
        '
        'cxmnuEditValues
        '
        Me.cxmnuEditValues.Image = CType(resources.GetObject("cxmnuEditValues.Image"), System.Drawing.Image)
        Me.cxmnuEditValues.Name = "cxmnuEditValues"
        Me.cxmnuEditValues.Size = New System.Drawing.Size(191, 22)
        Me.cxmnuEditValues.Text = "Edit Selected Totals"
        '
        'cxmnuRemoveValues
        '
        Me.cxmnuRemoveValues.Image = CType(resources.GetObject("cxmnuRemoveValues.Image"), System.Drawing.Image)
        Me.cxmnuRemoveValues.Name = "cxmnuRemoveValues"
        Me.cxmnuRemoveValues.Size = New System.Drawing.Size(191, 22)
        Me.cxmnuRemoveValues.Text = "Remove Selected Totals"
        '
        'lblFilterPaymentsDeposits
        '
        Me.lblFilterPaymentsDeposits.AutoSize = True
        Me.lblFilterPaymentsDeposits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblFilterPaymentsDeposits.Location = New System.Drawing.Point(340, 21)
        Me.lblFilterPaymentsDeposits.Name = "lblFilterPaymentsDeposits"
        Me.lblFilterPaymentsDeposits.Size = New System.Drawing.Size(109, 13)
        Me.lblFilterPaymentsDeposits.TabIndex = 5
        Me.lblFilterPaymentsDeposits.Text = "Payments or Deposits"
        '
        'cbPaymentsDeposits
        '
        Me.cbPaymentsDeposits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaymentsDeposits.FormattingEnabled = True
        Me.cbPaymentsDeposits.Items.AddRange(New Object() {"Payments", "Deposits"})
        Me.cbPaymentsDeposits.Location = New System.Drawing.Point(340, 37)
        Me.cbPaymentsDeposits.Name = "cbPaymentsDeposits"
        Me.cbPaymentsDeposits.Size = New System.Drawing.Size(182, 21)
        Me.cbPaymentsDeposits.TabIndex = 6
        '
        'lblLedgerStatus
        '
        Me.lblLedgerStatus.AutoSize = True
        Me.lblLedgerStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblLedgerStatus.Location = New System.Drawing.Point(134, 21)
        Me.lblLedgerStatus.Name = "lblLedgerStatus"
        Me.lblLedgerStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblLedgerStatus.TabIndex = 2
        Me.lblLedgerStatus.Text = "Ledger Status"
        '
        'txtLedgerStatus
        '
        Me.txtLedgerStatus.Enabled = False
        Me.txtLedgerStatus.Location = New System.Drawing.Point(134, 37)
        Me.txtLedgerStatus.Name = "txtLedgerStatus"
        Me.txtLedgerStatus.ReadOnly = True
        Me.txtLedgerStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtLedgerStatus.TabIndex = 3
        '
        'gbCurrentYear
        '
        Me.gbCurrentYear.Controls.Add(Me.txtTotalPayments)
        Me.gbCurrentYear.Controls.Add(Me.lblTotalPayments)
        Me.gbCurrentYear.Controls.Add(Me.txtTotalDeposits)
        Me.gbCurrentYear.Controls.Add(Me.lblTotalDeposits)
        Me.gbCurrentYear.Controls.Add(Me.txtYearStatus)
        Me.gbCurrentYear.Controls.Add(Me.lblYearStatus)
        Me.gbCurrentYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbCurrentYear.Location = New System.Drawing.Point(567, 12)
        Me.gbCurrentYear.Name = "gbCurrentYear"
        Me.gbCurrentYear.Size = New System.Drawing.Size(379, 79)
        Me.gbCurrentYear.TabIndex = 1
        Me.gbCurrentYear.TabStop = False
        Me.gbCurrentYear.Text = "Current Year Details"
        '
        'gbOverallDetails
        '
        Me.gbOverallDetails.Controls.Add(Me.txtOverallBalance)
        Me.gbOverallDetails.Controls.Add(Me.lblOverallBalance)
        Me.gbOverallDetails.Controls.Add(Me.txtLedgerStatus)
        Me.gbOverallDetails.Controls.Add(Me.lblLedgerStatus)
        Me.gbOverallDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbOverallDetails.Location = New System.Drawing.Point(952, 12)
        Me.gbOverallDetails.Name = "gbOverallDetails"
        Me.gbOverallDetails.Size = New System.Drawing.Size(263, 79)
        Me.gbOverallDetails.TabIndex = 2
        Me.gbOverallDetails.TabStop = False
        Me.gbOverallDetails.Text = "Overall Account Details"
        '
        'gbFilterOptions
        '
        Me.gbFilterOptions.Controls.Add(Me.cbYear)
        Me.gbFilterOptions.Controls.Add(Me.lblYear)
        Me.gbFilterOptions.Controls.Add(Me.cbCategoriesPayees)
        Me.gbFilterOptions.Controls.Add(Me.lblFilterPaymentsDeposits)
        Me.gbFilterOptions.Controls.Add(Me.lblFilterCategoriesPayees)
        Me.gbFilterOptions.Controls.Add(Me.cbPaymentsDeposits)
        Me.gbFilterOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbFilterOptions.Location = New System.Drawing.Point(12, 12)
        Me.gbFilterOptions.Name = "gbFilterOptions"
        Me.gbFilterOptions.Size = New System.Drawing.Size(549, 79)
        Me.gbFilterOptions.TabIndex = 0
        Me.gbFilterOptions.TabStop = False
        Me.gbFilterOptions.Text = "Filter Options"
        '
        'frmSpendingOverview
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1227, 801)
        Me.Controls.Add(Me.gbFilterOptions)
        Me.Controls.Add(Me.gbOverallDetails)
        Me.Controls.Add(Me.gbCurrentYear)
        Me.Controls.Add(Me.dgvMonthly)
        Me.Controls.Add(Me.gbWhatif)
        Me.Controls.Add(Me.dgvCategory)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1161, 667)
        Me.Name = "frmSpendingOverview"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Spending Overview"
        Me.cxmnuWhatIf.ResumeLayout(False)
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbWhatif.ResumeLayout(False)
        Me.gbModelOptions.ResumeLayout(False)
        Me.gbModelOptions.PerformLayout()
        CType(Me.dgvMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxmnuMonthlyIncomeTable.ResumeLayout(False)
        Me.gbCurrentYear.ResumeLayout(False)
        Me.gbCurrentYear.PerformLayout()
        Me.gbOverallDetails.ResumeLayout(False)
        Me.gbOverallDetails.PerformLayout()
        Me.gbFilterOptions.ResumeLayout(False)
        Me.gbFilterOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblYearStatus As System.Windows.Forms.Label
    Friend WithEvents lblOverallBalance As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayments As System.Windows.Forms.Label
    Friend WithEvents txtTotalPayments As System.Windows.Forms.TextBox
    Friend WithEvents txtOverallBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtYearStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDeposits As System.Windows.Forms.Label
    Friend WithEvents txtTotalDeposits As System.Windows.Forms.TextBox
    Friend WithEvents cxmnuWhatIf As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxmnuCreateExpense As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditExpense As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cxmnuResetYearTotals As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuRemoveCategories As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuRemoveExpenses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnResetYearTotals As System.Windows.Forms.Button
    Friend WithEvents btnCreateExpense As System.Windows.Forms.Button
    Friend WithEvents btnRemoveCategory As System.Windows.Forms.Button
    Friend WithEvents btnEditExpense As System.Windows.Forms.Button
    Friend WithEvents btnRemoveExpenses As System.Windows.Forms.Button
    Friend WithEvents dgvCategory As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents gbWhatif As System.Windows.Forms.GroupBox
    Friend WithEvents cbCategoriesPayees As System.Windows.Forms.ComboBox
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents January As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents February As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents March As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents April As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents May As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents June As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents July As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents August As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents September As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents October As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents November As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents December As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Totals As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Percent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFilterCategoriesPayees As System.Windows.Forms.Label
    Friend WithEvents dgvMonthly As System.Windows.Forms.DataGridView
    Friend WithEvents Month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deposits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monthly As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AveMonthlyIncome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblFilterPaymentsDeposits As System.Windows.Forms.Label
    Friend WithEvents cbPaymentsDeposits As System.Windows.Forms.ComboBox
    Friend WithEvents lblLedgerStatus As Label
    Friend WithEvents txtLedgerStatus As TextBox
    Friend WithEvents gbModelOptions As GroupBox
    Friend WithEvents rbCurrentYear As RadioButton
    Friend WithEvents rbNextYear As RadioButton
    Friend WithEvents gbCurrentYear As GroupBox
    Friend WithEvents gbOverallDetails As GroupBox
    Friend WithEvents gbFilterOptions As GroupBox
    Friend WithEvents btnCreateEmptyWhatif As Button
    Friend WithEvents cxmnuCreateEmptyScenario As ToolStripMenuItem
    Friend WithEvents cxmnuMonthlyIncomeTable As ContextMenuStrip
    Friend WithEvents cxmnuEditValues As ToolStripMenuItem
    Friend WithEvents cxmnuRemoveValues As ToolStripMenuItem
    Friend WithEvents cxmnuCopyToNextMonth As ToolStripMenuItem
    Friend WithEvents cxmnuCopyToRestOfYear As ToolStripMenuItem
    Friend WithEvents btnCopyToRestOfYear As Button
    Friend WithEvents btnCopyToNextMonth As Button
    Friend WithEvents btnCopyToSelectedMonths As Button
    Friend WithEvents cxmnuCopyToSelectedMonths As ToolStripMenuItem
End Class
