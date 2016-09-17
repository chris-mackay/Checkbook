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
Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds
Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Module MainModule

    'MODULE LEVEL VARIABLES HAVE A PREFIX OF '_m'. THESE VARIABLES ARE USED THROUGHOUT THE ENTIRE APPLICATION.

    Public m_helpProvider As HelpProvider 'THIS STORES CHECKBOOK HELP SO IT CAN BE ACCESSED THROUGHOUT PROGRAM

    Public m_ledgerIsBeingBalanced As Boolean = False 'STORES WHETHER THE LEDGER IS BEING BALANCED
    Public m_ledgerIsBeingFiltered As Boolean = False

    'FRMFILTER
    Public m_frmFilter As frmFilter = Nothing 'USED TO DETERMINED IF THE ADVANCED FILTER FORM IS OPEN. THE USER CAN EDIT AND ADD TRANSACTIONS AND THE FILTERS WILL BE APPLIED.

    'FRMTRANS
    Public m_frmTrans As frmTransaction = Nothing

    Public m_DATA_IS_BEING_LOADED As Boolean
    Public m_NEW_VERSION_IS_BEING_DOWNLOADED As Boolean

    'WHATIF VARIABLES
    Public m_MonthCollection As New Microsoft.VisualBasic.Collection
    Public m_myMonthsCollection As New Microsoft.VisualBasic.Collection

    'MAINFORM CONTROL LISTS
    Public m_groupAllControls_MainForm As New List(Of Control)
    Public m_groupAccountDetailTextboxes As New List(Of Control)

    'SPENDINGOVERVIEW COLLECTIONS
    Public m_globalUsedCategoryCollection As New Microsoft.VisualBasic.Collection
    Public m_globalUsedPayeeCollection As New Microsoft.VisualBasic.Collection

    Public m_transactionIsBeingEdited As Boolean
    Public m_dgvID As Integer 'THIS IS THE ID OF THE SELECTED TRANSACTION TO UPDATE IF EDIT TRANSACTION IS SELECTED
    Public m_strCurrentFile As String 'THIS IS THE FILENAME THIS IS CURRENTLY 'LOADED'. IT IS A MODULE LEVEL VARIABLE BECAUSE IT IS USED OFTEN AND NEEDS TO BE ACCESSIBLE.
    Public m_strOriginalReceiptToCopy As String 'CREATES A COPY OF THE RECEIPT FILE PROVIDED IN TO MY CHECKBOOK LEDGERS\RECEIPTS\FILENAME_RECEIPTS.
    Public m_colReceiptFilesToDelete As New Microsoft.VisualBasic.Collection 'IF A RECEIPT IS REMOVED FROM THE TRANSACTION IT IS STORED IN THIS VARIABLE AND DELETES IT FROM MY CHECKBOOK LEDGERS\RECEIPTS\FILENAME_RECEIPTS IF BTNUPDATE IS CLICKED.

    Public m_myGreen As Color = Color.FromArgb(239, 254, 218)
    Public m_myRed As Color = Color.FromArgb(254, 216, 222)

    'STORES THE NUMBER OF TRANSACTIONS IN THE FILE
    'THIS IS USED THE DETERMINED WHETHER THE USER CAN OPEN FILTER
    Public m_TransactionCount As Integer

    'NEW INSTANCES OF CLASSES
    Private DataCon As New clsLedgerDataManager
    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager

    Public Function AccessIsInstalled() As Boolean

        Dim key As RegistryKey
        Dim reader As RegistryKey
        Dim strSubKeyName As String = String.Empty
        Dim strDisplayName As String = String.Empty
        Dim blnAccessIsInstalled As Boolean = False

        Dim progList As New List(Of String)

        key = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall", False)

        For Each strSubKeyName In key.GetSubKeyNames

            reader = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall\" & strSubKeyName, False)

            If reader.GetValueNames().Contains("DisplayName") Then

                strDisplayName = reader.GetValue("DisplayName")

                If Not progList.Contains(strDisplayName) Then progList.Add(strDisplayName)

            End If

        Next

        If progList.Contains("Microsoft Office Access Runtime (English) 2007") Then

            blnAccessIsInstalled = True

        Else

            blnAccessIsInstalled = False

        End If


        Return blnAccessIsInstalled
    End Function

    Public Sub FormatUncleared_setClearedImage_setReceiptImage() 'THIS TAKES ROUGHLY 0.5 SECS

        Dim clrUnclearedHighlightColor As Color
        Dim strUnclearHighlightColorSetting As String
        Dim blnColorUncleared As Boolean

        FileCon.Connect()
        strUnclearHighlightColorSetting = FileCon.SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 6)
        blnColorUncleared = FileCon.SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 9)
        FileCon.Close()

        clrUnclearedHighlightColor = System.Drawing.ColorTranslator.FromHtml(strUnclearHighlightColorSetting)

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = row.Index

