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
Partial Class frmCustomizeToolbar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomizeToolbar))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgvIcons = New System.Windows.Forms.DataGridView()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.gbAdjust = New System.Windows.Forms.GroupBox()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnUncheckAll = New System.Windows.Forms.Button()
        CType(Me.dgvIcons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAdjust.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(535, 386)
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
        Me.btnOK.Location = New System.Drawing.Point(454, 386)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dgvIcons
        '
        Me.dgvIcons.AllowUserToAddRows = False
        Me.dgvIcons.AllowUserToDeleteRows = False
        Me.dgvIcons.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvIcons.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIcons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIcons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIcons.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvIcons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIcons.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvIcons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIcons.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIcons.GridColor = System.Drawing.Color.LightGray
        Me.dgvIcons.Location = New System.Drawing.Point(12, 12)
        Me.dgvIcons.MultiSelect = False
        Me.dgvIcons.Name = "dgvIcons"
        Me.dgvIcons.RowHeadersVisible = False
        Me.dgvIcons.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvIcons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIcons.Size = New System.Drawing.Size(428, 397)
        Me.dgvIcons.TabIndex = 0
        '
        'btnDown
        '
        Me.btnDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDown.Location = New System.Drawing.Point(6, 72)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(152, 23)
        Me.btnDown.TabIndex = 1
        Me.btnDown.Text = "Move Down"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUp.Location = New System.Drawing.Point(6, 43)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(152, 23)
        Me.btnUp.TabIndex = 0
        Me.btnUp.Text = "Move Up"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDefault
        '
        Me.btnDefault.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDefault.Location = New System.Drawing.Point(6, 159)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(152, 23)
        Me.btnDefault.TabIndex = 4
        Me.btnDefault.Text = "Restore Default"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'gbAdjust
        '
        Me.gbAdjust.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.gbAdjust.Controls.Add(Me.btnUncheckAll)
        Me.gbAdjust.Controls.Add(Me.btnUp)
        Me.gbAdjust.Controls.Add(Me.btnDefault)
        Me.gbAdjust.Controls.Add(Me.btnDown)
        Me.gbAdjust.Controls.Add(Me.btnCheckAll)
        Me.gbAdjust.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbAdjust.Location = New System.Drawing.Point(446, 12)
        Me.gbAdjust.Name = "gbAdjust"
        Me.gbAdjust.Size = New System.Drawing.Size(164, 209)
        Me.gbAdjust.TabIndex = 1
        Me.gbAdjust.TabStop = False
        Me.gbAdjust.Text = "Adjust Buttons"
        '
        'btnCheckAll
        '
        Me.btnCheckAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCheckAll.Location = New System.Drawing.Point(6, 101)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(152, 23)
        Me.btnCheckAll.TabIndex = 2
        Me.btnCheckAll.Text = "Check All Buttons"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUncheckAll.Location = New System.Drawing.Point(6, 130)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(152, 23)
        Me.btnUncheckAll.TabIndex = 3
        Me.btnUncheckAll.Text = "Uncheck All Buttons"
        Me.btnUncheckAll.UseVisualStyleBackColor = True
        '
        'frmCustomizeToolbar
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(622, 421)
        Me.Controls.Add(Me.gbAdjust)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dgvIcons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomizeToolbar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customize Toolbar"
        CType(Me.dgvIcons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAdjust.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents dgvIcons As DataGridView
    Friend WithEvents btnDown As Button
    Friend WithEvents btnUp As Button
    Friend WithEvents btnDefault As Button
    Friend WithEvents gbAdjust As GroupBox
    Friend WithEvents btnUncheckAll As Button
    Friend WithEvents btnCheckAll As Button
End Class
