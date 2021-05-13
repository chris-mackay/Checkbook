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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.btnGridColor = New System.Windows.Forms.Button()
        Me.btnAlternatingRowColor = New System.Windows.Forms.Button()
        Me.btnRowSelectionColor = New System.Windows.Forms.Button()
        Me.btnDefaultView = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.clrColorDialog = New System.Windows.Forms.ColorDialog()
        Me.btnUnclearedColor = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.ckGridLines = New System.Windows.Forms.CheckBox()
        Me.gbGridOptions = New System.Windows.Forms.GroupBox()
        Me.rbSingle = New System.Windows.Forms.RadioButton()
        Me.rbSingleHorizontal = New System.Windows.Forms.RadioButton()
        Me.rbSingleVertical = New System.Windows.Forms.RadioButton()
        Me.gbColorOptions = New System.Windows.Forms.GroupBox()
        Me.ckColorAlternatingRows = New System.Windows.Forms.CheckBox()
        Me.ckColorUncleared = New System.Windows.Forms.CheckBox()
        Me.btnCustomizeToolbar = New System.Windows.Forms.Button()
        Me.tbTabControl = New System.Windows.Forms.TabControl()
        Me.tpLedgerUI = New System.Windows.Forms.TabPage()
        Me.gbUIOptions = New System.Windows.Forms.GroupBox()
        Me.tpDefaultPaths = New System.Windows.Forms.TabPage()
        Me.lblStatement = New System.Windows.Forms.Label()
        Me.lblReceipt = New System.Windows.Forms.Label()
        Me.btnStatement = New System.Windows.Forms.Button()
        Me.btnReceipt = New System.Windows.Forms.Button()
        Me.txtStatement = New System.Windows.Forms.TextBox()
        Me.txtReceipt = New System.Windows.Forms.TextBox()
        Me.btnScenarioSave = New System.Windows.Forms.Button()
        Me.lblBackupRestore = New System.Windows.Forms.Label()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.txtBackup = New System.Windows.Forms.TextBox()
        Me.lbExport = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txtExport = New System.Windows.Forms.TextBox()
        Me.lblImport = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.txtImport = New System.Windows.Forms.TextBox()
        Me.lblScenario = New System.Windows.Forms.Label()
        Me.txtScenarioSave = New System.Windows.Forms.TextBox()
        Me.gbGridOptions.SuspendLayout()
        Me.gbColorOptions.SuspendLayout()
        Me.tbTabControl.SuspendLayout()
        Me.tpLedgerUI.SuspendLayout()
        Me.gbUIOptions.SuspendLayout()
        Me.tpDefaultPaths.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGridColor
        '
        Me.btnGridColor.BackColor = System.Drawing.Color.White
        Me.btnGridColor.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnGridColor.FlatAppearance.BorderSize = 2
        Me.btnGridColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGridColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnGridColor.Image = CType(resources.GetObject("btnGridColor.Image"), System.Drawing.Image)
        Me.btnGridColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGridColor.Location = New System.Drawing.Point(11, 19)
        Me.btnGridColor.Name = "btnGridColor"
        Me.btnGridColor.Size = New System.Drawing.Size(237, 30)
        Me.btnGridColor.TabIndex = 0
        Me.btnGridColor.Text = "Grid Color"
        Me.btnGridColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGridColor.UseVisualStyleBackColor = False
        '
        'btnAlternatingRowColor
        '
        Me.btnAlternatingRowColor.BackColor = System.Drawing.Color.White
        Me.btnAlternatingRowColor.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnAlternatingRowColor.FlatAppearance.BorderSize = 2
        Me.btnAlternatingRowColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternatingRowColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnAlternatingRowColor.Image = CType(resources.GetObject("btnAlternatingRowColor.Image"), System.Drawing.Image)
        Me.btnAlternatingRowColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlternatingRowColor.Location = New System.Drawing.Point(11, 127)
        Me.btnAlternatingRowColor.Name = "btnAlternatingRowColor"
        Me.btnAlternatingRowColor.Size = New System.Drawing.Size(237, 30)
        Me.btnAlternatingRowColor.TabIndex = 3
        Me.btnAlternatingRowColor.Text = "Alternating Row Color"
        Me.btnAlternatingRowColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlternatingRowColor.UseVisualStyleBackColor = False
        '
        'btnRowSelectionColor
        '
        Me.btnRowSelectionColor.BackColor = System.Drawing.Color.White
        Me.btnRowSelectionColor.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRowSelectionColor.FlatAppearance.BorderSize = 2
        Me.btnRowSelectionColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRowSelectionColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnRowSelectionColor.Image = CType(resources.GetObject("btnRowSelectionColor.Image"), System.Drawing.Image)
        Me.btnRowSelectionColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRowSelectionColor.Location = New System.Drawing.Point(11, 91)
        Me.btnRowSelectionColor.Name = "btnRowSelectionColor"
        Me.btnRowSelectionColor.Size = New System.Drawing.Size(237, 30)
        Me.btnRowSelectionColor.TabIndex = 2
        Me.btnRowSelectionColor.Text = "Row Selection Color"
        Me.btnRowSelectionColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRowSelectionColor.UseVisualStyleBackColor = False
        '
        'btnDefaultView
        '
        Me.btnDefaultView.BackColor = System.Drawing.Color.White
        Me.btnDefaultView.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnDefaultView.FlatAppearance.BorderSize = 2
        Me.btnDefaultView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefaultView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnDefaultView.Image = CType(resources.GetObject("btnDefaultView.Image"), System.Drawing.Image)
        Me.btnDefaultView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefaultView.Location = New System.Drawing.Point(11, 163)
        Me.btnDefaultView.Name = "btnDefaultView"
        Me.btnDefaultView.Size = New System.Drawing.Size(237, 30)
        Me.btnDefaultView.TabIndex = 5
        Me.btnDefaultView.Text = "Restore Default Colors"
        Me.btnDefaultView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDefaultView.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(452, 387)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(371, 387)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.TabStop = False
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnUnclearedColor
        '
        Me.btnUnclearedColor.BackColor = System.Drawing.Color.White
        Me.btnUnclearedColor.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnUnclearedColor.FlatAppearance.BorderSize = 2
        Me.btnUnclearedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnclearedColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnUnclearedColor.Image = CType(resources.GetObject("btnUnclearedColor.Image"), System.Drawing.Image)
        Me.btnUnclearedColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUnclearedColor.Location = New System.Drawing.Point(11, 55)
        Me.btnUnclearedColor.Name = "btnUnclearedColor"
        Me.btnUnclearedColor.Size = New System.Drawing.Size(237, 30)
        Me.btnUnclearedColor.TabIndex = 1
        Me.btnUnclearedColor.Text = "Uncleared Highlight Color"
        Me.btnUnclearedColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnclearedColor.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(290, 387)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 0
        Me.btnApply.TabStop = False
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'ckGridLines
        '
        Me.ckGridLines.AutoSize = True
        Me.ckGridLines.Checked = True
        Me.ckGridLines.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckGridLines.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckGridLines.Location = New System.Drawing.Point(22, 28)
        Me.ckGridLines.Name = "ckGridLines"
        Me.ckGridLines.Size = New System.Drawing.Size(103, 17)
        Me.ckGridLines.TabIndex = 0
        Me.ckGridLines.Text = "Show Grid Lines"
        Me.ckGridLines.UseVisualStyleBackColor = True
        '
        'gbGridOptions
        '
        Me.gbGridOptions.Controls.Add(Me.rbSingle)
        Me.gbGridOptions.Controls.Add(Me.rbSingleHorizontal)
        Me.gbGridOptions.Controls.Add(Me.rbSingleVertical)
        Me.gbGridOptions.Controls.Add(Me.ckGridLines)
        Me.gbGridOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbGridOptions.Location = New System.Drawing.Point(295, 26)
        Me.gbGridOptions.Name = "gbGridOptions"
        Me.gbGridOptions.Size = New System.Drawing.Size(167, 142)
        Me.gbGridOptions.TabIndex = 1
        Me.gbGridOptions.TabStop = False
        Me.gbGridOptions.Text = "Grid Options"
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbSingle.Location = New System.Drawing.Point(22, 51)
        Me.rbSingle.Name = "rbSingle"
        Me.rbSingle.Size = New System.Drawing.Size(76, 17)
        Me.rbSingle.TabIndex = 1
        Me.rbSingle.TabStop = True
        Me.rbSingle.Text = "Cell Border"
        Me.rbSingle.UseVisualStyleBackColor = True
        '
        'rbSingleHorizontal
        '
        Me.rbSingleHorizontal.AutoSize = True
        Me.rbSingleHorizontal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbSingleHorizontal.Location = New System.Drawing.Point(22, 74)
        Me.rbSingleHorizontal.Name = "rbSingleHorizontal"
        Me.rbSingleHorizontal.Size = New System.Drawing.Size(97, 17)
        Me.rbSingleHorizontal.TabIndex = 2
        Me.rbSingleHorizontal.TabStop = True
        Me.rbSingleHorizontal.Text = "Row Grid Lines"
        Me.rbSingleHorizontal.UseVisualStyleBackColor = True
        '
        'rbSingleVertical
        '
        Me.rbSingleVertical.AutoSize = True
        Me.rbSingleVertical.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbSingleVertical.Location = New System.Drawing.Point(22, 97)
        Me.rbSingleVertical.Name = "rbSingleVertical"
        Me.rbSingleVertical.Size = New System.Drawing.Size(110, 17)
        Me.rbSingleVertical.TabIndex = 3
        Me.rbSingleVertical.TabStop = True
        Me.rbSingleVertical.Text = "Column Grid Lines"
        Me.rbSingleVertical.UseVisualStyleBackColor = True
        '
        'gbColorOptions
        '
        Me.gbColorOptions.Controls.Add(Me.ckColorAlternatingRows)
        Me.gbColorOptions.Controls.Add(Me.ckColorUncleared)
        Me.gbColorOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbColorOptions.Location = New System.Drawing.Point(295, 174)
        Me.gbColorOptions.Name = "gbColorOptions"
        Me.gbColorOptions.Size = New System.Drawing.Size(167, 136)
        Me.gbColorOptions.TabIndex = 2
        Me.gbColorOptions.TabStop = False
        Me.gbColorOptions.Text = "Color Options"
        '
        'ckColorAlternatingRows
        '
        Me.ckColorAlternatingRows.AutoSize = True
        Me.ckColorAlternatingRows.Checked = True
        Me.ckColorAlternatingRows.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckColorAlternatingRows.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckColorAlternatingRows.Location = New System.Drawing.Point(22, 71)
        Me.ckColorAlternatingRows.Name = "ckColorAlternatingRows"
        Me.ckColorAlternatingRows.Size = New System.Drawing.Size(133, 17)
        Me.ckColorAlternatingRows.TabIndex = 1
        Me.ckColorAlternatingRows.Text = "Color Alternating Rows"
        Me.ckColorAlternatingRows.UseVisualStyleBackColor = True
        '
        'ckColorUncleared
        '
        Me.ckColorUncleared.AutoSize = True
        Me.ckColorUncleared.Checked = True
        Me.ckColorUncleared.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckColorUncleared.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckColorUncleared.Location = New System.Drawing.Point(22, 48)
        Me.ckColorUncleared.Name = "ckColorUncleared"
        Me.ckColorUncleared.Size = New System.Drawing.Size(102, 17)
        Me.ckColorUncleared.TabIndex = 0
        Me.ckColorUncleared.Text = "Color Uncleared"
        Me.ckColorUncleared.UseVisualStyleBackColor = True
        '
        'btnCustomizeToolbar
        '
        Me.btnCustomizeToolbar.BackColor = System.Drawing.Color.White
        Me.btnCustomizeToolbar.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCustomizeToolbar.FlatAppearance.BorderSize = 2
        Me.btnCustomizeToolbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomizeToolbar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnCustomizeToolbar.Image = CType(resources.GetObject("btnCustomizeToolbar.Image"), System.Drawing.Image)
        Me.btnCustomizeToolbar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCustomizeToolbar.Location = New System.Drawing.Point(11, 199)
        Me.btnCustomizeToolbar.Name = "btnCustomizeToolbar"
        Me.btnCustomizeToolbar.Size = New System.Drawing.Size(237, 30)
        Me.btnCustomizeToolbar.TabIndex = 6
        Me.btnCustomizeToolbar.Text = "Customize Toolbar"
        Me.btnCustomizeToolbar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCustomizeToolbar.UseVisualStyleBackColor = False
        '
        'tbTabControl
        '
        Me.tbTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tbTabControl.Controls.Add(Me.tpLedgerUI)
        Me.tbTabControl.Controls.Add(Me.tpDefaultPaths)
        Me.tbTabControl.Location = New System.Drawing.Point(19, 12)
        Me.tbTabControl.Name = "tbTabControl"
        Me.tbTabControl.SelectedIndex = 0
        Me.tbTabControl.Size = New System.Drawing.Size(501, 366)
        Me.tbTabControl.TabIndex = 0
        Me.tbTabControl.TabStop = False
        '
        'tpLedgerUI
        '
        Me.tpLedgerUI.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.tpLedgerUI.Controls.Add(Me.gbUIOptions)
        Me.tpLedgerUI.Controls.Add(Me.gbColorOptions)
        Me.tpLedgerUI.Controls.Add(Me.gbGridOptions)
        Me.tpLedgerUI.Location = New System.Drawing.Point(4, 25)
        Me.tpLedgerUI.Name = "tpLedgerUI"
        Me.tpLedgerUI.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLedgerUI.Size = New System.Drawing.Size(493, 337)
        Me.tpLedgerUI.TabIndex = 0
        Me.tpLedgerUI.Text = "Ledger Graphics"
        '
        'gbUIOptions
        '
        Me.gbUIOptions.Controls.Add(Me.btnGridColor)
        Me.gbUIOptions.Controls.Add(Me.btnCustomizeToolbar)
        Me.gbUIOptions.Controls.Add(Me.btnUnclearedColor)
        Me.gbUIOptions.Controls.Add(Me.btnDefaultView)
        Me.gbUIOptions.Controls.Add(Me.btnAlternatingRowColor)
        Me.gbUIOptions.Controls.Add(Me.btnRowSelectionColor)
        Me.gbUIOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbUIOptions.Location = New System.Drawing.Point(31, 26)
        Me.gbUIOptions.Name = "gbUIOptions"
        Me.gbUIOptions.Size = New System.Drawing.Size(258, 284)
        Me.gbUIOptions.TabIndex = 0
        Me.gbUIOptions.TabStop = False
        Me.gbUIOptions.Text = "Colors && Toolbar"
        '
        'tpDefaultPaths
        '
        Me.tpDefaultPaths.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.tpDefaultPaths.Controls.Add(Me.lblStatement)
        Me.tpDefaultPaths.Controls.Add(Me.lblReceipt)
        Me.tpDefaultPaths.Controls.Add(Me.btnStatement)
        Me.tpDefaultPaths.Controls.Add(Me.btnReceipt)
        Me.tpDefaultPaths.Controls.Add(Me.txtStatement)
        Me.tpDefaultPaths.Controls.Add(Me.txtReceipt)
        Me.tpDefaultPaths.Controls.Add(Me.btnScenarioSave)
        Me.tpDefaultPaths.Controls.Add(Me.lblBackupRestore)
        Me.tpDefaultPaths.Controls.Add(Me.btnBackup)
        Me.tpDefaultPaths.Controls.Add(Me.txtBackup)
        Me.tpDefaultPaths.Controls.Add(Me.lbExport)
        Me.tpDefaultPaths.Controls.Add(Me.btnExport)
        Me.tpDefaultPaths.Controls.Add(Me.txtExport)
        Me.tpDefaultPaths.Controls.Add(Me.lblImport)
        Me.tpDefaultPaths.Controls.Add(Me.btnImport)
        Me.tpDefaultPaths.Controls.Add(Me.txtImport)
        Me.tpDefaultPaths.Controls.Add(Me.lblScenario)
        Me.tpDefaultPaths.Controls.Add(Me.txtScenarioSave)
        Me.tpDefaultPaths.Location = New System.Drawing.Point(4, 25)
        Me.tpDefaultPaths.Name = "tpDefaultPaths"
        Me.tpDefaultPaths.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDefaultPaths.Size = New System.Drawing.Size(493, 337)
        Me.tpDefaultPaths.TabIndex = 1
        Me.tpDefaultPaths.Text = "Default Directories"
        '
        'lblStatement
        '
        Me.lblStatement.AutoSize = True
        Me.lblStatement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatement.Location = New System.Drawing.Point(17, 223)
        Me.lblStatement.Name = "lblStatement"
        Me.lblStatement.Size = New System.Drawing.Size(176, 13)
        Me.lblStatement.TabIndex = 19
        Me.lblStatement.Text = "Default Choose Statement Directory"
        '
        'lblReceipt
        '
        Me.lblReceipt.AutoSize = True
        Me.lblReceipt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReceipt.Location = New System.Drawing.Point(17, 184)
        Me.lblReceipt.Name = "lblReceipt"
        Me.lblReceipt.Size = New System.Drawing.Size(165, 13)
        Me.lblReceipt.TabIndex = 19
        Me.lblReceipt.Text = "Default Choose Receipt Directory"
        '
        'btnStatement
        '
        Me.btnStatement.Location = New System.Drawing.Point(401, 237)
        Me.btnStatement.Name = "btnStatement"
        Me.btnStatement.Size = New System.Drawing.Size(75, 24)
        Me.btnStatement.TabIndex = 21
        Me.btnStatement.Text = "Browse"
        Me.btnStatement.UseVisualStyleBackColor = True
        '
        'btnReceipt
        '
        Me.btnReceipt.Location = New System.Drawing.Point(401, 198)
        Me.btnReceipt.Name = "btnReceipt"
        Me.btnReceipt.Size = New System.Drawing.Size(75, 24)
        Me.btnReceipt.TabIndex = 21
        Me.btnReceipt.Text = "Browse"
        Me.btnReceipt.UseVisualStyleBackColor = True
        '
        'txtStatement
        '
        Me.txtStatement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatement.Location = New System.Drawing.Point(20, 239)
        Me.txtStatement.Name = "txtStatement"
        Me.txtStatement.ReadOnly = True
        Me.txtStatement.Size = New System.Drawing.Size(375, 20)
        Me.txtStatement.TabIndex = 20
        '
        'txtReceipt
        '
        Me.txtReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceipt.Location = New System.Drawing.Point(20, 200)
        Me.txtReceipt.Name = "txtReceipt"
        Me.txtReceipt.ReadOnly = True
        Me.txtReceipt.Size = New System.Drawing.Size(375, 20)
        Me.txtReceipt.TabIndex = 20
        '
        'btnScenarioSave
        '
        Me.btnScenarioSave.Location = New System.Drawing.Point(401, 34)
        Me.btnScenarioSave.Name = "btnScenarioSave"
        Me.btnScenarioSave.Size = New System.Drawing.Size(75, 24)
        Me.btnScenarioSave.TabIndex = 18
        Me.btnScenarioSave.Text = "Browse"
        Me.btnScenarioSave.UseVisualStyleBackColor = True
        '
        'lblBackupRestore
        '
        Me.lblBackupRestore.AutoSize = True
        Me.lblBackupRestore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBackupRestore.Location = New System.Drawing.Point(17, 145)
        Me.lblBackupRestore.Name = "lblBackupRestore"
        Me.lblBackupRestore.Size = New System.Drawing.Size(204, 13)
        Me.lblBackupRestore.TabIndex = 12
        Me.lblBackupRestore.Text = "Default Backup/Restore Ledger Directory"
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(401, 159)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(75, 24)
        Me.btnBackup.TabIndex = 14
        Me.btnBackup.Text = "Browse"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'txtBackup
        '
        Me.txtBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBackup.Location = New System.Drawing.Point(20, 161)
        Me.txtBackup.Name = "txtBackup"
        Me.txtBackup.ReadOnly = True
        Me.txtBackup.Size = New System.Drawing.Size(375, 20)
        Me.txtBackup.TabIndex = 13
        '
        'lbExport
        '
        Me.lbExport.AutoSize = True
        Me.lbExport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbExport.Location = New System.Drawing.Point(17, 102)
        Me.lbExport.Name = "lbExport"
        Me.lbExport.Size = New System.Drawing.Size(183, 13)
        Me.lbExport.TabIndex = 9
        Me.lbExport.Text = "Default Export Transactions Directory"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(401, 116)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 24)
        Me.btnExport.TabIndex = 11
        Me.btnExport.Text = "Browse"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'txtExport
        '
        Me.txtExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExport.Location = New System.Drawing.Point(20, 118)
        Me.txtExport.Name = "txtExport"
        Me.txtExport.ReadOnly = True
        Me.txtExport.Size = New System.Drawing.Size(375, 20)
        Me.txtExport.TabIndex = 10
        '
        'lblImport
        '
        Me.lblImport.AutoSize = True
        Me.lblImport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblImport.Location = New System.Drawing.Point(17, 59)
        Me.lblImport.Name = "lblImport"
        Me.lblImport.Size = New System.Drawing.Size(182, 13)
        Me.lblImport.TabIndex = 6
        Me.lblImport.Text = "Default Import Transactions Directory"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(401, 73)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 24)
        Me.btnImport.TabIndex = 8
        Me.btnImport.Text = "Browse"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'txtImport
        '
        Me.txtImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImport.Location = New System.Drawing.Point(20, 75)
        Me.txtImport.Name = "txtImport"
        Me.txtImport.ReadOnly = True
        Me.txtImport.Size = New System.Drawing.Size(375, 20)
        Me.txtImport.TabIndex = 7
        '
        'lblScenario
        '
        Me.lblScenario.AutoSize = True
        Me.lblScenario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblScenario.Location = New System.Drawing.Point(17, 20)
        Me.lblScenario.Name = "lblScenario"
        Me.lblScenario.Size = New System.Drawing.Size(190, 13)
        Me.lblScenario.TabIndex = 0
        Me.lblScenario.Text = "Default Scenario Save/Open Directory"
        '
        'txtScenarioSave
        '
        Me.txtScenarioSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScenarioSave.Location = New System.Drawing.Point(20, 36)
        Me.txtScenarioSave.Name = "txtScenarioSave"
        Me.txtScenarioSave.ReadOnly = True
        Me.txtScenarioSave.Size = New System.Drawing.Size(375, 20)
        Me.txtScenarioSave.TabIndex = 1
        '
        'frmOptions
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(539, 422)
        Me.Controls.Add(Me.tbTabControl)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        Me.gbGridOptions.ResumeLayout(False)
        Me.gbGridOptions.PerformLayout()
        Me.gbColorOptions.ResumeLayout(False)
        Me.gbColorOptions.PerformLayout()
        Me.tbTabControl.ResumeLayout(False)
        Me.tpLedgerUI.ResumeLayout(False)
        Me.gbUIOptions.ResumeLayout(False)
        Me.tpDefaultPaths.ResumeLayout(False)
        Me.tpDefaultPaths.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGridColor As System.Windows.Forms.Button
    Friend WithEvents btnAlternatingRowColor As System.Windows.Forms.Button
    Friend WithEvents btnRowSelectionColor As System.Windows.Forms.Button
    Friend WithEvents btnDefaultView As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents clrColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents btnUnclearedColor As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents ckGridLines As System.Windows.Forms.CheckBox
    Friend WithEvents gbGridOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbSingle As System.Windows.Forms.RadioButton
    Friend WithEvents rbSingleHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents rbSingleVertical As System.Windows.Forms.RadioButton
    Friend WithEvents gbColorOptions As System.Windows.Forms.GroupBox
    Friend WithEvents ckColorAlternatingRows As System.Windows.Forms.CheckBox
    Friend WithEvents ckColorUncleared As System.Windows.Forms.CheckBox
    Friend WithEvents btnCustomizeToolbar As Button
    Friend WithEvents tbTabControl As TabControl
    Friend WithEvents tpLedgerUI As TabPage
    Friend WithEvents gbUIOptions As GroupBox
    Friend WithEvents tpDefaultPaths As TabPage
    Friend WithEvents txtScenarioSave As TextBox
    Friend WithEvents lbExport As Label
    Friend WithEvents btnExport As Button
    Friend WithEvents txtExport As TextBox
    Friend WithEvents lblImport As Label
    Friend WithEvents btnImport As Button
    Friend WithEvents txtImport As TextBox
    Friend WithEvents lblScenario As Label
    Friend WithEvents lblBackupRestore As Label
    Friend WithEvents btnBackup As Button
    Friend WithEvents txtBackup As TextBox
    Friend WithEvents btnScenarioSave As Button
    Friend WithEvents lblReceipt As Label
    Friend WithEvents btnReceipt As Button
    Friend WithEvents txtReceipt As TextBox
    Friend WithEvents lblStatement As Label
    Friend WithEvents btnStatement As Button
    Friend WithEvents txtStatement As TextBox
End Class