#Region "COLOR UNCLEARED ROWS"

            Dim blnCleared As Boolean

            With MainForm

                If blnColorUncleared = True Then

                    blnCleared = .dgvLedger.Rows(i).Cells("Cleared").Value

                    If blnCleared = False Then

                        .dgvLedger.Rows(i).DefaultCellStyle.BackColor = clrUnclearedHighlightColor 'CHANGES THE COLOR OF THE CLEARED TRANSACTIONS

                    End If

                Else

                    .dgvLedger.Rows(i).DefaultCellStyle.BackColor = Nothing

                End If

            End With

#End Region

#Region "SET CLEARED IMAGE"

            blnCleared = MainForm.dgvLedger.Item("Cleared", i).Value.ToString
            Dim imgClearedImage As Image = My.Resources.cleared
            Dim imgUnclearedImage As Image = My.Resources.uncleared

            If blnCleared = True Then

                MainForm.dgvLedger.Item("ClearedImage", i).Value = imgClearedImage

            Else

                MainForm.dgvLedger.Item("ClearedImage", i).Value = imgUnclearedImage

            End If

#End Region

#Region "SET RECEIPT IMAGE"

            Dim strReceipt As String

            strReceipt = MainForm.dgvLedger.Item("Receipt", i).Value.ToString
            Dim imgReceiptImage As Image = My.Resources.receipt
            Dim imgEmptyImage As Image = My.Resources.Empty_Image

            If Not strReceipt = String.Empty Then

                MainForm.dgvLedger.Item("ReceiptImage", i).Value = imgReceiptImage

            Else

                MainForm.dgvLedger.Item("ReceiptImage", i).Value = imgEmptyImage

            End If

