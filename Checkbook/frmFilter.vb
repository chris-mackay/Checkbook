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

Imports System.Data.OleDb
Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds

Public Class frmFilter

    Private UIManager As New clsUIManager
    Private FileCon As New clsLedgerDBConnector
    Private FORM_IS_BEING_LOADED As Boolean

    Private Sub frmFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FORM_IS_BEING_LOADED = True

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        ClearFilterSettings()
        DisableEnableApplyButton()

        Try

            FileCon.Connect()
            FileCon.SQLread_FillComboBox(cbCategory, "SELECT * FROM Categories")
            FileCon.SQLread_FillComboBox(cbPayees, "SELECT * FROM Payees")
            FileCon.SQLread_FillComboBox(cbStatements, "SELECT * FROM Statements")
            FileCon.Close()

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        Finally

            FORM_IS_BEING_LOADED = False

        End Try

    End Sub

    Private Sub frmFilter_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If Not FORM_IS_BEING_LOADED Then

            'GET PREVIOUSLY SELECTED ITEMS
            Dim strPreviousCategory As String = String.Empty
            Dim strPreviousPayee As String = String.Empty
            Dim strPreviousStatement As String = String.Empty

            If Not cbCategory.SelectedIndex = -1 Then strPreviousCategory = cbCategory.SelectedItem.ToString
            If Not cbPayees.SelectedIndex = -1 Then strPreviousPayee = cbPayees.SelectedItem.ToString
            If Not cbStatements.SelectedIndex = -1 Then strPreviousStatement = cbStatements.SelectedItem.ToString

            Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

            DisableEnableApplyButton()

            Try

                FileCon.Connect()
                FileCon.SQLread_FillComboBox(cbCategory, "SELECT * FROM Categories")
                FileCon.SQLread_FillComboBox(cbPayees, "SELECT * FROM Payees")
                FileCon.SQLread_FillComboBox(cbStatements, "SELECT * FROM Statements")
                FileCon.Close()

                'SET PREVIOUSLY SELECTED ITEMS
                If Not strPreviousCategory = String.Empty Then cbCategory.SelectedIndex = cbCategory.FindStringExact(strPreviousCategory)
                If Not strPreviousPayee = String.Empty Then cbPayees.SelectedIndex = cbPayees.FindStringExact(strPreviousPayee)
                If Not strPreviousStatement = String.Empty Then cbStatements.SelectedIndex = cbStatements.FindStringExact(strPreviousStatement)

            Catch ex As Exception

                Me.Dispose()
                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            End Try

        End If

    End Sub

    Private Sub ckbReceipts_CheckedChanged(sender As Object, e As EventArgs) Handles ckbReceipts.CheckedChanged

        If Not ckbReceipts.Checked Then

            rbReceipt.Checked = False
            rbNoReceipt.Checked = False
            gbReceipts.Enabled = False

        Else

            rbReceipt.Checked = True
            gbReceipts.Enabled = True

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub ckbCleared_CheckedChanged(sender As Object, e As EventArgs) Handles ckbClearedAndUncleared.CheckedChanged

        If Not ckbClearedAndUncleared.Checked Then

            rbCleared.Checked = False
            rbUncleared.Checked = False
            gbCleared.Enabled = False

        Else

            rbCleared.Checked = True
            gbCleared.Enabled = True

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub ckbDates_CheckedChanged(sender As Object, e As EventArgs) Handles ckbDates.CheckedChanged

        If Not ckbDates.Checked Then

            rbExactDate.Checked = False
            rbRange.Checked = False
            gbDates.Enabled = False

        Else

            rbRange.Checked = True
            gbDates.Enabled = True

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub ckbCategoriesPayees_CheckedChanged(sender As Object, e As EventArgs) Handles ckbCategoriesPayees.CheckedChanged

        If Not ckbCategoriesPayees.Checked Then

            rbCategories.Checked = False
            cbCategory.SelectedIndex = -1
            rbPayees.Checked = False
            cbPayees.SelectedIndex = -1
            rbBoth.Checked = False
            gbCategoriesPayess.Enabled = False

        Else

            rbCategories.Checked = True
            gbCategoriesPayess.Enabled = True

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub ckbStatement_CheckedChanged(sender As Object, e As EventArgs) Handles ckbStatement.CheckedChanged

        If Not ckbStatement.Checked Then

            cbStatements.SelectedIndex = -1
            gbStatements.Enabled = False

        Else

            gbStatements.Enabled = True

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub DisableEnableApplyButton()

        If Not ckbDates.Checked And Not ckbCategoriesPayees.Checked And Not ckbClearedAndUncleared.Checked And Not ckbReceipts.Checked And Not ckbStatement.Checked Then

            btnApply.Enabled = False

        ElseIf Not ckbCategoriesPayees.Checked And Not ckbStatement.Checked Then

            btnApply.Enabled = True

        Else

            If ckbCategoriesPayees.Checked And Not ckbStatement.Checked Then

                If rbCategories.Checked And Not rbPayees.Checked And Not rbBoth.Checked Then

                    If cbCategory.SelectedIndex = -1 Then btnApply.Enabled = False Else btnApply.Enabled = True

                End If

                If rbPayees.Checked And Not rbCategories.Checked And Not rbBoth.Checked Then

                    If cbPayees.SelectedIndex = -1 Then btnApply.Enabled = False Else btnApply.Enabled = True

                End If

                If rbBoth.Checked And Not rbCategories.Checked And Not rbPayees.Checked Then

                    If cbCategory.SelectedIndex = -1 Or cbPayees.SelectedIndex = -1 Then btnApply.Enabled = False Else btnApply.Enabled = True

                End If

            End If

            If ckbCategoriesPayees.Checked And ckbStatement.Checked Then

                If rbCategories.Checked And Not rbPayees.Checked And Not rbBoth.Checked Then

                    If cbCategory.SelectedIndex = -1 Or cbStatements.SelectedIndex = -1 Then
                        btnApply.Enabled = False
                    Else
                        btnApply.Enabled = True
                    End If

                End If

                If rbPayees.Checked And Not rbCategories.Checked And Not rbBoth.Checked Then

                    If cbPayees.SelectedIndex = -1 Or cbStatements.SelectedIndex = -1 Then
                        btnApply.Enabled = False
                    Else
                        btnApply.Enabled = True
                    End If

                End If

                If rbBoth.Checked And Not rbCategories.Checked And Not rbPayees.Checked Then

                    If cbCategory.SelectedIndex = -1 Or cbPayees.SelectedIndex = -1 Or cbStatements.SelectedIndex = -1 Then
                        btnApply.Enabled = False
                    Else
                        btnApply.Enabled = True
                    End If

                End If

            End If

            If ckbStatement.Checked And Not ckbCategoriesPayees.Checked Then

                If cbStatements.SelectedIndex = -1 Then btnApply.Enabled = False Else btnApply.Enabled = True

            End If

        End If

    End Sub

    Private Sub ClearFilterSettings()

        m_ledgerIsBeingFiltered_Advanced = False

        'GENERAL
        ckbReceipts.Checked = False
        ckbClearedAndUncleared.Checked = False

        ckbDates.Checked = False
        ckbCategoriesPayees.Checked = False

        'RECEIPTS
        rbReceipt.Checked = False
        rbNoReceipt.Checked = False
        gbReceipts.Enabled = False

        'CLEARED
        rbCleared.Checked = False
        rbUncleared.Checked = False
        gbCleared.Enabled = False

        'DATES
        rbExactDate.Checked = False
        rbRange.Checked = False
        gbDates.Enabled = False

        'CATEGORIES OR PAYEES
        rbCategories.Checked = False
        cbCategory.SelectedIndex = -1
        rbPayees.Checked = False
        cbPayees.SelectedIndex = -1
        gbCategoriesPayess.Enabled = False
        rbBoth.Checked = False

        'STATEMENTS
        ckbStatement.Checked = False
        cbStatements.SelectedIndex = -1
        gbStatements.Enabled = False

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearFilterSettings()
        ApplyFilters()

    End Sub

    Private Sub Form_Dispose() Handles Me.Disposed

        m_ledgerIsBeingFiltered_Advanced = False
        ClearFilterSettings()
        ApplyFilters()
        MainForm.SetMainFormMenuItemsAndToolbarButtonsEnabled_ToggleFilter()
        MainForm.mnuFilter.Enabled = True
        MainForm.filter_Button.Enabled = True

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub rbCategories_CheckedChanged(sender As Object, e As EventArgs) Handles rbCategories.CheckedChanged

        If Not rbCategories.Checked Then

            lblCategory.Enabled = False
            cbCategory.Enabled = False

            lblPayee.Enabled = True
            cbPayees.Enabled = True

        Else

            lblCategory.Enabled = True
            cbCategory.Enabled = True

            lblPayee.Enabled = False
            cbPayees.Enabled = False

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub rbPayees_CheckedChanged(sender As Object, e As EventArgs) Handles rbPayees.CheckedChanged

        If Not rbPayees.Checked Then

            lblPayee.Enabled = False
            cbPayees.Enabled = False

            lblCategory.Enabled = True
            cbCategory.Enabled = True

        Else

            lblPayee.Enabled = True
            cbPayees.Enabled = True

            lblCategory.Enabled = False
            cbCategory.Enabled = False

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub rbBoth_CheckedChanged(sender As Object, e As EventArgs) Handles rbBoth.CheckedChanged

        If rbBoth.Checked Then

            lblCategory.Enabled = True
            cbCategory.Enabled = True

            lblPayee.Enabled = True
            cbPayees.Enabled = True

        End If

        DisableEnableApplyButton()

    End Sub

    Private Sub rbExactDate_CheckedChanged(sender As Object, e As EventArgs) Handles rbExactDate.CheckedChanged

        If Not rbExactDate.Checked Then

            lblStartDate.Enabled = True
            lblStartDate.Text = "Start Date"
            dtpStartDate.Enabled = True

            lblEndDate.Enabled = True
            dtpEndDate.Enabled = True

        Else

            lblStartDate.Enabled = True
            lblStartDate.Text = "Date"
            dtpStartDate.Enabled = True

            lblEndDate.Enabled = False
            dtpEndDate.Enabled = False

        End If

    End Sub

    Private Sub rbRange_CheckedChanged(sender As Object, e As EventArgs) Handles rbRange.CheckedChanged

        If Not rbRange.Checked Then

            lblStartDate.Enabled = True
            lblStartDate.Text = "Date"
            dtpStartDate.Enabled = True

            lblEndDate.Enabled = False
            dtpEndDate.Enabled = False

        Else

            lblStartDate.Enabled = True
            lblStartDate.Text = "Start Date"
            dtpStartDate.Enabled = True

            lblEndDate.Enabled = True
            dtpEndDate.Enabled = True

        End If

    End Sub

    Public Sub ApplyFilters()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Try

            UIManager.SetCursor(Me, Cursors.WaitCursor)

            Dim con As New OleDbConnection
            Dim da As New OleDbDataAdapter
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim bs As New BindingSource
            Dim dsView As New DataView
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & m_strCurrentFile
            con.Open()
            ds.Tables.Add(dt)
            da = New OleDbDataAdapter("SELECT * FROM LedgerData", con)
            da.Fill(dt)

            MainForm.dgvLedger.Columns.Clear()
            MainForm.dgvLedger.DataSource = Nothing

            dsView = ds.Tables(0).DefaultView
            bs.DataSource = dsView

