'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2021 Christopher Mackay

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
Partial Class frmTransaction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransaction))
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.txtPayment = New System.Windows.Forms.TextBox()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.dtpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.cbPayee = New System.Windows.Forms.ComboBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblTransDate = New System.Windows.Forms.Label()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.lblDeposit = New System.Windows.Forms.Label()
        Me.lblPayee = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.cbCleared = New System.Windows.Forms.CheckBox()
        Me.btnQuickCat = New System.Windows.Forms.Button()
        Me.btnQuickPayee = New System.Windows.Forms.Button()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.btnAttachReceipt = New System.Windows.Forms.Button()
        Me.lblReceipt = New System.Windows.Forms.Label()
        Me.txtReceipt = New System.Windows.Forms.TextBox()
        Me.btnRemoveReceipt = New System.Windows.Forms.Button()
        Me.btnViewReceipt = New System.Windows.Forms.Button()
        Me.lblStatement = New System.Windows.Forms.Label()
        Me.cbStatements = New System.Windows.Forms.ComboBox()
        Me.btnMyStatements = New System.Windows.Forms.Button()
        Me.btnViewStatement = New System.Windows.Forms.Button()
        Me.btnRemoveStatement = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbCategory
        '
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(92, 50)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(246, 21)
        Me.cbCategory.Sorted = True
        Me.cbCategory.TabIndex = 4
        '
        'txtPayment
        '
        Me.txtPayment.Location = New System.Drawing.Point(92, 103)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.ShortcutsEnabled = False
        Me.txtPayment.Size = New System.Drawing.Size(100, 20)
        Me.txtPayment.TabIndex = 9
        '
        'txtDeposit
        '
        Me.txtDeposit.Location = New System.Drawing.Point(92, 129)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.ShortcutsEnabled = False
        Me.txtDeposit.Size = New System.Drawing.Size(100, 20)
        Me.txtDeposit.TabIndex = 11
        '
        'dtpTransDate
        '
        Me.dtpTransDate.Location = New System.Drawing.Point(92, 77)
        Me.dtpTransDate.Name = "dtpTransDate"
        Me.dtpTransDate.Size = New System.Drawing.Size(246, 20)
        Me.dtpTransDate.TabIndex = 7
        '
        'cbPayee
        '
        Me.cbPayee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPayee.FormattingEnabled = True
        Me.cbPayee.Location = New System.Drawing.Point(92, 155)
        Me.cbPayee.Name = "cbPayee"
        Me.cbPayee.Size = New System.Drawing.Size(246, 21)
        Me.cbPayee.Sorted = True
        Me.cbPayee.TabIndex = 13
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(92, 182)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(246, 77)
        Me.txtDescription.TabIndex = 16
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCreate.Location = New System.Drawing.Point(217, 364)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 28
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(298, 364)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblType.Location = New System.Drawing.Point(17, 28)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(59, 13)
        Me.lblType.TabIndex = 0
        Me.lblType.Text = "Type Code"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(17, 54)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(49, 13)
        Me.lblCategory.TabIndex = 3
        Me.lblCategory.Text = "Category"
        '
        'lblTransDate
        '
        Me.lblTransDate.AutoSize = True
        Me.lblTransDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTransDate.Location = New System.Drawing.Point(17, 81)
        Me.lblTransDate.Name = "lblTransDate"
        Me.lblTransDate.Size = New System.Drawing.Size(30, 13)
        Me.lblTransDate.TabIndex = 6
        Me.lblTransDate.Text = "Date"
        '
        'lblPayment
        '
        Me.lblPayment.AutoSize = True
        Me.lblPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblPayment.Location = New System.Drawing.Point(17, 107)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(48, 13)
        Me.lblPayment.TabIndex = 8
        Me.lblPayment.Text = "Payment"
        '
        'lblDeposit
        '
        Me.lblDeposit.AutoSize = True
        Me.lblDeposit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblDeposit.Location = New System.Drawing.Point(17, 133)
        Me.lblDeposit.Name = "lblDeposit"
        Me.lblDeposit.Size = New System.Drawing.Size(43, 13)
        Me.lblDeposit.TabIndex = 10
        Me.lblDeposit.Text = "Deposit"
        '
        'lblPayee
        '
        Me.lblPayee.AutoSize = True
        Me.lblPayee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblPayee.Location = New System.Drawing.Point(17, 159)
        Me.lblPayee.Name = "lblPayee"
        Me.lblPayee.Size = New System.Drawing.Size(37, 13)
        Me.lblPayee.TabIndex = 12
        Me.lblPayee.Text = "Payee"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblDescription.Location = New System.Drawing.Point(17, 182)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 15
        Me.lblDescription.Text = "Description"
        '
        'btnInfo
        '
        Me.btnInfo.Image = CType(resources.GetObject("btnInfo.Image"), System.Drawing.Image)
        Me.btnInfo.Location = New System.Drawing.Point(198, 22)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(24, 24)
        Me.btnInfo.TabIndex = 2
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'cbCleared
        '
        Me.cbCleared.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbCleared.AutoSize = True
        Me.cbCleared.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.cbCleared.Location = New System.Drawing.Point(12, 370)
        Me.cbCleared.Name = "cbCleared"
        Me.cbCleared.Size = New System.Drawing.Size(62, 17)
        Me.cbCleared.TabIndex = 27
        Me.cbCleared.Text = "Cleared"
        Me.cbCleared.UseVisualStyleBackColor = True
        '
        'btnQuickCat
        '
        Me.btnQuickCat.Image = CType(resources.GetObject("btnQuickCat.Image"), System.Drawing.Image)
        Me.btnQuickCat.Location = New System.Drawing.Point(344, 48)
        Me.btnQuickCat.Name = "btnQuickCat"
        Me.btnQuickCat.Size = New System.Drawing.Size(24, 24)
        Me.btnQuickCat.TabIndex = 5
        Me.btnQuickCat.UseVisualStyleBackColor = True
        '
        'btnQuickPayee
        '
        Me.btnQuickPayee.Image = CType(resources.GetObject("btnQuickPayee.Image"), System.Drawing.Image)
        Me.btnQuickPayee.Location = New System.Drawing.Point(344, 153)
        Me.btnQuickPayee.Name = "btnQuickPayee"
        Me.btnQuickPayee.Size = New System.Drawing.Size(24, 24)
        Me.btnQuickPayee.TabIndex = 14
        Me.btnQuickPayee.UseVisualStyleBackColor = True
        '
        'cbType
        '
        Me.cbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"AD", "AP", "ATM", "BP", "DC", "T", "TD", "CRD"})
        Me.cbType.Location = New System.Drawing.Point(92, 24)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(100, 21)
        Me.cbType.TabIndex = 1
        '
        'btnAttachReceipt
        '
        Me.btnAttachReceipt.Image = CType(resources.GetObject("btnAttachReceipt.Image"), System.Drawing.Image)
        Me.btnAttachReceipt.Location = New System.Drawing.Point(122, 291)
        Me.btnAttachReceipt.Name = "btnAttachReceipt"
        Me.btnAttachReceipt.Size = New System.Drawing.Size(24, 24)
        Me.btnAttachReceipt.TabIndex = 20
        Me.btnAttachReceipt.UseVisualStyleBackColor = True
        '
        'lblReceipt
        '
        Me.lblReceipt.AutoSize = True
        Me.lblReceipt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblReceipt.Location = New System.Drawing.Point(17, 269)
        Me.lblReceipt.Name = "lblReceipt"
        Me.lblReceipt.Size = New System.Drawing.Size(44, 13)
        Me.lblReceipt.TabIndex = 17
        Me.lblReceipt.Text = "Receipt"
        '
        'txtReceipt
        '
        Me.txtReceipt.Location = New System.Drawing.Point(92, 265)
        Me.txtReceipt.Name = "txtReceipt"
        Me.txtReceipt.ReadOnly = True
        Me.txtReceipt.Size = New System.Drawing.Size(246, 20)
        Me.txtReceipt.TabIndex = 18
        '
        'btnRemoveReceipt
        '
        Me.btnRemoveReceipt.Image = CType(resources.GetObject("btnRemoveReceipt.Image"), System.Drawing.Image)
        Me.btnRemoveReceipt.Location = New System.Drawing.Point(152, 291)
        Me.btnRemoveReceipt.Name = "btnRemoveReceipt"
        Me.btnRemoveReceipt.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveReceipt.TabIndex = 21
        Me.btnRemoveReceipt.UseVisualStyleBackColor = True
        '
        'btnViewReceipt
        '
        Me.btnViewReceipt.Image = CType(resources.GetObject("btnViewReceipt.Image"), System.Drawing.Image)
        Me.btnViewReceipt.Location = New System.Drawing.Point(92, 291)
        Me.btnViewReceipt.Name = "btnViewReceipt"
        Me.btnViewReceipt.Size = New System.Drawing.Size(24, 24)
        Me.btnViewReceipt.TabIndex = 19
        Me.btnViewReceipt.UseVisualStyleBackColor = True
        '
        'lblStatement
        '
        Me.lblStatement.AutoSize = True
        Me.lblStatement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblStatement.Location = New System.Drawing.Point(17, 325)
        Me.lblStatement.Name = "lblStatement"
        Me.lblStatement.Size = New System.Drawing.Size(55, 13)
        Me.lblStatement.TabIndex = 22
        Me.lblStatement.Text = "Statement"
        '
        'cbStatements
        '
        Me.cbStatements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatements.FormattingEnabled = True
        Me.cbStatements.Location = New System.Drawing.Point(92, 321)
        Me.cbStatements.Name = "cbStatements"
        Me.cbStatements.Size = New System.Drawing.Size(246, 21)
        Me.cbStatements.Sorted = True
        Me.cbStatements.TabIndex = 23
        '
        'btnMyStatements
        '
        Me.btnMyStatements.Image = Global.Checkbook.My.Resources.Resources.img_manage_statements
        Me.btnMyStatements.Location = New System.Drawing.Point(344, 319)
        Me.btnMyStatements.Name = "btnMyStatements"
        Me.btnMyStatements.Size = New System.Drawing.Size(24, 24)
        Me.btnMyStatements.TabIndex = 24
        Me.btnMyStatements.UseVisualStyleBackColor = True
        '
        'btnViewStatement
        '
        Me.btnViewStatement.Image = Global.Checkbook.My.Resources.Resources.statement
        Me.btnViewStatement.Location = New System.Drawing.Point(92, 348)
        Me.btnViewStatement.Name = "btnViewStatement"
        Me.btnViewStatement.Size = New System.Drawing.Size(24, 24)
        Me.btnViewStatement.TabIndex = 25
        Me.btnViewStatement.UseVisualStyleBackColor = True
        '
        'btnRemoveStatement
        '
        Me.btnRemoveStatement.Image = Global.Checkbook.My.Resources.Resources.remove_statement
        Me.btnRemoveStatement.Location = New System.Drawing.Point(122, 348)
        Me.btnRemoveStatement.Name = "btnRemoveStatement"
        Me.btnRemoveStatement.Size = New System.Drawing.Size(24, 24)
        Me.btnRemoveStatement.TabIndex = 26
        Me.btnRemoveStatement.UseVisualStyleBackColor = True
        '
        'frmTransaction
        '
        Me.AcceptButton = Me.btnCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(385, 399)
        Me.Controls.Add(Me.btnMyStatements)
        Me.Controls.Add(Me.btnRemoveStatement)
        Me.Controls.Add(Me.btnViewStatement)
        Me.Controls.Add(Me.btnViewReceipt)
        Me.Controls.Add(Me.btnRemoveReceipt)
        Me.Controls.Add(Me.lblStatement)
        Me.Controls.Add(Me.lblReceipt)
        Me.Controls.Add(Me.txtReceipt)
        Me.Controls.Add(Me.btnAttachReceipt)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.btnQuickPayee)
        Me.Controls.Add(Me.btnQuickCat)
        Me.Controls.Add(Me.cbCleared)
        Me.Controls.Add(Me.btnInfo)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblPayee)
        Me.Controls.Add(Me.lblDeposit)
        Me.Controls.Add(Me.lblPayment)
        Me.Controls.Add(Me.lblTransDate)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.cbStatements)
        Me.Controls.Add(Me.cbPayee)
        Me.Controls.Add(Me.dtpTransDate)
        Me.Controls.Add(Me.txtDeposit)
        Me.Controls.Add(Me.txtPayment)
        Me.Controls.Add(Me.cbCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransaction"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Transaction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtPayment As System.Windows.Forms.TextBox
    Friend WithEvents txtDeposit As System.Windows.Forms.TextBox
    Friend WithEvents dtpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbPayee As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblTransDate As System.Windows.Forms.Label
    Friend WithEvents lblPayment As System.Windows.Forms.Label
    Friend WithEvents lblDeposit As System.Windows.Forms.Label
    Friend WithEvents lblPayee As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents btnInfo As System.Windows.Forms.Button
    Friend WithEvents cbCleared As System.Windows.Forms.CheckBox
    Friend WithEvents btnQuickCat As System.Windows.Forms.Button
    Friend WithEvents btnQuickPayee As System.Windows.Forms.Button
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents btnAttachReceipt As System.Windows.Forms.Button
    Friend WithEvents lblReceipt As System.Windows.Forms.Label
    Friend WithEvents txtReceipt As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveReceipt As System.Windows.Forms.Button
    Friend WithEvents btnViewReceipt As System.Windows.Forms.Button
    Friend WithEvents lblStatement As Label
    Friend WithEvents cbStatements As ComboBox
    Friend WithEvents btnMyStatements As Button
    Friend WithEvents btnViewStatement As Button
    Friend WithEvents btnRemoveStatement As Button
End Class
