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

Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmCharts

    Private WithEvents prtDoc As PrintDocument = New PrintDocument
    Public caller_frmSpendingOverview As frmSpendingOverview

    Private UIManager As New clsUIManager

    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadSettings()

    End Sub

    Private Sub LoadSettings()

        If Boolean.Parse(GetCheckbookSettingsValue(CheckbookSettings.ChartExploded)) = True Then
            rbExploded.Checked = True
            rbNotExploded.Checked = False
        Else
            rbExploded.Checked = False
            rbNotExploded.Checked = True
        End If

        MyChart.BackColor = ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.ChartBackgroundColor))
        cbChartType.SelectedIndex = cbChartType.FindStringExact(GetCheckbookSettingsValue(CheckbookSettings.ChartType))
        cbColorPalette.SelectedIndex = cbColorPalette.FindStringExact(GetCheckbookSettingsValue(CheckbookSettings.ChartColorPalette))

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

        SetCheckbookSettingsValue(CheckbookSettings.ChartType, strChartType)

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

        SetCheckbookSettingsValue(CheckbookSettings.ChartType, strChartType)

    End Sub

    Private Sub cbColorPalette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColorPalette.SelectedIndexChanged

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

        SetCheckbookSettingsValue(CheckbookSettings.ChartColorPalette, strColorPalette)

    End Sub

    Private Sub cbChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbChartType.SelectedIndexChanged

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

        clrDialog.Color = ColorTranslator.FromHtml(GetCheckbookSettingsValue(CheckbookSettings.ChartBackgroundColor))
        clrDialog.FullOpen = True

        If clrDialog.ShowDialog = DialogResult.OK Then

            MyChart.BackColor = clrDialog.Color
            SetCheckbookSettingsValue(CheckbookSettings.ChartBackgroundColor, UIManager.GetHexColor(clrDialog.Color))

        End If

    End Sub

    Private Sub ExplodeChart()

        For Each dp As DataPoint In MyChart.Series("Categories").Points

            dp("Exploded") = "True"

        Next

        SetCheckbookSettingsValue(CheckbookSettings.ChartExploded, "True")

    End Sub

    Private Sub rbExploded_CheckedChanged(sender As Object, e As EventArgs) Handles rbExploded.CheckedChanged

        SetExplode()

    End Sub

    Private Sub UnExplodeChart()

        For Each dp As DataPoint In MyChart.Series("Categories").Points

            dp("Exploded") = "False"

        Next

        SetCheckbookSettingsValue(CheckbookSettings.ChartExploded, "False")

    End Sub

    Private Sub rbNotExploded_CheckedChanged(sender As Object, e As EventArgs) Handles rbNotExploded.CheckedChanged

        SetExplode()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim new_frmPrint As New frmPrint
        new_frmPrint.caller_frmCharts = Me
        new_frmPrint.ShowDialog()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click

        Dim strWebAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/charts.html"
        Process.Start(strWebAddress)

    End Sub

End Class