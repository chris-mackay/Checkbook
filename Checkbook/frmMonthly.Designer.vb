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
Partial Class frmMonthly
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMonthly))
        Me.dgvMonthly = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblChoose = New System.Windows.Forms.Label()
        Me.lblLedgerStatus = New System.Windows.Forms.Label()
        Me.txtLedgerStatus = New System.Windows.Forms.TextBox()
        CType(Me.dgvMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMonthly
        '
        Me.dgvMonthly.AllowUserToAddRows = False
        Me.dgvMonthly.AllowUserToDeleteRows = False
        Me.dgvMonthly.AllowUserToResizeColumns = False
        Me.dgvMonthly.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvMonthly.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMonthly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMonthly.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMonthly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMonthly.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvMonthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMonthly.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMonthly.GridColor = System.Drawing.Color.LightGray
        Me.dgvMonthly.Location = New System.Drawing.Point(12, 64)
        Me.dgvMonthly.Name = "dgvMonthly"
        Me.dgvMonthly.ReadOnly = True
        Me.dgvMonthly.RowHeadersVisible = False
        Me.dgvMonthly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMonthly.Size = New System.Drawing.Size(581, 285)
        Me.dgvMonthly.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(518, 360)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(12, 37)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(121, 21)
        Me.cbYear.TabIndex = 1
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(12, 21)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(68, 13)
        Me.lblYear.TabIndex = 0
        Me.lblYear.Text = "Filter by Year"
        '
        'lblChoose
        '
        Me.lblChoose.AutoSize = True
        Me.lblChoose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblChoose.Location = New System.Drawing.Point(139, 45)
        Me.lblChoose.Name = "lblChoose"
        Me.lblChoose.Size = New System.Drawing.Size(196, 13)
        Me.lblChoose.TabIndex = 2
        Me.lblChoose.Text = "Choose a year from the list to view totals"
        '
        'lblLedgerStatus
        '
        Me.lblLedgerStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLedgerStatus.AutoSize = True
        Me.lblLedgerStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblLedgerStatus.Location = New System.Drawing.Point(493, 22)
        Me.lblLedgerStatus.Name = "lblLedgerStatus"
        Me.lblLedgerStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblLedgerStatus.TabIndex = 3
        Me.lblLedgerStatus.Text = "Status"
        '
        'txtLedgerStatus
        '
        Me.txtLedgerStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLedgerStatus.Enabled = False
        Me.txtLedgerStatus.Location = New System.Drawing.Point(493, 38)
        Me.txtLedgerStatus.Name = "txtLedgerStatus"
        Me.txtLedgerStatus.ReadOnly = True
        Me.txtLedgerStatus.Size = New System.Drawing.Size(100, 20)
        Me.txtLedgerStatus.TabIndex = 4
        '
        'frmMonthly
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(605, 395)
        Me.Controls.Add(Me.lblLedgerStatus)
        Me.Controls.Add(Me.txtLedgerStatus)
        Me.Controls.Add(Me.lblChoose)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.cbYear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvMonthly)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMonthly"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Monthly Income"
        CType(Me.dgvMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvMonthly As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblChoose As System.Windows.Forms.Label
    Friend WithEvents lblLedgerStatus As System.Windows.Forms.Label
    Friend WithEvents txtLedgerStatus As System.Windows.Forms.TextBox
End Class