#Region "FILTERS"

            Dim strStartDate As String = String.Empty
            Dim strEndDate As String = String.Empty
            Dim strCategory As String = String.Empty
            Dim strPayee As String = String.Empty
            Dim strStatementName As String = String.Empty
            Dim blnCleared As Boolean = False

#Region "1 COMBINATION"

#Region "ONLY DATES - A"

            'ONLY DATES
            If ckbDates.Checked And Not ckbCategoriesPayees.Checked And Not ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked Then

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                'EXACT DATE
                If rbExactDate.Checked Then

                    bs.Filter = "TransDate = '" & strStartDate & "'"

                End If

                'RANGE
                If rbRange.Checked Then

                    bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'"

                End If

            End If
#End Region

#Region "ONLY CATEGORIES/PAYEES - B"

            'ONLY CATEGORIES OR PAYEES
            If ckbCategoriesPayees.Checked And Not ckbDates.Checked And Not ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked Then

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "'"

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "'"

                End If

            End If

            'CATEGORIES AND PAYEES
            If rbBoth.Checked Then

                strCategory = cbCategory.SelectedItem.ToString
                strPayee = cbPayees.SelectedItem.ToString

                bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "'"

            End If

#End Region

#Region "ONLY CLEARED - C"

            If ckbClearedAndUncleared.Checked And Not ckbDates.Checked And Not ckbCategoriesPayees.Checked And Not ckbReceipts.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                bs.Filter = "Cleared = '" & blnCleared & "'"

            End If

