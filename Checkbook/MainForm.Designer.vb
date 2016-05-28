<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mnuMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNewTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditType = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditTransDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditDeposit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPayee = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUnclearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditStartingBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPayees = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSpendingOverview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMonthlyIncome = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBudgets = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUnCatUnknownMessage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLedgerManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBalanceAccount = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsToolMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLoanCalculator = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCalc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCheckforUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCheckbookHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvLedger = New System.Windows.Forms.DataGridView()
        Me.cxmnuDataGridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuNewTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuDeleteTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditType = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditTransDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditDeposit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditPayee = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuClearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuUnclearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuViewReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuSumSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cxmnuResetDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtLedgerStatus = New System.Windows.Forms.TextBox()
        Me.txtOverallBalance = New System.Windows.Forms.TextBox()
        Me.txtTotalDeposits = New System.Windows.Forms.TextBox()
        Me.txtTotalPayments = New System.Windows.Forms.TextBox()
        Me.lblStartingBalance = New System.Windows.Forms.Label()
        Me.lblTotalPayments = New System.Windows.Forms.Label()
        Me.lblTotalDeposits = New System.Windows.Forms.Label()
        Me.lblOverallBalance = New System.Windows.Forms.Label()
        Me.lblLedgerStatus = New System.Windows.Forms.Label()
        Me.tsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNewTrans = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteTrans = New System.Windows.Forms.ToolStripButton()
        Me.btnEditTrans = New System.Windows.Forms.ToolStripButton()
        Me.btnClearSelected = New System.Windows.Forms.ToolStripButton()
        Me.btnUnclearSelected = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCategories = New System.Windows.Forms.ToolStripButton()
        Me.btnPayees = New System.Windows.Forms.ToolStripButton()
        Me.btnViewReceipt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSumSelected = New System.Windows.Forms.ToolStripButton()
        Me.btnFilter = New System.Windows.Forms.ToolStripButton()
        Me.btnBalanceAccount = New System.Windows.Forms.ToolStripButton()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.lblCleared = New System.Windows.Forms.Label()
        Me.txtClearedBalance = New System.Windows.Forms.TextBox()
        Me.sfdSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.stStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.DownloadUpdateProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.DownloadUpdateLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.txtStartingBalance = New System.Windows.Forms.TextBox()
        Me.tmrFilterTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.gbAccountDetails = New System.Windows.Forms.GroupBox()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.mnuMenuStrip.SuspendLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxmnuDataGridMenu.SuspendLayout()
        Me.tsToolStrip.SuspendLayout()
        Me.stStatusStrip.SuspendLayout()
        Me.gbAccountDetails.SuspendLayout()
        Me.gbFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMenuStrip
        '
        Me.mnuMenuStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mnuMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuTools, Me.mnuHelp})
        Me.mnuMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuMenuStrip.Name = "mnuMenuStrip"
        Me.mnuMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.mnuMenuStrip.Size = New System.Drawing.Size(1084, 24)
        Me.mnuMenuStrip.TabIndex = 5
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuOpen, Me.mnuSaveAs, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile.Text = "File"
        '
        'mnuNew
        '
        Me.mnuNew.Image = CType(resources.GetObject("mnuNew.Image"), System.Drawing.Image)
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(145, 22)
        Me.mnuNew.Text = "New Ledger..."
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = CType(resources.GetObject("mnuOpen.Image"), System.Drawing.Image)
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(145, 22)
        Me.mnuOpen.Text = "Open Ledger..."
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Image = CType(resources.GetObject("mnuSaveAs.Image"), System.Drawing.Image)
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(145, 22)
        Me.mnuSaveAs.Text = "Save As..."
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(145, 22)
        Me.mnuExit.Text = "Exit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewTrans, Me.mnuDeleteTrans, Me.mnuEditTrans, Me.mnuClearSelected, Me.mnuUnclearSelected, Me.ToolStripSeparator3, Me.mnuEditStartingBalance})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.mnuEdit.Text = "Edit"
        '
        'mnuNewTrans
        '
        Me.mnuNewTrans.Image = CType(resources.GetObject("mnuNewTrans.Image"), System.Drawing.Image)
        Me.mnuNewTrans.Name = "mnuNewTrans"
        Me.mnuNewTrans.Size = New System.Drawing.Size(175, 22)
        Me.mnuNewTrans.Text = "New Transaction..."
        '
        'mnuDeleteTrans
        '
        Me.mnuDeleteTrans.Image = CType(resources.GetObject("mnuDeleteTrans.Image"), System.Drawing.Image)
        Me.mnuDeleteTrans.Name = "mnuDeleteTrans"
        Me.mnuDeleteTrans.Size = New System.Drawing.Size(175, 22)
        Me.mnuDeleteTrans.Text = "Delete Transaction(s)"
        '
        'mnuEditTrans
        '
        Me.mnuEditTrans.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditType, Me.mnuEditCategory, Me.mnuEditTransDate, Me.mnuEditPayment, Me.mnuEditDeposit, Me.mnuEditPayee})
        Me.mnuEditTrans.Image = CType(resources.GetObject("mnuEditTrans.Image"), System.Drawing.Image)
        Me.mnuEditTrans.Name = "mnuEditTrans"
        Me.mnuEditTrans.Size = New System.Drawing.Size(175, 22)
        Me.mnuEditTrans.Text = "Edit Transaction(s)..."
        '
        'mnuEditType
        '
        Me.mnuEditType.Image = CType(resources.GetObject("mnuEditType.Image"), System.Drawing.Image)
        Me.mnuEditType.Name = "mnuEditType"
        Me.mnuEditType.Size = New System.Drawing.Size(125, 22)
        Me.mnuEditType.Text = "Type..."
        '
        'mnuEditCategory
        '
        Me.mnuEditCategory.Image = CType(resources.GetObject("mnuEditCategory.Image"), System.Drawing.Image)
        Me.mnuEditCategory.Name = "mnuEditCategory"
        Me.mnuEditCategory.Size = New System.Drawing.Size(125, 22)
        Me.mnuEditCategory.Text = "Ca&tegory..."
        '
        'mnuEditTransDate
        '
        Me.mnuEditTransDate.Image = CType(resources.GetObject("mnuEditTransDate.Image"), System.Drawing.Image)
        Me.mnuEditTransDate.Name = "mnuEditTransDate"
        Me.mnuEditTransDate.Size = New System.Drawing.Size(125, 22)
        Me.mnuEditTransDate.Text = "Date..."
        '
        'mnuEditPayment
        '
        Me.mnuEditPayment.Image = CType(resources.GetObject("mnuEditPayment.Image"), System.Drawing.Image)
        Me.mnuEditPayment.Name = "mnuEditPayment"
        Me.mnuEditPayment.Size = New System.Drawing.Size(125, 22)
        Me.mnuEditPayment.Text = "&Payment..."
        '
        'mnuEditDeposit
        '
        Me.mnuEditDeposit.Image = CType(resources.GetObject("mnuEditDeposit.Image"), System.Drawing.Image)
        Me.mnuEditDeposit.Name = "mnuEditDeposit"
        Me.mnuEditDeposit.Size = New System.Drawing.Size(125, 22)
        Me.mnuEditDeposit.Text = "&Deposit..."
        '
        'mnuEditPayee
        '
        Me.mnuEditPayee.Image = CType(resources.GetObject("mnuEditPayee.Image"), System.Drawing.Image)
        Me.mnuEditPayee.Name = "mnuEditPayee"
        Me.mnuEditPayee.Size = New System.Drawing.Size(125, 22)
        Me.mnuEditPayee.Text = "Pa&yee..."
        '
        'mnuClearSelected
        '
        Me.mnuClearSelected.Image = CType(resources.GetObject("mnuClearSelected.Image"), System.Drawing.Image)
        Me.mnuClearSelected.Name = "mnuClearSelected"
        Me.mnuClearSelected.Size = New System.Drawing.Size(175, 22)
        Me.mnuClearSelected.Text = "Clear"
        '
        'mnuUnclearSelected
        '
        Me.mnuUnclearSelected.Image = CType(resources.GetObject("mnuUnclearSelected.Image"), System.Drawing.Image)
        Me.mnuUnclearSelected.Name = "mnuUnclearSelected"
        Me.mnuUnclearSelected.Size = New System.Drawing.Size(175, 22)
        Me.mnuUnclearSelected.Text = "Unclear"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(172, 6)
        '
        'mnuEditStartingBalance
        '
        Me.mnuEditStartingBalance.Image = CType(resources.GetObject("mnuEditStartingBalance.Image"), System.Drawing.Image)
        Me.mnuEditStartingBalance.Name = "mnuEditStartingBalance"
        Me.mnuEditStartingBalance.Size = New System.Drawing.Size(175, 22)
        Me.mnuEditStartingBalance.Text = "Edit Starting Balance"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCategories, Me.mnuPayees, Me.mnuViewReceipt, Me.ToolStripSeparator4, Me.mnuSpendingOverview, Me.mnuMonthlyIncome, Me.mnuBudgets, Me.ToolStripSeparator7, Me.mnuUnCatUnknownMessage})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(42, 20)
        Me.mnuView.Text = "View"
        '
        'mnuCategories
        '
        Me.mnuCategories.Image = CType(resources.GetObject("mnuCategories.Image"), System.Drawing.Image)
        Me.mnuCategories.Name = "mnuCategories"
        Me.mnuCategories.Size = New System.Drawing.Size(194, 22)
        Me.mnuCategories.Text = "Categories..."
        '
        'mnuPayees
        '
        Me.mnuPayees.Image = CType(resources.GetObject("mnuPayees.Image"), System.Drawing.Image)
        Me.mnuPayees.Name = "mnuPayees"
        Me.mnuPayees.Size = New System.Drawing.Size(194, 22)
        Me.mnuPayees.Text = "Payees..."
        '
        'mnuViewReceipt
        '
        Me.mnuViewReceipt.Image = CType(resources.GetObject("mnuViewReceipt.Image"), System.Drawing.Image)
        Me.mnuViewReceipt.Name = "mnuViewReceipt"
        Me.mnuViewReceipt.Size = New System.Drawing.Size(194, 22)
        Me.mnuViewReceipt.Text = "View Receipt"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(191, 6)
        '
        'mnuSpendingOverview
        '
        Me.mnuSpendingOverview.Image = CType(resources.GetObject("mnuSpendingOverview.Image"), System.Drawing.Image)
        Me.mnuSpendingOverview.Name = "mnuSpendingOverview"
        Me.mnuSpendingOverview.Size = New System.Drawing.Size(194, 22)
        Me.mnuSpendingOverview.Text = "Spending Overview"
        '
        'mnuMonthlyIncome
        '
        Me.mnuMonthlyIncome.Image = CType(resources.GetObject("mnuMonthlyIncome.Image"), System.Drawing.Image)
        Me.mnuMonthlyIncome.Name = "mnuMonthlyIncome"
        Me.mnuMonthlyIncome.Size = New System.Drawing.Size(194, 22)
        Me.mnuMonthlyIncome.Text = "Monthly Income"
        '
        'mnuBudgets
        '
        Me.mnuBudgets.Image = CType(resources.GetObject("mnuBudgets.Image"), System.Drawing.Image)
        Me.mnuBudgets.Name = "mnuBudgets"
        Me.mnuBudgets.Size = New System.Drawing.Size(194, 22)
        Me.mnuBudgets.Text = "Budgets"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(191, 6)
        '
        'mnuUnCatUnknownMessage
        '
        Me.mnuUnCatUnknownMessage.Image = CType(resources.GetObject("mnuUnCatUnknownMessage.Image"), System.Drawing.Image)
        Me.mnuUnCatUnknownMessage.Name = "mnuUnCatUnknownMessage"
        Me.mnuUnCatUnknownMessage.Size = New System.Drawing.Size(194, 22)
        Me.mnuUnCatUnknownMessage.Text = "Unknown/Uncategorized"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSum, Me.mnuFilter, Me.mnuLedgerManager, Me.mnuOptions, Me.mnuImportTrans, Me.mnuBalanceAccount, Me.tsToolMenuSeparator1, Me.mnuLoanCalculator, Me.mnuCalc, Me.ToolStripSeparator8, Me.mnuCheckforUpdate})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(45, 20)
        Me.mnuTools.Text = "Tools"
        '
        'mnuSum
        '
        Me.mnuSum.Image = CType(resources.GetObject("mnuSum.Image"), System.Drawing.Image)
        Me.mnuSum.Name = "mnuSum"
        Me.mnuSum.Size = New System.Drawing.Size(168, 22)
        Me.mnuSum.Text = "Sum Selected"
        '
        'mnuFilter
        '
        Me.mnuFilter.Image = CType(resources.GetObject("mnuFilter.Image"), System.Drawing.Image)
        Me.mnuFilter.Name = "mnuFilter"
        Me.mnuFilter.Size = New System.Drawing.Size(168, 22)
        Me.mnuFilter.Text = "Filter"
        '
        'mnuLedgerManager
        '
        Me.mnuLedgerManager.Image = CType(resources.GetObject("mnuLedgerManager.Image"), System.Drawing.Image)
        Me.mnuLedgerManager.Name = "mnuLedgerManager"
        Me.mnuLedgerManager.Size = New System.Drawing.Size(168, 22)
        Me.mnuLedgerManager.Text = "Ledger Manager"
        '
        'mnuOptions
        '
        Me.mnuOptions.Image = CType(resources.GetObject("mnuOptions.Image"), System.Drawing.Image)
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(168, 22)
        Me.mnuOptions.Text = "Options"
        '
        'mnuImportTrans
        '
        Me.mnuImportTrans.Image = CType(resources.GetObject("mnuImportTrans.Image"), System.Drawing.Image)
        Me.mnuImportTrans.Name = "mnuImportTrans"
        Me.mnuImportTrans.Size = New System.Drawing.Size(168, 22)
        Me.mnuImportTrans.Text = "Import Transactions"
        '
        'mnuBalanceAccount
        '
        Me.mnuBalanceAccount.Image = CType(resources.GetObject("mnuBalanceAccount.Image"), System.Drawing.Image)
        Me.mnuBalanceAccount.Name = "mnuBalanceAccount"
        Me.mnuBalanceAccount.Size = New System.Drawing.Size(168, 22)
        Me.mnuBalanceAccount.Text = "Balance Account"
        '
        'tsToolMenuSeparator1
        '
        Me.tsToolMenuSeparator1.Name = "tsToolMenuSeparator1"
        Me.tsToolMenuSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'mnuLoanCalculator
        '
        Me.mnuLoanCalculator.Image = CType(resources.GetObject("mnuLoanCalculator.Image"), System.Drawing.Image)
        Me.mnuLoanCalculator.Name = "mnuLoanCalculator"
        Me.mnuLoanCalculator.Size = New System.Drawing.Size(168, 22)
        Me.mnuLoanCalculator.Text = "Loan Calculator"
        '
        'mnuCalc
        '
        Me.mnuCalc.Image = CType(resources.GetObject("mnuCalc.Image"), System.Drawing.Image)
        Me.mnuCalc.Name = "mnuCalc"
        Me.mnuCalc.Size = New System.Drawing.Size(168, 22)
        Me.mnuCalc.Text = "Windows Calculator"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(165, 6)
        '
        'mnuCheckforUpdate
        '
        Me.mnuCheckforUpdate.Image = CType(resources.GetObject("mnuCheckforUpdate.Image"), System.Drawing.Image)
        Me.mnuCheckforUpdate.Name = "mnuCheckforUpdate"
        Me.mnuCheckforUpdate.Size = New System.Drawing.Size(168, 22)
        Me.mnuCheckforUpdate.Text = "Check for Update"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCheckbookHelp, Me.mnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(41, 20)
        Me.mnuHelp.Text = "Help"
        '
        'mnuCheckbookHelp
        '
        Me.mnuCheckbookHelp.Image = CType(resources.GetObject("mnuCheckbookHelp.Image"), System.Drawing.Image)
        Me.mnuCheckbookHelp.Name = "mnuCheckbookHelp"
        Me.mnuCheckbookHelp.Size = New System.Drawing.Size(160, 22)
        Me.mnuCheckbookHelp.Text = "Checkbook Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Image = CType(resources.GetObject("mnuAbout.Image"), System.Drawing.Image)
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(160, 22)
        Me.mnuAbout.Text = "About Checkbook"
        '
        'dgvLedger
        '
        Me.dgvLedger.AllowUserToAddRows = False
        Me.dgvLedger.AllowUserToDeleteRows = False
        Me.dgvLedger.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvLedger.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLedger.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLedger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLedger.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvLedger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLedger.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLedger.ContextMenuStrip = Me.cxmnuDataGridMenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLedger.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLedger.GridColor = System.Drawing.Color.LightGray
        Me.dgvLedger.Location = New System.Drawing.Point(12, 137)
        Me.dgvLedger.Name = "dgvLedger"
        Me.dgvLedger.ReadOnly = True
        Me.dgvLedger.RowHeadersVisible = False
        Me.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLedger.Size = New System.Drawing.Size(1060, 599)
        Me.dgvLedger.TabIndex = 0
        '
        'cxmnuDataGridMenu
        '
        Me.cxmnuDataGridMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cxmnuDataGridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuNewTrans, Me.cxmnuDeleteTrans, Me.cxmnuEditTrans, Me.cxmnuClearSelected, Me.cxmnuUnclearSelected, Me.cxmnuViewReceipt, Me.cxmnuSumSelected, Me.ToolStripSeparator5, Me.cxmnuResetDefault})
        Me.cxmnuDataGridMenu.Name = "cxmnuDataGridMenu"
        Me.cxmnuDataGridMenu.Size = New System.Drawing.Size(183, 186)
        '
        'cxmnuNewTrans
        '
        Me.cxmnuNewTrans.Image = CType(resources.GetObject("cxmnuNewTrans.Image"), System.Drawing.Image)
        Me.cxmnuNewTrans.Name = "cxmnuNewTrans"
        Me.cxmnuNewTrans.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuNewTrans.Text = "New Transaction..."
        '
        'cxmnuDeleteTrans
        '
        Me.cxmnuDeleteTrans.Image = CType(resources.GetObject("cxmnuDeleteTrans.Image"), System.Drawing.Image)
        Me.cxmnuDeleteTrans.Name = "cxmnuDeleteTrans"
        Me.cxmnuDeleteTrans.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuDeleteTrans.Text = "Delete Transaction(s)"
        '
        'cxmnuEditTrans
        '
        Me.cxmnuEditTrans.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuEditType, Me.cxmnuEditCategory, Me.cxmnuEditTransDate, Me.cxmnuEditPayment, Me.cxmnuEditDeposit, Me.cxmnuEditPayee})
        Me.cxmnuEditTrans.Image = CType(resources.GetObject("cxmnuEditTrans.Image"), System.Drawing.Image)
        Me.cxmnuEditTrans.Name = "cxmnuEditTrans"
        Me.cxmnuEditTrans.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuEditTrans.Text = "Edit Transaction(s)..."
        '
        'cxmnuEditType
        '
        Me.cxmnuEditType.Image = CType(resources.GetObject("cxmnuEditType.Image"), System.Drawing.Image)
        Me.cxmnuEditType.Name = "cxmnuEditType"
        Me.cxmnuEditType.Size = New System.Drawing.Size(125, 22)
        Me.cxmnuEditType.Text = "Type..."
        '
        'cxmnuEditCategory
        '
        Me.cxmnuEditCategory.Image = CType(resources.GetObject("cxmnuEditCategory.Image"), System.Drawing.Image)
        Me.cxmnuEditCategory.Name = "cxmnuEditCategory"
        Me.cxmnuEditCategory.Size = New System.Drawing.Size(125, 22)
        Me.cxmnuEditCategory.Text = "Category..."
        '
        'cxmnuEditTransDate
        '
        Me.cxmnuEditTransDate.Image = CType(resources.GetObject("cxmnuEditTransDate.Image"), System.Drawing.Image)
        Me.cxmnuEditTransDate.Name = "cxmnuEditTransDate"
        Me.cxmnuEditTransDate.Size = New System.Drawing.Size(125, 22)
        Me.cxmnuEditTransDate.Text = "Date..."
        '
        'cxmnuEditPayment
        '
        Me.cxmnuEditPayment.Image = CType(resources.GetObject("cxmnuEditPayment.Image"), System.Drawing.Image)
        Me.cxmnuEditPayment.Name = "cxmnuEditPayment"
        Me.cxmnuEditPayment.Size = New System.Drawing.Size(125, 22)
        Me.cxmnuEditPayment.Text = "Payment..."
        '
        'cxmnuEditDeposit
        '
        Me.cxmnuEditDeposit.Image = CType(resources.GetObject("cxmnuEditDeposit.Image"), System.Drawing.Image)
        Me.cxmnuEditDeposit.Name = "cxmnuEditDeposit"
        Me.cxmnuEditDeposit.Size = New System.Drawing.Size(125, 22)
        Me.cxmnuEditDeposit.Text = "Deposit..."
        '
        'cxmnuEditPayee
        '
        Me.cxmnuEditPayee.Image = CType(resources.GetObject("cxmnuEditPayee.Image"), System.Drawing.Image)
        Me.cxmnuEditPayee.Name = "cxmnuEditPayee"
        Me.cxmnuEditPayee.Size = New System.Drawing.Size(125, 22)
        Me.cxmnuEditPayee.Text = "Payee..."
        '
        'cxmnuClearSelected
        '
        Me.cxmnuClearSelected.Image = CType(resources.GetObject("cxmnuClearSelected.Image"), System.Drawing.Image)
        Me.cxmnuClearSelected.Name = "cxmnuClearSelected"
        Me.cxmnuClearSelected.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuClearSelected.Text = "Clear"
        '
        'cxmnuUnclearSelected
        '
        Me.cxmnuUnclearSelected.Image = CType(resources.GetObject("cxmnuUnclearSelected.Image"), System.Drawing.Image)
        Me.cxmnuUnclearSelected.Name = "cxmnuUnclearSelected"
        Me.cxmnuUnclearSelected.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuUnclearSelected.Text = "Unclear"
        '
        'cxmnuViewReceipt
        '
        Me.cxmnuViewReceipt.Image = CType(resources.GetObject("cxmnuViewReceipt.Image"), System.Drawing.Image)
        Me.cxmnuViewReceipt.Name = "cxmnuViewReceipt"
        Me.cxmnuViewReceipt.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuViewReceipt.Text = "View Receipt"
        '
        'cxmnuSumSelected
        '
        Me.cxmnuSumSelected.Image = CType(resources.GetObject("cxmnuSumSelected.Image"), System.Drawing.Image)
        Me.cxmnuSumSelected.Name = "cxmnuSumSelected"
        Me.cxmnuSumSelected.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuSumSelected.Text = "Sum Selected"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(179, 6)
        '
        'cxmnuResetDefault
        '
        Me.cxmnuResetDefault.Image = CType(resources.GetObject("cxmnuResetDefault.Image"), System.Drawing.Image)
        Me.cxmnuResetDefault.Name = "cxmnuResetDefault"
        Me.cxmnuResetDefault.Size = New System.Drawing.Size(182, 22)
        Me.cxmnuResetDefault.Text = "Default Column Widths"
        '
        'txtLedgerStatus
        '
        Me.txtLedgerStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLedgerStatus.Enabled = False
        Me.txtLedgerStatus.Location = New System.Drawing.Point(568, 37)
        Me.txtLedgerStatus.Name = "txtLedgerStatus"
        Me.txtLedgerStatus.ReadOnly = True
        Me.txtLedgerStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtLedgerStatus.TabIndex = 6
        '
        'txtOverallBalance
        '
        Me.txtOverallBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOverallBalance.Enabled = False
        Me.txtOverallBalance.Location = New System.Drawing.Point(462, 37)
        Me.txtOverallBalance.Name = "txtOverallBalance"
        Me.txtOverallBalance.ReadOnly = True
        Me.txtOverallBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtOverallBalance.TabIndex = 7
        '
        'txtTotalDeposits
        '
        Me.txtTotalDeposits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDeposits.Enabled = False
        Me.txtTotalDeposits.Location = New System.Drawing.Point(250, 37)
        Me.txtTotalDeposits.Name = "txtTotalDeposits"
        Me.txtTotalDeposits.ReadOnly = True
        Me.txtTotalDeposits.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDeposits.TabIndex = 8
        '
        'txtTotalPayments
        '
        Me.txtTotalPayments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPayments.Enabled = False
        Me.txtTotalPayments.Location = New System.Drawing.Point(144, 37)
        Me.txtTotalPayments.Name = "txtTotalPayments"
        Me.txtTotalPayments.ReadOnly = True
        Me.txtTotalPayments.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalPayments.TabIndex = 9
        '
        'lblStartingBalance
        '
        Me.lblStartingBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStartingBalance.AutoSize = True
        Me.lblStartingBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblStartingBalance.Location = New System.Drawing.Point(38, 21)
        Me.lblStartingBalance.Name = "lblStartingBalance"
        Me.lblStartingBalance.Size = New System.Drawing.Size(85, 13)
        Me.lblStartingBalance.TabIndex = 11
        Me.lblStartingBalance.Text = "Starting Balance"
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPayments.AutoSize = True
        Me.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalPayments.Location = New System.Drawing.Point(144, 21)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Size = New System.Drawing.Size(80, 13)
        Me.lblTotalPayments.TabIndex = 12
        Me.lblTotalPayments.Text = "Total Payments"
        '
        'lblTotalDeposits
        '
        Me.lblTotalDeposits.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDeposits.AutoSize = True
        Me.lblTotalDeposits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalDeposits.Location = New System.Drawing.Point(250, 21)
        Me.lblTotalDeposits.Name = "lblTotalDeposits"
        Me.lblTotalDeposits.Size = New System.Drawing.Size(75, 13)
        Me.lblTotalDeposits.TabIndex = 13
        Me.lblTotalDeposits.Text = "Total Deposits"
        '
        'lblOverallBalance
        '
        Me.lblOverallBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOverallBalance.AutoSize = True
        Me.lblOverallBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblOverallBalance.Location = New System.Drawing.Point(462, 21)
        Me.lblOverallBalance.Name = "lblOverallBalance"
        Me.lblOverallBalance.Size = New System.Drawing.Size(82, 13)
        Me.lblOverallBalance.TabIndex = 14
        Me.lblOverallBalance.Text = "Overall Balance"
        '
        'lblLedgerStatus
        '
        Me.lblLedgerStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLedgerStatus.AutoSize = True
        Me.lblLedgerStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblLedgerStatus.Location = New System.Drawing.Point(568, 21)
        Me.lblLedgerStatus.Name = "lblLedgerStatus"
        Me.lblLedgerStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblLedgerStatus.TabIndex = 15
        Me.lblLedgerStatus.Text = "Ledger Status"
        '
        'tsToolStrip
        '
        Me.tsToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnOpen, Me.btnSaveAs, Me.ToolStripSeparator1, Me.btnNewTrans, Me.btnDeleteTrans, Me.btnEditTrans, Me.btnClearSelected, Me.btnUnclearSelected, Me.ToolStripSeparator6, Me.btnCategories, Me.btnPayees, Me.btnViewReceipt, Me.ToolStripSeparator2, Me.btnSumSelected, Me.btnFilter, Me.btnBalanceAccount})
        Me.tsToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.tsToolStrip.Name = "tsToolStrip"
        Me.tsToolStrip.Padding = New System.Windows.Forms.Padding(12, 0, 1, 0)
        Me.tsToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsToolStrip.Size = New System.Drawing.Size(1084, 25)
        Me.tsToolStrip.TabIndex = 16
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(23, 22)
        Me.btnNew.Text = "New Ledger"
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(23, 22)
        Me.btnOpen.Text = "Open Ledger"
        '
        'btnSaveAs
        '
        Me.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveAs.Image = CType(resources.GetObject("btnSaveAs.Image"), System.Drawing.Image)
        Me.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(23, 22)
        Me.btnSaveAs.Text = "Save As"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnNewTrans
        '
        Me.btnNewTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNewTrans.Image = CType(resources.GetObject("btnNewTrans.Image"), System.Drawing.Image)
        Me.btnNewTrans.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNewTrans.Name = "btnNewTrans"
        Me.btnNewTrans.Size = New System.Drawing.Size(23, 22)
        Me.btnNewTrans.Text = "New Transaction"
        '
        'btnDeleteTrans
        '
        Me.btnDeleteTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeleteTrans.Image = CType(resources.GetObject("btnDeleteTrans.Image"), System.Drawing.Image)
        Me.btnDeleteTrans.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteTrans.Name = "btnDeleteTrans"
        Me.btnDeleteTrans.Size = New System.Drawing.Size(23, 22)
        Me.btnDeleteTrans.Text = "Delete Transaction(s)"
        '
        'btnEditTrans
        '
        Me.btnEditTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditTrans.Image = CType(resources.GetObject("btnEditTrans.Image"), System.Drawing.Image)
        Me.btnEditTrans.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditTrans.Name = "btnEditTrans"
        Me.btnEditTrans.Size = New System.Drawing.Size(23, 22)
        Me.btnEditTrans.Text = "Edit Transaction"
        '
        'btnClearSelected
        '
        Me.btnClearSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClearSelected.Image = CType(resources.GetObject("btnClearSelected.Image"), System.Drawing.Image)
        Me.btnClearSelected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClearSelected.Name = "btnClearSelected"
        Me.btnClearSelected.Size = New System.Drawing.Size(23, 22)
        Me.btnClearSelected.Text = "Clear Selected"
        '
        'btnUnclearSelected
        '
        Me.btnUnclearSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUnclearSelected.Image = CType(resources.GetObject("btnUnclearSelected.Image"), System.Drawing.Image)
        Me.btnUnclearSelected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUnclearSelected.Name = "btnUnclearSelected"
        Me.btnUnclearSelected.Size = New System.Drawing.Size(23, 22)
        Me.btnUnclearSelected.Text = "Unclear Selected"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnCategories
        '
        Me.btnCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCategories.Image = CType(resources.GetObject("btnCategories.Image"), System.Drawing.Image)
        Me.btnCategories.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(23, 22)
        Me.btnCategories.Text = "Categories"
        '
        'btnPayees
        '
        Me.btnPayees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPayees.Image = CType(resources.GetObject("btnPayees.Image"), System.Drawing.Image)
        Me.btnPayees.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPayees.Name = "btnPayees"
        Me.btnPayees.Size = New System.Drawing.Size(23, 22)
        Me.btnPayees.Text = "Payees"
        '
        'btnViewReceipt
        '
        Me.btnViewReceipt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewReceipt.Image = CType(resources.GetObject("btnViewReceipt.Image"), System.Drawing.Image)
        Me.btnViewReceipt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewReceipt.Name = "btnViewReceipt"
        Me.btnViewReceipt.Size = New System.Drawing.Size(23, 22)
        Me.btnViewReceipt.Text = "View Receipt"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnSumSelected
        '
        Me.btnSumSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSumSelected.Image = CType(resources.GetObject("btnSumSelected.Image"), System.Drawing.Image)
        Me.btnSumSelected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSumSelected.Name = "btnSumSelected"
        Me.btnSumSelected.Size = New System.Drawing.Size(23, 22)
        Me.btnSumSelected.Text = "Sum Selected"
        '
        'btnFilter
        '
        Me.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(23, 22)
        Me.btnFilter.Text = "Filter"
        '
        'btnBalanceAccount
        '
        Me.btnBalanceAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBalanceAccount.Image = CType(resources.GetObject("btnBalanceAccount.Image"), System.Drawing.Image)
        Me.btnBalanceAccount.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBalanceAccount.Name = "btnBalanceAccount"
        Me.btnBalanceAccount.Size = New System.Drawing.Size(23, 22)
        Me.btnBalanceAccount.Text = "Balance Account"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(53, 37)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(272, 20)
        Me.txtFilter.TabIndex = 17
        '
        'lblCleared
        '
        Me.lblCleared.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCleared.AutoSize = True
        Me.lblCleared.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCleared.Location = New System.Drawing.Point(356, 21)
        Me.lblCleared.Name = "lblCleared"
        Me.lblCleared.Size = New System.Drawing.Size(85, 13)
        Me.lblCleared.TabIndex = 20
        Me.lblCleared.Text = "Cleared Balance"
        '
        'txtClearedBalance
        '
        Me.txtClearedBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClearedBalance.Enabled = False
        Me.txtClearedBalance.Location = New System.Drawing.Point(356, 37)
        Me.txtClearedBalance.Name = "txtClearedBalance"
        Me.txtClearedBalance.ReadOnly = True
        Me.txtClearedBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtClearedBalance.TabIndex = 19
        '
        'stStatusStrip
        '
        Me.stStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadUpdateProgressBar, Me.DownloadUpdateLabel, Me.stLabel})
        Me.stStatusStrip.Location = New System.Drawing.Point(0, 739)
        Me.stStatusStrip.Name = "stStatusStrip"
        Me.stStatusStrip.Size = New System.Drawing.Size(1084, 22)
        Me.stStatusStrip.TabIndex = 21
        Me.stStatusStrip.Text = "StatusStrip1"
        '
        'DownloadUpdateProgressBar
        '
        Me.DownloadUpdateProgressBar.Margin = New System.Windows.Forms.Padding(12, 3, 1, 3)
        Me.DownloadUpdateProgressBar.Name = "DownloadUpdateProgressBar"
        Me.DownloadUpdateProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'DownloadUpdateLabel
        '
        Me.DownloadUpdateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.DownloadUpdateLabel.Name = "DownloadUpdateLabel"
        Me.DownloadUpdateLabel.Size = New System.Drawing.Size(150, 17)
        Me.DownloadUpdateLabel.Text = "Downloading latest version"
        '
        'stLabel
        '
        Me.stLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.stLabel.Name = "stLabel"
        Me.stLabel.Size = New System.Drawing.Size(93, 17)
        Me.stLabel.Text = "Transaction Info"
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Image = CType(resources.GetObject("btnClearFilter.Image"), System.Drawing.Image)
        Me.btnClearFilter.Location = New System.Drawing.Point(23, 35)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(24, 24)
        Me.btnClearFilter.TabIndex = 22
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'txtStartingBalance
        '
        Me.txtStartingBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartingBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStartingBalance.Enabled = False
        Me.txtStartingBalance.Location = New System.Drawing.Point(38, 37)
        Me.txtStartingBalance.Name = "txtStartingBalance"
        Me.txtStartingBalance.ReadOnly = True
        Me.txtStartingBalance.ShortcutsEnabled = False
        Me.txtStartingBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtStartingBalance.TabIndex = 10
        '
        'tmrFilterTimer
        '
        Me.tmrFilterTimer.Interval = 1
        '
        'tmrTimer
        '
        '
        'gbAccountDetails
        '
        Me.gbAccountDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAccountDetails.Controls.Add(Me.txtStartingBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtLedgerStatus)
        Me.gbAccountDetails.Controls.Add(Me.lblCleared)
        Me.gbAccountDetails.Controls.Add(Me.txtOverallBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtClearedBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtTotalDeposits)
        Me.gbAccountDetails.Controls.Add(Me.txtTotalPayments)
        Me.gbAccountDetails.Controls.Add(Me.lblStartingBalance)
        Me.gbAccountDetails.Controls.Add(Me.lblTotalPayments)
        Me.gbAccountDetails.Controls.Add(Me.lblTotalDeposits)
        Me.gbAccountDetails.Controls.Add(Me.lblOverallBalance)
        Me.gbAccountDetails.Controls.Add(Me.lblLedgerStatus)
        Me.gbAccountDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbAccountDetails.Location = New System.Drawing.Point(366, 52)
        Me.gbAccountDetails.Name = "gbAccountDetails"
        Me.gbAccountDetails.Size = New System.Drawing.Size(706, 79)
        Me.gbAccountDetails.TabIndex = 23
        Me.gbAccountDetails.TabStop = False
        Me.gbAccountDetails.Text = "Account Details"
        '
        'gbFilter
        '
        Me.gbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFilter.Controls.Add(Me.txtFilter)
        Me.gbFilter.Controls.Add(Me.btnClearFilter)
        Me.gbFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbFilter.Location = New System.Drawing.Point(12, 52)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(348, 79)
        Me.gbFilter.TabIndex = 24
        Me.gbFilter.TabStop = False
        Me.gbFilter.Text = "Filter"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1084, 761)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.gbAccountDetails)
        Me.Controls.Add(Me.stStatusStrip)
        Me.Controls.Add(Me.tsToolStrip)
        Me.Controls.Add(Me.dgvLedger)
        Me.Controls.Add(Me.mnuMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMenuStrip
        Me.MinimumSize = New System.Drawing.Size(922, 667)
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checkbook"
        Me.mnuMenuStrip.ResumeLayout(False)
        Me.mnuMenuStrip.PerformLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxmnuDataGridMenu.ResumeLayout(False)
        Me.tsToolStrip.ResumeLayout(False)
        Me.tsToolStrip.PerformLayout()
        Me.stStatusStrip.ResumeLayout(False)
        Me.stStatusStrip.PerformLayout()
        Me.gbAccountDetails.ResumeLayout(False)
        Me.gbAccountDetails.PerformLayout()
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvLedger As System.Windows.Forms.DataGridView
    Friend WithEvents txtLedgerStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtOverallBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDeposits As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPayments As System.Windows.Forms.TextBox
    Friend WithEvents lblStartingBalance As System.Windows.Forms.Label
    Friend WithEvents lblTotalPayments As System.Windows.Forms.Label
    Friend WithEvents lblTotalDeposits As System.Windows.Forms.Label
    Friend WithEvents lblOverallBalance As System.Windows.Forms.Label
    Friend WithEvents lblLedgerStatus As System.Windows.Forms.Label
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNewTrans As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeleteTrans As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditTrans As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCategories As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPayees As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSumSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuCalc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents mnuFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSpendingOverview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMonthlyIncome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEditStartingBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLedgerManager As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCleared As System.Windows.Forms.Label
    Friend WithEvents txtClearedBalance As System.Windows.Forms.TextBox
    Friend WithEvents btnClearSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUnclearSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuDataGridMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxmnuNewTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuDeleteTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditTrans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuSumSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents stStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents DownloadUpdateProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cxmnuResetDefault As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditDeposit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPayee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditDeposit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditPayee As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditTransDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditTransDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuEditType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsToolMenuSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnViewReceipt As System.Windows.Forms.ToolStripButton
    Friend WithEvents cxmnuViewReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuClearSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxmnuUnclearSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClearSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuUnclearSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClearFilter As System.Windows.Forms.Button
    Friend WithEvents txtStartingBalance As System.Windows.Forms.TextBox
    Friend WithEvents mnuViewReceipt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCategories As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPayees As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuUnCatUnknownMessage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrFilterTimer As System.Windows.Forms.Timer
    Friend WithEvents mnuLoanCalculator As ToolStripMenuItem
    Friend WithEvents mnuOpen As ToolStripMenuItem
    Friend WithEvents tmrTimer As Timer
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents mnuCheckforUpdate As ToolStripMenuItem
    Friend WithEvents DownloadUpdateLabel As ToolStripStatusLabel
    Friend WithEvents gbAccountDetails As GroupBox
    Friend WithEvents gbFilter As GroupBox
    Friend WithEvents mnuImportTrans As ToolStripMenuItem
    Friend WithEvents stLabel As ToolStripStatusLabel
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuCheckbookHelp As ToolStripMenuItem
    Friend WithEvents mnuAbout As ToolStripMenuItem
    Friend WithEvents mnuBalanceAccount As ToolStripMenuItem
    Friend WithEvents btnBalanceAccount As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Public WithEvents tsToolStrip As ToolStrip
    Friend WithEvents mnuBudgets As ToolStripMenuItem
End Class
