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
Partial Class frmImportCategories
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportCategories))
        Me.cbMyLedgers = New System.Windows.Forms.ComboBox()
        Me.lstImportCategories = New System.Windows.Forms.ListBox()
        Me.lstMyCategories = New System.Windows.Forms.ListBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblMyCategories = New System.Windows.Forms.Label()
        Me.lblMyCheckbookLedgers = New System.Windows.Forms.Label()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbMyLedgers
        '
        Me.cbMyLedgers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMyLedgers.FormattingEnabled = True
        Me.cbMyLedgers.Location = New System.Drawing.Point(12, 32)
        Me.cbMyLedgers.Name = "cbMyLedgers"
        Me.cbMyLedgers.Size = New System.Drawing.Size(184, 21)
        Me.cbMyLedgers.Sorted = True
        Me.cbMyLedgers.TabIndex = 1
        '
        'lstImportCategories
        '
        Me.lstImportCategories.FormattingEnabled = True
        Me.lstImportCategories.HorizontalScrollbar = True
        Me.lstImportCategories.Location = New System.Drawing.Point(12, 59)
        Me.lstImportCategories.Name = "lstImportCategories"
        Me.lstImportCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstImportCategories.Size = New System.Drawing.Size(184, 212)
        Me.lstImportCategories.Sorted = True
        Me.lstImportCategories.TabIndex = 2
        '
        'lstMyCategories
        '
        Me.lstMyCategories.FormattingEnabled = True
        Me.lstMyCategories.HorizontalScrollbar = True
        Me.lstMyCategories.Location = New System.Drawing.Point(236, 59)
        Me.lstMyCategories.Name = "lstMyCategories"
        Me.lstMyCategories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMyCategories.Size = New System.Drawing.Size(184, 212)
        Me.lstMyCategories.Sorted = True
        Me.lstMyCategories.TabIndex = 6
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(345, 281)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImport.Location = New System.Drawing.Point(264, 281)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 7
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(203, 59)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(26, 26)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblMyCategories
        '
        Me.lblMyCategories.AutoSize = True
        Me.lblMyCategories.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblMyCategories.Location = New System.Drawing.Point(236, 43)
        Me.lblMyCategories.Name = "lblMyCategories"
        Me.lblMyCategories.Size = New System.Drawing.Size(74, 13)
        Me.lblMyCategories.TabIndex = 5
        Me.lblMyCategories.Text = "My Categories"
        '
        'lblMyCheckbookLedgers
        '
        Me.lblMyCheckbookLedgers.AutoSize = True
        Me.lblMyCheckbookLedgers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblMyCheckbookLedgers.Location = New System.Drawing.Point(12, 16)
        Me.lblMyCheckbookLedgers.Name = "lblMyCheckbookLedgers"
        Me.lblMyCheckbookLedgers.Size = New System.Drawing.Size(120, 13)
        Me.lblMyCheckbookLedgers.TabIndex = 0
        Me.lblMyCheckbookLedgers.Text = "My Checkbook Ledgers"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Image = CType(resources.GetObject("btnSelectAll.Image"), System.Drawing.Image)
        Me.btnSelectAll.Location = New System.Drawing.Point(203, 91)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(26, 26)
        Me.btnSelectAll.TabIndex = 4
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'frmImportCategories
        '
        Me.AcceptButton = Me.btnImport
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(432, 316)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.lblMyCheckbookLedgers)
        Me.Controls.Add(Me.lblMyCategories)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lstMyCategories)
        Me.Controls.Add(Me.lstImportCategories)
        Me.Controls.Add(Me.cbMyLedgers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportCategories"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Categories"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbMyLedgers As System.Windows.Forms.ComboBox
    Friend WithEvents lstImportCategories As System.Windows.Forms.ListBox
    Friend WithEvents lstMyCategories As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblMyCategories As System.Windows.Forms.Label
    Friend WithEvents lblMyCheckbookLedgers As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
End Class