#End Region

#Region "ONLY RECEIPTS - D"

            If ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked And Not ckbDates.Checked And Not ckbCategoriesPayees.Checked Then

                If rbReceipt.Checked Then

                    bs.Filter = "Receipt <> '" & "" & "'"

                Else

                    bs.Filter = "Receipt = '" & "" & "'"

                End If

            End If

#End Region

#Region "ONLY STATEMENTS - E"

            If ckbStatement.Checked And Not ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked And Not ckbDates.Checked And Not ckbCategoriesPayees.Checked Then

                strStatementName = cbStatements.SelectedItem.ToString

                bs.Filter = "StatementName = '" & strStatementName & "'"

            End If

#End Region

#End Region

#Region "2 COMBINATIONS"

#Region "DATES : CATEGORIES/PAYEES - A,B"

            If ckbCategoriesPayees.Checked And ckbDates.Checked And Not ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked And Not ckbStatement.Checked Then

                'ONLY CATEGORIES AND EXACT DATE
                If rbCategories.Checked And rbExactDate.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strStartDate = dtpStartDate.Value.ToShortDateString

                    bs.Filter = "Category = '" & strCategory & "' AND TransDate = '" & strStartDate & "'"

                End If

                'ONLY PAYEES AND EXACT DATE
                If rbPayees.Checked And rbExactDate.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString
                    strStartDate = dtpStartDate.Value.ToShortDateString

                    bs.Filter = "Payee = '" & strPayee & "' AND TransDate = '" & strStartDate & "'"

                End If

                'ONLY CATEGORIES AND DATE RANGE
                If rbCategories.Checked And rbRange.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strStartDate = dtpStartDate.Value.ToShortDateString
                    strEndDate = dtpEndDate.Value.ToShortDateString

                    bs.Filter = "Category = '" & strCategory & "' AND TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'"

                End If

                'ONLY PAYEES AND DATE RANGE
                If rbPayees.Checked And rbRange.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString
                    strStartDate = dtpStartDate.Value.ToShortDateString
                    strEndDate = dtpEndDate.Value.ToShortDateString

                    bs.Filter = "Payee = '" & strPayee & "' AND TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'"

                End If

                'CATEGORIES AND PAYEES AND EXACT DATE
                If rbBoth.Checked And rbExactDate.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString
                    strStartDate = dtpStartDate.Value.ToShortDateString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND TransDate = '" & strStartDate & "'"

                End If

                'CATEGORIES AND PAYEES AND DATE RANGE
                If rbBoth.Checked And rbRange.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString
                    strStartDate = dtpStartDate.Value.ToShortDateString
                    strEndDate = dtpEndDate.Value.ToShortDateString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'"

                End If

            End If

