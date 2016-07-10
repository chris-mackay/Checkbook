<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCharts
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCharts))
        Me.MyChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.rbNotExploded = New System.Windows.Forms.RadioButton()
        Me.rbExploded = New System.Windows.Forms.RadioButton()
        Me.gbColors = New System.Windows.Forms.GroupBox()
        Me.lblColorPalette = New System.Windows.Forms.Label()
        Me.cbColorPalette = New System.Windows.Forms.ComboBox()
        Me.btnBackColor = New System.Windows.Forms.Button()
        Me.gbChartType = New System.Windows.Forms.GroupBox()
        Me.cbChartType = New System.Windows.Forms.ComboBox()
        Me.gbPrint = New System.Windows.Forms.GroupBox()
        Me.cbPrinters = New System.Windows.Forms.ComboBox()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lblPrinters = New System.Windows.Forms.Label()
        CType(Me.MyChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbView.SuspendLayout()
        Me.gbColors.SuspendLayout()
        Me.gbChartType.SuspendLayout()
        Me.gbPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyChart
        '
        Me.MyChart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyChart.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.MyChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "ChartArea1"
        Me.MyChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.MyChart.Legends.Add(Legend1)
        Me.MyChart.Location = New System.Drawing.Point(12, 94)
        Me.MyChart.Name = "MyChart"
        Me.MyChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series1.Legend = "Legend1"
        Series1.Name = "Categories"
        Me.MyChart.Series.Add(Series1)
        Me.MyChart.Size = New System.Drawing.Size(1282, 750)
        Me.MyChart.TabIndex = 4
        '
        'gbView
        '
        Me.gbView.Controls.Add(Me.rbNotExploded)
        Me.gbView.Controls.Add(Me.rbExploded)
        Me.gbView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbView.Location = New System.Drawing.Point(12, 9)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(160, 76)
        Me.gbView.TabIndex = 0
        Me.gbView.TabStop = False
        Me.gbView.Text = "Chart View"
        '
        'rbNotExploded
        '
        Me.rbNotExploded.AutoSize = True
        Me.rbNotExploded.Location = New System.Drawing.Point(35, 45)
        Me.rbNotExploded.Name = "rbNotExploded"
        Me.rbNotExploded.Size = New System.Drawing.Size(89, 17)
        Me.rbNotExploded.TabIndex = 1
        Me.rbNotExploded.TabStop = True
        Me.rbNotExploded.Text = "Not Exploded"
        Me.rbNotExploded.UseVisualStyleBackColor = True
        '
        'rbExploded
        '
        Me.rbExploded.AutoSize = True
        Me.rbExploded.Location = New System.Drawing.Point(35, 22)
        Me.rbExploded.Name = "rbExploded"
        Me.rbExploded.Size = New System.Drawing.Size(69, 17)
        Me.rbExploded.TabIndex = 0
        Me.rbExploded.TabStop = True
        Me.rbExploded.Text = "Exploded"
        Me.rbExploded.UseVisualStyleBackColor = True
        '
        'gbColors
        '
        Me.gbColors.Controls.Add(Me.lblColorPalette)
        Me.gbColors.Controls.Add(Me.cbColorPalette)
        Me.gbColors.Controls.Add(Me.btnBackColor)
        Me.gbColors.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbColors.Location = New System.Drawing.Point(178, 9)
        Me.gbColors.Name = "gbColors"
        Me.gbColors.Size = New System.Drawing.Size(310, 76)
        Me.gbColors.TabIndex = 1
        Me.gbColors.TabStop = False
        Me.gbColors.Text = "Colors"
        '
        'lblColorPalette
        '
        Me.lblColorPalette.AutoSize = True
        Me.lblColorPalette.Location = New System.Drawing.Point(158, 15)
        Me.lblColorPalette.Name = "lblColorPalette"
        Me.lblColorPalette.Size = New System.Drawing.Size(95, 13)
        Me.lblColorPalette.TabIndex = 1
        Me.lblColorPalette.Text = "Chart Color Palette"
        '
        'cbColorPalette
        '
        Me.cbColorPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbColorPalette.FormattingEnabled = True
        Me.cbColorPalette.Items.AddRange(New Object() {"Berry", "Bright", "BrightPastel", "Chocolate", "EarthTones", "Excel", "Fire", "Grayscale", "Light", "None", "Pastel", "SeaGreen", "SemiTransparent"})
        Me.cbColorPalette.Location = New System.Drawing.Point(158, 31)
        Me.cbColorPalette.Name = "cbColorPalette"
        Me.cbColorPalette.Size = New System.Drawing.Size(130, 21)
        Me.cbColorPalette.Sorted = True
        Me.cbColorPalette.TabIndex = 2
        '
        'btnBackColor
        '
        Me.btnBackColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBackColor.Location = New System.Drawing.Point(22, 30)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(130, 23)
        Me.btnBackColor.TabIndex = 0
        Me.btnBackColor.Text = "Background Color"
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'gbChartType
        '
        Me.gbChartType.Controls.Add(Me.cbChartType)
        Me.gbChartType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbChartType.Location = New System.Drawing.Point(494, 9)
        Me.gbChartType.Name = "gbChartType"
        Me.gbChartType.Size = New System.Drawing.Size(174, 76)
        Me.gbChartType.TabIndex = 2
        Me.gbChartType.TabStop = False
        Me.gbChartType.Text = "Chart Type"
        '
        'cbChartType
        '
        Me.cbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChartType.FormattingEnabled = True
        Me.cbChartType.Items.AddRange(New Object() {"Donut", "Pie"})
        Me.cbChartType.Location = New System.Drawing.Point(22, 31)
        Me.cbChartType.Name = "cbChartType"
        Me.cbChartType.Size = New System.Drawing.Size(130, 21)
        Me.cbChartType.Sorted = True
        Me.cbChartType.TabIndex = 0
        '
        'gbPrint
        '
        Me.gbPrint.Controls.Add(Me.lblPrinters)
        Me.gbPrint.Controls.Add(Me.cbPrinters)
        Me.gbPrint.Controls.Add(Me.btnPageSetup)
        Me.gbPrint.Controls.Add(Me.btnPrintPreview)
        Me.gbPrint.Controls.Add(Me.btnPrint)
        Me.gbPrint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbPrint.Location = New System.Drawing.Point(674, 9)
        Me.gbPrint.Name = "gbPrint"
        Me.gbPrint.Size = New System.Drawing.Size(620, 76)
        Me.gbPrint.TabIndex = 3
        Me.gbPrint.TabStop = False
        Me.gbPrint.Text = "Print"
        '
        'cbPrinters
        '
        Me.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrinters.FormattingEnabled = True
        Me.cbPrinters.Location = New System.Drawing.Point(11, 31)
        Me.cbPrinters.Name = "cbPrinters"
        Me.cbPrinters.Size = New System.Drawing.Size(190, 21)
        Me.cbPrinters.Sorted = True
        Me.cbPrinters.TabIndex = 0
        '
        'btnPageSetup
        '
        Me.btnPageSetup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPageSetup.Location = New System.Drawing.Point(207, 30)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(130, 23)
        Me.btnPageSetup.TabIndex = 1
        Me.btnPageSetup.Text = "Page Setup"
        Me.btnPageSetup.UseVisualStyleBackColor = True
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrintPreview.Location = New System.Drawing.Point(343, 30)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(130, 23)
        Me.btnPrintPreview.TabIndex = 2
        Me.btnPrintPreview.Text = "Print Preview"
        Me.btnPrintPreview.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(479, 30)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(130, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print Chart"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(1219, 850)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Location = New System.Drawing.Point(1138, 850)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'lblPrinters
        '
        Me.lblPrinters.AutoSize = True
        Me.lblPrinters.Location = New System.Drawing.Point(11, 15)
        Me.lblPrinters.Name = "lblPrinters"
        Me.lblPrinters.Size = New System.Drawing.Size(42, 13)
        Me.lblPrinters.TabIndex = 3
        Me.lblPrinters.Text = "Printers"
        '
        'frmCharts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1306, 885)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.gbPrint)
        Me.Controls.Add(Me.gbChartType)
        Me.Controls.Add(Me.gbColors)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.MyChart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1322, 924)
        Me.Name = "frmCharts"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spending Overview Charts"
        CType(Me.MyChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        Me.gbColors.ResumeLayout(False)
        Me.gbColors.PerformLayout()
        Me.gbChartType.ResumeLayout(False)
        Me.gbPrint.ResumeLayout(False)
        Me.gbPrint.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MyChart As DataVisualization.Charting.Chart
    Friend WithEvents gbView As GroupBox
    Friend WithEvents rbExploded As RadioButton
    Friend WithEvents rbNotExploded As RadioButton
    Friend WithEvents gbColors As GroupBox
    Friend WithEvents btnBackColor As Button
    Friend WithEvents lblColorPalette As Label
    Friend WithEvents cbColorPalette As ComboBox
    Friend WithEvents gbChartType As GroupBox
    Friend WithEvents cbChartType As ComboBox
    Friend WithEvents gbPrint As GroupBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnPageSetup As Button
    Friend WithEvents cbPrinters As ComboBox
    Friend WithEvents lblPrinters As Label
End Class
