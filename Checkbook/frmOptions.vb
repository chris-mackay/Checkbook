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

Public Class frmOptions

    Private UIManager As New clsUIManager
    Private FileCon As New clsLedgerDBConnector

    Private clrPreviousGridColor As Color
    Private clrPreviousUnclearedHighlightColor As Color
    Private clrPreviousSelectionColor As Color
    Private clrPreviousAltRowColor As Color

    Private blnPreviousShowGridSettings As Boolean = False
    Private blnPreviousCellBorderSettings As Boolean = False
    Private blnPreviousRowGridSettings As Boolean = False
    Private blnPreviousColumnGridSettings As Boolean = False
    Private blnPreviousColorUnclearedSettings As Boolean = False
    Private blnPreviousColorAlternatingRowsSettings As Boolean = False

    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileCon.Connect()

        'SETS PREVIOUS COLOR SETTINGS FROM SETTINGS
        clrPreviousGridColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.GridColor))
        clrPreviousUnclearedHighlightColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.UnclearedColor))
        clrPreviousSelectionColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.RowHighlightColor))
        clrPreviousAltRowColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.AlternatingRowColor))

        'SETS PREVIOUS GRID SETTINGS FROM SETTINGS
        blnPreviousShowGridSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ShowGrids))
        blnPreviousCellBorderSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.CellBorder))
        blnPreviousRowGridSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.RowGridLines))
        blnPreviousColumnGridSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ColumnGridLines))

        'SETS PREVIOUS COLOR OPTIONS SETTINGS FROM SETTINGS
        blnPreviousColorUnclearedSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ColorUncleared))
        blnPreviousColorAlternatingRowsSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ColorAlternatingRows))

        btnDefaultView.BackColor = Color.WhiteSmoke
        btnCustomizeToolbar.BackColor = Color.WhiteSmoke
        btnGridColor.BackColor = clrPreviousGridColor
        btnUnclearedColor.BackColor = clrPreviousUnclearedHighlightColor
        btnRowSelectionColor.BackColor = clrPreviousSelectionColor
        btnAlternatingRowColor.BackColor = clrPreviousAltRowColor

        Me.ckGridLines.Checked = blnPreviousShowGridSettings
        Me.rbSingle.Checked = blnPreviousCellBorderSettings
        Me.rbSingleHorizontal.Checked = blnPreviousRowGridSettings
        Me.rbSingleVertical.Checked = blnPreviousColumnGridSettings
        Me.ckColorUncleared.Checked = blnPreviousColorUnclearedSettings
        Me.ckColorAlternatingRows.Checked = blnPreviousColorAlternatingRowsSettings

        FileCon.Close()

        txtScenarioSave.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory)
        txtImport.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory)
        txtExport.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory)
        txtBackup.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory)
        txtReceipt.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory)
        txtStatement.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseStatementDirectory)


    End Sub

    Private Sub frmOptions_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        DrawBorderAroundTabControl()

    End Sub

    Private Sub DrawBorderAroundTabControl()

        Dim pen As New Pen(Color.LightSteelBlue, 1)
        Dim rec As New Rectangle(18, 10, 502, 368)

        Me.CreateGraphics.DrawRectangle(pen, rec)

    End Sub

    Private Sub btnGridColor_Click(sender As Object, e As EventArgs) Handles btnGridColor.Click

        If clrColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim clrGridColor As System.Drawing.Color
            clrGridColor = clrColorDialog.Color
            btnGridColor.BackColor = clrGridColor
        End If

    End Sub

    Private Sub btnUnclearedColor_Click(sender As Object, e As EventArgs) Handles btnUnclearedColor.Click

        If clrColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim clrUnclearedHighlightColor As System.Drawing.Color
            clrUnclearedHighlightColor = clrColorDialog.Color
            btnUnclearedColor.BackColor = clrUnclearedHighlightColor
        End If

    End Sub

    Private Sub btnSelectionColor_Click(sender As Object, e As EventArgs) Handles btnRowSelectionColor.Click

        If clrColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim clrRowSelectionColor As System.Drawing.Color
            clrRowSelectionColor = clrColorDialog.Color
            btnRowSelectionColor.BackColor = clrRowSelectionColor
        End If

    End Sub

    Private Sub btnAlternatingRowColor_Click(sender As Object, e As EventArgs) Handles btnAlternatingRowColor.Click

        If clrColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim clrAlternateRow As System.Drawing.Color
            clrAlternateRow = clrColorDialog.Color
            btnAlternatingRowColor.BackColor = clrAlternateRow
        End If

    End Sub

    Private Sub btnDefaultView_Click(sender As Object, e As EventArgs) Handles btnDefaultView.Click

        'GRID COLOR
        Dim clrGridColor As System.Drawing.Color
        clrGridColor = Color.LightGray
        btnGridColor.BackColor = clrGridColor

        'ALTERNATING ROW COLOR
        Dim clrAlternateRow As System.Drawing.Color
        clrAlternateRow = Color.WhiteSmoke
        btnAlternatingRowColor.BackColor = clrAlternateRow

        'ROW SELECTION COLOR
        Dim clrRowSelectionColor As System.Drawing.Color
        clrRowSelectionColor = Color.LightSteelBlue
        btnRowSelectionColor.BackColor = clrRowSelectionColor

        'UNCLEARED TRANSACTION HIGHLIGHT COLOR
        Dim clrUnclearedHighlightColor As System.Drawing.Color
        clrUnclearedHighlightColor = m_clrMyRed
        btnUnclearedColor.BackColor = clrUnclearedHighlightColor

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        MainForm.dgvLedger.GridColor = btnGridColor.BackColor

        MainForm.dgvLedger.DefaultCellStyle.SelectionBackColor = btnRowSelectionColor.BackColor

        If Not Me.ckColorAlternatingRows.Checked = True Then

            MainForm.dgvLedger.AlternatingRowsDefaultCellStyle.BackColor = Nothing

        Else

            MainForm.dgvLedger.AlternatingRowsDefaultCellStyle.BackColor = btnAlternatingRowColor.BackColor

        End If

        With MainForm

            If Me.ckColorUncleared.Checked = True Then

                For i = 0 To .dgvLedger.Rows.Count - 1

                    If .dgvLedger.Rows(i).Cells("Cleared").Value = False Then

                        .dgvLedger.Rows(i).DefaultCellStyle.BackColor = btnUnclearedColor.BackColor

                    End If

                Next

            Else

                For i = 0 To .dgvLedger.Rows.Count - 1

                    .dgvLedger.Rows(i).DefaultCellStyle.BackColor = Nothing

                Next

            End If

        End With

        If Not ckGridLines.Checked = True Then

            MainForm.dgvLedger.CellBorderStyle = DataGridViewCellBorderStyle.None

        ElseIf rbSingle.Checked = True Then

            MainForm.dgvLedger.CellBorderStyle = DataGridViewCellBorderStyle.Single

        ElseIf rbSingleHorizontal.Checked = True Then

            MainForm.dgvLedger.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

        Else

            MainForm.dgvLedger.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical

        End If

        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        FileCon.Connect()

        Dim blnShowGridLines As Boolean = False
        Dim blnCellBorder As Boolean = False
        Dim blnRowGridLines As Boolean = False
        Dim blnColumnGridLines As Boolean = False

        Dim blnColorUncleared As Boolean = False
        Dim blnColorAlternatingRows As Boolean = False

        blnShowGridLines = Me.ckGridLines.Checked
        blnCellBorder = Me.rbSingle.Checked
        blnRowGridLines = Me.rbSingleHorizontal.Checked
        blnColumnGridLines = Me.rbSingleVertical.Checked

        blnColorUncleared = Me.ckColorUncleared.Checked
        blnColorAlternatingRows = Me.ckColorAlternatingRows.Checked

        SetCheckbookSettingsValue(CheckbookSettings.ShowGrids, blnShowGridLines)
        SetCheckbookSettingsValue(CheckbookSettings.CellBorder, blnCellBorder)
        SetCheckbookSettingsValue(CheckbookSettings.RowGridLines, blnRowGridLines)
        SetCheckbookSettingsValue(CheckbookSettings.ColumnGridLines, blnColumnGridLines)
        SetCheckbookSettingsValue(CheckbookSettings.ColorUncleared, blnColorUncleared)
        SetCheckbookSettingsValue(CheckbookSettings.ColorAlternatingRows, blnColorAlternatingRows)

        Dim strGridColor As String = String.Empty
        Dim strUnclearedHighlightColor As String = String.Empty
        Dim strRowSelectionColor As String = String.Empty
        Dim strAlternatingRowColor As String = String.Empty

        strGridColor = UIManager.GetHexColor(btnGridColor.BackColor)
        strUnclearedHighlightColor = UIManager.GetHexColor(btnUnclearedColor.BackColor)
        strRowSelectionColor = UIManager.GetHexColor(btnRowSelectionColor.BackColor)
        strAlternatingRowColor = UIManager.GetHexColor(btnAlternatingRowColor.BackColor)

        SetCheckbookSettingsValue(CheckbookSettings.GridColor, strGridColor)
        SetCheckbookSettingsValue(CheckbookSettings.UnclearedColor, strUnclearedHighlightColor)
        SetCheckbookSettingsValue(CheckbookSettings.RowHighlightColor, strRowSelectionColor)
        SetCheckbookSettingsValue(CheckbookSettings.AlternatingRowColor, strAlternatingRowColor)

        FileCon.SetLedgerGrid_Color_Settings()

        FileCon.Close()

        FormatUncleared()

        SetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory, txtScenarioSave.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory, txtImport.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory, txtExport.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory, txtBackup.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory, txtReceipt.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultChooseStatementDirectory, txtStatement.Text)

        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        Me.Dispose()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        FormatUncleared()
        FileCon.Connect()
        FileCon.SetLedgerGrid_Color_Settings()
        FileCon.Close()
        Me.Dispose()

    End Sub

    Private Sub ckGridLines_CheckedChanged(sender As Object, e As EventArgs) Handles ckGridLines.CheckedChanged

        If Not ckGridLines.Checked = True Then

            rbSingle.Enabled = False
            rbSingleHorizontal.Enabled = False
            rbSingleVertical.Enabled = False

        Else

            rbSingle.Enabled = True
            rbSingleHorizontal.Enabled = True
            rbSingleVertical.Enabled = True

        End If

    End Sub

    Private Sub HelpButton_Click() Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/options.html"
        Process.Start(strWebAddress)

    End Sub

    Private Sub btnCustomizeToolbar_Click(sender As Object, e As EventArgs) Handles btnCustomizeToolbar.Click

        Dim new_frmCustomizeToolbar As New frmCustomizeToolbar
        new_frmCustomizeToolbar.ShowDialog()

    End Sub

    Private Sub btnScenarioSave_Click(sender As Object, e As EventArgs) Handles btnScenarioSave.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder to save and open Scenarios."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultScenarioSaveDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtScenarioSave.Text = dlg.SelectedPath

        End If

    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder containing csv files you import from."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtImport.Text = dlg.SelectedPath

        End If

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder where you want your exported transactions to be saved."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtExport.Text = dlg.SelectedPath

        End If

    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder to backup and restore your ledgers."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtBackup.Text = dlg.SelectedPath

        End If

    End Sub

    Private Sub btnReceipt_Click(sender As Object, e As EventArgs) Handles btnReceipt.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder to select receipts from."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtReceipt.Text = dlg.SelectedPath

        End If

    End Sub

    Private Sub btnStatement_Click(sender As Object, e As EventArgs) Handles btnStatement.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder to select statements from."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseStatementDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseStatementDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtStatement.Text = dlg.SelectedPath

        End If

    End Sub

End Class