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
        Me.cxmnuScenario = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuCreateNewScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuSaveScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuOpenScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCloseScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cxmnuCreateExpense = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditExpense = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveExpenses = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyToNextMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyToRestOfYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyToSelectedMonths = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cxmnuResetSpendingOverview = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cxmnuSumSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.lblYearStatus = New System.Windows.Forms.Label()
        Me.lblTotalPayments = New System.Windows.Forms.Label()
        Me.txtCurrentYearPayments = New System.Windows.Forms.TextBox()
        Me.txtCurrentYearStatus = New System.Windows.Forms.TextBox()
        Me.lblTotalDeposits = New System.Windows.Forms.Label()
        Me.txtCurrentYearDeposits = New System.Windows.Forms.TextBox()
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
        Me.cbCategoriesPayees = New System.Windows.Forms.ComboBox()
        Me.lblFilterCategoriesPayees = New System.Windows.Forms.Label()
        Me.dgvMonthly = New System.Windows.Forms.DataGridView()
        Me.cxmnuMonthlyIncomeTable = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuEditValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblFilterPaymentsDeposits = New System.Windows.Forms.Label()
        Me.cbPaymentsDeposits = New System.Windows.Forms.ComboBox()
        Me.gbCurrentYear = New System.Windows.Forms.GroupBox()
        Me.gbFilterOptions = New System.Windows.Forms.GroupBox()
        Me.mnuMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMyScenarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateNewScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCreateExpense = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditExpense = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveExpenses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyToNextMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyToRestOfYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyToSelectedMonths = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSumSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCharts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuResetSpendingOverview = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportCategoryPayeeTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbOverallDetails = New System.Windows.Forms.GroupBox()
        Me.txtOverallTotalPayments = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOverallLedgerStatus = New System.Windows.Forms.TextBox()
        Me.txtOverallTotalDeposits = New System.Windows.Forms.TextBox()
        Me.lblLedgerStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOverallBalance = New System.Windows.Forms.TextBox()
        Me.lblOverallBalance = New System.Windows.Forms.Label()
        Me.lblModelingOption = New System.Windows.Forms.Label()
        Me.lblScenario = New System.Windows.Forms.Label()
        Me.cxmnuScenario.SuspendLayout()
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxmnuMonthlyIncomeTable.SuspendLayout()
        Me.gbCurrentYear.SuspendLayout()
        Me.gbFilterOptions.SuspendLayout()
        Me.mnuMenuStrip.SuspendLayout()
        Me.gbOverallDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'cxmnuScenario
        '
        Me.cxmnuScenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cxmnuScenario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuCreateNewScenario, Me.cxmnuSaveScenario, Me.cxmnuOpenScenario, Me.cxmnuCloseScenario, Me.ToolStripSeparator1, Me.cxmnuCreateExpense, Me.cxmnuEditExpense, Me.cxmnuRemoveExpenses, Me.cxmnuRemoveCategories, Me.cxmnuCopyToNextMonth, Me.cxmnuCopyToRestOfYear, Me.cxmnuCopyToSelectedMonths, Me.ToolStripSeparator5, Me.cxmnuResetSpendingOverview, Me.ToolStripSeparator4, Me.cxmnuSumSelected})
        Me.cxmnuScenario.Name = "cxmnuScenario"
        Me.cxmnuScenario.Size = New System.Drawing.Size(199, 330)
        '
        'cxmnuCreateNewScenario
        '
        Me.cxmnuCreateNewScenario.Image = CType(resources.GetObject("cxmnuCreateNewScenario.Image"), System.Drawing.Image)
        Me.cxmnuCreateNewScenario.Name = "cxmnuCreateNewScenario"
        Me.cxmnuCreateNewScenario.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuCreateNewScenario.Text = "Create New Scenario"
        '
        'cxmnuSaveScenario
        '
        Me.cxmnuSaveScenario.Image = CType(resources.GetObject("cxmnuSaveScenario.Image"), System.Drawing.Image)
        Me.cxmnuSaveScenario.Name = "cxmnuSaveScenario"
        Me.cxmnuSaveScenario.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuSaveScenario.Text = "Save Scenario"
        '
        'cxmnuOpenScenario
        '
        Me.cxmnuOpenScenario.Image = CType(resources.GetObject("cxmnuOpenScenario.Image"), System.Drawing.Image)
        Me.cxmnuOpenScenario.Name = "cxmnuOpenScenario"
        Me.cxmnuOpenScenario.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuOpenScenario.Text = "Open Scenario"
        '
        'cxmnuCloseScenario
        '
        Me.cxmnuCloseScenario.Image = CType(resources.GetObject("cxmnuCloseScenario.Image"), System.Drawing.Image)
        Me.cxmnuCloseScenario.Name = "cxmnuCloseScenario"
        Me.cxmnuCloseScenario.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuCloseScenario.Text = "Close Scenario"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(195, 6)
        '
        'cxmnuCreateExpense
        '
        Me.cxmnuCreateExpense.Image = CType(resources.GetObject("cxmnuCreateExpense.Image"), System.Drawing.Image)
        Me.cxmnuCreateExpense.Name = "cxmnuCreateExpense"
        Me.cxmnuCreateExpense.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuCreateExpense.Text = "Create Monthly Expense"
        '
        'cxmnuEditExpense
        '
        Me.cxmnuEditExpense.Image = CType(resources.GetObject("cxmnuEditExpense.Image"), System.Drawing.Image)
        Me.cxmnuEditExpense.Name = "cxmnuEditExpense"
        Me.cxmnuEditExpense.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuEditExpense.Text = "Edit Expenses"
        '
        'cxmnuRemoveExpenses
        '
        Me.cxmnuRemoveExpenses.Image = CType(resources.GetObject("cxmnuRemoveExpenses.Image"), System.Drawing.Image)
        Me.cxmnuRemoveExpenses.Name = "cxmnuRemoveExpenses"
        Me.cxmnuRemoveExpenses.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuRemoveExpenses.Text = "Remove Expenses"
        '
        'cxmnuRemoveCategories
        '
        Me.cxmnuRemoveCategories.Image = CType(resources.GetObject("cxmnuRemoveCategories.Image"), System.Drawing.Image)
        Me.cxmnuRemoveCategories.Name = "cxmnuRemoveCategories"
        Me.cxmnuRemoveCategories.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuRemoveCategories.Text = "Remove Categories"
        '
        'cxmnuCopyToNextMonth
        '
        Me.cxmnuCopyToNextMonth.Image = CType(resources.GetObject("cxmnuCopyToNextMonth.Image"), System.Drawing.Image)
        Me.cxmnuCopyToNextMonth.Name = "cxmnuCopyToNextMonth"
        Me.cxmnuCopyToNextMonth.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuCopyToNextMonth.Text = "Copy to Next Month"
        '
        'cxmnuCopyToRestOfYear
        '
        Me.cxmnuCopyToRestOfYear.Image = CType(resources.GetObject("cxmnuCopyToRestOfYear.Image"), System.Drawing.Image)
        Me.cxmnuCopyToRestOfYear.Name = "cxmnuCopyToRestOfYear"
        Me.cxmnuCopyToRestOfYear.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuCopyToRestOfYear.Text = "Copy to Rest of Year"
        '
        'cxmnuCopyToSelectedMonths
        '
        Me.cxmnuCopyToSelectedMonths.Image = CType(resources.GetObject("cxmnuCopyToSelectedMonths.Image"), System.Drawing.Image)
        Me.cxmnuCopyToSelectedMonths.Name = "cxmnuCopyToSelectedMonths"
        Me.cxmnuCopyToSelectedMonths.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuCopyToSelectedMonths.Text = "Copy To Selected Months"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(195, 6)
        '
        'cxmnuResetSpendingOverview
        '
        Me.cxmnuResetSpendingOverview.Image = CType(resources.GetObject("cxmnuResetSpendingOverview.Image"), System.Drawing.Image)
        Me.cxmnuResetSpendingOverview.Name = "cxmnuResetSpendingOverview"
        Me.cxmnuResetSpendingOverview.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuResetSpendingOverview.Text = "Reset Spending Overview"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(195, 6)
        '
        'cxmnuSumSelected
        '
        Me.cxmnuSumSelected.Image = Global.Checkbook.My.Resources.Resources.sum_selected
        Me.cxmnuSumSelected.Name = "cxmnuSumSelected"
        Me.cxmnuSumSelected.Size = New System.Drawing.Size(198, 22)
        Me.cxmnuSumSelected.Text = "Sum Selected"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(1140, 766)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(27, 21)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 1
        Me.lblYear.Text = "Year"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(27, 37)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(121, 21)
        Me.cbYear.TabIndex = 2
        '
        'lblYearStatus
        '
        Me.lblYearStatus.AutoSize = True
        Me.lblYearStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYearStatus.Location = New System.Drawing.Point(242, 21)
        Me.lblYearStatus.Name = "lblYearStatus"
        Me.lblYearStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblYearStatus.TabIndex = 4
        Me.lblYearStatus.Text = "Status"
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.AutoSize = True
        Me.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalPayments.Location = New System.Drawing.Point(27, 21)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Size = New System.Drawing.Size(53, 13)
        Me.lblTotalPayments.TabIndex = 0
        Me.lblTotalPayments.Text = "Payments"
        '
        'txtCurrentYearPayments
        '
        Me.txtCurrentYearPayments.Enabled = False
        Me.txtCurrentYearPayments.Location = New System.Drawing.Point(27, 37)
        Me.txtCurrentYearPayments.Name = "txtCurrentYearPayments"
        Me.txtCurrentYearPayments.ReadOnly = True
        Me.txtCurrentYearPayments.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentYearPayments.TabIndex = 1
        '
        'txtCurrentYearStatus
        '
        Me.txtCurrentYearStatus.Enabled = False
        Me.txtCurrentYearStatus.Location = New System.Drawing.Point(242, 37)
        Me.txtCurrentYearStatus.Name = "txtCurrentYearStatus"
        Me.txtCurrentYearStatus.ReadOnly = True
        Me.txtCurrentYearStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentYearStatus.TabIndex = 5
        '
        'lblTotalDeposits
        '
        Me.lblTotalDeposits.AutoSize = True
        Me.lblTotalDeposits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalDeposits.Location = New System.Drawing.Point(133, 21)
        Me.lblTotalDeposits.Name = "lblTotalDeposits"
        Me.lblTotalDeposits.Size = New System.Drawing.Size(48, 13)
        Me.lblTotalDeposits.TabIndex = 2
        Me.lblTotalDeposits.Text = "Deposits"
        '
        'txtCurrentYearDeposits
        '
        Me.txtCurrentYearDeposits.Enabled = False
        Me.txtCurrentYearDeposits.Location = New System.Drawing.Point(133, 37)
        Me.txtCurrentYearDeposits.Name = "txtCurrentYearDeposits"
        Me.txtCurrentYearDeposits.ReadOnly = True
        Me.txtCurrentYearDeposits.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentYearDeposits.TabIndex = 3
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
        Me.dgvCategory.ContextMenuStrip = Me.cxmnuScenario
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCategory.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCategory.GridColor = System.Drawing.Color.LightGray
        Me.dgvCategory.Location = New System.Drawing.Point(12, 38)
        Me.dgvCategory.Name = "dgvCategory"
        Me.dgvCategory.ReadOnly = True
        Me.dgvCategory.RowHeadersVisible = False
        Me.dgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCategory.Size = New System.Drawing.Size(1203, 451)
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
        'cbCategoriesPayees
        '
        Me.cbCategoriesPayees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoriesPayees.FormattingEnabled = True
        Me.cbCategoriesPayees.Items.AddRange(New Object() {"Categories", "Payees"})
        Me.cbCategoriesPayees.Location = New System.Drawing.Point(154, 37)
        Me.cbCategoriesPayees.Name = "cbCategoriesPayees"
        Me.cbCategoriesPayees.Size = New System.Drawing.Size(182, 21)
        Me.cbCategoriesPayees.TabIndex = 4
        '
        'lblFilterCategoriesPayees
        '
        Me.lblFilterCategoriesPayees.AutoSize = True
        Me.lblFilterCategoriesPayees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblFilterCategoriesPayees.Location = New System.Drawing.Point(154, 21)
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
        Me.dgvMonthly.Size = New System.Drawing.Size(580, 285)
        Me.dgvMonthly.TabIndex = 4
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
        Me.lblFilterPaymentsDeposits.Location = New System.Drawing.Point(342, 21)
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
        Me.cbPaymentsDeposits.Location = New System.Drawing.Point(342, 37)
        Me.cbPaymentsDeposits.Name = "cbPaymentsDeposits"
        Me.cbPaymentsDeposits.Size = New System.Drawing.Size(182, 21)
        Me.cbPaymentsDeposits.TabIndex = 6
        '
        'gbCurrentYear
        '
        Me.gbCurrentYear.Controls.Add(Me.txtCurrentYearPayments)
        Me.gbCurrentYear.Controls.Add(Me.lblTotalPayments)
        Me.gbCurrentYear.Controls.Add(Me.txtCurrentYearDeposits)
        Me.gbCurrentYear.Controls.Add(Me.lblTotalDeposits)
        Me.gbCurrentYear.Controls.Add(Me.txtCurrentYearStatus)
        Me.gbCurrentYear.Controls.Add(Me.lblYearStatus)
        Me.gbCurrentYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbCurrentYear.Location = New System.Drawing.Point(598, 674)
        Me.gbCurrentYear.Name = "gbCurrentYear"
        Me.gbCurrentYear.Size = New System.Drawing.Size(617, 79)
        Me.gbCurrentYear.TabIndex = 1
        Me.gbCurrentYear.TabStop = False
        Me.gbCurrentYear.Text = "Current Year Details"
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
        Me.gbFilterOptions.Location = New System.Drawing.Point(598, 504)
        Me.gbFilterOptions.Name = "gbFilterOptions"
        Me.gbFilterOptions.Size = New System.Drawing.Size(617, 79)
        Me.gbFilterOptions.TabIndex = 0
        Me.gbFilterOptions.TabStop = False
        Me.gbFilterOptions.Text = "Filter Options"
        '
        'mnuMenuStrip
        '
        Me.mnuMenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mnuMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.ToolStripMenuItem4})
        Me.mnuMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuMenuStrip.Name = "mnuMenuStrip"
        Me.mnuMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mnuMenuStrip.Size = New System.Drawing.Size(1227, 24)
        Me.mnuMenuStrip.TabIndex = 8
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMyScenarios, Me.mnuSaveScenario, Me.mnuOpenScenario, Me.mnuCloseScenario, Me.ToolStripSeparator6, Me.mnuClose})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuMyScenarios
        '
        Me.mnuMyScenarios.Image = CType(resources.GetObject("mnuMyScenarios.Image"), System.Drawing.Image)
        Me.mnuMyScenarios.Name = "mnuMyScenarios"
        Me.mnuMyScenarios.Size = New System.Drawing.Size(180, 22)
        Me.mnuMyScenarios.Text = "&My Scenarios"
        '
        'mnuSaveScenario
        '
        Me.mnuSaveScenario.Image = CType(resources.GetObject("mnuSaveScenario.Image"), System.Drawing.Image)
        Me.mnuSaveScenario.Name = "mnuSaveScenario"
        Me.mnuSaveScenario.Size = New System.Drawing.Size(180, 22)
        Me.mnuSaveScenario.Text = "&Save Scenario"
        '
        'mnuOpenScenario
        '
        Me.mnuOpenScenario.Image = CType(resources.GetObject("mnuOpenScenario.Image"), System.Drawing.Image)
        Me.mnuOpenScenario.Name = "mnuOpenScenario"
        Me.mnuOpenScenario.Size = New System.Drawing.Size(180, 22)
        Me.mnuOpenScenario.Text = "&Open Scenario"
        '
        'mnuCloseScenario
        '
        Me.mnuCloseScenario.Image = CType(resources.GetObject("mnuCloseScenario.Image"), System.Drawing.Image)
        Me.mnuCloseScenario.Name = "mnuCloseScenario"
        Me.mnuCloseScenario.Size = New System.Drawing.Size(180, 22)
        Me.mnuCloseScenario.Text = "Clo&se Scenario"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(177, 6)
        '
        'mnuClose
        '
        Me.mnuClose.Image = CType(resources.GetObject("mnuClose.Image"), System.Drawing.Image)
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(180, 22)
        Me.mnuClose.Text = "&Close"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCreateNewScenario, Me.ToolStripSeparator2, Me.mnuCreateExpense, Me.mnuEditExpense, Me.mnuRemoveExpenses, Me.mnuRemoveCategory, Me.mnuCopyToNextMonth, Me.mnuCopyToRestOfYear, Me.mnuCopyToSelectedMonths, Me.ToolStripSeparator3, Me.mnuSumSelected})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuCreateNewScenario
        '
        Me.mnuCreateNewScenario.Image = CType(resources.GetObject("mnuCreateNewScenario.Image"), System.Drawing.Image)
        Me.mnuCreateNewScenario.Name = "mnuCreateNewScenario"
        Me.mnuCreateNewScenario.Size = New System.Drawing.Size(193, 22)
        Me.mnuCreateNewScenario.Text = "Create New &Scenario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(190, 6)
        '
        'mnuCreateExpense
        '
        Me.mnuCreateExpense.Image = CType(resources.GetObject("mnuCreateExpense.Image"), System.Drawing.Image)
        Me.mnuCreateExpense.Name = "mnuCreateExpense"
        Me.mnuCreateExpense.Size = New System.Drawing.Size(193, 22)
        Me.mnuCreateExpense.Text = "&Create Monthly Expense"
        '
        'mnuEditExpense
        '
        Me.mnuEditExpense.Image = CType(resources.GetObject("mnuEditExpense.Image"), System.Drawing.Image)
        Me.mnuEditExpense.Name = "mnuEditExpense"
        Me.mnuEditExpense.Size = New System.Drawing.Size(193, 22)
        Me.mnuEditExpense.Text = "&Edit Expenses"
        '
        'mnuRemoveExpenses
        '
        Me.mnuRemoveExpenses.Image = CType(resources.GetObject("mnuRemoveExpenses.Image"), System.Drawing.Image)
        Me.mnuRemoveExpenses.Name = "mnuRemoveExpenses"
        Me.mnuRemoveExpenses.Size = New System.Drawing.Size(193, 22)
        Me.mnuRemoveExpenses.Text = "&Remove Expenses"
        '
        'mnuRemoveCategory
        '
        Me.mnuRemoveCategory.Image = CType(resources.GetObject("mnuRemoveCategory.Image"), System.Drawing.Image)
        Me.mnuRemoveCategory.Name = "mnuRemoveCategory"
        Me.mnuRemoveCategory.Size = New System.Drawing.Size(193, 22)
        Me.mnuRemoveCategory.Text = "Remo&ve Categories"
        '
        'mnuCopyToNextMonth
        '
        Me.mnuCopyToNextMonth.Image = CType(resources.GetObject("mnuCopyToNextMonth.Image"), System.Drawing.Image)
        Me.mnuCopyToNextMonth.Name = "mnuCopyToNextMonth"
        Me.mnuCopyToNextMonth.Size = New System.Drawing.Size(193, 22)
        Me.mnuCopyToNextMonth.Text = "Copy to &Next Month"
        '
        'mnuCopyToRestOfYear
        '
        Me.mnuCopyToRestOfYear.Image = CType(resources.GetObject("mnuCopyToRestOfYear.Image"), System.Drawing.Image)
        Me.mnuCopyToRestOfYear.Name = "mnuCopyToRestOfYear"
        Me.mnuCopyToRestOfYear.Size = New System.Drawing.Size(193, 22)
        Me.mnuCopyToRestOfYear.Text = "Copy to Rest of &Year"
        '
        'mnuCopyToSelectedMonths
        '
        Me.mnuCopyToSelectedMonths.Image = CType(resources.GetObject("mnuCopyToSelectedMonths.Image"), System.Drawing.Image)
        Me.mnuCopyToSelectedMonths.Name = "mnuCopyToSelectedMonths"
        Me.mnuCopyToSelectedMonths.Size = New System.Drawing.Size(193, 22)
        Me.mnuCopyToSelectedMonths.Text = "Copy to Selected &Months"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(190, 6)
        '
        'mnuSumSelected
        '
        Me.mnuSumSelected.Image = Global.Checkbook.My.Resources.Resources.sum_selected
        Me.mnuSumSelected.Name = "mnuSumSelected"
        Me.mnuSumSelected.Size = New System.Drawing.Size(193, 22)
        Me.mnuSumSelected.Text = "Sum Selected"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCharts, Me.mnuResetSpendingOverview})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(42, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuCharts
        '
        Me.mnuCharts.Image = CType(resources.GetObject("mnuCharts.Image"), System.Drawing.Image)
        Me.mnuCharts.Name = "mnuCharts"
        Me.mnuCharts.Size = New System.Drawing.Size(200, 22)
        Me.mnuCharts.Text = "Spending Overview &Charts"
        '
        'mnuResetSpendingOverview
        '
        Me.mnuResetSpendingOverview.Image = CType(resources.GetObject("mnuResetSpendingOverview.Image"), System.Drawing.Image)
        Me.mnuResetSpendingOverview.Name = "mnuResetSpendingOverview"
        Me.mnuResetSpendingOverview.Size = New System.Drawing.Size(200, 22)
        Me.mnuResetSpendingOverview.Text = "&Reset Spending Overview"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportCategoryPayeeTable})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(45, 20)
        Me.ToolStripMenuItem4.Text = "&Tools"
        '
        'mnuExportCategoryPayeeTable
        '
        Me.mnuExportCategoryPayeeTable.Image = CType(resources.GetObject("mnuExportCategoryPayeeTable.Image"), System.Drawing.Image)
        Me.mnuExportCategoryPayeeTable.Name = "mnuExportCategoryPayeeTable"
        Me.mnuExportCategoryPayeeTable.Size = New System.Drawing.Size(235, 22)
        Me.mnuExportCategoryPayeeTable.Text = "&Export Spending Overview Tables"
        '
        'gbOverallDetails
        '
        Me.gbOverallDetails.Controls.Add(Me.txtOverallTotalPayments)
        Me.gbOverallDetails.Controls.Add(Me.Label1)
        Me.gbOverallDetails.Controls.Add(Me.txtOverallLedgerStatus)
        Me.gbOverallDetails.Controls.Add(Me.txtOverallTotalDeposits)
        Me.gbOverallDetails.Controls.Add(Me.lblLedgerStatus)
        Me.gbOverallDetails.Controls.Add(Me.Label2)
        Me.gbOverallDetails.Controls.Add(Me.txtOverallBalance)
        Me.gbOverallDetails.Controls.Add(Me.lblOverallBalance)
        Me.gbOverallDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbOverallDetails.Location = New System.Drawing.Point(598, 589)
        Me.gbOverallDetails.Name = "gbOverallDetails"
        Me.gbOverallDetails.Size = New System.Drawing.Size(617, 79)
        Me.gbOverallDetails.TabIndex = 4
        Me.gbOverallDetails.TabStop = False
        Me.gbOverallDetails.Text = "Overall Account Details"
        '
        'txtOverallTotalPayments
        '
        Me.txtOverallTotalPayments.Enabled = False
        Me.txtOverallTotalPayments.Location = New System.Drawing.Point(27, 37)
        Me.txtOverallTotalPayments.Name = "txtOverallTotalPayments"
        Me.txtOverallTotalPayments.ReadOnly = True
        Me.txtOverallTotalPayments.Size = New System.Drawing.Size(100, 20)
        Me.txtOverallTotalPayments.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(27, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Total Payments"
        '
        'txtOverallLedgerStatus
        '
        Me.txtOverallLedgerStatus.Enabled = False
        Me.txtOverallLedgerStatus.Location = New System.Drawing.Point(345, 37)
        Me.txtOverallLedgerStatus.Name = "txtOverallLedgerStatus"
        Me.txtOverallLedgerStatus.ReadOnly = True
        Me.txtOverallLedgerStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtOverallLedgerStatus.TabIndex = 3
        '
        'txtOverallTotalDeposits
        '
        Me.txtOverallTotalDeposits.Enabled = False
        Me.txtOverallTotalDeposits.Location = New System.Drawing.Point(133, 37)
        Me.txtOverallTotalDeposits.Name = "txtOverallTotalDeposits"
        Me.txtOverallTotalDeposits.ReadOnly = True
        Me.txtOverallTotalDeposits.Size = New System.Drawing.Size(100, 20)
        Me.txtOverallTotalDeposits.TabIndex = 9
        '
        'lblLedgerStatus
        '
        Me.lblLedgerStatus.AutoSize = True
        Me.lblLedgerStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblLedgerStatus.Location = New System.Drawing.Point(345, 21)
        Me.lblLedgerStatus.Name = "lblLedgerStatus"
        Me.lblLedgerStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblLedgerStatus.TabIndex = 2
        Me.lblLedgerStatus.Text = "Ledger Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(133, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Total Deposits"
        '
        'txtOverallBalance
        '
        Me.txtOverallBalance.Enabled = False
        Me.txtOverallBalance.Location = New System.Drawing.Point(239, 37)
        Me.txtOverallBalance.Name = "txtOverallBalance"
        Me.txtOverallBalance.ReadOnly = True
        Me.txtOverallBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtOverallBalance.TabIndex = 1
        '
        'lblOverallBalance
        '
        Me.lblOverallBalance.AutoSize = True
        Me.lblOverallBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblOverallBalance.Location = New System.Drawing.Point(239, 21)
        Me.lblOverallBalance.Name = "lblOverallBalance"
        Me.lblOverallBalance.Size = New System.Drawing.Size(82, 13)
        Me.lblOverallBalance.TabIndex = 0
        Me.lblOverallBalance.Text = "Overall Balance"
        '
        'lblModelingOption
        '
        Me.lblModelingOption.AutoSize = True
        Me.lblModelingOption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblModelingOption.Location = New System.Drawing.Point(598, 776)
        Me.lblModelingOption.Name = "lblModelingOption"
        Me.lblModelingOption.Size = New System.Drawing.Size(87, 13)
        Me.lblModelingOption.TabIndex = 9
        Me.lblModelingOption.Text = "Modeling Option:"
        '
        'lblScenario
        '
        Me.lblScenario.AutoSize = True
        Me.lblScenario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblScenario.Location = New System.Drawing.Point(598, 756)
        Me.lblScenario.Name = "lblScenario"
        Me.lblScenario.Size = New System.Drawing.Size(52, 13)
        Me.lblScenario.TabIndex = 9
        Me.lblScenario.Text = "Scenario:"
        '
        'frmSpendingOverview
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1227, 801)
        Me.Controls.Add(Me.lblScenario)
        Me.Controls.Add(Me.lblModelingOption)
        Me.Controls.Add(Me.dgvCategory)
        Me.Controls.Add(Me.gbOverallDetails)
        Me.Controls.Add(Me.mnuMenuStrip)
        Me.Controls.Add(Me.gbFilterOptions)
        Me.Controls.Add(Me.gbCurrentYear)
        Me.Controls.Add(Me.dgvMonthly)
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
        Me.cxmnuScenario.ResumeLayout(False)
        CType(Me.dgvCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxmnuMonthlyIncomeTable.ResumeLayout(False)
        Me.gbCurrentYear.ResumeLayout(False)
        Me.gbCurrentYear.PerformLayout()
        Me.gbFilterOptions.ResumeLayout(False)
        Me.gbFilterOptions.PerformLayout()
        Me.mnuMenuStrip.ResumeLayout(False)
        Me.mnuMenuStrip.PerformLayout()
        Me.gbOverallDetails.ResumeLayout(False)
        Me.gbOverallDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblYearStatus As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayments As System.Windows.Forms.Label
    Friend WithEvents txtCurrentYearPayments As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentYearStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDeposits As System.Windows.Forms.Label
    Friend WithEvents txtCurrentYearDeposits As System.Windows.Forms.TextBox
    Friend WithEvents cxmnuScenario As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxmnuCreateExpense As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditExpense As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cxmnuResetSpendingOverview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuRemoveCategories As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuRemoveExpenses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvCategory As System.Windows.Forms.DataGridView
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
    Friend WithEvents lblFilterPaymentsDeposits As System.Windows.Forms.Label
    Friend WithEvents cbPaymentsDeposits As System.Windows.Forms.ComboBox
    Friend WithEvents gbCurrentYear As GroupBox
    Friend WithEvents gbFilterOptions As GroupBox
    Friend WithEvents cxmnuCreateNewScenario As ToolStripMenuItem
    Friend WithEvents cxmnuMonthlyIncomeTable As ContextMenuStrip
    Friend WithEvents cxmnuEditValues As ToolStripMenuItem
    Friend WithEvents cxmnuRemoveValues As ToolStripMenuItem
    Friend WithEvents cxmnuCopyToNextMonth As ToolStripMenuItem
    Friend WithEvents cxmnuCopyToRestOfYear As ToolStripMenuItem
    Friend WithEvents cxmnuCopyToSelectedMonths As ToolStripMenuItem
    Friend WithEvents mnuMenuStrip As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuSaveScenario As ToolStripMenuItem
    Friend WithEvents mnuMyScenarios As ToolStripMenuItem
    Friend WithEvents mnuClose As ToolStripMenuItem
    Friend WithEvents mnuEdit As ToolStripMenuItem
    Friend WithEvents mnuView As ToolStripMenuItem
    Friend WithEvents mnuCreateExpense As ToolStripMenuItem
    Friend WithEvents mnuEditExpense As ToolStripMenuItem
    Friend WithEvents mnuRemoveExpenses As ToolStripMenuItem
    Friend WithEvents mnuRemoveCategory As ToolStripMenuItem
    Friend WithEvents mnuCopyToNextMonth As ToolStripMenuItem
    Friend WithEvents mnuCopyToSelectedMonths As ToolStripMenuItem
    Friend WithEvents mnuCopyToRestOfYear As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuCreateNewScenario As ToolStripMenuItem
    Friend WithEvents mnuCharts As ToolStripMenuItem
    Friend WithEvents mnuResetSpendingOverview As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents mnuExportCategoryPayeeTable As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents mnuSumSelected As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents cxmnuSumSelected As ToolStripMenuItem
    Friend WithEvents gbOverallDetails As GroupBox
    Friend WithEvents txtOverallBalance As TextBox
    Friend WithEvents lblOverallBalance As Label
    Friend WithEvents lblLedgerStatus As Label
    Friend WithEvents txtOverallLedgerStatus As TextBox
    Friend WithEvents txtOverallTotalPayments As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOverallTotalDeposits As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents lblModelingOption As Label
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents lblScenario As Label
    Friend WithEvents mnuCloseScenario As ToolStripMenuItem
    Friend WithEvents cxmnuSaveScenario As ToolStripMenuItem
    Friend WithEvents cxmnuOpenScenario As ToolStripMenuItem
    Friend WithEvents cxmnuCloseScenario As ToolStripMenuItem
    Friend WithEvents mnuOpenScenario As ToolStripMenuItem
End Class