#End Region

#Region "DATES : CLEARED/UNCLEARED - A,C"

            If ckbDates.Checked And ckbClearedAndUncleared.Checked And Not ckbReceipts.Checked And Not ckbCategoriesPayees.Checked And Not ckbStatement.Checked Then

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                'EXACT DATE
                If rbExactDate.Checked Then

                    bs.Filter = "TransDate = '" & strStartDate & "' AND " & "Cleared = '" & blnCleared & "'"

                End If

                'RANGE
                If rbRange.Checked Then

                    bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND " & "Cleared = '" & blnCleared & "'"

                End If

            End If

#End Region

#Region "DATES : RECEIPTS/NO RECEIPTS - A,D"

            If ckbDates.Checked And ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked And Not ckbCategoriesPayees.Checked And Not ckbStatement.Checked Then

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                If rbExactDate.Checked Then

                    If rbReceipt.Checked Then

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Receipt <> '" & "" & "'"

                    Else

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Receipt = '" & "" & "'"

                    End If

                End If

                If rbRange.Checked Then

                    If rbReceipt.Checked Then

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Receipt <> '" & "" & "'"

                    Else

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Receipt = '" & "" & "'"

                    End If

                End If

            End If

#End Region

#Region "DATES : STATEMENT - A,E"

            If ckbDates.Checked And ckbStatement.Checked And Not ckbClearedAndUncleared.Checked And Not ckbCategoriesPayees.Checked And Not ckbReceipts.Checked Then

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                If rbExactDate.Checked Then

                    bs.Filter = "TransDate = '" & strStartDate & "' AND StatementName = '" & strStatementName & "'"

                End If

                If rbRange.Checked Then

                    bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND StatementName = '" & strStatementName & "'"

                End If

            End If

