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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMyScenarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMyScenarios))
        Me.gbManageLedgers = New System.Windows.Forms.GroupBox()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.btnCopyYear = New System.Windows.Forms.Button()
        Me.btnDuplicateScenario = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvMyScenarios = New System.Windows.Forms.DataGridView()
        Me.LedgerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cxmnuManageScenarios = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuDeleteScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRenameScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cxmnuDuplicateScenario = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuCopyYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbManageLedgers.SuspendLayout()
        CType(Me.dgvMyScenarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxmnuManageScenarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbManageLedgers
        '
        Me.gbManageLedgers.Controls.Add(Me.btnRename)
        Me.gbManageLedgers.Controls.Add(Me.btnCopyYear)
        Me.gbManageLedgers.Controls.Add(Me.btnDuplicateScenario)
        Me.gbManageLedgers.Controls.Add(Me.btnDelete)
        Me.gbManageLedgers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbManageLedgers.Location = New System.Drawing.Point(571, 12)
        Me.gbManageLedgers.Name = "gbManageLedgers"
        Me.gbManageLedgers.Size = New System.Drawing.Size(164, 168)
        Me.gbManageLedgers.TabIndex = 1
        Me.gbManageLedgers.TabStop = False
        Me.gbManageLedgers.Text = "Manage Scenarios"
        '
        'btnRename
        '
        Me.btnRename.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRename.Location = New System.Drawing.Point(6, 60)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(152, 23)
        Me.btnRename.TabIndex = 1
        Me.btnRename.Text = "Rename Scenario"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'btnCopyYear
        '
        Me.btnCopyYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCopyYear.Location = New System.Drawing.Point(6, 118)
        Me.btnCopyYear.Name = "btnCopyYear"
        Me.btnCopyYear.Size = New System.Drawing.Size(152, 23)
        Me.btnCopyYear.TabIndex = 3
        Me.btnCopyYear.Text = "Copy Year From Scenario"
        Me.btnCopyYear.UseVisualStyleBackColor = True
        '
        'btnDuplicateScenario
        '
        Me.btnDuplicateScenario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDuplicateScenario.Location = New System.Drawing.Point(6, 89)
        Me.btnDuplicateScenario.Name = "btnDuplicateScenario"
        Me.btnDuplicateScenario.Size = New System.Drawing.Size(152, 23)
        Me.btnDuplicateScenario.TabIndex = 2
        Me.btnDuplicateScenario.Text = "Duplicate Scenario"
        Me.btnDuplicateScenario.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(6, 31)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(152, 23)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "Delete Scenario"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'dgvMyScenarios
        '
        Me.dgvMyScenarios.AllowUserToAddRows = False
        Me.dgvMyScenarios.AllowUserToDeleteRows = False
        Me.dgvMyScenarios.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMyScenarios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMyScenarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMyScenarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMyScenarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMyScenarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMyScenarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMyScenarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LedgerName, Me.DateModified})
        Me.dgvMyScenarios.ContextMenuStrip = Me.cxmnuManageScenarios
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMyScenarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMyScenarios.GridColor = System.Drawing.Color.LightGray
        Me.dgvMyScenarios.Location = New System.Drawing.Point(12, 12)
        Me.dgvMyScenarios.MultiSelect = False
        Me.dgvMyScenarios.Name = "dgvMyScenarios"
        Me.dgvMyScenarios.ReadOnly = True
        Me.dgvMyScenarios.RowHeadersVisible = False
        Me.dgvMyScenarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyScenarios.Size = New System.Drawing.Size(553, 397)
        Me.dgvMyScenarios.TabIndex = 0
        '
        'LedgerName
        '
        Me.LedgerName.HeaderText = "My Scenarios"
        Me.LedgerName.Name = "LedgerName"
        Me.LedgerName.ReadOnly = True
        '
        'DateModified
        '
        Me.DateModified.HeaderText = "Last Modified"
        Me.DateModified.Name = "DateModified"
        Me.DateModified.ReadOnly = True
        '
        'cxmnuManageScenarios
        '
        Me.cxmnuManageScenarios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuDeleteScenario, Me.cxmnuRenameScenario, Me.cxmnuDuplicateScenario, Me.cxmnuCopyYear})
        Me.cxmnuManageScenarios.Name = "cxmnuManageLedgers"
        Me.cxmnuManageScenarios.Size = New System.Drawing.Size(207, 92)
        '
        'cxmnuDeleteScenario
        '
        Me.cxmnuDeleteScenario.Name = "cxmnuDeleteScenario"
        Me.cxmnuDeleteScenario.Size = New System.Drawing.Size(206, 22)
        Me.cxmnuDeleteScenario.Text = "&Delete Scenario"
        '
        'cxmnuRenameScenario
        '
        Me.cxmnuRenameScenario.Name = "cxmnuRenameScenario"
        Me.cxmnuRenameScenario.Size = New System.Drawing.Size(206, 22)
        Me.cxmnuRenameScenario.Text = "&Rename Scenario..."
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOpen.Location = New System.Drawing.Point(579, 386)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
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
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cxmnuDuplicateScenario
        '
        Me.cxmnuDuplicateScenario.Name = "cxmnuDuplicateScenario"
        Me.cxmnuDuplicateScenario.Size = New System.Drawing.Size(206, 22)
        Me.cxmnuDuplicateScenario.Text = "Du&plicate Scenario"
        '
        'cxmnuCopyYear
        '
        Me.cxmnuCopyYear.Name = "cxmnuCopyYear"
        Me.cxmnuCopyYear.Size = New System.Drawing.Size(206, 22)
        Me.cxmnuCopyYear.Text = "&Copy Year From Scenario"
        '
        'frmMyScenarios
        '
        Me.AcceptButton = Me.btnOpen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(747, 421)
        Me.Controls.Add(Me.gbManageLedgers)
        Me.Controls.Add(Me.dgvMyScenarios)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMyScenarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "My Scenarios"
        Me.gbManageLedgers.ResumeLayout(False)
        CType(Me.dgvMyScenarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxmnuManageScenarios.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbManageLedgers As GroupBox
    Friend WithEvents btnRename As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents dgvMyScenarios As DataGridView
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents LedgerName As DataGridViewTextBoxColumn
    Friend WithEvents DateModified As DataGridViewTextBoxColumn
    Friend WithEvents cxmnuManageScenarios As ContextMenuStrip
    Friend WithEvents cxmnuDeleteScenario As ToolStripMenuItem
    Friend WithEvents cxmnuRenameScenario As ToolStripMenuItem
    Friend WithEvents btnCopyYear As Button
    Friend WithEvents btnDuplicateScenario As Button
    Friend WithEvents cxmnuDuplicateScenario As ToolStripMenuItem
    Friend WithEvents cxmnuCopyYear As ToolStripMenuItem
End Class
