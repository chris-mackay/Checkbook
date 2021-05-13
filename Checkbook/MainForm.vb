'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2021 Christopher Mackay

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

    'COLUMN ORDER
    '(0) ID
    '(1) TYPE
    '(2) CATEGORY
    '(3) TRANSDATE
    '(4) PAYMENT
    '(5) DEPOSIT
    '(6) PAYEE
    '(7) DESCRIPTION
    '(8) CLEARED
    '(9) RECEIPT
    '(10) STATEMENT NAME
    '(11) STATEMENT FILE NAME
    '(12) CLEARED IMAGE
    '(13) RECEIPT IMAGE

    Public lstCommands As New List(Of String)

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
    Public WithEvents monthly_income_Button As New ToolStripButton
    Public WithEvents budgets_Button As New ToolStripButton
    Public WithEvents new_ledger_Button As New ToolStripButton
    Public WithEvents new_trans_Button As New ToolStripButton
    Public WithEvents open_Button As New ToolStripButton
    Public WithEvents options_Button As New ToolStripButton
    Public WithEvents payees_Button As New ToolStripButton
    Public WithEvents receipt_Button As New ToolStripButton
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
    Public WithEvents view_statement_Button As New ToolStripButton
    Public WithEvents my_statements_Button As New ToolStripButton

    'VARIABLES FOR ALL BITMAP ICONS
    Public bmp_about As Bitmap
    Public bmp_balance_account As Bitmap
    Public bmp_calculator As Bitmap
    Public bmp_categories As Bitmap
    Public bmp_cleared As Bitmap
    Public bmp_delete_trans As Bitmap
    Public bmp_edit_trans As Bitmap
    Public bmp_exit As Bitmap
    Public bmp_filter As Bitmap
    Public bmp_help As Bitmap
    Public bmp_import_trans As Bitmap
    Public bmp_loan_calculator As Bitmap
    Public bmp_monthly_income As Bitmap
    Public bmp_budgets As Bitmap
    Public bmp_new_ledger As Bitmap
    Public bmp_new_trans As Bitmap
    Public bmp_open As Bitmap
    Public bmp_options As Bitmap
    Public bmp_payees As Bitmap
    Public bmp_receipt As Bitmap
    Public bmp_save_as As Bitmap
    Public bmp_spending_overview As Bitmap
    Public bmp_start_balance As Bitmap
    Public bmp_sum_selected As Bitmap
    Public bmp_uncleared As Bitmap
    Public bmp_updates As Bitmap
    Public bmp_mostUsed As Bitmap
    Public bmp_export_trans As Bitmap
    Public bmp_advanced_filter As Bitmap
    Public bmp_duplicate_trans As Bitmap
    Public bmp_close_ledger_Button As Bitmap
    Public bmp_view_statement_Button As Bitmap
    Public bmp_my_statements_Button As Bitmap

    Private No As Boolean = False
    Private Yes As Boolean = True

    Private intFilterTimerInterval As Integer

    Private strLatestVersionFromDropbox As String = String.Empty

    Private intTime As Integer

    Private File As New clsLedgerDBFileManager
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager
    Private NewTrans As New clsTransaction

    Private lstOriginalCategories As New List(Of String)
    Private lstOriginalPayees As New List(Of String)

    Private lstNewCategories As New List(Of String)
    Private lstNewPayees As New List(Of String)

    Private lstTransactions As New List(Of String)
    Private lstErrors As New List(Of Integer)

    Private Sub dgvLedger_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If Not txtFilter.Focused And Not m_strCurrentFile = String.Empty Then

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

        Dim intStatementIndex As Integer = 10
        Dim intClearedIndex As Integer = 12
        Dim intReceiptIndex As Integer = 13

        If e.ColumnIndex = intReceiptIndex Then
            ViewReceipt()
        End If

        If e.ColumnIndex = intStatementIndex Then
            ViewStatement()
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

            Dim strNewLedgerPath As String = String.Empty
            Dim strStartBalance As String = String.Empty
            Dim strNewLedgerName As String = String.Empty

            strNewLedgerName = new_frmNewCheckbookLedger.txtNewLedger.Text
            strNewLedgerPath = AppendLedgerPath(strNewLedgerName)

            If IO.File.Exists(strNewLedgerPath) Then

                CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The ledger '" & strNewLedgerName & "' already exists. Provide a unique name for your ledger.", Exclamation)

            Else

                Try

                    strStartBalance = new_frmNewCheckbookLedger.txtStartBalance.Text

                    Me.Show()
                    Me.Activate()

                    CreateLedgerDirectories(strNewLedgerName)

                    File.CreateNewLedger_AccessDatabase(strNewLedgerPath)

                    m_strCurrentFile = strNewLedgerPath

                    CreateLedgerSettings_SetDefaults(strNewLedgerName)

                    LoadButtonSettings_Or_CreateDefaultButtons()

                    Me.Text = "Checkbook - " & strNewLedgerName

                    FileCon.Connect()
                    FileCon.SQLinsert("INSERT INTO StartBalance (Balance) VALUES('" & strStartBalance & "')")
                    FileCon.SQLselect(FileCon.strSelectAllQuery)
                    FileCon.Fill_Format_LedgerData_DataGrid()
                    FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                    DataCon.LedgerStatus()

                    UIManager.UpdateStatusStripInfo()

                    UIManager.Maintain_DisabledMainFormUI()

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Create New Error", MsgButtons.OK, "An error occurred while creating the new ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                Finally

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

        If Not m_strCurrentFile = String.Empty Then

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

                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery)
                FileCon.Fill_Format_LedgerData_DataGrid()
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

        If m_blnLedgerIsBeingFiltered And txtFilter.Focused Then

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
        DownloadUpdateLabel.Text = String.Empty

        gbFilter.Visible = False

        m_lstAllMainFormControls.Clear()
        m_lstAccountDetailTextboxes.Clear()

        'ADDS CONTROLS TO A LIST SO YOU CAN SET DRAWING CONTROL METHODS TO THEM IN A GROUP
        m_lstAllMainFormControls.Add(tsToolStrip)
        m_lstAllMainFormControls.Add(mnuMenuStrip)
        m_lstAllMainFormControls.Add(dgvLedger)
        m_lstAllMainFormControls.Add(stStatusStrip)
        m_lstAllMainFormControls.Add(gbAccountDetails)

        m_lstAccountDetailTextboxes.Add(txtStartingBalance)
        m_lstAccountDetailTextboxes.Add(txtTotalPayments)
        m_lstAccountDetailTextboxes.Add(txtTotalDeposits)
        m_lstAccountDetailTextboxes.Add(txtOverallBalance)
        m_lstAccountDetailTextboxes.Add(txtClearedBalance)
        m_lstAccountDetailTextboxes.Add(txtUnclearedBalance)
        m_lstAccountDetailTextboxes.Add(txtLedgerStatus)

        File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

        UIManager.Maintain_DisabledMainFormUI()

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

            If Not IsDBNull(e.Value) Then

                If Not e.Value = String.Empty Then

                    e.Value = FormatCurrency(dgvLedger.Rows(e.RowIndex).Cells("Payment").Value)

                End If

            End If

        End If

        'FORMATS DEPOSIT TO CURRENCY
        If dgvLedger.Columns(e.ColumnIndex).Name.Equals("Deposit") Then

            If Not IsDBNull(e.Value) Then

                If Not e.Value = String.Empty Then

                    e.Value = FormatCurrency(dgvLedger.Rows(e.RowIndex).Cells("Deposit").Value)

                End If

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

    Private Sub ToggleFilter(ByVal _ObjectClicked As Object, Optional ByVal _SecondaryObjectToToggle As Object = Nothing)

        _ObjectClicked.Checked = Not (_ObjectClicked.Checked)
        If _ObjectClicked.Checked = True Then
            m_blnLedgerIsBeingFiltered = True

            SetMainFormMenuItemsAndToolbarButtonsDisabled_ToggleFilter()

            _SecondaryObjectToToggle.Checked = True
            gbFilter.Visible = True
            txtFilter.Text = String.Empty
            txtFilter.Focus()
            dgvLedger.ClearSelection()

        End If
        If _ObjectClicked.Checked = False Then
            m_blnLedgerIsBeingFiltered = False

            SetMainFormMenuItemsAndToolbarButtonsEnabled_ToggleFilter()

            _SecondaryObjectToToggle.Checked = False
            gbFilter.Visible = False
            txtFilter.Text = String.Empty

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_LedgerData_DataGrid()
            FileCon.Close()

            dgvLedger.Sort(dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            dgvLedger.ClearSelection()

            UIManager.SetCursor(Me, Cursors.Default)

        End If

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub filter_Button_Click(sender As System.Object, e As System.EventArgs)

        If Not m_intTransactionCount = 0 Then

            ToggleFilter(sender, mnuFilter)

        Else

            If Not m_blnLedgerIsBeingFiltered Then

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                CheckbookMsg.ShowMessage("Your ledger does not have any transactions to filter", MsgButtons.OK, "", Exclamation)

            Else

                ToggleFilter(sender, mnuFilter)

            End If

        End If

    End Sub

    Private Sub mnuFilter_Click(sender As System.Object, e As System.EventArgs) Handles mnuFilter.Click

        If Not m_intTransactionCount = 0 Then

            ToggleFilter(sender, filter_Button)

        Else

            If Not m_blnLedgerIsBeingFiltered Then

                Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

                CheckbookMsg.ShowMessage("Your ledger does not have any transactions to filter", MsgButtons.OK, "", Exclamation)

            Else

                ToggleFilter(sender, filter_Button)

            End If

        End If

    End Sub

    Public Sub ToggleBalanceAccount(ByVal _ObjectClicked As Object, Optional ByVal _SecondaryObjectToToggle As Object = Nothing)

        _ObjectClicked.Checked = Not (_ObjectClicked.Checked)
        If _ObjectClicked.Checked = True Then
            m_blnLedgerIsBeingBalanced = True

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

            _SecondaryObjectToToggle.Checked = True
            UIManager.SetCursor(Me, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery & " WHERE Cleared=False")
            FileCon.Fill_Format_LedgerData_DataGrid()
            FileCon.Close()

            dgvLedger.Sort(dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Ascending)
            dgvLedger.ClearSelection()

            UIManager.SetCursor(Me, Cursors.Default)

        End If
        If _ObjectClicked.Checked = False Then
            m_blnLedgerIsBeingBalanced = False

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

            _SecondaryObjectToToggle.Checked = False

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_LedgerData_DataGrid()
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

        If Not m_blnLedgerIsBeingBalanced Then 'MAKES SURE THE LEDGER IS NOT ALREADY BEING BALANCED. BECAUSE WE CLICK THE SAME BUTTON TO TOGGLE IT OFF. WE DONT NEED TO CHECK IF WE ARE BALANCING

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

        If Not m_blnLedgerIsBeingBalanced Then 'MAKES SURE THE LEDGER IS NOT ALREADY BEING BALANCED. BECAUSE WE CLICK THE SAME BUTTON TO TOGGLE IT OFF. WE DONT NEED TO CHECK IF WE ARE BALANCING

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

        Dim intRowCount As Integer = 0
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

        Dim intRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditPayee As New frmEditPayee
            new_frmEditPayee.ShowDialog()

        End If

    End Sub

    Private Sub mnuEditStatement_Click(sender As Object, e As EventArgs) Handles mnuEditStatement.Click, cxmnuEditStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmEditStatement As New frmEditStatement
            new_frmEditStatement.ShowDialog()

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

        If Not m_blnDataIsBeingLoaded Then

            FormatUncleared_SetClearedStatus_SetReceiptStatus()

        End If

    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click

        Dim new_frmAbout As New frmAbout
        new_frmAbout.ShowDialog()

    End Sub

    Private Sub receipt_Button_Click(sender As Object, e As EventArgs) Handles cxmnuViewReceipt.Click, mnuViewReceipt.Click

        ViewReceipt()

    End Sub

    Private Sub view_statement_Button_Click(sender As Object, e As EventArgs) Handles cxmnuViewStatement.Click, mnuViewStatement.Click

        ViewStatement()

    End Sub

    Private Sub my_statements_Button_Click(sender As Object, e As EventArgs) Handles mnuMyStatements.Click

        Dim new_frmStatements As New frmMyStatements
        new_frmStatements.ShowDialog()

    End Sub

    Private Sub btnClearFilter_MouseHover(sender As Object, e As EventArgs) Handles btnClearFilter.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnClearFilter, "Clear Filter")

    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click

        txtFilter.Text = String.Empty

        FileCon.Connect()
        FileCon.SQLselect(FileCon.strSelectAllQuery)
        FileCon.Fill_Format_LedgerData_DataGrid()
        FileCon.Close()

        UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub EditTransaction()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
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

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then

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

    Private Sub ViewStatement()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no items selected to view a statement", MsgButtons.OK, "", Exclamation)

        ElseIf intSelectedRowCount > 1 Then

            CheckbookMsg.ShowMessage("You can only view one statement at a time", MsgButtons.OK, "", Exclamation)

        Else

            With Me.dgvLedger

                Dim i As Integer = 0
                Dim strStatementFromDGV As String = String.Empty

                i = .CurrentRow.Index
                strStatementFromDGV = .Item("StatementFileName", i).Value

                If strStatementFromDGV = String.Empty Then

                    CheckbookMsg.ShowMessage("This transaction does not have a statement attached", MsgButtons.OK, "", Exclamation)

                Else

                    Dim strStatementPath As String = String.Empty
                    strStatementPath = AppendStatementPath(m_strCurrentFile, strStatementFromDGV)

                    If Not System.IO.File.Exists(strStatementPath) Then

                        CheckbookMsg.ShowMessage("The statement for this transaction does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

                    Else

                        Process.Start(strStatementPath)

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub ViewReceipt()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no items selected to view a receipt", MsgButtons.OK, "", Exclamation)

        ElseIf intSelectedRowCount > 1 Then

            CheckbookMsg.ShowMessage("You can only view one receipt at a time", MsgButtons.OK, "", Exclamation)

        Else

            With Me.dgvLedger

                Dim i As Integer = 0
                Dim strReceiptFromDGV As String = String.Empty

                i = .CurrentRow.Index
                strReceiptFromDGV = .Item("Receipt", i).Value

                If strReceiptFromDGV = String.Empty Then

                    CheckbookMsg.ShowMessage("This transaction does not have a receipt attached", MsgButtons.OK, "", Exclamation)

                Else

                    Dim strReceiptPath As String = String.Empty
                    strReceiptPath = AppendReceiptPath(m_strCurrentFile, strReceiptFromDGV)

                    If Not System.IO.File.Exists(strReceiptPath) Then

                        CheckbookMsg.ShowMessage("The receipt for this transaction does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

                    Else

                        Process.Start(strReceiptPath)

                    End If

                End If

            End With

        End If

    End Sub

    Private Sub SumSelected()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount = 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to calculate", MsgButtons.OK, "", Exclamation)

        Else

            Dim dblPayments As Double = DataCon.SumPayments
            Dim dblDeposits As Double = DataCon.SumDeposits
            Dim dblNet As Double = dblDeposits - dblPayments

            Dim strPayments As String = String.Empty
            Dim strDeposits As String = String.Empty
            Dim strNet As String = String.Empty

            strPayments = FormatCurrency(dblPayments)
            strDeposits = FormatCurrency(dblDeposits)
            strNet = FormatCurrency(dblNet)

            Dim strMessage As String = "Payments: " & strPayments & vbNewLine & "Deposits: " & strDeposits & vbNewLine & "Net: " & strNet

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

        Dim strSelectedLedgerName As String = String.Empty
        strSelectedLedgerName = menuItem.Text

        Dim strLedgerPath As String = String.Empty
        strLedgerPath = AppendLedgerPath(strSelectedLedgerName)

        m_strCurrentFile = strLedgerPath

        CreateLedgerDirectories(strSelectedLedgerName)

        CreateLedgerSettings_SetDefaults(strSelectedLedgerName)

        LoadButtonSettings_Or_CreateDefaultButtons()

        Try

            Me.Text = "Checkbook - " & strSelectedLedgerName

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_LedgerData_DataGrid()
            FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

            DataCon.LedgerStatus()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Open Error", MsgButtons.OK, "An error occurred while opening the ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

        Finally

            FileCon.Close()
            UIManager.SetCursor(Me, Cursors.Default)
            UIManager.Maintain_DisabledMainFormUI()
            UIManager.UpdateStatusStripInfo()

        End Try

    End Sub

    Private Sub mnuFile_Click(sender As Object, e As EventArgs) Handles mnuFile.DropDownOpening

        File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

    End Sub

    Private Sub mnuCheckforUpdate_Click(sender As Object, e As EventArgs) Handles mnuCheckforUpdate.Click

        CheckForUpdate()

    End Sub

    Private Sub CheckForUpdate()

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strVersionTextWebFilePath As String = String.Empty
        Dim strVersionFromTextFile As String = String.Empty

        strVersionTextWebFilePath = "https://chris-mackay.github.io/CheckbookWebsite/all_installer_versions/latest_version/Version.txt"

        Dim strCheckbookSetupFileToDownload As String = String.Empty

        strCheckbookSetupFileToDownload = "https://chris-mackay.github.io/CheckbookWebsite/all_installer_versions/latest_version/Checkbook Setup.exe"

        Try

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            Dim webClient As New System.Net.WebClient
            Dim strVersionTextFile_Version_WithPeriod As String = String.Empty
            Dim strVersionTextFile_Version_WithoutPeriod As String = String.Empty

            Dim strCheckbookVersion_WithoutPeriod As String = String.Empty
            Dim strCheckbookVersion_WithPeriod As String = String.Empty

            Dim fileStream As System.IO.Stream
            fileStream = webClient.OpenRead(strVersionTextWebFilePath)

            Dim streamReader As New System.IO.StreamReader(fileStream)

            strVersionTextFile_Version_WithPeriod = streamReader.ReadToEnd

            strVersionTextFile_Version_WithPeriod = strVersionTextFile_Version_WithPeriod.Trim

            strLatestVersionFromDropbox = strVersionTextFile_Version_WithPeriod

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

                            m_blnNewVersionIsBeingDownloaded = True
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

        CheckbookMsg.ShowMessage("You have downloaded version " & strLatestVersionFromDropbox & ".", MsgButtons.OK, "To install the latest version please close Checkbook and run the installer.", Media.SystemSounds.Exclamation)

        m_blnNewVersionIsBeingDownloaded = False
        DownloadUpdateProgressBar.Value = 0
        DownloadUpdateProgressBar.Visible = False
        DownloadUpdateLabel.Text = ""
        If m_strCurrentFile = "" Then stLabel.Text = "Create a new ledger or open an existing ledger." Else UIManager.UpdateStatusStripInfo()

    End Sub

    Private Sub mnuImportTrans_Click(sender As Object, e As EventArgs) Handles mnuImportTrans.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dlgOpenDialog As New OpenFileDialog
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

                If lstErrors.Count = 0 Then

                    ImportValidTransactions()

                ElseIf lstErrors.Count > 0 Then

                    Dim strErrorRows As String = String.Empty

                    For Each intRowLine As Integer In lstErrors

                        strErrorRows = strErrorRows & "Row #" & intRowLine & vbNewLine

                    Next

                    If CheckbookMsg.ShowMessage("Some of your transactions contain invalid data. The following rows in your file contain errors:" & vbNewLine & vbNewLine & strErrorRows & vbNewLine & "Make sure the date (C column), payment (D column), and/or deposit (E column) values do not contain letters or any other characters that do not represent a date or money value.", MsgButtons.YesNo, "Would you like to import the valid transactions? Once the valid transactions are imported delete them from your file to avoid duplicate imports, fix the errors and try again.", Question) = DialogResult.Yes Then

                        ImportValidTransactions()

                    End If

                End If

            End If

        End If

    End Sub

    ''' <summary>
    ''' Checks and makes sure the provided entries contain valid values. Fills a list of valid transactions (transactionList) that can be imported. 
    ''' </summary>
    ''' <param name="_Path"></param>
    Private Sub CheckValidTransactions(ByVal _Path As String)

        Dim csvLine As String = String.Empty
        Dim reader As New StreamReader(_Path)
        Dim blnInvalidValueFlag As Boolean = False
        Dim intCurrentRow As Integer = 1

        lstTransactions.Clear()
        lstErrors.Clear()

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
            strReceipt = String.Empty

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

                lstTransactions.Add(strEntry)

            Catch ex As Exception

                blnInvalidValueFlag = True
                lstErrors.Add(intCurrentRow)

            Finally

                intCurrentRow += 1

            End Try

        End While

    End Sub

    ''' <summary>
    ''' If their are errors in the entries the user has the option to import the valid entries.
    ''' </summary>
    Private Sub ImportValidTransactions()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Try
            'LOAD ALL CATEGORIES AND PAYEES FROM LEDGER TO CHECK IF THEY DO NOT EXIST
            'IF THEY DONT EXIST IN THE LEDGER THEN ADD THEM

            FileCon.Connect()
            FileCon.SQLread_Fill_List("SELECT * FROM Categories", lstOriginalCategories)
            FileCon.SQLread_Fill_List("SELECT * FROM Payees", lstOriginalPayees)
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        lstNewCategories.Clear()
        lstNewPayees.Clear()

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
        Dim strStatementName As String = String.Empty
        Dim strStatementFileName As String = String.Empty

        For Each strEntry As String In lstTransactions

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
            strStatementName = ""
            strStatementFileName = ""


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
            NewTrans.StatementName = strStatementName
            NewTrans.StatementFileName = strStatementFileName

            If Not lstOriginalCategories.Contains(NewTrans.Category) And Not lstNewCategories.Contains(NewTrans.Category) And Not NewTrans.Category = "Uncategorized" Then

                lstNewCategories.Add(NewTrans.Category)

            End If

            If Not lstOriginalPayees.Contains(NewTrans.Payee) And Not lstNewPayees.Contains(NewTrans.Payee) And Not NewTrans.Payee = "Unknown" Then

                lstNewPayees.Add(NewTrans.Payee)

            End If

            Try

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO LedgerData (Type,Category,TransDate,Payment,Deposit,Payee,Description,Cleared,Receipt,StatementName,StatementFileName) VALUES('" & NewTrans.Type & "','" & NewTrans.Category & "','" & NewTrans.TransDate & "','" & NewTrans.Payment & "','" & NewTrans.Deposit & "','" & NewTrans.Payee & "','" & NewTrans.Description & "'," & NewTrans.Cleared & ",'" & NewTrans.Receipt & "','" & NewTrans.StatementName & "','" & NewTrans.StatementFileName & "')")
                FileCon.Close()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Transaction Error", MsgButtons.OK, "An error occurred while creating the transaction. If you created a backup you should restore it now." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            End Try

        Next

        Try

            For Each newCategory As String In lstNewCategories

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO Categories (Category) VALUES ('" & newCategory & "')")
                FileCon.Close()

            Next

            For Each newPayee As String In lstNewPayees

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO Payees (Payee) VALUES ('" & newPayee & "')")
                FileCon.Close()

            Next

            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_LedgerData_DataGrid()
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Category/Payee Error", MsgButtons.OK, "An error occurred while updating your categories and/or payees. If you created a backup your should restore it now." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        DataCon.LedgerStatus()
        Me.dgvLedger.ClearSelection()
        UIManager.UpdateStatusStripInfo()
        UIManager.SetCursor(Me, Cursors.Default)
        CheckbookMsg.ShowMessage("Your transactions have imported successfully.", MsgButtons.OK, "", Exclamation)

    End Sub

    Private Sub mnuCheckbookHelp_Click(sender As Object, e As EventArgs) Handles mnuCheckbookHelp.Click

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/checkbook_help.html"
        Process.Start(strWebAddress)

    End Sub

    Public Sub LoadButtonSettings_Or_CreateDefaultButtons()

        tsToolStrip.Items.Clear()

        lstCommands.Clear()
        lstCommands.Add("about")
        lstCommands.Add("balance")
        lstCommands.Add("calculator")
        lstCommands.Add("categories")
        lstCommands.Add("cleared")
        lstCommands.Add("delete_trans")
        lstCommands.Add("edit_trans")
        lstCommands.Add("exit")
        lstCommands.Add("filter")
        lstCommands.Add("help")
        lstCommands.Add("import_trans")
        lstCommands.Add("loan_calculator")
        lstCommands.Add("monthly_income")
        lstCommands.Add("budgets")
        lstCommands.Add("new_ledger")
        lstCommands.Add("new_trans")
        lstCommands.Add("open")
        lstCommands.Add("options")
        lstCommands.Add("payees")
        lstCommands.Add("receipt")
        lstCommands.Add("save_as")
        lstCommands.Add("spending_overview")
        lstCommands.Add("start_balance")
        lstCommands.Add("sum_selected")
        lstCommands.Add("uncleared")
        lstCommands.Add("updates")
        lstCommands.Add("most_used")
        lstCommands.Add("export_trans")
        lstCommands.Add("advanced_filter")
        lstCommands.Add("duplicate_trans")
        lstCommands.Add("close_ledger")
        lstCommands.Add("statement")
        lstCommands.Add("my_statements")

        'SETS ALL IMAGES
        bmp_about = My.Resources.about
        bmp_balance_account = My.Resources.balance_account
        bmp_calculator = My.Resources.calculator
        bmp_categories = My.Resources.categories
        bmp_cleared = My.Resources.cleared
        bmp_delete_trans = My.Resources.delete_trans
        bmp_edit_trans = My.Resources.edit_trans
        bmp_exit = My.Resources._exit
        bmp_filter = My.Resources.filter
        bmp_help = My.Resources.help
        bmp_import_trans = My.Resources.import_trans
        bmp_loan_calculator = My.Resources.loan_calculator
        bmp_monthly_income = My.Resources.monthly_income
        bmp_budgets = My.Resources.budgets
        bmp_new_ledger = My.Resources.new_ledger
        bmp_new_trans = My.Resources.new_trans
        bmp_open = My.Resources.my_checkbook_ledgers
        bmp_options = My.Resources.options
        bmp_payees = My.Resources.payees
        bmp_receipt = My.Resources.receipt
        bmp_save_as = My.Resources.save_as
        bmp_spending_overview = My.Resources.spending_overview
        bmp_start_balance = My.Resources.start_balance
        bmp_sum_selected = My.Resources.sum_selected
        bmp_uncleared = My.Resources.uncleared
        bmp_updates = My.Resources.updates
        bmp_mostUsed = My.Resources.most_used
        bmp_export_trans = My.Resources.export_trans
        bmp_advanced_filter = My.Resources.advanced_filter
        bmp_duplicate_trans = My.Resources.duplicate_trans
        bmp_close_ledger_Button = My.Resources.close_ledger
        bmp_view_statement_Button = My.Resources.statement
        bmp_my_statements_Button = My.Resources.img_manage_statements

        Dim strDefaultButtonList As String = "0|new_ledger,1|open,2|my_statements,3|save_as,4|new_trans,5|delete_trans,6|edit_trans,7|cleared,8|uncleared,9|categories,10|payees,11|receipt,12|statement,13|sum_selected,14|filter,15|balance"

        Dim strToolBarButtonList As String = String.Empty

        If System.IO.File.Exists(GetLedgerSettingsFile(m_strCurrentFile)) Then

            strToolBarButtonList = GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList)

        Else

            strToolBarButtonList = String.Empty

        End If

        If Not strToolBarButtonList = String.Empty Then

            If Not strToolBarButtonList = strDefaultButtonList Then

                Dim colButtons As New Specialized.StringCollection
                colButtons = Convert_CSV_Button_List_To_Collection(GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList))

                For Each strEntry As String In colButtons

                    Dim chrSeparator As Char() = New Char() {","c}
                    Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                    Dim intIndex As Integer = arrValues(0)
                    Dim strButtonName As String = arrValues(1)

                    If lstCommands.Contains(strButtonName) Then

                        CreateButton(strButtonName)

                    End If

                Next

            Else

                'CREATE DEFAULT BUTTONS
                CreateButton("new_ledger")
                CreateButton("open")
                CreateButton("my_statements")
                CreateButton("save_as")
                CreateButton("new_trans")
                CreateButton("delete_trans")
                CreateButton("edit_trans")
                CreateButton("cleared")
                CreateButton("uncleared")
                CreateButton("categories")
                CreateButton("payees")
                CreateButton("receipt")
                CreateButton("statement")
                CreateButton("sum_selected")
                CreateButton("filter")
                CreateButton("balance")

                'SAVE DEFAULT BUTTON SETTINGS
                SetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList, strDefaultButtonList)

            End If

        End If

    End Sub

    Public Sub CreateButton(ByVal _ButtonName As String)

        Select Case _ButtonName
            Case "about"
                CreateToolStripButton(about_Button, _ButtonName)
            Case "balance"
                CreateToolStripButton(balance_Button, _ButtonName)
            Case "calculator"
                CreateToolStripButton(calculator_Button, _ButtonName)
            Case "categories"
                CreateToolStripButton(categories_Button, _ButtonName)
            Case "cleared"
                CreateToolStripButton(cleared_Button, _ButtonName)
            Case "delete_trans"
                CreateToolStripButton(delete_trans_Button, _ButtonName)
            Case "edit_trans"
                CreateToolStripButton(edit_trans_Button, _ButtonName)
            Case "exit"
                CreateToolStripButton(exit_Button, _ButtonName)
            Case "filter"
                CreateToolStripButton(filter_Button, _ButtonName)
            Case "help"
                CreateToolStripButton(help_Button, _ButtonName)
            Case "import_trans"
                CreateToolStripButton(import_trans_Button, _ButtonName)
            Case "loan_calculator"
                CreateToolStripButton(loan_calculator_Button, _ButtonName)
            Case "monthly_income"
                CreateToolStripButton(monthly_income_Button, _ButtonName)
            Case "budgets"
                CreateToolStripButton(budgets_Button, _ButtonName)
            Case "new_ledger"
                CreateToolStripButton(new_ledger_Button, _ButtonName)
            Case "new_trans"
                CreateToolStripButton(new_trans_Button, _ButtonName)
            Case "open"
                CreateToolStripButton(open_Button, _ButtonName)
            Case "options"
                CreateToolStripButton(options_Button, _ButtonName)
            Case "payees"
                CreateToolStripButton(payees_Button, _ButtonName)
            Case "receipt"
                CreateToolStripButton(receipt_Button, _ButtonName)
            Case "save_as"
                CreateToolStripButton(save_as_Button, _ButtonName)
            Case "spending_overview"
                CreateToolStripButton(spending_overview_Button, _ButtonName)
            Case "start_balance"
                CreateToolStripButton(start_balance_Button, _ButtonName)
            Case "sum_selected"
                CreateToolStripButton(sum_selected_Button, _ButtonName)
            Case "uncleared"
                CreateToolStripButton(uncleared_Button, _ButtonName)
            Case "updates"
                CreateToolStripButton(updates_Button, _ButtonName)
            Case "most_used"
                CreateToolStripButton(mostUsed_Button, _ButtonName)
            Case "export_trans"
                CreateToolStripButton(export_trans_Button, _ButtonName)
            Case "advanced_filter"
                CreateToolStripButton(advanced_filter_Button, _ButtonName)
            Case "duplicate_trans"
                CreateToolStripButton(duplicate_trans_Button, _ButtonName)
            Case "close_ledger"
                CreateToolStripButton(close_ledger_Button, _ButtonName)
            Case "statement"
                CreateToolStripButton(view_statement_Button, _ButtonName)
            Case "my_statements"
                CreateToolStripButton(my_statements_Button, _ButtonName)
            Case Else

        End Select

    End Sub

    Public Sub CreateToolStripButton(ByVal _ToolStripButton As ToolStripButton, ByVal _ButtonName As String)

        _ToolStripButton = New System.Windows.Forms.ToolStripButton()
        _ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        _ToolStripButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        _ToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        Select Case _ButtonName
            Case "about"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "About Checkbook"
                _ToolStripButton.Image = bmp_about
                about_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuAbout_Click
            Case "balance"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Balance Account"
                _ToolStripButton.Image = bmp_balance_account
                balance_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf balance_Button_Click
            Case "calculator"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Windows Calculator"
                _ToolStripButton.Image = bmp_calculator
                calculator_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuCalc_Click
            Case "categories"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Categories"
                _ToolStripButton.Image = bmp_categories
                categories_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuCategories_Click
            Case "cleared"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Clear Selected"
                _ToolStripButton.Image = bmp_cleared
                cleared_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuClearSelected_Click
            Case "delete_trans"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Delete Transaction(s)"
                _ToolStripButton.Image = bmp_delete_trans
                delete_trans_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuDeleteTrans_Click
            Case "edit_trans"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Edit Transaction"
                _ToolStripButton.Image = bmp_edit_trans
                edit_trans_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuEditTrans_Click
            Case "exit"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Exit"
                _ToolStripButton.Image = bmp_exit
                exit_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuExit_Click
            Case "filter"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Quick Filter"
                _ToolStripButton.Image = bmp_filter
                filter_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf filter_Button_Click
            Case "help"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Checkbook Help"
                _ToolStripButton.Image = bmp_help
                help_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuCheckbookHelp_Click
            Case "import_trans"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Import Transactions"
                _ToolStripButton.Image = bmp_import_trans
                import_trans_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuImportTrans_Click
            Case "loan_calculator"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Loan Calculator"
                _ToolStripButton.Image = bmp_loan_calculator
                loan_calculator_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuLoanCalculator_Click
            Case "monthly_income"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Monthly Income"
                _ToolStripButton.Image = bmp_monthly_income
                monthly_income_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuMonthlyIncome_Click
            Case "budgets"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Budgets"
                _ToolStripButton.Image = bmp_budgets
                budgets_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuBudgets_Click
            Case "new_ledger"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "New Ledger"
                _ToolStripButton.Image = bmp_new_ledger
                new_ledger_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuNew_Click
            Case "new_trans"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "New Transaction"
                _ToolStripButton.Image = bmp_new_trans
                new_trans_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuNewTrans_Click
            Case "open"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "My Checkbook Ledgers"
                _ToolStripButton.Image = bmp_open
                open_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuOpen_Click
            Case "options"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Options"
                _ToolStripButton.Image = bmp_options
                options_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuOptions_Click
            Case "payees"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Payees"
                _ToolStripButton.Image = bmp_payees
                payees_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuPayees_Click
            Case "receipt"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "View Receipt"
                _ToolStripButton.Image = bmp_receipt
                receipt_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf receipt_Button_Click
            Case "save_as"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Save As"
                _ToolStripButton.Image = bmp_save_as
                save_as_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuSaveAs_Click
            Case "spending_overview"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Spending Overview"
                _ToolStripButton.Image = bmp_spending_overview
                spending_overview_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuSpendingOverview_Click
            Case "start_balance"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Edit Starting Balance"
                _ToolStripButton.Image = bmp_start_balance
                start_balance_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuEditStartingBalance_Click
            Case "sum_selected"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Sum Selected"
                _ToolStripButton.Image = bmp_sum_selected
                sum_selected_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuSum_Click
            Case "uncleared"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Unclear Selected"
                _ToolStripButton.Image = bmp_uncleared
                uncleared_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuUnclearSelected_Click
            Case "updates"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Check for Update"
                _ToolStripButton.Image = bmp_updates
                updates_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuCheckforUpdate_Click
            Case "most_used"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Most Used Categories/Payees"
                _ToolStripButton.Image = bmp_mostUsed
                mostUsed_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuMostUsed_Click
            Case "export_trans"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Export Transactions"
                _ToolStripButton.Image = bmp_export_trans
                export_trans_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuExportTransactions_Click
            Case "advanced_filter"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Advanced Filter"
                _ToolStripButton.Image = bmp_advanced_filter
                advanced_filter_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuAdvancedFilter_Click
            Case "duplicate_trans"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Duplicate Transaction(s)"
                _ToolStripButton.Image = bmp_duplicate_trans
                duplicate_trans_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuDuplicateTrans_Click
            Case "close_ledger"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "Close Ledger"
                _ToolStripButton.Image = bmp_close_ledger_Button
                close_ledger_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf mnuCloseLedger_Click
            Case "statement"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "View Statement"
                _ToolStripButton.Image = bmp_view_statement_Button
                view_statement_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf view_statement_Button_Click
            Case "my_statements"
                _ToolStripButton.Name = _ButtonName
                _ToolStripButton.Text = "My Statements"
                _ToolStripButton.Image = bmp_my_statements_Button
                my_statements_Button = _ToolStripButton
                AddHandler _ToolStripButton.Click, AddressOf my_statements_Button_Click

        End Select

        tsToolStrip.Items.Add(_ToolStripButton)

    End Sub

    Private Sub mnuBudgets_Click(sender As Object, e As EventArgs) Handles mnuBudgets.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intRowCount As Integer = 0
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

        Dim intRowCount As Integer = 0
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

        If m_intTransactionCount = 0 Then

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

                Dim strExportPath As String = String.Empty
                strExportPath = sfdDialog.FileName

                If CheckbookMsg.ShowMessage("Are you sure you want to export your transactions to " & strExportPath & "?", MsgButtons.YesNo, "Checkbook will export all loaded transactions. If you are currently filtering or balancing your ledger only those visible will export.", Question) = DialogResult.Yes Then

                    Try

                        UIManager.SetCursor(Me, Cursors.WaitCursor)

                        ExportTransactions(dgvLedger, strExportPath)

                        UIManager.SetCursor(Me, Cursors.Default)

                        If CheckbookMsg.ShowMessage("Your transactions have exported successfully.", MsgButtons.YesNo, "Would you like to open the file now?", Question) = DialogResult.Yes Then

                            Process.Start(strExportPath)

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

    Private Sub ExportTransactions(ByVal _DataGridView As DataGridView, ByVal _Path As String)

        Dim writer As New StreamWriter(_Path)

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
        writer = Nothing

    End Sub

    Private Sub mnuAdvancedFilter_Click(sender As Object, e As EventArgs) Handles mnuAdvancedFilter.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If m_intTransactionCount = 0 Then

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

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no items selected to duplicate", MsgButtons.OK, "", Exclamation)

        Else

            ' GET CURRENTLY SELECTED TRANSACTIONS
            ' LOOP THROUGH EACH ONE AND INSERT INTO DATABASE

            Try

                UIManager.SetCursor(Me, Cursors.WaitCursor)

                For Each row As DataGridViewRow In dgvLedger.SelectedRows

                    Dim i As Integer = 0
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
                    newTransaction.StatementName = dgvLedger.Rows(i).Cells("StatementName").Value
                    newTransaction.StatementFileName = dgvLedger.Rows(i).Cells("StatementFileName").Value

                    If Not newTransaction.Receipt = String.Empty Then

                        Dim strReceiptToCopy As String = String.Empty
                        Dim strNewReceipt As String = String.Empty

                        strReceiptToCopy = AppendReceiptPath(m_strCurrentFile, newTransaction.Receipt)

                        newTransaction.Receipt = newTransaction.Receipt.Remove(0, 13)

                        ' ADD NEW TIMESTAMP
                        Dim timeStamp As String
                        timeStamp = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds).ToString

                        newTransaction.Receipt = timeStamp & newTransaction.Receipt

                        strNewReceipt = AppendReceiptPath(m_strCurrentFile, newTransaction.Receipt)

                        My.Computer.FileSystem.CopyFile(strReceiptToCopy, strNewReceipt, True)

                    End If

                    FileCon.Connect()
                    FileCon.SQLinsert("INSERT INTO LedgerData (Type,Category,TransDate,Payment,Deposit,Payee,Description,Cleared,Receipt,StatementName,StatementFileName) VALUES('" & newTransaction.Type & "','" & newTransaction.Category & "','" & newTransaction.TransDate & "','" & newTransaction.Payment & "','" & newTransaction.Deposit & "','" & newTransaction.Payee & "','" & newTransaction.Description & "'," & newTransaction.Cleared & ",'" & newTransaction.Receipt & "','" & newTransaction.StatementName & "','" & newTransaction.StatementFileName & "')")
                    FileCon.Close()

                Next

                If m_blnLedgerIsBeingBalanced Then

                    DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                ElseIf m_blnLedgerIsBeingFiltered And Not txtFilter.Text = String.Empty Then

                    DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

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

    Private Sub mnuDuplicateTrans_Click(sender As Object, e As EventArgs) Handles mnuDuplicateTrans.Click, cxmnuDuplicateTrans.Click

        DuplicateTransactions()

    End Sub

    Private Sub mnuCloseLedger_Click(sender As Object, e As EventArgs) Handles mnuCloseLedger.Click

        Me.dgvLedger.DataSource = Nothing
        Me.dgvLedger.Columns.Clear()

        m_strCurrentFile = String.Empty

        UIManager.Maintain_DisabledMainFormUI()

    End Sub

    Private Sub mnuRemoveReceipt_Click(sender As Object, e As EventArgs) Handles mnuRemoveReceipt.Click, cxmnuRemoveReceipt.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            If CheckbookMsg.ShowMessage("Are you sure you want to remove the receipt(s) from the selected transaction(s)?", MsgButtons.YesNo, "Removing a receipt cannot be undone", Question) = DialogResult.Yes Then

                Try

                    UIManager.SetCursor(Me, Cursors.WaitCursor)

                    For Each dgvRow As DataGridViewRow In dgvLedger.SelectedRows

                        Dim intRowIndex As Integer = 0
                        intRowIndex = dgvLedger.Rows.IndexOf(dgvRow)

                        Dim dgvID As Integer = dgvLedger.Item("ID", intRowIndex).Value

                        FileCon.Connect()
                        FileCon.SQLupdate("UPDATE LedgerData SET Receipt ='' WHERE ID = " & dgvID & "")
                        FileCon.Close()

                    Next

                    If m_blnLedgerIsBeingBalanced Then

                        DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered And Not txtFilter.Text = String.Empty Then

                        DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                        DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                    Else

                        DataCon.SelectAllLedgerData_UpdateAccountDetails()

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Remove Receipt Error", MsgButtons.OK, "An error occurred while removing the selected receipts" & vbNewLine & vbNewLine & ex.Message, Exclamation)
                    Exit Sub

                Finally

                    FileCon.Close()
                    UIManager.SetCursor(Me, Cursors.Default)

                End Try

            End If

        End If

    End Sub

    Private Sub mnuRemoveStatement_Click(sender As Object, e As EventArgs) Handles mnuRemoveStatement.Click, cxmnuRemoveStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvLedger.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

        Else

            If CheckbookMsg.ShowMessage("Are you sure you want to remove the statement(s) from the selected transaction(s)?", MsgButtons.YesNo, "Removing a statement cannot be undone", Question) = DialogResult.Yes Then

                Try

                    UIManager.SetCursor(Me, Cursors.WaitCursor)

                    For Each dgvRow As DataGridViewRow In dgvLedger.SelectedRows

                        Dim intRowIndex As Integer = 0

                        intRowIndex = dgvLedger.Rows.IndexOf(dgvRow)
                        Dim dgvID As Integer = dgvLedger.Item("ID", intRowIndex).Value

                        FileCon.Connect()
                        FileCon.SQLupdate("UPDATE LedgerData SET StatementName ='', StatementFileName ='' WHERE ID = " & dgvID & "")
                        FileCon.Close()

                    Next

                    If m_blnLedgerIsBeingBalanced Then

                        DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered And Not txtFilter.Text = String.Empty Then

                        DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                        DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                    Else

                        DataCon.SelectAllLedgerData_UpdateAccountDetails()

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Remove Statement Error", MsgButtons.OK, "An error occurred while removing the selected statements" & vbNewLine & vbNewLine & ex.Message, Exclamation)
                    Exit Sub

                Finally

                    FileCon.Close()
                    UIManager.SetCursor(Me, Cursors.Default)

                End Try

            End If

        End If

    End Sub

End Class
