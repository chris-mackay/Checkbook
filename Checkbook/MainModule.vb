'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2017 Christopher Mackay

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
Imports System.Xml
Imports System.Text

Module MainModule

    'MODULE LEVEL VARIABLES HAVE A PREFIX OF 'm_'. THESE VARIABLES ARE USED THROUGHOUT THE ENTIRE APPLICATION.

    Public m_helpProvider As HelpProvider 'THIS STORES CHECKBOOK HELP SO IT CAN BE ACCESSED THROUGHOUT PROGRAM

    Public m_ledgerIsBeingBalanced As Boolean = False 'STORES WHETHER THE LEDGER IS BEING BALANCED
    Public m_ledgerIsBeingFiltered As Boolean = False 'STORES WHETHER THE LEDGER IS BEING FILTERED

    'FRMFILTER
    Public m_frmFilter As frmFilter = Nothing 'USED TO DETERMINED IF THE ADVANCED FILTER FORM IS OPEN. THE USER CAN EDIT AND ADD TRANSACTIONS AND THE FILTERS WILL BE APPLIED.
    Public m_ledgerIsBeingFiltered_Advanced As Boolean = False 'STORES WHETHER THE LEDGER IS BEING FILTERED FROM ADVANCED FILTER

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

    'SPENDINGOVERVIEW
    Public m_globalUsedCategoryCollection As New Microsoft.VisualBasic.Collection
    Public m_globalUsedPayeeCollection As New Microsoft.VisualBasic.Collection
    Public m_CategoriesPayees As String 'THIS VARIABLE STORES EITHER THE STRING 'Categories' or 'Payees' WHICH IS USED IN FRMCREATEEXPENSE.

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

    Public Sub GetAllYearsFromDataGridView_FillList_ComboBox(ByVal list As List(Of Integer), ByVal comboBox As ComboBox)

        Dim dtDate As Date = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows 'FINDS ALL THE YEARS THAT EXIST IN THE LEDGER AND LOADS THEM INTO THE LIST

            Dim intYear As Integer
            Dim i As Integer = Nothing
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            If Not list.Contains(intYear) Then

                list.Add(intYear)

            End If

            If Not comboBox.Items.Contains(intYear) Then

                comboBox.Items.Add(intYear) 'IF THE YEAR DOESNT ALREADY EXIST WITHIN THE LIST THEN IT WILL BE ADDED

            End If

        Next

    End Sub

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

        strUnclearHighlightColorSetting = GetCheckbookSettingsValue(CheckbookSettings.UnclearedColor)
        blnColorUncleared = GetCheckbookSettingsValue(CheckbookSettings.ColorUncleared)

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

        strUnclearHighlightColorSetting = GetCheckbookSettingsValue(CheckbookSettings.UnclearedColor)
        blnColorUncleared = GetCheckbookSettingsValue(CheckbookSettings.ColorUncleared)

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

    Public Function GetLedgerSettingsFile(ByVal _ledgerFile As String) As String

        Dim strFullPath As String

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Settings\" & System.IO.Path.GetFileNameWithoutExtension(_ledgerFile) & ".cks"

        Return strFullPath
    End Function


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

            If m_ledgerIsBeingFiltered_Advanced Then

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

        'SETS SETTINGS
        With MainForm.dgvLedger

            If .Columns.Contains("Type") = True Then
                intTypeColSize = .Columns("Type").Width
                SetCheckbookSettingsValue(CheckbookSettings.TypeColSize, intTypeColSize.ToString)
            End If

            If .Columns.Contains("Category") = True Then
                intCategoryColSize = .Columns("Category").Width
                SetCheckbookSettingsValue(CheckbookSettings.CatColSize, intCategoryColSize.ToString)
            End If

            If .Columns.Contains("TransDate") = True Then
                intDateColSize = .Columns("TransDate").Width
                SetCheckbookSettingsValue(CheckbookSettings.DateColSize, intDateColSize.ToString)
            End If

            If .Columns.Contains("Payment") = True Then
                intPaymentColSize = .Columns("Payment").Width
                SetCheckbookSettingsValue(CheckbookSettings.PaymentColSize, intPaymentColSize.ToString)
            End If

            If .Columns.Contains("Deposit") = True Then
                intDepositColSize = .Columns("Deposit").Width
                SetCheckbookSettingsValue(CheckbookSettings.DepositColSize, intDepositColSize.ToString)
            End If

            If .Columns.Contains("Payee") = True Then
                intPayeeColSize = .Columns("Payee").Width
                SetCheckbookSettingsValue(CheckbookSettings.PayeeColSize, intPayeeColSize.ToString)
            End If

            If .Columns.Contains("Description") = True Then
                intDescriptionColSize = .Columns("Description").Width
                SetCheckbookSettingsValue(CheckbookSettings.DescriptionColSize, intDescriptionColSize.ToString)
            End If

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
            .Columns("Type").Width = GetCheckbookSettingsValue(CheckbookSettings.TypeColSize)
            .Columns("Type").ReadOnly = True

            'CATEGORY
            .Columns("Category").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Category").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Category").Width = GetCheckbookSettingsValue(CheckbookSettings.CatColSize)
            .Columns("Category").ReadOnly = True

            'TRANSDATE
            .Columns("TransDate").HeaderText = "Date"
            .Columns("TransDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("TransDate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TransDate").Width = GetCheckbookSettingsValue(CheckbookSettings.DateColSize)

            If m_ledgerIsBeingBalanced Then

                .Sort(.Columns("TransDate"), System.ComponentModel.ListSortDirection.Ascending)

            Else

                .Sort(.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)

            End If
            
            .Columns("TransDate").ReadOnly = True

            'PAYMENT
            .Columns("Payment").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Payment").Width = GetCheckbookSettingsValue(CheckbookSettings.PaymentColSize)
            .Columns("Payment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Payment").ReadOnly = True
            .Columns("Payment").SortMode = False

            'DEPOSIT
            .Columns("Deposit").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Deposit").Width = GetCheckbookSettingsValue(CheckbookSettings.DepositColSize)
            .Columns("Deposit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Deposit").ReadOnly = True
            .Columns("Deposit").SortMode = False

            'PAYEE
            .Columns("Payee").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Payee").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Payee").Width = GetCheckbookSettingsValue(CheckbookSettings.PayeeColSize)
            .Columns("Payee").ReadOnly = True

            'DESCRIPTION
            .Columns("Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("Description").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Description").Width = GetCheckbookSettingsValue(CheckbookSettings.DescriptionColSize)
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

    ''' <summary>
    ''' Provides a descrete list of settings that can be read and set.
    ''' To create a new setting or update an existing one use the Sub 'SetCheckbookSettingsValue()'.
    ''' To get the current value of a setting use the Function 'GetCheckbookSettingsValue()'
    ''' </summary>
    Public NotInheritable Class CheckbookSettings

        Private Sub New()
        End Sub

        'LEDGER GRAPHICS
        Public Const GridColor As String = "//Settings/GridColor"
        Public Const AlternatingRowColor As String = "//Settings/AlternatingRowColor"
        Public Const RowHighlightColor As String = "//Settings/RowHighlightColor"
        Public Const UnclearedColor As String = "//Settings/UnclearedColor"
        Public Const ColorUncleared As String = "//Settings/ColorUncleared"
        Public Const ColorAlternatingRows As String = "//Settings/ColorAlternatingRows"
        Public Const ToolBarButtonList As String = "//Settings/ToolBarButtonList"

        'GRID SETTINGS
        Public Const ShowGrids As String = "//Settings/ShowGrids"
        Public Const CellBorder As String = "//Settings/CellBorder"
        Public Const RowGridLines As String = "//Settings/RowGridLines"
        Public Const ColumnGridLines As String = "//Settings/ColumnGridLines"

        'COLUMN SIZES
        Public Const TypeColSize As String = "//Settings/TypeColSize"
        Public Const CatColSize As String = "//Settings/CatColSize"
        Public Const DateColSize As String = "//Settings/DateColSize"
        Public Const PaymentColSize As String = "//Settings/PaymentColSize"
        Public Const DepositColSize As String = "//Settings/DepositColSize"
        Public Const PayeeColSize As String = "//Settings/PayeeColSize"
        Public Const DescriptionColSize As String = "//Settings/DescriptionColSize"

        'DEFAULT DIRECTORIES
        Public Const DefaultWhatifSaveDirectory As String = "//Settings/DefaultWhatifSaveDirectory"
        Public Const DefaultImportTransactionsDirectory As String = "//Settings/DefaultImportTransactionsDirectory"
        Public Const DefaultExportTransactionsDirectory As String = "//Settings/DefaultExportTransactionsDirectory"
        Public Const DefaultBackupLedgerDirectory As String = "//Settings/DefaultBackupLedgerDirectory"
        Public Const DefaultChooseReceiptDirectory As String = "//Settings/DefaultChooseReceiptDirectory"

        'SPENDING OVERVIEW CHARTS
        Public Const ChartExploded As String = "//Settings/ChartExploded"
        Public Const ChartColorPalette As String = "//Settings/ChartColorPalette"
        Public Const ChartBackgroundColor As String = "//Settings/ChartBackgroundColor"
        Public Const ChartType As String = "//Settings/ChartType"

    End Class

    ''' <summary>
    ''' Provide a CheckbookSettings member for the 'setting' parameter.
    ''' Loads the ledger settings .cks file and reads the setting provided as a String value.
    ''' If an optional 'ledgerFileName' is not provided then m_strCurrentFile will be used. Only provid the optional filename if no ledger is currently open.
    ''' </summary>
    ''' <param name="setting"></param>
    ''' <param name="ledgerFileName"></param>
    ''' <returns></returns>
    Public Function GetCheckbookSettingsValue(ByVal setting As String, Optional ByVal ledgerFileName As String = Nothing) As String

        Dim file As String = String.Empty
        Dim settingsFile As String = String.Empty

        If ledgerFileName Is Nothing Then ' GETS CURRENT FILE IF OPTIONAL PARAMETER WAS NOT PROVIDED, OR GETS THE CURRENTLY SELECTED FILENAME FROM THE OPEN LEDGER LIST

            file = m_strCurrentFile

        Else

            file = AppendLedgerDirectory(ledgerFileName)

        End If

        settingsFile = GetLedgerSettingsFile(file)

        Dim doc As New XmlDocument
        doc.Load(settingsFile)

        Dim value As String = String.Empty

        If Not doc.SelectSingleNode(setting) Is Nothing Then

            Dim node As XmlNode = doc.SelectSingleNode(setting)

            value = node.InnerText

        End If

        Return value
    End Function

    ''' <summary>
    ''' Provide a CheckbookSettings member for the 'setting' parameter.
    ''' Creates a new setting if it does not already exist.
    ''' If the setting already exists it with be updated with the 'value' param .
    ''' </summary>
    ''' <param name="setting"></param>
    ''' <param name="value"></param>
    Public Sub SetCheckbookSettingsValue(ByVal setting As String, ByVal value As String)

        Dim settingsFile As String = String.Empty
        settingsFile = GetLedgerSettingsFile(m_strCurrentFile)

        Dim doc As New XmlDocument()
        doc.Load(settingsFile)

        If doc.SelectSingleNode(setting) Is Nothing Then

            ' IF THE SETTING DOES NOT EXIST THEN CREATE IT

            setting = setting.Replace("//Settings/", "")

            ' Create a new element node.
            Dim newSetting As XmlNode = doc.CreateElement(setting)
            newSetting.InnerText = value
            doc.DocumentElement.AppendChild(newSetting)
            doc.Save(settingsFile)

        Else

            ' IF THE SETTING EXISTS THEN UPDATE IT
            Dim node As XmlNode = Nothing
            node = doc.SelectSingleNode(setting)

            node.InnerText = value
            doc.Save(settingsFile)

        End If

    End Sub

    Public Function LedgerSettingsFileExists(ByVal _ledgerFile As String) As Boolean

        Dim blnExists As Boolean = False

        If System.IO.File.Exists(GetLedgerSettingsFile(_ledgerFile)) Then

            blnExists = True

        Else

            blnExists = False

        End If

        Return blnExists
    End Function

    ''' <summary>
    ''' Creates a settings file and sets default values in the following location 'C:\Users\Username\Documents\My Checkbook Ledgers\Settings\LedgerName.cks'.
    ''' This file is created when a particular ledger is opened if it does not already exist.
    ''' </summary>
    Public Sub CreateLedgerSettings_SetDefaults()

        ' SETTINGS AND DEFAULTS MUST BE ADDED AS COMMA SEPARATED VALUES
        Dim LEDGER_SETTINGS_LIST As New Specialized.StringCollection ' EVERY TIME A NEW SETTING IN INTRODUCED IT MUST BE ADDED TO THIS LIST IN THE REGIONS BELOW

        Dim settingsFile As String = String.Empty
        settingsFile = GetLedgerSettingsFile(m_strCurrentFile)

