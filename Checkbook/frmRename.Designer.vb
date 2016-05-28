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
Partial Class frmRename
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRename))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.txtRename = New System.Windows.Forms.TextBox()
        Me.lblRename = New System.Windows.Forms.Label()
        Me.txtPrevious = New System.Windows.Forms.TextBox()
        Me.lblPrevious = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(216, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRename.Enabled = False
        Me.btnRename.Location = New System.Drawing.Point(135, 96)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(75, 23)
        Me.btnRename.TabIndex = 4
        Me.btnRename.Text = "Rename"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'txtRename
        '
        Me.txtRename.Location = New System.Drawing.Point(12, 70)
        Me.txtRename.Name = "txtRename"
        Me.txtRename.Size = New System.Drawing.Size(279, 20)
        Me.txtRename.TabIndex = 3
        '
        'lblRename
        '
        Me.lblRename.AutoSize = True
        Me.lblRename.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblRename.Location = New System.Drawing.Point(12, 54)
        Me.lblRename.Name = "lblRename"
        Me.lblRename.Size = New System.Drawing.Size(29, 13)
        Me.lblRename.TabIndex = 2
        Me.lblRename.Text = "New"
        '
        'txtPrevious
        '
        Me.txtPrevious.Enabled = False
        Me.txtPrevious.Location = New System.Drawing.Point(12, 31)
        Me.txtPrevious.Name = "txtPrevious"
        Me.txtPrevious.ReadOnly = True
        Me.txtPrevious.Size = New System.Drawing.Size(279, 20)
        Me.txtPrevious.TabIndex = 1
        '
        'lblPrevious
        '
        Me.lblPrevious.AutoSize = True
        Me.lblPrevious.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblPrevious.Location = New System.Drawing.Point(12, 15)
        Me.lblPrevious.Name = "lblPrevious"
        Me.lblPrevious.Size = New System.Drawing.Size(48, 13)
        Me.lblPrevious.TabIndex = 0
        Me.lblPrevious.Text = "Previous"
        '
        'frmRename
        '
        Me.AcceptButton = Me.btnRename
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(303, 131)
        Me.Controls.Add(Me.txtPrevious)
        Me.Controls.Add(Me.lblPrevious)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRename)
        Me.Controls.Add(Me.txtRename)
        Me.Controls.Add(Me.lblRename)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRename"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRename As System.Windows.Forms.Button
    Friend WithEvents txtRename As System.Windows.Forms.TextBox
    Friend WithEvents lblRename As System.Windows.Forms.Label
    Friend WithEvents txtPrevious As System.Windows.Forms.TextBox
    Friend WithEvents lblPrevious As System.Windows.Forms.Label
End Class