#End Region

#Region "CLEARED/UNCLEARED : CATEGORIES/PAYEES - B,C"

            If ckbClearedAndUncleared.Checked And ckbCategoriesPayees.Checked And Not ckbDates.Checked And Not ckbReceipts.Checked And Not ckbStatement.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Cleared = '" & blnCleared & "'"

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'"

                End If

                'CATEGORIES AND PAYEES
                If rbBoth.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'"

                End If

            End If

#End Region

#Region "RECEIPTS/NO RECEIPTS : CATEGORIES/PAYEES - B,D"

            If ckbReceipts.Checked And ckbCategoriesPayees.Checked And Not ckbDates.Checked And Not ckbClearedAndUncleared.Checked And Not ckbStatement.Checked Then

                If rbReceipt.Checked Then

                    'ONLY CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "Category = '" & strCategory & "' AND Receipt <> '" & "" & "'"

                    End If

                    'ONLY PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "Payee = '" & strPayee & "' AND Receipt <> '" & "" & "'"

                    End If

                    'CATEGORIES AND PAYEES
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Receipt <> '" & "" & "'"

                    End If

                End If

                If rbNoReceipt.Checked Then

                    'ONLY CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "Category = '" & strCategory & "' AND Receipt = '" & "" & "'"

                    End If

                    'ONLY PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "Payee = '" & strPayee & "' AND Receipt = '" & "" & "'"

                    End If

                    'CATEGORIES AND PAYEES
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Receipt = '" & "" & "'"

                    End If

                End If

            End If

#End Region

#Region "STATEMENT : CATEGORIES/PAYEES - B,E"

            If ckbStatement.Checked And ckbCategoriesPayees.Checked And Not ckbDates.Checked And Not ckbClearedAndUncleared.Checked And Not ckbReceipts.Checked Then

                strStatementName = cbStatements.SelectedItem.ToString

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "'"

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'"

                End If

                'CATEGORIES AND PAYEES
                If rbBoth.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'"

                End If

            End If

#End Region

#Region "RECEIPTS/NO RECEIPTS : CLEARED/UNCLEARED - C,D"

            If ckbReceipts.Checked And ckbClearedAndUncleared.Checked And Not ckbDates.Checked And Not ckbCategoriesPayees.Checked And Not ckbStatement.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                If rbReceipt.Checked Then

                    bs.Filter = "Receipt <> '" & "" & "' AND Cleared = '" & blnCleared & "'"

                End If

                If rbNoReceipt.Checked Then

                    bs.Filter = "Receipt = '" & "" & "' AND Cleared = '" & blnCleared & "'"

                End If

            End If

#End Region

#Region "STATEMENT : CLEARED/UNCLEARED - C,E"

            If ckbStatement.Checked And ckbClearedAndUncleared.Checked And Not ckbCategoriesPayees.Checked And Not ckbDates.Checked And Not ckbReceipts.Checked Then

                strStatementName = cbStatements.SelectedItem.ToString

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                bs.Filter = "StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

            End If

#End Region

