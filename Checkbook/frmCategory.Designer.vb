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
Partial Class frmCategory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategory))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lstCategories = New System.Windows.Forms.ListBox()
        Me.tsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnCreate = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnRename = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.btnSweep = New System.Windows.Forms.ToolStripButton()
        Me.lblItemCount = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.tsToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(177, 316)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(0, 16)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(237, 20)
        Me.txtSearch.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(1, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(41, 13)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstCategories)
        Me.Panel1.Controls.Add(Me.lblSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Location = New System.Drawing.Point(15, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 267)
        Me.Panel1.TabIndex = 1
        '
        'lstCategories
        '
        Me.lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstCategories.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstCategories.FormattingEnabled = True
        Me.lstCategories.HorizontalScrollbar = True
        Me.lstCategories.Location = New System.Drawing.Point(0, 44)
        Me.lstCategories.Name = "lstCategories"
        Me.lstCategories.Size = New System.Drawing.Size(237, 223)
        Me.lstCategories.Sorted = True
        Me.lstCategories.TabIndex = 2
        '
        'tsToolStrip
        '
        Me.tsToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsToolStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCreate, Me.btnDelete, Me.btnRename, Me.btnSearch, Me.btnImport, Me.btnSweep})
        Me.tsToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.tsToolStrip.Name = "tsToolStrip"
        Me.tsToolStrip.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.tsToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsToolStrip.Size = New System.Drawing.Size(267, 25)
        Me.tsToolStrip.TabIndex = 0
        '
        'btnCreate
        '
        Me.btnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCreate.Image = CType(resources.GetObject("btnCreate.Image"), System.Drawing.Image)
        Me.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(23, 22)
        Me.btnCreate.Text = "Create Category"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Delete Category"
        '
        'btnRename
        '
        Me.btnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRename.Image = CType(resources.GetObject("btnRename.Image"), System.Drawing.Image)
        Me.btnRename.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(23, 22)
        Me.btnRename.Text = "Rename Category"
        '
        'btnSearch
        '
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(23, 22)
        Me.btnSearch.Text = "Search List"
        '
        'btnImport
        '
        Me.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(23, 22)
        Me.btnImport.Text = "Import"
        '
        'btnSweep
        '
        Me.btnSweep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSweep.Image = CType(resources.GetObject("btnSweep.Image"), System.Drawing.Image)
        Me.btnSweep.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSweep.Name = "btnSweep"
        Me.btnSweep.Size = New System.Drawing.Size(23, 22)
        Me.btnSweep.Text = "Delete Unused"
        '
        'lblItemCount
        '
        Me.lblItemCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblItemCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblItemCount.Location = New System.Drawing.Point(16, 326)
        Me.lblItemCount.Name = "lblItemCount"
        Me.lblItemCount.Size = New System.Drawing.Size(155, 13)
        Me.lblItemCount.TabIndex = 2
        Me.lblItemCount.Text = "ItemCount"
        '
        'frmCategory
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(267, 350)
        Me.Controls.Add(Me.lblItemCount)
        Me.Controls.Add(Me.tsToolStrip)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCategory"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Categories"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsToolStrip.ResumeLayout(False)
        Me.tsToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstCategories As System.Windows.Forms.ListBox
    Friend WithEvents tsToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCreate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRename As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSweep As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
End Class
