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

Public Class frmCategory

    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private NewCategory As New clsTransaction
    Private UIManager As New clsUIManager

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Dispose()
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub frmCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim colorRenderer_System As New clsUIManager.MySystemRenderer

        tsToolStrip.Renderer = colorRenderer_System

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        FileCon.caller_frmCategory = Me
        FileCon.caller_frmTransaction = m_frmTrans

        btnSearch.Checked = False
        lblSearch.Visible = False
        txtSearch.Visible = False
        lstCategories.Size = New Size(237, 267)

        Try

            FileCon.Connect()
            FileCon.SQLread_Fill_lstCategories("SELECT * FROM Categories")
            FileCon.Close()

            CountTotalListBoxItems_Display(lstCategories, lblItemCount)

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

                Dim strPreviousCategory As String = String.Empty
                strPreviousCategory = m_frmTrans.cbCategory.Text

                FileCon.Connect()
                FileCon.SQLread_FillcbCategories("SELECT * FROM Categories")
                FileCon.Close()

                If Not lstCategories.SelectedItems.Count = 0 Then

                    m_frmTrans.cbCategory.SelectedIndex = m_frmTrans.cbCategory.FindStringExact(Me.lstCategories.SelectedItem).ToString

                Else

                    m_frmTrans.cbCategory.SelectedIndex = m_frmTrans.cbCategory.FindStringExact(strPreviousCategory)

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
        new_frmCreate.Text = "Create Category"
        new_frmCreate.Icon = My.Resources.AddCategory
        new_frmCreate.txtEnter.Text = String.Empty

        Dim colCategoryCollection As New Microsoft.VisualBasic.Collection

        Try

            FileCon.Connect()
            FileCon.SQLread_FillCollection_FromDBColumn("SELECT * FROM Categories", colCategoryCollection, "Category")
            FileCon.Close()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

        If new_frmCreate.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim strCategory As String = String.Empty
            strCategory = new_frmCreate.txtEnter.Text

            For Each category As String In colCategoryCollection

                If strCategory.ToUpper = category.ToUpper Then

                    CheckbookMsg.ShowMessage("Category Conflict", MsgButtons.OK, "'" & strCategory & "'" & " already exists in your category list", Exclamation)
                    Exit Sub

                End If

            Next

            NewCategory.Category = strCategory

            Try

                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO Categories (Category) VALUES ('" & NewCategory.Category & "')")
                FileCon.SQLread_Fill_lstCategories("SELECT * FROM Categories")
                FileCon.Close()

                lstCategories.SelectedIndex = lstCategories.FindStringExact(NewCategory.Category)
                CountTotalListBoxItems_Display(lstCategories, lblItemCount)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
                Exit Sub

            End Try

        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strDeleteCategory As String = String.Empty
        Dim strRenamedCategory As String = String.Empty
        Dim strMessage As String = String.Empty
        Dim strMessage2 As String = String.Empty

        Dim intCount As Integer = 0

        If lstCategories.SelectedIndex < 0 Then

            CheckbookMsg.ShowMessage("There are no items selected to delete", MsgButtons.OK, "", Exclamation)

        Else

            strDeleteCategory = lstCategories.SelectedItem.ToString
            strRenamedCategory = "Unknown"

            NewCategory.Category = strRenamedCategory

            strMessage = "Are you sure you want to delete the category '" & strDeleteCategory & "'?"
            strMessage2 = "Consider renaming if you have used this category"

            If CheckbookMsg.ShowMessage(strMessage, MsgButtons.YesNo, strMessage2, Question) = DialogResult.Yes Then

                Try

                    FileCon.Connect()

                    FileCon.SQLupdate("UPDATE LedgerData SET Category = '" & NewCategory.Category & "' WHERE Category = '" & strDeleteCategory & "'")
                    FileCon.SQLdelete("DELETE FROM Categories WHERE Category = '" & strDeleteCategory & "'")

                    FileCon.SQLread_Fill_lstCategories("SELECT * FROM Categories")

                    If m_blnLedgerIsBeingBalanced Then

                        DataCon.SelectOnlyUnCleared_UpdateAccountDetails()

                    ElseIf m_blnLedgerIsBeingFiltered And Not MainForm.txtFilter.Text = String.Empty Then

                        DataCon.SelectOnlyFiltered_UpdateAccountDetails()

                    Else

                        DataCon.SelectAllLedgerData_UpdateAccountDetails()

                    End If

                    CountTotalListBoxItems_Display(lstCategories, lblItemCount)

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Delete Category Error", MsgButtons.OK, "An error occurred while deleting category" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                Finally

                    FileCon.Close()

                End Try

            End If

        End If

    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If lstCategories.SelectedIndex < 0 Then

            CheckbookMsg.ShowMessage("Please select a category to rename", MsgButtons.OK, "", Exclamation)

        Else

            Dim new_frmRename As New frmRename
            new_frmRename.Text = "Rename Category"
            new_frmRename.txtPrevious.BackColor = Color.White
            new_frmRename.txtPrevious.Text = lstCategories.SelectedItem.ToString
            new_frmRename.txtRename.Text = lstCategories.SelectedItem.ToString
            new_frmRename.txtRename.Focus()
            new_frmRename.txtRename.SelectAll()

            If new_frmRename.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim strPreviousCategoryName As String = String.Empty
                Dim strNewCategoryName As String = String.Empty
                Dim strSelectedCategory As String = String.Empty

                strPreviousCategoryName = new_frmRename.txtPrevious.Text
                strNewCategoryName = new_frmRename.txtRename.Text
                strSelectedCategory = lstCategories.SelectedItem.ToString

                If strPreviousCategoryName.ToUpper = strNewCategoryName.ToUpper Then

                    CheckbookMsg.ShowMessage("Category Conflict", MsgButtons.OK, "The category you entered is the same as the original, please enter a unique category name", Exclamation)
                    new_frmRename.txtRename.Focus()
                    new_frmRename.txtRename.SelectAll()
                    Exit Sub

                ElseIf CheckbookMsg.ShowMessage("Are you sure you want to rename the category '" & strSelectedCategory & "' to '" & new_frmRename.txtRename.Text & "'?", MsgButtons.YesNo, "", Question) = DialogResult.Yes Then

                    Try

                        Dim intCount As Integer = 0

                        NewCategory.Category = strNewCategoryName

                        FileCon.Connect()

                        FileCon.SQLupdate("UPDATE LedgerData SET Category = '" & NewCategory.Category & "' WHERE Category = '" & strPreviousCategoryName & "'")
                        FileCon.SQLupdate("UPDATE Categories SET Category = '" & NewCategory.Category & "' WHERE Category = '" & strPreviousCategoryName & "'")

                        FileCon.SQLread_Fill_lstCategories("SELECT * FROM Categories")

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

                        lstCategories.SelectedIndex = lstCategories.FindStringExact(NewCategory.Category)
                        UIManager.UpdateStatusStripInfo()

                        CheckbookMsg.ShowMessage("'" & strPreviousCategoryName & "' has been successfully renamed to  '" & NewCategory.Category & "'", MsgButtons.OK, "", Exclamation)

                    Catch ex As Exception

                        CheckbookMsg.ShowMessage("Rename Category Error", MsgButtons.OK, "An error occurred while renaming category" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

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
            lstCategories.Size = New Size(237, 225)
            txtSearch.Focus()
        End If
        If btnSearch.Checked = False Then
            lblSearch.Visible = False
            txtSearch.Visible = False
            lstCategories.Size = New Size(237, 267)
        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If txtSearch.Text = String.Empty Then
            lstCategories.SelectedIndex = -1
        End If
        Dim strSearch As String = txtSearch.Text.Trim
        If strSearch.Length = 0 Then Exit Sub
        Dim wordIndex As Integer
        wordIndex = lstCategories.FindStringExact(strSearch)
        If wordIndex >= 0 Then
            lstCategories.TopIndex = wordIndex
            lstCategories.SelectedIndex = wordIndex
        Else
            wordIndex = lstCategories.FindString(strSearch)
            If wordIndex >= 0 Then
                lstCategories.TopIndex = wordIndex
                lstCategories.SelectedIndex = wordIndex
            Else
                CheckbookMsg.ShowMessage("'" & strSearch & "'" & " does not exist in this list", MsgButtons.OK, "", Exclamation)
            End If
        End If

    End Sub

    Private Sub btnSweep_Click(sender As Object, e As EventArgs) Handles btnSweep.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
        Dim intOriginalCategoryItemsCount As Integer = 0
        Dim intNewCategoryItemsCount As Integer = 0

        intOriginalCategoryItemsCount = lstCategories.Items.Count

        FileCon.Connect()
        FileCon.SQLdelete("DELETE * FROM Categories")

        Dim colCategories As New Microsoft.VisualBasic.Collection

        FileCon.SQLread_FillCollection_FromDBColumn_RemoveDuplicates("SELECT * FROM LedgerData", colCategories, "Category")

        For Each category As String In colCategories

            If Not category = String.Empty And Not category = "Unknown" Then

                NewCategory.Category = category

                FileCon.SQLinsert("INSERT INTO Categories (Category) VALUES ('" & NewCategory.Category & "')")

            End If

        Next

        lstCategories.Items.Clear()

        FileCon.SQLread_Fill_lstCategories("SELECT * FROM Categories")

        FileCon.Close()

        CountTotalListBoxItems_Display(lstCategories, lblItemCount)

        intNewCategoryItemsCount = lstCategories.Items.Count

        If intNewCategoryItemsCount < intOriginalCategoryItemsCount Then

            Dim intCategoriesRemovedCount As Integer = 0
            intCategoriesRemovedCount = intOriginalCategoryItemsCount - intNewCategoryItemsCount
            Dim message As String = String.Empty

            If intCategoriesRemovedCount = 1 Then message = intCategoriesRemovedCount & " unused category has been removed from your list" Else message = intCategoriesRemovedCount & " unused categories have been removed from your list"

            CheckbookMsg.ShowMessage("All unused categories have been removed", MsgButtons.OK, message, Exclamation)

        Else

            CheckbookMsg.ShowMessage("There are no unused categories to remove", MsgButtons.OK, "", Exclamation)

        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        Dim new_frmImportCategories As New frmImportCategories
        new_frmImportCategories.ShowDialog()

        lstCategories.Items.Clear()
        FileCon.Connect()
        FileCon.SQLread_Fill_lstCategories("SELECT * FROM Categories")
        FileCon.Close()

        CountTotalListBoxItems_Display(lstCategories, lblItemCount)

    End Sub

    Private Sub lstCategories_DoubleClick(sender As Object, e As EventArgs) Handles lstCategories.DoubleClick

        lstCategories.ClearSelected()

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://chris-mackay.github.io/CheckbookWebsite/checkbook_help/categories_categories.html"
        Process.Start(strWebAddress)

    End Sub

End Class