#Region "STATEMENT : RECEIPTS/NO RECEIPTS - D,E"

            If ckbStatement.Checked And ckbReceipts.Checked And Not ckbCategoriesPayees.Checked And Not ckbDates.Checked And Not ckbClearedAndUncleared.Checked Then

                strStatementName = cbStatements.SelectedItem.ToString

                If rbReceipt.Checked Then

                    bs.Filter = "Receipt <> '" & "" & "' AND StatementName = '" & strStatementName & "'"

                End If

                If rbNoReceipt.Checked Then

                    bs.Filter = "Receipt = '" & "" & "' AND StatementName = '" & strStatementName & "'"

                End If

            End If

#End Region

#End Region

#Region "3 COMBINATIONS"

#Region "DATES : CATEGORIES/PAYEES : CLEARED/UNCLEARED - A,B,C"

            If ckbDates.Checked And ckbCategoriesPayees.Checked And ckbClearedAndUncleared.Checked And Not ckbReceipts.Checked And Not ckbStatement.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                'EXACT DATE
                If rbExactDate.Checked Then

                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND Category = '" & strCategory & "'"

                    End If

                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND Payee = '" & strPayee & "'"

                    End If

                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "'"

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND Category = '" & strCategory & "'"

                    End If

                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND Payee = '" & strPayee & "'"

                    End If

                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "'"

                    End If

                End If

            End If

#End Region

#Region "DATES : CATEGORIES/PAYEES : RECEIPTS/NO RECEIPTS - A,B,D"

            If ckbDates.Checked And ckbCategoriesPayees.Checked And ckbReceipts.Checked And Not ckbClearedAndUncleared.Checked And Not ckbStatement.Checked Then

                Dim strReceiptFilter As String = String.Empty

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                'EXACT DATE
                If rbExactDate.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "'"

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "'" & strReceiptFilter & " AND Payee = '" & strPayee & "'"

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "'"

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "'"

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'" & strReceiptFilter & " AND Payee = '" & strPayee & "'"

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "'"

                    End If

                End If

            End If

#End Region

#Region "DATES : CLEARED/UNCLEARED : RECEIPTS/NO RECEIPTS - A,C,D"

            If ckbDates.Checked And ckbClearedAndUncleared.Checked And ckbReceipts.Checked And Not ckbCategoriesPayees.Checked And Not ckbStatement.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                'EXACT DATE
                If rbExactDate.Checked Then

                    If rbReceipt.Checked Then

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND Receipt <> '" & "" & "'"

                    End If

                    If rbNoReceipt.Checked Then

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND Receipt = '" & "" & "'"

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    If rbReceipt.Checked Then

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND Receipt <> '" & "" & "'"

                    End If

                    If rbNoReceipt.Checked Then

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND Receipt = '" & "" & "'"

                    End If

                End If

            End If

#End Region

#Region "DATES : CLEARED/UNCLEARED : STATEMENT - A,C,E"

            If ckbDates.Checked And ckbClearedAndUncleared.Checked And ckbStatement.Checked And Not ckbCategoriesPayees.Checked And Not ckbReceipts.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                'EXACT DATE
                If rbExactDate.Checked Then

                    bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'"

                End If

                'RANGE
                If rbRange.Checked Then

                    bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'"

                End If

            End If

#End Region

#Region "DATES : RECEIPTS/NO RECEIPTS : STATEMENT - A,D,E"

            If ckbDates.Checked And ckbReceipts.Checked And ckbStatement.Checked And Not ckbClearedAndUncleared.Checked And Not ckbCategoriesPayees.Checked Then

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                'EXACT DATE
                If rbExactDate.Checked Then

                    If rbReceipt.Checked Then

                        bs.Filter = "TransDate = '" & strStartDate & "' AND StatementName = '" & strStatementName & "' AND Receipt <> '" & "" & "'"

                    End If

                    If rbNoReceipt.Checked Then

                        bs.Filter = "TransDate = '" & strStartDate & "' AND StatementName = '" & strStatementName & "' AND Receipt = '" & "" & "'"

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    If rbReceipt.Checked Then

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND StatementName = '" & strStatementName & "' AND Receipt <> '" & "" & "'"

                    End If

                    If rbNoReceipt.Checked Then

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND StatementName = '" & strStatementName & "' AND Receipt = '" & "" & "'"

                    End If

                End If

            End If

