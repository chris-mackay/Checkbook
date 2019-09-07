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

Imports System.ComponentModel

'THIS CLASS IS USED TO CREATE A NEW DATAGRIDVIEW COLUMN WITH A PROGRESS BAR CELL TYPE
'ORIGINAL CODE FOUND HERE: http://stackoverflow.com/questions/4646920/populating-a-datagridview-with-text-and-progressbars
Namespace Sample
    Public Class clsDataGridViewProgressColumn
        Inherits DataGridViewImageColumn
        Public Sub New()
            CellTemplate = New DataGridViewProgressCell()
        End Sub
    End Class
End Namespace
Namespace Sample
    Class DataGridViewProgressCell
        Inherits DataGridViewImageCell
        ' Used to make custom cell consistent with a DataGridViewImageCell
        Shared emptyImage As Image
        Shared Sub New()
            emptyImage = New Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        End Sub
        Public Sub New()
            Me.ValueType = GetType(Integer)
        End Sub
        ' Method required to make the Progress Cell consistent with the default Image Cell. 
        ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle, valueTypeConverter As TypeConverter, formattedValueTypeConverter As TypeConverter, context As DataGridViewDataErrorContexts) As Object
            Return emptyImage
        End Function
        Protected Overrides Sub Paint(g As System.Drawing.Graphics, clipBounds As System.Drawing.Rectangle, cellBounds As System.Drawing.Rectangle, rowIndex As Integer, cellState As DataGridViewElementStates, value As Object,
            formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)
            Try
                Dim progressVal As Double = value
                Dim percentage As Double = (progressVal / 100)
                ' Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.
                Dim backColorBrush As Brush = New SolidBrush(cellStyle.BackColor)
                Dim foreColorBrush As Brush = New SolidBrush(cellStyle.ForeColor)
                ' Draws the cell grid
                MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value,
                    formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts And Not DataGridViewPaintParts.ContentForeground))
                If percentage <= 1.0 Then
                    ' Draw the progress bar and the text
                    g.FillRectangle(New SolidBrush(m_clrMyRed), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 5)

                    g.DrawString(Math.Round(progressVal, 2).ToString() & "%", cellStyle.Font, foreColorBrush, cellBounds.X + (cellBounds.Width / 2) - 15, cellBounds.Y + 4)
                Else
                    ' draw the text
                    If Me.DataGridView.CurrentRow.Index = rowIndex Then
                        g.DrawString("Over Budget", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 23, cellBounds.Y + 4)
                    Else
                        g.DrawString("Over Budget", cellStyle.Font, foreColorBrush, cellBounds.X + 23, cellBounds.Y + 4)
                    End If
                End If
            Catch e As Exception
            End Try
        End Sub
    End Class
End Namespace