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

Public Class frmOptions

    'NEW INSTANCES OF CLASSES
    Private UIManager As New clsUIManager
    Private FileCon As New clsLedgerDBConnector

    Private clrPreviousGridColor As Color
    Private clrPreviousUnclearedHighlightColor As Color
    Private clrPreviousSelectionColor As Color
    Private clrPreviousAltRowColor As Color

    Private blnPreviousShowGridSettings As Boolean
    Private blnPreviousCellBorderSettings As Boolean
    Private blnPreviousRowGridSettings As Boolean
    Private blnPreviousColumnGridSettings As Boolean
    Private blnPreviousColorUnclearedSettings As Boolean
    Private blnPreviousColorAlternatingRowsSettings As Boolean

    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'LOAD PREVIOUS GRID SETTINGS
        FileCon.Connect()

        'SETS PREVIOUS COLOR SETTINGS FROM DB
        clrPreviousGridColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.GridColor))
        clrPreviousUnclearedHighlightColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.UnclearedColor))
        clrPreviousSelectionColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.RowHighlightColor))
        clrPreviousAltRowColor = System.Drawing.ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.AlternatingRowColor))

        'SETS PREVIOUS GRID SETTINGS FROM DB
        blnPreviousShowGridSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ShowGrids))
        blnPreviousCellBorderSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.CellBorder))
        blnPreviousRowGridSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.RowGridLines))
        blnPreviousColumnGridSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ColumnGridLines))

        'SETS PREVIOUS COLOR OPTIONS SETTINGS FROM DB
        blnPreviousColorUnclearedSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ColorUncleared))
        blnPreviousColorAlternatingRowsSettings = Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ColorAlternatingRows))

        'SETS CONTROLS WITH SETTINGS FROM DB
        btnDefaultView.BackColor = Color.WhiteSmoke
        btnRandom.BackColor = Color.WhiteSmoke
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

        'LOAD DEFAULT FILE DIRECTORIES
        txtWhatifSave.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory)
        txtImport.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory)
        txtExport.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory)
        txtBackup.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory)
        txtReceipt.Text = GetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory)

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

    Private Sub btnRandom_Click(sender As Object, e As EventArgs) Handles btnRandom.Click

        Dim Rnd As New Random
        Dim intMinColor As Integer = 150
        Dim intMaxColor As Integer = 255

        Dim clrRandomGridColor As Color = Color.FromArgb(Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor))
        Dim clrRandomUnclearedHighlightColor As Color = Color.FromArgb(Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor))
        Dim clrRandomSelectionColor As Color = Color.FromArgb(Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor))
        Dim clrRandomAltRowColor As Color = Color.FromArgb(Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor), Rnd.Next(intMinColor, intMaxColor))

        btnGridColor.BackColor = clrRandomGridColor
        btnUnclearedColor.BackColor = clrRandomUnclearedHighlightColor
        btnRowSelectionColor.BackColor = clrRandomSelectionColor
        btnAlternatingRowColor.BackColor = clrRandomAltRowColor

        btnGridColor.BackColor = clrRandomGridColor
        btnUnclearedColor.BackColor = clrRandomUnclearedHighlightColor
        btnRowSelectionColor.BackColor = clrRandomSelectionColor
        btnAlternatingRowColor.BackColor = clrRandomAltRowColor

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
        clrUnclearedHighlightColor = m_myRed
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

        'FORMATS UNCLEARED TRANSACTIONS
        With MainForm

            If Me.ckColorUncleared.Checked = True Then

                'Changes the color of the cleared transactions
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

        'SAVES GRID SETTINGS TO DB
        Dim blnShowGridLines As Boolean
        Dim blnCellBorder As Boolean
        Dim blnRowGridLines As Boolean
        Dim blnColumnGridLines As Boolean

        'SAVES COLOR OPTIONS SETTINGS TO DB
        Dim blnColorUncleared As Boolean
        Dim blnColorAlternatingRows As Boolean

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

        'SAVES COLOR SETTINGS TO DB
        Dim strGridColor As String
        Dim strUnclearedHighlightColor As String
        Dim strRowSelectionColor As String
        Dim strAlternatingRowColor As String

        strGridColor = UIManager.GetHexColor(btnGridColor.BackColor)
        strUnclearedHighlightColor = UIManager.GetHexColor(btnUnclearedColor.BackColor)
        strRowSelectionColor = UIManager.GetHexColor(btnRowSelectionColor.BackColor)
        strAlternatingRowColor = UIManager.GetHexColor(btnAlternatingRowColor.BackColor)

        SetCheckbookSettingsValue(CheckbookSettings.GridColor, strGridColor)
        SetCheckbookSettingsValue(CheckbookSettings.UnclearedColor, strUnclearedHighlightColor)
        SetCheckbookSettingsValue(CheckbookSettings.RowHighlightColor, strRowSelectionColor)
        SetCheckbookSettingsValue(CheckbookSettings.AlternatingRowColor, strAlternatingRowColor)

        'FORMATS DGVLEDGER WITH DB SETTINGS
        FileCon.SetLedgerGrid_Color_Settings()

        FileCon.Close()

        'FORMATS UNCLEARED TRANSACTIONS
        FormatUncleared()

        'SAVE DEFAULT DIRECTORY SETTINGS
        SetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory, txtWhatifSave.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultImportTransactionsDirectory, txtImport.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultExportTransactionsDirectory, txtExport.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultBackupLedgerDirectory, txtBackup.Text)
        SetCheckbookSettingsValue(CheckbookSettings.DefaultChooseReceiptDirectory, txtReceipt.Text)

        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        Me.Dispose()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'FORMATS UNCLEARED TRANSACTIONS
        FormatUncleared()

        'SET PREVIOUS GRID SETTINGS IF CANCELLED
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

        Help.ShowHelp(Me, m_helpProvider.HelpNamespace, "options.html")

    End Sub

    Private Sub btnCustomizeToolbar_Click(sender As Object, e As EventArgs) Handles btnCustomizeToolbar.Click

        Dim new_frmCustomizeToolbar As New frmCustomizeToolbar
        new_frmCustomizeToolbar.ShowDialog()

    End Sub

    Private Sub btnWhatifSave_Click(sender As Object, e As EventArgs) Handles btnWhatifSave.Click

        Dim dlg As New FolderBrowserDialog
        dlg.Description = "Select a default folder to save and open What if Scenarios."
        dlg.ShowNewFolderButton = True

        If GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory) = String.Empty Then

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = Environment.SpecialFolder.MyDocuments

        Else

            dlg.RootFolder = Environment.SpecialFolder.Desktop
            dlg.SelectedPath = GetCheckbookSettingsValue(CheckbookSettings.DefaultWhatifSaveDirectory)

        End If

        If dlg.ShowDialog = DialogResult.OK Then

            txtWhatifSave.Text = dlg.SelectedPath

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

End Class