#Region "LedgerGraphics"

        ' COLORS
        LEDGER_SETTINGS_LIST.Add("GridColor,#D3D3D3")
        LEDGER_SETTINGS_LIST.Add("AlternatingRowColor,#F5F5F5")
        LEDGER_SETTINGS_LIST.Add("RowHighlightColor,#B0C4DE")
        LEDGER_SETTINGS_LIST.Add("UnclearedColor,#FED8DE")

        ' GRID SETTINGS
        LEDGER_SETTINGS_LIST.Add("ShowGrids,True")
        LEDGER_SETTINGS_LIST.Add("CellBorder,True")
        LEDGER_SETTINGS_LIST.Add("RowGridLines,False")
        LEDGER_SETTINGS_LIST.Add("ColumnGridLines,False")
        LEDGER_SETTINGS_LIST.Add("ColorUncleared,True")
        LEDGER_SETTINGS_LIST.Add("ColorAlternatingRows,True")
        LEDGER_SETTINGS_LIST.Add("ToolBarButtonList,0|new_ledger,1|open,2|save_as,3|new_trans,4|delete_trans,5|edit_trans,6|cleared,7|uncleared,8|categories,9|payees,10|receipt,11|sum_selected,12|filter,13|balance")

#End Region

#Region "ColumnSizes"

        LEDGER_SETTINGS_LIST.Add("TypeColSize,100")
        LEDGER_SETTINGS_LIST.Add("CatColSize,105")
        LEDGER_SETTINGS_LIST.Add("DateColSize,100")
        LEDGER_SETTINGS_LIST.Add("PaymentColSize,75")
        LEDGER_SETTINGS_LIST.Add("DepositColSize,75")
        LEDGER_SETTINGS_LIST.Add("PayeeColSize,150")
        LEDGER_SETTINGS_LIST.Add("DescriptionColSize,200")

