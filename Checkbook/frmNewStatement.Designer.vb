'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2018 Christopher Mackay

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
Partial Class frmNewStatement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewStatement))
        Me.txtStatementName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtStatementFile = New System.Windows.Forms.TextBox()
        Me.lblStatementFileName = New System.Windows.Forms.Label()
        Me.btnViewStatement = New System.Windows.Forms.Button()
        Me.btnRemoveStatement = New System.Windows.Forms.Button()
        Me.btnAddStatement = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtStatementName
        '
        Me.txtStatementName.Location = New System.Drawing.Point(12, 34)
        Me.txtStatementName.Name = "txtStatementName"
        Me.txtStatementName.Size = New System.Drawing.Size(279, 20)
        Me.txtStatementName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(12, 18)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(86, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Statement Name"
        '
        'txtStatementFile
        '
        Me.txtStatementFile.Enabled = False
        Me.txtStatementFile.Location = New System.Drawing.Point(12, 73)
        Me.txtStatementFile.Name = "txtStatementFile"
        Me.txtStatementFile.ReadOnly = True
        Me.txtStatementFile.Size = New System.Drawing.Size(279, 20)
        Me.txtStatementFile.TabIndex = 3
        '
        'lblStatementFileName
        '
        Me.lblStatementFileName.AutoSize = True
        Me.lblStatementFileName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblStatementFileName.Location = New System.Drawing.Point(12, 57)
        Me.lblStatementFileName.Name = "lblStatementFileName"
        Me.lblStatementFileName.Size = New System.Drawing.Size(74, 13)
        Me.lblStatementFileName.TabIndex = 2
        Me.lblStatementFileName.Text = "Statement File"
        '
        'btnViewStatement
        '
        Me.btnViewStatement.Image = Global.Checkbook.My.Resources.Resources.statement
        Me.btnViewStatement.Location = New System.Drawing.Point(207, 99)
        Me.btnViewStatement.Name = "btnViewStatement"
        Me.btnViewStatement.Size = New System.Drawing.Size(24, 24)
        Me.btnViewStatement.TabIndex = 4
        Me.btnViewStatement.UseVisualStyleBackColor = True
        '
        'btnRemoveStatement
        '
        Me.btnRemoveStatement.Image = Global.Checkbook.My.Resources.Resources.remove_statement
        Me.btnRemoveStatement.Location = New System.Drawing.Point(267, 99)
        Me.btnRemoveStatement.Name = "btnRemoveStatement"
        Me.btnRemoveStatement.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveStatement.TabIndex = 6
        Me.btnRemoveStatement.UseVisualStyleBackColor = True
        '
        'btnAddStatement
        '
        Me.btnAddStatement.Image = Global.Checkbook.My.Resources.Resources.add_statement
        Me.btnAddStatement.Location = New System.Drawing.Point(237, 99)
        Me.btnAddStatement.Name = "btnAddStatement"
        Me.btnAddStatement.Size = New System.Drawing.Size(24, 24)
        Me.btnAddStatement.TabIndex = 5
        Me.btnAddStatement.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(219, 136)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.Location = New System.Drawing.Point(138, 136)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 7
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'frmNewStatement
        '
        Me.AcceptButton = Me.btnCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(306, 171)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnViewStatement)
        Me.Controls.Add(Me.btnRemoveStatement)
        Me.Controls.Add(Me.btnAddStatement)
        Me.Controls.Add(Me.lblStatementFileName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtStatementFile)
        Me.Controls.Add(Me.txtStatementName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewStatement"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Statement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtStatementName As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtStatementFile As TextBox
    Friend WithEvents lblStatementFileName As Label
    Friend WithEvents btnViewStatement As Button
    Friend WithEvents btnRemoveStatement As Button
    Friend WithEvents btnAddStatement As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCreate As Button
End Class
