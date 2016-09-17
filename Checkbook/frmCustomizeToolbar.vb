'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016 Christopher Mackay

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

Public Class frmCustomizeToolbar

    Private UIManager As New clsUIManager

    Private Sub AddColumns()

        Dim colCheckbox As New DataGridViewCheckBoxColumn
        Dim colIcon As New DataGridViewImageColumn
        Dim colCommandText As New DataGridViewTextBoxColumn
        Dim colCommandName As New DataGridViewTextBoxColumn

        colCheckbox.CellTemplate = New DataGridViewCheckBoxCell
        colCheckbox.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colCheckbox.Name = "include"
        colCheckbox.HeaderText = "Add"
        colCheckbox.Width = 60

        colIcon.CellTemplate = New DataGridViewImageCell
        colIcon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colIcon.Name = "icon"
        colIcon.HeaderText = "Icon"
        colIcon.ReadOnly = True
        colIcon.Width = 60

        colCommandText.CellTemplate = New DataGridViewTextBoxCell
        colCommandText.Name = "command_text"
        colCommandText.HeaderText = "Command Name"
        colCommandText.ReadOnly = True

        'HIDDEN COLUMN THAT HAS THE BUTTON NAME
        colCommandName.CellTemplate = New DataGridViewTextBoxCell
        colCommandName.Name = "name"
        colCommandName.HeaderText = "name"
        colCommandName.ReadOnly = True
        colCommandName.Visible = False

        dgvIcons.Columns.Add(colCheckbox)
        dgvIcons.Columns.Add(colIcon)
        dgvIcons.Columns.Add(colCommandText)
        dgvIcons.Columns.Add(colCommandName)

    End Sub

    Private Sub AddRows()

        With MainForm

            AddRow(.img_new_ledger, "new_ledger", "New Ledger")
            AddRow(.img_open, "open", "Open Ledger")
            AddRow(.img_save_as, "save_as", "Save As")
            AddRow(.img_new_trans, "new_trans", "New Transaction")
            AddRow(.img_delete_trans, "delete_trans", "Delete Transaction(s)")
            AddRow(.img_edit_trans, "edit_trans", "Edit Transaction")
            AddRow(.img_cleared, "cleared", "Clear Selected")
            AddRow(.img_uncleared, "uncleared", "Unclear Selected")
            AddRow(.img_categories, "categories", "Categories")
            AddRow(.img_payees, "payees", "Payees")
            AddRow(.img_receipt, "receipt", "View Receipt")
            AddRow(.img_sum_selected, "sum_selected", "Sum Selected")
            AddRow(.img_filter, "filter", "Quick Filter")
            AddRow(.img_balance_account, "balance", "Balance Account")
            AddRow(.img_about, "about", "About Checkbook")
            AddRow(.img_calculator, "calculator", "Windows Calculator")
            AddRow(.img_exit, "exit", "Exit")
            AddRow(.img_help, "help", "Checkbook Help")
            AddRow(.img_import_trans, "import_trans", "Import Transactions")
            AddRow(.img_ledger_manager, "ledger_manager", "Ledger Manager")
            AddRow(.img_loan_calculator, "loan_calculator", "Loan Calculator")
            AddRow(.img_message, "message", "Unknown/Uncategorized")
            AddRow(.img_monthly_income, "monthly_income", "Monthly Income")
            AddRow(.img_budgets, "budgets", "Budgets")
            AddRow(.img_options, "options", "Options")
            AddRow(.img_spending_overview, "spending_overview", "Spending Overview")
            AddRow(.img_start_balance, "start_balance", "Edit Starting Balance")
            AddRow(.img_updates, "updates", "Check for Update")
            AddRow(.img_mostUsed, "most_used", "Most Used Categories/Payees")
            AddRow(.img_export_trans, "export_trans", "Export Transactions")
            AddRow(.img_advanced_filter, "advanced_filter", "Advanced Filter")

        End With

    End Sub

    Private Sub AddRow(ByVal _image As Bitmap, ByVal _headerText As String, ByVal _commandName As String)

        dgvIcons.Rows.Add(False, _image, _commandName, _headerText)

    End Sub

    Private Sub InsertRow(ByVal _index As Integer, ByVal _image As Bitmap, ByVal _headerText As String, ByVal _commandName As String)

        dgvIcons.Rows.Insert(_index, False, _image, _commandName, _headerText)

    End Sub

    Private Sub InsertSavedButtonsAtSavedIndex()

        If Not My.Settings.ButtonList Is Nothing Then 'REMOVES ROWS FROM DGV THAT CONTAIN THE COMMAND IN SETTINGS. THIS ALLOWS THE SAVED BUTTON SETTING TO BE INSERTED AT THE CORRECT ROW INDEX.

            For Each strEntry In My.Settings.ButtonList

                Dim chrSeparator As Char() = New Char() {","c}
                Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                Dim intIndex As Integer = arrValues(0)
                Dim strCommandName As String = arrValues(1)

                If MainForm.fullListCommandsList.Contains(strCommandName) Then

                    For Each dgvRow As DataGridViewRow In dgvIcons.Rows

                        If dgvRow.Cells.Item("name").Value = strCommandName Then

                            dgvIcons.Rows.Remove(dgvRow)

                        End If

                    Next

                End If

            Next

            'INSERT ROWS AT PARTICULAR INDEX THAT BUTTONS WERE SAVED
            For Each strEntry As String In My.Settings.ButtonList

                Dim chrSeparator As Char() = New Char() {","c}
                Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                Dim intIndex As Integer = arrValues(0)
                Dim strCommandName As String = arrValues(1)

                'IF THE LIST DOESNT CONTAIN THE ITEM THEN ADD THE ROW.
                'ONCE ALL THE ONES THAT ARE NOT IN THE LIST ARE ADDED THEN INSERT THE OTHERS THAT ARE AT THE SAVED INDEX
                'SO THE ITEMS ARE LOADED IN THE DATAGRIDVIEW IN THE CORRECT ORDER.

                With MainForm

                    Select Case strCommandName
                        Case "about"
                            InsertRow(intIndex, .img_about, "about", "About Checkbook")
                        Case "balance"
                            InsertRow(intIndex, .img_balance_account, "balance", "Balance Account")
                        Case "calculator"
                            InsertRow(intIndex, .img_calculator, "calculator", "Windows Calculator")
                        Case "categories"
                            InsertRow(intIndex, .img_categories, "categories", "Categories")
                        Case "cleared"
                            InsertRow(intIndex, .img_cleared, "cleared", "Clear Selected")
                        Case "delete_trans"
                            InsertRow(intIndex, .img_delete_trans, "delete_trans", "Delete Transaction(s)")
                        Case "edit_trans"
                            InsertRow(intIndex, .img_edit_trans, "edit_trans", "Edit Transaction")
                        Case "exit"
                            InsertRow(intIndex, .img_exit, "exit", "Exit")
                        Case "filter"
                            InsertRow(intIndex, .img_filter, "filter", "Quick Filter")
                        Case "help"
                            InsertRow(intIndex, .img_help, "help", "Checkbook Help")
                        Case "import_trans"
                            InsertRow(intIndex, .img_import_trans, "import_trans", "Import Transactions")
                        Case "ledger_manager"
                            InsertRow(intIndex, .img_ledger_manager, "ledger_manager", "Ledger Mananger")
                        Case "loan_calculator"
                            InsertRow(intIndex, .img_loan_calculator, "loan_calculator", "Loan Calculator")
                        Case "message"
                            InsertRow(intIndex, .img_message, "message", "Unknown/Uncategorized")
                        Case "monthly_income"
                            InsertRow(intIndex, .img_monthly_income, "monthly_income", "Monthly Income")
                        Case "budgets"
                            InsertRow(intIndex, .img_budgets, "budgets", "Budgets")
                        Case "new_ledger"
                            InsertRow(intIndex, .img_new_ledger, "new_ledger", "New Ledger")
                        Case "new_trans"
                            InsertRow(intIndex, .img_new_trans, "new_trans", "New Transaction")
                        Case "open"
                            InsertRow(intIndex, .img_open, "open", "Open Ledger")
                        Case "options"
                            InsertRow(intIndex, .img_options, "options", "Options")
                        Case "payees"
                            InsertRow(intIndex, .img_payees, "payees", "Payees")
                        Case "receipt"
                            InsertRow(intIndex, .img_receipt, "receipt", "View Receipt")
                        Case "save_as"
                            InsertRow(intIndex, .img_save_as, "save_as", "Save As")
                        Case "spending_overview"
                            InsertRow(intIndex, .img_spending_overview, "spending_overview", "Spending Overview")
                        Case "start_balance"
                            InsertRow(intIndex, .img_start_balance, "start_balance", "Edit Starting Balance")
                        Case "sum_selected"
                            InsertRow(intIndex, .img_sum_selected, "sum_selected", "Sum Selected")
                        Case "uncleared"
                            InsertRow(intIndex, .img_uncleared, "uncleared", "Unclear Selected")
                        Case "updates"
                            InsertRow(intIndex, .img_updates, "updates", "Check for Update")
                        Case "most_used"
                            InsertRow(intIndex, .img_mostUsed, "most_used", "Most Used Categories/Payees")
                        Case "export_trans"
                            InsertRow(intIndex, .img_export_trans, "export_trans", "Export Transactions")
                        Case "advanced_filter"
                            InsertRow(intIndex, .img_advanced_filter, "advanced_filter", "Advanced Filter")
                        Case Else

                    End Select

                End With

            Next

        End If

        'CHECKS ALL THE ROWS THAT HAVE SAVED BUTTONS. THIS TRIGGERS DataGridCellValueChanged & CreateButtons_On_MainForm()
        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim buttonName As String = dgvRow.Cells.Item("name").Value

            For Each strEntry As String In My.Settings.ButtonList

                Dim chrSeparator As Char() = New Char() {","c}
                Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                Dim intIndex As Integer = arrValues(0)
                Dim strCommandName As String = arrValues(1)

                If buttonName = strCommandName Then

                    dgvRow.Cells.Item("include").Value = CheckState.Checked

                End If

            Next

        Next

    End Sub

    Private Sub frmCustomizeToolbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MainModule.DrawingControl.SuspendDrawing(dgvIcons)
        MainModule.DrawingControl.SetDoubleBuffered(dgvIcons)

        AddColumns()
        AddRows()
        InsertSavedButtonsAtSavedIndex()

        MainModule.DrawingControl.ResumeDrawing(dgvIcons)

        dgvIcons.ClearSelection()

    End Sub

    'Ends Edit Mode So CellValueChanged Event Can Fire
    Private Sub EndEditMode(sender As System.Object, e As EventArgs) Handles dgvIcons.CurrentCellDirtyStateChanged
        'if current cell of grid is dirty, commits edit
        If dgvIcons.IsCurrentCellDirty Then
            dgvIcons.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    'Executes when Cell Value on a DataGridView changes
    Private Sub DataGridCellValueChanged(sender As DataGridView, e As DataGridViewCellEventArgs) Handles dgvIcons.CellValueChanged
        'check that row isn't -1, i.e. creating datagrid header
        If e.RowIndex = -1 Then Exit Sub

        'mark as dirty
        'IsDirty = True
        CreateButtons_On_MainForm()
    End Sub

    Private Sub SaveButtonSettings()

        My.Settings.ButtonList = New System.Collections.Specialized.StringCollection

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim intRowIndex As Integer = dgvRow.Index
            Dim strCommandName As String = dgvRow.Cells.Item("name").Value.ToString
            Dim commandIsChecked As Boolean = dgvRow.Cells.Item("include").EditedFormattedValue

            Dim strEntry As String = intRowIndex & "," & strCommandName

            If commandIsChecked Then

                My.Settings.ButtonList.Add(strEntry)
                My.Settings.Save()

            End If

        Next

    End Sub

    Private Sub CreateButtons_On_MainForm()

        MainForm.tsToolStrip.Items.Clear()

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim strButtonName As String = dgvRow.Cells.Item("name").Value.ToString
            Dim commandIsChecked As Boolean = dgvRow.Cells.Item("include").EditedFormattedValue

            If commandIsChecked Then

                With MainForm

                    Select Case strButtonName
                        Case "about"
                            MainForm.CreateToolStripButton(.about_Button, strButtonName)
                        Case "balance"
                            MainForm.CreateToolStripButton(.balance_Button, strButtonName)
                        Case "calculator"
                            MainForm.CreateToolStripButton(.calculator_Button, strButtonName)
                        Case "categories"
                            MainForm.CreateToolStripButton(.categories_Button, strButtonName)
                        Case "cleared"
                            MainForm.CreateToolStripButton(.cleared_Button, strButtonName)
                        Case "delete_trans"
                            MainForm.CreateToolStripButton(.delete_trans_Button, strButtonName)
                        Case "edit_trans"
                            MainForm.CreateToolStripButton(.edit_trans_Button, strButtonName)
                        Case "exit"
                            MainForm.CreateToolStripButton(.exit_Button, strButtonName)
                        Case "filter"
                            MainForm.CreateToolStripButton(.filter_Button, strButtonName)
                        Case "help"
                            MainForm.CreateToolStripButton(.help_Button, strButtonName)
                        Case "import_trans"
                            MainForm.CreateToolStripButton(.import_trans_Button, strButtonName)
                        Case "ledger_manager"
                            MainForm.CreateToolStripButton(.ledger_manager_Button, strButtonName)
                        Case "loan_calculator"
                            MainForm.CreateToolStripButton(.loan_calculator_Button, strButtonName)
                        Case "message"
                            MainForm.CreateToolStripButton(.message_Button, strButtonName)
                        Case "monthly_income"
                            MainForm.CreateToolStripButton(.monthly_income_Button, strButtonName)
                        Case "budgets"
                            MainForm.CreateToolStripButton(.budgets_Button, strButtonName)
                        Case "new_ledger"
                            MainForm.CreateToolStripButton(.new_ledger_Button, strButtonName)
                        Case "new_trans"
                            MainForm.CreateToolStripButton(.new_trans_Button, strButtonName)
                        Case "open"
                            MainForm.CreateToolStripButton(.open_Button, strButtonName)
                        Case "options"
                            MainForm.CreateToolStripButton(.options_Button, strButtonName)
                        Case "payees"
                            MainForm.CreateToolStripButton(.payees_Button, strButtonName)
                        Case "receipt"
                            MainForm.CreateToolStripButton(.reciept_Button, strButtonName)
                        Case "save_as"
                            MainForm.CreateToolStripButton(.save_as_Button, strButtonName)
                        Case "spending_overview"
                            MainForm.CreateToolStripButton(.spending_overview_Button, strButtonName)
                        Case "start_balance"
                            MainForm.CreateToolStripButton(.start_balance_Button, strButtonName)
                        Case "sum_selected"
                            MainForm.CreateToolStripButton(.sum_selected_Button, strButtonName)
                        Case "uncleared"
                            MainForm.CreateToolStripButton(.uncleared_Button, strButtonName)
                        Case "updates"
                            MainForm.CreateToolStripButton(.updates_Button, strButtonName)
                        Case "most_used"
                            MainForm.CreateToolStripButton(.mostUsed_Button, strButtonName)
                        Case "export_trans"
                            MainForm.CreateToolStripButton(.export_trans_Button, strButtonName)
                        Case "advanced_filter"
                            MainForm.CreateToolStripButton(.advanced_filter_Button, strButtonName)
                        Case Else

                    End Select

                End With

            End If

        Next

    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click

        Dim dgv As DataGridView = dgvIcons
        Dim intTop As Integer
        intTop = dgv.FirstDisplayedScrollingRowIndex

        Try
            Dim intTotalRows As Integer = dgv.Rows.Count
            ' get index of the row for the selected cell
            Dim intRowIndex As Integer = dgv.SelectedCells(0).OwningRow.Index
            If intRowIndex = 0 Then
                Return
            End If
            ' get index of the column for the selected cell
            Dim intColIndex As Integer = dgv.SelectedCells(0).OwningColumn.Index
            Dim dgvRow As DataGridViewRow = dgv.Rows(intRowIndex)
            dgv.Rows.Remove(dgvRow)
            dgv.Rows.Insert(intRowIndex - 1, dgvRow)
            dgv.ClearSelection()
            dgv.Rows(intRowIndex - 1).Cells(intColIndex).Selected = True

            If dgv.Controls(1).Visible = True Then

                dgv.FirstDisplayedScrollingRowIndex = intTop

            End If

            CreateButtons_On_MainForm()
        Catch
        End Try

    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click

        Dim dgv As DataGridView = dgvIcons
        Dim intTop As Integer
        intTop = dgv.FirstDisplayedScrollingRowIndex

        Try
            Dim intTotalRows As Integer = dgv.Rows.Count
            ' get index of the row for the selected cell
            Dim intRowIndex As Integer = dgv.SelectedCells(0).OwningRow.Index
            If intRowIndex = intTotalRows - 1 Then
                Return
            End If
            ' get index of the column for the selected cell
            Dim intColIndex As Integer = dgv.SelectedCells(0).OwningColumn.Index
            Dim dgvRow As DataGridViewRow = dgv.Rows(intRowIndex)
            dgv.Rows.Remove(dgvRow)
            dgv.Rows.Insert(intRowIndex + 1, dgvRow)
            dgv.ClearSelection()
            dgv.Rows(intRowIndex + 1).Cells(intColIndex).Selected = True

            If dgv.Controls(1).Visible = True Then

                dgv.FirstDisplayedScrollingRowIndex = intTop

            End If

            CreateButtons_On_MainForm()
        Catch
        End Try

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        SaveButtonSettings()
        MainForm.LoadButtonSettings_Or_CreateDefaultButtons()
        Me.Dispose()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As EventArgs) Handles MyBase.Closed

        MainForm.LoadButtonSettings_Or_CreateDefaultButtons()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        MainForm.LoadButtonSettings_Or_CreateDefaultButtons()
        Me.Dispose()

    End Sub

    Private Sub btnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click

        'SET ALL BUTTONS TO DEFAULT SETTINGS.
        'DO NOT SAVE THE SETTINGS YET.
        'SAVE SETTINGS ON 'OK' IF THE USER DECIDES TO CANCEL
        'CREATE DEFAULT BUTTONS

        MainForm.tsToolStrip.Items.Clear()
        dgvIcons.Columns.Clear()
        dgvIcons.Rows.Clear()

        AddColumns()
        AddRows()

        With MainForm

            .CreateButton("new_ledger")
            .CreateButton("open")
            .CreateButton("save_as")
            .CreateButton("new_trans")
            .CreateButton("delete_trans")
            .CreateButton("edit_trans")
            .CreateButton("cleared")
            .CreateButton("uncleared")
            .CreateButton("categories")
            .CreateButton("payees")
            .CreateButton("receipt")
            .CreateButton("sum_selected")
            .CreateButton("filter")
            .CreateButton("balance")

        End With

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim strButtonName As String = dgvRow.Cells.Item("name").Value

            Select Case strButtonName
                Case "new_ledger"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "open"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "save_as"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "new_trans"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "delete_trans"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "edit_trans"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "cleared"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "uncleared"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "categories"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "payees"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "receipt"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "sum_selected"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "filter"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "balance"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case Else

            End Select

        Next

        dgvIcons.ClearSelection()

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Help.ShowHelp(Me, m_helpProvider.HelpNamespace, "customize_toolbar.html")

    End Sub

End Class