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

            AddRow(.bmp_new_ledger, "new_ledger", "New Ledger")
            AddRow(.bmp_open, "open", "My Checkbook Ledgers")
            AddRow(.bmp_my_statements_Button, "my_statements", "My Statements")
            AddRow(.bmp_save_as, "save_as", "Save As")
            AddRow(.bmp_new_trans, "new_trans", "New Transaction")
            AddRow(.bmp_delete_trans, "delete_trans", "Delete Transaction(s)")
            AddRow(.bmp_edit_trans, "edit_trans", "Edit Transaction")
            AddRow(.bmp_cleared, "cleared", "Clear Selected")
            AddRow(.bmp_uncleared, "uncleared", "Unclear Selected")
            AddRow(.bmp_categories, "categories", "Categories")
            AddRow(.bmp_payees, "payees", "Payees")
            AddRow(.bmp_receipt, "receipt", "View Receipt")
            AddRow(.bmp_view_statement_Button, "statement", "View Statement")
            AddRow(.bmp_sum_selected, "sum_selected", "Sum Selected")
            AddRow(.bmp_filter, "filter", "Quick Filter")
            AddRow(.bmp_balance_account, "balance", "Balance Account")
            AddRow(.bmp_about, "about", "About Checkbook")
            AddRow(.bmp_calculator, "calculator", "Windows Calculator")
            AddRow(.bmp_exit, "exit", "Exit")
            AddRow(.bmp_help, "help", "Checkbook Help")
            AddRow(.bmp_import_trans, "import_trans", "Import Transactions")
            AddRow(.bmp_loan_calculator, "loan_calculator", "Loan Calculator")
            AddRow(.bmp_monthly_income, "monthly_income", "Monthly Income")
            AddRow(.bmp_budgets, "budgets", "Budgets")
            AddRow(.bmp_options, "options", "Options")
            AddRow(.bmp_spending_overview, "spending_overview", "Spending Overview")
            AddRow(.bmp_start_balance, "start_balance", "Edit Starting Balance")
            AddRow(.bmp_updates, "updates", "Check for Update")
            AddRow(.bmp_mostUsed, "most_used", "Most Used Categories/Payees")
            AddRow(.bmp_export_trans, "export_trans", "Export Transactions")
            AddRow(.bmp_advanced_filter, "advanced_filter", "Advanced Filter")
            AddRow(.bmp_duplicate_trans, "duplicate_trans", "Duplicate Transaction(s)")
            AddRow(.bmp_close_ledger_Button, "close_ledger", "Close Ledger")

        End With

    End Sub

    Private Sub AddRow(ByVal _Bitmap As Bitmap, ByVal _HeaderText As String, ByVal _CommandName As String)

        dgvIcons.Rows.Add(False, _Bitmap, _CommandName, _HeaderText)

    End Sub

    Private Sub InsertRow(ByVal _Index As Integer, ByVal _Bitmap As Bitmap, ByVal _HeaderText As String, ByVal _CommandName As String)

        dgvIcons.Rows.Insert(_Index, False, _Bitmap, _CommandName, _HeaderText)

    End Sub

    Private Sub InsertSavedButtonsAtSavedIndex()

        Dim colButtonCollection As New Specialized.StringCollection
        colButtonCollection = Convert_CSV_Button_List_To_Collection(GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList))
        'SHOW OR HIDE THE TOOLSTRIP BUTTONS

        'REMOVES ROWS FROM DGV THAT CONTAIN THE COMMAND IN SETTINGS. THIS ALLOWS THE SAVED BUTTON SETTING TO BE INSERTED AT THE CORRECT ROW INDEX.
        If Not GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList) = "" Then

            For Each strEntry In colButtonCollection

                Dim chrSeparator As Char() = New Char() {","c}
                Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                Dim intIndex As Integer = arrValues(0)
                Dim strCommandName As String = arrValues(1)

                If MainForm.lstCommands.Contains(strCommandName) Then

                    For Each dgvRow As DataGridViewRow In dgvIcons.Rows

                        If dgvRow.Cells.Item("name").Value = strCommandName Then

                            dgvIcons.Rows.Remove(dgvRow)

                        End If

                    Next

                End If

            Next

            'INSERT ROWS AT PARTICULAR INDEX THAT BUTTONS WERE SAVED
            For Each strEntry As String In colButtonCollection

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
                            InsertRow(intIndex, .bmp_about, "about", "About Checkbook")
                        Case "balance"
                            InsertRow(intIndex, .bmp_balance_account, "balance", "Balance Account")
                        Case "calculator"
                            InsertRow(intIndex, .bmp_calculator, "calculator", "Windows Calculator")
                        Case "categories"
                            InsertRow(intIndex, .bmp_categories, "categories", "Categories")
                        Case "cleared"
                            InsertRow(intIndex, .bmp_cleared, "cleared", "Clear Selected")
                        Case "delete_trans"
                            InsertRow(intIndex, .bmp_delete_trans, "delete_trans", "Delete Transaction(s)")
                        Case "edit_trans"
                            InsertRow(intIndex, .bmp_edit_trans, "edit_trans", "Edit Transaction")
                        Case "exit"
                            InsertRow(intIndex, .bmp_exit, "exit", "Exit")
                        Case "filter"
                            InsertRow(intIndex, .bmp_filter, "filter", "Quick Filter")
                        Case "help"
                            InsertRow(intIndex, .bmp_help, "help", "Checkbook Help")
                        Case "import_trans"
                            InsertRow(intIndex, .bmp_import_trans, "import_trans", "Import Transactions")
                        Case "loan_calculator"
                            InsertRow(intIndex, .bmp_loan_calculator, "loan_calculator", "Loan Calculator")
                        Case "monthly_income"
                            InsertRow(intIndex, .bmp_monthly_income, "monthly_income", "Monthly Income")
                        Case "budgets"
                            InsertRow(intIndex, .bmp_budgets, "budgets", "Budgets")
                        Case "new_ledger"
                            InsertRow(intIndex, .bmp_new_ledger, "new_ledger", "New Ledger")
                        Case "new_trans"
                            InsertRow(intIndex, .bmp_new_trans, "new_trans", "New Transaction")
                        Case "open"
                            InsertRow(intIndex, .bmp_open, "open", "My Checkbook Ledgers")
                        Case "options"
                            InsertRow(intIndex, .bmp_options, "options", "Options")
                        Case "payees"
                            InsertRow(intIndex, .bmp_payees, "payees", "Payees")
                        Case "receipt"
                            InsertRow(intIndex, .bmp_receipt, "receipt", "View Receipt")
                        Case "save_as"
                            InsertRow(intIndex, .bmp_save_as, "save_as", "Save As")
                        Case "spending_overview"
                            InsertRow(intIndex, .bmp_spending_overview, "spending_overview", "Spending Overview")
                        Case "start_balance"
                            InsertRow(intIndex, .bmp_start_balance, "start_balance", "Edit Starting Balance")
                        Case "sum_selected"
                            InsertRow(intIndex, .bmp_sum_selected, "sum_selected", "Sum Selected")
                        Case "uncleared"
                            InsertRow(intIndex, .bmp_uncleared, "uncleared", "Unclear Selected")
                        Case "updates"
                            InsertRow(intIndex, .bmp_updates, "updates", "Check for Update")
                        Case "most_used"
                            InsertRow(intIndex, .bmp_mostUsed, "most_used", "Most Used Categories/Payees")
                        Case "export_trans"
                            InsertRow(intIndex, .bmp_export_trans, "export_trans", "Export Transactions")
                        Case "advanced_filter"
                            InsertRow(intIndex, .bmp_advanced_filter, "advanced_filter", "Advanced Filter")
                        Case "duplicate_trans"
                            InsertRow(intIndex, .bmp_duplicate_trans, "duplicate_trans", "Duplicate Transaction(s)")
                        Case "close_ledger"
                            InsertRow(intIndex, .bmp_close_ledger_Button, "close_ledger", "Close Ledger")
                        Case "statement"
                            InsertRow(intIndex, .bmp_view_statement_Button, "statement", "View Statement")
                        Case "my_statements"
                            InsertRow(intIndex, .bmp_my_statements_Button, "my_statements", "My Statements")

                        Case Else

                    End Select

                End With

            Next

        End If

        If Not GetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList) = "" Then

            'CHECKS ALL THE ROWS THAT HAVE SAVED BUTTONS. THIS TRIGGERS DataGridCellValueChanged & CreateButtons_On_MainForm()
            For Each dgvRow As DataGridViewRow In dgvIcons.Rows

                Dim strButtonName As String = String.Empty
                strButtonName = dgvRow.Cells.Item("name").Value

                For Each strEntry As String In colButtonCollection

                    Dim chrSeparator As Char() = New Char() {","c}
                    Dim arrValues As String() = strEntry.Split(chrSeparator, StringSplitOptions.None)

                    Dim intIndex As Integer = arrValues(0)
                    Dim strCommandName As String = arrValues(1)

                    If strButtonName = strCommandName Then

                        dgvRow.Cells.Item("include").Value = CheckState.Checked

                    End If

                Next

            Next

        End If

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

        Dim colButtonCollection As New Specialized.StringCollection

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim intRowIndex As Integer = dgvRow.Index
            Dim strCommandName As String = dgvRow.Cells.Item("name").Value.ToString
            Dim blnCommandIsChecked As Boolean = dgvRow.Cells.Item("include").EditedFormattedValue

            ' FORMAT TO BE SAVED IN SETTINGS
            ' 0|new_ledger,1|open,2|my_statements,3|save_as,4|new_trans,5|delete_trans,6|edit_trans,7|cleared,8|uncleared,9|categories,10|payees,11|receipt,12|statement,13|sum_selected,14|filter,15|balance

            If blnCommandIsChecked Then

                Dim strEntry As String = String.Empty
                strEntry = intRowIndex & "," & strCommandName

                colButtonCollection.Add(strEntry)

            End If

        Next

        SetCheckbookSettingsValue(CheckbookSettings.ToolBarButtonList, Convert_ButtonCollection_To_Settings_String(colButtonCollection))

    End Sub

    Private Sub CreateButtons_On_MainForm()

        MainForm.tsToolStrip.Items.Clear()

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim strButtonName As String = dgvRow.Cells.Item("name").Value.ToString
            Dim blnCommandIsChecked As Boolean = dgvRow.Cells.Item("include").EditedFormattedValue

            If blnCommandIsChecked Then

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
                        Case "loan_calculator"
                            MainForm.CreateToolStripButton(.loan_calculator_Button, strButtonName)
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
                            MainForm.CreateToolStripButton(.receipt_Button, strButtonName)
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
                        Case "duplicate_trans"
                            MainForm.CreateToolStripButton(.duplicate_trans_Button, strButtonName)
                        Case "close_ledger"
                            MainForm.CreateToolStripButton(.close_ledger_Button, strButtonName)
                        Case "statement"
                            MainForm.CreateToolStripButton(.view_statement_Button, strButtonName)
                        Case "my_statements"
                            MainForm.CreateToolStripButton(.my_statements_Button, strButtonName)
                        Case Else
                    End Select

                End With

            End If

        Next

    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click

        Dim dgv As DataGridView = dgvIcons
        Dim intTop As Integer = 0
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
        Dim intTop As Integer = 0
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
            .CreateButton("my_statements")
            .CreateButton("save_as")
            .CreateButton("new_trans")
            .CreateButton("delete_trans")
            .CreateButton("edit_trans")
            .CreateButton("cleared")
            .CreateButton("uncleared")
            .CreateButton("categories")
            .CreateButton("payees")
            .CreateButton("receipt")
            .CreateButton("statement")
            .CreateButton("sum_selected")
            .CreateButton("filter")
            .CreateButton("balance")

        End With

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            Dim strButtonName As String = String.Empty
            strButtonName = dgvRow.Cells.Item("name").Value

            Select Case strButtonName
                Case "new_ledger"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "open"
                    dgvRow.Cells.Item("include").Value = CheckState.Checked
                Case "my_statements"
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
                Case "statement"
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

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/customize_toolbar.html"
        Process.Start(strWebAddress)

    End Sub

    Private Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            dgvRow.Cells.Item("include").Value = True

        Next

    End Sub

    Private Sub btnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click

        For Each dgvRow As DataGridViewRow In dgvIcons.Rows

            dgvRow.Cells.Item("include").Value = False

        Next

    End Sub

End Class