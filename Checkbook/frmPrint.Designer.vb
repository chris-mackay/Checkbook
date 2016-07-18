<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.prtPreview = New System.Windows.Forms.PrintPreviewControl()
        Me.lblPrinters = New System.Windows.Forms.Label()
        Me.cbPrinters = New System.Windows.Forms.ComboBox()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.gbPrinters = New System.Windows.Forms.GroupBox()
        Me.gbPrint = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbPrinters.SuspendLayout()
        Me.gbPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'prtPreview
        '
        Me.prtPreview.BackColor = System.Drawing.SystemColors.ControlLight
        Me.prtPreview.Location = New System.Drawing.Point(12, 99)
        Me.prtPreview.Name = "prtPreview"
        Me.prtPreview.Size = New System.Drawing.Size(823, 498)
        Me.prtPreview.TabIndex = 2
        '
        'lblPrinters
        '
        Me.lblPrinters.AutoSize = True
        Me.lblPrinters.Location = New System.Drawing.Point(17, 21)
        Me.lblPrinters.Name = "lblPrinters"
        Me.lblPrinters.Size = New System.Drawing.Size(42, 13)
        Me.lblPrinters.TabIndex = 0
        Me.lblPrinters.Text = "Printers"
        '
        'cbPrinters
        '
        Me.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrinters.FormattingEnabled = True
        Me.cbPrinters.Location = New System.Drawing.Point(17, 37)
        Me.cbPrinters.Name = "cbPrinters"
        Me.cbPrinters.Size = New System.Drawing.Size(245, 21)
        Me.cbPrinters.Sorted = True
        Me.cbPrinters.TabIndex = 1
        '
        'btnPageSetup
        '
        Me.btnPageSetup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPageSetup.Location = New System.Drawing.Point(24, 36)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(152, 23)
        Me.btnPageSetup.TabIndex = 0
        Me.btnPageSetup.Text = "Page Setup"
        Me.btnPageSetup.UseVisualStyleBackColor = True
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrintPreview.Location = New System.Drawing.Point(182, 36)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(152, 23)
        Me.btnPrintPreview.TabIndex = 1
        Me.btnPrintPreview.Text = "Print Preview"
        Me.btnPrintPreview.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(340, 36)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(152, 23)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "Print Chart"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'gbPrinters
        '
        Me.gbPrinters.Controls.Add(Me.cbPrinters)
        Me.gbPrinters.Controls.Add(Me.lblPrinters)
        Me.gbPrinters.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbPrinters.Location = New System.Drawing.Point(12, 12)
        Me.gbPrinters.Name = "gbPrinters"
        Me.gbPrinters.Size = New System.Drawing.Size(295, 81)
        Me.gbPrinters.TabIndex = 0
        Me.gbPrinters.TabStop = False
        Me.gbPrinters.Text = "Select a printer"
        '
        'gbPrint
        '
        Me.gbPrint.Controls.Add(Me.btnPrintPreview)
        Me.gbPrint.Controls.Add(Me.btnPrint)
        Me.gbPrint.Controls.Add(Me.btnPageSetup)
        Me.gbPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbPrint.Location = New System.Drawing.Point(313, 12)
        Me.gbPrint.Name = "gbPrint"
        Me.gbPrint.Size = New System.Drawing.Size(522, 81)
        Me.gbPrint.TabIndex = 1
        Me.gbPrint.TabStop = False
        Me.gbPrint.Text = "Print"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(763, 609)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(850, 644)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gbPrint)
        Me.Controls.Add(Me.gbPrinters)
        Me.Controls.Add(Me.prtPreview)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Chart"
        Me.gbPrinters.ResumeLayout(False)
        Me.gbPrinters.PerformLayout()
        Me.gbPrint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents prtPreview As PrintPreviewControl
    Friend WithEvents lblPrinters As Label
    Friend WithEvents cbPrinters As ComboBox
    Friend WithEvents btnPageSetup As Button
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents gbPrinters As GroupBox
    Friend WithEvents gbPrint As GroupBox
    Friend WithEvents btnClose As Button
End Class
