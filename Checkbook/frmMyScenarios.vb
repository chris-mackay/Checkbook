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

Imports System.IO
Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds

Public Class frmMyScenarios

    Private File As New clsLedgerDBFileManager
    Public caller_frmSpendingOverview As frmSpendingOverview

    Private Sub frmScenarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim colorRenderer_Professional As New clsUIManager.MyProfessionalRenderer

        cxmnuManageScenarios.Renderer = colorRenderer_Professional

        Dim lstScenarioManagerControls As New List(Of Control)

        lstScenarioManagerControls.Add(btnDelete)
        lstScenarioManagerControls.Add(btnRename)
        lstScenarioManagerControls.Add(btnOpen)
        lstScenarioManagerControls.Add(btnClose)

        DrawingControl.SetDoubleBuffered_ListControls(lstScenarioManagerControls)
        DrawingControl.SuspendDrawing_ListControls(lstScenarioManagerControls)

        If caller_frmSpendingOverview.strCurrentScenarioName = String.Empty Then

            btnDelete.Enabled = True
            btnRename.Enabled = True
            btnDuplicateScenario.Enabled = True
            btnCopyYear.Enabled = True
            cxmnuManageScenarios.Enabled = True

        Else

            btnDelete.Enabled = False
            btnRename.Enabled = False
            btnDuplicateScenario.Enabled = False
            btnCopyYear.Enabled = False
            cxmnuManageScenarios.Enabled = False

        End If

        LoadMyScenarios()

        Dim intRowCount As Integer = 0
        intRowCount = dgvMyScenarios.Rows.Count

        If intRowCount = 0 Then btnOpen.Enabled = False Else btnOpen.Enabled = True

        DrawingControl.ResumeDrawing_ListControls(lstScenarioManagerControls)

        dgvMyScenarios.ClearSelection()

    End Sub

    Private Function YearList(ByVal _ScenarioDirectory As String) As List(Of String)

        Dim lst As List(Of String) = New List(Of String)

        For Each Dir As String In Directory.GetDirectories(_ScenarioDirectory)
            Dim dirInfo As New DirectoryInfo(Dir)
            lst.Add(dirInfo.Name)
        Next

        Return lst
    End Function

    Private Sub LoadMyScenarios()

        Dim dtLastWriteTime As DateTime = Nothing
        Dim strCurrentFile As String = String.Empty
        strCurrentFile = Path.GetFileNameWithoutExtension(m_strCurrentFile)

        Dim strScenarioDirectory As String = String.Empty
        strScenarioDirectory = AppendDirectory(AppendLedgerDirectory(strCurrentFile), "Scenarios")

        dgvMyScenarios.Rows.Clear()

        For Each dir As String In Directory.GetDirectories(strScenarioDirectory)

            Dim dInfo As New DirectoryInfo(dir)
            Dim f = Directory.GetFiles(dir, "*CategoryTableScenario.whf", SearchOption.AllDirectories).OrderByDescending(Function(fi) New FileInfo(fi).LastWriteTime).First()

            Dim fInfo As New FileInfo(f)
            dgvMyScenarios.Rows.Add(dInfo.Name, "Year (" & fInfo.Directory.Name & ") - " & fInfo.LastWriteTime)

        Next

        If dgvMyScenarios.Rows.Count <= 1 Then

            btnCopyYear.Enabled = False
            cxmnuCopyYear.Enabled = False

        Else

            btnCopyYear.Enabled = True
            cxmnuCopyYear.Enabled = True

        End If

        dgvMyScenarios.ClearSelection()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, cxmnuDeleteScenario.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyScenarios.SelectedRows.Count

        Dim strSelectedScenarioName As String = String.Empty
        Dim strAdvice As String = String.Empty
        Dim strMessage As String = String.Empty

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no scenarios selected to delete", MsgButtons.OK, "", Exclamation)

        Else

            strSelectedScenarioName = dgvMyScenarios.SelectedCells(0).Value

            strAdvice = "The scenario can be restored from the recycle bin"

            If caller_frmSpendingOverview.strCurrentScenarioName = strSelectedScenarioName Then

                strMessage = "The scenario you have selected Is currently open. " & "Are you sure you want to delete '" & strSelectedScenarioName & "'?"

            Else

                strMessage = "Are you sure you want to delete '" & strSelectedScenarioName & "'?"

            End If

            If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strAdvice, Question) = Windows.Forms.DialogResult.Yes Then

                If caller_frmSpendingOverview.strCurrentScenarioName = strSelectedScenarioName Then

                    Try

                        My.Computer.FileSystem.DeleteDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strSelectedScenarioName), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                        LoadMyScenarios()
                        Call caller_frmSpendingOverview.ResetSpendingOverview()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Delete Error", MsgButtons.OK, "An error occurred while deleting the scenario" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                    End Try

                Else

                    Try

                        My.Computer.FileSystem.DeleteDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strSelectedScenarioName), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                        LoadMyScenarios()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Delete Error", MsgButtons.OK, "An error occurred while deleting the scenario" & vbNewLine & vbNewLine & ex.Message, Exclamation)

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click, cxmnuRenameScenario.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyScenarios.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no scenarios selected to rename", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmRename As New frmRename
            Dim strPreviousScenarioName As String = String.Empty

            strPreviousScenarioName = dgvMyScenarios.SelectedCells(0).Value.ToString

            new_frmRename.Text = "Rename Scenario"
            new_frmRename.txtPrevious.BackColor = Color.White
            new_frmRename.txtPrevious.Text = strPreviousScenarioName
            new_frmRename.txtRename.Text = strPreviousScenarioName

            new_frmRename.txtRename.SelectAll()

            If new_frmRename.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim strNewScenarioName As String = String.Empty
                strNewScenarioName = new_frmRename.txtRename.Text

                If strPreviousScenarioName = strNewScenarioName Then

                    CheckbookMsg.ShowMessage("Name Conflict", MsgButtons.OK, "The name you entered is the same as the original, please enter a unique name.", Exclamation)

                ElseIf System.IO.Directory.Exists(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strNewScenarioName)) Then

                    CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The scenario '" & strNewScenarioName & "' already exists. Provide a unique name for your scenario.", Exclamation)

                ElseIf CheckbookMsg.ShowMessage("Are you sure you want to rename '" & strPreviousScenarioName & "' to '" & strNewScenarioName & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        Dim path As String = AppendScenarioPath(System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile), strPreviousScenarioName)

                        My.Computer.FileSystem.RenameDirectory(path, new_frmRename.txtRename.Text)

                        LoadMyScenarios()

                        If Not caller_frmSpendingOverview.strCurrentScenarioName = String.Empty Then
                            caller_frmSpendingOverview.lblScenario.Text = "Scenario: " & strNewScenarioName
                        End If

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Rename Scenario Error", MsgButtons.OK, "An error occurred while renaming the scenario." & vbNewLine & vbNewLine & ex.Message, Exclamation)
                        Exit Sub

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub btnDuplicateScenario_Click(sender As Object, e As EventArgs) Handles btnDuplicateScenario.Click, cxmnuDuplicateScenario.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyScenarios.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no scenarios selected to duplicate", MsgButtons.OK, "", Exclamation)

        Else

            Dim strSelectedScenarioName As String = String.Empty

            Dim new_frmCreate As New frmCreate
            new_frmCreate.Icon = My.Resources.duplicate_scenario
            new_frmCreate.Text = "Duplicate Scenario"

            strSelectedScenarioName = dgvMyScenarios.SelectedCells(0).Value.ToString

            If new_frmCreate.ShowDialog = DialogResult.OK Then

                Dim strNewScenarioName As String = String.Empty
                strNewScenarioName = new_frmCreate.txtEnter.Text

                If System.IO.Directory.Exists(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strNewScenarioName)) Then

                    CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The scenario '" & strNewScenarioName & "' already exists. Provide a unique name for your scenario.", Exclamation)

                Else

                    Try

                        Dim strScenarioToCopy As String = String.Empty
                        Dim strScenarioToCreate As String = String.Empty

                        strScenarioToCopy = AppendScenarioPath(System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile), strSelectedScenarioName)
                        strScenarioToCreate = AppendScenarioPath(System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile), strNewScenarioName)

                        My.Computer.FileSystem.CopyDirectory(strScenarioToCopy, strScenarioToCreate)

                        LoadMyScenarios()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Duplicate Scenario Error", MsgButtons.OK, "An error occurred while duplicating the scenario." & vbNewLine & vbNewLine & ex.Message, Exclamation)
                        Exit Sub

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub btnCopyYear_Click(sender As Object, e As EventArgs) Handles btnCopyYear.Click, cxmnuCopyYear.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim intSelectedRowCount As Integer = 0
        intSelectedRowCount = dgvMyScenarios.SelectedRows.Count

        If intSelectedRowCount < 1 Then

            CheckbookMsg.ShowMessage("There are no scenarios selected to copy from", MsgButtons.OK, "", Exclamation)

        Else

            Dim strSelectedScenarioToCopyFrom As String = String.Empty
            Dim new_frmCopyScenarioYear As New frmCopyScenarioYear

            strSelectedScenarioToCopyFrom = dgvMyScenarios.SelectedCells(0).Value.ToString

            new_frmCopyScenarioYear.Text = "Copy Year From " & strSelectedScenarioToCopyFrom

            LoadScenarioYears(strSelectedScenarioToCopyFrom, new_frmCopyScenarioYear.cbYears)
            LoadScenarios(new_frmCopyScenarioYear.cbScenario)
            new_frmCopyScenarioYear.cbScenario.Items.Remove(strSelectedScenarioToCopyFrom)

            If new_frmCopyScenarioYear.ShowDialog() = DialogResult.OK Then

                Dim strSelectedYearToCopy As String = String.Empty
                Dim strSelectedScenarioToCopyTo As String = String.Empty

                strSelectedYearToCopy = new_frmCopyScenarioYear.cbYears.SelectedItem.ToString
                strSelectedScenarioToCopyTo = new_frmCopyScenarioYear.cbScenario.SelectedItem.ToString

                Dim strDirectoryToCopyFrom As String = String.Empty
                strDirectoryToCopyFrom = AppendDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strSelectedScenarioToCopyFrom), strSelectedYearToCopy)

                Dim strDirectoryToCopyTo As String = String.Empty
                strDirectoryToCopyTo = AppendDirectory(AppendScenarioPath(Path.GetFileNameWithoutExtension(m_strCurrentFile), strSelectedScenarioToCopyTo), strSelectedYearToCopy)

                If Directory.Exists(strDirectoryToCopyTo) Then

                    If CheckbookMsg.ShowMessage(strSelectedYearToCopy & " already exists in " & strSelectedScenarioToCopyTo, MsgButtons.YesNo, "Do you want to overwrite " & strSelectedYearToCopy & "?", Exclamation) = DialogResult.Yes Then

                        Try

                            My.Computer.FileSystem.CopyDirectory(strDirectoryToCopyFrom, strDirectoryToCopyTo, True)
                            CheckbookMsg.ShowMessage(strSelectedYearToCopy & " was copied into " & strSelectedScenarioToCopyTo & " successfully", MsgButtons.OK, "", Exclamation)
                            LoadMyScenarios()

                        Catch ex As Exception

                            CheckbookMsg.ShowMessage("Copy Year Error", MsgButtons.OK, "An error occurred while copying the year." & vbNewLine & vbNewLine & ex.Message, Exclamation)

                            Exit Sub

                        End Try

                    End If

                Else

                    Try

                        My.Computer.FileSystem.CopyDirectory(strDirectoryToCopyFrom, strDirectoryToCopyTo, True)
                        CheckbookMsg.ShowMessage(strSelectedYearToCopy & " was copied into " & strSelectedScenarioToCopyTo & " successfully", MsgButtons.OK, "", Exclamation)
                        LoadMyScenarios()

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Copy Year Error", MsgButtons.OK, "An error occurred while copying the year." & vbNewLine & vbNewLine & ex.Message, Exclamation)
                        Exit Sub

                    End Try

                End If

            End If

        End If

    End Sub

    Private Sub LoadScenarioYears(ByVal _ScenarioName As String, ByVal _ComboBox As ComboBox)

        Dim strCurrentFile As String = String.Empty
        strCurrentFile = Path.GetFileNameWithoutExtension(m_strCurrentFile)

        Dim strScenarioDirectory As String = String.Empty
        strScenarioDirectory = AppendDirectory(AppendLedgerDirectory(strCurrentFile), "Scenarios")

        Dim strYearsDirectory As String = String.Empty
        strYearsDirectory = AppendDirectory(strScenarioDirectory, _ScenarioName)

        _ComboBox.Items.Clear()

        For Each dir As String In Directory.GetDirectories(strYearsDirectory)

            Dim dInfo As New DirectoryInfo(dir)
            _ComboBox.Items.Add(dInfo.Name)

        Next

    End Sub

    Private Sub LoadScenarios(ByVal _ComboBox As ComboBox)

        Dim strCurrentFile As String = String.Empty
        strCurrentFile = Path.GetFileNameWithoutExtension(m_strCurrentFile)

        Dim strScenarioDirectory As String = String.Empty
        strScenarioDirectory = AppendDirectory(AppendLedgerDirectory(strCurrentFile), "Scenarios")

        _ComboBox.Items.Clear()

        For Each dir As String In Directory.GetDirectories(strScenarioDirectory)

            Dim dInfo As New DirectoryInfo(dir)
            _ComboBox.Items.Add(dInfo.Name)

        Next

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/my_scenarios.html"
        Process.Start(strWebAddress)

    End Sub

End Class