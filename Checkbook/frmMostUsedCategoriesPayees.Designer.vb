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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvMostUsed = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cbCategoriesPayees = New System.Windows.Forms.ComboBox()
        Me.lblFilterCategoriesPayees = New System.Windows.Forms.Label()
        CType(Me.dgvMostUsed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMostUsed
        '
        Me.dgvMostUsed.AllowUserToAddRows = False
        Me.dgvMostUsed.AllowUserToDeleteRows = False
        Me.dgvMostUsed.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMostUsed.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMostUsed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMostUsed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMostUsed.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMostUsed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMostUsed.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMostUsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMostUsed.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMostUsed.GridColor = System.Drawing.Color.LightGray
        Me.dgvMostUsed.Location = New System.Drawing.Point(12, 52)
        Me.dgvMostUsed.MultiSelect = False
        Me.dgvMostUsed.Name = "dgvMostUsed"
        Me.dgvMostUsed.RowHeadersVisible = False
        Me.dgvMostUsed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMostUsed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMostUsed.Size = New System.Drawing.Size(800, 460)
        Me.dgvMostUsed.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(737, 518)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cbCategoriesPayees
        '
        Me.cbCategoriesPayees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoriesPayees.FormattingEnabled = True
        Me.cbCategoriesPayees.Items.AddRange(New Object() {"Categories", "Payees"})
        Me.cbCategoriesPayees.Location = New System.Drawing.Point(12, 25)
        Me.cbCategoriesPayees.Name = "cbCategoriesPayees"
        Me.cbCategoriesPayees.Size = New System.Drawing.Size(182, 21)
        Me.cbCategoriesPayees.TabIndex = 4
        '
        'lblFilterCategoriesPayees
        '
        Me.lblFilterCategoriesPayees.AutoSize = True
        Me.lblFilterCategoriesPayees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblFilterCategoriesPayees.Location = New System.Drawing.Point(12, 9)
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
        Me.ClientSize = New System.Drawing.Size(824, 553)
        Me.Controls.Add(Me.cbCategoriesPayees)
        Me.Controls.Add(Me.lblFilterCategoriesPayees)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvMostUsed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMostUsedCategoriesPayees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Most Used Categories & Payees"
        CType(Me.dgvMostUsed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvMostUsed As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents cbCategoriesPayees As ComboBox
    Friend WithEvents lblFilterCategoriesPayees As Label
End Class
