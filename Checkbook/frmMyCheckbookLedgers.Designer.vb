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
Partial Class frmMyCheckbookLedgers
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMyCheckbookLedgers))
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
        Me.dgvMyLedgers = New System.Windows.Forms.DataGridView()
        Me.LedgerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbEditBudgets = New System.Windows.Forms.GroupBox()
        Me.btnNewLedger = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        CType(Me.dgvMyLedgers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEditBudgets.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOpen.Location = New System.Drawing.Point(579, 386)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "Open"
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(660, 386)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tmrTimer
        '
        Me.tmrTimer.Interval = 1000
        '
        'dgvMyLedgers
        '
        Me.dgvMyLedgers.AllowUserToAddRows = False
        Me.dgvMyLedgers.AllowUserToDeleteRows = False
        Me.dgvMyLedgers.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMyLedgers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMyLedgers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMyLedgers.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMyLedgers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMyLedgers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMyLedgers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMyLedgers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LedgerName, Me.DateModified})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMyLedgers.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMyLedgers.GridColor = System.Drawing.Color.LightGray
        Me.dgvMyLedgers.Location = New System.Drawing.Point(12, 12)
        Me.dgvMyLedgers.MultiSelect = False
        Me.dgvMyLedgers.Name = "dgvMyLedgers"
        Me.dgvMyLedgers.ReadOnly = True
        Me.dgvMyLedgers.RowHeadersVisible = False
        Me.dgvMyLedgers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyLedgers.Size = New System.Drawing.Size(553, 397)
        Me.dgvMyLedgers.TabIndex = 0
        '
        'LedgerName
        '
        Me.LedgerName.HeaderText = "My Checkbook Ledgers"
        Me.LedgerName.Name = "LedgerName"
        Me.LedgerName.ReadOnly = True
        '
        'DateModified
        '
        Me.DateModified.HeaderText = "Last Modified"
        Me.DateModified.Name = "DateModified"
        Me.DateModified.ReadOnly = True
        '
        'gbEditBudgets
        '
        Me.gbEditBudgets.Controls.Add(Me.btnNewLedger)
        Me.gbEditBudgets.Controls.Add(Me.btnRestore)
        Me.gbEditBudgets.Controls.Add(Me.btnCopy)
        Me.gbEditBudgets.Controls.Add(Me.btnRename)
        Me.gbEditBudgets.Controls.Add(Me.btnDelete)
        Me.gbEditBudgets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbEditBudgets.Location = New System.Drawing.Point(571, 12)
        Me.gbEditBudgets.Name = "gbEditBudgets"
        Me.gbEditBudgets.Size = New System.Drawing.Size(164, 198)
        Me.gbEditBudgets.TabIndex = 3
        Me.gbEditBudgets.TabStop = False
        Me.gbEditBudgets.Text = "Manage Ledgers"
        '
        'btnNewLedger
        '
        Me.btnNewLedger.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNewLedger.Location = New System.Drawing.Point(6, 35)
        Me.btnNewLedger.Name = "btnNewLedger"
        Me.btnNewLedger.Size = New System.Drawing.Size(152, 23)
        Me.btnNewLedger.TabIndex = 0
        Me.btnNewLedger.Text = "New Ledger"
        Me.btnNewLedger.UseVisualStyleBackColor = True
        '
        'btnRestore
        '
        Me.btnRestore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRestore.Location = New System.Drawing.Point(6, 151)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(152, 23)
        Me.btnRestore.TabIndex = 4
        Me.btnRestore.Text = "Restore Ledger"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCopy.Location = New System.Drawing.Point(6, 122)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(152, 23)
        Me.btnCopy.TabIndex = 3
        Me.btnCopy.Text = "Backup Ledger"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRename.Location = New System.Drawing.Point(6, 93)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(152, 23)
        Me.btnRename.TabIndex = 2
        Me.btnRename.Text = "Rename Ledger"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(6, 64)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(152, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete Ledger"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmMyCheckbookLedgers
        '
        Me.AcceptButton = Me.btnOpen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(747, 421)
        Me.Controls.Add(Me.gbEditBudgets)
        Me.Controls.Add(Me.dgvMyLedgers)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMyCheckbookLedgers"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "My Checkbook Ledgers"
        CType(Me.dgvMyLedgers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEditBudgets.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tmrTimer As System.Windows.Forms.Timer
    Friend WithEvents dgvMyLedgers As System.Windows.Forms.DataGridView
    Friend WithEvents LedgerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateModified As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbEditBudgets As GroupBox
    Friend WithEvents btnRestore As Button
    Friend WithEvents btnCopy As Button
    Friend WithEvents btnRename As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnNewLedger As Button
End Class
