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

Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Imaging
Imports System.IO
Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds

Public Class frmCharts

    Private WithEvents prtDoc As PrintDocument = New PrintDocument
    Public caller_frmSpendingOverview As frmSpendingOverview

    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadSettings()

    End Sub

    Private Sub LoadSettings()

        Dim pkInstalledPrinters As String

        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            cbPrinters.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        cbPrinters.SelectedIndex = 0

        'LOAD MY.SETTINGS
        If My.Settings.ChartExploded = True Then
            rbExploded.Checked = True
            rbNotExploded.Checked = False
        Else
            rbExploded.Checked = False
            rbNotExploded.Checked = True
        End If

        MyChart.BackColor = My.Settings.ChartBackgroundColor
        cbChartType.SelectedIndex = cbChartType.FindStringExact(My.Settings.ChartType)
        cbColorPalette.SelectedIndex = cbColorPalette.FindStringExact(My.Settings.ChartColorPalette)

    End Sub

    Private Sub SetExplode()

        If rbExploded.Checked = True Then
            ExplodeChart()
        Else
            UnExplodeChart()
        End If

    End Sub

    Private Sub GeneratePieChart()

        MyChart.Series(0).Points.Clear()
        MyChart.Series(0).ChartType = SeriesChartType.Pie

        ' Set the PieLabelStyle custom attribute to the value of "Outside"
        MyChart.Series(0)("PieLabelStyle") = "Outside"

        ' By default, the callout lines will not be drawn unless you set a color for the series border
        MyChart.Series(0).BorderWidth = 1
        MyChart.Series(0).BorderDashStyle = ChartDashStyle.Solid
        MyChart.Series(0).BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105)

        ' Set the pie chart to be 3D
        MyChart.ChartAreas(0).Area3DStyle.Enable3D = True

        ' By setting the inclination to 0, the chart essentially goes back to being a 2D chart
        MyChart.ChartAreas(0).Area3DStyle.Inclination = 0

        For Each row As DataGridViewRow In caller_frmSpendingOverview.dgvCategory.Rows

            Dim cat As String = row.Cells(0).Value
            Dim total As Double = Replace(row.Cells("Totals").Value, "$", "")

            MyChart.Series("Categories").Points.AddXY(cat & " (" & FormatCurrency(total) & ")", total)

        Next

        SetExplode()

        Dim strChartType As String = String.Empty
        strChartType = "Pie"

        My.Settings.ChartType = strChartType
        My.Settings.Save()

    End Sub

    Private Sub GenerateDonutChart()

        MyChart.Series(0).Points.Clear()
        MyChart.Series(0).ChartType = SeriesChartType.Doughnut

        ' Set the PieLabelStyle custom attribute to the value of "Outside"
        MyChart.Series(0)("PieLabelStyle") = "Outside"

        ' By default, the callout lines will not be drawn unless you set a color for the series border
        MyChart.Series(0).BorderWidth = 1
        MyChart.Series(0).BorderDashStyle = ChartDashStyle.Solid
        MyChart.Series(0).BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105)

        ' Set the pie chart to be 3D
        MyChart.ChartAreas(0).Area3DStyle.Enable3D = True

        ' By setting the inclination to 0, the chart essentially goes back to being a 2D chart
        MyChart.ChartAreas(0).Area3DStyle.Inclination = 0

        For Each row As DataGridViewRow In caller_frmSpendingOverview.dgvCategory.Rows

            Dim cat As String = row.Cells(0).Value
            Dim total As Double = Replace(row.Cells("Totals").Value, "$", "")

            MyChart.Series("Categories").Points.AddXY(cat & " (" & FormatCurrency(total) & ")", total)

        Next

        SetExplode()

        Dim strChartType As String = String.Empty
        strChartType = "Donut"

        My.Settings.ChartType = strChartType
        My.Settings.Save()

    End Sub

    Private Sub cbColorPalette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColorPalette.SelectedIndexChanged

        'SELECT CASE
        Dim strColorPalette As String = String.Empty
        strColorPalette = cbColorPalette.SelectedItem.ToString

        Select Case strColorPalette
            Case "None"
                MyChart.Palette = ChartColorPalette.None
            Case "Bright"
                MyChart.Palette = ChartColorPalette.Bright
            Case "Grayscale"
                MyChart.Palette = ChartColorPalette.Grayscale
            Case "Excel"
                MyChart.Palette = ChartColorPalette.Excel
            Case "Light"
                MyChart.Palette = ChartColorPalette.Light
            Case "Pastel"
                MyChart.Palette = ChartColorPalette.Pastel
            Case "EarthTones"
                MyChart.Palette = ChartColorPalette.EarthTones
            Case "SemiTransparent"
                MyChart.Palette = ChartColorPalette.SemiTransparent
            Case "Berry"
                MyChart.Palette = ChartColorPalette.Berry
            Case "Chocolate"
                MyChart.Palette = ChartColorPalette.Chocolate
            Case "Fire"
                MyChart.Palette = ChartColorPalette.Fire
            Case "SeaGreen"
                MyChart.Palette = ChartColorPalette.SeaGreen
            Case "BrightPastel"
                MyChart.Palette = ChartColorPalette.BrightPastel
            Case Else

        End Select

        My.Settings.ChartColorPalette = strColorPalette
        My.Settings.Save()

    End Sub

    Private Sub cbChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbChartType.SelectedIndexChanged

        'SELECT CASE
        Dim strChartType As String = String.Empty
        strChartType = cbChartType.SelectedItem.ToString

        Select Case strChartType
            Case "Donut"
                GenerateDonutChart()
            Case "Pie"
                GeneratePieChart()
            Case "Column"
                MyChart.Series(0).ChartType = SeriesChartType.Column
            Case Else

        End Select

    End Sub

    Private Sub btnBackColor_Click(sender As Object, e As EventArgs) Handles btnBackColor.Click

        Dim clrDialog As New ColorDialog

        clrDialog.Color = My.Settings.ChartBackgroundColor
        clrDialog.FullOpen = True

        If clrDialog.ShowDialog = DialogResult.OK Then

            MyChart.BackColor = clrDialog.Color
            My.Settings.ChartBackgroundColor = clrDialog.Color
            My.Settings.Save()

        End If

    End Sub

    Private Sub ExplodeChart()

        For Each dp As DataPoint In MyChart.Series("Categories").Points

            dp("Exploded") = "True"

        Next

        My.Settings.ChartExploded = "True"
        My.Settings.Save()

    End Sub

    Private Sub rbExploded_CheckedChanged(sender As Object, e As EventArgs) Handles rbExploded.CheckedChanged

        SetExplode()

    End Sub

    Private Sub UnExplodeChart()

        For Each dp As DataPoint In MyChart.Series("Categories").Points

            dp("Exploded") = "False"

        Next

        My.Settings.ChartExploded = "False"
        My.Settings.Save()

    End Sub

    Private Sub rbNotExploded_CheckedChanged(sender As Object, e As EventArgs) Handles rbNotExploded.CheckedChanged

        SetExplode()

    End Sub

    Private Sub btnPageSetup_Click(sender As Object, e As EventArgs) Handles btnPageSetup.Click

        Dim dlgSetupDialog As New PageSetupDialog

        dlgSetupDialog.PageSettings = New PageSettings
        dlgSetupDialog.PrinterSettings = New PrinterSettings

        dlgSetupDialog.ShowNetwork = False

        prtDoc.PrinterSettings.PrinterName = cbPrinters.SelectedItem.ToString
        dlgSetupDialog.Document = prtDoc

        dlgSetupDialog.ShowDialog()

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click

        Dim dlgPrintPreview As New PrintPreviewDialog

        dlgPrintPreview.Icon = My.Resources.piechart

        dlgPrintPreview.Document = prtDoc

        dlgPrintPreview.WindowState = FormWindowState.Maximized
        dlgPrintPreview.ShowDialog()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage
        Dim prtdlg As New PrintDialog

        prtdlg.Document = prtDoc

        If prtdlg.ShowDialog() = DialogResult.OK Then

            Try

                prtDoc.Print()

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Print Error", MsgButtons.OK, "An error occurred while printing the chart. Please review the message below." & vbNewLine & vbNewLine & ex.Message, Exclamation)

            End Try

        End If

    End Sub

    'CODE FOUND HERE: http://social.technet.microsoft.com/wiki/contents/articles/31058.vb-net-high-resolution-printouts-of-the-chart-control-by-using-a-metafile.aspx
    Private Sub prtDoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles prtDoc.PrintPage

        'draw the preview or printer page
        'convert from 100ths of inch to pixels
        e.Graphics.PageUnit = GraphicsUnit.Pixel
        Dim xf As Single = e.Graphics.DpiX / 100
        Dim yf As Single = e.Graphics.DpiY / 100

        'printed page margin sizes
        Dim marginwidth As Integer = CInt(e.MarginBounds.Width * xf)
        Dim marginheight As Integer = CInt(e.MarginBounds.Height * yf)
        Dim l, t, w, h As Integer

        'size the printed chart to the page margins mantaining chart aspect and centered on the page
        Dim chartAspectRatio As Single = CSng(MyChart.ClientSize.Width / MyChart.ClientSize.Height)

        If chartAspectRatio < marginwidth / marginheight Then

            w = marginwidth
            h = CInt(w / chartAspectRatio)
            t = CInt((e.MarginBounds.Top * yf) + CInt((marginheight / 2 - (h / 2))))
            l = CInt(e.MarginBounds.Left * xf)

        Else

            h = marginheight
            w = CInt(h * chartAspectRatio)
            t = CInt(e.MarginBounds.Top * yf)
            l = CInt((e.MarginBounds.Left * xf) + CInt((marginwidth / 2) - (w / 2)))

        End If

        'create the metafile from the chart image
        Dim _stream2 As MemoryStream = Nothing

        Using stream2 As New MemoryStream()

            MyChart.SaveImage(stream2, ChartImageFormat.Emf)

            _stream2 = New MemoryStream(stream2.GetBuffer())

            'draw the metafile on the printer page
            Using _metaFile As Metafile = New Metafile(_stream2)

                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                e.Graphics.DrawImage(_metaFile, l, t, w, h)

            End Using

        End Using

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click

        Help.ShowHelp(Me, m_helpProvider.HelpNamespace, "charts.html")

    End Sub

End Class