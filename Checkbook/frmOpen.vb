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

Public Class frmOpen

    Inherits System.Windows.Forms.Form

    'NEW INSTANCES OF CLASSES
    Private File As New clsLedgerDBFileManager
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager
    Private intTimeToTrackBeforShowingUnknown_Uncategorized_Messge As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Dispose()

    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click, dgvMyLedgers.DoubleClick

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strSelected_fileName As String

        Dim intSelectedRowCount As Integer
        intSelectedRowCount = dgvMyLedgers.SelectedRows.Count

        If intSelectedRowCount < 1 Then 'CHECKS WHETHER ANY ITEMS ARE SELECTED

            CheckbookMsg.ShowMessage("Select a ledger from the list then click 'Open'", MsgButtons.OK, "", Exclamation)

        Else

            intTimeToTrackBeforShowingUnknown_Uncategorized_Messge = 0

            strSelected_fileName = dgvMyLedgers.SelectedCells(0).Value.ToString

            Dim strLedgerToOpen_fullFile As String
            strLedgerToOpen_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & strSelected_fileName & ".cbk"

            m_strCurrentFile = strLedgerToOpen_fullFile

            Try

                Me.Dispose()

                'SETS APPLICATION TITLE
                MainForm.Text = "Checkbook - " & strSelected_fileName

                UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery)
                FileCon.Fill_Format_DataGrid()
                FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
                DataCon.LedgerStatus()

                'STARTS THE TIMER ON FRMOPEN
                tmrTimer.Start()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Open Error", MsgButtons.OK, "An error occurred while opening the ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                'CLOSES THE DATABASE
                FileCon.Close()

                UIManager.SetCursor(MainForm, Cursors.Default)

                'ENABLES ALL MENU AND TOOLSTRIP ITEMS IF STRFILE IS NOT EMPTY
                UIManager.Maintain_DisabledMainFormUI()

                MainForm.dgvLedger.ClearSelection()

                UIManager.UpdateStatusStripInfo()

            End Try

        End If

    End Sub

    Private Sub frmOpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        With Me.dgvMyLedgers

            'SETS DATAGRID COLORS BASED ON USER SETTTINGS
            .GridColor = My.Settings.GridColor
            .AlternatingRowsDefaultCellStyle.BackColor = My.Settings.AlternatingRowColor
            .DefaultCellStyle.SelectionBackColor = My.Settings.RowHighlightColor

        End With

        Dim intRowCount As Integer

        Try

            File.LoadMyCheckbookLedgers_IntoDataGridView(dgvMyLedgers) 'LOADS LEDGERS INTO DATAGRIDVIEW
            intRowCount = dgvMyLedgers.Rows.Count 'COUNTS NUMBER OF ROWS IN DATAGRIDVIEW

            dgvMyLedgers.ClearSelection()

        Catch exFileNotFound As System.IO.DirectoryNotFoundException

            CheckbookMsg.ShowMessage("Load Ledger Error", MsgButtons.OK, "'My Checkbook Ledgers' could not be found." & vbNewLine & "It may have been deleted or moved!", Exclamation)
            Me.Dispose()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Load Ledger Error", MsgButtons.OK, "An error occurred while loading 'My Checkbook Ledgers'" & vbNewLine & vbNewLine & ex.Message, Exclamation)
            Me.Dispose()

        End Try

        If intRowCount = 0 Then

            btnOpen.Enabled = False

        Else

            btnOpen.Enabled = True

        End If

    End Sub

    Private Sub tmrTimer_Tick(sender As Object, e As EventArgs) Handles tmrTimer.Tick

        intTimeToTrackBeforShowingUnknown_Uncategorized_Messge += 1

        If intTimeToTrackBeforShowingUnknown_Uncategorized_Messge = 1 Then

            DataCon.Show_Uncategorized_Unknown_Message_FromOpen()
            tmrTimer.Stop()

        End If

    End Sub

End Class