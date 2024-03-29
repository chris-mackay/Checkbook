﻿'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
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

Imports System.Drawing.Drawing2D

Public Class clsUIManager

    'CREATES A LINE OF COMMUNICATION BETWEEN FORMS
    Public caller_frmTransaction As frmTransaction

    Public lstAccountDetailsTextboxes As New List(Of Control)
    Private lstMainFormMenuItems As New List(Of Object)
    Private lstMainFormButtons As New List(Of Object)

    Public Sub UpdateStatusStripInfo()

        If Not m_blnDataIsBeingLoaded And Not m_blnNewVersionIsBeingDownloaded Then

            MainForm.stLabel.Text = String.Empty

            'UPDATE TOTAL TRANSACTIONS LOADED COUNT
            Dim intTransactionCount As Integer = 0
            Dim intSelectedTransCount As Integer = 0
            Dim intClearedTransCount As Integer = 0
            Dim intUnclearedTransCount As Integer = 0

            For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

                Dim i As Integer = 0
                i = dgvRow.Index

                Dim blnCleared As Boolean

                With MainForm

                    blnCleared = .dgvLedger.Rows(i).Cells("Cleared").Value

                    If blnCleared = True Then

                        intClearedTransCount += 1

                    Else

                        intUnclearedTransCount += 1

                    End If

                End With

                'GETS TOTAL LOADED TRANSACTIONS
                intTransactionCount += 1

            Next

            'UPDATE SELECTED TRANSACTION COUNT
            For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.SelectedRows

                intSelectedTransCount += 1

            Next

            MainForm.stLabel.Text = "Transactions Loaded: " & intTransactionCount & " | " & "Transactions Cleared: " & intClearedTransCount & " | " & "Transactions Uncleared: " & intUnclearedTransCount & " | " & "Transactions Selected: " & intSelectedTransCount

        End If

    End Sub

    Public Sub TextBox_FormatCurrency_Validated(sender As Object, e As EventArgs)

        sender = TryCast(sender, TextBox)

        Dim strValue As String = String.Empty

        strValue = sender.Text

        If Not strValue = String.Empty Then strValue = FormatCurrency(strValue)

        sender.Text = strValue

    End Sub

    Public Sub TextBox_HandleDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)

        Dim ctrl As New Control

        sender = TryCast(sender, TextBox)

        ctrl = sender

        Dim value As String = String.Empty

        value = sender.Text

        Dim dot As Integer, ch As String
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = "." And sender.Text.IndexOf(".") = -1 Then e.Handled = False 'ALLOW SINGLE DECIMAL POINT
        dot = sender.Text.IndexOf(".")
        If dot > -1 Then 'ALLOW ONLY 2 DECIMAL PLACES
            ch = sender.Text.Substring(dot + 1)
            If ch.Length > 1 Then e.Handled = True 'DOES NOT ALLOW ANY OTHER KEYPRESSES
        End If
        If e.KeyChar = Chr(8) Then e.Handled = False 'ALLOW BACKSPACE

        Dim a As Integer = 0
        Dim R As String = String.Empty

        For a = 1 To Len(value)

            R = Mid(value, a, 1)

            If R = "." Then Exit Sub

        Next

        If value = "0" Then Exit Sub

        value = Format(Val(Replace(value, ",", "")), "#,###,###")

        sender.Text = value

        If Len(sender.Text) > 1 Then

            sender.SelectionStart = Len(sender.Text)

            sender.SelectionLength = 0

        End If

    End Sub

    Public Class MyProfessionalRenderer
        Inherits ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
            If Not e.Item.Selected Then
                MyBase.OnRenderMenuItemBackground(e)
                e.Item.ForeColor = Color.FromArgb(21, 66, 139)
            Else
                Dim rc As New Rectangle(0, 0, e.Item.Width, e.Item.Height)

                Dim fillBrush As New SolidBrush(Color.FromArgb(255, 233, 157))
                Dim gradBrush As New LinearGradientBrush(rc, Color.FromArgb(255, 251, 214), Color.FromArgb(255, 211, 84), LinearGradientMode.Vertical)

                e.Graphics.FillRectangle(gradBrush, rc)
                e.Item.ForeColor = Color.FromArgb(21, 66, 139)

            End If
        End Sub
    End Class

    Public Class MySystemRenderer
        Inherits ToolStripSystemRenderer

        Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
            If Not e.Item.Selected Then
                MyBase.OnRenderButtonBackground(e)
            Else
                Dim rc As New Rectangle(0, 0, e.Item.Width, e.Item.Height)

                Dim fillBrush As New SolidBrush(Color.FromArgb(255, 211, 84))

                Dim gradBrush As New LinearGradientBrush(rc, Color.FromArgb(255, 251, 214), Color.FromArgb(255, 211, 84), LinearGradientMode.Vertical)

                e.Graphics.FillRectangle(gradBrush, rc)

            End If
        End Sub
    End Class

    Public Function GetHexColor(colorObj As System.Drawing.Color) As String

        Dim hexColor As String = String.Empty

        Dim R As String = Hex(colorObj.R)
        Dim G As String = Hex(colorObj.G)
        Dim B As String = Hex(colorObj.B)
        If R.Length = 1 Then
            R = 0 & R
        End If
        If G.Length = 1 Then
            G = 0 & G
        End If
        If B.Length = 1 Then
            B = 0 & B
        End If
        hexColor = "#" & R & G & B

        Return hexColor
    End Function

    Public Sub SetCursor(ByVal _Form As Form, ByVal _Cursor As Cursor)

        Cursor.Current = _Cursor

    End Sub

    Public Sub SetAllTexboxes_Contents_Backcolor_Forecolor_Visible_Enabled(ByVal _Text As String, ByVal _BackColor As Color, ByVal _ForeColor As Color, ByVal _Visible As Boolean, ByVal _Enabled As Boolean)

        For Each textBox As TextBox In m_lstAccountDetailTextboxes

            textBox.Text = _Text
            textBox.BackColor = _BackColor
            textBox.ForeColor = _ForeColor
            textBox.Visible = _Visible
            textBox.Enabled = _Enabled

        Next

    End Sub

    Public Sub SetGroupObjects_MenuItems_Visible_Enabled(ByVal _Visible As Boolean, ByVal _Enabled As Boolean)

        For Each ctrl As Object In lstMainFormMenuItems

            ctrl.Visible = _Visible
            ctrl.Enabled = _Enabled

        Next

    End Sub

    Public Sub SetGroupObjects_Buttons_Visible_Enabled(ByVal _Visible As Boolean, ByVal _Enabled As Boolean)

        For Each ctrl As Object In MainForm.tsToolStrip.Items

            ctrl.Visible = _Visible
            ctrl.Enabled = _Enabled

        Next

    End Sub

    Public Sub SetGroupObjects_List_Visible(ByVal _List As List(Of Control), ByVal _Visible As Boolean)

        For Each ctrl As Object In _List

            ctrl.Visible = _Visible

        Next

    End Sub

    Public Sub Maintain_DisabledMainFormUI()

        With MainForm

            'MENU ITEMS; ADDS MENU ITEMS THAT NEED TO BE HIDDEN IF CURRENT LEDGER IS DELETED
            lstMainFormMenuItems.Add(.mnuCloseLedger)
            lstMainFormMenuItems.Add(.mnuMyStatements)
            lstMainFormMenuItems.Add(.mnuSaveAs)
            lstMainFormMenuItems.Add(.mnuEdit)
            lstMainFormMenuItems.Add(.mnuView)
            lstMainFormMenuItems.Add(.mnuSum)
            lstMainFormMenuItems.Add(.mnuFilter)
            lstMainFormMenuItems.Add(.mnuAdvancedFilter)
            lstMainFormMenuItems.Add(.mnuOptions)
            lstMainFormMenuItems.Add(.mnuImportTrans)
            lstMainFormMenuItems.Add(.mnuExportTransactions)
            lstMainFormMenuItems.Add(.mnuBalanceAccount)

            .dgvLedger.ContextMenuStrip = Nothing

        End With

        If m_strCurrentFile = String.Empty Then

            MainForm.Text = "Checkbook"

            'SETS ALL TEXTBOXES ON MAINFORM TO EMPTY CONTENTS AND WHITE BACKGROUND
            SetAllTexboxes_Contents_Backcolor_Forecolor_Visible_Enabled("$0.00", Color.White, Color.Black, True, False)

            'HIDES AND DISABLES MENU ITEMS IF CURRENT LEDGER IS DELETED FROM MY CHECKBOOK LEDGERS
            SetGroupObjects_MenuItems_Visible_Enabled(True, False)
            SetGroupObjects_Buttons_Visible_Enabled(False, False)

            MainForm.filter_Button.Checked = False
            MainForm.mnuFilter.Checked = False
            MainForm.gbFilter.Visible = False

            MainForm.stLabel.Text = "Create a new ledger or open an existing ledger."

        Else

            With MainForm

                MainModule.DrawingControl.SetDoubleBuffered_ListControls(m_lstAllMainFormControls)
                MainModule.DrawingControl.SuspendDrawing_ListControls(m_lstAllMainFormControls)

                SetGroupObjects_MenuItems_Visible_Enabled(True, True) 'IF CURRENT LEDGER IS NOT DELETED CONTINUE TO SHOW ALL THE CONTROLS
                SetGroupObjects_Buttons_Visible_Enabled(True, True)
                .dgvLedger.ContextMenuStrip = .cxmnuDataGridMenu
                UpdateStatusStripInfo()

                MainModule.DrawingControl.ResumeDrawing_ListControls(m_lstAllMainFormControls)

            End With

        End If

    End Sub

    Public Sub DisableDepositUI()

        With caller_frmTransaction

            .txtDeposit.Text = String.Empty
            .txtDeposit.Enabled = False

        End With

    End Sub

    Public Sub EnableDepositUI()

        With caller_frmTransaction

            .txtDeposit.Text = String.Empty
            .txtDeposit.Enabled = True

        End With

    End Sub

    Public Sub DisablePaymentUI()

        With caller_frmTransaction

            .txtPayment.Text = String.Empty
            .txtPayment.Enabled = False

        End With

    End Sub

    Public Sub EnablePaymentUI()

        With caller_frmTransaction

            .txtPayment.Text = String.Empty
            .txtPayment.Enabled = True

        End With

    End Sub

End Class
