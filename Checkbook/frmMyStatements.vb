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

Public Class frmMyStatements

    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager

    Public caller_frmNewStatement As frmNewStatement

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Dispose()
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub btnNewStatement_Click(sender As Object, e As EventArgs) Handles btnNewStatement.Click, cxmnuNewStatement.Click

        Dim new_frmNewStatement As New frmNewStatement
        new_frmNewStatement.caller_frmMyStatements = Me
        new_frmNewStatement.FileCon = FileCon
        dgvMyStatements.ClearSelection()
        new_frmNewStatement.ShowDialog()

    End Sub

    Private Sub btnDeleteStatement_Click(sender As Object, e As EventArgs) Handles btnDeleteStatement.Click, cxmnuDeleteStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyStatements.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no statements selected to delete", MsgButtons.OK, "", Exclamation)

        Else

            For Each dgvRow As DataGridViewRow In dgvMyStatements.SelectedRows

                Dim intRowIndex As Integer = 0
                intRowIndex = dgvMyStatements.Rows.IndexOf(dgvRow)

                Dim dgvID As Integer = dgvMyStatements.Item("ID", intRowIndex).Value
                Dim strStatementName As String = String.Empty
                strStatementName = dgvMyStatements.Item("StatementName", intRowIndex).Value.ToString

                If CheckbookMsg.ShowMessage("Are you sure you want to delete the statement titled '" & strStatementName & "'?", MsgButtons.YesNo, "Deleting a statement cannot be undone.", Question) = DialogResult.Yes Then

                    Try

                        Dim strStatementFileName As String = String.Empty
                        FileCon.Connect()
                        strStatementFileName = FileCon.SQLselect_Command("SELECT StatementFileName FROM Statements WHERE StatementName = '" & strStatementName & "'")

                        FileCon.SQLdelete("DELETE FROM Statements WHERE ID = " & dgvID & "")
                        FileCon.SQLselect_statements("SELECT * FROM Statements")
                        FileCon.Fill_Format_Statements_DataGrid()

                        FileCon.SQLupdate("UPDATE LedgerData SET StatementName = '' WHERE StatementName = '" & strStatementName & "'")
                        FileCon.SQLupdate("UPDATE LedgerData SET StatementFileName = '' WHERE StatementFileName = '" & strStatementFileName & "'")
                        FileCon.Close()

                        If m_blnLedgerIsBeingBalanced Then

                            DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                        ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                            DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                        ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                            DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                        Else

                            DataCon.SelectAllLedgerData_UpdateAccountDetails()

                        End If

                        Dim strStatementToDelete As String = String.Empty
                        strStatementToDelete = AppendStatementPath(m_strCurrentFile, strStatementFileName)

                        If My.Computer.FileSystem.FileExists(strStatementToDelete) Then

                            My.Computer.FileSystem.DeleteFile(strStatementToDelete, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)

                        End If

                    Catch ex As Exception

                        Dim CheckbookMsg_Error As New CheckbookMessage.CheckbookMessage

                        Me.Dispose()
                        CheckbookMsg_Error.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                        Exit Sub

                    End Try

                End If

            Next

        End If

    End Sub

    Private Sub btnRenameStatement_Click(sender As Object, e As EventArgs) Handles btnRenameStatement.Click, cxmnuRenameStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyStatements.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no statements selected to rename", MsgButtons.OK, "", Exclamation)

        Else

            For Each dgvRow As DataGridViewRow In dgvMyStatements.SelectedRows

                Dim intRowIndex As Integer = 0
                intRowIndex = dgvMyStatements.Rows.IndexOf(dgvRow)

                Dim dgvID As Integer = dgvMyStatements.Item("ID", intRowIndex).Value
                Dim strPreviousStatementName As String = String.Empty
                strPreviousStatementName = dgvMyStatements.Item("StatementName", intRowIndex).Value.ToString

                Dim new_frmRename As New frmRename
                new_frmRename.Text = "Rename Statement"
                new_frmRename.txtPrevious.Text = strPreviousStatementName
                new_frmRename.txtRename.Text = strPreviousStatementName

                new_frmRename.txtRename.Focus()
                new_frmRename.txtRename.SelectAll()

                If new_frmRename.ShowDialog = DialogResult.OK Then

                    Dim strNewStatementName As String = String.Empty
                    strNewStatementName = new_frmRename.txtRename.Text

                    If strPreviousStatementName.ToUpper = strNewStatementName.ToUpper Then

                        CheckbookMsg.ShowMessage("Statement Conflict", MsgButtons.OK, "The statement name you entered is the same as the original, please enter a unique statement name", Exclamation)
                        new_frmRename.txtRename.Focus()
                        new_frmRename.txtRename.SelectAll()
                        Exit Sub

                    ElseIf CheckbookMsg.ShowMessage("Are you sure you want to rename the statement '" & strPreviousStatementName & "' to '" & strNewStatementName & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                        Try

                            FileCon.Connect()
                            FileCon.SQLupdate("UPDATE Statements SET StatementName = '" & strNewStatementName & "' WHERE StatementName = '" & strPreviousStatementName & "'")
                            FileCon.SQLupdate("UPDATE LedgerData SET StatementName = '" & strNewStatementName & "' WHERE StatementName = '" & strPreviousStatementName & "'")
                            FileCon.Fill_Format_Statements_DataGrid()
                            FileCon.Close()

                            If m_blnLedgerIsBeingBalanced Then

                                DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                            ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                                DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                            ElseIf m_blnLedgerIsBeingFiltered_Advanced Then

                                DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                            Else

                                DataCon.SelectAllLedgerData_UpdateAccountDetails()

                            End If

                        Catch ex As Exception

                            Dim CheckbookMsg_Error As New CheckbookMessage.CheckbookMessage

                            Me.Dispose()
                            CheckbookMsg_Error.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                            Exit Sub

                        End Try

                    End If

                End If

            Next

        End If

    End Sub

    Private Sub btnViewStatement_Click(sender As Object, e As EventArgs) Handles btnViewStatement.Click, cxmnuViewStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyStatements.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no statements selected to view", MsgButtons.OK, "", Exclamation)

        Else

            For Each dgvRow As DataGridViewRow In dgvMyStatements.SelectedRows

                Dim intRowIndex As Integer = 0
                intRowIndex = dgvMyStatements.Rows.IndexOf(dgvRow)

                Dim strStatementFileName As String = String.Empty
                strStatementFileName = dgvMyStatements.Item("StatementFileName", intRowIndex).Value.ToString

                Dim strStatementFile As String = String.Empty
                strStatementFile = AppendStatementPath(m_strCurrentFile, strStatementFileName)

                If Not System.IO.File.Exists(strStatementFile) Then

                    CheckbookMsg.ShowMessage("The file for this statement does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

                Else

                    Process.Start(strStatementFile)

                End If

            Next

        End If

    End Sub

    Private Sub frmStatements_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/my_statements.html"
        Process.Start(strWebAddress)

    End Sub

    Private Sub frmStatements_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim colorRenderer_Professional As New clsUIManager.MyProfessionalRenderer

        cxmnuManageStatements.Renderer = colorRenderer_Professional

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        FileCon.caller_frmMyStatements = Me
        MainModule.caller_frmMyStatements = Me
        DataCon.caller_frmMyStatements = Me
        FileCon.caller_frmTransaction = m_frmTrans

        Try

            FileCon.Connect()
            FileCon.SQLselect_statements("SELECT ID, StatementName, StatementFileName FROM Statements")
            FileCon.Fill_Format_Statements_DataGrid()
            FileCon.Close()

        Catch ex As Exception

            Me.Dispose()
            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If m_frmTrans IsNot Nothing Then

            Try

                Dim strPreviousStatement As String = String.Empty
                strPreviousStatement = m_frmTrans.cbStatements.Text

                FileCon.Connect()
                FileCon.SQLread_FillcbStatements("SELECT * FROM Statements")
                FileCon.Close()

                Dim strStatementName As String = String.Empty

                For Each dgvRow As DataGridViewRow In dgvMyStatements.SelectedRows

                    Dim intRowIndex As Integer = 0
                    intRowIndex = dgvMyStatements.Rows.IndexOf(dgvRow)

                    strStatementName = dgvMyStatements.Item("StatementName", intRowIndex).Value.ToString

                Next

                If Not strStatementName = String.Empty Then

                    m_frmTrans.cbStatements.SelectedIndex = m_frmTrans.cbStatements.FindStringExact(strStatementName).ToString

                Else

                    m_frmTrans.cbStatements.SelectedIndex = m_frmTrans.cbStatements.FindStringExact(strPreviousStatement)

                End If

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            Finally

                Me.Dispose()

            End Try

        End If

    End Sub

    Private Sub frmStatements_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        dgvMyStatements.ClearSelection()

    End Sub

End Class