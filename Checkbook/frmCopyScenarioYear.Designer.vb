<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyScenarioYear
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblScenario = New System.Windows.Forms.Label()
        Me.cbScenario = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cbYears = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(226, 84)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(145, 84)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblScenario
        '
        Me.lblScenario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblScenario.AutoSize = True
        Me.lblScenario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblScenario.Location = New System.Drawing.Point(12, 61)
        Me.lblScenario.Name = "lblScenario"
        Me.lblScenario.Size = New System.Drawing.Size(77, 13)
        Me.lblScenario.TabIndex = 2
        Me.lblScenario.Text = "Copy year into:"
        '
        'cbScenario
        '
        Me.cbScenario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbScenario.FormattingEnabled = True
        Me.cbScenario.Location = New System.Drawing.Point(103, 57)
        Me.cbScenario.Name = "cbScenario"
        Me.cbScenario.Size = New System.Drawing.Size(198, 21)
        Me.cbScenario.Sorted = True
        Me.cbScenario.TabIndex = 3
        '
        'lblYear
        '
        Me.lblYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(12, 21)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(70, 13)
        Me.lblYear.TabIndex = 0
        Me.lblYear.Text = "Year to copy:"
        '
        'cbYears
        '
        Me.cbYears.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYears.FormattingEnabled = True
        Me.cbYears.Location = New System.Drawing.Point(103, 17)
        Me.cbYears.Name = "cbYears"
        Me.cbYears.Size = New System.Drawing.Size(198, 21)
        Me.cbYears.Sorted = True
        Me.cbYears.TabIndex = 1
        '
        'frmCopyScenarioYear
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(313, 119)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.cbYears)
        Me.Controls.Add(Me.lblScenario)
        Me.Controls.Add(Me.cbScenario)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCopyScenarioYear"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copy Year From Scenario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents lblScenario As Label
    Friend WithEvents cbScenario As ComboBox
    Friend WithEvents lblYear As Label
    Friend WithEvents cbYears As ComboBox
End Class
