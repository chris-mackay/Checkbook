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
Imports System.IO

Public Class frmBackup

    'NEW INSTANCES OF CLASSES
    Private File As New clsLedgerDBFileManager
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager
    Private watcher As New System.IO.FileSystemWatcher

    Private Sub dgvMyLedgers_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvMyLedgers.KeyDown

        Select Case e.KeyCode
            Case Keys.Delete
                DeleteLedger()
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim ledgerManagerControls As New List(Of Control)

        ledgerManagerControls.Add(btnDelete)
        ledgerManagerControls.Add(btnRename)
        ledgerManagerControls.Add(btnCopy)
        ledgerManagerControls.Add(btnRestore)
        ledgerManagerControls.Add(dgvMyLedgers)
        ledgerManagerControls.Add(btnClose)

        MainModule.DrawingControl.SetDoubleBuffered_ListControls(ledgerManagerControls)
        MainModule.DrawingControl.SuspendDrawing_ListControls(ledgerManagerControls)

        File.caller_frmBackup = Me

        Try

            File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers)

            dgvMyLedgers.ClearSelection()

        Catch exFileNotFound As System.IO.DirectoryNotFoundException

            CheckbookMsg.ShowMessage("Load Ledger Error", MsgButtons.OK, "'My Checkbook Ledgers' could not be found." & vbNewLine & "It may have been deleted or moved!", Exclamation)
            Me.Dispose()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Load Ledger Error", MsgButtons.OK, "An error occurred while loading 'My Checkbook Ledgers'" & vbNewLine & vbNewLine & ex.Message, Exclamation)
            Me.Dispose()

        Finally

            CreateDirectoryWatcher()

        End Try

        MainModule.DrawingControl.ResumeDrawing_ListControls(ledgerManagerControls)

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As EventArgs) Handles MyBase.Closed

        watcher.Dispose()
        watcher = Nothing

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        DeleteLedger()

    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strSelected_ledger_filename As String
        Dim strSelected_ledger_fullFile As String
        Dim strBudgets_fullFile As String

        Dim strBackup_folderPath As String
        Dim strBackup_ledger_fullFile As String
        Dim strBackup_budgets_fullFile As String
        Dim strBackup_ledger_filename As String

        Dim strLastModifiedDate_ledger_Backup As String
        Dim strLastModifiedDate_ledger_Current As String

        Dim dlgFolderDialog As New FolderBrowserDialog

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count


        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("Please select a ledger from the list then click 'Restore Ledger'", MsgButtons.OK, "", Exclamation)

        Else

            strSelected_ledger_filename = dgvMyLedgers.SelectedCells(0).Value.ToString

            strSelected_ledger_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & strSelected_ledger_filename & ".cbk"
            strBudgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strSelected_ledger_filename & ".bgt"

            dlgFolderDialog.ShowNewFolderButton = True
            dlgFolderDialog.Description = "Select the '_Backup' folder containing the copy of '" & strSelected_ledger_filename & "' you would like to restore"

            If My.Settings.DefaultBackupLedgerDirectory = String.Empty Then

                dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
                dlgFolderDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

            Else

                dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
                dlgFolderDialog.SelectedPath = My.Settings.DefaultBackupLedgerDirectory

            End If

            If dlgFolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                strBackup_folderPath = dlgFolderDialog.SelectedPath
                strBackup_ledger_fullFile = strBackup_folderPath & "\" & strSelected_ledger_filename & ".cbk"
                strBackup_budgets_fullFile = strBackup_folderPath & "\" & strSelected_ledger_filename & ".bgt"

                strLastModifiedDate_ledger_Backup = System.IO.File.GetLastWriteTime(strBackup_ledger_fullFile)
                strLastModifiedDate_ledger_Current = System.IO.File.GetLastWriteTime(strSelected_ledger_fullFile)

                strBackup_ledger_filename = System.IO.Path.GetFileNameWithoutExtension(strBackup_ledger_fullFile)

                Try

                    If Not My.Computer.FileSystem.FileExists(strBackup_ledger_fullFile) Then

                        CheckbookMsg.ShowMessage("No Backup Copy", MsgButtons.OK, "A backup copy of '" & strSelected_ledger_filename & "' was not found in the selected location.", Exclamation)

                    Else

                        If CheckbookMsg.ShowMessage("Are you sure you want to restore '" & strSelected_ledger_filename & "'?", MsgButtons.YesNo, "'" & strSelected_ledger_filename & "' was last modified on " & strLastModifiedDate_ledger_Current & vbNewLine & vbNewLine & "The selected backup ledger was last modified on " & strLastModifiedDate_ledger_Backup, Question) = DialogResult.Yes Then


                            Dim strBackupReceiptDirectory As String
                            strBackupReceiptDirectory = strBackup_folderPath & "\" & strBackup_ledger_filename & "_Receipts"

                            Dim strSelectedFileReceiptDirectory As String
                            strSelectedFileReceiptDirectory = AppendReceiptDirectory(strSelected_ledger_filename)

                            'DECIDES WHETHER TO COPY, OVERWRITE, OR DELETE BUDGETS FILE
                            My.Computer.FileSystem.CopyFile(strBackup_ledger_fullFile, strSelected_ledger_fullFile, True) 'COPIES SELECTED FILE FROM BACKUP LOCATION AND OVERWRITES FILE IN MY CHECKBOOK LEDGERS

                            If System.IO.File.Exists(strBackup_budgets_fullFile) And System.IO.File.Exists(strBudgets_fullFile) Then

                                My.Computer.FileSystem.CopyFile(strBackup_budgets_fullFile, strBudgets_fullFile, True)

                            ElseIf Not System.IO.File.Exists(strBackup_budgets_fullFile) And System.IO.File.Exists(strBudgets_fullFile) Then

                                My.Computer.FileSystem.DeleteFile(strBudgets_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)

                            ElseIf System.IO.File.Exists(strBackup_budgets_fullFile) And Not System.IO.File.Exists(strBudgets_fullFile) Then

                                My.Computer.FileSystem.CopyFile(strBackup_budgets_fullFile, strBudgets_fullFile, True)

                            End If

                            'DELETES RECEIPTS DIRECTORY AND COPIES FROM BACKUP FOLDER
                            My.Computer.FileSystem.DeleteDirectory(strSelectedFileReceiptDirectory, FileIO.DeleteDirectoryOption.DeleteAllContents)
                            My.Computer.FileSystem.CopyDirectory(strBackupReceiptDirectory, strSelectedFileReceiptDirectory, True)

                            If strBackup_ledger_filename = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) Then

                                File.OpenFilefromBackup()

                                CheckbookMsg.ShowMessage("'" & strSelected_ledger_filename & "' has been successfully restored.", MsgButtons.OK, "")

                                'RELOADS LEDGERS TO GET MOST RECENT MODIFIED DATES
                                File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers)

                            Else

                                CheckbookMsg.ShowMessage("'" & strSelected_ledger_filename & "' has been successfully restored.", MsgButtons.OK, "")

                            End If

                        Else

                            Exit Sub

                        End If

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Restore Error", MsgButtons.OK, "An error occurred while restoring the ledger." & vbNewLine & vbNewLine & ex.Message, Exclamation)

                End Try

            End If

        End If

    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("Please select a ledger from the list then click 'Rename Ledger'", MsgButtons.OK, "", Exclamation)

        Else

            Dim myfrmRename As New frmRename
            Dim strPrevious_filename As String
            Dim strRename_ledger_fullFile As String
            Dim strRename_budgets_fullFile As String
            Dim strNew_filename As String
            Dim strOriginalReceiptDirectory As String
            Dim strNewReceiptDirectory As String

            strPrevious_filename = dgvMyLedgers.SelectedCells(0).Value.ToString

            myfrmRename.Text = "Rename Ledger"
            myfrmRename.txtPrevious.BackColor = Color.White
            myfrmRename.txtPrevious.Text = strPrevious_filename
            myfrmRename.txtRename.Text = strPrevious_filename

            myfrmRename.txtRename.SelectAll()

            If myfrmRename.ShowDialog = Windows.Forms.DialogResult.OK Then

                If myfrmRename.txtPrevious.Text = myfrmRename.txtRename.Text Then

                    CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The filename you entered is the same as the original, please enter a unique filename.", Exclamation)

                ElseIf CheckbookMsg.ShowMessage("Are you sure you want to rename '" & strPrevious_filename & "' to '" & myfrmRename.txtRename.Text & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        strRename_ledger_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & strPrevious_filename & ".cbk"
                        strRename_budgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strPrevious_filename & ".bgt"

                        strNew_filename = myfrmRename.txtRename.Text

                        strOriginalReceiptDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Receipts\" & System.IO.Path.GetFileNameWithoutExtension(strRename_ledger_fullFile) & "_Receipts"
                        strNewReceiptDirectory = strNew_filename & "_Receipts"

                        My.Computer.FileSystem.RenameDirectory(strOriginalReceiptDirectory, strNewReceiptDirectory)
                        My.Computer.FileSystem.RenameFile(strRename_ledger_fullFile, strNew_filename & ".cbk")

                        If System.IO.File.Exists(strRename_budgets_fullFile) Then

                            My.Computer.FileSystem.RenameFile(strRename_budgets_fullFile, strNew_filename & ".bgt")

                        End If

                        If System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) = strPrevious_filename Then

                            m_strCurrentFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & strNew_filename & ".cbk"

                            MainForm.Text = "Checkbook - " & strNew_filename

                        End If

                        'RELOADS MYLEDGERS AFTER RENAMING OF FILE
                        File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers)

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Rename Ledger Error", MsgButtons.OK, "An error occurred while renaming the ledger." & vbNewLine & vbNewLine & ex.Message, Exclamation)
                        Exit Sub

                    Finally

                        File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strArchive_Directory As String
        Dim strArchive_receipts_Directory As String
        Dim strArchive_budgets_fullFile As String
        Dim strArchive_ledger_fullFile As String

        Dim strSelected_ledger_fileName As String
        Dim strSelected_ledger_fullFile As String
        Dim strBudgets_fullFile As String

        Dim strFolderDialogPath As String
        Dim strLastModifiedDate_Backup As String
        Dim dlgFolderDialog As New FolderBrowserDialog

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("Please select a ledger from the list then click 'Backup Ledger'", MsgButtons.OK, "", Exclamation)

        Else

            strSelected_ledger_fileName = dgvMyLedgers.SelectedCells(0).Value.ToString
            strSelected_ledger_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & strSelected_ledger_fileName & ".cbk"
            strBudgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strSelected_ledger_fileName & ".bgt"

            dlgFolderDialog.ShowNewFolderButton = True
            dlgFolderDialog.Description = "Select a location to create a backup folder for '" & strSelected_ledger_fileName & "'"

            If My.Settings.DefaultBackupLedgerDirectory = String.Empty Then

                dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
                dlgFolderDialog.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

            Else

                dlgFolderDialog.RootFolder = Environment.SpecialFolder.Desktop
                dlgFolderDialog.SelectedPath = My.Settings.DefaultBackupLedgerDirectory

            End If

            If dlgFolderDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                strFolderDialogPath = dlgFolderDialog.SelectedPath

                strArchive_Directory = strFolderDialogPath & "\" & strSelected_ledger_fileName & "_Backup"
                strArchive_receipts_Directory = strArchive_Directory & "\" & strSelected_ledger_fileName & "_Receipts"
                strArchive_budgets_fullFile = strArchive_Directory & "\" & strSelected_ledger_fileName & ".bgt"
                strArchive_ledger_fullFile = strArchive_Directory & "\" & strSelected_ledger_fileName & ".cbk"

                strLastModifiedDate_Backup = System.IO.File.GetLastWriteTime(strArchive_ledger_fullFile)

                Try

                    If My.Computer.FileSystem.DirectoryExists(strArchive_Directory) Then

                        If CheckbookMsg.ShowMessage("A backup folder for '" & strSelected_ledger_fileName & "' already exists in this location", MsgButtons.YesNo, "It was last modified on " & strLastModifiedDate_Backup & vbNewLine & vbNewLine & "Do you want to overwrite it?", Exclamation) = DialogResult.Yes Then

                            'DELETES EXISTING RECEIPTS DIRECTORY
                            My.Computer.FileSystem.DeleteDirectory(strArchive_receipts_Directory, FileIO.DeleteDirectoryOption.DeleteAllContents)

                            'COPIES CURRENT RECEIPTS DIRECTORY AND LEDGER FILE TO BACKUP FOLDER
                            My.Computer.FileSystem.CopyDirectory(AppendReceiptDirectory(strSelected_ledger_fileName), strArchive_receipts_Directory, True)
                            My.Computer.FileSystem.CopyFile(strSelected_ledger_fullFile, strArchive_ledger_fullFile, True) 'COPIES SELECTED FILE FROM STARTUP FOLDER TO BACKUP LOCATION AND OVERWRITES EXISTING

                            If System.IO.File.Exists(strArchive_budgets_fullFile) And System.IO.File.Exists(strBudgets_fullFile) Then

                                My.Computer.FileSystem.DeleteFile(strArchive_budgets_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                                My.Computer.FileSystem.CopyFile(strBudgets_fullFile, strArchive_budgets_fullFile, True)

                            ElseIf Not System.IO.File.Exists(strArchive_budgets_fullFile) And System.IO.File.Exists(strBudgets_fullFile) Then

                                My.Computer.FileSystem.CopyFile(strBudgets_fullFile, strArchive_budgets_fullFile, True)

                            ElseIf System.IO.File.Exists(strArchive_budgets_fullFile) And Not System.IO.File.Exists(strBudgets_fullFile) Then

                                My.Computer.FileSystem.DeleteFile(strArchive_budgets_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)

                            End If

                        End If

                    Else

                        System.IO.Directory.CreateDirectory(strArchive_Directory)

                        'COPIES CURRENT RECEIPTS DIRECTORY AND LEDGER FILE TO BACKUP FOLDER
                        My.Computer.FileSystem.CopyDirectory(AppendReceiptDirectory(strSelected_ledger_fileName), strArchive_receipts_Directory)
                        My.Computer.FileSystem.CopyFile(strSelected_ledger_fullFile, strArchive_ledger_fullFile) 'COPIES SELECTED FILE FROM STARTUP FOLDER TO BACKUP LOCATION AND OVERWRITES EXISTING

                        'COPIES BUDGETS FILE TO BACKUP FOLDER
                        If System.IO.File.Exists(strBudgets_fullFile) Then

                            My.Computer.FileSystem.CopyFile(strBudgets_fullFile, strArchive_budgets_fullFile)

                        End If

                        CheckbookMsg.ShowMessage("A backup folder for '" & strSelected_ledger_fileName & "' has been created", MsgButtons.OK, "")

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Backup Error", MsgButtons.OK, "An error occurred while copying the ledger" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                End Try

            End If

        End If

    End Sub

    Private Sub DeleteLedger()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strDelete_ledger_fullFile As String
        Dim strDelete_budgets_fullFile As String
        Dim strSelected_ledger_fileName As String
        Dim strMessage As String
        Dim strAdvice As String

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("There are no ledgers selected to delete", MsgButtons.OK, "", Exclamation)

        Else

            strSelected_ledger_fileName = dgvMyLedgers.SelectedCells(0).Value

            strAdvice = "The ledger can be restored from the recycle bin." & vbNewLine & vbNewLine &
                            "WARNING: If you are going to restore this ledger from the recycle bin you must restore the receipts folder as well titled " & strSelected_ledger_fileName & "_Receipts."

            If System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) = strSelected_ledger_fileName Then

                strMessage = "The ledger you have selected is currently open. " & "Are you sure you want to delete '" & strSelected_ledger_fileName & "'?"

            Else

                strMessage = "Are you sure you want to delete '" & strSelected_ledger_fileName & "'?"

            End If

            If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strAdvice, Question) = Windows.Forms.DialogResult.Yes Then

                Try

                    If System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) = strSelected_ledger_fileName Then

                        strDelete_ledger_fullFile = AppendLedgerDirectory(strSelected_ledger_fileName)
                        strDelete_budgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strSelected_ledger_fileName & ".bgt"

                        'DELETE LEDGER FILE
                        If System.IO.File.Exists(strDelete_ledger_fullFile) Then

                            My.Computer.FileSystem.DeleteFile(strDelete_ledger_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        End If

                        'DELETE RECEIPT DIRECTORY
                        If System.IO.Directory.Exists(AppendReceiptDirectory(strSelected_ledger_fileName)) Then

                            My.Computer.FileSystem.DeleteDirectory(AppendReceiptDirectory(strSelected_ledger_fileName), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        End If

                        'DELETE BUDGET FILE
                        If System.IO.File.Exists(strDelete_budgets_fullFile) Then

                            My.Computer.FileSystem.DeleteFile(strDelete_budgets_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        End If

                        'RELOADS MYLEDGERS AFTER DELETION OF FILE
                        File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers)

                        'CLEARS DATA FROM DATAGRID IF THE CURRENTLY OPEN FILE WAS THE DELETED FILE
                        MainForm.dgvLedger.DataSource = Nothing
                        MainForm.dgvLedger.Columns.Clear()

                        m_strCurrentFile = ""

                        'ENABLES ALL MENU AND TOOLSTRIP ITEMS IF STRFILE IS NOT EMPTY
                        UIManager.Maintain_DisabledMainFormUI()

                    Else

                        strDelete_ledger_fullFile = AppendLedgerDirectory(strSelected_ledger_fileName)
                        strDelete_budgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strSelected_ledger_fileName & ".bgt"

                        'DELETE LEDGER FILE
                        If System.IO.File.Exists(strDelete_ledger_fullFile) Then

                            My.Computer.FileSystem.DeleteFile(strDelete_ledger_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        End If

                        'DELETE RECEIPT DIRECTORY
                        If System.IO.Directory.Exists(AppendReceiptDirectory(strSelected_ledger_fileName)) Then

                            My.Computer.FileSystem.DeleteDirectory(AppendReceiptDirectory(strSelected_ledger_fileName), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        End If

                        'DELETE BUDGET FILE
                        If System.IO.File.Exists(strDelete_budgets_fullFile) Then

                            My.Computer.FileSystem.DeleteFile(strDelete_budgets_fullFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        End If

                        'RELOADS MYLEDGERS AFTER DELETION OF FILE
                        File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers)

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Delete Error", MsgButtons.OK, "An error occurred while deleting the ledger" & vbNewLine & vbNewLine & ex.Message, Exclamation)


                Finally

                    File.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

                End Try

            End If

        End If

    End Sub

    Private Sub CreateDirectoryWatcher()

        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        watcher.Path = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers"
        watcher.Filter = "*.cbk"

        AddHandler watcher.Created, AddressOf FileAdded

        watcher.EnableRaisingEvents = True

    End Sub

    Private Sub FileAdded(source As Object, e As FileSystemEventArgs)

        BeginInvoke(New Action(Sub()

                                   dgvMyLedgers.SuspendLayout()

                                   File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers)

                                   dgvMyLedgers.ResumeLayout()

                               End Sub))

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Help.ShowHelp(Me, m_helpProvider.HelpNamespace, "ledger_manager.html")

    End Sub

End Class