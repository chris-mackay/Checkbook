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

Imports System.Data.OleDb

Public Class clsLedgerDBConnector

    'CREATES A LINE OF COMMUNICATION BETWEEN FORMS
    Inherits System.Windows.Forms.Form
    Public caller_frmCategory As frmCategory
    Public caller_frmPayee As frmPayee
    Public caller_frmTransaction As frmTransaction
    Public caller_frmEditCategory As frmEditCategory
    Public caller_frmCreateBudget As frmCreateBudget
    Public caller_frmEditPayee As frmEditPayee
    Public caller_frmImportCategories As frmImportCategories
    Public caller_frmImportPayees As frmImportPayees
    Public caller_frmEditPayment As frmEditPayment
    Public caller_frmEditDeposit As frmEditDeposit
    Public caller_frmEditType As frmEditType
    Public caller_frmEditTransDate As frmEditTransDate

    'NEW INSTANCES OF CLASSES
    Private UIManager As New clsUIManager

    Private con As New OleDbConnection
    Private dbProvider As String
    Private dbSource As String
    Private ds As New DataSet
    Private dt As New DataTable
    Private da As OleDb.OleDbDataAdapter
    Private sql As String

    'PUBLIC SELECT ALL QUERY. THIS IS USED EVERYWHERE IN THE PROGRAM
    Public strSelectAllQuery As String = "SELECT ID, Type, Category, TransDate, Payment, Deposit, Payee, Description, Cleared, Receipt FROM LedgerData"

    Public Sub Connect()

        con.Close()
        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        dbSource = "Data Source = " & m_strCurrentFile

        con.ConnectionString = dbProvider & dbSource

        con.Open()

    End Sub

    Public Sub ConnectMenu(ByVal _File As String)

        con.Close()
        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        dbSource = "Data Source = " & _File

        con.ConnectionString = dbProvider & dbSource

        con.Open()

    End Sub

    Public Sub Reset()

        ds.Reset()

    End Sub

    Public Overloads Sub Close()

        con.Close()

    End Sub

    Public Function SQLselect(ByVal sqlString)

        sql = sqlString
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "LedgerData")

        Return ds
    End Function

    Public Sub Fill_Format_DataGrid_For_ExternalDrawingControl()

        m_DATA_IS_BEING_LOADED = True

        'THE ONLY DIFFERENCE BETWEEN THIS SUB AND THE ONE BELOW IS THIS ONE DOES NOT
        'HAVE DRAWING CONTROL METHODS. THIS IS DONE SEPARATELY IN clsLedgerDataManager

        'CLEARS AND FILLS DATAGRIDVIEW WITH DATA
        MainForm.dgvLedger.DataSource = Nothing
        MainForm.dgvLedger.Columns.Clear()

        dt.Clear()
        da.Fill(dt)

        'COUNTS THE NUMBER OF TRANSACTIONS IN THE FILE
        'THIS IS USED THE DETERMINED WHETHER THE USER CAN OPEN FILTER
        m_TransactionCount = dt.Rows.Count

        MainForm.dgvLedger.DataSource = dt.DefaultView

        FormatMainFormLedgerDataGridView()

        'FORMATS DATAGRIDVIEW WITH GRID SETTINGS
        SetLedgerGrid_Color_Settings()

        'FORMATS UNCLEARED & SETS IMAGES
        FormatUncleared_setClearedImage_setReceiptImage()

        m_DATA_IS_BEING_LOADED = False

    End Sub

    Public Sub Fill_Format_DataGrid()

        m_DATA_IS_BEING_LOADED = True

        MainModule.DrawingControl.SetDoubleBuffered(MainForm.dgvLedger)
        MainModule.DrawingControl.SuspendDrawing(MainForm.dgvLedger)

        'CLEARS AND FILLS DATAGRIDVIEW WITH DATA
        MainForm.dgvLedger.DataSource = Nothing
        MainForm.dgvLedger.Columns.Clear()

        dt.Clear()
        da.Fill(dt)

        'COUNTS THE NUMBER OF TRANSACTIONS IN THE FILE
        'THIS IS USED THE DETERMINED WHETHER THE USER CAN OPEN FILTER
        m_TransactionCount = dt.Rows.Count

        MainForm.dgvLedger.DataSource = dt.DefaultView

        FormatMainFormLedgerDataGridView()

        'FORMATS DATAGRIDVIEW WITH GRID SETTINGS
        SetLedgerGrid_Color_Settings()

        'FORMATS UNCLEARED & SETS IMAGES
        FormatUncleared_setClearedImage_setReceiptImage()

        MainForm.dgvLedger.ClearSelection()
        MainModule.DrawingControl.ResumeDrawing(MainForm.dgvLedger)

        m_DATA_IS_BEING_LOADED = False

    End Sub

    Public Sub SQLinsert(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        da.ExecuteNonQuery()

    End Sub

    Public Sub SQLread_FillCollection_FromDBColumn(ByVal sql As String, ByVal _itemCollection As Microsoft.VisualBasic.Collection, ByVal _columnName As String)

        _itemCollection.Clear()

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        While dr.Read

            Dim item As Object
            item = dr.Item(_columnName)

            If IsDBNull(item) Then

                item = item.ToString
                item = String.Empty

                _itemCollection.Add(item)

            Else

                _itemCollection.Add(dr.Item(_columnName))

            End If

        End While

    End Sub

    Public Sub SQLread_FillCollection_FromDBColumn_RemoveDuplicates(ByVal sql As String, ByVal _itemCollection As Microsoft.VisualBasic.Collection, ByVal _columnName As String)

        _itemCollection.Clear()

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        While dr.Read
            _itemCollection.Add(dr.Item(_columnName))
        End While

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        For x = _itemCollection.Count To 2 Step -1

            For y = (x - 1) To 1 Step -1

                If _itemCollection.Item(x) = _itemCollection.Item(y) Then

                    _itemCollection.Remove(x)

                    Exit For

                End If

            Next

        Next

    End Sub

    Public Sub SQLread_Fill_List(ByVal sql As String, ByVal list As List(Of String))

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        list.Clear()

        While dr.Read
            list.Add(dr.Item(1))
        End While
        dr.Close()

    End Sub

    Public Sub SQLread_Fill_lstCategories(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmCategory.lstCategories.Items.Clear()
        caller_frmCategory.lstCategories.BeginUpdate()

        MainModule.DrawingControl.SetDoubleBuffered(caller_frmCategory.lstCategories)
        MainModule.DrawingControl.SuspendDrawing(caller_frmCategory.lstCategories)

        While dr.Read
            caller_frmCategory.lstCategories.Items.Add(dr.Item(1))
        End While
        caller_frmCategory.lstCategories.EndUpdate()
        dr.Close()

        MainModule.DrawingControl.ResumeDrawing(caller_frmCategory.lstCategories)

    End Sub

    Public Sub SQLread_Fill_lstMyCategories(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmImportCategories.lstMyCategories.Items.Clear()
        caller_frmImportCategories.lstMyCategories.BeginUpdate()

        MainModule.DrawingControl.SetDoubleBuffered(caller_frmImportCategories.lstMyCategories)
        MainModule.DrawingControl.SuspendDrawing(caller_frmImportCategories.lstMyCategories)

        While dr.Read
            caller_frmImportCategories.lstMyCategories.Items.Add(dr.Item(1))
        End While
        caller_frmImportCategories.lstMyCategories.EndUpdate()
        dr.Close()

        MainModule.DrawingControl.ResumeDrawing(caller_frmImportCategories.lstMyCategories)

    End Sub

    Public Sub SQLread_Fill_lstMyPayees(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmImportPayees.lstMyPayees.Items.Clear()
        caller_frmImportPayees.lstMyPayees.BeginUpdate()

        MainModule.DrawingControl.SetDoubleBuffered(caller_frmImportPayees.lstMyPayees)
        MainModule.DrawingControl.SuspendDrawing(caller_frmImportPayees.lstMyPayees)

        While dr.Read
            caller_frmImportPayees.lstMyPayees.Items.Add(dr.Item(1))
        End While
        caller_frmImportPayees.lstMyPayees.EndUpdate()
        dr.Close()

        MainModule.DrawingControl.ResumeDrawing(caller_frmImportPayees.lstMyPayees)

    End Sub

    Public Sub SQL_Connect_read_Fill_ImportlstCategories(ByVal _File As String, ByVal sql As String)

        con.Close()
        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        dbSource = "Data Source = " & _File

        con.ConnectionString = dbProvider & dbSource

        con.Open()

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmImportCategories.lstImportCategories.Items.Clear()
        caller_frmImportCategories.lstImportCategories.BeginUpdate()

        MainModule.DrawingControl.SetDoubleBuffered(caller_frmImportCategories.lstImportCategories)
        MainModule.DrawingControl.SuspendDrawing(caller_frmImportCategories.lstImportCategories)

        While dr.Read
            caller_frmImportCategories.lstImportCategories.Items.Add(dr.Item(1))
        End While
        caller_frmImportCategories.lstImportCategories.EndUpdate()
        dr.Close()

        con.Close()

        MainModule.DrawingControl.ResumeDrawing(caller_frmImportCategories.lstImportCategories)


    End Sub

    Public Sub SQL_Connect_read_Fill_ImportlstPayees(ByVal _File As String, ByVal sql As String)

        con.Close()
        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        dbSource = "Data Source = " & _File

        con.ConnectionString = dbProvider & dbSource

        con.Open()

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmImportPayees.lstImportPayees.Items.Clear()
        caller_frmImportPayees.lstImportPayees.BeginUpdate()

        MainModule.DrawingControl.SetDoubleBuffered(caller_frmImportPayees.lstImportPayees)
        MainModule.DrawingControl.SuspendDrawing(caller_frmImportPayees.lstImportPayees)

        While dr.Read
            caller_frmImportPayees.lstImportPayees.Items.Add(dr.Item(1))
        End While
        caller_frmImportPayees.lstImportPayees.EndUpdate()
        dr.Close()

        con.Close()

        MainModule.DrawingControl.ResumeDrawing(caller_frmImportPayees.lstImportPayees)

    End Sub

    Public Sub SQLread_Fill_lstPayees(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmPayee.lstPayees.Items.Clear()
        caller_frmPayee.lstPayees.BeginUpdate()

        MainModule.DrawingControl.SetDoubleBuffered(caller_frmPayee.lstPayees)
        MainModule.DrawingControl.SuspendDrawing(caller_frmPayee.lstPayees)

        While dr.Read
            caller_frmPayee.lstPayees.Items.Add(dr.Item(1))
        End While
        caller_frmPayee.lstPayees.EndUpdate()
        dr.Close()

        MainModule.DrawingControl.ResumeDrawing(caller_frmPayee.lstPayees)

    End Sub

    Public Sub SQLread_FillcbCategories(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmTransaction.cbCategory.Items.Clear()
        caller_frmTransaction.cbCategory.BeginUpdate()
        While dr.Read
            caller_frmTransaction.cbCategory.Items.Add(dr.Item(1))
        End While
        caller_frmTransaction.cbCategory.EndUpdate()
        dr.Close()

    End Sub

    Public Sub SQLread_FillcbEditCategories(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmEditCategory.cbCategory.Items.Clear()
        While dr.Read
            caller_frmEditCategory.cbCategory.Items.Add(dr.Item(1))
        End While
        dr.Close()

    End Sub

    Public Sub SQLread_FillcbBudgetCategories(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmCreateBudget.cbCategory.Items.Clear()
        While dr.Read
            caller_frmCreateBudget.cbCategory.Items.Add(dr.Item(1))
        End While
        dr.Close()

    End Sub

    Public Sub SQLread_FillcbEditPayees(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmEditPayee.cbPayee.Items.Clear()
        While dr.Read
            caller_frmEditPayee.cbPayee.Items.Add(dr.Item(1))
        End While
        dr.Close()

    End Sub

    Public Sub SQLread_FillcbPayees(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        caller_frmTransaction.cbPayee.Items.Clear()
        caller_frmTransaction.cbPayee.BeginUpdate()
        While dr.Read
            caller_frmTransaction.cbPayee.Items.Add(dr.Item(1))
        End While
        caller_frmTransaction.cbPayee.EndUpdate()
        dr.Close()

    End Sub

    Public Sub SQLreadStartBalance(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()

        While dr.Read
            MainForm.txtStartingBalance.Text = FormatCurrency(dr.Item(1))
        End While
        dr.Close()

    End Sub

    Public Function SQLreadDBValueByFieldNumber(ByVal sql As String, ByVal _fieldNumber As Integer) As String

        Dim da As New OleDbCommand(sql, con)
        Dim dr As OleDbDataReader
        dr = da.ExecuteReader()
        Dim myDBSetting As String = String.Empty

        While dr.Read
            myDBSetting = dr.GetValue(_fieldNumber)
            dr.Close()
            Return myDBSetting
        End While

        Return myDBSetting
    End Function

    Public Sub SQLdelete(ByVal sql)

        Dim da As New OleDbCommand

        da.Connection = con
        da.CommandType = CommandType.Text
        da.CommandText = sql
        da.ExecuteNonQuery()

    End Sub

    Public Sub SQLupdate(ByVal sql)

        Dim da As New OleDbCommand(sql, con)
        da.ExecuteNonQuery()

    End Sub

    Public Sub SetLedgerGrid_Color_Settings()

        'COLUMN DESIGNATIONS
        '1: ShowGrids
        '2: CellBorder
        '3: RowGridLines
        '4: ColumnGridLines
        '5: GridColor
        '6: UnclearedHighlightColor
        '7: RowSelectionColor
        '8: AlternatingRowColor
        '9: ColorUncleared
        '10: ColorAlternatingRows

        'CONNECTION IS ALREADY OPEN DURING DATAMANAGER SUBS

        'SETS GRID LINE SETTINGS
        Dim blnShowGridLines As Boolean
        Dim blnCellBorder As Boolean
        Dim blnRowGridLines As Boolean

        'SETS COLOR OPTIONS SETTINGS
        Dim blnColorAlternatingRows As Boolean

        blnShowGridLines = Boolean.Parse(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 1))
        blnCellBorder = Boolean.Parse(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 2))
        blnRowGridLines = Boolean.Parse(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 3))

        blnColorAlternatingRows = Boolean.Parse(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 10))

        With MainForm.dgvLedger

            'SETS COLOR SETTINGS
            .GridColor = System.Drawing.ColorTranslator.FromHtml(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 5))
            .DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 7))

            If blnColorAlternatingRows = True Then

                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 8))

            Else

                .AlternatingRowsDefaultCellStyle.BackColor = Nothing

            End If

            If Not blnShowGridLines = True Then

                .CellBorderStyle = DataGridViewCellBorderStyle.None

            ElseIf blnCellBorder = True Then

                .CellBorderStyle = DataGridViewCellBorderStyle.Single

            ElseIf blnRowGridLines = True Then

                .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal

            Else

                .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical

            End If

        End With

    End Sub

End Class
