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
        Me.mnuMyStatements = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseLedger = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.mnuEditStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRemoveReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDuplicateTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUnclearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditStartingBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPayees = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSpendingOverview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMonthlyIncome = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBudgets = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMostUsed = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdvancedFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImportTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportTransactions = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.cxmnuEditStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.cxmnuRemoveReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRemoveStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuDuplicateTrans = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuClearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuUnclearSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuViewReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuViewStatement = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.gbAccountDetails = New System.Windows.Forms.GroupBox()
        Me.lnlUncleared = New System.Windows.Forms.Label()
        Me.txtUnclearedBalance = New System.Windows.Forms.TextBox()
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.mnuMenuStrip.SuspendLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxmnuDataGridMenu.SuspendLayout()
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
        Me.mnuMenuStrip.Size = New System.Drawing.Size(984, 24)
        Me.mnuMenuStrip.TabIndex = 5
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuOpen, Me.mnuMyStatements, Me.mnuCloseLedger, Me.ToolStripSeparator1, Me.mnuSaveAs, Me.ToolStripSeparator2, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.Image = CType(resources.GetObject("mnuNew.Image"), System.Drawing.Image)
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(196, 22)
        Me.mnuNew.Text = "&New Ledger..."
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = Global.Checkbook.My.Resources.Resources.my_checkbook_ledgers
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(196, 22)
        Me.mnuOpen.Text = "My Checkbook &Ledgers..."
        '
        'mnuMyStatements
        '
        Me.mnuMyStatements.Image = Global.Checkbook.My.Resources.Resources.img_manage_statements
        Me.mnuMyStatements.Name = "mnuMyStatements"
        Me.mnuMyStatements.Size = New System.Drawing.Size(196, 22)
        Me.mnuMyStatements.Text = "My S&tatements..."
        '
        'mnuCloseLedger
        '
        Me.mnuCloseLedger.Image = Global.Checkbook.My.Resources.Resources.close_ledger
        Me.mnuCloseLedger.Name = "mnuCloseLedger"
        Me.mnuCloseLedger.Size = New System.Drawing.Size(196, 22)
        Me.mnuCloseLedger.Text = "&Close Ledger"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(193, 6)
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Image = CType(resources.GetObject("mnuSaveAs.Image"), System.Drawing.Image)
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(196, 22)
        Me.mnuSaveAs.Text = "&Save As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(193, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(196, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewTrans, Me.mnuDeleteTrans, Me.mnuEditTrans, Me.mnuDuplicateTrans, Me.mnuClearSelected, Me.mnuUnclearSelected, Me.ToolStripSeparator3, Me.mnuEditStartingBalance})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuNewTrans
        '
        Me.mnuNewTrans.Image = CType(resources.GetObject("mnuNewTrans.Image"), System.Drawing.Image)
        Me.mnuNewTrans.Name = "mnuNewTrans"
        Me.mnuNewTrans.Size = New System.Drawing.Size(189, 22)
        Me.mnuNewTrans.Text = "&New Transaction..."
        '
        'mnuDeleteTrans
        '
        Me.mnuDeleteTrans.Image = CType(resources.GetObject("mnuDeleteTrans.Image"), System.Drawing.Image)
        Me.mnuDeleteTrans.Name = "mnuDeleteTrans"
        Me.mnuDeleteTrans.Size = New System.Drawing.Size(189, 22)
        Me.mnuDeleteTrans.Text = "&Delete Transaction(s)"
        '
        'mnuEditTrans
        '
        Me.mnuEditTrans.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditType, Me.mnuEditCategory, Me.mnuEditTransDate, Me.mnuEditPayment, Me.mnuEditDeposit, Me.mnuEditPayee, Me.mnuEditStatement, Me.ToolStripSeparator6, Me.mnuRemoveReceipt, Me.mnuRemoveStatement})
        Me.mnuEditTrans.Image = CType(resources.GetObject("mnuEditTrans.Image"), System.Drawing.Image)
        Me.mnuEditTrans.Name = "mnuEditTrans"
        Me.mnuEditTrans.Size = New System.Drawing.Size(189, 22)
        Me.mnuEditTrans.Text = "&Edit Transaction(s)..."
        '
        'mnuEditType
        '
        Me.mnuEditType.Image = CType(resources.GetObject("mnuEditType.Image"), System.Drawing.Image)
        Me.mnuEditType.Name = "mnuEditType"
        Me.mnuEditType.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditType.Text = "&Type..."
        '
        'mnuEditCategory
        '
        Me.mnuEditCategory.Image = Global.Checkbook.My.Resources.Resources.categories
        Me.mnuEditCategory.Name = "mnuEditCategory"
        Me.mnuEditCategory.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditCategory.Text = "&Category..."
        '
        'mnuEditTransDate
        '
        Me.mnuEditTransDate.Image = Global.Checkbook.My.Resources.Resources.trans_date
        Me.mnuEditTransDate.Name = "mnuEditTransDate"
        Me.mnuEditTransDate.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditTransDate.Text = "&Date..."
        '
        'mnuEditPayment
        '
        Me.mnuEditPayment.Image = CType(resources.GetObject("mnuEditPayment.Image"), System.Drawing.Image)
        Me.mnuEditPayment.Name = "mnuEditPayment"
        Me.mnuEditPayment.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditPayment.Text = "Pa&yment..."
        '
        'mnuEditDeposit
        '
        Me.mnuEditDeposit.Image = CType(resources.GetObject("mnuEditDeposit.Image"), System.Drawing.Image)
        Me.mnuEditDeposit.Name = "mnuEditDeposit"
        Me.mnuEditDeposit.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditDeposit.Text = "&Deposit..."
        '
        'mnuEditPayee
        '
        Me.mnuEditPayee.Image = Global.Checkbook.My.Resources.Resources.payee
        Me.mnuEditPayee.Name = "mnuEditPayee"
        Me.mnuEditPayee.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditPayee.Text = "&Payee..."
        '
        'mnuEditStatement
        '
        Me.mnuEditStatement.Image = Global.Checkbook.My.Resources.Resources.statement
        Me.mnuEditStatement.Name = "mnuEditStatement"
        Me.mnuEditStatement.Size = New System.Drawing.Size(165, 22)
        Me.mnuEditStatement.Text = "&Statement..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(162, 6)
        '
        'mnuRemoveReceipt
        '
        Me.mnuRemoveReceipt.Image = Global.Checkbook.My.Resources.Resources.remove_receipt
        Me.mnuRemoveReceipt.Name = "mnuRemoveReceipt"
        Me.mnuRemoveReceipt.Size = New System.Drawing.Size(165, 22)
        Me.mnuRemoveReceipt.Text = "Remove &Receipt"
        '
        'mnuRemoveStatement
        '
        Me.mnuRemoveStatement.Image = Global.Checkbook.My.Resources.Resources.remove_statement
        Me.mnuRemoveStatement.Name = "mnuRemoveStatement"
        Me.mnuRemoveStatement.Size = New System.Drawing.Size(165, 22)
        Me.mnuRemoveStatement.Text = "Remove St&atement"
        '
        'mnuDuplicateTrans
        '
        Me.mnuDuplicateTrans.Image = Global.Checkbook.My.Resources.Resources.duplicate_trans
        Me.mnuDuplicateTrans.Name = "mnuDuplicateTrans"
        Me.mnuDuplicateTrans.Size = New System.Drawing.Size(189, 22)
        Me.mnuDuplicateTrans.Text = "Du&plicate Transaction(s)"
        '
        'mnuClearSelected
        '
        Me.mnuClearSelected.Image = CType(resources.GetObject("mnuClearSelected.Image"), System.Drawing.Image)
        Me.mnuClearSelected.Name = "mnuClearSelected"
        Me.mnuClearSelected.Size = New System.Drawing.Size(189, 22)
        Me.mnuClearSelected.Text = "&Clear"
        '
        'mnuUnclearSelected
        '
        Me.mnuUnclearSelected.Image = CType(resources.GetObject("mnuUnclearSelected.Image"), System.Drawing.Image)
        Me.mnuUnclearSelected.Name = "mnuUnclearSelected"
        Me.mnuUnclearSelected.Size = New System.Drawing.Size(189, 22)
        Me.mnuUnclearSelected.Text = "&Unclear"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(186, 6)
        '
        'mnuEditStartingBalance
        '
        Me.mnuEditStartingBalance.Image = CType(resources.GetObject("mnuEditStartingBalance.Image"), System.Drawing.Image)
        Me.mnuEditStartingBalance.Name = "mnuEditStartingBalance"
        Me.mnuEditStartingBalance.Size = New System.Drawing.Size(189, 22)
        Me.mnuEditStartingBalance.Text = "Edit &Starting Balance..."
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCategories, Me.mnuPayees, Me.mnuViewReceipt, Me.mnuViewStatement, Me.ToolStripSeparator4, Me.mnuSpendingOverview, Me.mnuMonthlyIncome, Me.mnuBudgets, Me.mnuMostUsed})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(42, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuCategories
        '
        Me.mnuCategories.Image = CType(resources.GetObject("mnuCategories.Image"), System.Drawing.Image)
        Me.mnuCategories.Name = "mnuCategories"
        Me.mnuCategories.Size = New System.Drawing.Size(227, 22)
        Me.mnuCategories.Text = "&Categories..."
        '
        'mnuPayees
        '
        Me.mnuPayees.Image = CType(resources.GetObject("mnuPayees.Image"), System.Drawing.Image)
        Me.mnuPayees.Name = "mnuPayees"
        Me.mnuPayees.Size = New System.Drawing.Size(227, 22)
        Me.mnuPayees.Text = "&Payees..."
        '
        'mnuViewReceipt
        '
        Me.mnuViewReceipt.Image = CType(resources.GetObject("mnuViewReceipt.Image"), System.Drawing.Image)
        Me.mnuViewReceipt.Name = "mnuViewReceipt"
        Me.mnuViewReceipt.Size = New System.Drawing.Size(227, 22)
        Me.mnuViewReceipt.Text = "View &Receipt"
        '
        'mnuViewStatement
        '
        Me.mnuViewStatement.Image = Global.Checkbook.My.Resources.Resources.statement
        Me.mnuViewStatement.Name = "mnuViewStatement"
        Me.mnuViewStatement.Size = New System.Drawing.Size(227, 22)
        Me.mnuViewStatement.Text = "View &Statement"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(224, 6)
        '
        'mnuSpendingOverview
        '
        Me.mnuSpendingOverview.Image = CType(resources.GetObject("mnuSpendingOverview.Image"), System.Drawing.Image)
        Me.mnuSpendingOverview.Name = "mnuSpendingOverview"
        Me.mnuSpendingOverview.Size = New System.Drawing.Size(227, 22)
        Me.mnuSpendingOverview.Text = "Spending &Overview..."
        '
        'mnuMonthlyIncome
        '
        Me.mnuMonthlyIncome.Image = CType(resources.GetObject("mnuMonthlyIncome.Image"), System.Drawing.Image)
        Me.mnuMonthlyIncome.Name = "mnuMonthlyIncome"
        Me.mnuMonthlyIncome.Size = New System.Drawing.Size(227, 22)
        Me.mnuMonthlyIncome.Text = "Monthly &Income..."
        '
        'mnuBudgets
        '
        Me.mnuBudgets.Image = CType(resources.GetObject("mnuBudgets.Image"), System.Drawing.Image)
        Me.mnuBudgets.Name = "mnuBudgets"
        Me.mnuBudgets.Size = New System.Drawing.Size(227, 22)
        Me.mnuBudgets.Text = "&Budgets..."
        '
        'mnuMostUsed
        '
        Me.mnuMostUsed.Image = CType(resources.GetObject("mnuMostUsed.Image"), System.Drawing.Image)
        Me.mnuMostUsed.Name = "mnuMostUsed"
        Me.mnuMostUsed.Size = New System.Drawing.Size(227, 22)
        Me.mnuMostUsed.Text = "&Most Used Categories/Payees..."
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSum, Me.mnuFilter, Me.mnuAdvancedFilter, Me.mnuOptions, Me.mnuImportTrans, Me.mnuExportTransactions, Me.mnuBalanceAccount, Me.tsToolMenuSeparator1, Me.mnuLoanCalculator, Me.mnuCalc, Me.ToolStripSeparator8, Me.mnuCheckforUpdate})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(45, 20)
        Me.mnuTools.Text = "&Tools"
        '
        'mnuSum
        '
        Me.mnuSum.Image = CType(resources.GetObject("mnuSum.Image"), System.Drawing.Image)
        Me.mnuSum.Name = "mnuSum"
        Me.mnuSum.Size = New System.Drawing.Size(177, 22)
        Me.mnuSum.Text = "&Sum Selected"
        '
        'mnuFilter
        '
        Me.mnuFilter.Image = CType(resources.GetObject("mnuFilter.Image"), System.Drawing.Image)
        Me.mnuFilter.Name = "mnuFilter"
        Me.mnuFilter.Size = New System.Drawing.Size(177, 22)
        Me.mnuFilter.Text = "&Quick Filter"
        '
        'mnuAdvancedFilter
        '
        Me.mnuAdvancedFilter.Image = CType(resources.GetObject("mnuAdvancedFilter.Image"), System.Drawing.Image)
        Me.mnuAdvancedFilter.Name = "mnuAdvancedFilter"
        Me.mnuAdvancedFilter.Size = New System.Drawing.Size(177, 22)
        Me.mnuAdvancedFilter.Text = "&Advanced Filter..."
        '
        'mnuOptions
        '
        Me.mnuOptions.Image = CType(resources.GetObject("mnuOptions.Image"), System.Drawing.Image)
        Me.mnuOptions.Name = "mnuOptions"
        Me.mnuOptions.Size = New System.Drawing.Size(177, 22)
        Me.mnuOptions.Text = "&Options..."
        '
        'mnuImportTrans
        '
        Me.mnuImportTrans.Image = CType(resources.GetObject("mnuImportTrans.Image"), System.Drawing.Image)
        Me.mnuImportTrans.Name = "mnuImportTrans"
        Me.mnuImportTrans.Size = New System.Drawing.Size(177, 22)
        Me.mnuImportTrans.Text = "&Import Transactions..."
        '
        'mnuExportTransactions
        '
        Me.mnuExportTransactions.Image = CType(resources.GetObject("mnuExportTransactions.Image"), System.Drawing.Image)
        Me.mnuExportTransactions.Name = "mnuExportTransactions"
        Me.mnuExportTransactions.Size = New System.Drawing.Size(177, 22)
        Me.mnuExportTransactions.Text = "&Export Transactions..."
        '
        'mnuBalanceAccount
        '
        Me.mnuBalanceAccount.Image = CType(resources.GetObject("mnuBalanceAccount.Image"), System.Drawing.Image)
        Me.mnuBalanceAccount.Name = "mnuBalanceAccount"
        Me.mnuBalanceAccount.Size = New System.Drawing.Size(177, 22)
        Me.mnuBalanceAccount.Text = "&Balance Account"
        '
        'tsToolMenuSeparator1
        '
        Me.tsToolMenuSeparator1.Name = "tsToolMenuSeparator1"
        Me.tsToolMenuSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'mnuLoanCalculator
        '
        Me.mnuLoanCalculator.Image = CType(resources.GetObject("mnuLoanCalculator.Image"), System.Drawing.Image)
        Me.mnuLoanCalculator.Name = "mnuLoanCalculator"
        Me.mnuLoanCalculator.Size = New System.Drawing.Size(177, 22)
        Me.mnuLoanCalculator.Text = "&Loan Calculator..."
        '
        'mnuCalc
        '
        Me.mnuCalc.Image = CType(resources.GetObject("mnuCalc.Image"), System.Drawing.Image)
        Me.mnuCalc.Name = "mnuCalc"
        Me.mnuCalc.Size = New System.Drawing.Size(177, 22)
        Me.mnuCalc.Text = "&Windows Calculator"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(174, 6)
        '
        'mnuCheckforUpdate
        '
        Me.mnuCheckforUpdate.Image = CType(resources.GetObject("mnuCheckforUpdate.Image"), System.Drawing.Image)
        Me.mnuCheckforUpdate.Name = "mnuCheckforUpdate"
        Me.mnuCheckforUpdate.Size = New System.Drawing.Size(177, 22)
        Me.mnuCheckforUpdate.Text = "&Check for Update"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCheckbookHelp, Me.mnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(41, 20)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuCheckbookHelp
        '
        Me.mnuCheckbookHelp.Image = CType(resources.GetObject("mnuCheckbookHelp.Image"), System.Drawing.Image)
        Me.mnuCheckbookHelp.Name = "mnuCheckbookHelp"
        Me.mnuCheckbookHelp.Size = New System.Drawing.Size(160, 22)
        Me.mnuCheckbookHelp.Text = "Checkbook &Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Image = CType(resources.GetObject("mnuAbout.Image"), System.Drawing.Image)
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(160, 22)
        Me.mnuAbout.Text = "&About Checkbook"
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
        Me.dgvLedger.ShowCellToolTips = False
        Me.dgvLedger.Size = New System.Drawing.Size(960, 549)
        Me.dgvLedger.TabIndex = 0
        '
        'cxmnuDataGridMenu
        '
        Me.cxmnuDataGridMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cxmnuDataGridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuNewTrans, Me.cxmnuDeleteTrans, Me.cxmnuEditTrans, Me.cxmnuDuplicateTrans, Me.cxmnuClearSelected, Me.cxmnuUnclearSelected, Me.cxmnuViewReceipt, Me.cxmnuViewStatement, Me.cxmnuSumSelected, Me.ToolStripSeparator5, Me.cxmnuResetDefault})
        Me.cxmnuDataGridMenu.Name = "cxmnuDataGridMenu"
        Me.cxmnuDataGridMenu.Size = New System.Drawing.Size(190, 230)
        '
        'cxmnuNewTrans
        '
        Me.cxmnuNewTrans.Image = CType(resources.GetObject("cxmnuNewTrans.Image"), System.Drawing.Image)
        Me.cxmnuNewTrans.Name = "cxmnuNewTrans"
        Me.cxmnuNewTrans.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuNewTrans.Text = "&New Transaction..."
        '
        'cxmnuDeleteTrans
        '
        Me.cxmnuDeleteTrans.Image = CType(resources.GetObject("cxmnuDeleteTrans.Image"), System.Drawing.Image)
        Me.cxmnuDeleteTrans.Name = "cxmnuDeleteTrans"
        Me.cxmnuDeleteTrans.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuDeleteTrans.Text = "&Delete Transaction(s)"
        '
        'cxmnuEditTrans
        '
        Me.cxmnuEditTrans.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuEditType, Me.cxmnuEditCategory, Me.cxmnuEditTransDate, Me.cxmnuEditPayment, Me.cxmnuEditDeposit, Me.cxmnuEditPayee, Me.cxmnuEditStatement, Me.ToolStripSeparator9, Me.cxmnuRemoveReceipt, Me.cxmnuRemoveStatement})
        Me.cxmnuEditTrans.Image = CType(resources.GetObject("cxmnuEditTrans.Image"), System.Drawing.Image)
        Me.cxmnuEditTrans.Name = "cxmnuEditTrans"
        Me.cxmnuEditTrans.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuEditTrans.Text = "&Edit Transaction(s)..."
        '
        'cxmnuEditType
        '
        Me.cxmnuEditType.Image = CType(resources.GetObject("cxmnuEditType.Image"), System.Drawing.Image)
        Me.cxmnuEditType.Name = "cxmnuEditType"
        Me.cxmnuEditType.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditType.Text = "&Type..."
        '
        'cxmnuEditCategory
        '
        Me.cxmnuEditCategory.Image = Global.Checkbook.My.Resources.Resources.categories
        Me.cxmnuEditCategory.Name = "cxmnuEditCategory"
        Me.cxmnuEditCategory.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditCategory.Text = "&Category..."
        '
        'cxmnuEditTransDate
        '
        Me.cxmnuEditTransDate.Image = Global.Checkbook.My.Resources.Resources.trans_date
        Me.cxmnuEditTransDate.Name = "cxmnuEditTransDate"
        Me.cxmnuEditTransDate.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditTransDate.Text = "&Date..."
        '
        'cxmnuEditPayment
        '
        Me.cxmnuEditPayment.Image = CType(resources.GetObject("cxmnuEditPayment.Image"), System.Drawing.Image)
        Me.cxmnuEditPayment.Name = "cxmnuEditPayment"
        Me.cxmnuEditPayment.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditPayment.Text = "Pa&yment..."
        '
        'cxmnuEditDeposit
        '
        Me.cxmnuEditDeposit.Image = CType(resources.GetObject("cxmnuEditDeposit.Image"), System.Drawing.Image)
        Me.cxmnuEditDeposit.Name = "cxmnuEditDeposit"
        Me.cxmnuEditDeposit.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditDeposit.Text = "D&eposit..."
        '
        'cxmnuEditPayee
        '
        Me.cxmnuEditPayee.Image = Global.Checkbook.My.Resources.Resources.payee
        Me.cxmnuEditPayee.Name = "cxmnuEditPayee"
        Me.cxmnuEditPayee.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditPayee.Text = "&Payee..."
        '
        'cxmnuEditStatement
        '
        Me.cxmnuEditStatement.Image = Global.Checkbook.My.Resources.Resources.statement
        Me.cxmnuEditStatement.Name = "cxmnuEditStatement"
        Me.cxmnuEditStatement.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuEditStatement.Text = "&Statement..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(162, 6)
        '
        'cxmnuRemoveReceipt
        '
        Me.cxmnuRemoveReceipt.Image = Global.Checkbook.My.Resources.Resources.remove_receipt
        Me.cxmnuRemoveReceipt.Name = "cxmnuRemoveReceipt"
        Me.cxmnuRemoveReceipt.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuRemoveReceipt.Text = "Remove &Receipt"
        '
        'cxmnuRemoveStatement
        '
        Me.cxmnuRemoveStatement.Image = Global.Checkbook.My.Resources.Resources.remove_statement
        Me.cxmnuRemoveStatement.Name = "cxmnuRemoveStatement"
        Me.cxmnuRemoveStatement.Size = New System.Drawing.Size(165, 22)
        Me.cxmnuRemoveStatement.Text = "Remove St&atement"
        '
        'cxmnuDuplicateTrans
        '
        Me.cxmnuDuplicateTrans.Image = Global.Checkbook.My.Resources.Resources.duplicate_trans
        Me.cxmnuDuplicateTrans.Name = "cxmnuDuplicateTrans"
        Me.cxmnuDuplicateTrans.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuDuplicateTrans.Text = "Du&plicate Transaction(s)"
        '
        'cxmnuClearSelected
        '
        Me.cxmnuClearSelected.Image = CType(resources.GetObject("cxmnuClearSelected.Image"), System.Drawing.Image)
        Me.cxmnuClearSelected.Name = "cxmnuClearSelected"
        Me.cxmnuClearSelected.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuClearSelected.Text = "&Clear"
        '
        'cxmnuUnclearSelected
        '
        Me.cxmnuUnclearSelected.Image = CType(resources.GetObject("cxmnuUnclearSelected.Image"), System.Drawing.Image)
        Me.cxmnuUnclearSelected.Name = "cxmnuUnclearSelected"
        Me.cxmnuUnclearSelected.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuUnclearSelected.Text = "&Unclear"
        '
        'cxmnuViewReceipt
        '
        Me.cxmnuViewReceipt.Image = CType(resources.GetObject("cxmnuViewReceipt.Image"), System.Drawing.Image)
        Me.cxmnuViewReceipt.Name = "cxmnuViewReceipt"
        Me.cxmnuViewReceipt.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuViewReceipt.Text = "View &Receipt"
        '
        'cxmnuViewStatement
        '
        Me.cxmnuViewStatement.Image = Global.Checkbook.My.Resources.Resources.statement
        Me.cxmnuViewStatement.Name = "cxmnuViewStatement"
        Me.cxmnuViewStatement.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuViewStatement.Text = "View &Statement"
        '
        'cxmnuSumSelected
        '
        Me.cxmnuSumSelected.Image = CType(resources.GetObject("cxmnuSumSelected.Image"), System.Drawing.Image)
        Me.cxmnuSumSelected.Name = "cxmnuSumSelected"
        Me.cxmnuSumSelected.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuSumSelected.Text = "Su&m Selected"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(186, 6)
        '
        'cxmnuResetDefault
        '
        Me.cxmnuResetDefault.Image = CType(resources.GetObject("cxmnuResetDefault.Image"), System.Drawing.Image)
        Me.cxmnuResetDefault.Name = "cxmnuResetDefault"
        Me.cxmnuResetDefault.Size = New System.Drawing.Size(189, 22)
        Me.cxmnuResetDefault.Text = "Default Column &Widths"
        '
        'txtLedgerStatus
        '
        Me.txtLedgerStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLedgerStatus.Enabled = False
        Me.txtLedgerStatus.Location = New System.Drawing.Point(670, 37)
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
        Me.txtOverallBalance.Location = New System.Drawing.Point(564, 37)
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
        Me.txtTotalDeposits.Location = New System.Drawing.Point(246, 37)
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
        Me.txtTotalPayments.Location = New System.Drawing.Point(140, 37)
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
        Me.lblStartingBalance.Location = New System.Drawing.Point(34, 21)
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
        Me.lblTotalPayments.Location = New System.Drawing.Point(140, 21)
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
        Me.lblTotalDeposits.Location = New System.Drawing.Point(246, 21)
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
        Me.lblOverallBalance.Location = New System.Drawing.Point(564, 21)
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
        Me.lblLedgerStatus.Location = New System.Drawing.Point(670, 21)
        Me.lblLedgerStatus.Name = "lblLedgerStatus"
        Me.lblLedgerStatus.Size = New System.Drawing.Size(73, 13)
        Me.lblLedgerStatus.TabIndex = 15
        Me.lblLedgerStatus.Text = "Ledger Status"
        '
        'tsToolStrip
        '
        Me.tsToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.tsToolStrip.Name = "tsToolStrip"
        Me.tsToolStrip.Padding = New System.Windows.Forms.Padding(12, 0, 1, 0)
        Me.tsToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsToolStrip.Size = New System.Drawing.Size(984, 25)
        Me.tsToolStrip.TabIndex = 16
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(53, 37)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(74, 20)
        Me.txtFilter.TabIndex = 17
        '
        'lblCleared
        '
        Me.lblCleared.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCleared.AutoSize = True
        Me.lblCleared.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCleared.Location = New System.Drawing.Point(352, 21)
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
        Me.txtClearedBalance.Location = New System.Drawing.Point(352, 37)
        Me.txtClearedBalance.Name = "txtClearedBalance"
        Me.txtClearedBalance.ReadOnly = True
        Me.txtClearedBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtClearedBalance.TabIndex = 19
        '
        'stStatusStrip
        '
        Me.stStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadUpdateProgressBar, Me.DownloadUpdateLabel, Me.stLabel})
        Me.stStatusStrip.Location = New System.Drawing.Point(0, 689)
        Me.stStatusStrip.Name = "stStatusStrip"
        Me.stStatusStrip.Size = New System.Drawing.Size(984, 22)
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
        Me.stLabel.Size = New System.Drawing.Size(92, 17)
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
        Me.txtStartingBalance.Location = New System.Drawing.Point(34, 37)
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
        'gbAccountDetails
        '
        Me.gbAccountDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAccountDetails.Controls.Add(Me.txtStartingBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtLedgerStatus)
        Me.gbAccountDetails.Controls.Add(Me.lnlUncleared)
        Me.gbAccountDetails.Controls.Add(Me.lblCleared)
        Me.gbAccountDetails.Controls.Add(Me.txtOverallBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtUnclearedBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtClearedBalance)
        Me.gbAccountDetails.Controls.Add(Me.txtTotalDeposits)
        Me.gbAccountDetails.Controls.Add(Me.txtTotalPayments)
        Me.gbAccountDetails.Controls.Add(Me.lblStartingBalance)
        Me.gbAccountDetails.Controls.Add(Me.lblTotalPayments)
        Me.gbAccountDetails.Controls.Add(Me.lblTotalDeposits)
        Me.gbAccountDetails.Controls.Add(Me.lblOverallBalance)
        Me.gbAccountDetails.Controls.Add(Me.lblLedgerStatus)
        Me.gbAccountDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbAccountDetails.Location = New System.Drawing.Point(168, 52)
        Me.gbAccountDetails.Name = "gbAccountDetails"
        Me.gbAccountDetails.Size = New System.Drawing.Size(804, 79)
        Me.gbAccountDetails.TabIndex = 23
        Me.gbAccountDetails.TabStop = False
        Me.gbAccountDetails.Text = "Account Details"
        '
        'lnlUncleared
        '
        Me.lnlUncleared.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnlUncleared.AutoSize = True
        Me.lnlUncleared.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lnlUncleared.Location = New System.Drawing.Point(458, 21)
        Me.lnlUncleared.Name = "lnlUncleared"
        Me.lnlUncleared.Size = New System.Drawing.Size(98, 13)
        Me.lnlUncleared.TabIndex = 20
        Me.lnlUncleared.Text = "Uncleared Balance"
        '
        'txtUnclearedBalance
        '
        Me.txtUnclearedBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUnclearedBalance.Enabled = False
        Me.txtUnclearedBalance.Location = New System.Drawing.Point(458, 37)
        Me.txtUnclearedBalance.Name = "txtUnclearedBalance"
        Me.txtUnclearedBalance.ReadOnly = True
        Me.txtUnclearedBalance.Size = New System.Drawing.Size(100, 20)
        Me.txtUnclearedBalance.TabIndex = 19
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
        Me.gbFilter.Size = New System.Drawing.Size(150, 79)
        Me.gbFilter.TabIndex = 24
        Me.gbFilter.TabStop = False
        Me.gbFilter.Text = "Filter"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(984, 711)
        Me.Controls.Add(Me.gbFilter)
        Me.Controls.Add(Me.gbAccountDetails)
        Me.Controls.Add(Me.stStatusStrip)
        Me.Controls.Add(Me.tsToolStrip)
        Me.Controls.Add(Me.dgvLedger)
        Me.Controls.Add(Me.mnuMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMenuStrip
        Me.MinimumSize = New System.Drawing.Size(1000, 667)
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checkbook"
        Me.mnuMenuStrip.ResumeLayout(False)
        Me.mnuMenuStrip.PerformLayout()
        CType(Me.dgvLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxmnuDataGridMenu.ResumeLayout(False)
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
    Friend WithEvents mnuCalc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents mnuFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSpendingOverview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMonthlyIncome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEditStartingBalance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCleared As System.Windows.Forms.Label
    Friend WithEvents txtClearedBalance As System.Windows.Forms.TextBox
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
    Friend WithEvents tmrFilterTimer As System.Windows.Forms.Timer
    Friend WithEvents mnuLoanCalculator As ToolStripMenuItem
    Friend WithEvents mnuOpen As ToolStripMenuItem
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
    Public WithEvents tsToolStrip As ToolStrip
    Friend WithEvents mnuBudgets As ToolStripMenuItem
    Friend WithEvents mnuMostUsed As ToolStripMenuItem
    Friend WithEvents mnuExportTransactions As ToolStripMenuItem
    Friend WithEvents mnuAdvancedFilter As ToolStripMenuItem
    Friend WithEvents cxmnuDuplicateTrans As ToolStripMenuItem
    Friend WithEvents mnuDuplicateTrans As ToolStripMenuItem
    Friend WithEvents mnuCloseLedger As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents lnlUncleared As Label
    Friend WithEvents txtUnclearedBalance As TextBox
    Friend WithEvents mnuViewStatement As ToolStripMenuItem
    Friend WithEvents cxmnuViewStatement As ToolStripMenuItem
    Friend WithEvents mnuMyStatements As ToolStripMenuItem
    Friend WithEvents mnuEditStatement As ToolStripMenuItem
    Friend WithEvents cxmnuEditStatement As ToolStripMenuItem
    Friend WithEvents mnuRemoveStatement As ToolStripMenuItem
    Friend WithEvents mnuRemoveReceipt As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents cxmnuRemoveReceipt As ToolStripMenuItem
    Friend WithEvents cxmnuRemoveStatement As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
End Class