#End Region

#Region "CATEGORIES/PAYEES : RECEIPTS/NO RECEIPTS : CLEARED/UNCLEARED - B,C,D"

            If ckbCategoriesPayees.Checked And ckbReceipts.Checked And ckbClearedAndUncleared.Checked And Not ckbDates.Checked And Not ckbStatement.Checked Then

                Dim strReceiptFilter As String = String.Empty

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                End If

                'CATEGORIES AND PAYEES
                If rbBoth.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                End If

            End If

#End Region

#Region "CATEGORIES/PAYEES : CLEARED/UNCLEARED : STATEMENT - B,C,E"

            If ckbCategoriesPayees.Checked And ckbClearedAndUncleared.Checked And ckbStatement.Checked And Not ckbDates.Checked And Not ckbReceipts.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStatementName = cbStatements.SelectedItem.ToString

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                End If

                'CATEGORIES AND PAYEES
                If rbBoth.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                End If

            End If

#End Region

#Region "CATEGORIES/PAYEES : RECEIPTS/NO RECEIPTS : STATEMENT - B,D,E"

            If ckbCategoriesPayees.Checked And ckbReceipts.Checked And ckbStatement.Checked And Not ckbClearedAndUncleared.Checked And Not ckbDates.Checked Then

                Dim strReceiptFilter As String = String.Empty

                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                strStatementName = cbStatements.SelectedItem.ToString

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

                'CATEGORIES AND PAYEES
                If rbBoth.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

            End If

#End Region

#Region "RECEIPTS/NO RECEIPTS : CLEARED/UNCLEARED :STATEMENT - C,D,E"

            If ckbReceipts.Checked And ckbClearedAndUncleared.Checked And ckbStatement.Checked And Not ckbDates.Checked And Not ckbCategoriesPayees.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False
                strStatementName = cbStatements.SelectedItem.ToString

                If rbReceipt.Checked Then

                    bs.Filter = "Receipt <> '" & "" & "' AND Cleared = '" & blnCleared & "'" & " AND StatementName = '" & strStatementName & "'"

                End If

                If rbNoReceipt.Checked Then

                    bs.Filter = "Receipt = '" & "" & "' AND Cleared = '" & blnCleared & "'" & " AND StatementName = '" & strStatementName & "'"

                End If

            End If

#End Region

#End Region

#Region "4 COMBINATIONS"

#Region "DATES : CATEGORIES/PAYEES : RECEIPTS/NO RECEIPTS : CLEARED/UNCLEARED - A,B,C,D"

            If ckbDates.Checked And ckbCategoriesPayees.Checked And ckbReceipts.Checked And ckbClearedAndUncleared.Checked And Not ckbStatement.Checked Then

                Dim strReceiptFilter As String = String.Empty

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString

                'EXACT DATE
                If rbExactDate.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "'" & strReceiptFilter & " AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'"

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'" & strReceiptFilter & " AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "'" & strReceiptFilter & " AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "'"

                    End If

                End If

            End If

#End Region

#Region "DATES : CATEGORIES/PAYEES : CLEARED/UNCLEARED : STATEMENT - A,B,C,E"

            If ckbDates.Checked And ckbCategoriesPayees.Checked And ckbClearedAndUncleared.Checked And ckbStatement.Checked And Not ckbReceipts.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                'EXACT DATE
                If rbExactDate.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'"

                    End If

                End If

            End If

#End Region

#Region "DATES : CATEGORIES/PAYEES : RECEIPTS/NO RECEIPTS : STATEMENT - A,B,D,E"

            If ckbDates.Checked And ckbCategoriesPayees.Checked And ckbReceipts.Checked And ckbStatement.Checked And Not ckbClearedAndUncleared.Checked Then

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                Dim strReceiptFilter As String = String.Empty
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"


                'EXACT DATE
                If rbExactDate.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                    End If

                End If

            End If

#End Region

