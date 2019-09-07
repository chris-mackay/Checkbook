﻿'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportPayees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportPayees))
        Me.cbMyLedgers = New System.Windows.Forms.ComboBox()
        Me.lstImportPayees = New System.Windows.Forms.ListBox()
        Me.lstMyPayees = New System.Windows.Forms.ListBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblMyPayees = New System.Windows.Forms.Label()
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
        'lstImportPayees
        '
        Me.lstImportPayees.FormattingEnabled = True
        Me.lstImportPayees.HorizontalScrollbar = True
        Me.lstImportPayees.Location = New System.Drawing.Point(12, 59)
        Me.lstImportPayees.Name = "lstImportPayees"
        Me.lstImportPayees.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstImportPayees.Size = New System.Drawing.Size(184, 212)
        Me.lstImportPayees.Sorted = True
        Me.lstImportPayees.TabIndex = 2
        '
        'lstMyPayees
        '
        Me.lstMyPayees.FormattingEnabled = True
        Me.lstMyPayees.HorizontalScrollbar = True
        Me.lstMyPayees.Location = New System.Drawing.Point(236, 59)
        Me.lstMyPayees.Name = "lstMyPayees"
        Me.lstMyPayees.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstMyPayees.Size = New System.Drawing.Size(184, 212)
        Me.lstMyPayees.Sorted = True
        Me.lstMyPayees.TabIndex = 6
        '
        'btnCancel
        '
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
        'lblMyPayees
        '
        Me.lblMyPayees.AutoSize = True
        Me.lblMyPayees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblMyPayees.Location = New System.Drawing.Point(236, 43)
        Me.lblMyPayees.Name = "lblMyPayees"
        Me.lblMyPayees.Size = New System.Drawing.Size(59, 13)
        Me.lblMyPayees.TabIndex = 5
        Me.lblMyPayees.Text = "My Payees"
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
        'frmImportPayees
        '
        Me.AcceptButton = Me.btnImport
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(432, 316)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.lblMyCheckbookLedgers)
        Me.Controls.Add(Me.lblMyPayees)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lstMyPayees)
        Me.Controls.Add(Me.lstImportPayees)
        Me.Controls.Add(Me.cbMyLedgers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportPayees"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Payees"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbMyLedgers As System.Windows.Forms.ComboBox
    Friend WithEvents lstImportPayees As System.Windows.Forms.ListBox
    Friend WithEvents lstMyPayees As System.Windows.Forms.ListBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblMyPayees As System.Windows.Forms.Label
    Friend WithEvents lblMyCheckbookLedgers As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
End Class
