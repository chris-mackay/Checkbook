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
        Me.btnRandom = New System.Windows.Forms.Button()
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
        Me.gbGridOptions.SuspendLayout()
        Me.gbColorOptions.SuspendLayout()
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
        Me.btnGridColor.Location = New System.Drawing.Point(12, 12)
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
        Me.btnAlternatingRowColor.Location = New System.Drawing.Point(12, 120)
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
        Me.btnRowSelectionColor.Location = New System.Drawing.Point(12, 84)
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
        Me.btnDefaultView.Location = New System.Drawing.Point(12, 192)
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
        Me.btnCancel.Location = New System.Drawing.Point(347, 276)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(266, 276)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 10
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
        Me.btnUnclearedColor.Location = New System.Drawing.Point(12, 48)
        Me.btnUnclearedColor.Name = "btnUnclearedColor"
        Me.btnUnclearedColor.Size = New System.Drawing.Size(237, 30)
        Me.btnUnclearedColor.TabIndex = 1
        Me.btnUnclearedColor.Text = "Uncleared Highlight Color"
        Me.btnUnclearedColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnclearedColor.UseVisualStyleBackColor = False
        '
        'btnRandom
        '
        Me.btnRandom.BackColor = System.Drawing.Color.White
        Me.btnRandom.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRandom.FlatAppearance.BorderSize = 2
        Me.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRandom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnRandom.Image = CType(resources.GetObject("btnRandom.Image"), System.Drawing.Image)
        Me.btnRandom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRandom.Location = New System.Drawing.Point(12, 156)
        Me.btnRandom.Name = "btnRandom"
        Me.btnRandom.Size = New System.Drawing.Size(237, 30)
        Me.btnRandom.TabIndex = 4
        Me.btnRandom.Text = "Randomize"
        Me.btnRandom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRandom.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.Location = New System.Drawing.Point(185, 276)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 9
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'ckGridLines
        '
        Me.ckGridLines.AutoSize = True
        Me.ckGridLines.Checked = True
        Me.ckGridLines.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckGridLines.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckGridLines.Location = New System.Drawing.Point(22, 23)
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
        Me.gbGridOptions.Location = New System.Drawing.Point(255, 12)
        Me.gbGridOptions.Name = "gbGridOptions"
        Me.gbGridOptions.Size = New System.Drawing.Size(167, 123)
        Me.gbGridOptions.TabIndex = 7
        Me.gbGridOptions.TabStop = False
        Me.gbGridOptions.Text = "Grid Options"
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbSingle.Location = New System.Drawing.Point(22, 46)
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
        Me.rbSingleHorizontal.Location = New System.Drawing.Point(22, 69)
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
        Me.rbSingleVertical.Location = New System.Drawing.Point(22, 92)
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
        Me.gbColorOptions.Location = New System.Drawing.Point(255, 141)
        Me.gbColorOptions.Name = "gbColorOptions"
        Me.gbColorOptions.Size = New System.Drawing.Size(167, 117)
        Me.gbColorOptions.TabIndex = 8
        Me.gbColorOptions.TabStop = False
        Me.gbColorOptions.Text = "Color Options"
        '
        'ckColorAlternatingRows
        '
        Me.ckColorAlternatingRows.AutoSize = True
        Me.ckColorAlternatingRows.Checked = True
        Me.ckColorAlternatingRows.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckColorAlternatingRows.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckColorAlternatingRows.Location = New System.Drawing.Point(22, 61)
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
        Me.ckColorUncleared.Location = New System.Drawing.Point(22, 38)
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
        Me.btnCustomizeToolbar.Location = New System.Drawing.Point(12, 228)
        Me.btnCustomizeToolbar.Name = "btnCustomizeToolbar"
        Me.btnCustomizeToolbar.Size = New System.Drawing.Size(237, 30)
        Me.btnCustomizeToolbar.TabIndex = 6
        Me.btnCustomizeToolbar.Text = "Customize Toolbar"
        Me.btnCustomizeToolbar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCustomizeToolbar.UseVisualStyleBackColor = False
        '
        'frmOptions
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(434, 311)
        Me.Controls.Add(Me.btnCustomizeToolbar)
        Me.Controls.Add(Me.gbColorOptions)
        Me.Controls.Add(Me.gbGridOptions)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnRandom)
        Me.Controls.Add(Me.btnUnclearedColor)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDefaultView)
        Me.Controls.Add(Me.btnRowSelectionColor)
        Me.Controls.Add(Me.btnAlternatingRowColor)
        Me.Controls.Add(Me.btnGridColor)
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
    Friend WithEvents btnRandom As System.Windows.Forms.Button
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
End Class