#End Region

#Region "DefaultDirectories"

        LEDGER_SETTINGS_LIST.Add("DefaultWhatifSaveDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        LEDGER_SETTINGS_LIST.Add("DefaultImportTransactionsDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        LEDGER_SETTINGS_LIST.Add("DefaultExportTransactionsDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        LEDGER_SETTINGS_LIST.Add("DefaultBackupLedgerDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        LEDGER_SETTINGS_LIST.Add("DefaultChooseReceiptDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)

#End Region

#Region "SpendingOverviewCharts"

        LEDGER_SETTINGS_LIST.Add("ChartExploded,False")
        LEDGER_SETTINGS_LIST.Add("ChartColorPalette,Excel")
        LEDGER_SETTINGS_LIST.Add("ChartBackgroundColor,#FFFFFF")
        LEDGER_SETTINGS_LIST.Add("ChartType,Pie")

#End Region

        If Not LedgerSettingsFileExists(m_strCurrentFile) Then

            Dim settings As New XmlWriterSettings()

            settings.Indent = True

            Dim XmlWrt As XmlWriter = XmlWriter.Create(settingsFile, settings)

            With XmlWrt

                .WriteStartDocument()

                ' SETTINGS FILE TITLE.
                .WriteComment("Ledger Settings.")

                ' WRITE THE ROOT ELEMENT.
                .WriteStartElement("Settings")

                ' EVERY TIME A NEW SETTING IS INTRODUCED TO CHECKBOOK IT MUST BE ADDED TO DEFAULTS IN THE REGIONS BELOW

                Dim arr As String()

                For Each setting As String In LEDGER_SETTINGS_LIST

                    arr = Split(setting, ",", 2)

                    Dim settingName As String = arr(0)
                    Dim defaultValue As String = arr(1)

                    .WriteStartElement(settingName)
                    .WriteString(defaultValue)
                    .WriteEndElement()

                Next

                ' CLOSE THE XMLTEXTWRITER.
                .WriteEndDocument()
                .Close()

            End With

        Else

            ' IF THE SETTINGS FILE DOES EXIST, THIS CHECKS TO SEE IF ALL SETTINGS EXIST IN THE FILE.

            Dim xmlDoc As New XmlDocument()

            xmlDoc.Load(settingsFile)
            Dim elm As XmlElement = xmlDoc.DocumentElement
            Dim lstSettings As XmlNodeList = elm.ChildNodes
            Dim arr As String()
            Dim nodeNames As New Specialized.StringCollection ' THIS COLLECTION HOLDS ALL SETTINGS IN THE .cks SETTINGS FILE. USED TO CHECK AGAINST LEDGER_SETTINGS_LIST

            For Each node As XmlNode In lstSettings

                nodeNames.Add(node.Name)

            Next

            For Each setting As String In LEDGER_SETTINGS_LIST

                arr = Split(setting, ",", 2)

                Dim settingName As String = arr(0)
                Dim defaultValue As String = arr(1)

                ' IF THE SETTING DOES NOT EXIST THEN CREATE IT
                If Not nodeNames.Contains(settingName) Then

                    ' Create a new element node.
                    Dim newSetting As XmlNode = xmlDoc.CreateElement(settingName)
                    newSetting.InnerText = defaultValue
                    xmlDoc.DocumentElement.AppendChild(newSetting)
                    xmlDoc.Save(settingsFile)

                End If

            Next

        End If

    End Sub

    Public Function Convert_CSV_Button_List_To_Collection(ByVal buttonList_csv_list As String) As Specialized.StringCollection

        ' FORMAT TO BE READ FROM SETTINGS
        ' 0|new_ledger,1|open,2|save_as,3|new_trans,4|delete_trans,5|edit_trans,6|cleared,7|uncleared,8|categories,9|payees,10|receipt,11|sum_selected,12|filter,13|balance etc...

        Dim buttonCollection As New System.Collections.Specialized.StringCollection

        Dim chrSeparator As Char() = New Char() {","c}
        Dim arrButtons As String() = buttonList_csv_list.Split(chrSeparator, StringSplitOptions.None)

        For index = 0 To arrButtons.Length - 1

            Dim button As String = arrButtons(index)
            buttonCollection.Add(button.Replace("|", ","))

            ' BUTTONS WILL BE ADDED TO THE LIST IN THE FORMAT BELOW
            ' 0,new_ledger
            ' 1,open
            ' etc...

        Next

        Return buttonCollection
    End Function

    Public Function Convert_ButtonCollection_To_Settings_String(ByVal buttonCol As Specialized.StringCollection) As String

        Dim strRowIndex As String
        Dim strCommandName As String

        ' Declare new StringBuilder Dim.
        Dim builder As New StringBuilder

        Dim buttonListString As String = String.Empty
        Dim s As String = String.Empty

        For Each button As String In buttonCol

            ' BUTTONS WILL BE READ FROM THE LIST IN THE FORMAT BELOW AND CONVERTED INTO A STRING TO SAVE IN SETTINGS FILE
            ' 0,new_ledger
            ' 1,open
            ' etc...

            ' FORMAT TO BE SAVED IN SETTINGS
            ' 0|new_ledger,1|open,2|save_as,3|new_trans,4|delete_trans,5|edit_trans,6|cleared,7|uncleared,8|categories,9|payees,10|receipt,11|sum_selected,12|filter,13|balance etc...

            Dim chrSeparator As Char() = New Char() {","c}
            Dim arrButtons As String() = button.Split(chrSeparator, StringSplitOptions.None)

            strRowIndex = arrButtons(0)
            strCommandName = arrButtons(1)

            Dim strEntry As String = strRowIndex & "|" & strCommandName

            buttonListString = strEntry & ","

            ' Append a string to the StringBuilder.
            builder.Append(buttonListString)

            s = builder.ToString

        Next

        Dim chr As Char = ","
        buttonListString = s.TrimEnd(chr)

        Return buttonListString
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
