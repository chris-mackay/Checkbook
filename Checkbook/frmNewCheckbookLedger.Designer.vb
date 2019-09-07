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
Partial Class frmNewCheckbookLedger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewCheckbookLedger))
        Me.txtStartBalance = New System.Windows.Forms.TextBox()
        Me.lblStartBalance = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.txtNewLedger = New System.Windows.Forms.TextBox()
        Me.lblNew = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtStartBalance
        '
        Me.txtStartBalance.Location = New System.Drawing.Point(12, 70)
        Me.txtStartBalance.Name = "txtStartBalance"
        Me.txtStartBalance.ShortcutsEnabled = False
        Me.txtStartBalance.Size = New System.Drawing.Size(279, 20)
        Me.txtStartBalance.TabIndex = 3
        '
        'lblStartBalance
        '
        Me.lblStartBalance.AutoSize = True
        Me.lblStartBalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblStartBalance.Location = New System.Drawing.Point(12, 54)
        Me.lblStartBalance.Name = "lblStartBalance"
        Me.lblStartBalance.Size = New System.Drawing.Size(85, 13)
        Me.lblStartBalance.TabIndex = 2
        Me.lblStartBalance.Text = "Starting Balance"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(216, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCreate.Enabled = False
        Me.btnCreate.Location = New System.Drawing.Point(135, 96)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 4
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'txtNewLedger
        '
        Me.txtNewLedger.Location = New System.Drawing.Point(12, 31)
        Me.txtNewLedger.Name = "txtNewLedger"
        Me.txtNewLedger.Size = New System.Drawing.Size(279, 20)
        Me.txtNewLedger.TabIndex = 1
        '
        'lblNew
        '
        Me.lblNew.AutoSize = True
        Me.lblNew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblNew.Location = New System.Drawing.Point(12, 15)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(71, 13)
        Me.lblNew.TabIndex = 0
        Me.lblNew.Text = "Ledger Name"
        '
        'frmNewCheckbookLedger
        '
        Me.AcceptButton = Me.btnCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(303, 131)
        Me.Controls.Add(Me.txtStartBalance)
        Me.Controls.Add(Me.lblStartBalance)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.txtNewLedger)
        Me.Controls.Add(Me.lblNew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewCheckbookLedger"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Ledger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStartBalance As System.Windows.Forms.TextBox
    Friend WithEvents lblStartBalance As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents txtNewLedger As System.Windows.Forms.TextBox
    Friend WithEvents lblNew As System.Windows.Forms.Label
End Class
