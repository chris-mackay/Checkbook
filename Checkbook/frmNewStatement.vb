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

Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds

Public Class frmNewStatement

    'NEW INSTANCES OF CLASSES
    Private DataCon As New clsLedgerDataManager
    Public FileCon As New clsLedgerDBConnector

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnViewStatement_MouseHover(sender As Object, e As EventArgs) Handles btnViewStatement.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnViewStatement, "View Statement")

    End Sub

    Private Sub btnAddStatement_MouseHover(sender As Object, e As EventArgs) Handles btnAddStatement.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnAddStatement, "Add Statement")

    End Sub

    Private Sub btnRemoveStatement_MouseHover(sender As Object, e As EventArgs) Handles btnRemoveStatement.MouseHover

        Dim tpToolTip As New ToolTip
        tpToolTip.SetToolTip(btnRemoveStatement, "Remove Statement")

    End Sub

    Private Sub btnAddStatement_Click(sender As Object, e As EventArgs) Handles btnAddStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If Not Me.txtStatementFile.Text = String.Empty Then

            CheckbookMsg.ShowMessage("There is already a file associated with this statement", MsgButtons.OK, "Remove the current file if you wish to replace it", Exclamation)

        Else

            DataCon.AddStatement()

        End If

    End Sub

    Private Sub frmNewStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataCon.caller_frmNewStatement = Me

        txtStatementName.Text = ""
        txtStatementFile.Text = ""

        btnCreate.Enabled = False

        txtStatementName.Focus()

    End Sub

    Private Sub btnRemoveStatement_Click(sender As Object, e As EventArgs) Handles btnRemoveStatement.Click

        txtStatementFile.Text = ""

    End Sub

    Private Sub btnViewStatement_Click(sender As Object, e As EventArgs) Handles btnViewStatement.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strStatementFile As String

        strStatementFile = Me.txtStatementFile.Text

        If strStatementFile = String.Empty Then

            CheckbookMsg.ShowMessage("This statement does not have a file attached", MsgButtons.OK, "", Exclamation)

        ElseIf Not m_strOriginalStatementToCopy = String.Empty Then

            'CHECK IF FILE EXISTS
            If Not My.Computer.FileSystem.FileExists(m_strOriginalStatementToCopy) Then

                CheckbookMsg.ShowMessage("The file for this statement does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

            Else

                Process.Start(m_strOriginalStatementToCopy)

            End If

        Else

            'CHECK IF FILE EXISTS
            Dim strStatement As String = String.Empty
            strStatement = AppendStatementDirectoryAndStatementFile(m_strCurrentFile, strStatementFile)

            If Not My.Computer.FileSystem.FileExists(m_strOriginalStatementToCopy) Then

                CheckbookMsg.ShowMessage("The file for this statement does not exist. It has been moved or deleted. Check the recycle bin and restore it if it exists. You may need to find another copy and re-attach.", MsgButtons.OK, "", Exclamation)

            Else

                Process.Start(strStatement)

            End If

        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim newStatement As New clsTransaction
        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strStatementName As String = String.Empty
        Dim strStatementFileName As String = String.Empty

        strStatementName = txtStatementName.Text
        strStatementFileName = txtStatementFile.Text

        newStatement.StatementName = strStatementName
        newStatement.StatementFileName = strStatementFileName

        Me.Dispose()

        Try

            FileCon.Connect()

            FileCon.SQLinsert("INSERT INTO Statements (StatementName,StatementFileName) VALUES ('" & newStatement.StatementName & "','" & newStatement.StatementFileName & "')")
            FileCon.Fill_Format_Statements_DataGrid()
            FileCon.Close()

            Dim strCopyofStatement As String

            strCopyofStatement = AppendStatementDirectoryAndStatementFile(m_strCurrentFile, newStatement.StatementFileName)

            If Not strCopyofStatement = String.Empty Then

                My.Computer.FileSystem.CopyFile(m_strOriginalStatementToCopy, strCopyofStatement, True)

            End If

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Statement Error", MsgButtons.OK, "An error occurred while creating the statement" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

        Finally

            FileCon.Close()
            Me.Dispose()

        End Try

    End Sub

    Private Sub txtStatementName_TextChanged(sender As Object, e As EventArgs) Handles txtStatementName.TextChanged

        If Len(txtStatementName.Text) = 0 Or Len(txtStatementFile.Text) = 0 Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub txtStatementFile_TextChanged(sender As Object, e As EventArgs) Handles txtStatementFile.TextChanged

        If Len(txtStatementName.Text) = 0 Or Len(txtStatementFile.Text) = 0 Then

            btnCreate.Enabled = False

        Else

            btnCreate.Enabled = True

        End If

    End Sub

    Private Sub frmNewStatement_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked

        Dim webAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/statements.html"
        Process.Start(webAddress)

    End Sub

End Class