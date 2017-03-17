'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2017 Christopher Mackay

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
Partial Class frmBudgets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBudgets))
        Me.dgvBudgets = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.gbEditBudgets = New System.Windows.Forms.GroupBox()
        Me.btnAddAllCategories = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbViewBudgets = New System.Windows.Forms.GroupBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.cxmnuAdjustBudgets = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuCreateBudget = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuAddAllCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuEditBudget = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuDeleteBudget = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvBudgets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEditBudgets.SuspendLayout()
        Me.gbViewBudgets.SuspendLayout()
        Me.cxmnuAdjustBudgets.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvBudgets
        '
        Me.dgvBudgets.AllowUserToAddRows = False
        Me.dgvBudgets.AllowUserToDeleteRows = False
        Me.dgvBudgets.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvBudgets.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBudgets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBudgets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBudgets.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvBudgets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvBudgets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvBudgets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBudgets.ContextMenuStrip = Me.cxmnuAdjustBudgets
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBudgets.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBudgets.GridColor = System.Drawing.Color.LightGray
        Me.dgvBudgets.Location = New System.Drawing.Point(12, 12)
        Me.dgvBudgets.Name = "dgvBudgets"
        Me.dgvBudgets.RowHeadersVisible = False
        Me.dgvBudgets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvBudgets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBudgets.Size = New System.Drawing.Size(553, 397)
        Me.dgvBudgets.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(660, 386)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(579, 386)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'gbEditBudgets
        '
        Me.gbEditBudgets.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEditBudgets.Controls.Add(Me.btnAddAllCategories)
        Me.gbEditBudgets.Controls.Add(Me.btnDelete)
        Me.gbEditBudgets.Controls.Add(Me.btnEdit)
        Me.gbEditBudgets.Controls.Add(Me.btnAdd)
        Me.gbEditBudgets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbEditBudgets.Location = New System.Drawing.Point(571, 12)
        Me.gbEditBudgets.Name = "gbEditBudgets"
        Me.gbEditBudgets.Size = New System.Drawing.Size(164, 190)
        Me.gbEditBudgets.TabIndex = 1
        Me.gbEditBudgets.TabStop = False
        Me.gbEditBudgets.Text = "Adjust Budgets"
        '
        'btnAddAllCategories
        '
        Me.btnAddAllCategories.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddAllCategories.Location = New System.Drawing.Point(6, 69)
        Me.btnAddAllCategories.Name = "btnAddAllCategories"
        Me.btnAddAllCategories.Size = New System.Drawing.Size(152, 23)
        Me.btnAddAllCategories.TabIndex = 3
        Me.btnAddAllCategories.Text = "Add All Categories"
        Me.btnAddAllCategories.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(6, 127)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(152, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete Budget(s)"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(6, 98)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(152, 23)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit Budget(s)"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(6, 40)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(152, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Create Budget"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'gbViewBudgets
        '
        Me.gbViewBudgets.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbViewBudgets.Controls.Add(Me.lblMonth)
        Me.gbViewBudgets.Controls.Add(Me.lblYear)
        Me.gbViewBudgets.Controls.Add(Me.cbMonth)
        Me.gbViewBudgets.Controls.Add(Me.cbYear)
        Me.gbViewBudgets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbViewBudgets.Location = New System.Drawing.Point(571, 208)
        Me.gbViewBudgets.Name = "gbViewBudgets"
        Me.gbViewBudgets.Size = New System.Drawing.Size(164, 133)
        Me.gbViewBudgets.TabIndex = 4
        Me.gbViewBudgets.TabStop = False
        Me.gbViewBudgets.Text = "View Budgets"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(17, 68)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 6
        Me.lblMonth.Text = "Month"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(17, 28)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 5
        Me.lblYear.Text = "Year"
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cbMonth.Location = New System.Drawing.Point(17, 84)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(130, 21)
        Me.cbMonth.TabIndex = 4
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(17, 44)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(130, 21)
        Me.cbYear.TabIndex = 3
        '
        'cxmnuAdjustBudgets
        '
        Me.cxmnuAdjustBudgets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuCreateBudget, Me.cxmnuAddAllCategories, Me.cxmnuEditBudget, Me.cxmnuDeleteBudget})
        Me.cxmnuAdjustBudgets.Name = "cxmnuAdjustBudgets"
        Me.cxmnuAdjustBudgets.Size = New System.Drawing.Size(173, 92)
        '
        'cxmnuCreateBudget
        '
        Me.cxmnuCreateBudget.Name = "cxmnuCreateBudget"
        Me.cxmnuCreateBudget.Size = New System.Drawing.Size(172, 22)
        Me.cxmnuCreateBudget.Text = "Create Budget..."
        '
        'cxmnuAddAllCategories
        '
        Me.cxmnuAddAllCategories.Name = "cxmnuAddAllCategories"
        Me.cxmnuAddAllCategories.Size = New System.Drawing.Size(172, 22)
        Me.cxmnuAddAllCategories.Text = "Add All Categories"
        '
        'cxmnuEditBudget
        '
        Me.cxmnuEditBudget.Name = "cxmnuEditBudget"
        Me.cxmnuEditBudget.Size = New System.Drawing.Size(172, 22)
        Me.cxmnuEditBudget.Text = "Edit Budget(s)"
        '
        'cxmnuDeleteBudget
        '
        Me.cxmnuDeleteBudget.Name = "cxmnuDeleteBudget"
        Me.cxmnuDeleteBudget.Size = New System.Drawing.Size(172, 22)
        Me.cxmnuDeleteBudget.Text = "Delete Budget(s)"
        '
        'frmBudgets
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(747, 421)
        Me.Controls.Add(Me.gbViewBudgets)
        Me.Controls.Add(Me.gbEditBudgets)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.dgvBudgets)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(763, 460)
        Me.Name = "frmBudgets"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budgets"
        CType(Me.dgvBudgets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEditBudgets.ResumeLayout(False)
        Me.gbViewBudgets.ResumeLayout(False)
        Me.gbViewBudgets.PerformLayout()
        Me.cxmnuAdjustBudgets.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvBudgets As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents gbEditBudgets As GroupBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents gbViewBudgets As GroupBox
    Friend WithEvents lblMonth As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents btnAddAllCategories As Button
    Friend WithEvents cxmnuAdjustBudgets As ContextMenuStrip
    Friend WithEvents cxmnuCreateBudget As ToolStripMenuItem
    Friend WithEvents cxmnuAddAllCategories As ToolStripMenuItem
    Friend WithEvents cxmnuEditBudget As ToolStripMenuItem
    Friend WithEvents cxmnuDeleteBudget As ToolStripMenuItem
End Class
