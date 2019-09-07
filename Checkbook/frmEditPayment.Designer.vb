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
Partial Class frmEditPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditPayment))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtNewValue = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblPaymentAmount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(135, 61)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtNewValue
        '
        Me.txtNewValue.Location = New System.Drawing.Point(12, 35)
        Me.txtNewValue.Name = "txtNewValue"
        Me.txtNewValue.ShortcutsEnabled = False
        Me.txtNewValue.Size = New System.Drawing.Size(279, 20)
        Me.txtNewValue.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(216, 61)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPaymentAmount
        '
        Me.lblPaymentAmount.AutoSize = True
        Me.lblPaymentAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblPaymentAmount.Location = New System.Drawing.Point(12, 19)
        Me.lblPaymentAmount.Name = "lblPaymentAmount"
        Me.lblPaymentAmount.Size = New System.Drawing.Size(68, 13)
        Me.lblPaymentAmount.TabIndex = 0
        Me.lblPaymentAmount.Text = "New Amount"
        '
        'frmEditPayment
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(303, 96)
        Me.Controls.Add(Me.lblPaymentAmount)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtNewValue)
        Me.Controls.Add(Me.btnUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditPayment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Payment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtNewValue As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPaymentAmount As System.Windows.Forms.Label
End Class
