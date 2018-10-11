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

Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing.Imaging
Imports System.IO
Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds

Public Class frmPrint

    Private WithEvents prtDoc As PrintDocument = New PrintDocument
    Public caller_frmCharts As frmCharts

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Dispose()

    End Sub

    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim pkInstalledPrinters As String = String.Empty

        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            cbPrinters.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        cbPrinters.SelectedIndex = 0

        prtPreview.Document = prtDoc

    End Sub

    Private Sub btnPageSetup_Click(sender As Object, e As EventArgs) Handles btnPageSetup.Click

        Dim dlgSetupDialog As New PageSetupDialog

        dlgSetupDialog.PageSettings = New PageSettings
        dlgSetupDialog.PrinterSettings = New PrinterSettings

        dlgSetupDialog.ShowNetwork = False

        prtDoc.PrinterSettings.PrinterName = cbPrinters.SelectedItem.ToString
        dlgSetupDialog.Document = prtDoc

        If dlgSetupDialog.ShowDialog() = DialogResult.OK Then

            prtPreview.Document = prtDoc

        End If

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
        Dim chartAspectRatio As Single = CSng(caller_frmCharts.MyChart.ClientSize.Width / caller_frmCharts.MyChart.ClientSize.Height)

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

            caller_frmCharts.MyChart.SaveImage(stream2, ChartImageFormat.Emf)

            _stream2 = New MemoryStream(stream2.GetBuffer())

            'draw the metafile on the printer page
            Using _metaFile As Metafile = New Metafile(_stream2)

                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                e.Graphics.DrawImage(_metaFile, l, t, w, h)

            End Using

        End Using

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles Me.HelpButtonClicked

        Dim strWebAddress As String = "https://cmackay732.github.io/CheckbookWebsite/checkbook_help/print_chart.html"
        Process.Start(strWebAddress)

    End Sub

End Class