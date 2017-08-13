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

Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds
Imports System.Net
Imports System.IO
Imports System.EventArgs

Public Class MainForm

    'COLUMNS
    'ID
    'TYPE
    'CATEGORY
    'DATE
    'PAYMENT
    'DEPOSIT
    'PAYEE
    'DESCRIPTION
    'CLEARED
    'RECEIPT

    Public fullListCommandsList As New List(Of String)

    Public WithEvents about_Button As New ToolStripButton
    Public WithEvents balance_Button As New ToolStripButton
    Public WithEvents calculator_Button As New ToolStripButton
    Public WithEvents categories_Button As New ToolStripButton
    Public WithEvents cleared_Button As New ToolStripButton
    Public WithEvents delete_trans_Button As New ToolStripButton
    Public WithEvents edit_trans_Button As New ToolStripButton
    Public WithEvents exit_Button As New ToolStripButton
    Public WithEvents filter_Button As New ToolStripButton
    Public WithEvents help_Button As New ToolStripButton
    Public WithEvents import_trans_Button As New ToolStripButton
    Public WithEvents loan_calculator_Button As New ToolStripButton
    Public WithEvents message_Button As New ToolStripButton
    Public WithEvents monthly_income_Button As New ToolStripButton
    Public WithEvents budgets_Button As New ToolStripButton
    Public WithEvents new_ledger_Button As New ToolStripButton
    Public WithEvents new_trans_Button As New ToolStripButton
    Public WithEvents open_Button As New ToolStripButton
    Public WithEvents options_Button As New ToolStripButton
    Public WithEvents payees_Button As New ToolStripButton
    Public WithEvents reciept_Button As New ToolStripButton
    Public WithEvents save_as_Button As New ToolStripButton
    Public WithEvents spending_overview_Button As New ToolStripButton
    Public WithEvents start_balance_Button As New ToolStripButton
    Public WithEvents sum_selected_Button As New ToolStripButton
    Public WithEvents uncleared_Button As New ToolStripButton
    Public WithEvents updates_Button As New ToolStripButton
    Public WithEvents mostUsed_Button As New ToolStripButton
    Public WithEvents export_trans_Button As New ToolStripButton
    Public WithEvents advanced_filter_Button As New ToolStripButton
    Public WithEvents duplicate_trans_Button As New ToolStripButton
    Public WithEvents close_ledger_Button As New ToolStripButton

    'VARIABLES FOR ALL BITMAP ICONS
    Public img_about As Bitmap
    Public img_balance_account As Bitmap
    Public img_calculator As Bitmap
    Public img_categories As Bitmap
    Public img_cleared As Bitmap
    Public img_delete_trans As Bitmap
    Public img_edit_trans As Bitmap
    Public img_exit As Bitmap
    Public img_filter As Bitmap
    Public img_help As Bitmap
    Public img_import_trans As Bitmap
    Public img_loan_calculator As Bitmap
    Public img_message As Bitmap
    Public img_monthly_income As Bitmap
    Public img_budgets As Bitmap
    Public img_new_ledger As Bitmap
    Public img_new_trans As Bitmap
    Public img_open As Bitmap
    Public img_options As Bitmap
    Public img_payees As Bitmap
    Public img_receipt As Bitmap
    Public img_save_as As Bitmap
    Public img_spending_overview As Bitmap
    Public img_start_balance As Bitmap
    Public img_sum_selected As Bitmap
    Public img_uncleared As Bitmap
    Public img_updates As Bitmap
    Public img_mostUsed As Bitmap
    Public img_export_trans As Bitmap
    Public img_advanced_filter As Bitmap
    Public img_duplicate_trans As Bitmap
    Public img_close_ledger_Button As Bitmap

    Private No As Boolean = False
    Private Yes As Boolean = True

    Private intFilterTimerInterval As Integer

    Private latestVersionFromDropbox As String = String.Empty

    Private intTime As Integer

    Private File As New clsLedgerDBFileManager
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager
    Private NewTrans As New clsTransaction

    Private originalCategoryList As New List(Of String)
    Private originalPayeeList As New List(Of String)

    Private newCategoryList As New List(Of String)
    Private newPayeeList As New List(Of String)

    Private transactionList As New List(Of String)
    Private errorList As New List(Of Integer)

    Private Sub dgvLedger_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If Not txtFilter.Focused And Not m_strCurrentFile = "" Then

            Select Case e.KeyCode
                Case Keys.Space
                    DataCon.ToggleCleared()
                Case Keys.Delete
                    DeleteTransaction()
                Case Else
                    Exit Sub
            End Select

        End If

    End Sub

    Private Sub dgvLedger_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLedger.CellClick

        Dim intReceiptIndex As Integer = 9
        Dim intClearedIndex As Integer = 8

        If e.ColumnIndex = intReceiptIndex Then
            viewReceipt()
        End If

        If e.ColumnIndex = intClearedIndex Then
            DataCon.ToggleCleared()
        End If

    End Sub

    Private Sub LedgerSelectedIndexChanged(sender As Object, e As EventArgs) Handles dgvLedger.SelectionChanged

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim new_frmNewCheckbookLedger As New frmNewCheckbookLedger

        If new_frmNewCheckbookLedger.ShowDialog = DialogResult.OK Then

            Dim strNew_fullFile As String = String.Empty
            Dim strStartBalance As String = String.Empty
            Dim strNew_fileName As String = String.Empty

            strNew_fileName = new_frmNewCheckbookLedger.txtNewLedger.Text
            strNew_fullFile = AppendLedgerDirectory(strNew_fileName)

            If IO.File.Exists(strNew_fullFile) Then

                CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The ledger '" & strNew_fileName & "' already exists. Provide a unique name for your ledger.", Exclamation)

            Else

                Try

                    strStartBalance = new_frmNewCheckbookLedger.txtStartBalance.Text

                    Me.Show()
                    Me.Activate()

                    m_strCurrentFile = strNew_fullFile 'SAVES NEW NAME FOR LATER USE

                    File.CreateNewLedger_AccessDatabase(m_strCurrentFile) 'CREATES NEW DATABASE WITH ADOX OBJECTS

                    IO.Directory.CreateDirectory(AppendReceiptDirectory(m_strCurrentFile))

                    'CREATE SETTINGS FILE
                    CreateLedgerSettings_SetDefaults()

                    'LOAD TOOLBAR BUTTONS
                    LoadButtonSettings_Or_CreateDefaultButtons()

                    'SETS APPLICATION TITLE
                    Me.Text = "Checkbook - " & strNew_fileName

                    'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                    FileCon.Connect()
                    FileCon.SQLinsert("INSERT INTO StartBalance (Balance) VALUES('" & strStartBalance & "')")
                    FileCon.SQLselect(FileCon.strSelectAllQuery)
                    FileCon.Fill_Format_DataGrid()
                    FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                    'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
                    DataCon.LedgerStatus()

                    File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

                    UIManager.UpdateStatusStripInfo()

                    'ENABLES ALL MENU AND TOOLSTRIP ITEMS IF STRFILE IS NOT EMPTY
                    UIManager.Maintain_DisabledMainFormUI()

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Create New Error", MsgButtons.OK, "An error occurred while creating the new ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                Finally

                    'CLOSES THE DATABASE
                    FileCon.Close()

                End Try

            End If

        End If

    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click

        Dim new_frmMyCheckbookLedgers As New frmMyCheckbookLedgers
        new_frmMyCheckbookLedgers.ShowDialog()

    End Sub

    Private Sub mnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click

        Dim new_frmSaveAs As New frmSaveAs
        new_frmSaveAs.ShowDialog()

    End Sub

    Private Sub mnuNewTrans_Click(sender As Object, e As EventArgs) Handles mnuNewTrans.Click, cxmnuNewTrans.Click

        dgvLedger.ClearSelection()
        Dim new_frmTransaction As New frmTransaction
        m_frmTrans = new_frmTransaction
        m_frmTrans.ShowDialog()

    End Sub

    Private Sub mnuDeleteTrans_Click(sender As Object, e As EventArgs) Handles mnuDeleteTrans.Click, cxmnuDeleteTrans.Click

        DeleteTransaction()

    End Sub

    Private Sub mnuEditTrans_Click(sender As Object, e As EventArgs) Handles mnuEditTrans.Click, cxmnuEditTrans.Click, dgvLedger.DoubleClick

        If Not m_strCurrentFile = "" Then

            EditTransaction()

        End If

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click

        Me.Dispose()

    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        GetAndSetColumnWidths()

    End Sub

    Private Sub tmrFilterTimer_Tick(sender As Object, e As EventArgs) Handles tmrFilterTimer.Tick

        intFilterTimerInterval += 1

        If intFilterTimerInterval = 25 Then

            If Not txtFilter.Text = String.Empty Then

                FilterLedger()
                tmrFilterTimer.Stop()

            Else

                'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery)
                FileCon.Fill_Format_DataGrid()
                FileCon.Close()

            End If

        End If

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub txtFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilter.KeyDown

        If e.KeyCode = Keys.OemOpenBrackets Or e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemCloseBrackets Then

            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        If m_ledgerIsBeingFiltered And txtFilter.Focused Then

            intFilterTimerInterval = 0
            tmrFilterTimer.Start()

        End If

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Dim colorRenderer_Professional As New clsUIManager.MyProfessionalRenderer
        Dim colorRenderer_System As New clsUIManager.MySystemRenderer

        mnuMenuStrip.Renderer = colorRenderer_Professional
        tsToolStrip.Renderer = colorRenderer_System
        cxmnuDataGridMenu.Renderer = colorRenderer_Professional

        DownloadUpdateProgressBar.Visible = False
        DownloadUpdateLabel.Text = ""

        gbFilter.Visible = False

        m_groupAllControls_MainForm.Clear()
        m_groupAccountDetailTextboxes.Clear()

        'ADDS CONTROLS TO A LIST SO YOU CAN SET DRAWING CONTROL METHODS TO THEM IN A GROUP
        m_groupAllControls_MainForm.Add(tsToolStrip)
        m_groupAllControls_MainForm.Add(mnuMenuStrip)
        m_groupAllControls_MainForm.Add(dgvLedger)
        m_groupAllControls_MainForm.Add(stStatusStrip)
        m_groupAllControls_MainForm.Add(gbAccountDetails)

        m_groupAccountDetailTextboxes.Add(txtStartingBalance)
        m_groupAccountDetailTextboxes.Add(txtTotalPayments)
        m_groupAccountDetailTextboxes.Add(txtTotalDeposits)
        m_groupAccountDetailTextboxes.Add(txtOverallBalance)
        m_groupAccountDetailTextboxes.Add(txtClearedBalance)
        m_groupAccountDetailTextboxes.Add(txtLedgerStatus)

        'CREATE CHECKBOOK DIRECTORIES
        'CREATE My CHECKBOOK LEDGERS IF IT DOESNT ALREADY EXIST
        'CREATE RECEIPTS FOLDER IF IT DOESNT ALREADY EXIST
        'CREATE SETTINGS FOLDER IF IT DOESNT ALREADY EXIST
        CreateCheckbookDirectories()

        File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

        UIManager.Maintain_DisabledMainFormUI()

    End Sub

    Private Sub CreateCheckbookDirectories()

        Dim strMyCheckbookLedgers_DIRECTORY As String = String.Empty
        Dim strReceipts_DIRECTORY As String = String.Empty
        Dim strBudgets_DIRECTORY As String = String.Empty
        Dim strSettings_DIRECTORY As String = String.Empty

        strMyCheckbookLedgers_DIRECTORY = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\"
        strReceipts_DIRECTORY = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Receipts\"
        strBudgets_DIRECTORY = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\"
        strSettings_DIRECTORY = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Settings\"

        'CREATE MY CHECKBOOK LEDGERS
        If Not System.IO.Directory.Exists(strMyCheckbookLedgers_DIRECTORY) Then

            My.Computer.FileSystem.CreateDirectory(strMyCheckbookLedgers_DIRECTORY)

        End If

        'CREATE RECEIPTS DIECTORY
        If Not System.IO.Directory.Exists(strReceipts_DIRECTORY) Then

            My.Computer.FileSystem.CreateDirectory(strReceipts_DIRECTORY)

        End If

        'CREATE BUDGETS DIRECTORY
        If Not System.IO.Directory.Exists(strBudgets_DIRECTORY) Then

            My.Computer.FileSystem.CreateDirectory(strBudgets_DIRECTORY)

        End If

        'CREATE SETTINGS DIRECTORY 
        If Not System.IO.Directory.Exists(strSettings_DIRECTORY) Then

            My.Computer.FileSystem.CreateDirectory(strSettings_DIRECTORY)

        End If

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If MainModule.AccessIsInstalled = False Then

            Me.Hide()

            Dim new_frmInstallAccess As New frmInstallAccess
            new_frmInstallAccess.ShowDialog()

        End If

    End Sub

    Private Sub mnuSum_Click(sender As Object, e As EventArgs) Handles mnuSum.Click, cxmnuSumSelected.Click

        SumSelected()

    End Sub

    Private Sub mnuCategories_Click(sender As Object, e As EventArgs) Handles mnuCategories.Click

        Dim new_frmCategory As New frmCategory
        new_frmCategory.ShowDialog()

    End Sub

    Private Sub mnuPayees_Click(sender As Object, e As EventArgs) Handles mnuPayees.Click

        Dim new_frmPayee As New frmPayee
        new_frmPayee.ShowDialog()

    End Sub

    Private Sub mnuCalc_Click(sender As Object, e As EventArgs) Handles mnuCalc.Click

        System.Diagnostics.Process.Start("calc")

    End Sub

    Private Sub dgvLedger_CurrentCellChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvLedger.CellFormatting

        'FORMATS PAYMENT TO CURRENCY
        If dgvLedger.Columns(e.ColumnIndex).Name.Equals("Payment") Then

            If Not e.Value = "" Then

                e.Value = FormatCurrency(dgvLedger.Rows(e.RowIndex).Cells("Payment").Value)

            End If

        End If

        'FORMATS DEPOSIT TO CURRENCY
        If dgvLedger.Columns(e.ColumnIndex).Name.Equals("Deposit") Then

            If Not e.Value = "" Then

                e.Value = FormatCurrency(dgvLedger.Rows(e.RowIndex).Cells("Deposit").Value)

            End If

        End If

    End Sub

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtStartingBalance.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStartingBalance.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Public Sub SetMainFormMenuItemsAndToolbarButtonsEnabled_ToggleFilter()

        'MENU ITEMS
        mnuSpendingOverview.Enabled = True
        mnuMonthlyIncome.Enabled = True
        mnuBudgets.Enabled = True
        mnuBalanceAccount.Enabled = True
        mnuAdvancedFilter.Enabled = True
        mnuNew.Enabled = True
        mnuOpen.Enabled = True
        mnuSaveAs.Enabled = True
        mnuImportTrans.Enabled = True
        mnuOptions.Enabled = True
        mnuMostUsed.Enabled = True
        mnuCloseLedger.Enabled = True

        'TOOLBAR BUTTONS
        spending_overview_Button.Enabled = True
        monthly_income_Button.Enabled = True
        budgets_Button.Enabled = True
        balance_Button.Enabled = True
        advanced_filter_Button.Enabled = True
        new_ledger_Button.Enabled = True
        open_Button.Enabled = True
        save_as_Button.Enabled = True
        import_trans_Button.Enabled = True
        options_Button.Enabled = True
        mostUsed_Button.Enabled = True
        close_ledger_Button.Enabled = True

    End Sub

    Public Sub SetMainFormMenuItemsAndToolbarButtonsDisabled_ToggleFilter()

        'MENU ITEMS
        mnuSpendingOverview.Enabled = False
        mnuMonthlyIncome.Enabled = False
        mnuBudgets.Enabled = False
        mnuBalanceAccount.Enabled = False
        mnuAdvancedFilter.Enabled = False
        mnuNew.Enabled = False
        mnuOpen.Enabled = False
        mnuSaveAs.Enabled = False
        mnuImportTrans.Enabled = False
        mnuOptions.Enabled = False
        mnuMostUsed.Enabled = False
        mnuCloseLedger.Enabled = False

        'TOOLBAR BUTTONS
        spending_overview_Button.Enabled = False
        monthly_income_Button.Enabled = False
        budgets_Button.Enabled = False
        balance_Button.Enabled = False
        advanced_filter_Button.Enabled = False
        new_ledger_Button.Enabled = False
        open_Button.Enabled = False
        save_as_Button.Enabled = False
        import_trans_Button.Enabled = False
        options_Button.Enabled = False
        mostUsed_Button.Enabled = False
        close_ledger_Button.Enabled = False

    End Sub

    Private Sub ToggleFilter(ByVal _objectClicked As Object, Optional ByVal _secondaryObjectToToggle As Object = Nothing)

        _objectClicked.Checked = Not (_objectClicked.Checked)
        If _objectClicked.Checked = True Then
            m_ledgerIsBeingFiltered = True

            SetMainFormMenuItemsAndToolbarButtonsDisabled_ToggleFilter()

            _secondaryObjectToToggle.Checked = True
            gbFilter.Visible = True
            txtFilter.Text = ""
            txtFilter.Focus()
            dgvLedger.ClearSelection()

        End If
        If _objectClicked.Checked = False Then
            m_ledgerIsBeingFiltered = False

            SetMainFormMenuItemsAndToolbarButtonsEnabled_ToggleFilter()

            _secondaryObjectToToggle.Checked = False
            gbFilter.Visible = False
            txtFilter.Text = ""

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_DataGrid()
            FileCon.Close()

            dgvLedger.Sort(dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            dgvLedger.ClearSelection()

            UIManager.SetCursor(Me, Cursors.Default)

        End If

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub filter_Button_Click(sender As System.Object, e As System.EventArgs)

        If Not m_TransactionCount = 0 Then

            ToggleFilter(sender, mnuFilter)

        Else

            If Not m_ledgerIsBeingFiltered Then

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                CheckbookMsg.ShowMessage("Your ledger does not have any transactions to filter", MsgButtons.OK, "", Exclamation)

            Else

                ToggleFilter(sender, mnuFilter)

            End If

        End If

    End Sub

    Private Sub mnuFilter_Click(sender As System.Object, e As System.EventArgs) Handles mnuFilter.Click

        If Not m_TransactionCount = 0 Then

            ToggleFilter(sender, filter_Button)

        Else

            If Not m_ledgerIsBeingFiltered Then

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                CheckbookMsg.ShowMessage("Your ledger does not have any transactions to filter", MsgButtons.OK, "", Exclamation)

            Else

                ToggleFilter(sender, filter_Button)

            End If

        End If

    End Sub

    Public Sub ToggleBalanceAccount(ByVal _objectClicked As Object, Optional ByVal _secondaryObjectToToggle As Object = Nothing)

        _objectClicked.Checked = Not (_objectClicked.Checked)
        If _objectClicked.Checked = True Then
            m_ledgerIsBeingBalanced = True

            'MENU ITEMS
            mnuSpendingOverview.Enabled = False
            mnuMonthlyIncome.Enabled = False
            mnuBudgets.Enabled = False
            mnuNew.Enabled = False
            mnuOpen.Enabled = False
            mnuSaveAs.Enabled = False
            mnuImportTrans.Enabled = False
            mnuOptions.Enabled = False
            mnuMostUsed.Enabled = False
            mnuFilter.Enabled = False
            mnuAdvancedFilter.Enabled = False
            mnuCloseLedger.Enabled = False

            'TOOLBAR BUTTONS
            spending_overview_Button.Enabled = False
            monthly_income_Button.Enabled = False
            budgets_Button.Enabled = False
            new_ledger_Button.Enabled = False
            open_Button.Enabled = False
            save_as_Button.Enabled = False
            import_trans_Button.Enabled = False
            options_Button.Enabled = False
            mostUsed_Button.Enabled = False
            filter_Button.Enabled = False
            advanced_filter_Button.Enabled = False
            close_ledger_Button.Enabled = False

            _secondaryObjectToToggle.Checked = True
            UIManager.SetCursor(Me, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery & " WHERE Cleared=False")
            FileCon.Fill_Format_DataGrid()
            FileCon.Close()

            dgvLedger.Sort(dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Ascending)
            dgvLedger.ClearSelection()

            UIManager.SetCursor(Me, Cursors.Default)

        End If
        If _objectClicked.Checked = False Then
            m_ledgerIsBeingBalanced = False

            'MENU ITEMS
            mnuSpendingOverview.Enabled = True
            mnuMonthlyIncome.Enabled = True
            mnuBudgets.Enabled = True
            mnuNew.Enabled = True
            mnuOpen.Enabled = True
            mnuSaveAs.Enabled = True
            mnuImportTrans.Enabled = True
            mnuOptions.Enabled = True
            mnuMostUsed.Enabled = True
            mnuFilter.Enabled = True
            mnuAdvancedFilter.Enabled = True
            mnuCloseLedger.Enabled = True

            'TOOLBAR BUTTONS
            spending_overview_Button.Enabled = True
            monthly_income_Button.Enabled = True
            budgets_Button.Enabled = True
            new_ledger_Button.Enabled = True
            open_Button.Enabled = True
            save_as_Button.Enabled = True
            import_trans_Button.Enabled = True
            options_Button.Enabled = True
            mostUsed_Button.Enabled = True
            filter_Button.Enabled = True
            advanced_filter_Button.Enabled = True
            close_ledger_Button.Enabled = True

            _secondaryObjectToToggle.Checked = False

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_DataGrid()
            FileCon.Close()

            dgvLedger.Sort(dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            dgvLedger.ClearSelection()

            UIManager.SetCursor(Me, Cursors.Default)

        End If

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub balance_Button_Click(sender As System.Object, e As System.EventArgs)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strOverallBalance As String = txtOverallBalance.Text
        Dim strClearedBalance As String = txtClearedBalance.Text

        If Not m_ledgerIsBeingBalanced Then 'MAKES SURE THE LEDGER IS NOT ALREADY BEING BALANCED. BECAUSE WE CLICK THE SAME BUTTON TO TOGGLE IT OFF. WE DONT NEED TO CHECK IF WE ARE BALANCING

            If strClearedBalance = strOverallBalance Then

                CheckbookMsg.ShowMessage("Your ledger is already balanced. Your Cleared Balance is the same as your Overall Balance.", MsgButtons.OK, "", Exclamation)

            Else

                ToggleBalanceAccount(sender, mnuBalanceAccount)

            End If

        Else

            ToggleBalanceAccount(sender, mnuBalanceAccount)

        End If

    End Sub

    Private Sub mnuBalanceAccount_Click(sender As System.Object, e As System.EventArgs) Handles mnuBalanceAccount.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strOverallBalance As String = txtOverallBalance.Text
        Dim strClearedBalance As String = txtClearedBalance.Text

        If Not m_ledgerIsBeingBalanced Then 'MAKES SURE THE LEDGER IS NOT ALREADY BEING BALANCED. BECAUSE WE CLICK THE SAME BUTTON TO TOGGLE IT OFF. WE DONT NEED TO CHECK IF WE ARE BALANCING

            If strClearedBalance = strOverallBalance Then

                CheckbookMsg.ShowMessage("Your ledger is already balanced. Your Cleared Balance is the same as your Overall Balance.", MsgButtons.OK, "", Exclamation)

            Else

                ToggleBalanceAccount(sender, balance_Button)

            End If

        Else

            ToggleBalanceAccount(sender, balance_Button)

        End If

    End Sub

    Private Sub mnuSpendingOverview_Click(sender As Object, e As EventArgs) Handles mnuSpendingOverview.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intRowCount As Integer = Nothing

        intRowCount = Me.dgvLedger.Rows.Count

        If Not intRowCount = 0 Then

            Dim new_frmSpendingOverview As New frmSpendingOverview
            new_frmSpendingOverview.ShowDialog()

        Else

            CheckbookMsg.ShowMessage("Your ledger does not have any transactions to calculate", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub mnuMonthlyIncome_Click(sender As Object, e As EventArgs) Handles mnuMonthlyIncome.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intRowCount As Integer = Nothing

        intRowCount = Me.dgvLedger.Rows.Count

        If Not intRowCount = 0 Then

            Dim new_frmMonthly As New frmMonthly
            new_frmMonthly.ShowDialog()

        Else

            CheckbookMsg.ShowMessage("Your ledger does not have any transactions to calculate", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub mnuEditStartingBalance_Click(sender As Object, e As EventArgs) Handles mnuEditStartingBalance.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strStartBalance As String = String.Empty

        Dim new_frmEditValues As New frmEditValues

        new_frmEditValues.Icon = My.Resources.StartBalance
        new_frmEditValues.Text = "Edit Starting Balance"

        If new_frmEditValues.ShowDialog = DialogResult.OK Then

            strStartBalance = new_frmEditValues.txtNewExpenseValue.Text

            If CheckbookMsg.ShowMessage("Are you want to update your starting balance with " & strStartBalance & "?", MsgButtons.YesNo, "", Media.SystemSounds.Question) = DialogResult.Yes Then

                Try

                    FileCon.Connect()
                    FileCon.SQLupdate("UPDATE StartBalance SET Balance ='" & strStartBalance & "' WHERE ID = 1")
                    FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                    'CALCULATES OVERALL BALANCE WITH NEW STARTING BALANCE
                    DataCon.LedgerStatus()
                    FileCon.Close()

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                    Exit Sub

                End Try

            End If

        End If

    End Sub

    Private Sub mnuEditType_Click(sender As Object, e As EventArgs) Handles mnuEditType.Click, cxmnuEditType.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditType As New frmEditType
            new_frmEditType.ShowDialog()

        End If

    End Sub

    Private Sub mnuEditCategory_Click(sender As Object, e As EventArgs) Handles mnuEditCategory.Click, cxmnuEditCategory.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditCategory As New frmEditCategory
            new_frmEditCategory.ShowDialog()

        End If

    End Sub

    Private Sub mnuEditTransDate_Click(sender As Object, e As EventArgs) Handles mnuEditTransDate.Click, cxmnuEditTransDate.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditTransDate As New frmEditTransDate
            new_frmEditTransDate.ShowDialog()

        End If

    End Sub

    Private Sub mnuEditPayment_Click(sender As Object, e As EventArgs) Handles mnuEditPayment.Click, cxmnuEditPayment.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditPayment As New frmEditPayment
            new_frmEditPayment.ShowDialog()

        End If

    End Sub

    Private Sub mnuEditDeposits_Click(sender As Object, e As EventArgs) Handles mnuEditDeposit.Click, cxmnuEditDeposit.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditDeposit As New frmEditDeposit
            new_frmEditDeposit.ShowDialog()

        End If

    End Sub

    Private Sub mnuEditPayee_Click(sender As Object, e As EventArgs) Handles mnuEditPayee.Click, cxmnuEditPayee.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditPayee As New frmEditPayee
            new_frmEditPayee.ShowDialog()

        End If

    End Sub

    Private Sub mnuClearSelected_Click(sender As Object, e As EventArgs) Handles mnuClearSelected.Click, cxmnuClearSelected.Click

        DataCon.ClearSelectedWithButton_MenuItem(Yes)

    End Sub

    Private Sub mnuUnclearSelected_Click(sender As Object, e As EventArgs) Handles mnuUnclearSelected.Click, cxmnuUnclearSelected.Click

        DataCon.ClearSelectedWithButton_MenuItem(No)

    End Sub

    Private Sub mnuOptions_Click(sender As Object, e As EventArgs) Handles mnuOptions.Click

        Dim new_frmOptions As New frmOptions
        new_frmOptions.ShowDialog()

    End Sub

    Private Sub dgvLedger_MouseMove(sender As Object, e As EventArgs) Handles dgvLedger.MouseMove

        GetAndSetColumnWidths()

    End Sub

    Private Sub dgvLedger_MouseEnter(sender As Object, e As EventArgs) Handles dgvLedger.MouseEnter

        GetAndSetColumnWidths()

    End Sub

    Private Sub dgvLedger_MouseLeave(sender As Object, e As EventArgs) Handles dgvLedger.MouseLeave

        GetAndSetColumnWidths()

    End Sub

    Private Sub cxmnuResetDefault_Click(sender As Object, e As EventArgs) Handles cxmnuResetDefault.Click

        'FORMATS DATAGRIDVIEW
        With Me.dgvLedger

            'TYPE
            .Columns("Type").Width = 100

            'CATEGORY
            .Columns("Category").Width = 150

            'TRANSDATE
            .Columns("TransDate").Width = 100

            'PAYMENT
            .Columns("Payment").Width = 75

            'DEPOSIT
            .Columns("Deposit").Width = 75

            'PAYEE
            .Columns("Payee").Width = 150

            'DESCRIPTION
            .Columns("Description").Width = 200

        End With

    End Sub

    Private Sub dgvLedger_Sorted(sender As Object, e As EventArgs) Handles dgvLedger.Sorted

        If Not m_DATA_IS_BEING_LOADED Then

            'FORMATS UNCLEARED TRANSACTIONS
            FormatUncleared()

            'SHOWS THE UNCLEARED IMAGE IF TRANSACTION IS NOT CLEARED
            CheckIfTransactionIsUnCleared()

            'SHOWS THE RECEIPT IMAGE IF A RECEIPT EXISTS
            CheckIfReceiptExists()

        End If

    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click

        Dim new_frmAbout As New frmAbout
        new_frmAbout.ShowDialog()

    End Sub

    Private Sub mnuUnCatUnknownMessage_Click(sender As Object, e As EventArgs) Handles mnuUnCatUnknownMessage.Click

        DataCon.Show_Uncategorized_Unknown_Message_FromMenu()

    End Sub

    Private Sub receipt_Button_Click(sender As Object, e As EventArgs) Handles cxmnuViewReceipt.Click, mnuViewReceipt.Click

        viewReceipt()

    End Sub

    Private Sub btnClearFilter_MouseHover(sender As Object, e As EventArgs) Handles btnClearFilter.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnClearFilter, "Clear Filter")

    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click

        txtFilter.Text = String.Empty

        'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
        FileCon.Connect()
        FileCon.SQLselect(FileCon.strSelectAllQuery)
        FileCon.Fill_Format_DataGrid()
        FileCon.Close()

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub EditTransaction()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        ElseIf intSelectedRowCount > 1 Then

            cxmnuDataGridMenu.Hide()
            CheckbookMsg.ShowMessage("You can only open one transaction at a time", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmTransaction As New frmTransaction
            m_frmTrans = new_frmTransaction
            m_frmTrans.ShowDialog()

        End If

    End Sub

    Private Sub DeleteTransaction()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("There are no items selected to delete", MsgButtons.OK, "", Exclamation)

        ElseIf CheckbookMsg.ShowMessage("Are you sure you want to delete the selected transaction(s)?", MsgButtons.YesNo, "Deleting a transacation cannot be undone.", Question) = DialogResult.Yes Then

            Try

                UIManager.SetCursor(Me, Cursors.WaitCursor)

                DataCon.DeleteSelected()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Delete Error", MsgButtons.OK, "An error occurred while attempting to delete the selected transaction(s)", Exclamation)

            Finally

                FileCon.Close()
                UIManager.SetCursor(Me, Cursors.Default)

            End Try

        End If

    End Sub

    Private Sub viewReceipt()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("There are no items selected to view a receipt", MsgButtons.OK, "", Exclamation)

        ElseIf intSelectedRowCount > 1 Then

            CheckbookMsg.ShowMessage("You can only view one receipt at a time", MsgButtons.OK, "", Exclamation)

        Else

            With Me.dgvLedger

                Dim i As Integer
                Dim strReceiptFromDGV As String

                i = .CurrentRow.Index
                strReceiptFromDGV = .Item("Receipt", i).Value.ToString()

                If strReceiptFromDGV = String.Empty Then

                    CheckbookMsg.ShowMessage("This transaction does not have a receipt attached", MsgButtons.OK, "", Exclamation)

                Else

                    'CHECK IF FILE EXISTS
                    Dim strReceipt_fullFile As String = String.Empty
                    strReceipt_fullFile = AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, strReceiptFromDGV)

                    If Not System.IO.File.Exists(strReceipt_fullFile) Then

                        CheckbookMsg.ShowMessage("The receipt for this transaction does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

                    Else

                        Process.Start(strReceipt_fullFile)

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub SumSelected()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to calculate", MsgButtons.OK, "", Exclamation)

        Else

            Dim strMessage As String = "Payments: " & DataCon.SumPayments & vbNewLine & "Deposits: " & DataCon.SumDeposits

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, "")

        End If

    End Sub

    Private Sub mnuLoanCalculator_Click(sender As Object, e As EventArgs) Handles mnuLoanCalculator.Click

        Dim new_frmLoanCalculator As New frmLoanCalculator
        new_frmLoanCalculator.Show()

    End Sub

    Public Sub OpenLedger_Click(ByVal sender As Object, ByVal e As EventArgs)

        'SETS ALL TEXTBOXES ON MAINFORM TO EMPTY CONTENTS AND WHITE BACKGROUND
        UIManager.SetAllTexboxes_Contents_Backcolor_Forecolor_Visible_Enabled("$0.00", Color.White, Color.Black, True, False)

        Dim menuItem As ToolStripMenuItem
        menuItem = CType(sender, ToolStripMenuItem) 'GETS THE OBJECT CLICKED AND CONVERTS IT TO A MENU ITEM

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strSelected_fileName As String = String.Empty

        intTime = 0

        strSelected_fileName = menuItem.Text

        Dim strFileToOpen_fullFile As String
        strFileToOpen_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & strSelected_fileName & ".cbk"

        m_strCurrentFile = strFileToOpen_fullFile

        'CREATE SETTINGS FILE
        CreateLedgerSettings_SetDefaults()

        'LOAD TOOLBAR BUTTONS
        LoadButtonSettings_Or_CreateDefaultButtons()

        Try

            'SETS APPLICATION TITLE
            Me.Text = "Checkbook - " & strSelected_fileName

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_DataGrid()
            FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

            'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
            DataCon.LedgerStatus()

            'STARTS THE TIMER ON FRMMYCHECKBOOKLEDGERS
            tmrTimer.Start()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Open Error", MsgButtons.OK, "An error occurred while opening the ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

        Finally

            'CLOSES THE DATABASE
            FileCon.Close()

            UIManager.SetCursor(Me, Cursors.Default)

            'ENABLES ALL MENU AND TOOLSTRIP ITEMS IF STRFILE IS NOT EMPTY
            UIManager.Maintain_DisabledMainFormUI()

            UIManager.UpdateStatusStripInfo()

        End Try

    End Sub

    Private Sub tmrTimer_Tick(sender As Object, e As EventArgs) Handles tmrTimer.Tick

        intTime += 1

        If intTime = 1 Then

            DataCon.Show_Uncategorized_Unknown_Message_FromOpen()
            tmrTimer.Stop()

        End If

    End Sub

    Private Sub mnuFile_Click(sender As Object, e As EventArgs) Handles mnuFile.DropDownOpening

        File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

    End Sub

    Private Sub mnuCheckforUpdate_Click(sender As Object, e As EventArgs) Handles mnuCheckforUpdate.Click

        CheckForUpdate()

    End Sub

    Private Sub CheckForUpdate()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strVersionTextWebFilePath As String = String.Empty
        Dim strVersionFromTextFile As String = String.Empty

        strVersionTextWebFilePath = "https://cmackay732.github.io/CheckbookWebsite/all_installer_versions/latest_version/Version.txt"

        Dim strCheckbookSetupFileToDownload As String = String.Empty

        strCheckbookSetupFileToDownload = "https://cmackay732.github.io/CheckbookWebsite/all_installer_versions/latest_version/Checkbook Setup.exe"

        Try

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            Dim webClient As New System.Net.WebClient
            Dim strVersionTextFile_Version_WithPeriod As String = String.Empty
            Dim strVersionTextFile_Version_WithoutPeriod As String = String.Empty

            Dim strCheckbookVersion_WithoutPeriod As String = String.Empty
            Dim strCheckbookVersion_WithPeriod As String = String.Empty

            'STREAMREADER
            Dim fileStream As System.IO.Stream
            fileStream = webClient.OpenRead(strVersionTextWebFilePath)

            Dim streamReader As New System.IO.StreamReader(fileStream)

            strVersionTextFile_Version_WithPeriod = streamReader.ReadToEnd

            strVersionTextFile_Version_WithPeriod = strVersionTextFile_Version_WithPeriod.Trim

            latestVersionFromDropbox = strVersionTextFile_Version_WithPeriod

            strVersionTextFile_Version_WithoutPeriod = strVersionTextFile_Version_WithPeriod.Replace(".", "") 'REPLACES PERIOD WITH NOTHING SO YOU CAN TEST IF THE NUMBER IS GREATER AS AN INTEGER

            strCheckbookVersion_WithPeriod = CheckbookProductInfo.Version

            strCheckbookVersion_WithoutPeriod = strCheckbookVersion_WithPeriod.Replace(".", "") 'REPLACES PERIOD WITH NOTHING SO YOU CAN TEST IF THE NUMBER IS GREATER AS AN INTEGER

            If strVersionTextFile_Version_WithPeriod = strCheckbookVersion_WithPeriod Then 'CHECKS IF YOU ALREADY HAVE THE LATEST VERSION

                CheckbookMsg.ShowMessage("Your version of Checkbook (" & strCheckbookVersion_WithPeriod & ") is up to date.", MsgButtons.OK, "", Media.SystemSounds.Exclamation)

            ElseIf CInt(strVersionTextFile_Version_WithoutPeriod) > CInt(strCheckbookVersion_WithoutPeriod) Then 'CHECKS IF YOUR VERSION IS OLD

                If CheckbookMsg.ShowMessage("A newer version of Checkbook is available (" & strVersionTextFile_Version_WithPeriod & "). Would you like to download it now?", MsgButtons.YesNo, "", Media.SystemSounds.Question) = DialogResult.Yes Then

                    Dim dlgFolderDialog As New FolderBrowserDialog
                    dlgFolderDialog.ShowNewFolderButton = True
                    dlgFolderDialog.Description = "Select a location where you would like to save Checkbook Setup - v" & strVersionTextFile_Version_WithPeriod & ".exe"

                    Dim strDownloadPath As String = String.Empty

                    If dlgFolderDialog.ShowDialog = DialogResult.OK Then

                        Dim strDownloadedFile_fullFile As String = String.Empty
                        Dim strFileName As String = String.Empty

                        strDownloadPath = dlgFolderDialog.SelectedPath

                        strFileName = "Checkbook Setup - v" & strVersionTextFile_Version_WithPeriod & ".exe"

                        strDownloadedFile_fullFile = strDownloadPath & "\" & strFileName

                        If Not System.IO.File.Exists(strDownloadedFile_fullFile) Then

                            m_NEW_VERSION_IS_BEING_DOWNLOADED = True
                            DownloadUpdateProgressBar.Value = 0
                            DownloadUpdateProgressBar.Visible = True
                            DownloadUpdateLabel.Text = "Downloading Checkbook Setup - v" & strVersionTextFile_Version_WithPeriod & ".exe..."
                            stLabel.Text = ""

                            AddHandler webClient.DownloadProgressChanged, AddressOf client_ProgressChanged
                            AddHandler webClient.DownloadFileCompleted, AddressOf client_DownloadCompleted

                            webClient.DownloadFileAsync(New Uri(strCheckbookSetupFileToDownload), strDownloadedFile_fullFile)

                        Else

                            CheckbookMsg.ShowMessage("'" & strFileName & "' already exists.", MsgButtons.OK, "You already have a copy of this file saved in this location.", Media.SystemSounds.Exclamation)

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("An error occurred. Please report the error message below.", MsgButtons.OK, ex.Message & vbNewLine & vbNewLine & "Please take a screen shot of this error message and send it to the email address below." & vbNewLine & vbNewLine & "chkbookapp@gmail.com", Media.SystemSounds.Exclamation)

        Finally

            UIManager.SetCursor(Me, Cursors.Default)

        End Try

    End Sub

    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        Dim dblBytesIn As Double = Double.Parse(e.BytesReceived.ToString())

        Dim dblTotalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())

        Dim dblPercentage As Double = dblBytesIn / dblTotalBytes * 100

        DownloadUpdateProgressBar.Value = Int32.Parse(Math.Truncate(dblPercentage).ToString())

    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        CheckbookMsg.ShowMessage("You have downloaded version " & latestVersionFromDropbox & ".", MsgButtons.OK, "To install the latest version please close Checkbook and run the installer.", Media.SystemSounds.Exclamation)

        m_NEW_VERSION_IS_BEING_DOWNLOADED = False
        DownloadUpdateProgressBar.Value = 0
        DownloadUpdateProgressBar.Visible = False
        DownloadUpdateLabel.Text = ""
        If m_strCurrentFile = "" Then stLabel.Text = "Create a new ledger or open an existing ledger." Else UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub mnuImportTrans_Click(sender As Object, e As EventArgs) Handles mnuImportTrans.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dlgOpenDialog As New OpenFileDialog
        'SET OPEN DIALOG PROPERTIES
        dlgOpenDialog.Filter = "csv files (*.csv)|*.csv"
        dlgOpenDialog.FilterIndex = 1
        dlgOpenDialog.RestoreDirectory = True
        dlgOpenDialog.Title = "Select a file to import transactions"

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory) = String.Empty Then

            dlgOpenDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        Else

            dlgOpenDialog.InitialDirectory = GetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory)

        End If

        Dim strFile As String = String.Empty

        If dlgOpenDialog.ShowDialog = DialogResult.OK Then

            strFile = dlgOpenDialog.FileName

            If CheckbookMsg.ShowMessage("Are you sure you want import transactions from " & strFile & "?", MsgButtons.YesNo, "Consider making a backup copy of your ledger in 'My Checkbook Ledgers' before importing transactions." & vbNewLine & vbNewLine & "Imported transactions are cleared by default. If you have not provided a category or payee for a transaction they will be set to Uncategorized or Unknown.", Media.SystemSounds.Question) = DialogResult.Yes Then

                Try

                    CheckValidTransactions(strFile)

                Catch exFileIsOpen As System.IO.IOException

                    CheckbookMsg.ShowMessage("The file you have provided is currently open. To import transactions from this file it must be closed.", MsgButtons.OK, "", Media.SystemSounds.Exclamation)
                    Exit Sub

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("An error occured while importing transactions.", MsgButtons.OK, "Make sure your spreadsheet is formatted properly. Consult Checkbook Help for proper formatting.", Exclamation)
                    Exit Sub

                End Try

                If errorList.Count = 0 Then

                    ImportValidTransactions(strFile)

                ElseIf errorList.Count > 0 Then

                    Dim errorRows As String = String.Empty

                    For Each intRowLine As Integer In errorList

                        errorRows = errorRows & "Row #" & intRowLine & vbNewLine

                    Next

                    If CheckbookMsg.ShowMessage("Some of your transactions contain invalid data. The following rows in your file contain errors:" & vbNewLine & vbNewLine & errorRows & vbNewLine & "Make sure the date (C column), payment (D column), and/or deposit (E column) values do not contain letters or any other characters that do not represent a date or money value.", MsgButtons.YesNo, "Would you like to import the valid transactions? Once the valid transactions are imported delete them from your file to avoid duplicate imports, fix the errors and try again.", Question) = DialogResult.Yes Then

                        ImportValidTransactions(strFile)

                    End If

                End If

            End If

        End If

    End Sub

    ''' <summary>
    ''' Checks and makes sure the provided entries contain valid values. Fills a list of valid transactions (transactionList) that can be imported. 
    ''' </summary>
    ''' <param name="file"></param>
    Private Sub CheckValidTransactions(ByVal file As String)

        Dim csvLine As String = String.Empty
        Dim reader As New StreamReader(file)
        Dim blnInvalidValueFlag As Boolean = False
        Dim intCurrentRow As Integer = 1

        transactionList.Clear()
        errorList.Clear()

        While Not reader.EndOfStream
            Dim arrValues As String() = reader.ReadLine.Split(","c)

            Dim strType As String = String.Empty
            Dim strCategory As String = String.Empty
            Dim objTransDate As Object
            Dim objPayment As Object
            Dim objDeposit As Object
            Dim strPayee As String = String.Empty
            Dim strDescription As String = String.Empty
            Dim strCleared As String = String.Empty
            Dim blnCleared As Boolean = True
            Dim strReceipt As String = String.Empty

            strType = arrValues(0)
            strCategory = arrValues(1)
            objTransDate = arrValues(2)
            objPayment = arrValues(3)
            objDeposit = arrValues(4)
            strPayee = arrValues(5)
            strDescription = arrValues(6)
            strCleared = arrValues(7)
            strReceipt = ""

            Try

                'MAKES SURE VALUES ARE VALID
                objTransDate = CType(objTransDate, Date)
                If Not objPayment = "" Then
                    objPayment = CType(objPayment, Double)
                End If

                If Not objDeposit = "" Then
                    objDeposit = CType(objDeposit, Double)
                End If

                'CONVERT OBJECTS TO PROPER TYPES
                objTransDate = CType(objTransDate, Date)
                objPayment = CType(objPayment, String)
                objDeposit = CType(objDeposit, String)

                'REASSIGNS NEW VALUES IF EMPTY
                If strCategory = "" Then arrValues(1) = "Uncategorized"
                If strCleared.ToUpper = "TRUE" Or strCleared.ToUpper = "FALSE" Then blnCleared = Boolean.Parse(strCleared) Else blnCleared = True
                If strPayee = "" Then arrValues(5) = "Unknown"

                'REASSIGNS NEW VALUES IF EMPTY
                strCategory = arrValues(1)
                strPayee = arrValues(5)

                Dim strEntry As String = strType & "," & strCategory & "," & objTransDate & "," & objPayment & "," & objDeposit & "," & strPayee & "," & strDescription & "," & strCleared

                transactionList.Add(strEntry)

            Catch ex As Exception

                blnInvalidValueFlag = True
                errorList.Add(intCurrentRow)

            Finally

                intCurrentRow += 1

            End Try

        End While

    End Sub

    ''' <summary>
    ''' If their are errors in the entries the user has the option to import the valid entries.
    ''' </summary>
    ''' <param name="_file"></param>
    Private Sub ImportValidTransactions(ByVal _file As String)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Try
            'LOAD ALL CATEGORIES AND PAYEES FROM LEDGER TO CHECK IF THEY DO NOT EXIST
            'IF THEY DONT EXIST IN THE LEDGER THEN ADD THEM

            FileCon.Connect()
            FileCon.SQLread_Fill_List("SELECT * FROM Categories", originalCategoryList)
            FileCon.SQLread_Fill_List("SELECT * FROM Payees", originalPayeeList)
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        newCategoryList.Clear()
        newPayeeList.Clear()

        Dim NewTrans As New clsTransaction

        UIManager.SetCursor(Me, Cursors.WaitCursor)

        Dim strType As String = String.Empty
        Dim strCategory As String = String.Empty
        Dim dtTransDate As Date = Nothing
        Dim strPayment As String = String.Empty
        Dim strDeposit As String = String.Empty
        Dim strPayee As String = String.Empty
        Dim strDescription As String = String.Empty
        Dim strCleared As String = String.Empty
        Dim blnCleared As Boolean = True
        Dim strReceipt As String = String.Empty

        For Each strEntry As String In transactionList

            Dim chrSeparator As Char() = New Char() {","c}
            Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

            strType = arrValues(0)
            strCategory = arrValues(1)
            dtTransDate = Date.Parse(arrValues(2))
            strPayment = arrValues(3)
            strDeposit = arrValues(4)
            strPayee = arrValues(5)
            strDescription = arrValues(6)
            strCleared = arrValues(7)
            strReceipt = ""

            'REASSIGNS NEW VALUES IF EMPTY
            If strCategory = "" Then arrValues(1) = "Uncategorized"
            If Not strPayment = "" Then strPayment = FormatCurrency(strPayment)
            If Not strDeposit = "" Then strDeposit = FormatCurrency(strDeposit)
            If strCleared.ToUpper = "TRUE" Or strCleared.ToUpper = "FALSE" Then blnCleared = Boolean.Parse(strCleared) Else blnCleared = True
            If strPayee = "" Then arrValues(5) = "Unknown"

            'REASSIGNS NEW VALUES IF EMPTY
            strCategory = arrValues(1)
            strPayee = arrValues(5)

            NewTrans.Type = strType
            NewTrans.Category = strCategory
            NewTrans.TransDate = dtTransDate
            NewTrans.Payment = strPayment
            NewTrans.Deposit = strDeposit
            NewTrans.Payee = strPayee
            NewTrans.Description = strDescription
            NewTrans.Cleared = blnCleared
            NewTrans.Receipt = strReceipt

            If Not originalCategoryList.Contains(NewTrans.Category) And Not newCategoryList.Contains(NewTrans.Category) And Not NewTrans.Category = "Uncategorized" Then

                newCategoryList.Add(NewTrans.Category)

            End If

            If Not originalPayeeList.Contains(NewTrans.Payee) And Not newPayeeList.Contains(NewTrans.Payee) And Not NewTrans.Payee = "Unknown" Then

                newPayeeList.Add(NewTrans.Payee)

            End If

            Try

                'CONNECTS TO DATABASE AND INSERTS NEW TRANSACTION DATA
                'FILLS THE DATAGRIDVIEW AND THE CLOSES CONNECTION
                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO LedgerData (Type,Category,TransDate,Payment,Deposit,Payee,Description,Cleared,Receipt) VALUES('" & NewTrans.Type & "','" & NewTrans.Category & "','" & NewTrans.TransDate & "','" & NewTrans.Payment & "','" & NewTrans.Deposit & "','" & NewTrans.Payee & "','" & NewTrans.Description & "'," & NewTrans.Cleared & ",'" & NewTrans.Receipt & "')")
                FileCon.Close()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Transaction Error", MsgButtons.OK, "An error occurred while creating the transaction. If you created a backup you should restore it now." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            End Try

        Next

        Try

            For Each newCategory As String In newCategoryList

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO Categories (Category) VALUES ('" & newCategory & "')")
                FileCon.Close()

            Next

            For Each newPayee As String In newPayeeList

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO Payees (Payee) VALUES ('" & newPayee & "')")
                FileCon.Close()

            Next

            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_DataGrid()
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Category/Payee Error", MsgButtons.OK, "An error occurred while updating your categories and/or payees. If you created a backup your should restore it now." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
        DataCon.LedgerStatus()

        Me.dgvLedger.ClearSelection()

        UIManager.UpdateStatusStripInfo()

        UIManager.SetCursor(Me, Cursors.Default)

        CheckbookMsg.ShowMessage("Your transactions have imported successfully.", MsgButtons.OK, "", Exclamation)

    End Sub

    Private Sub mnuCheckbookHelp_Click(sender As Object, e As EventArgs) Handles mnuCheckbookHelp.Click

        Dim webAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/checkbook_help.html"
        Process.Start(webAddress)

    End Sub

    Public Sub LoadButtonSettings_Or_CreateDefaultButtons()

        tsToolStrip.Items.Clear()

        fullListCommandsList.Clear()
        fullListCommandsList.Add("about")
        fullListCommandsList.Add("balance")
        fullListCommandsList.Add("calculator")
        fullListCommandsList.Add("categories")
        fullListCommandsList.Add("cleared")
        fullListCommandsList.Add("delete_trans")
        fullListCommandsList.Add("edit_trans")
        fullListCommandsList.Add("exit")
        fullListCommandsList.Add("filter")
        fullListCommandsList.Add("help")
        fullListCommandsList.Add("import_trans")
        fullListCommandsList.Add("loan_calculator")
        fullListCommandsList.Add("message")
        fullListCommandsList.Add("monthly_income")
        fullListCommandsList.Add("budgets")
        fullListCommandsList.Add("new_ledger")
        fullListCommandsList.Add("new_trans")
        fullListCommandsList.Add("open")
        fullListCommandsList.Add("options")
        fullListCommandsList.Add("payees")
        fullListCommandsList.Add("receipt")
        fullListCommandsList.Add("save_as")
        fullListCommandsList.Add("spending_overview")
        fullListCommandsList.Add("start_balance")
        fullListCommandsList.Add("sum_selected")
        fullListCommandsList.Add("uncleared")
        fullListCommandsList.Add("updates")
        fullListCommandsList.Add("most_used")
        fullListCommandsList.Add("export_trans")
        fullListCommandsList.Add("advanced_filter")
        fullListCommandsList.Add("duplicate_trans")
        fullListCommandsList.Add("close_ledger")

        'SETS ALL IMAGES
        img_about = My.Resources.about
        img_balance_account = My.Resources.balance_account
        img_calculator = My.Resources.calculator
        img_categories = My.Resources.categories
        img_cleared = My.Resources.cleared
        img_delete_trans = My.Resources.delete_trans
        img_edit_trans = My.Resources.edit_trans
        img_exit = My.Resources._exit
        img_filter = My.Resources.filter
        img_help = My.Resources.help
        img_import_trans = My.Resources.import_trans
        img_loan_calculator = My.Resources.loan_calculator
        img_message = My.Resources.message
        img_monthly_income = My.Resources.monthly_income
        img_budgets = My.Resources.budgets
        img_new_ledger = My.Resources.new_ledger
        img_new_trans = My.Resources.new_trans
        img_open = My.Resources.my_checkbook_ledgers
        img_options = My.Resources.options
        img_payees = My.Resources.payees
        img_receipt = My.Resources.receipt
        img_save_as = My.Resources.save_as
        img_spending_overview = My.Resources.spending_overview
        img_start_balance = My.Resources.start_balance
        img_sum_selected = My.Resources.sum_selected
        img_uncleared = My.Resources.uncleared
        img_updates = My.Resources.updates
        img_mostUsed = My.Resources.most_used
        img_export_trans = My.Resources.export_trans
        img_advanced_filter = My.Resources.advanced_filter
        img_duplicate_trans = My.Resources.duplicate_trans
        img_close_ledger_Button = My.Resources.close_ledger

        Dim defaultButtonList As String = "0|new_ledger,1|open,2|save_as,3|new_trans,4|delete_trans,5|edit_trans,6|cleared,7|uncleared,8|categories,9|payees,10|receipt,11|sum_selected,12|filter,13|balance"

        Dim toolBarButtonList As String = ""

        If System.IO.File.Exists(GetLedgerSettingsFile(m_strCurrentFile)) Then

            toolBarButtonList = GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList)

        Else

            toolBarButtonList = ""

        End If

        If Not toolBarButtonList = "" Then

            If Not toolBarButtonList = defaultButtonList Then

                Dim buttonCol As New Specialized.StringCollection
                buttonCol = Convert_CSV_Button_List_To_Collection(GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList))

                For Each strEntry As String In buttonCol

                    Dim chrSeparator As Char() = New Char() {","c}
                    Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                    Dim intIndex As Integer = arrValues(0)
                    Dim strButtonName As String = arrValues(1)

                    If fullListCommandsList.Contains(strButtonName) Then

                        CreateButton(strButtonName)

                    End If

                Next

            Else

                'CREATE DEFAULT BUTTONS
                CreateButton("new_ledger")
                CreateButton("open")
                CreateButton("save_as")
                CreateButton("new_trans")
                CreateButton("delete_trans")
                CreateButton("edit_trans")
                CreateButton("cleared")
                CreateButton("uncleared")
                CreateButton("categories")
                CreateButton("payees")
                CreateButton("receipt")
                CreateButton("sum_selected")
                CreateButton("filter")
                CreateButton("balance")

                'SAVE DEFAULT BUTTON SETTINGS
                SetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList, defaultButtonList)

            End If

        End If

    End Sub

    Public Sub CreateButton(ByVal buttonName As String)

        Select Case buttonName
            Case "about"
                CreateToolStripButton(about_Button, buttonName)
            Case "balance"
                CreateToolStripButton(balance_Button, buttonName)
            Case "calculator"
                CreateToolStripButton(calculator_Button, buttonName)
            Case "categories"
                CreateToolStripButton(categories_Button, buttonName)
            Case "cleared"
                CreateToolStripButton(cleared_Button, buttonName)
            Case "delete_trans"
                CreateToolStripButton(delete_trans_Button, buttonName)
            Case "edit_trans"
                CreateToolStripButton(edit_trans_Button, buttonName)
            Case "exit"
                CreateToolStripButton(exit_Button, buttonName)
            Case "filter"
                CreateToolStripButton(filter_Button, buttonName)
            Case "help"
                CreateToolStripButton(help_Button, buttonName)
            Case "import_trans"
                CreateToolStripButton(import_trans_Button, buttonName)
            Case "loan_calculator"
                CreateToolStripButton(loan_calculator_Button, buttonName)
            Case "message"
                CreateToolStripButton(message_Button, buttonName)
            Case "monthly_income"
                CreateToolStripButton(monthly_income_Button, buttonName)
            Case "budgets"
                CreateToolStripButton(budgets_Button, buttonName)
            Case "new_ledger"
                CreateToolStripButton(new_ledger_Button, buttonName)
            Case "new_trans"
                CreateToolStripButton(new_trans_Button, buttonName)
            Case "open"
                CreateToolStripButton(open_Button, buttonName)
            Case "options"
                CreateToolStripButton(options_Button, buttonName)
            Case "payees"
                CreateToolStripButton(payees_Button, buttonName)
            Case "receipt"
                CreateToolStripButton(reciept_Button, buttonName)
            Case "save_as"
                CreateToolStripButton(save_as_Button, buttonName)
            Case "spending_overview"
                CreateToolStripButton(spending_overview_Button, buttonName)
            Case "start_balance"
                CreateToolStripButton(start_balance_Button, buttonName)
            Case "sum_selected"
                CreateToolStripButton(sum_selected_Button, buttonName)
            Case "uncleared"
                CreateToolStripButton(uncleared_Button, buttonName)
            Case "updates"
                CreateToolStripButton(updates_Button, buttonName)
            Case "most_used"
                CreateToolStripButton(mostUsed_Button, buttonName)
            Case "export_trans"
                CreateToolStripButton(export_trans_Button, buttonName)
            Case "advanced_filter"
                CreateToolStripButton(advanced_filter_Button, buttonName)
            Case "duplicate_trans"
                CreateToolStripButton(duplicate_trans_Button, buttonName)
            Case "close_ledger"
                CreateToolStripButton(close_ledger_Button, buttonName)
            Case Else

        End Select

    End Sub

    Public Sub CreateToolStripButton(ByVal _button As ToolStripButton, ByVal _name As String)

        _button = New System.Windows.Forms.ToolStripButton()
        _button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        _button.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        _button.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        Select Case _name
            Case "about"
                _button.Name = _name
                _button.Text = "About Checkbook"
                _button.Image = img_about
                about_Button = _button
                AddHandler _button.Click, AddressOf mnuAbout_Click
            Case "balance"
                _button.Name = _name
                _button.Text = "Balance Account"
                _button.Image = img_balance_account
                balance_Button = _button
                AddHandler _button.Click, AddressOf balance_Button_Click
            Case "calculator"
                _button.Name = _name
                _button.Text = "Windows Calculator"
                _button.Image = img_calculator
                calculator_Button = _button
                AddHandler _button.Click, AddressOf mnuCalc_Click
            Case "categories"
                _button.Name = _name
                _button.Text = "Categories"
                _button.Image = img_categories
                categories_Button = _button
                AddHandler _button.Click, AddressOf mnuCategories_Click
            Case "cleared"
                _button.Name = _name
                _button.Text = "Clear Selected"
                _button.Image = img_cleared
                cleared_Button = _button
                AddHandler _button.Click, AddressOf mnuClearSelected_Click
            Case "delete_trans"
                _button.Name = _name
                _button.Text = "Delete Transaction(s)"
                _button.Image = img_delete_trans
                delete_trans_Button = _button
                AddHandler _button.Click, AddressOf mnuDeleteTrans_Click
            Case "edit_trans"
                _button.Name = _name
                _button.Text = "Edit Transaction"
                _button.Image = img_edit_trans
                edit_trans_Button = _button
                AddHandler _button.Click, AddressOf mnuEditTrans_Click
            Case "exit"
                _button.Name = _name
                _button.Text = "Exit"
                _button.Image = img_exit
                exit_Button = _button
                AddHandler _button.Click, AddressOf mnuExit_Click
            Case "filter"
                _button.Name = _name
                _button.Text = "Quick Filter"
                _button.Image = img_filter
                filter_Button = _button
                AddHandler _button.Click, AddressOf filter_Button_Click
            Case "help"
                _button.Name = _name
                _button.Text = "Checkbook Help"
                _button.Image = img_help
                help_Button = _button
                AddHandler _button.Click, AddressOf mnuCheckbookHelp_Click
            Case "import_trans"
                _button.Name = _name
                _button.Text = "Import Transactions"
                _button.Image = img_import_trans
                import_trans_Button = _button
                AddHandler _button.Click, AddressOf mnuImportTrans_Click
            Case "loan_calculator"
                _button.Name = _name
                _button.Text = "Loan Calculator"
                _button.Image = img_loan_calculator
                loan_calculator_Button = _button
                AddHandler _button.Click, AddressOf mnuLoanCalculator_Click
            Case "message"
                _button.Name = _name
                _button.Text = "Unknown/Uncategorized"
                _button.Image = img_message
                message_Button = _button
                AddHandler _button.Click, AddressOf mnuUnCatUnknownMessage_Click
            Case "monthly_income"
                _button.Name = _name
                _button.Text = "Monthly Income"
                _button.Image = img_monthly_income
                monthly_income_Button = _button
                AddHandler _button.Click, AddressOf mnuMonthlyIncome_Click
            Case "budgets"
                _button.Name = _name
                _button.Text = "Budgets"
                _button.Image = img_budgets
                budgets_Button = _button
                AddHandler _button.Click, AddressOf mnuBudgets_Click
            Case "new_ledger"
                _button.Name = _name
                _button.Text = "New Ledger"
                _button.Image = img_new_ledger
                new_ledger_Button = _button
                AddHandler _button.Click, AddressOf mnuNew_Click
            Case "new_trans"
                _button.Name = _name
                _button.Text = "New Transaction"
                _button.Image = img_new_trans
                new_trans_Button = _button
                AddHandler _button.Click, AddressOf mnuNewTrans_Click
            Case "open"
                _button.Name = _name
                _button.Text = "My Checkbook Ledgers"
                _button.Image = img_open
                open_Button = _button
                AddHandler _button.Click, AddressOf mnuOpen_Click
            Case "options"
                _button.Name = _name
                _button.Text = "Options"
                _button.Image = img_options
                options_Button = _button
                AddHandler _button.Click, AddressOf mnuOptions_Click
            Case "payees"
                _button.Name = _name
                _button.Text = "Payees"
                _button.Image = img_payees
                payees_Button = _button
                AddHandler _button.Click, AddressOf mnuPayees_Click
            Case "receipt"
                _button.Name = _name
                _button.Text = "View Receipt"
                _button.Image = img_receipt
                reciept_Button = _button
                AddHandler _button.Click, AddressOf receipt_Button_Click
            Case "save_as"
                _button.Name = _name
                _button.Text = "Save As"
                _button.Image = img_save_as
                save_as_Button = _button
                AddHandler _button.Click, AddressOf mnuSaveAs_Click
            Case "spending_overview"
                _button.Name = _name
                _button.Text = "Spending Overview"
                _button.Image = img_spending_overview
                spending_overview_Button = _button
                AddHandler _button.Click, AddressOf mnuSpendingOverview_Click
            Case "start_balance"
                _button.Name = _name
                _button.Text = "Edit Starting Balance"
                _button.Image = img_start_balance
                start_balance_Button = _button
                AddHandler _button.Click, AddressOf mnuEditStartingBalance_Click
            Case "sum_selected"
                _button.Name = _name
                _button.Text = "Sum Selected"
                _button.Image = img_sum_selected
                sum_selected_Button = _button
                AddHandler _button.Click, AddressOf mnuSum_Click
            Case "uncleared"
                _button.Name = _name
                _button.Text = "Unclear Selected"
                _button.Image = img_uncleared
                uncleared_Button = _button
                AddHandler _button.Click, AddressOf mnuUnclearSelected_Click
            Case "updates"
                _button.Name = _name
                _button.Text = "Check for Update"
                _button.Image = img_updates
                updates_Button = _button
                AddHandler _button.Click, AddressOf mnuCheckforUpdate_Click
            Case "most_used"
                _button.Name = _name
                _button.Text = "Most Used Categories/Payees"
                _button.Image = img_mostUsed
                mostUsed_Button = _button
                AddHandler _button.Click, AddressOf mnuMostUsed_Click
            Case "export_trans"
                _button.Name = _name
                _button.Text = "Export Transactions"
                _button.Image = img_export_trans
                export_trans_Button = _button
                AddHandler _button.Click, AddressOf mnuExportTransactions_Click
            Case "advanced_filter"
                _button.Name = _name
                _button.Text = "Advanced Filter"
                _button.Image = img_advanced_filter
                advanced_filter_Button = _button
                AddHandler _button.Click, AddressOf mnuAdvancedFilter_Click
            Case "duplicate_trans"
                _button.Name = _name
                _button.Text = "Duplicate Transaction(s)"
                _button.Image = img_duplicate_trans
                duplicate_trans_Button = _button
                AddHandler _button.Click, AddressOf mnuDuplicateTrans_Click
            Case "close_ledger"
                _button.Name = _name
                _button.Text = "Close Ledger"
                _button.Image = img_close_ledger_Button
                close_ledger_Button = _button
                AddHandler _button.Click, AddressOf mnuCloseLedger_Click
        End Select

        tsToolStrip.Items.Add(_button)

    End Sub

    Private Sub mnuBudgets_Click(sender As Object, e As EventArgs) Handles mnuBudgets.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intRowCount As Integer = Nothing

        intRowCount = Me.dgvLedger.Rows.Count

        If Not intRowCount = 0 Then

            Dim new_frmBudgets As New frmBudgets
            new_frmBudgets.ShowDialog()

        Else

            CheckbookMsg.ShowMessage("Your ledger does not have any transactions to calculate", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub mnuMostUsed_Click(sender As Object, e As EventArgs) Handles mnuMostUsed.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intRowCount As Integer = Nothing

        intRowCount = Me.dgvLedger.Rows.Count

        If Not intRowCount = 0 Then

            Dim new_frmMostUsedCategoriesPayees As New frmMostUsedCategoriesPayees
            new_frmMostUsedCategoriesPayees.ShowDialog()

        Else

            CheckbookMsg.ShowMessage("Your ledger does not have any transactions to calculate", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub mnuExportTransactions_Click(sender As Object, e As EventArgs) Handles mnuExportTransactions.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If m_TransactionCount = 0 Then

            CheckbookMsg.ShowMessage("Your ledger does not have any transactions to export", MsgButtons.OK, "", Exclamation)

        Else

            Dim strCurrentFile As String = String.Empty
            strCurrentFile = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile)

            Dim sfdDialog As New SaveFileDialog
            sfdDialog.Title = "Export transactions to csv file"
            sfdDialog.FileName = strCurrentFile & "_Export"
            sfdDialog.Filter = "csv files (*.csv)|*.csv"

            If GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory) = String.Empty Then

                sfdDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            Else

                sfdDialog.InitialDirectory = GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory)

            End If

            If sfdDialog.ShowDialog = DialogResult.OK Then

                Dim file As String = String.Empty
                file = sfdDialog.FileName

                If CheckbookMsg.ShowMessage("Are you sure you want to export your transactions to " & file & "?", MsgButtons.YesNo, "Checkbook will export all loaded transactions. If you are currently filtering or balancing your ledger only those visible will export.", Question) = DialogResult.Yes Then

                    Try

                        UIManager.SetCursor(Me, Cursors.WaitCursor)

                        ExportTransactions(dgvLedger, file)

                        UIManager.SetCursor(Me, Cursors.Default)

                        If CheckbookMsg.ShowMessage("Your transactions have exported successfully.", MsgButtons.YesNo, "Would you like to open the file now?", Question) = DialogResult.Yes Then

                            Process.Start(file)

                        End If

                    Catch exIOException As System.IO.IOException

                        CheckbookMsg.ShowMessage("Export Error", MsgButtons.OK, "The file you are trying to export to may be open. Make sure the file is closed and try exporting again. If it is not open  please see the message below." & vbNewLine & vbNewLine & exIOException.Message & vbNewLine & vbNewLine & exIOException.Source, Exclamation)

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Export Error", MsgButtons.OK, "An error occurred while exporting your transactions. Please see the message below." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        UIManager.SetCursor(Me, Cursors.Default)

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub ExportTransactions(ByVal _dgv As DataGridView, ByVal _file As String)

        Dim writer As New StreamWriter(_file)

        'TYPE
        'CATEGORY
        'DATE
        'PAYMENT
        'DEPOSIT
        'PAYEE
        'DESCRIPTION
        'CLEARED

        Dim strColumnHeaders As String = String.Empty
        strColumnHeaders = "TYPE,CATEGORY,DATE,PAYMENT,DEPOSIT,PAYEE,DESCRIPTION,CLEARED" & Environment.NewLine

        writer.Write(strColumnHeaders)

        For Each dgvRow As DataGridViewRow In dgvLedger.Rows

            Dim strEntry As String = String.Empty

            Dim strType As String = String.Empty
            Dim strCategory As String = String.Empty
            Dim dtDate As Date = Nothing
            Dim strDate As String = String.Empty
            Dim strPayment As String = String.Empty
            Dim strDeposit As String = String.Empty
            Dim strPayee As String = String.Empty
            Dim strDescription As String = String.Empty
            Dim strCleared As String = String.Empty

            strType = dgvRow.Cells.Item("Type").Value.ToString
            strCategory = dgvRow.Cells.Item("Category").Value.ToString
            dtDate = dgvRow.Cells.Item("TransDate").Value
            strDate = dtDate.ToShortDateString
            strPayment = dgvRow.Cells.Item("Payment").Value.ToString
            strDeposit = dgvRow.Cells.Item("Deposit").Value.ToString
            strPayee = dgvRow.Cells.Item("Payee").Value.ToString
            strDescription = dgvRow.Cells.Item("Description").Value.ToString
            strCleared = dgvRow.Cells.Item("Cleared").Value.ToString

            strType = strType.Replace(",", "")
            strCategory = strCategory.Replace(",", "")
            strPayment = strPayment.Replace(",", "")
            strDeposit = strDeposit.Replace(",", "")
            strPayee = strPayee.Replace(",", "")
            strDescription = strDescription.Replace(",", "")

            strEntry = strType & "," & strCategory & "," & strDate & "," & strPayment & "," & strDeposit & "," & strPayee & "," & strDescription & "," & strCleared & Environment.NewLine

            writer.Write(strEntry)

        Next

        writer.Close()

    End Sub

    Private Sub mnuAdvancedFilter_Click(sender As Object, e As EventArgs) Handles mnuAdvancedFilter.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If m_TransactionCount = 0 Then

            CheckbookMsg.ShowMessage("Your ledger does not have any transactions to filter", MsgButtons.OK, "", Exclamation)

        Else

            SetMainFormMenuItemsAndToolbarButtonsDisabled_ToggleFilter()
            mnuFilter.Enabled = False
            filter_Button.Enabled = False

            Dim new_frmFilter As New frmFilter
            m_frmFilter = new_frmFilter
            new_frmFilter.Show()

        End If

    End Sub

    Private Sub DuplicateTransactions()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("There are no items selected to duplicate", MsgButtons.OK, "", Exclamation)

        Else

            ' GET CURRENTLY SELECTED TRANSACTIONS
            ' LOOP THROUGH EACH ONE AND INSERT INTO DATABASE

            Try

                UIManager.SetCursor(Me, Cursors.WaitCursor)

                For Each row As DataGridViewRow In dgvLedger.SelectedRows

                    Dim i As Integer
                    i = row.Index

                    Dim newTransaction As New clsTransaction

                    newTransaction.Type = dgvLedger.Rows(i).Cells("Type").Value
                    newTransaction.Category = dgvLedger.Rows(i).Cells("Category").Value
                    newTransaction.TransDate = dgvLedger.Rows(i).Cells("TransDate").Value
                    newTransaction.Payment = dgvLedger.Rows(i).Cells("Payment").Value
                    newTransaction.Deposit = dgvLedger.Rows(i).Cells("Deposit").Value
                    newTransaction.Payee = dgvLedger.Rows(i).Cells("Payee").Value
                    newTransaction.Description = dgvLedger.Rows(i).Cells("Description").Value
                    newTransaction.Cleared = dgvLedger.Rows(i).Cells("Cleared").Value
                    newTransaction.Receipt = dgvLedger.Rows(i).Cells("Receipt").Value

                    If Not newTransaction.Receipt = "" Then

                        Dim strReceiptToCopy As String = ""
                        Dim strNewReceipt As String = ""

                        strReceiptToCopy = AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, newTransaction.Receipt)

                        newTransaction.Receipt = newTransaction.Receipt.Remove(0, 13)

                        ' ADD NEW TIMESTAMP
                        Dim timeStamp As String
                        timeStamp = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds).ToString

                        newTransaction.Receipt = timeStamp & newTransaction.Receipt

                        strNewReceipt = AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, newTransaction.Receipt)

                        My.Computer.FileSystem.CopyFile(strReceiptToCopy, strNewReceipt, True)

                    End If

                    ' CONNECTS TO DATABASE AND INSERTS NEW TRANSACTION DATA
                    ' FILLS THE DATAGRIDVIEW
                    FileCon.Connect()
                    FileCon.SQLinsert("INSERT INTO LedgerData (Type,Category,TransDate,Payment,Deposit,Payee,Description,Cleared,Receipt) VALUES('" & newTransaction.Type & "','" & newTransaction.Category & "','" & newTransaction.TransDate & "','" & newTransaction.Payment & "','" & newTransaction.Deposit & "','" & newTransaction.Payee & "','" & newTransaction.Description & "'," & newTransaction.Cleared & ",'" & newTransaction.Receipt & "')")
                    FileCon.Close()

                Next

                If m_ledgerIsBeingBalanced Then

                    DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                ElseIf m_ledgerIsBeingFiltered And Not txtFilter.Text = "" Then

                    DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                ElseIf m_ledgerIsBeingFiltered_Advanced Then

                    DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                Else

                    DataCon.SelectAllLedgerData_UpdateAccountDetails()

                End If

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Transaction Error", MsgButtons.OK, "An error occurred while duplicating the transaction(s)" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                UIManager.SetCursor(Me, Cursors.Default)
                FileCon.Close()

            End Try

        End If

    End Sub

    Private Sub cxmnuDuplicateTrans_Click(sender As Object, e As EventArgs) Handles cxmnuDuplicateTrans.Click

        DuplicateTransactions()

    End Sub

    Private Sub mnuDuplicateTrans_Click(sender As Object, e As EventArgs) Handles mnuDuplicateTrans.Click

        DuplicateTransactions()

    End Sub

    Private Sub mnuCloseLedger_Click(sender As Object, e As EventArgs) Handles mnuCloseLedger.Click

        'CLEARS DATA FROM DATAGRID IF THE CURRENTLY OPEN FILE IS CLOSED.
        Me.dgvLedger.DataSource = Nothing
        Me.dgvLedger.Columns.Clear()

        m_strCurrentFile = ""

        'ENABLES ALL MENU AND TOOLSTRIP ITEMS IF STRFILE IS NOT EMPTY
        UIManager.Maintain_DisabledMainFormUI()

    End Sub

End Class
