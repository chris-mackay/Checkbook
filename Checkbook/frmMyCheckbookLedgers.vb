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
Imports System.IO

Public Class frmMyCheckbookLedgers

    Inherits Form

    Public caller_frmNewFileFromMenu As frmNewCheckbookLedger
    Private File As New clsLedgerDBFileManager
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager

    Private Sub dgvMyLedgers_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvMyLedgers.KeyDown

        Select Case e.KeyCode
            Case Keys.Delete
                DeleteLedger()
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click, dgvMyLedgers.DoubleClick

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strSelectedName As String = String.Empty

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There is no ledger selected to open", MsgButtons.OK, "", Exclamation)

        Else

            strSelectedName = dgvMyLedgers.SelectedCells(0).Value.ToString

            Dim strLedgerPath As String = String.Empty
            strLedgerPath = AppendLedgerPath(strSelectedName)

            m_strCurrentFile = strLedgerPath

            CreateLedgerDirectories(strSelectedName)
            CreateLedgerSettings_SetDefaults(strSelectedName)
            MainForm.LoadButtonSettings_Or_CreateDefaultButtons()

            Try

                Me.Dispose()
                MainForm.Activate()

                MainForm.Text = "Checkbook - " & strSelectedName

                UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery)
                FileCon.Fill_Format_LedgerData_DataGrid()
                FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                DataCon.LedgerStatus()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Open Error", MsgButtons.OK, "An error occurred while opening the ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                FileCon.Close()
                UIManager.SetCursor(MainForm, Cursors.Default)
                UIManager.Maintain_DisabledMainFormUI()
                MainForm.dgvLedger.ClearSelection()
                UIManager.UpdateStatusStripInfo()

            End Try

        End If

    End Sub

    Private Sub frmMyCheckbookLedgers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim colorRenderer_Professional As New clsUIManager.MyProfessionalRenderer
        cxmnuManageLedgers.Renderer = colorRenderer_Professional

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
        Dim lstLedgerManagerControls As New List(Of Control)

        lstLedgerManagerControls.Add(btnDelete)
        lstLedgerManagerControls.Add(btnRename)
        lstLedgerManagerControls.Add(btnCopy)
        lstLedgerManagerControls.Add(btnRestore)
        lstLedgerManagerControls.Add(dgvMyLedgers)
        lstLedgerManagerControls.Add(btnOpen)
        lstLedgerManagerControls.Add(btnClose)

        DrawingControl.SetDoubleBuffered_ListControls(lstLedgerManagerControls)
        DrawingControl.SuspendDrawing_ListControls(lstLedgerManagerControls)

        Dim intRowCount As Integer = 0

        Try

            LoadMyCheckbookLedgersIntoDataGridView()
            intRowCount = dgvMyLedgers.Rows.Count

            dgvMyLedgers.ClearSelection()

        Catch exFileNotFound As System.IO.DirectoryNotFoundException

            CheckbookMsg.ShowMessage("Load Ledger Error", MsgButtons.OK, "'My Checkbook Ledgers' could not be found." & vbNewLine & "It may have been deleted or moved!", Exclamation)
            Me.Dispose()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Load Ledger Error", MsgButtons.OK, "An error occurred while loading 'My Checkbook Ledgers'" & vbNewLine & vbNewLine & ex.Message, Exclamation)
            Me.Dispose()

        End Try

        DrawingControl.ResumeDrawing_ListControls(lstLedgerManagerControls)

        If intRowCount = 0 Then

            btnOpen.Enabled = False

        Else

            btnOpen.Enabled = True

        End If

        dgvMyLedgers.ClearSelection()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, cxmnuDeleteLedger.Click

        DeleteLedger()

    End Sub