#Region "DATES : CLEARED/UNCLEARED : RECEIPTS/NO RECEIPTS : STATEMENT - A,C,D,E"

            If ckbDates.Checked And ckbClearedAndUncleared.Checked And ckbReceipts.Checked And ckbStatement.Checked And Not ckbCategoriesPayees.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                Dim strReceiptFilter As String = String.Empty
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                'EXACT DATE
                If rbExactDate.Checked Then

                    bs.Filter = "TransDate = '" & strStartDate & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

                'RANGE
                If rbRange.Checked Then

                    bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

            End If

#End Region

#Region "CATEGORIES/PAYEES : CLEARED/UNCLEARED : RECEIPTS/NO RECEIPTS : STATEMENT - B,C,D,E"

            If ckbClearedAndUncleared.Checked And ckbCategoriesPayees.Checked And ckbReceipts.Checked And ckbStatement.Checked And Not ckbDates.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                Dim strReceiptFilter As String = String.Empty
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                strStatementName = cbStatements.SelectedItem.ToString

                'ONLY CATEGORIES
                If rbCategories.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

                'ONLY PAYEES
                If rbPayees.Checked Then

                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

                'CATEGORIES AND PAYEES
                If rbBoth.Checked Then

                    strCategory = cbCategory.SelectedItem.ToString
                    strPayee = cbPayees.SelectedItem.ToString

                    bs.Filter = "Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND Cleared = '" & blnCleared & "' AND StatementName = '" & strStatementName & "'" & strReceiptFilter

                End If

            End If

#End Region

#End Region

#Region "5 COMBINATIONS"

            If ckbDates.Checked And ckbCategoriesPayees.Checked And ckbClearedAndUncleared.Checked And ckbReceipts.Checked And ckbStatement.Checked Then

                If rbCleared.Checked Then blnCleared = True Else blnCleared = False

                strStartDate = dtpStartDate.Value.ToShortDateString
                strEndDate = dtpEndDate.Value.ToShortDateString
                strStatementName = cbStatements.SelectedItem.ToString

                Dim strReceiptFilter As String = String.Empty
                If rbReceipt.Checked Then strReceiptFilter = " AND Receipt <> ' '" Else strReceiptFilter = " AND Receipt = ' '"

                'EXACT DATE
                If rbExactDate.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate = '" & strStartDate & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                    End If

                End If

                'RANGE
                If rbRange.Checked Then

                    'CATEGORIES
                    If rbCategories.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Category = '" & strCategory & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                    End If

                    'PAYEES
                    If rbPayees.Checked Then

                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                    End If

                    'BOTH
                    If rbBoth.Checked Then

                        strCategory = cbCategory.SelectedItem.ToString
                        strPayee = cbPayees.SelectedItem.ToString

                        bs.Filter = "TransDate >= '" & strStartDate & "' AND TransDate <= '" & strEndDate & "' AND Category = '" & strCategory & "' AND Payee = '" & strPayee & "' AND StatementName = '" & strStatementName & "' AND Cleared = '" & blnCleared & "'" & strReceiptFilter

                    End If

                End If

            End If

#End Region

#End Region

            MainForm.dgvLedger.DataSource = bs

            FormatMainFormLedgerDataGridView()

            MainForm.dgvLedger.Sort(MainForm.dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            con.Close()

            'FORMATS UNCLEARED TRANSACTIONS
            FormatUncleared()

            'SHOWS THE UNCLEARED IMAGE IF TRANSACTION IS NOT CLEARED
            CheckIfTransactionIsUnCleared()

            'SHOWS THE RECEIPT IMAGE IF A RECEIPT EXISTS
            CheckIfReceiptExists()

            UIManager.UpdateStatusStripInfo()

            MainForm.dgvLedger.ClearSelection()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        Finally

            UIManager.SetCursor(Me, Cursors.Default)

        End Try

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        m_ledgerIsBeingFiltered_Advanced = True
        ApplyFilters()

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        DisableEnableApplyButton()

    End Sub

    Private Sub cbPayees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPayees.SelectedIndexChanged

        DisableEnableApplyButton()

    End Sub

    Private Sub cbStatements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStatements.SelectedIndexChanged

        DisableEnableApplyButton()

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click

        Dim webAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/advanced_filter.html"
        Process.Start(webAddress)

    End Sub

End Class