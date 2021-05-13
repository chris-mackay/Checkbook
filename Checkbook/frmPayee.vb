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

Public Class frmPayee

    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private NewPayee As New clsTransaction
    Private UIManager As New clsUIManager

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Dispose()
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub frmPayee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim colorRenderer_System As New clsUIManager.MySystemRenderer

        tsToolStrip.Renderer = colorRenderer_System

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        FileCon.caller_frmPayee = Me
        FileCon.caller_frmTransaction = m_frmTrans

        btnSearch.Checked = False
        lblSearch.Visible = False
        txtSearch.Visible = False
        lstPayees.Size = New Size(237, 267)

        Try

            FileCon.Connect()
            FileCon.SQLread_Fill_lstPayees("SELECT * FROM Payees")
            FileCon.Close()

            CountTotalListBoxItems_Display(lstPayees, lblItemCount)

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If m_frmTrans IsNot Nothing Then

            Try

                Dim strPreviousPayee As String = String.Empty
                strPreviousPayee = m_frmTrans.cbPayee.Text

                FileCon.Connect()
                FileCon.SQLread_FillcbPayees("SELECT * FROM Payees")
                FileCon.Close()

                If Not lstPayees.SelectedItems.Count = 0 Then

                    m_frmTrans.cbPayee.SelectedIndex = m_frmTrans.cbPayee.FindStringExact(Me.lstPayees.SelectedItem).ToString

                Else

                    m_frmTrans.cbPayee.SelectedIndex = m_frmTrans.cbPayee.FindStringExact(strPreviousPayee)

                End If

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            Finally

                Me.Dispose()

            End Try

        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim new_frmCreate As New frmCreate
        new_frmCreate.Text = "Create Payee"
        new_frmCreate.Icon = My.Resources.AddPayee
        new_frmCreate.txtEnter.Text = String.Empty

        Dim colPayeeCollection As New Microsoft.VisualBasic.Collection

        Try

            FileCon.Connect()
            FileCon.SQLread_FillCollection_FromDBColumn("SELECT * FROM Payees", colPayeeCollection, "Payee")
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        If new_frmCreate.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim strPayee As String = String.Empty
            strPayee = new_frmCreate.txtEnter.Text

            For Each payee As String In colPayeeCollection

                If strPayee.ToUpper = payee.ToUpper Then

                    CheckbookMsg.ShowMessage("Payee Conflict", MsgButtons.OK, "'" & strPayee & "'" & " already exists in your payee list", Exclamation)
                    Exit Sub

                End If

            Next

            NewPayee.Payee = strPayee

            Try

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO Payees (Payee) VALUES ('" & NewPayee.Payee & "')")
                FileCon.SQLread_Fill_lstPayees("SELECT * FROM Payees")
                FileCon.Close()

                lstPayees.SelectedIndex = lstPayees.FindStringExact(NewPayee.Payee)
                CountTotalListBoxItems_Display(lstPayees, lblItemCount)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            End Try

        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strDeletePayee As String = String.Empty
        Dim strRenamedPayee As String = String.Empty
        Dim strMessage As String = String.Empty
        Dim strMessage2 As String = String.Empty

        Dim intCount As Integer = 0

        If lstPayees.SelectedIndex < 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to delete", MsgButtons.OK, "", Exclamation)

        Else

            strDeletePayee = lstPayees.SelectedItem.ToString
            strRenamedPayee = "Unknown"

            NewPayee.Payee = strRenamedPayee

            strMessage = "Are you sure you want to delete the payee '" & strDeletePayee & "'?"
            strMessage2 = "Consider renaming if you have used this payee"

            If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strMessage2, Question) = DialogResult.Yes Then

                Try

                    FileCon.Connect()

                    FileCon.SQLupdate("UPDATE LedgerData SET Payee = '" & NewPayee.Payee & "' WHERE Payee = '" & strDeletePayee & "'")
                    FileCon.SQLdelete("DELETE FROM Payees WHERE Payee = '" & strDeletePayee & "'")

                    FileCon.SQLread_Fill_lstPayees("SELECT * FROM Payees")

                    If m_blnLedgerIsBeingBalanced Then

                        DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                        DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                    Else

                        DataCon.SelectAllLedgerData_UpdateAccountDetails()

                    End If

                    CountTotalListBoxItems_Display(lstPayees, lblItemCount)

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Delete Payee Error", MsgButtons.OK, "An error occurred while deleting payee" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                Finally

                    FileCon.Close()

                End Try

            End If

        End If

    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If lstPayees.SelectedIndex < 0 Then

            CheckbookMsg.ShowMessage("Please select a payee to rename", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmRename As New frmRename
            new_frmRename.Text = "Rename Payee"
            new_frmRename.txtPrevious.BackColor = Color.White
            new_frmRename.txtPrevious.Text = lstPayees.SelectedItem.ToString
            new_frmRename.txtRename.Text = lstPayees.SelectedItem.ToString
            new_frmRename.txtRename.Focus()
            new_frmRename.txtRename.SelectAll()

            If new_frmRename.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim strPreviousPayeeName As String = String.Empty
                Dim strNewPayeeName As String = String.Empty
                Dim strSelectedPayee As String = String.Empty

                strPreviousPayeeName = new_frmRename.txtPrevious.Text
                strNewPayeeName = new_frmRename.txtRename.Text
                strSelectedPayee = lstPayees.SelectedItem.ToString

                If strPreviousPayeeName.ToUpper = strNewPayeeName.ToUpper Then

                    CheckbookMsg.ShowMessage("Payee Conflict", MsgButtons.OK, "The payee you entered is the same as the original, please enter a unique payee name", Exclamation)
                    new_frmRename.txtRename.Focus()
                    new_frmRename.txtRename.SelectAll()
                    Exit Sub

                ElseIf CheckbookMsg.ShowMessage("Are you sure you want to rename the payee '" & strSelectedPayee & "' to '" & new_frmRename.txtRename.Text & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        Dim intCount As Integer = 0

                        NewPayee.Payee = strNewPayeeName

                        FileCon.Connect()

                        FileCon.SQLupdate("UPDATE LedgerData SET Payee = '" & NewPayee.Payee & "' WHERE Payee = '" & strPreviousPayeeName & "'")
                        FileCon.SQLupdate("UPDATE Payees SET Payee = '" & NewPayee.Payee & "' WHERE Payee = '" & strPreviousPayeeName & "'")

                        FileCon.SQLread_Fill_lstPayees("SELECT * FROM Payees")

                        If m_blnLedgerIsBeingBalanced Then

                            DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                        ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                            DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                        ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                            DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                        Else

                            DataCon.SelectAllLedgerData_UpdateAccountDetails()

                        End If

                        FileCon.Close()

                        lstPayees.SelectedIndex = lstPayees.FindStringExact(NewPayee.Payee)
                        UIManager.UpdateStatusStripInfo()

                        CheckbookMsg.ShowMessage("'" & strPreviousPayeeName & "' has been successfully renamed to  '" & NewPayee.Payee & "'", MsgButtons.OK, "", Exclamation)

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Rename Payee Error", MsgButtons.OK, "An error occurred while renaming payee" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                    Finally

                        FileCon.Close()

                        UIManager.UpdateStatusStripInfo()

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        btnSearch.Checked = Not (btnSearch.Checked)
        If btnSearch.Checked = True Then
            lblSearch.Visible = True
            txtSearch.Visible = True
            txtSearch.Text = ""
            lstPayees.Size = New Size(237, 225)
            txtSearch.Focus()
        End If
        If btnSearch.Checked = False Then
            lblSearch.Visible = False
            txtSearch.Visible = False
            lstPayees.Size = New Size(237, 267)
        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If txtSearch.Text = String.Empty Then
            lstPayees.SelectedIndex = -1
        End If
        Dim strSearch As String = txtSearch.Text.Trim
        If strSearch.Length = 0 Then Exit Sub
        Dim wordIndex As Integer
        wordIndex = lstPayees.FindStringExact(strSearch)
        If wordIndex >= 0 Then
            lstPayees.TopIndex = wordIndex
            lstPayees.SelectedIndex = wordIndex
        Else
            wordIndex = lstPayees.FindString(strSearch)
            If wordIndex >= 0 Then
                lstPayees.TopIndex = wordIndex
                lstPayees.SelectedIndex = wordIndex
            Else
                CheckbookMsg.ShowMessage("'" & strSearch & "'" & " does not exist in this list", MsgButtons.OK, "", Exclamation)
            End If
        End If

    End Sub

    Private Sub btnSweep_Click(sender As Object, e As EventArgs) Handles btnSweep.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
        Dim intOriginalPayeeItemsCount As Integer = 0
        Dim intNewPayeeItemsCount As Integer = 0

        intOriginalPayeeItemsCount = lstPayees.Items.Count

        FileCon.Connect()
        FileCon.SQLdelete("DELETE * FROM Payees")

        Dim colPayees As New Microsoft.VisualBasic.Collection

        FileCon.SQLread_FillCollection_FromDBColumn_RemoveDuplicates("SELECT * FROM LedgerData", colPayees, "Payee")

        For Each payee As String In colPayees

            If Not payee = String.Empty And Not payee = "Unknown" Then

                NewPayee.Payee = payee

                FileCon.SQLinsert("INSERT INTO Payees (Payee) VALUES ('" & NewPayee.Payee & "')")

            End If

        Next

        lstPayees.Items.Clear()

        FileCon.SQLread_Fill_lstPayees("SELECT * FROM Payees")

        FileCon.Close()

        CountTotalListBoxItems_Display(lstPayees, lblItemCount)

        intNewPayeeItemsCount = lstPayees.Items.Count

        If intNewPayeeItemsCount < intOriginalPayeeItemsCount Then

            Dim intPayeesRemovedCount As Integer = 0
            intPayeesRemovedCount = intOriginalPayeeItemsCount - intNewPayeeItemsCount
            Dim message As String = String.Empty

            If intPayeesRemovedCount = 1 Then message = intPayeesRemovedCount & " unused payee has been removed from your list" Else message = intPayeesRemovedCount & " unused payees have been removed from your list"

            CheckbookMsg.ShowMessage("All unused payees have been removed", MsgButtons.OK, message, Exclamation)

        Else

            CheckbookMsg.ShowMessage("There are no unused payees to remove", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        Dim new_frmImportPayees As New frmImportPayees
        new_frmImportPayees.ShowDialog()

        lstPayees.Items.Clear()
        FileCon.Connect()
        FileCon.SQLread_Fill_lstPayees("SELECT * FROM Payees")
        FileCon.Close()

        CountTotalListBoxItems_Display(lstPayees, lblItemCount)

    End Sub

    Private Sub lstPayees_DoubleClick(sender As Object, e As EventArgs) Handles lstPayees.DoubleClick

        lstPayees.ClearSelected()

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/categories_payees.html"
        Process.Start(strWebAddress)

    End Sub

End Class