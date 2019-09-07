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
Partial Class frmCreateExpense
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateExpense))
        Me.txtMonthlyExpense = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblMonthlyExpense = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cbCategoriesPayees = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtMonthlyExpense
        '
        Me.txtMonthlyExpense.Location = New System.Drawing.Point(12, 70)
        Me.txtMonthlyExpense.Name = "txtMonthlyExpense"
        Me.txtMonthlyExpense.ShortcutsEnabled = False
        Me.txtMonthlyExpense.Size = New System.Drawing.Size(279, 20)
        Me.txtMonthlyExpense.TabIndex = 3
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(12, 14)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(49, 13)
        Me.lblCategory.TabIndex = 0
        Me.lblCategory.Text = "Category"
        '
        'lblMonthlyExpense
        '
        Me.lblMonthlyExpense.AutoSize = True
        Me.lblMonthlyExpense.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblMonthlyExpense.Location = New System.Drawing.Point(12, 54)
        Me.lblMonthlyExpense.Name = "lblMonthlyExpense"
        Me.lblMonthlyExpense.Size = New System.Drawing.Size(88, 13)
        Me.lblMonthlyExpense.TabIndex = 2
        Me.lblMonthlyExpense.Text = "Monthly Expense"
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
        'cbCategoriesPayees
        '
        Me.cbCategoriesPayees.FormattingEnabled = True
        Me.cbCategoriesPayees.Location = New System.Drawing.Point(12, 30)
        Me.cbCategoriesPayees.Name = "cbCategoriesPayees"
        Me.cbCategoriesPayees.Size = New System.Drawing.Size(279, 21)
        Me.cbCategoriesPayees.TabIndex = 1
        '
        'frmCreateExpense
        '
        Me.AcceptButton = Me.btnCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(303, 131)
        Me.Controls.Add(Me.cbCategoriesPayees)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.lblMonthlyExpense)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.txtMonthlyExpense)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateExpense"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Monthly Expense"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMonthlyExpense As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblMonthlyExpense As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbCategoriesPayees As ComboBox
End Class