#Region "Manage Ledgers"

    Private Sub btnNewLedger_Click(sender As Object, e As EventArgs) Handles btnNewLedger.Click, cxmnuNewLedger.Click

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

                    CreateLedgerDirectories(strNewLedgerName)

                    File.CreateNewLedger_AccessDatabase(strNewLedgerPath)

                    CreateLedgerSettings_SetDefaults(strNewLedgerPath)

                    FileCon.ConnectMenu(strNewLedgerPath)
                    FileCon.SQLinsert("INSERT INTO StartBalance (Balance) VALUES('" & strStartBalance & "')")
                    FileCon.Close()

                    LoadMyCheckbookLedgersIntoDataGridView()

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Create New Error", MsgButtons.OK, "An error occurred while creating the new ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                End Try

            End If

        End If

    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click, cxmnuRestoreLedger.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strFolderDialogPath As String = String.Empty
        Dim fd As New FolderBrowserDialog
        Dim strSelectedLedgerName As String = String.Empty
        Dim strLastModifiedDate_Backup As String = String.Empty
        Dim strLastModifiedDate_Current As String = String.Empty

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no ledgers selected to restore", MsgButtons.OK, "", Exclamation)

        Else

            strSelectedLedgerName = dgvMyLedgers.SelectedCells(0).Value.ToString

            Dim strLedgerDirectory As String = String.Empty
            strLedgerDirectory = AppendLedgerDirectory(strSelectedLedgerName)

            fd.ShowNewFolderButton = True
            fd.Description = "Select a folder named '" & strSelectedLedgerName & "_Backup' to restore the ledger."

            If IO.File.Exists(GetLedgerSettingsFile(strSelectedLedgerName)) Then

                If GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory, strSelectedLedgerName) = String.Empty Then

                    fd.RootFolder = Environment.SpecialFolder.Desktop
                    fd.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

                Else

                    fd.RootFolder = Environment.SpecialFolder.Desktop
                    fd.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory, strSelectedLedgerName)

                End If

            Else

                fd.RootFolder = Environment.SpecialFolder.Desktop

            End If

            If fd.ShowDialog = Windows.Forms.DialogResult.OK Then

                strFolderDialogPath = fd.SelectedPath
                Dim strArchivedCheckbookLedger As String = String.Empty
                strArchivedCheckbookLedger = AppendFileName(strFolderDialogPath, strSelectedLedgerName & ".cbk")

                strLastModifiedDate_Backup = IO.File.GetLastWriteTime(strArchivedCheckbookLedger)
                strLastModifiedDate_Current = IO.File.GetLastWriteTime(AppendLedgerPath(strSelectedLedgerName))

                Try

                    If CheckbookMsg.ShowMessage("Are you sure you want to restore '" & strSelectedLedgerName & "'?", MsgButtons.YesNo, "'" & strSelectedLedgerName & "' was last modified on " & strLastModifiedDate_Current & vbNewLine & vbNewLine & "The selected backup ledger was last modified on " & strLastModifiedDate_Backup, Question) = DialogResult.Yes Then

                        My.Computer.FileSystem.DeleteDirectory(strLedgerDirectory, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        My.Computer.FileSystem.CreateDirectory(strLedgerDirectory)
                        My.Computer.FileSystem.CopyDirectory(strFolderDialogPath, strLedgerDirectory, True)

                        If strSelectedLedgerName = Path.GetFileNameWithoutExtension(m_strCurrentFile) Then

                            File.OpenFilefromBackup()

                            CheckbookMsg.ShowMessage("'" & strSelectedLedgerName & "' has been successfully restored.", MsgButtons.OK, "")

                            LoadMyCheckbookLedgersIntoDataGridView()

                        Else

                            CheckbookMsg.ShowMessage("'" & strSelectedLedgerName & "' has been successfully restored.", MsgButtons.OK, "")

                        End If

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Restore Error", MsgButtons.OK, "An error occurred while restoring the ledger" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                End Try

            End If

        End If

    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click, cxmnuRenameLedger.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("There are no ledgers selected to rename", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmRename As New frmRename
            Dim strPreviousLedgerName As String = String.Empty

            strPreviousLedgerName = dgvMyLedgers.SelectedCells(0).Value.ToString

            new_frmRename.Text = "Rename Ledger"
            new_frmRename.txtPrevious.BackColor = Color.White
            new_frmRename.txtPrevious.Text = strPreviousLedgerName
            new_frmRename.txtRename.Text = strPreviousLedgerName

            new_frmRename.txtRename.SelectAll()

            If new_frmRename.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim strNewLedgerName As String = String.Empty
                strNewLedgerName = new_frmRename.txtRename.Text

                If strPreviousLedgerName = strNewLedgerName Then

                    CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The filename you entered is the same as the original, please enter a unique filename.", Exclamation)

                ElseIf System.IO.File.Exists(AppendLedgerPath(strNewLedgerName)) Then

                    CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The ledger '" & strNewLedgerName & "' already exists. Provide a unique name for your ledger.", Exclamation)

                ElseIf CheckbookMsg.ShowMessage("Are you sure you want to rename '" & strPreviousLedgerName & "' to '" & strNewLedgerName & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        Dim path As String = AppendLedgerDirectory(strPreviousLedgerName)

                        RenameAllFilesInLedgerDirectory(strPreviousLedgerName, strNewLedgerName)
                        My.Computer.FileSystem.RenameDirectory(path, strNewLedgerName)

                        LoadMyCheckbookLedgersIntoDataGridView()

                        m_strCurrentFile = AppendLedgerPath(strNewLedgerName)
                        MainForm.Text = "Checkbook - " & strNewLedgerName

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Rename Ledger Error", MsgButtons.OK, "An error occurred while renaming the ledger." & vbNewLine & vbNewLine & ex.Message, Exclamation)
                        Exit Sub

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click, cxmnuBackupLedger.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strFolderDialogPath As String = String.Empty
        Dim strLastModifiedDate_Backup As String = String.Empty
        Dim fd As New FolderBrowserDialog
        Dim strSelectedLedgerName As String = String.Empty

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no ledgers selected to backup", MsgButtons.OK, "", Exclamation)

        Else

            strSelectedLedgerName = dgvMyLedgers.SelectedCells(0).Value.ToString

            Dim strLedgerDirectory As String = String.Empty
            strLedgerDirectory = AppendLedgerDirectory(strSelectedLedgerName)

            fd.ShowNewFolderButton = True
            fd.Description = "Select a location to create a backup folder for '" & strSelectedLedgerName & "'"

            If IO.File.Exists(GetLedgerSettingsFile(strSelectedLedgerName)) Then

                If GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory, strSelectedLedgerName) = String.Empty Then

                    fd.RootFolder = Environment.SpecialFolder.Desktop
                    fd.SelectedPath = My.Computer.FileSystem.SpecialDirectories.Desktop

                Else

                    fd.RootFolder = Environment.SpecialFolder.Desktop
                    fd.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory, strSelectedLedgerName)

                End If

            Else

                fd.RootFolder = Environment.SpecialFolder.Desktop

            End If

            If fd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Try

                    strFolderDialogPath = fd.SelectedPath
                    Dim strArchivedCheckbookLedger As String = String.Empty

                    strArchivedCheckbookLedger = AppendDirectory(strFolderDialogPath, strSelectedLedgerName & "_Backup")

                    strLastModifiedDate_Backup = System.IO.File.GetLastWriteTime(strArchivedCheckbookLedger)

                    If My.Computer.FileSystem.DirectoryExists(strArchivedCheckbookLedger) Then

                        If CheckbookMsg.ShowMessage("A backup folder for '" & strSelectedLedgerName & "' already exists in this location", MsgButtons.YesNo, "It was last modified on " & strLastModifiedDate_Backup & vbNewLine & vbNewLine & "Do you want to overwrite it?", Exclamation) = DialogResult.Yes Then

                            My.Computer.FileSystem.DeleteDirectory(strArchivedCheckbookLedger, FileIO.DeleteDirectoryOption.DeleteAllContents)
                            My.Computer.FileSystem.CreateDirectory(strArchivedCheckbookLedger)
                            My.Computer.FileSystem.CopyDirectory(strLedgerDirectory, strArchivedCheckbookLedger, True)
                            CheckbookMsg.ShowMessage("The backup folder for '" & strSelectedLedgerName & "' was overwritten successfully", MsgButtons.OK, "")

                        End If

                    Else

                        My.Computer.FileSystem.CreateDirectory(strArchivedCheckbookLedger)
                        My.Computer.FileSystem.CopyDirectory(strLedgerDirectory, strArchivedCheckbookLedger, True)
                        CheckbookMsg.ShowMessage("A backup folder for '" & strSelectedLedgerName & "' has been created", MsgButtons.OK, "")

                    End If

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Backup Error", MsgButtons.OK, "An error occurred while copying the ledger" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                End Try

            End If

        End If

    End Sub

    Private Sub DeleteLedger()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        Dim strSelectedLedgerName As String = String.Empty
        Dim strAdvice As String = String.Empty
        Dim strMessage As String = String.Empty

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no ledgers selected to delete", MsgButtons.OK, "", Exclamation)

        Else

            strSelectedLedgerName = dgvMyLedgers.SelectedCells(0).Value

            strAdvice = "The ledger can be restored from the recycle bin"

            If Path.GetFileNameWithoutExtension(m_strCurrentFile) = strSelectedLedgerName Then

                strMessage = "The ledger you have selected is currently open. " & "Are you sure you want to delete '" & strSelectedLedgerName & "'?"

            Else

                strMessage = "Are you sure you want to delete '" & strSelectedLedgerName & "'?"

            End If

            If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strAdvice, Question) = Windows.Forms.DialogResult.Yes Then

                If Path.GetFileNameWithoutExtension(m_strCurrentFile) = strSelectedLedgerName Then

                    Try

                        My.Computer.FileSystem.DeleteDirectory(AppendLedgerDirectory(strSelectedLedgerName), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        LoadMyCheckbookLedgersIntoDataGridView()

                        MainForm.dgvLedger.DataSource = Nothing
                        MainForm.dgvLedger.Columns.Clear()

                        m_strCurrentFile = String.Empty

                        UIManager.Maintain_DisabledMainFormUI()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Delete Error", MsgButtons.OK, "An error occurred while deleting the ledger" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                    End Try

                Else

                    Try

                        My.Computer.FileSystem.DeleteDirectory(AppendLedgerDirectory(strSelectedLedgerName), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)

                        LoadMyCheckbookLedgersIntoDataGridView()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Delete Error", MsgButtons.OK, "An error occurred while deleting the ledger" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub LoadMyCheckbookLedgersIntoDataGridView()

        dgvMyLedgers.Rows.Clear()

        Dim strMyCheckbookLedgersDirectory As String = String.Empty
        strMyCheckbookLedgersDirectory = AppendDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "My Checkbook Ledgers")

        For Each Dir As String In IO.Directory.GetDirectories(strMyCheckbookLedgersDirectory)

            Dim dirInfo As New IO.DirectoryInfo(Dir)

            Dim strCheckbookLedger As String = String.Empty
            strCheckbookLedger = AppendLedgerPath(dirInfo.Name)

            Dim dtLastWriteTime As DateTime = Nothing
            dtLastWriteTime = System.IO.File.GetLastWriteTime(strCheckbookLedger)

            dgvMyLedgers.Rows.Add(dirInfo.Name, dtLastWriteTime)

        Next

        dgvMyLedgers.ClearSelection()

    End Sub

#End Region

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/my_checkbook_ledgers.html"
        Process.Start(strWebAddress)

    End Sub

End Class