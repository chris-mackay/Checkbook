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
Partial Class frmMostUsedCategoriesPayees
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMostUsedCategoriesPayees))
        Me.dgvMostUsed = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbFilterOptions = New System.Windows.Forms.GroupBox()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cbCategoriesPayees = New System.Windows.Forms.ComboBox()
        Me.lblFilterCategoriesPayees = New System.Windows.Forms.Label()
        CType(Me.dgvMostUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFilterOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvMostUsed
        '
        Me.dgvMostUsed.AllowUserToAddRows = False
        Me.dgvMostUsed.AllowUserToDeleteRows = False
        Me.dgvMostUsed.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMostUsed.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMostUsed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMostUsed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMostUsed.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMostUsed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMostUsed.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMostUsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMostUsed.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMostUsed.GridColor = System.Drawing.Color.LightGray
        Me.dgvMostUsed.Location = New System.Drawing.Point(12, 97)
        Me.dgvMostUsed.MultiSelect = False
        Me.dgvMostUsed.Name = "dgvMostUsed"
        Me.dgvMostUsed.RowHeadersVisible = False
        Me.dgvMostUsed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMostUsed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMostUsed.Size = New System.Drawing.Size(628, 426)
        Me.dgvMostUsed.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(565, 529)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbFilterOptions
        '
        Me.gbFilterOptions.Controls.Add(Me.cbYear)
        Me.gbFilterOptions.Controls.Add(Me.lblYear)
        Me.gbFilterOptions.Controls.Add(Me.cbCategoriesPayees)
        Me.gbFilterOptions.Controls.Add(Me.lblFilterCategoriesPayees)
        Me.gbFilterOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbFilterOptions.Location = New System.Drawing.Point(12, 12)
        Me.gbFilterOptions.Name = "gbFilterOptions"
        Me.gbFilterOptions.Size = New System.Drawing.Size(628, 79)
        Me.gbFilterOptions.TabIndex = 7
        Me.gbFilterOptions.TabStop = False
        Me.gbFilterOptions.Text = "Filter Options"
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(25, 37)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(121, 21)
        Me.cbYear.TabIndex = 2
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(25, 21)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 1
        Me.lblYear.Text = "Year"
        '
        'cbCategoriesPayees
        '
        Me.cbCategoriesPayees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoriesPayees.FormattingEnabled = True
        Me.cbCategoriesPayees.Items.AddRange(New Object() {"Categories", "Payees"})
        Me.cbCategoriesPayees.Location = New System.Drawing.Point(152, 37)
        Me.cbCategoriesPayees.Name = "cbCategoriesPayees"
        Me.cbCategoriesPayees.Size = New System.Drawing.Size(182, 21)
        Me.cbCategoriesPayees.TabIndex = 4
        '
        'lblFilterCategoriesPayees
        '
        Me.lblFilterCategoriesPayees.AutoSize = True
        Me.lblFilterCategoriesPayees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblFilterCategoriesPayees.Location = New System.Drawing.Point(152, 21)
        Me.lblFilterCategoriesPayees.Name = "lblFilterCategoriesPayees"
        Me.lblFilterCategoriesPayees.Size = New System.Drawing.Size(107, 13)
        Me.lblFilterCategoriesPayees.TabIndex = 3
        Me.lblFilterCategoriesPayees.Text = "Categories or Payees"
        '
        'frmMostUsedCategoriesPayees
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(652, 564)
        Me.Controls.Add(Me.gbFilterOptions)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvMostUsed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMostUsedCategoriesPayees"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Most Used Categories/Payees"
        CType(Me.dgvMostUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFilterOptions.ResumeLayout(False)
        Me.gbFilterOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvMostUsed As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents gbFilterOptions As GroupBox
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents lblYear As Label
    Friend WithEvents cbCategoriesPayees As ComboBox
    Friend WithEvents lblFilterCategoriesPayees As Label
End Class
