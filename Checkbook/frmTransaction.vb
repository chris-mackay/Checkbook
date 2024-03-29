﻿'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
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

Public Class frmTransaction

    Public caller_frmCategory As frmCategory

    Private DataCon As New clsLedgerDataManager
    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dgvSelectedRowCount As Integer
        dgvSelectedRowCount = MainForm.dgvLedger.SelectedRows.Count

        Dim strType As String = String.Empty
        Dim strCategory As String = String.Empty
        Dim dtTransDate As Date = Nothing
        Dim strPayment As String = String.Empty
        Dim strDeposit As String = String.Empty
        Dim strPayee As String = String.Empty
        Dim strDescription As String = String.Empty
        Dim blnCleared As Boolean = False
        Dim strReceipt As String = String.Empty
        Dim strStatementName As String = String.Empty
        Dim strStatementFileName As String = String.Empty

        strType = cbType.Text
        strCategory = cbCategory.Text
        dtTransDate = dtpTransDate.Value.Date
        strPayment = txtPayment.Text
        strDeposit = txtDeposit.Text
        strPayee = cbPayee.Text
        strDescription = txtDescription.Text
        blnCleared = cbCleared.CheckState
        strReceipt = txtReceipt.Text

        Try

            strStatementName = cbStatements.Text

            FileCon.Connect()
            strStatementFileName = FileCon.SQLselect_Command("SELECT StatementFileName FROM Statements WHERE StatementName = '" & strStatementName & "'")
            FileCon.Close()

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        If MainModule.m_blnTansactionIsBeingEdited = True Then

            Try

                UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                Me.Dispose()
                DataCon.UpdateData(strType, strCategory, dtTransDate, strPayment, strDeposit, strPayee, strDescription, blnCleared, strReceipt, strStatementName, strStatementFileName)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Update Error", MsgButtons.OK, "An error occurred while updating the transaction" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                FileCon.Close()
                UIManager.SetCursor(MainForm, Cursors.Default)

            End Try

        Else

            Try

                UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                Me.Dispose()
                DataCon.InsertData(strType, strCategory, dtTransDate, strPayment, strDeposit, strPayee, strDescription, blnCleared, strReceipt, strStatementName, strStatementFileName)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Transaction Error", MsgButtons.OK, "An error occurred while creating the transaction" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                FileCon.Close()
                UIManager.SetCursor(MainForm, Cursors.Default)

            End Try

        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

    Private Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs) Handles txtPayment.Validated, txtDeposit.Validated

        UIManager.TextBox_FormatCurrency_Validated(sender, e)

    End Sub

    Private Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPayment.KeyPress, txtDeposit.KeyPress

        UIManager.TextBox_HandleDecimal_KeyPress(sender, e)

    End Sub

    Private Sub txtDeposit_TextChanged(sender As Object, e As EventArgs) Handles txtDeposit.TextChanged

        If Len(txtDeposit.Text) > 0 Then

            UIManager.DisablePaymentUI()

        Else

            UIManager.EnablePaymentUI()

        End If

    End Sub

    Private Sub txtPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPayment.TextChanged

        If Len(txtPayment.Text) > 0 Then

            UIManager.DisableDepositUI()

        Else

            UIManager.EnableDepositUI()

        End If

    End Sub

    Private Sub frmTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim dgvSelectedRowCount As Integer = 0
        dgvSelectedRowCount = MainForm.dgvLedger.SelectedRows.Count

        FileCon.caller_frmTransaction = Me
        DataCon.caller_frmTransaction = Me
        UIManager.caller_frmTransaction = Me

        Dim lstTransactionControls As New List(Of Control)

        For Each ctrl As Control In Me.Controls

            lstTransactionControls.Add(ctrl)

        Next

        MainModule.DrawingControl.SetDoubleBuffered_ListControls(lstTransactionControls)
        MainModule.DrawingControl.SuspendDrawing_ListControls(lstTransactionControls)

        If dgvSelectedRowCount = 1 Then

            MainModule.m_blnTansactionIsBeingEdited = True

            Try

                FileCon.Connect()
                FileCon.SQLread_FillcbCategories("SELECT * FROM Categories")
                FileCon.SQLread_FillcbPayees("SELECT * FROM Payees")
                FileCon.SQLread_FillcbStatements("SELECT * FROM Statements")
                FileCon.Close()

            Catch ex As Exception

                Me.Dispose()
                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            End Try

            DataCon.EditSelected()
            MainModule.DrawingControl.ResumeDrawing_ListControls(lstTransactionControls)

        Else

            MainModule.m_blnTansactionIsBeingEdited = False

            Icon = My.Resources.NewTrans
            Text = "New Transaction"
            btnCreate.Text = "Create"
            cbType.Text = String.Empty
            cbType.SelectedIndex = -1
            cbCategory.SelectedIndex = -1
            dtpTransDate.Value = Now
            txtPayment.Text = String.Empty
            txtDeposit.Text = String.Empty
            cbPayee.SelectedIndex = -1
            txtDescription.Text = String.Empty
            txtReceipt.Text = String.Empty
            cbStatements.SelectedIndex = -1
            cbCleared.CheckState = False
            cbType.Focus()
            cbType.SelectAll()
            btnCreate.Select()

            Try

                FileCon.Connect()
                FileCon.SQLread_FillcbCategories("SELECT * FROM Categories")
                FileCon.SQLread_FillcbPayees("SELECT * FROM Payees")
                FileCon.SQLread_FillcbStatements("SELECT * FROM Statements")
                FileCon.Close()

            Catch ex As Exception

                Me.Dispose()
                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            Finally

                MainModule.DrawingControl.ResumeDrawing_ListControls(lstTransactionControls)

            End Try

        End If

    End Sub

    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click

        Dim new_frmTypeInfo As New frmTypeInfo
        new_frmTypeInfo.ShowDialog()

    End Sub

    Private Sub btnInfo_MouseHover(sender As Object, e As EventArgs) Handles btnInfo.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnInfo, "Type Codes")

    End Sub

    Private Sub btnQuickCat_MouseHover(sender As Object, e As EventArgs) Handles btnQuickCat.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnQuickCat, "Categories")

    End Sub

    Private Sub btnQuickPayee_MouseHover(sender As Object, e As EventArgs) Handles btnQuickPayee.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnQuickPayee, "Payees")

    End Sub

    Private Sub btnViewReceipt_MouseHover(sender As Object, e As EventArgs) Handles btnViewReceipt.MouseHover, btnViewStatement.MouseHover, btnRemoveStatement.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnViewReceipt, "View Receipt")

    End Sub

    Private Sub btnAttachReceipt_MouseHover(sender As Object, e As EventArgs) Handles btnAttachReceipt.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnAttachReceipt, "Attach Receipt")

    End Sub

    Private Sub btnRemoveReceipt_MouseHover(sender As Object, e As EventArgs) Handles btnRemoveReceipt.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnRemoveReceipt, "Remove Receipt")

    End Sub

    Private Sub btnMyStatements_MouseHover(sender As Object, e As EventArgs) Handles btnMyStatements.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnMyStatements, "My Statements")

    End Sub

    Private Sub btnQuickCat_Click(sender As Object, e As EventArgs) Handles btnQuickCat.Click

        Dim new_frmCategory As New frmCategory
        new_frmCategory.ShowDialog()

    End Sub

    Private Sub btnQuickPayee_Click(sender As Object, e As EventArgs) Handles btnQuickPayee.Click

        Dim new_frmPayee As New frmPayee
        new_frmPayee.ShowDialog()

    End Sub

    Private Sub btnAddReceipt_Click(sender As Object, e As EventArgs) Handles btnAttachReceipt.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If Not Me.txtReceipt.Text = String.Empty Then

            CheckbookMsg.ShowMessage("There is already a receipt attached to this transaction", MsgButtons.OK, "Remove the current receipt if you wish to add another file", Exclamation)

        Else

            DataCon.AddReceiptTofrmTrans()

        End If

    End Sub

    Private Sub btnRemoveReceipt_Click(sender As Object, e As EventArgs) Handles btnRemoveReceipt.Click

        m_colReceiptFilesToDelete.Add(AppendReceiptPath(m_strCurrentFile, Me.txtReceipt.Text))

        Me.txtReceipt.Text = String.Empty

    End Sub

    Private Sub btnViewReceipt_Click(sender As Object, e As EventArgs) Handles btnViewReceipt.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strReceiptFile As String = String.Empty
        strReceiptFile = Me.txtReceipt.Text

        If strReceiptFile = String.Empty Then

            CheckbookMsg.ShowMessage("This transaction does not have a receipt attached", MsgButtons.OK, "", Exclamation)

        ElseIf Not m_strOriginalReceiptToCopy = String.Empty Then

            If Not System.IO.File.Exists(m_strOriginalReceiptToCopy) Then

                CheckbookMsg.ShowMessage("The receipt for this transaction does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

            Else

                Process.Start(m_strOriginalReceiptToCopy)

            End If

        Else

            Dim strReceipt As String = String.Empty
            strReceipt = AppendReceiptPath(m_strCurrentFile, strReceiptFile)

            If Not System.IO.File.Exists(m_strOriginalReceiptToCopy) Then

                CheckbookMsg.ShowMessage("The receipt for this transaction does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

            Else

                Process.Start(strReceipt)

            End If

        End If

    End Sub

    Private Sub btnViewStatement_Click(sender As Object, e As EventArgs) Handles btnViewStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedIndex As Integer = 0
        intSelectedIndex = cbStatements.SelectedIndex

        If intSelectedIndex < 0 Then

            CheckbookMsg.ShowMessage("This transaction does not have a statement attached", MsgButtons.OK, "", Exclamation)

        Else

            Dim strStatementName As String = String.Empty
            strStatementName = cbStatements.SelectedItem.ToString

            Dim strStatementFileName As String = String.Empty

            FileCon.Connect()
            strStatementFileName = FileCon.SQLselect_Command("SELECT StatementFileName FROM Statements WHERE StatementName = '" & strStatementName & "'")
            FileCon.Close()

            strStatementFileName = AppendStatementPath(m_strCurrentFile, strStatementFileName)

            If Not System.IO.File.Exists(strStatementFileName) Then

                CheckbookMsg.ShowMessage("The file for this statement does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

            Else

                Process.Start(strStatementFileName)

            End If

        End If

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/transactions.html"
        Process.Start(strWebAddress)

    End Sub

    Private Sub btnMyStatements_Click(sender As Object, e As EventArgs) Handles btnMyStatements.Click

        Dim new_frmStatements As New frmMyStatements
        new_frmStatements.ShowDialog()

    End Sub

    Private Sub btnRemoveStatement_Click(sender As Object, e As EventArgs) Handles btnRemoveStatement.Click

        cbStatements.SelectedIndex = -1

    End Sub

End Class