#End Region

        Next

    End Sub

    Public Sub FormatUncleared()

        Dim clrUnclearedHighlightColor As Color
        Dim strUnclearHighlightColorSetting As String
        Dim blnColorUncleared As Boolean

        FileCon.Connect()
        strUnclearHighlightColorSetting = FileCon.SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 6)
        blnColorUncleared = FileCon.SQLreadDBValueByFieldNumber("SELECT * FROM tblSettings WHERE ID = 1", 9)
        FileCon.Close()

        clrUnclearedHighlightColor = System.Drawing.ColorTranslator.FromHtml(strUnclearHighlightColorSetting)

        With MainForm

            If blnColorUncleared = True Then

                'CHANGES THE COLOR OF THE CLEARED TRANSACTIONS
                For i = 0 To .dgvLedger.Rows.Count - 1

                    Dim blnCleared As Boolean = .dgvLedger.Rows(i).Cells("Cleared").Value

                    If blnCleared = False Then

                        .dgvLedger.Rows(i).DefaultCellStyle.BackColor = clrUnclearedHighlightColor

                    End If

                Next

            Else

                For i = 0 To .dgvLedger.Rows.Count - 1

                    .dgvLedger.Rows(i).DefaultCellStyle.BackColor = Nothing

                Next

            End If

        End With

    End Sub

    Public Sub CheckIfTransactionIsUnCleared()

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index
            Dim blnCleared As Boolean

            blnCleared = MainForm.dgvLedger.Item("Cleared", i).Value.ToString
            Dim imgClearedImage As Image = My.Resources.cleared
            Dim imgUnclearedImage As Image = My.Resources.uncleared

            If blnCleared = True Then

                MainForm.dgvLedger.Item("ClearedImage", i).Value = imgClearedImage

            Else

                MainForm.dgvLedger.Item("ClearedImage", i).Value = imgUnclearedImage

            End If

        Next

    End Sub

    Public Sub CheckIfReceiptExists()

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index
            Dim strReceipt As String

            strReceipt = MainForm.dgvLedger.Item("Receipt", i).Value.ToString
            Dim imgReceiptImage As Image = My.Resources.receipt
            Dim imgEmptyImage As Image = My.Resources.Empty_Image

            If Not strReceipt = String.Empty Then

                MainForm.dgvLedger.Item("ReceiptImage", i).Value = imgReceiptImage

            Else

                MainForm.dgvLedger.Item("ReceiptImage", i).Value = imgEmptyImage

            End If

        Next

    End Sub

    Public Function AppendLedgerDirectory(ByVal _ledgerFile As String) As String

        Dim strFullPath As String

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileName(_ledgerFile) & ".cbk"

        Return strFullPath
    End Function

    Public Function AppendReceiptDirectoryAndReceiptFile(ByVal _ledgerFile As String, ByVal _receiptFileName As String) As String

        Dim strFullPath As String

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Receipts\" & System.IO.Path.GetFileNameWithoutExtension(_ledgerFile) & "_Receipts\" & _receiptFileName

        Return strFullPath
    End Function

    Public Function AppendReceiptDirectory(ByVal _ledgerFile As String) As String

        Dim strFullPath As String

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Receipts\" & System.IO.Path.GetFileNameWithoutExtension(_ledgerFile) & "_Receipts"

        Return strFullPath
    End Function

    Public Sub RetainFilter()

        With MainForm

            'KEEPS FILTER RESULTS ACTIVE AFTER EDITING A TRANSACTION
            If .txtFilter.Visible = True And Not .txtFilter.Text = "" Then
                FilterLedger()
            End If

            If m_frmFilter.Visible Then

                m_frmFilter.ApplyFilters()

            End If

            .dgvLedger.ClearSelection()

        End With

    End Sub

    Public Sub RetainAccountBalancing()

        With MainForm

            'KEEPS FILTER RESULTS ACTIVE AFTER EDITING A TRANSACTION
            If m_ledgerIsBeingBalanced Then

                'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery & " WHERE Cleared=False")
                FileCon.Fill_Format_DataGrid_For_ExternalDrawingControl()
                FileCon.Close()

            End If

            .dgvLedger.ClearSelection()

        End With

    End Sub

    Public Sub FilterLedger()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Try

            Dim con As New OleDbConnection
            Dim da As New OleDbDataAdapter
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim bs As New BindingSource
            Dim dsView As New DataView
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & m_strCurrentFile
            con.Open()
            ds.Tables.Add(dt)
            da = New OleDbDataAdapter("SELECT * FROM LedgerData", con)
            da.Fill(dt)

            MainForm.dgvLedger.Columns.Clear()
            MainForm.dgvLedger.DataSource = Nothing

            dsView = ds.Tables(0).DefaultView
            bs.DataSource = dsView

            Dim strSearch As String = MainForm.txtFilter.Text.ToString()
            Dim Type As String = " Type LIKE'%" & strSearch & "%'"
            Dim Category As String = " Category LIKE'%" & strSearch & "%'"
            Dim Payment As String = " Payment LIKE'%" & strSearch & "%'"
            Dim Deposit As String = " Deposit LIKE'%" & strSearch & "%'"
            Dim Payee As String = " Payee LIKE'%" & strSearch & "%'"
            Dim Description As String = " Description LIKE'%" & strSearch & "%'"
            Dim Cleared As String = " Convert(Cleared, System.String) LIKE'%" & strSearch & "%'"
            Dim TransDate As String = " Convert(TransDate, System.String) LIKE'%" & strSearch & "%'"
            bs.Filter = Type & "or" & Category & "or" & Payment & "or" & Deposit & "or" & Payee & "or" & Description & "or" & TransDate & "or" & Cleared

            MainForm.dgvLedger.DataSource = bs

            FormatMainFormLedgerDataGridView()

            MainForm.dgvLedger.Sort(MainForm.dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            con.Close()

            'FORMATS UNCLEARED TRANSACTIONS
            FormatUncleared()

            'SHOWS THE UNCLEARED IMAGE IF TRANSACTION IS NOT CLEARED
            CheckIfTransactionIsUnCleared()

            'SHOWS THE RECEIPT IMAGE IF A RECEIPT EXISTS
            CheckIfReceiptExists()

            MainForm.dgvLedger.ClearSelection()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

    End Sub

    Public Function ConvertMonthFromIntegerToString(ByVal _month As Integer)

        Dim _strMonth As String
        _strMonth = ""

        If _month = 1 Then
            _strMonth = "January"
        End If
        If _month = 2 Then
            _strMonth = "February"
        End If
        If _month = 3 Then
            _strMonth = "March"
        End If
        If _month = 4 Then
            _strMonth = "April"
        End If
        If _month = 5 Then
            _strMonth = "May"
        End If
        If _month = 6 Then
            _strMonth = "June"
        End If
        If _month = 7 Then
            _strMonth = "July"
        End If
        If _month = 8 Then
            _strMonth = "August"
        End If
        If _month = 9 Then
            _strMonth = "September"
        End If
        If _month = 10 Then
            _strMonth = "October"
        End If
        If _month = 11 Then
            _strMonth = "November"
        End If
        If _month = 12 Then
            _strMonth = "December"
        End If

        Return _strMonth
    End Function

    Public Function ConvertMonthFromStringToInteger(ByVal _month As String)

        Dim _intMonth As Integer

        If _month = "January" Then
            _intMonth = 1
        End If
        If _month = "February" Then
            _intMonth = 2
        End If
        If _month = "March" Then
            _intMonth = 3
        End If
        If _month = "April" Then
            _intMonth = 4
        End If
        If _month = "May" Then
            _intMonth = 5
        End If
        If _month = "June" Then
            _intMonth = 6
        End If
        If _month = "July" Then
            _intMonth = 7
        End If
        If _month = "August" Then
            _intMonth = 8
        End If
        If _month = "September" Then
            _intMonth = 9
        End If
        If _month = "October" Then
            _intMonth = 10
        End If
        If _month = "November" Then
            _intMonth = 11
        End If
        If _month = "December" Then
            _intMonth = 12
        End If

        Return _intMonth
    End Function

    Public Function SumPaymentsMonthly_FromMainFromLedger(ByVal _month As String, ByVal _year As Integer)

        Dim dblTotal As Double

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strPayment As String
            Dim dtDate As Date
            Dim intYear As Integer
            Dim intMonth As Integer

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intMonth = dtDate.Month
            intYear = dtDate.Year

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString

            If strPayment = "" Then
                strPayment = 0
            Else
                strPayment = CDbl(strPayment)
            End If

            If ConvertMonthFromIntegerToString(intMonth) = _month And intYear = _year Then
                dblTotal += strPayment
            End If

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Public Function SumDepositsMonthly_FromMainFormLedger(ByVal _month As String, ByVal _year As Integer)

        Dim dblTotal As Double

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strDeposit As String
            Dim dtDate As Date
            Dim intMonth As Integer
            Dim intYear As Integer

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intMonth = dtDate.Month
            intYear = dtDate.Year

            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            If strDeposit = "" Then
                strDeposit = 0
            Else
                strDeposit = CDbl(strDeposit)
            End If

            If ConvertMonthFromIntegerToString(intMonth) = _month And intYear = _year Then
                dblTotal += strDeposit
            End If

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Public Sub DetermineCategoriesbyYear_Payments(ByVal _year As Integer)

        m_globalUsedCategoryCollection.Clear()

        Dim dtDate As Date
        Dim strCategory As String
        Dim strDeposit As String

        'DETERMINES CATEGORIES BASED ON YEAR
        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = row.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _year And strDeposit = "" And Not strCategory = "Uncategorized" Then

                m_globalUsedCategoryCollection.Add(strCategory)

            End If

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(m_globalUsedCategoryCollection)

    End Sub

    Public Sub DetermineCategoriesbyYear_Deposits(ByVal _year As Integer)

        m_globalUsedCategoryCollection.Clear()

        Dim dtDate As Date
        Dim strCategory As String
        Dim strPayment As String

        'DETERMINES CATEGORIES BASED ON YEAR
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _year And strPayment = "" And Not strCategory = "Uncategorized" Then

                m_globalUsedCategoryCollection.Add(strCategory)

            End If

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(m_globalUsedCategoryCollection)

    End Sub

    Public Sub DeterminePayeesbyYear_Payments(ByVal _year As Integer)

        m_globalUsedPayeeCollection.Clear()

        Dim dtDate As Date
        Dim strPayee As String
        Dim strDeposit As String

        'DETERMINES PAYEES BASED ON YEAR
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index

            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _year And strDeposit = "" And Not strPayee = "Unknown" Then

                m_globalUsedPayeeCollection.Add(strPayee)

            End If

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(m_globalUsedPayeeCollection)

    End Sub

    Public Sub DeterminePayeesbyYear_Deposits(ByVal _year As Integer)

        m_globalUsedPayeeCollection.Clear()

        Dim dtDate As Date
        Dim strPayee As String
        Dim strPayment As String

        'DETERMINES PAYEES BASED ON YEAR
        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer
            i = dgvRow.Index

            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _year And strPayment = "" And Not strPayee = "Unknown" Then

                m_globalUsedPayeeCollection.Add(strPayee)

            End If

        Next

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        RemoveDuplicateCollectionItems(m_globalUsedPayeeCollection)

    End Sub

    Public Sub GetAndSetColumnWidths()

        Dim intTypeColSize As Integer
        Dim intCategoryColSize As Integer
        Dim intDateColSize As Integer
        Dim intPaymentColSize As Integer
        Dim intDepositColSize As Integer
        Dim intPayeeColSize As Integer
        Dim intDescriptionColSize As Integer

        'SETS MY.SETTINGS
        With MainForm.dgvLedger

            If .Columns.Contains("Type") = True Then
                intTypeColSize = .Columns("Type").Width
                My.Settings.TypeColSize = intTypeColSize
            End If

            If .Columns.Contains("Category") = True Then
                intCategoryColSize = .Columns("Category").Width
                My.Settings.CatColSize = intCategoryColSize
            End If

            If .Columns.Contains("TransDate") = True Then
                intDateColSize = .Columns("TransDate").Width
                My.Settings.DateColSize = intDateColSize
            End If

            If .Columns.Contains("Payment") = True Then
                intPaymentColSize = .Columns("Payment").Width
                My.Settings.PaymentColSize = intPaymentColSize
            End If

            If .Columns.Contains("Deposit") = True Then
                intDepositColSize = .Columns("Deposit").Width
                My.Settings.DepositColSize = intDepositColSize
            End If

            If .Columns.Contains("Payee") = True Then
                intPayeeColSize = .Columns("Payee").Width
                My.Settings.PayeeColSize = intPayeeColSize
            End If

            If .Columns.Contains("Description") = True Then
                intDescriptionColSize = .Columns("Description").Width
                My.Settings.DescriptionColSize = intDescriptionColSize
            End If

            My.Settings.Save()

        End With

    End Sub

    Public Sub CenterFormCenterScreen(ByVal _oForm As Object)

        Dim currentArea = Screen.FromControl(_oForm).WorkingArea
        _oForm.Top = currentArea.Top + CInt((currentArea.Height / 2) - (_oForm.Height / 2))
        _oForm.Left = currentArea.Left + CInt((currentArea.Width / 2) - (_oForm.Width / 2))

    End Sub

    Public Sub CountTotalListBoxItems_Display(ByVal myListBox As ListBox, ByVal myLabel As Label)

        myLabel.Text = myListBox.Items.Count & " total items"

    End Sub

    Public Sub CalculateMonthlyIncome_And_AverageIncome(ByVal _dgv As DataGridView)

        Dim dblMonthlyIncome As Double = Nothing
        Dim dblTotalIncome As Double = Nothing
        Dim dblAverageIncome As Double = Nothing
        Dim dblTotalPayments As Double = Nothing
        Dim dblTotalDeposits As Double = Nothing
        Dim intMonthCounter As Integer = 1

        For Each dgvRow As DataGridViewRow In _dgv.Rows

            dblTotalPayments = dgvRow.Cells("Payments").Value
            dblTotalDeposits = dgvRow.Cells("Deposits").Value

            dblMonthlyIncome = dblTotalDeposits - dblTotalPayments
            dblTotalIncome += dblMonthlyIncome
            dblAverageIncome = dblTotalIncome / intMonthCounter

            intMonthCounter += 1 'ADDS 1 AFTER EACH ROW TO CALCULATE AVERAGE INCOME

            'FORMAT NUMBER TO CURRENCY
            dgvRow.Cells("Payments").Value = FormatCurrency(dblTotalPayments)
            dgvRow.Cells("Deposits").Value = FormatCurrency(dblTotalDeposits)
            dgvRow.Cells("Monthly").Value = FormatCurrency(dblMonthlyIncome)
            dgvRow.Cells("AveMonthlyIncome").Value = FormatCurrency(dblAverageIncome)

            'FORMATS '$0.00' SO YOU DONT SEE IT
            If dgvRow.Cells("Payments").Value = "$0.00" Then

                dgvRow.Cells("Payments").Style.ForeColor = Color.Transparent
                dgvRow.Cells("Payments").Style.SelectionForeColor = Color.Transparent

            Else

                dgvRow.Cells("Payments").Style.ForeColor = Color.Black
                dgvRow.Cells("Payments").Style.SelectionForeColor = Color.Black

            End If

            'FORMATS '$0.00' SO YOU DONT SEE IT
            If dgvRow.Cells("Deposits").Value = "$0.00" Then

                dgvRow.Cells("Deposits").Style.ForeColor = Color.Transparent
                dgvRow.Cells("Deposits").Style.SelectionForeColor = Color.Transparent

            Else

                dgvRow.Cells("Deposits").Style.ForeColor = Color.Black
                dgvRow.Cells("Deposits").Style.SelectionForeColor = Color.Black

            End If

            'FORMATS '$0.00' SO YOU DONT SEE IT
            If dgvRow.Cells("Monthly").Value = "$0.00" Then

                dgvRow.Cells("Monthly").Style.ForeColor = Color.Transparent
                dgvRow.Cells("Monthly").Style.SelectionForeColor = Color.Transparent

            Else

                dgvRow.Cells("Monthly").Style.ForeColor = Color.Black
                dgvRow.Cells("Monthly").Style.SelectionForeColor = Color.Black

            End If

            'FORMATS '$0.00' SO YOU DONT SEE IT
            If dgvRow.Cells("Monthly").Value = "$0.00" Then

                dgvRow.Cells("AveMonthlyIncome").Style.ForeColor = Color.Transparent
                dgvRow.Cells("AveMonthlyIncome").Style.SelectionForeColor = Color.Transparent

            Else

                dgvRow.Cells("AveMonthlyIncome").Style.ForeColor = Color.Black
                dgvRow.Cells("AveMonthlyIncome").Style.SelectionForeColor = Color.Black

            End If

        Next

    End Sub

    Public Function GetTotalPaymentsFromMonthlyGrid(ByVal _dgv As DataGridView) 'GET TOTAL PAYMENTS TO UPDATE LEDGER STATUS FOR THAT PARTICULAR YEAR

        Dim dblTotal As Double

        For Each dgvRow As DataGridViewRow In _dgv.Rows

            Dim strPayment As String = String.Empty

            strPayment = CType(dgvRow.Cells("Payments").Value, Double)

            dblTotal += strPayment

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Public Function GetTotalDepositsFromMonthlyGrid(ByVal _dgv As DataGridView) 'GET TOTAL DEPOSITS TO UPDATE LEDGER STATUS FOR THAT PARTICULAR YEAR

        Dim dblTotal As Double

        For Each dgvRow As DataGridViewRow In _dgv.Rows

            Dim strDeposit As String = String.Empty

            strDeposit = CType(dgvRow.Cells("Deposits").Value, Double)

            dblTotal += strDeposit

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Public Sub ColorTextboxes(ByVal _textBoxList As List(Of TextBox))

        For Each textBox As TextBox In _textBoxList

            If textBox.Text > 0 Then
                textBox.BackColor = m_myGreen
            End If
            If textBox.Text < 0 Then
                textBox.BackColor = m_myRed
            End If
            If textBox.Text = 0 Then
                textBox.BackColor = Color.White
            End If

        Next

    End Sub 'RECOLORS TEXTBOX BACKGROUND COLORS BASED ON POSITIVE OR NEGATIVE VALUES

    Public Sub RemoveDuplicateCollectionItems(ByVal _collection As Collection)

        'REMOVES DUPLICATE ENTRIES IN COLLECTION
        For x = _collection.Count To 2 Step -1

            For y = (x - 1) To 1 Step -1

                If _collection.Item(x) = _collection.Item(y) Then

                    _collection.Remove(x)

                    Exit For

                End If

            Next

        Next

    End Sub

    Public Sub CreateMonthlyGridColumns(ByVal _dgv As DataGridView)

        MainModule.DrawingControl.SetDoubleBuffered(_dgv)
        MainModule.DrawingControl.SuspendDrawing(_dgv)

        _dgv.Columns.Clear()

        'CREATE DEFAULT CELL STYLE
        Dim dgvDefaultCellStyle As New DataGridViewCellStyle
        _dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        'SET CELL STYLE PROPERTIES
        dgvDefaultCellStyle.BackColor = Color.White
        dgvDefaultCellStyle.ForeColor = Color.Black
        dgvDefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
        dgvDefaultCellStyle.SelectionForeColor = Color.Black
        dgvDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        'CREATE COLUMNS
        Dim colMonthColumn As New DataGridViewTextBoxColumn
        Dim colPaymentsColumn As New DataGridViewTextBoxColumn
        Dim colDepositsColumn As New DataGridViewTextBoxColumn
        Dim colIncomeColumn As New DataGridViewTextBoxColumn
        Dim colAverageIncomeColumn As New DataGridViewTextBoxColumn

        'SET NAME
        colMonthColumn.Name = "Month"
        colPaymentsColumn.Name = "Payments"
        colDepositsColumn.Name = "Deposits"
        colIncomeColumn.Name = "Monthly"
        colAverageIncomeColumn.Name = "AveMonthlyIncome"

        'SET HEADER TEXT
        colMonthColumn.HeaderText = "Month"
        colPaymentsColumn.HeaderText = "Payments"
        colDepositsColumn.HeaderText = "Deposits"
        colIncomeColumn.HeaderText = "Monthly Income"
        colAverageIncomeColumn.HeaderText = "Average Income"

        'SET AUTOSIZE
        colMonthColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colPaymentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDepositsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colIncomeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colAverageIncomeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'SET SORTABLE
        colMonthColumn.SortMode = False
        colPaymentsColumn.SortMode = False
        colDepositsColumn.SortMode = False
        colIncomeColumn.SortMode = False
        colAverageIncomeColumn.SortMode = False

        'SET READONLY
        colMonthColumn.ReadOnly = True
        colPaymentsColumn.ReadOnly = True
        colDepositsColumn.ReadOnly = True
        colIncomeColumn.ReadOnly = True
        colAverageIncomeColumn.ReadOnly = True

        'SET CELL TEMPLATE
        _dgv.DefaultCellStyle = dgvDefaultCellStyle

        'ADD COLUMNS TO DATAGRIDVIEW
        _dgv.Columns.Add(colMonthColumn)
        _dgv.Columns.Add(colPaymentsColumn)
        _dgv.Columns.Add(colDepositsColumn)
        _dgv.Columns.Add(colIncomeColumn)
        _dgv.Columns.Add(colAverageIncomeColumn)

        MainModule.DrawingControl.ResumeDrawing(_dgv)

    End Sub

    Public Sub FormatMainFormLedgerDataGridView() 'THIS TAKE ROUGHLY 0.59 SECS

        'COLUMN ORDER
        'ID
        'TYPE
        'CATEGORY
        'TRANSDATE
        'PAYMENT
        'DEPOSIT
        'PAYEE
        'DESCRIPTION
        'RUNNINGBALANCE
        'RECEIPTIMAGE
        'CLEARED
        'RECEIPT

        'FORMATS DATAGRIDVIEW
        With MainForm.dgvLedger

            .ReadOnly = False

            'ADD IMAGE COLUMN TO DATAGRIDVIEW
            Dim colCleared As New DataGridViewImageColumn
            colCleared.CellTemplate = New DataGridViewImageCell
            colCleared.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            colCleared.Resizable = DataGridViewTriState.False
            colCleared.Name = "ClearedImage"
            colCleared.HeaderText = "Cleared"
            colCleared.Width = 60
            colCleared.DefaultCellStyle.NullValue = Nothing

            MainForm.dgvLedger.Columns.Insert(8, colCleared)

            'ADD IMAGE COLUMN TO DATAGRIDVIEW
            Dim colReceiptColumn As New DataGridViewImageColumn
            colReceiptColumn.CellTemplate = New DataGridViewImageCell
            colReceiptColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            colReceiptColumn.Resizable = DataGridViewTriState.False
            colReceiptColumn.Name = "ReceiptImage"
            colReceiptColumn.HeaderText = "Receipt"
            colReceiptColumn.Width = 60
            colReceiptColumn.DefaultCellStyle.NullValue = Nothing

            MainForm.dgvLedger.Columns.Insert(9, colReceiptColumn)

            'ID
            .Columns("ID").Visible = False
            .Columns("ID").ReadOnly = True

            'TYPE
            .Columns("Type").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Type").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Type").Width = My.Settings.TypeColSize
            .Columns("Type").ReadOnly = True

            'CATEGORY
            .Columns("Category").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Category").Width = My.Settings.CatColSize
            .Columns("Category").ReadOnly = True

            'TRANSDATE
            .Columns("TransDate").HeaderText = "Date"
            .Columns("TransDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("TransDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TransDate").Width = My.Settings.DateColSize
            .Sort(.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            .Columns("TransDate").ReadOnly = True

            'PAYMENT
            .Columns("Payment").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Payment").Width = My.Settings.PaymentColSize
            .Columns("Payment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Payment").ReadOnly = True
            .Columns("Payment").SortMode = False

            'DEPOSIT
            .Columns("Deposit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Deposit").Width = My.Settings.DepositColSize
            .Columns("Deposit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Deposit").ReadOnly = True
            .Columns("Deposit").SortMode = False

            'PAYEE
            .Columns("Payee").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Payee").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Payee").Width = My.Settings.PayeeColSize
            .Columns("Payee").ReadOnly = True

            'DESCRIPTION
            .Columns("Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Description").Width = My.Settings.DescriptionColSize
            .Columns("Description").ReadOnly = True

            'CLEARED
            .Columns("Cleared").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Cleared").Resizable = DataGridViewTriState.False
            .Columns("Cleared").Visible = False
            .Columns("Cleared").ReadOnly = True
            .Columns("Cleared").SortMode = False

            'RECEIPT
            .Columns("Receipt").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Receipt").Resizable = DataGridViewTriState.False
            .Columns("Receipt").Visible = False
            .Columns("Receipt").ReadOnly = True
            .Columns("Receipt").SortMode = False

        End With

    End Sub

    Public Function RemoveExtension(ByVal _fileName As String) As String

        Dim Dot As Integer = _fileName.LastIndexOf(".")

        Return _fileName.Substring(0, Dot)
    End Function

    Public NotInheritable Class DrawingControl
        Private Sub New()
        End Sub
        <DllImport("user32.dll")>
        Public Shared Function SendMessage(_hWnd As IntPtr, _wMsg As Int32, _wParam As Boolean, _lParam As Int32) As Integer
        End Function

        Private Const WM_SETREDRAW As Integer = 11

        ''' <summary>
        ''' Original code found here: http://stackoverflow.com/questions/118528/horrible-redraw-performance-of-the-datagridview-on-one-of-my-two-screens
        ''' Some controls, such as the DataGridView, do not allow setting the DoubleBuffered property.
        ''' It is set as a protected property. This method is a work-around to allow setting it.
        ''' Call this in the constructor just after InitializeComponent().
        ''' </summary>
        ''' <param name="_ctrl">The Control on which to set DoubleBuffered to true.</param>
        Public Shared Sub SetDoubleBuffered(ByVal _ctrl As Control)
            ' if not remote desktop session then enable double-buffering optimization
            If Not System.Windows.Forms.SystemInformation.TerminalServerSession Then

                ' set instance non-public property with name "DoubleBuffered" to true
                GetType(Control).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic, Nothing, _ctrl, New Object() {True})
            End If
        End Sub

        Public Shared Sub SetDoubleBuffered_ListControls(ByVal _ctrlList As List(Of Control))
            ' if not remote desktop session then enable double-buffering optimization
            If Not System.Windows.Forms.SystemInformation.TerminalServerSession Then

                For Each ctrl As Control In _ctrlList

                    ' set instance non-public property with name "DoubleBuffered" to true
                    GetType(Control).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic, Nothing, ctrl, New Object() {True})

                Next

            End If
        End Sub

        ''' <summary>
        ''' Original code found here: http://stackoverflow.com/questions/118528/horrible-redraw-performance-of-the-datagridview-on-one-of-my-two-screens
        ''' Suspend drawing updates for the specified control. After the control has been updated
        ''' call DrawingControl.ResumeDrawing(Control control).
        ''' </summary>
        ''' <param name="_ctrl">The control to suspend draw updates on.</param>
        Public Shared Sub SuspendDrawing(ByVal _ctrl As Control)
            SendMessage(_ctrl.Handle, WM_SETREDRAW, False, 0)
        End Sub

        Public Shared Sub SuspendDrawing_ListControls(ByVal _ctrlList As List(Of Control))

            For Each ctrl As Control In _ctrlList

                SendMessage(ctrl.Handle, WM_SETREDRAW, False, 0)

            Next

        End Sub

        ''' <summary>
        ''' Resume drawing updates for the specified control.
        ''' </summary>
        ''' <param name="_ctrl">The control to resume draw updates on.</param>
        Public Shared Sub ResumeDrawing(ByVal _ctrl As Control)
            SendMessage(_ctrl.Handle, WM_SETREDRAW, True, 0)
            _ctrl.Refresh()
        End Sub

        Public Shared Sub ResumeDrawing_ListControls(ByVal _ctrlList As List(Of Control))

            For Each ctrl As Control In _ctrlList

                SendMessage(ctrl.Handle, WM_SETREDRAW, True, 0)
                ctrl.Refresh()

            Next

        End Sub

    End Class

End Module
