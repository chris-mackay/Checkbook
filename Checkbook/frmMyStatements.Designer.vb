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
Partial Class frmMyStatements
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMyStatements))
        Me.dgvMyStatements = New System.Windows.Forms.DataGridView()
        Me.cxmnuManageStatements = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxmnuNewStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuDeleteStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuRenameStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.cxmnuViewStatement = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnViewStatement = New System.Windows.Forms.Button()
        Me.btnRenameStatement = New System.Windows.Forms.Button()
        Me.btnDeleteStatement = New System.Windows.Forms.Button()
        Me.btnNewStatement = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.dgvMyStatements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxmnuManageStatements.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvMyStatements
        '
        Me.dgvMyStatements.AllowUserToAddRows = False
        Me.dgvMyStatements.AllowUserToDeleteRows = False
        Me.dgvMyStatements.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMyStatements.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMyStatements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMyStatements.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMyStatements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMyStatements.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMyStatements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMyStatements.ContextMenuStrip = Me.cxmnuManageStatements
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMyStatements.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMyStatements.GridColor = System.Drawing.Color.LightGray
        Me.dgvMyStatements.Location = New System.Drawing.Point(12, 12)
        Me.dgvMyStatements.MultiSelect = False
        Me.dgvMyStatements.Name = "dgvMyStatements"
        Me.dgvMyStatements.ReadOnly = True
        Me.dgvMyStatements.RowHeadersVisible = False
        Me.dgvMyStatements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyStatements.Size = New System.Drawing.Size(303, 397)
        Me.dgvMyStatements.TabIndex = 0
        '
        'cxmnuManageStatements
        '
        Me.cxmnuManageStatements.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxmnuNewStatement, Me.cxmnuDeleteStatement, Me.cxmnuRenameStatement, Me.cxmnuViewStatement})
        Me.cxmnuManageStatements.Name = "cxmnuManageStatements"
        Me.cxmnuManageStatements.Size = New System.Drawing.Size(184, 114)
        '
        'cxmnuNewStatement
        '
        Me.cxmnuNewStatement.Name = "cxmnuNewStatement"
        Me.cxmnuNewStatement.ShortcutKeyDisplayString = ""
        Me.cxmnuNewStatement.Size = New System.Drawing.Size(183, 22)
        Me.cxmnuNewStatement.Text = "&New Statement..."
        '
        'cxmnuDeleteStatement
        '
        Me.cxmnuDeleteStatement.Name = "cxmnuDeleteStatement"
        Me.cxmnuDeleteStatement.Size = New System.Drawing.Size(183, 22)
        Me.cxmnuDeleteStatement.Text = "&Delete Statement"
        '
        'cxmnuRenameStatement
        '
        Me.cxmnuRenameStatement.Name = "cxmnuRenameStatement"
        Me.cxmnuRenameStatement.Size = New System.Drawing.Size(183, 22)
        Me.cxmnuRenameStatement.Text = "&Rename Statement..."
        '
        'cxmnuViewStatement
        '
        Me.cxmnuViewStatement.Name = "cxmnuViewStatement"
        Me.cxmnuViewStatement.Size = New System.Drawing.Size(183, 22)
        Me.cxmnuViewStatement.Text = "&View Statement"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnViewStatement)
        Me.GroupBox1.Controls.Add(Me.btnRenameStatement)
        Me.GroupBox1.Controls.Add(Me.btnDeleteStatement)
        Me.GroupBox1.Controls.Add(Me.btnNewStatement)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(321, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(164, 170)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manage Statements"
        '
        'btnViewStatement
        '
        Me.btnViewStatement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewStatement.Location = New System.Drawing.Point(6, 122)
        Me.btnViewStatement.Name = "btnViewStatement"
        Me.btnViewStatement.Size = New System.Drawing.Size(152, 23)
        Me.btnViewStatement.TabIndex = 3
        Me.btnViewStatement.Text = "View Statement"
        Me.btnViewStatement.UseVisualStyleBackColor = True
        '
        'btnRenameStatement
        '
        Me.btnRenameStatement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRenameStatement.Location = New System.Drawing.Point(6, 93)
        Me.btnRenameStatement.Name = "btnRenameStatement"
        Me.btnRenameStatement.Size = New System.Drawing.Size(152, 23)
        Me.btnRenameStatement.TabIndex = 2
        Me.btnRenameStatement.Text = "Rename Statement"
        Me.btnRenameStatement.UseVisualStyleBackColor = True
        '
        'btnDeleteStatement
        '
        Me.btnDeleteStatement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeleteStatement.Location = New System.Drawing.Point(6, 64)
        Me.btnDeleteStatement.Name = "btnDeleteStatement"
        Me.btnDeleteStatement.Size = New System.Drawing.Size(152, 23)
        Me.btnDeleteStatement.TabIndex = 1
        Me.btnDeleteStatement.Text = "Delete Statement"
        Me.btnDeleteStatement.UseVisualStyleBackColor = True
        '
        'btnNewStatement
        '
        Me.btnNewStatement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNewStatement.Location = New System.Drawing.Point(6, 35)
        Me.btnNewStatement.Name = "btnNewStatement"
        Me.btnNewStatement.Size = New System.Drawing.Size(152, 23)
        Me.btnNewStatement.TabIndex = 0
        Me.btnNewStatement.Text = "New Statement"
        Me.btnNewStatement.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(410, 386)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmStatements
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(497, 421)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvMyStatements)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStatements"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "My Statements"
        CType(Me.dgvMyStatements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxmnuManageStatements.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvMyStatements As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnNewStatement As Button
    Friend WithEvents btnViewStatement As Button
    Friend WithEvents btnRenameStatement As Button
    Friend WithEvents btnDeleteStatement As Button
    Friend WithEvents cxmnuManageStatements As ContextMenuStrip
    Friend WithEvents cxmnuNewStatement As ToolStripMenuItem
    Friend WithEvents cxmnuDeleteStatement As ToolStripMenuItem
    Friend WithEvents cxmnuRenameStatement As ToolStripMenuItem
    Friend WithEvents cxmnuViewStatement As ToolStripMenuItem
End Class
