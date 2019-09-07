'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2019 Christopher Mackay

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
Imports System.Xml

Public Class clsLedgerDataManager

    Inherits Form
    Public caller_frmRenameCategory As frmRename
    Public caller_frmCategory As frmCategory
    Public caller_frmPayee As frmPayee
    Public caller_frmEditCategory As frmEditCategory
    Public caller_frmEditPayee As frmEditPayee
    Public caller_frmEditStatement As frmEditStatement
    Public caller_frmTransaction As frmTransaction
    Public caller_frmEditPayment As frmEditPayment
    Public caller_frmEditDeposit As frmEditDeposit
    Public caller_frmEditTransDate As frmEditTransDate
    Public caller_frmEditType As frmEditType
    Public caller_frmMainForm As MainForm
    Public caller_frmNewStatement As frmNewStatement
    Public caller_frmMyStatements As frmMyStatements

    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager
    Private NewTrans As New clsTransaction

    Public Sub DeleteAllAssociatedReceipts()

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim intRowIndex As Integer = .dgvLedger.Rows.IndexOf(dgvRow)

                Dim receiptFileCollection As New Microsoft.VisualBasic.Collection

                FillCollectionWith_dgvLedgerDataFromSelectedRows_RemoveDuplicates(receiptFileCollection, "Receipt")

                For Each receiptFile As String In receiptFileCollection

                    If System.IO.File.Exists(AppendReceiptPath(m_strCurrentFile, receiptFile)) Then

                        My.Computer.FileSystem.DeleteFile(AppendReceiptPath(m_strCurrentFile, receiptFile), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)

                    End If

                Next

            Next

        End With

    End Sub

    Public Sub DeleteSelected()

        FileCon.Connect()

        Dim intRowIndex As Integer = 0

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                Dim dgvID As Integer = .dgvLedger.Item("ID", intRowIndex).Value
                FileCon.SQLdelete("DELETE FROM LedgerData WHERE ID = " & dgvID & "")

            Next

            DeleteAllAssociatedReceipts()

            If m_blnLedgerIsBeingBalanced Then

                SelectOnlyUnCleared_UpdateAccountDetails()

            ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                SelectOnlyFiltered_UpdateAccountDetails()

            ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                SelectOnlyFiltered_UpdateAccountDetails()

            Else

                SelectAllLedgerData_UpdateAccountDetails()

            End If

        End With

    End Sub

    Public Sub InsertData(ByVal _Type As String, ByVal _Category As String, ByVal _Date As Date, ByVal _Payment As String, ByVal _Deposit As String, ByVal _Payee As String, ByVal _Description As String, ByVal _Cleared As Boolean, ByVal _Receipt As String, ByVal _StatementName As String, ByVal _StatementFileName As String)

        NewTrans.Type = _Type
        NewTrans.Category = _Category
        NewTrans.TransDate = _Date
        NewTrans.Payment = _Payment
        NewTrans.Deposit = _Deposit
        NewTrans.Payee = _Payee
        NewTrans.Description = _Description
        NewTrans.Cleared = _Cleared
        NewTrans.Receipt = _Receipt
        NewTrans.StatementName = _StatementName
        NewTrans.StatementFileName = _StatementFileName

        If NewTrans.Category = String.Empty Then

            NewTrans.Category = "Uncategorized"

        End If

        If NewTrans.Payee = String.Empty Then

            NewTrans.Payee = "Unknown"

        End If

        FileCon.Connect()
        FileCon.SQLinsert("INSERT INTO LedgerData (Type,Category,TransDate,Payment,Deposit,Payee,Description,Cleared,Receipt,StatementName,StatementFileName) VALUES('" & NewTrans.Type & "','" & NewTrans.Category & "','" & NewTrans.TransDate & "','" & NewTrans.Payment & "','" & NewTrans.Deposit & "','" & NewTrans.Payee & "','" & NewTrans.Description & "'," & NewTrans.Cleared & ",'" & NewTrans.Receipt & "','" & NewTrans.StatementName & "','" & NewTrans.StatementFileName & "')")

        Dim strCopyofReceipt As String

        strCopyofReceipt = AppendReceiptPath(m_strCurrentFile, NewTrans.Receipt)

        If Not NewTrans.Receipt = String.Empty Then

            My.Computer.FileSystem.CopyFile(m_strOriginalReceiptToCopy, strCopyofReceipt, True)

        End If

        If m_blnLedgerIsBeingBalanced Then

            SelectOnlyUnCleared_UpdateAccountDetails()
            CheckIfAccountIsBalanced_LoadAllTransactions()

        ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

            SelectOnlyFiltered_UpdateAccountDetails()

        ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

            SelectOnlyFiltered_UpdateAccountDetails()

        Else

            SelectAllLedgerData_UpdateAccountDetails()

        End If

        MainForm.dgvLedger.ClearSelection()

        UIManager.UpdateStatusStripInfo()

    End Sub

    Public Sub UpdateData(ByVal _Type As String, ByVal _Category As String, ByVal _Date As Date, ByVal _Payment As String, ByVal _Deposit As String, ByVal _Payee As String, ByVal _Description As String, ByVal _Cleared As Boolean, ByVal _Receipt As String, ByVal _StatementName As String, ByVal _StatementFileName As String)

        'RETRIEVES VALUES FROM INPUT FORM
        NewTrans.Type = _Type
        NewTrans.Category = _Category
        NewTrans.TransDate = _Date
        NewTrans.Payment = _Payment
        NewTrans.Deposit = _Deposit
        NewTrans.Payee = _Payee
        NewTrans.Description = _Description
        NewTrans.Cleared = _Cleared
        NewTrans.Receipt = _Receipt
        NewTrans.StatementName = _StatementName
        NewTrans.StatementFileName = _StatementFileName

        If NewTrans.Category = String.Empty Then

            NewTrans.Category = "Uncategorized"

        End If

        If NewTrans.Payee = String.Empty Then

            NewTrans.Payee = "Unknown"

        End If

        With MainForm

            FileCon.Connect()
            FileCon.SQLupdate("UPDATE LedgerData SET Type ='" & NewTrans.Type & "', Category ='" & NewTrans.Category & "', TransDate ='" & NewTrans.TransDate & "', Payment ='" & NewTrans.Payment & "', Deposit ='" & NewTrans.Deposit & "', Payee ='" & NewTrans.Payee & "', Description ='" & NewTrans.Description & "', Cleared =" & NewTrans.Cleared & ", Receipt ='" & NewTrans.Receipt & "', StatementName ='" & NewTrans.StatementName & "', StatementFileName ='" & NewTrans.StatementFileName & "' WHERE ID = " & m_intDGVID & "")

            Dim strCopyofReceipt As String = String.Empty
            strCopyofReceipt = AppendReceiptPath(m_strCurrentFile, NewTrans.Receipt)

            If Not NewTrans.Receipt = String.Empty Then

                If Not System.IO.File.Exists(m_strOriginalReceiptToCopy) Or Not System.IO.File.Exists(strCopyofReceipt) Then

                    My.Computer.FileSystem.CopyFile(m_strOriginalReceiptToCopy, strCopyofReceipt, True)

                End If

            End If

            For Each strReceiptPath As String In m_colReceiptFilesToDelete

                If Not strReceiptPath = String.Empty And System.IO.File.Exists(strReceiptPath) Then

                    My.Computer.FileSystem.DeleteFile(strReceiptPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
                    strReceiptPath = String.Empty

                End If

            Next

            If m_blnLedgerIsBeingBalanced Then

                SelectOnlyUnCleared_UpdateAccountDetails()
                CheckIfAccountIsBalanced_LoadAllTransactions()

            ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                SelectOnlyFiltered_UpdateAccountDetails()

            ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                SelectOnlyFiltered_UpdateAccountDetails()

            Else

                SelectAllLedgerData_UpdateAccountDetails()
                CheckIfAccountIsBalanced_LetUserKnow()

            End If

        End With

    End Sub

    Public Sub EditSelected()

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim dgvRowIndex As Integer = 0
                dgvRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                m_intDGVID = .dgvLedger.Item("ID", dgvRowIndex).Value 'SETS PUBLIC VARIABLE IN MAIN MODULE FOR SELECTED TRANSACTION TO BE UPDATED

            Next

        End With

        Dim i As Integer = 0

        With caller_frmTransaction

            .cbType.Text = String.Empty
            .cbType.SelectedIndex = -1
            .cbCategory.Enabled = True
            .cbCategory.SelectedIndex = -1
            .txtPayment.Text = String.Empty
            .txtDeposit.Text = String.Empty
            .cbPayee.Enabled = True
            .cbPayee.SelectedIndex = -1
            .txtDescription.Text = String.Empty
            .txtReceipt.Text = String.Empty
            .cbStatements.SelectedIndex = -1
            .cbCleared.Checked = False

        End With

        With MainForm.dgvLedger

            i = .CurrentRow.Index

            NewTrans.Type = .Item("Type", i).Value.ToString
            NewTrans.Category = .Item("Category", i).Value.ToString
            NewTrans.TransDate = .Item("TransDate", i).Value
            NewTrans.Payment = .Item("Payment", i).Value.ToString
            NewTrans.Deposit = .Item("Deposit", i).Value.ToString
            NewTrans.Payee = .Item("Payee", i).Value.ToString
            NewTrans.Description = .Item("Description", i).Value.ToString
            NewTrans.Cleared = Convert.ToBoolean(.Item("Cleared", i).Value)
            NewTrans.Receipt = .Item("Receipt", i).Value.ToString
            m_strOriginalReceiptToCopy = AppendReceiptPath(m_strCurrentFile, NewTrans.Receipt)
            NewTrans.StatementName = .Item("StatementName", i).Value.ToString

            m_colReceiptFilesToDelete.Clear()

        End With

        With caller_frmTransaction

            .Icon = My.Resources.EditTrans
            .Text = "Edit Transaction"
            .btnCreate.Text = "Update"
            .cbType.Text = NewTrans.Type
            .cbCategory.SelectedIndex = .cbCategory.FindStringExact(NewTrans.Category).ToString
            .dtpTransDate.Value = NewTrans.TransDate
            .txtPayment.Text = NewTrans.Payment
            .txtDeposit.Text = NewTrans.Deposit
            .cbPayee.SelectedIndex = .cbPayee.FindStringExact(NewTrans.Payee).ToString
            .txtDescription.Text = NewTrans.Description
            .cbCleared.Checked = NewTrans.Cleared
            .txtReceipt.Text = NewTrans.Receipt
            .cbStatements.SelectedIndex = .cbStatements.FindStringExact(NewTrans.StatementName)
            .cbType.Focus()
            .btnCreate.Select()

        End With

    End Sub

    Public Sub AddStatement()

        Dim newStatement As New clsTransaction
        Dim ofdAddStatement As New OpenFileDialog
        Dim timeStamp As String = String.Empty

        timeStamp = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds).ToString

        ofdAddStatement.FileName = String.Empty
        ofdAddStatement.Title = "Choose Statement File"
        ofdAddStatement.Filter = "All Files (*.*)|*.*"

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseStatementDirectory) = String.Empty Then

            ofdAddStatement.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        Else

            ofdAddStatement.InitialDirectory = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseStatementDirectory)

        End If

        If ofdAddStatement.ShowDialog(caller_frmNewStatement) = Windows.Forms.DialogResult.OK Then

            Dim strStatementFileName As String = String.Empty

            strStatementFileName = timeStamp & "_" & System.IO.Path.GetFileName(ofdAddStatement.FileName)

            newStatement.StatementFileName = strStatementFileName

            m_strOriginalStatementToCopy = ofdAddStatement.FileName

            caller_frmNewStatement.txtStatementFile.Text = newStatement.StatementFileName

        End If

    End Sub

    Public Sub AddReceiptTofrmTrans()

        Dim ofdAddReceipt As New OpenFileDialog
        Dim strTimeStamp As String = String.Empty

        strTimeStamp = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds).ToString

        ofdAddReceipt.FileName = String.Empty
        ofdAddReceipt.Title = "Choose Receipt File"
        ofdAddReceipt.Filter = "All Files (*.*)|*.*"

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory) = String.Empty Then

            ofdAddReceipt.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        Else

            ofdAddReceipt.InitialDirectory = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory)

        End If

        If ofdAddReceipt.ShowDialog(caller_frmTransaction) = Windows.Forms.DialogResult.OK Then

            m_strOriginalReceiptToCopy = ofdAddReceipt.FileName

            NewTrans.Receipt = strTimeStamp & "_" & System.IO.Path.GetFileName(ofdAddReceipt.FileName)
            caller_frmTransaction.txtReceipt.Text = NewTrans.Receipt

        End If

    End Sub

    Public Sub LedgerStatus()

        MainModule.DrawingControl.SetDoubleBuffered_ListControls(m_lstAccountDetailTextboxes)
        MainModule.DrawingControl.SuspendDrawing_ListControls(m_lstAccountDetailTextboxes)

        FileCon.Connect()

        Dim dblTotalPayments As Double = FileCon.SQLselect_Command("SELECT sum(IIf(IsNumeric([Payment]),CDbl([Payment]),0)) as TotalPayments FROM LedgerData")
        Dim dblTotalDeposits As Double = FileCon.SQLselect_Command("SELECT sum(IIf(IsNumeric([Deposit]),CDbl([Deposit]),0)) as TotalDeposits FROM LedgerData")
        Dim dblTotalClearedPayments As Double = FileCon.SQLselect_Command("SELECT sum(IIf(IsNumeric([Payment]),CDbl([Payment]),0)) as ClearedPayments FROM LedgerData WHERE Cleared = True")
        Dim dblTotalClearedDeposits As Double = FileCon.SQLselect_Command("SELECT sum(IIf(IsNumeric([Deposit]),CDbl([Deposit]),0)) as ClearedDeposits FROM LedgerData WHERE Cleared = True")

        FileCon.Close()

        Dim dblStartBalance As Double = 0
        Dim dblLedgerStatus As Double = 0
        Dim dblOverallBalance As Double = 0
        Dim dblClearedBalance As Double = 0
        Dim dblUnclearedBalance As Double = 0

        dblStartBalance = CDbl(MainForm.txtStartingBalance.Text)

        dblLedgerStatus = dblTotalDeposits - dblTotalPayments

        dblOverallBalance = dblStartBalance + dblTotalDeposits - dblTotalPayments

        dblClearedBalance = dblStartBalance + dblTotalClearedDeposits - dblTotalClearedPayments

        dblUnclearedBalance = dblOverallBalance - dblClearedBalance

        MainForm.txtTotalPayments.Text = FormatCurrency(dblTotalPayments)
        MainForm.txtTotalDeposits.Text = FormatCurrency(dblTotalDeposits)
        MainForm.txtOverallBalance.Text = FormatCurrency(dblOverallBalance)
        MainForm.txtClearedBalance.Text = FormatCurrency(dblClearedBalance)
        MainForm.txtUnclearedBalance.Text = FormatCurrency(dblUnclearedBalance)
        MainForm.txtLedgerStatus.Text = FormatCurrency(dblLedgerStatus)

        Dim lstGroupAccountDetailsTextboxes As New List(Of TextBox)

        With MainForm

            'ADDS ACCOUNT DETAILS TEXTBOXES INTO A GROUP TO EASILY SET BACKCOLOR
            lstGroupAccountDetailsTextboxes.Add(.txtOverallBalance)
            lstGroupAccountDetailsTextboxes.Add(.txtLedgerStatus)

        End With

        'FORMATS TEXTBOX COLORS BASED ON VALUES
        For Each textbox As TextBox In lstGroupAccountDetailsTextboxes

            If textbox.Text > 0 Then
                textbox.BackColor = m_clrMyGreen
            End If
            If textbox.Text < 0 Then
                textbox.BackColor = m_clrMyRed
            End If
            If textbox.Text = 0 Then
                textbox.BackColor = Color.White
            End If

        Next

        MainModule.DrawingControl.ResumeDrawing_ListControls(m_lstAccountDetailTextboxes)

    End Sub

    Public Function SumPayments() 'USED IN SUM SELECTED COMMAND

        Dim strPayment As String = String.Empty
        Dim dblTotalPayments As Double = 0

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim i As Integer = 0
                i = dgvRow.Index

                strPayment = .dgvLedger.Item("Payment", i).Value

                If strPayment = String.Empty Then

                    strPayment = 0

                Else

                    strPayment = CDbl(strPayment)

                End If

                dblTotalPayments += strPayment

            Next

        End With

        Return dblTotalPayments
    End Function

    Public Function SumDeposits() 'USED IN SUM SELECTED COMMAND

        Dim strDeposit As String = String.Empty
        Dim dblTotalDeposits As Double = 0

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim i As Integer = 0
                i = dgvRow.Index

                strDeposit = .dgvLedger.Item("Deposit", i).Value

                If strDeposit = String.Empty Then

                    strDeposit = 0

                Else

                    strDeposit = CDbl(strDeposit)

                End If

                dblTotalDeposits += strDeposit

            Next

        End With

        Return dblTotalDeposits
    End Function

    Public Enum enumTransactionProperties

        Type = 0
        TransDate = 1
        Deposit = 2
        Payment = 3
        Category = 4
        Payee = 5
        Statement = 6

    End Enum

    Public Sub UpdateSelectedLedgerData(ByVal _clsTransactionProperty As enumTransactionProperties, ByVal _ValueToUpdate As Object)

        FileCon.Connect()

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim intRowIndex As Integer = 0
                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)

                Dim intID As Integer = .dgvLedger.Item("ID", intRowIndex).Value

                Select Case _clsTransactionProperty
                    Case enumTransactionProperties.Type

                        NewTrans.Type = TryCast(_ValueToUpdate, String)

                        FileCon.SQLupdate("UPDATE LedgerData SET Type ='" & NewTrans.Type & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.TransDate

                        NewTrans.TransDate = CType(_ValueToUpdate, Date)

                        FileCon.SQLupdate("UPDATE LedgerData SET TransDate ='" & NewTrans.TransDate & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Deposit

                        If Len(.dgvLedger("Payment", intRowIndex).Value.ToString) > 0 Then
                            NewTrans.Deposit = String.Empty
                        Else
                            NewTrans.Deposit = TryCast(_ValueToUpdate, String)
                        End If

                        FileCon.SQLupdate("UPDATE LedgerData SET Deposit ='" & NewTrans.Deposit & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Payment

                        If Len(.dgvLedger("Deposit", intRowIndex).Value.ToString) > 0 Then
                            NewTrans.Payment = String.Empty
                        Else
                            NewTrans.Payment = TryCast(_ValueToUpdate, String)
                        End If

                        FileCon.SQLupdate("UPDATE LedgerData SET Payment ='" & NewTrans.Payment & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Category

                        NewTrans.Category = TryCast(_ValueToUpdate, String)

                        FileCon.SQLupdate("UPDATE LedgerData SET Category ='" & NewTrans.Category & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Payee

                        NewTrans.Payee = TryCast(_ValueToUpdate, String)

                        FileCon.SQLupdate("UPDATE LedgerData SET Payee ='" & NewTrans.Payee & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Statement

                        NewTrans.StatementName = TryCast(_ValueToUpdate, String)
                        NewTrans.StatementFileName = FileCon.SQLselect_Command("SELECT StatementFileName FROM Statements WHERE StatementName = '" & NewTrans.StatementName & "'")

                        FileCon.SQLupdate("UPDATE LedgerData SET StatementName ='" & NewTrans.StatementName & "', StatementFileName ='" & NewTrans.StatementFileName & "' WHERE ID = " & intID & "")

                End Select

            Next

        End With

        If m_blnLedgerIsBeingBalanced Then

            SelectOnlyUnCleared_UpdateAccountDetails()

        ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

            SelectOnlyFiltered_UpdateAccountDetails()

        ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

            SelectOnlyFiltered_UpdateAccountDetails()

        Else

            SelectAllLedgerData_UpdateAccountDetails()

        End If

    End Sub

    Public Sub ClearSelectedWithButton_MenuItem(ByVal _YesNo As Boolean)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        With MainForm

            Dim intSelectedRowCount As Integer = 0
            intSelectedRowCount = .dgvLedger.SelectedRows.Count

            If intSelectedRowCount < 1 Then

                CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

            Else

                Try

                    UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                    Dim intRowIndex As Integer = 0
                    NewTrans.Cleared = _YesNo

                    FileCon.Connect()

                    For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                        intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                        Dim intID As Integer = .dgvLedger("ID", intRowIndex).Value

                        FileCon.SQLupdate("UPDATE LedgerData SET Cleared =" & NewTrans.Cleared & " WHERE ID = " & intID & "")

                    Next

                    If m_blnLedgerIsBeingBalanced Then

                        SelectOnlyUnCleared_UpdateAccountDetails()
                        CheckIfAccountIsBalanced_LoadAllTransactions()

                    ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                        SelectOnlyFiltered_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                        SelectOnlyFiltered_UpdateAccountDetails()

                    Else

                        SelectAllLedgerData_UpdateAccountDetails()
                        CheckIfAccountIsBalanced_LetUserKnow()

                    End If

                Catch exConnect As System.Data.OleDb.OleDbException

                    CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made." & vbNewLine & vbNewLine & exConnect.Message & vbNewLine & vbNewLine & exConnect.Source, Exclamation)

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Clear/Unclear Error", MsgButtons.OK, "An error occurred while clearing or unclearing the selected transactions" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                Finally

                    UIManager.SetCursor(MainForm, Cursors.Default)

                End Try

            End If

        End With

    End Sub

    Public Sub ToggleCleared()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        With MainForm

            Try

                UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                Dim intRowIndex As Integer = 0

                FileCon.Connect()

                For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                    intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                    Dim intID As Integer = .dgvLedger("ID", intRowIndex).Value
                    NewTrans.Cleared = .dgvLedger("Cleared", intRowIndex).Value

                    'NOT SURE WHY IT DOESN'T GET THE CURRENT VALUE. THIS SETS IT TO THE OPPOSITE OF WHAT THE VALUE IS
                    If NewTrans.Cleared = True Then
                        NewTrans.Cleared = False
                    Else
                        NewTrans.Cleared = True
                    End If

                    FileCon.SQLupdate("UPDATE LedgerData SET Cleared =" & NewTrans.Cleared & " WHERE ID = " & intID & "")

                Next

                If m_blnLedgerIsBeingBalanced Then

                    SelectOnlyUnCleared_UpdateAccountDetails()
                    CheckIfAccountIsBalanced_LoadAllTransactions()

                ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                    SelectOnlyFiltered_UpdateAccountDetails()

                ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                    SelectOnlyFiltered_UpdateAccountDetails()

                Else

                    SelectAllLedgerData_UpdateAccountDetails()
                    CheckIfAccountIsBalanced_LetUserKnow()

                End If

            Catch exConnect As System.Data.OleDb.OleDbException

                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made." & vbNewLine & vbNewLine & exConnect.Message & vbNewLine & vbNewLine & exConnect.Source, Exclamation)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Clear/Unclear Error", MsgButtons.OK, "An error occurred while clearing or unclearing the selected transactions" & vbNewLine & vbNewLine & ex.Message, Exclamation)

            Finally

                UIManager.SetCursor(MainForm, Cursors.Default)

            End Try

        End With

    End Sub

    Public Sub CheckIfAccountIsBalanced_LetUserKnow()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim isAccountBalance As Boolean = False
        Dim strOverallBalance As String = MainForm.txtOverallBalance.Text
        Dim strClearedBalance As String = MainForm.txtClearedBalance.Text

        If strOverallBalance = strClearedBalance Then

            CheckbookMsg.ShowMessage("Your account is balanced. You are up to to date with your bank records.", MsgButtons.OK, "", Exclamation)

        End If
    End Sub

    Public Sub CheckIfAccountIsBalanced_LoadAllTransactions()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim isAccountBalance As Boolean = False
        Dim strOverallBalance As String = MainForm.txtOverallBalance.Text
        Dim strClearedBalance As String = MainForm.txtClearedBalance.Text

        If strOverallBalance = strClearedBalance Then

            CheckbookMsg.ShowMessage("Your account is balanced. You are up to to date with your bank records.", MsgButtons.OK, "Checkbook will now load all of your transactions.", Exclamation)

            With MainForm

                .ToggleBalanceAccount(.balance_Button, .mnuBalanceAccount)

            End With

        End If
    End Sub

    Public Sub FillCollectionWith_dgvLedgerDataFromSelectedRows_RemoveDuplicates(ByVal _Collection As Microsoft.VisualBasic.Collection, ByVal _ColumnName As String)

        'THIS WILL GET ALL VALUES IN SELECTED ROWS FROM THE GRIDVIEW OF A PARTICULAR COLUMN AND PUT THEM IN A COLLECTION THEN REMOVE DUPLICATES.

        _Collection.Clear()

        Dim intRowIndex As Integer = 0

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                Dim strItem As Object = .dgvLedger.Item(_ColumnName, intRowIndex).Value

                If Not IsDBNull(strItem) Then

                    strItem = strItem.ToString()

                    If Not strItem = String.Empty Then

                        _Collection.Add(strItem)

                    End If

                End If

            Next

        End With

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        For x = _Collection.Count To 2 Step -1

            For y = (x - 1) To 1 Step -1

                If _Collection.Item(x) = _Collection.Item(y) Then

                    _Collection.Remove(x)

                    Exit For

                End If

            Next

        Next

    End Sub

    Public Sub SelectOnlyFiltered_UpdateAccountDetails()

        Dim intTop As Integer = 0
        intTop = MainForm.dgvLedger.FirstDisplayedScrollingRowIndex

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        LedgerStatus()

        RetainFilter()

        If MainForm.dgvLedger.Controls(1).Visible = True Then

            MainForm.dgvLedger.FirstDisplayedScrollingRowIndex = intTop

        End If

        MainForm.dgvLedger.ClearSelection()
        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        UIManager.UpdateStatusStripInfo()

    End Sub

    Public Sub SelectOnlyUnCleared_UpdateAccountDetails()

        Dim intTop As Integer = 0
        intTop = MainForm.dgvLedger.FirstDisplayedScrollingRowIndex

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        LedgerStatus()

        RetainAccountBalancing()

        If MainForm.dgvLedger.Controls(1).Visible = True Then

            MainForm.dgvLedger.FirstDisplayedScrollingRowIndex = intTop

        End If

        MainForm.dgvLedger.ClearSelection()
        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        UIManager.UpdateStatusStripInfo()

    End Sub

    Public Sub SelectAllLedgerData_UpdateAccountDetails()

        Dim intTop As Integer = 0
        intTop = MainForm.dgvLedger.FirstDisplayedScrollingRowIndex

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        FileCon.Connect()
        FileCon.SQLselect(FileCon.strSelectAllQuery)
        FileCon.Fill_Format_LedgerData_DataGrid_For_ExternalDrawingControl()

        FileCon.Close()

        LedgerStatus()

        If MainForm.dgvLedger.Controls(1).Visible = True Then

            MainForm.dgvLedger.FirstDisplayedScrollingRowIndex = intTop

        End If

        MainForm.dgvLedger.ClearSelection()
        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        UIManager.UpdateStatusStripInfo()

    End Sub

End Class
