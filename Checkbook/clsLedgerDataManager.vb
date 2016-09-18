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

Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds

Public Class clsLedgerDataManager

    'CREATES A LINE OF COMMUNICATION BETWEEN FORMS
    Inherits Form
    Public caller_frmRenameCategory As frmRename
    Public caller_frmCategory As frmCategory
    Public caller_frmPayee As frmPayee
    Public caller_frmEditCategory As frmEditCategory
    Public caller_frmEditPayee As frmEditPayee
    Public caller_frmTransaction As frmTransaction
    Public caller_frmEditPayment As frmEditPayment
    Public caller_frmEditDeposit As frmEditDeposit
    Public caller_frmEditTransDate As frmEditTransDate
    Public caller_frmEditType As frmEditType
    Public caller_frmMainForm As MainForm

    'NEW INSTANCES OF CLASSES
    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager
    Private NewTrans As New clsTransaction

    Public Sub DeleteAllAssociatedReceipts()

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim intRowIndex As Integer

                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)

                Dim receiptFileCollection As New Microsoft.VisualBasic.Collection

                FillCollectionWith_dgvLedgerDataFromSelectedRows_RemoveDuplicates(receiptFileCollection, "Receipt")

                For Each receiptFile As String In receiptFileCollection

                    If System.IO.File.Exists(AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, receiptFile)) Then

                        My.Computer.FileSystem.DeleteFile(AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, receiptFile), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)

                    End If

                Next

            Next

        End With

    End Sub

    Public Sub DeleteSelected()

        'OPENS THE DATABASE CONNECTION
        FileCon.Connect()

        Dim intRowIndex As Integer

        With MainForm

            'DELETES ALL SELECTED ROWS
            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                Dim dgvID As Integer = .dgvLedger.Item("ID", intRowIndex).Value
                FileCon.SQLdelete("DELETE FROM LedgerData WHERE ID = " & dgvID & "")

            Next

            DeleteAllAssociatedReceipts() 'DELETES ALL ASSOCIATED RECEIPTS FROM SELECTED ROWS

            If m_ledgerIsBeingBalanced Then

                SelectOnlyUnCleared_UpdateAccountDetails()

            ElseIf (m_ledgerIsBeingFiltered And Not MainForm.txtFilter.Text = "") Or m_ledgerIsBeingFiltered_Advanced Then

                SelectOnlyFiltered_UpdateAccountDetails()

            Else

                SelectAllLedgerData_UpdateAccountDetails()

            End If

        End With

    End Sub

    Public Sub InsertData(ByVal _type As String, ByVal _category As String, ByVal _date As Date, ByVal _payment As String, ByVal _deposit As String, ByVal _payee As String, ByVal _description As String, ByVal _cleared As Boolean, ByVal _receipt As String)

        NewTrans.Type = _type
        NewTrans.Category = _category
        NewTrans.TransDate = _date
        NewTrans.Payment = _payment
        NewTrans.Deposit = _deposit
        NewTrans.Payee = _payee
        NewTrans.Description = _description
        NewTrans.Cleared = _cleared
        NewTrans.Receipt = _receipt

        If NewTrans.Category = "" Then

            NewTrans.Category = "Uncategorized"

        End If

        If NewTrans.Payee = "" Then

            NewTrans.Payee = "Unknown"

        End If

        'CONNECTS TO DATABASE AND INSERTS NEW TRANSACTION DATA
        'FILLS THE DATAGRIDVIEW AND THE CLOSES CONNECTION
        FileCon.Connect()
        FileCon.SQLinsert("INSERT INTO LedgerData (Type,Category,TransDate,Payment,Deposit,Payee,Description,Cleared,Receipt) VALUES('" & NewTrans.Type & "','" & NewTrans.Category & "','" & NewTrans.TransDate & "','" & NewTrans.Payment & "','" & NewTrans.Deposit & "','" & NewTrans.Payee & "','" & NewTrans.Description & "'," & NewTrans.Cleared & ",'" & NewTrans.Receipt & "')")

        Dim strCopyofReceipt As String

        strCopyofReceipt = AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, NewTrans.Receipt)

        If Not NewTrans.Receipt = String.Empty Then

            My.Computer.FileSystem.CopyFile(m_strOriginalReceiptToCopy, strCopyofReceipt, True)

        End If

        If m_ledgerIsBeingBalanced Then

            SelectOnlyUnCleared_UpdateAccountDetails()
            CheckIfAccountIsBalanced_LoadAllTransactions()

        ElseIf (m_ledgerIsBeingFiltered And Not MainForm.txtFilter.Text = "") Or m_ledgerIsBeingFiltered_Advanced Then

            SelectOnlyFiltered_UpdateAccountDetails()

        Else

            SelectAllLedgerData_UpdateAccountDetails()

        End If

        MainForm.dgvLedger.ClearSelection()

        UIManager.UpdateStatusStripInfo()

    End Sub

    Public Sub UpdateData(ByVal _type As String, ByVal _category As String, ByVal _date As Date, ByVal _payment As String, ByVal _deposit As String, ByVal _payee As String, ByVal _description As String, ByVal _cleared As Boolean, ByVal _receipt As String)

        'RETRIEVES VALUES FROM INPUT FORM

        NewTrans.Type = _type
        NewTrans.Category = _category
        NewTrans.TransDate = _date
        NewTrans.Payment = _payment
        NewTrans.Deposit = _deposit
        NewTrans.Payee = _payee
        NewTrans.Description = _description
        NewTrans.Cleared = _cleared
        NewTrans.Receipt = _receipt

        If NewTrans.Category = "" Then

            NewTrans.Category = "Uncategorized"

        End If

        If NewTrans.Payee = "" Then

            NewTrans.Payee = "Unknown"

        End If

        With MainForm

            'CONNECTS TO DATABASE AND INSERTS NEW TRANSACTION DATA
            'FILLS THE DATAGRIDVIEW AND THE CLOSES CONNECTION
            FileCon.Connect()
            FileCon.SQLupdate("UPDATE LedgerData SET Type ='" & NewTrans.Type & "', Category ='" & NewTrans.Category & "', TransDate ='" & NewTrans.TransDate & "', Payment ='" & NewTrans.Payment & "', Deposit ='" & NewTrans.Deposit & "', Payee ='" & NewTrans.Payee & "', Description ='" & NewTrans.Description & "', Cleared =" & NewTrans.Cleared & ", Receipt ='" & NewTrans.Receipt & "' WHERE ID = " & m_dgvID & "")

            Dim strCopyofReceipt As String

            strCopyofReceipt = AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, NewTrans.Receipt)

            If Not NewTrans.Receipt = String.Empty Then

                If Not System.IO.File.Exists(m_strOriginalReceiptToCopy) Or Not System.IO.File.Exists(strCopyofReceipt) Then

                    My.Computer.FileSystem.CopyFile(m_strOriginalReceiptToCopy, strCopyofReceipt, True)

                End If

            End If

            For Each receiptFile As String In m_colReceiptFilesToDelete

                If Not receiptFile = String.Empty And System.IO.File.Exists(receiptFile) Then

                    My.Computer.FileSystem.DeleteFile(receiptFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
                    receiptFile = String.Empty

                End If

            Next

            If m_ledgerIsBeingBalanced Then

                SelectOnlyUnCleared_UpdateAccountDetails()
                CheckIfAccountIsBalanced_LoadAllTransactions()

            ElseIf (m_ledgerIsBeingFiltered And Not MainForm.txtFilter.Text = "") Or m_ledgerIsBeingFiltered_Advanced Then

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

                Dim dgvRowIndex As Integer
                dgvRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                m_dgvID = .dgvLedger.Item("ID", dgvRowIndex).Value 'SETS PUBLIC VARIABLE IN MAIN MODULE FOR SELECTED TRANSACTION TO BE UPDATED

            Next

        End With

        Dim i As Integer

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
            m_strOriginalReceiptToCopy = AppendReceiptDirectoryAndReceiptFile(m_strCurrentFile, NewTrans.Receipt)
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
            .cbType.Focus()
            .cbType.SelectAll()
            .btnCreate.Select()

        End With

    End Sub

    Public Sub AddReceiptTofrmTrans()

        Dim ofdAddReceipt As New OpenFileDialog

        Dim timeStamp As String

        timeStamp = CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds).ToString

        ofdAddReceipt.FileName = ""
        ofdAddReceipt.Title = "Choose Receipt File"
        ofdAddReceipt.Filter = "All Files (*.*)|*.*"

        If My.Settings.DefaultChooseReceiptDirectory = String.Empty Then

            ofdAddReceipt.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        Else

            ofdAddReceipt.InitialDirectory = My.Settings.DefaultChooseReceiptDirectory

        End If

        If ofdAddReceipt.ShowDialog(caller_frmTransaction) = Windows.Forms.DialogResult.OK Then

            m_strOriginalReceiptToCopy = ofdAddReceipt.FileName

            NewTrans.Receipt = timeStamp & "_" & System.IO.Path.GetFileName(ofdAddReceipt.FileName)
            caller_frmTransaction.txtReceipt.Text = NewTrans.Receipt

        End If

    End Sub

    Public Sub LedgerStatus()

        MainModule.DrawingControl.SetDoubleBuffered_ListControls(m_groupAccountDetailTextboxes)
        MainModule.DrawingControl.SuspendDrawing_ListControls(m_groupAccountDetailTextboxes)

        'CALCULATE TOTAL PAYMENTS
        Dim strPayment As String
        Dim dblTotalPayments As Double

        Dim paymentCollection As New Microsoft.VisualBasic.Collection

        FileCon.Connect()
        FileCon.SQLread_FillCollection_FromDBColumn("SELECT * FROM LedgerData", paymentCollection, "Payment")
        FileCon.Close()

        For Each payment As String In paymentCollection

            strPayment = payment

            If strPayment = "" Then

                strPayment = 0

            Else

                strPayment = CDbl(strPayment)

            End If

            dblTotalPayments += strPayment

        Next

        'CALCULATES CLEARED PAYMENTS
        Dim strClearedPayment As String
        Dim dblTotalClearedPayments As Double

        Dim clearedPaymentCollection As New Microsoft.VisualBasic.Collection

        FileCon.Connect()
        FileCon.SQLread_FillCollection_FromDBColumn("SELECT * FROM LedgerData WHERE Cleared = True", clearedPaymentCollection, "Payment")
        FileCon.Close()

        For Each clearedPayment As String In clearedPaymentCollection

            strClearedPayment = clearedPayment

            If strClearedPayment = "" Then

                strClearedPayment = 0

            Else

                strClearedPayment = CDbl(strClearedPayment)

            End If

            dblTotalClearedPayments += strClearedPayment

        Next

        'CALCULATES TOTAL DEPOSITS
        Dim strDeposit As String
        Dim dblTotalDeposits As Double

        Dim depositCollection As New Microsoft.VisualBasic.Collection

        FileCon.Connect()
        FileCon.SQLread_FillCollection_FromDBColumn("SELECT * FROM LedgerData", depositCollection, "Deposit")
        FileCon.Close()

        For Each deposit As String In depositCollection

            strDeposit = deposit

            If strDeposit = "" Then

                strDeposit = 0

            Else

                strDeposit = CDbl(strDeposit)

            End If

            dblTotalDeposits += strDeposit

        Next

        'CALCULATES CLEARED DEPOSITS
        Dim strClearedDeposit As String = String.Empty
        Dim dblTotalClearedDeposits As Double

        Dim clearedDepositCollection As New Microsoft.VisualBasic.Collection

        FileCon.Connect()
        FileCon.SQLread_FillCollection_FromDBColumn("SELECT * FROM LedgerData WHERE Cleared = True", clearedDepositCollection, "Deposit")
        FileCon.Close()

        For Each clearedDeposit As String In clearedDepositCollection

            strClearedDeposit = clearedDeposit

            If strClearedDeposit = "" Then

                strClearedDeposit = 0

            Else

                strClearedDeposit = CDbl(strClearedDeposit)

            End If

            dblTotalClearedDeposits += strClearedDeposit

        Next

        Dim dblStartBalance As Double
        Dim dblLedgerStatus As Double
        Dim dblOverallBalance As Double
        Dim dblClearedBalance As Double

        dblStartBalance = CDbl(MainForm.txtStartingBalance.Text)

        dblLedgerStatus = dblTotalDeposits - dblTotalPayments

        dblOverallBalance = dblStartBalance + dblTotalDeposits - dblTotalPayments

        dblClearedBalance = dblStartBalance + dblTotalClearedDeposits - dblTotalClearedPayments

        MainForm.txtTotalPayments.Text = FormatCurrency(dblTotalPayments)
        MainForm.txtTotalDeposits.Text = FormatCurrency(dblTotalDeposits)
        MainForm.txtOverallBalance.Text = FormatCurrency(dblOverallBalance)
        MainForm.txtClearedBalance.Text = FormatCurrency(dblClearedBalance)
        MainForm.txtLedgerStatus.Text = FormatCurrency(dblLedgerStatus)

        Dim groupAccountDetailsTextboxes As New List(Of TextBox)

        With MainForm

            'ADDS ACCOUNT DETAILS TEXTBOXES INTO A GROUP TO EASILY SET BACKCOLOR
            groupAccountDetailsTextboxes.Add(.txtOverallBalance)
            groupAccountDetailsTextboxes.Add(.txtLedgerStatus)

        End With

        'FORMATS TEXTBOX COLORS BASED ON VALUES
        For Each textbox As TextBox In groupAccountDetailsTextboxes

            If textbox.Text > 0 Then
                textbox.BackColor = m_myGreen
            End If
            If textbox.Text < 0 Then
                textbox.BackColor = m_myRed
            End If
            If textbox.Text = 0 Then
                textbox.BackColor = Color.White
            End If

        Next

        MainModule.DrawingControl.ResumeDrawing_ListControls(m_groupAccountDetailTextboxes)

        'FORMATS UNCLEARED TRANSACTIONS
        FormatUncleared()

    End Sub

    Public Function SumPayments() 'USED IN SUM SELECTED COMMAND

        'CALCULATE TOTAL PAYMENTS
        Dim strPayment As String
        Dim dblTotalPayments As Double

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim i As Integer

                i = dgvRow.Index

                strPayment = .dgvLedger.Item("Payment", i).Value

                If strPayment = "" Then

                    strPayment = 0

                Else

                    strPayment = CDbl(strPayment)

                End If

                dblTotalPayments += strPayment

            Next

        End With

        Return FormatCurrency(dblTotalPayments)
    End Function

    Public Function SumDeposits() 'USED IN SUM SELECTED COMMAND

        'CALCULATES TOTAL DEPOSITS
        Dim strDeposit As String
        Dim dblTotalDeposits As Double

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim i As Integer

                i = dgvRow.Index

                strDeposit = .dgvLedger.Item("Deposit", i).Value

                If strDeposit = "" Then

                    strDeposit = 0

                Else

                    strDeposit = CDbl(strDeposit)

                End If

                dblTotalDeposits += strDeposit

            Next

        End With

        Return FormatCurrency(dblTotalDeposits)
    End Function

    Private Function CountUncategorizedTransaction()

        'SEARCHES FOR UNCATEGORIZED AND COUNTS INSTANCES
        Dim intUncategorizedCount As Integer = 0
        Dim strCategory As String

        With MainForm.dgvLedger

            For i As Integer = 0 To .RowCount - 1

                strCategory = .Item("Category", i).Value.ToString

                If strCategory = "Uncategorized" Then

                    'COUNTS NUMBER OF INSTANCES
                    intUncategorizedCount += 1

                End If

            Next

        End With

        Return intUncategorizedCount
    End Function

    Private Function CountUnknownPayees()

        'SEARCHES FOR UNKNOWN AND COUNTS INSTANCES
        Dim intUnknownCount As Integer = 0
        Dim strPayee As String

        With MainForm.dgvLedger

            For i As Integer = 0 To .RowCount - 1

                strPayee = .Item("Payee", i).Value.ToString

                If strPayee = "Unknown" Then

                    'COUNTS NUMBER OF INSTANCES
                    intUnknownCount += 1

                End If

            Next

        End With

        Return intUnknownCount
    End Function

    Public Sub Show_Uncategorized_Unknown_Message_FromOpen()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strMessage As String

        Dim strAdvice As String = vbNewLine & vbNewLine & "Assign a category and payee for each transaction to view totals in 'Spending Overview'" &
                                  vbNewLine & vbNewLine & "Use Filter and search for 'Uncategorized' or 'Unknown'"

        'SHOWS NUMBER OF UNCATEGORIZED TRANSACTIONS AND UNKNOWN PAYEES
        If CountUncategorizedTransaction() = 1 And CountUnknownPayees() = 1 Then 'IF THERE IS ONLY ONE UNCATEGORIED AND ONLY ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transaction" & vbNewLine &
                            CountUnknownPayees() & " unknown payee"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 1 And CountUnknownPayees() = 0 Then 'IF THERE IS ONLY ONE UNCATEGORIED

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transaction"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 0 And CountUnknownPayees() = 1 Then 'IF THERE IS ONLY ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUnknownPayees() & " unknown payee"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() > 1 And CountUnknownPayees() = 0 Then 'IF THERE IS MORE THAN ONE UNCATEGORIZED

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transactions"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 0 And CountUnknownPayees() > 1 Then 'IF THERE IS MORE THAN ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUnknownPayees() & " unknown payees"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() > 1 And CountUnknownPayees() > 1 Then 'IF THERE IS MORE THAN ONE UNCATEGORIZED AND MORE THAN ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transactions" & vbNewLine &
                            CountUnknownPayees() & " unknown payees"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() > 1 And CountUnknownPayees() = 1 Then 'IF THERE IS MORE THAN ONE UNCATEGORIZED AND ONLY ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transactions" & vbNewLine &
                            CountUnknownPayees() & " unknown payee"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 1 And CountUnknownPayees() > 1 Then 'IF THERE IS ONLY ONE UNCATEGORIZED AND MORE THAN ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transaction" & vbNewLine &
                            CountUnknownPayees() & " unknown payees"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        End If

    End Sub

    Public Sub Show_Uncategorized_Unknown_Message_FromMenu()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strMessage As String

        Dim strAdvice As String = vbNewLine & vbNewLine & "Assign a category and payee for each transaction to view totals in 'Spending Overview'" &
                                  vbNewLine & vbNewLine & "Use Filter and search for 'Uncategorized' or 'Unknown'"

        'SHOWS NUMBER OF UNCATEGORIZED TRANSACTIONS AND UNKNOWN PAYEES
        If CountUncategorizedTransaction() = 1 And CountUnknownPayees() = 1 Then 'IF THERE IS ONLY ONE UNCATEGORIED AND ONLY ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transaction" & vbNewLine &
                            CountUnknownPayees() & " unknown payee"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 1 And CountUnknownPayees() = 0 Then 'IF THERE IS ONLY ONE UNCATEGORIED

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transaction"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 0 And CountUnknownPayees() = 1 Then 'IF THERE IS ONLY ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUnknownPayees() & " unknown payee"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() > 1 And CountUnknownPayees() = 0 Then 'IF THERE IS MORE THAN ONE UNCATEGORIZED

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transactions"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 0 And CountUnknownPayees() > 1 Then 'IF THERE IS MORE THAN ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUnknownPayees() & " unknown payees"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() > 1 And CountUnknownPayees() > 1 Then 'IF THERE IS MORE THAN ONE UNCATEGORIZED AND MORE THAN ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transactions" & vbNewLine &
                            CountUnknownPayees() & " unknown payees"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() > 1 And CountUnknownPayees() = 1 Then 'IF THERE IS MORE THAN ONE UNCATEGORIZED AND ONLY ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transactions" & vbNewLine &
                            CountUnknownPayees() & " unknown payee"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        ElseIf CountUncategorizedTransaction() = 1 And CountUnknownPayees() > 1 Then 'IF THERE IS ONLY ONE UNCATEGORIZED AND MORE THAN ONE UNKNOWN

            strMessage = "This ledger currently has:" & vbNewLine & vbNewLine &
                            CountUncategorizedTransaction() & " uncategorized transaction" & vbNewLine &
                            CountUnknownPayees() & " unknown payees"

            CheckbookMsg.ShowMessage(strMessage, MsgButtons.OK, strAdvice, Exclamation)

        Else

            CheckbookMsg.ShowMessage("There are currently no uncategorized transactions or unknown payees.", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Public Enum enumTransactionProperties

        Type = 0
        TransDate = 1
        Deposit = 2
        Payment = 3
        Category = 4
        Payee = 5

    End Enum

    Public Sub UpdateSelectedLedgerData(ByVal _clsTransactionProperty As enumTransactionProperties, ByVal _valueToUpdate As Object)

        'OPENS THE DATABASE CONNECTION
        FileCon.Connect()

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                Dim intRowIndex As Integer
                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)

                Dim intID As Integer = .dgvLedger.Item("ID", intRowIndex).Value

                Select Case _clsTransactionProperty
                    Case enumTransactionProperties.Type

                        NewTrans.Type = TryCast(_valueToUpdate, String)

                        FileCon.SQLupdate("UPDATE LedgerData SET Type ='" & NewTrans.Type & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.TransDate

                        NewTrans.TransDate = CType(_valueToUpdate, Date)

                        FileCon.SQLupdate("UPDATE LedgerData SET TransDate ='" & NewTrans.TransDate & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Deposit

                        If Len(.dgvLedger("Payment", intRowIndex).Value.ToString) > 0 Then
                            NewTrans.Deposit = ""
                        Else
                            NewTrans.Deposit = TryCast(_valueToUpdate, String)
                        End If

                        FileCon.SQLupdate("UPDATE LedgerData SET Deposit ='" & NewTrans.Deposit & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Payment

                        If Len(.dgvLedger("Deposit", intRowIndex).Value.ToString) > 0 Then
                            NewTrans.Payment = ""
                        Else
                            NewTrans.Payment = TryCast(_valueToUpdate, String)
                        End If

                        FileCon.SQLupdate("UPDATE LedgerData SET Payment ='" & NewTrans.Payment & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Category

                        NewTrans.Category = TryCast(_valueToUpdate, String)

                        FileCon.SQLupdate("UPDATE LedgerData SET Category ='" & NewTrans.Category & "' WHERE ID = " & intID & "")

                    Case enumTransactionProperties.Payee

                        NewTrans.Payee = TryCast(_valueToUpdate, String)

                        FileCon.SQLupdate("UPDATE LedgerData SET Payee ='" & NewTrans.Payee & "' WHERE ID = " & intID & "")

                End Select

            Next

        End With

        If m_ledgerIsBeingBalanced Then

            SelectOnlyUnCleared_UpdateAccountDetails()

        ElseIf (m_ledgerIsBeingFiltered And Not MainForm.txtFilter.Text = "") Or m_ledgerIsBeingFiltered_Advanced Then

            SelectOnlyFiltered_UpdateAccountDetails()

        Else

            SelectAllLedgerData_UpdateAccountDetails()

        End If

    End Sub

    Public Sub ClearSelectedWithButton_MenuItem(ByVal _YesNo As Boolean)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        With MainForm

            Dim intSelectedRowCount As Integer
            intSelectedRowCount = .dgvLedger.SelectedRows.Count

            If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

                CheckbookMsg.ShowMessage("There are no items selected to edit", MsgButtons.OK, "", Exclamation)

            Else

                Try

                    UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                    Dim intRowIndex As Integer
                    NewTrans.Cleared = _YesNo

                    'CONNECTS TO DATABASE
                    FileCon.Connect()

                    For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                        intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                        Dim intID As Integer = .dgvLedger("ID", intRowIndex).Value

                        FileCon.SQLupdate("UPDATE LedgerData SET Cleared =" & NewTrans.Cleared & " WHERE ID = " & intID & "")

                    Next

                    If m_ledgerIsBeingBalanced Then

                        SelectOnlyUnCleared_UpdateAccountDetails()
                        CheckIfAccountIsBalanced_LoadAllTransactions()

                    ElseIf (m_ledgerIsBeingFiltered And Not MainForm.txtFilter.Text = "") Or m_ledgerIsBeingFiltered_Advanced Then

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

                Dim intRowIndex As Integer

                'CONNECTS TO DATABASE
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

                If m_ledgerIsBeingBalanced Then

                    SelectOnlyUnCleared_UpdateAccountDetails()
                    CheckIfAccountIsBalanced_LoadAllTransactions()

                ElseIf (m_ledgerIsBeingFiltered And Not MainForm.txtFilter.Text = "") Or m_ledgerIsBeingFiltered_Advanced Then

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

    Private Sub CheckIfAccountIsBalanced_LetUserKnow()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim isAccountBalance As Boolean = False
        Dim strOverallBalance As String = MainForm.txtOverallBalance.Text
        Dim strClearedBalance As String = MainForm.txtClearedBalance.Text

        If strOverallBalance = strClearedBalance Then

            CheckbookMsg.ShowMessage("Your account is balanced. You are up to to date with your bank records.", MsgButtons.OK, "", Exclamation)

        End If
    End Sub

    Private Sub CheckIfAccountIsBalanced_LoadAllTransactions()

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

    Public Sub FillCollectionWith_dgvLedgerDataFromSelectedRows_RemoveDuplicates(ByVal _collection As Microsoft.VisualBasic.Collection, ByVal _columnName As String)

        'THIS WILL GET ALL VALUES IN SELECTED ROWS FROM THE GRIDVIEW OF A PARTICULAR COLUMN AND PUT THEM IN A COLLECTION THEN REMOVE DUPLICATES.

        _collection.Clear()

        Dim intRowIndex As Integer

        With MainForm

            For Each dgvRow As DataGridViewRow In .dgvLedger.SelectedRows

                intRowIndex = .dgvLedger.Rows.IndexOf(dgvRow)
                Dim strItem As Object = .dgvLedger.Item(_columnName, intRowIndex).Value

                If Not IsDBNull(strItem) Then

                    strItem = strItem.ToString()

                    If Not strItem = String.Empty Then

                        _collection.Add(strItem)

                    End If

                End If

            Next

        End With

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        For x = _collection.Count To 2 Step -1

            For y = (x - 1) To 1 Step -1

                If _collection.Item(x) = _collection.Item(y) Then

                    _collection.Remove(x)

                    Exit For

                End If

            Next

        Next

    End Sub

    Public Sub SelectOnlyFiltered_UpdateAccountDetails()

        Dim intTop As Integer
        intTop = MainForm.dgvLedger.FirstDisplayedScrollingRowIndex

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
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

        Dim intTop As Integer
        intTop = MainForm.dgvLedger.FirstDisplayedScrollingRowIndex

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
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

        Dim intTop As Integer
        intTop = MainForm.dgvLedger.FirstDisplayedScrollingRowIndex

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        FileCon.Connect()

        'SELECTS THE AND FILLS THE DATAGRID WITH THE UPDATED DATA
        FileCon.SQLselect(FileCon.strSelectAllQuery)

        FileCon.Fill_Format_DataGrid_For_ExternalDrawingControl()

        'CLOSES THE DATABASE CONNECTION
        FileCon.Close()

        'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
        LedgerStatus()

        If MainForm.dgvLedger.Controls(1).Visible = True Then

            MainForm.dgvLedger.FirstDisplayedScrollingRowIndex = intTop

        End If

        MainForm.dgvLedger.ClearSelection()
        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        UIManager.UpdateStatusStripInfo()

    End Sub

End Class
