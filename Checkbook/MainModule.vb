'    Checkbook is a transaction register for Windows Desktop. It keeps track of how you are spending and making money.
'    Copyright(C) 2016-2021 Christopher Mackay

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
Imports System.IO

Module MainModule

    'MODULE LEVEL VARIABLES HAVE A PREFIX OF 'm_'. THESE VARIABLES ARE USED THROUGHOUT THE ENTIRE APPLICATION.

    Public m_strCurrentFile As String 'THIS IS THE FILENAME THIS IS CURRENTLY 'LOADED'. IT IS A MODULE LEVEL VARIABLE BECAUSE IT IS USED OFTEN AND NEEDS TO BE ACCESSIBLE.

    Public m_blnLedgerIsBeingBalanced As Boolean = False 'STORES WHETHER THE LEDGER IS BEING BALANCED
    Public m_blnLedgerIsBeingFiltered As Boolean = False 'STORES WHETHER THE LEDGER IS BEING FILTERED

    'FRMFILTER
    Public m_frmFilter As frmFilter = Nothing 'USED TO DETERMINED IF THE ADVANCED FILTER FORM IS OPEN. THE USER CAN EDIT AND ADD TRANSACTIONS AND THE FILTERS WILL BE APPLIED.
    Public m_blnLedgerIsBeingFiltered_Advanced As Boolean = False 'STORES WHETHER THE LEDGER IS BEING FILTERED FROM ADVANCED FILTER

    'FRMTRANS
    Public m_frmTrans As frmTransaction = Nothing

    Public caller_frmMyStatements As frmMyStatements

    Public m_blnDataIsBeingLoaded As Boolean = False
    Public m_blnNewVersionIsBeingDownloaded As Boolean = False

    'SCENARIO VARIABLES
    Public m_colMonths As New Microsoft.VisualBasic.Collection
    Public m_colUsedMonths As New Microsoft.VisualBasic.Collection

    'MAINFORM CONTROL LISTS
    Public m_lstAllMainFormControls As New List(Of Control)
    Public m_lstAccountDetailTextboxes As New List(Of Control)

    'SPENDINGOVERVIEW
    Public m_colGlobalUsedCategories As New Microsoft.VisualBasic.Collection
    Public m_colGlobalUsedPayees As New Microsoft.VisualBasic.Collection
    Public m_strCategoriesPayees As String 'THIS VARIABLE STORES EITHER THE STRING 'Categories' or 'Payees' WHICH IS USED IN FRMCREATEEXPENSE.

    Public m_blnTansactionIsBeingEdited As Boolean = False
    Public m_intDGVID As Integer = 0 'THIS IS THE ID OF THE SELECTED TRANSACTION TO UPDATE IF EDIT TRANSACTION IS SELECTED
    Public m_strOriginalReceiptToCopy As String = String.Empty 'CREATES A COPY OF THE RECEIPT FILE PROVIDED IN TO MY CHECKBOOK LEDGERS\RECEIPTS\FILENAME_RECEIPTS.
    Public m_strOriginalStatementToCopy As String = String.Empty 'CREATES A COPY OF THE STATEMENT FILE PROVIDED IN TO MY CHECKBOOK LEDGERS\STATEMENTS\FILENAME_STATEMENTS. 
    Public m_colReceiptFilesToDelete As New Microsoft.VisualBasic.Collection 'IF A RECEIPT IS REMOVED FROM THE TRANSACTION IT IS STORED IN THIS VARIABLE AND DELETES IT FROM MY CHECKBOOK LEDGERS\RECEIPTS\FILENAME_RECEIPTS IF BTNUPDATE IS CLICKED.

    Public m_clrMyGreen As Color = Color.FromArgb(239, 254, 218)
    Public m_clrMyRed As Color = Color.FromArgb(254, 216, 222)

    'STORES THE NUMBER OF TRANSACTIONS IN THE FILE
    'THIS IS USED THE DETERMINED WHETHER THE USER CAN OPEN FILTER
    Public m_intTransactionCount As Integer = 0

    Private DataCon As New clsLedgerDataManager
    Private FileCon As New clsLedgerDBConnector
    Private UIManager As New clsUIManager

    Public Sub CreateLedgerDirectories(ByVal _LedgerName As String)

        Dim strLedgerDirectory As String = String.Empty
        Dim strReceiptsDirectory As String = String.Empty
        Dim strStatementsDirectory As String = String.Empty
        Dim strScenariosDirectory As String = String.Empty

        strLedgerDirectory = AppendLedgerDirectory(_LedgerName)
        strReceiptsDirectory = AppendDirectory(strLedgerDirectory, "Receipts")
        strStatementsDirectory = AppendDirectory(strLedgerDirectory, "Statements")
        strScenariosDirectory = AppendDirectory(strLedgerDirectory, "Scenarios")

        If Not Directory.Exists(strLedgerDirectory) Then

            My.Computer.FileSystem.CreateDirectory(strLedgerDirectory)

        End If

        If Not Directory.Exists(strReceiptsDirectory) Then

            My.Computer.FileSystem.CreateDirectory(strReceiptsDirectory)

        End If

        If Not Directory.Exists(strStatementsDirectory) Then

            My.Computer.FileSystem.CreateDirectory(strStatementsDirectory)

        End If

        If Not Directory.Exists(strScenariosDirectory) Then

            My.Computer.FileSystem.CreateDirectory(strScenariosDirectory)

        End If

    End Sub

    Public Sub GetAllYearsFromDataGridView_FillList_ComboBox(ByVal _List As List(Of Integer), ByVal _ComboBox As ComboBox)

        Dim dtDate As Date = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim intYear As Integer = 0
            Dim i As Integer = 0
            i = dgvRow.Index

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            If Not _List.Contains(intYear) Then

                _List.Add(intYear)

            End If

            If Not _ComboBox.Items.Contains(intYear) Then

                _ComboBox.Items.Add(intYear)

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

    Public Sub FormatUncleared_SetClearedStatus_SetReceiptStatus()

        Dim clrUnclearedHighlightColor As Color
        Dim strUnclearHighlightColorSetting As String = String.Empty
        Dim blnColorUncleared As Boolean

        strUnclearHighlightColorSetting = GetCheckbookSettingsValue(CheckbookSettings.UnclearedColor)
        blnColorUncleared = GetCheckbookSettingsValue(CheckbookSettings.ColorUncleared)

        clrUnclearedHighlightColor = System.Drawing.ColorTranslator.FromHtml(strUnclearHighlightColorSetting)

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer = 0
            i = row.Index

#Region "COLOR UNCLEARED ROWS"

            Dim blnCleared As Boolean = False

            With MainForm

                If blnColorUncleared = True Then

                    blnCleared = .dgvLedger.Rows(i).Cells("Cleared").Value

                    If blnCleared = False Then

                        .dgvLedger.Rows(i).DefaultCellStyle.BackColor = clrUnclearedHighlightColor

                    End If

                Else

                    .dgvLedger.Rows(i).DefaultCellStyle.BackColor = Nothing

                End If

            End With

#End Region

#Region "SET CLEARED STATUS"

            blnCleared = MainForm.dgvLedger.Item("Cleared", i).Value.ToString

            If blnCleared = True Then

                MainForm.dgvLedger.Item("ClearedStatus", i).Value = "C"

            Else

                MainForm.dgvLedger.Item("ClearedStatus", i).Value = ""

            End If

#End Region

#Region "SET RECEIPT STATUS"

            Dim strReceipt As String = String.Empty

            strReceipt = MainForm.dgvLedger.Item("Receipt", i).Value.ToString

            If Not strReceipt = String.Empty Then

                MainForm.dgvLedger.Item("ReceiptStatus", i).Value = "R"

            Else

                MainForm.dgvLedger.Item("ReceiptStatus", i).Value = ""

            End If

#End Region

        Next

    End Sub

    Public Sub FormatUncleared()

        Dim clrUnclearedHighlightColor As Color
        Dim strUnclearHighlightColorSetting As String = String.Empty
        Dim blnColorUncleared As Boolean = False

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

    Public Function GetAllFilesInDirectoryGivenExtension(ByVal _Directory As String, ByVal _Extension As String) As List(Of String)

        Dim lstFilesInDirectory As New List(Of String)

        Dim i As Integer = 0

        Dim files As String()
        files = Directory.GetFiles(_Directory, "*." & _Extension, SearchOption.AllDirectories)
        For Each f As String In files
            lstFilesInDirectory.Add(f)
            i += 1
        Next

        Return lstFilesInDirectory
    End Function

    Public Sub RenameAllFilesInLedgerDirectory(ByVal _OldName As String, ByVal _NewName As String)

        Dim i As Integer = 0
        Dim path As String = AppendLedgerDirectory(_OldName)

        Dim files As String()

        files = Directory.GetFiles(path, "*")
        For Each f As String In files
            Dim ext As String = IO.Path.GetExtension(f)
            My.Computer.FileSystem.RenameFile(f, _NewName & ext)
            i += 1
        Next

    End Sub

    Public Sub DeleteAllFilesInDirectory(ByVal _Path As String)

        Dim i As Integer = 0

        Dim files As String()
        Dim file As String
        files = Directory.GetFiles(_Path, "*")
        For Each file In files
            System.IO.File.Delete(file)
            i += 1
        Next

    End Sub

    ''' <summary>
    ''' Append a filename with extension to a directory path.
    ''' </summary>
    ''' <param name="_Directory"></param>
    ''' <param name="_FileName"></param>
    ''' <returns></returns>
    Public Function AppendFileName(ByVal _Directory As String, ByVal _FileName As String) As String

        Dim file As String = String.Empty
        Dim sb As New StringBuilder

        sb.Append(_Directory)
        sb.Append("\" & _FileName)

        file = sb.ToString()

        Return file
    End Function

    ''' <summary>
    ''' Create a sub-directory provided the main path.
    ''' </summary>
    ''' <param name="_MainDirectory"></param>
    ''' <param name="_DirectoryToAdd"></param>
    ''' <returns></returns>
    Public Function AppendDirectory(ByVal _MainDirectory As String, ByVal _DirectoryToAdd As String) As String

        Dim directory As String = String.Empty
        Dim sb As New StringBuilder

        sb.Append(_MainDirectory)
        sb.Append("\" & _DirectoryToAdd)

        directory = sb.ToString()

        Return directory
    End Function

    Public Function GetLedgerSettingsFile(ByVal _LedgerName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & ".cks"

        Return strFullPath
    End Function

    Public Function AppendLedgerDirectory(ByVal _LedgerName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName)

        Return strFullPath
    End Function

    Public Function AppendLedgerPath(ByVal _LedgerName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & ".cbk"

        Return strFullPath
    End Function

    Public Function AppendReceiptPath(ByVal _LedgerName As String, ByVal _ReceiptFileName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\Receipts\" & _ReceiptFileName

        Return strFullPath
    End Function

    Public Function AppendStatementPath(ByVal _LedgerName As String, ByVal _StatementFileName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\Statements\" & _StatementFileName

        Return strFullPath
    End Function

    Public Function AppendReceiptDirectory(ByVal _LedgerName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\Receipts"

        Return strFullPath
    End Function

    Public Function AppendStatementDirectory(ByVal _LedgerName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\Statements"

        Return strFullPath
    End Function

    Public Function AppendScenarioPath(ByVal _LedgerName As String, ByVal _ScenarioName As String) As String

        Dim strFullPath As String = String.Empty

        strFullPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & System.IO.Path.GetFileNameWithoutExtension(_LedgerName) & "\Scenarios\" & _ScenarioName

        Return strFullPath
    End Function

    Public Sub RetainFilter()

        With MainForm

            'KEEPS FILTER RESULTS ACTIVE AFTER EDITING A TRANSACTION
            If .txtFilter.Visible = True And Not .txtFilter.Text = String.Empty Then
                FilterLedger()
            End If

            If m_blnLedgerIsBeingFiltered_Advanced Then

                m_frmFilter.ApplyFilters()

            End If

            .dgvLedger.ClearSelection()

        End With

    End Sub

    Public Sub RetainAccountBalancing()

        With MainForm

            'KEEPS FILTER RESULTS ACTIVE AFTER EDITING A TRANSACTION
            If m_blnLedgerIsBeingBalanced Then

                'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery & " WHERE Cleared=False")
                FileCon.Fill_Format_LedgerData_DataGrid_For_ExternalDrawingControl()
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
            Dim StatementName As String = " StatementName LIKE'%" & strSearch & "%'"
            bs.Filter = Type & "or" & Category & "or" & Payment & "or" & Deposit & "or" & Payee & "or" & Description & "or" & TransDate & "or" & Cleared & "or" & StatementName

            MainForm.dgvLedger.DataSource = bs

            FormatMainFormLedgerDataGridView()

            MainForm.dgvLedger.Sort(MainForm.dgvLedger.Columns("TransDate"), System.ComponentModel.ListSortDirection.Descending)
            con.Close()

            FormatUncleared_SetClearedStatus_SetReceiptStatus()

            MainForm.dgvLedger.ClearSelection()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Connection Failure", MsgButtons.OK, "Connection to the ledger could not be made." & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)
            Exit Sub

        End Try

    End Sub

    Public Function ConvertMonthFromIntegerToString(ByVal _Month As Integer)

        Dim _strMonth As String = String.Empty
        _strMonth = String.Empty

        If _Month = 1 Then
            _strMonth = "January"
        End If
        If _Month = 2 Then
            _strMonth = "February"
        End If
        If _Month = 3 Then
            _strMonth = "March"
        End If
        If _Month = 4 Then
            _strMonth = "April"
        End If
        If _Month = 5 Then
            _strMonth = "May"
        End If
        If _Month = 6 Then
            _strMonth = "June"
        End If
        If _Month = 7 Then
            _strMonth = "July"
        End If
        If _Month = 8 Then
            _strMonth = "August"
        End If
        If _Month = 9 Then
            _strMonth = "September"
        End If
        If _Month = 10 Then
            _strMonth = "October"
        End If
        If _Month = 11 Then
            _strMonth = "November"
        End If
        If _Month = 12 Then
            _strMonth = "December"
        End If

        Return _strMonth
    End Function

    Public Function ConvertMonthFromStringToInteger(ByVal _Month As String)

        Dim _intMonth As Integer = 0

        If _Month = "January" Then
            _intMonth = 1
        End If
        If _Month = "February" Then
            _intMonth = 2
        End If
        If _Month = "March" Then
            _intMonth = 3
        End If
        If _Month = "April" Then
            _intMonth = 4
        End If
        If _Month = "May" Then
            _intMonth = 5
        End If
        If _Month = "June" Then
            _intMonth = 6
        End If
        If _Month = "July" Then
            _intMonth = 7
        End If
        If _Month = "August" Then
            _intMonth = 8
        End If
        If _Month = "September" Then
            _intMonth = 9
        End If
        If _Month = "October" Then
            _intMonth = 10
        End If
        If _Month = "November" Then
            _intMonth = 11
        End If
        If _Month = "December" Then
            _intMonth = 12
        End If

        Return _intMonth
    End Function

    Public Sub SumMonthlyPaymentAndDeposits_FromLedger(ByVal _Month As String, ByVal _Year As Integer, ByRef _Payments As Double, ByRef _Deposits As Double)

        _Payments = 0
        _Deposits = 0

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strPayment As String = String.Empty
            Dim strDeposit As String = String.Empty
            Dim dtDate As Date = Nothing
            Dim intYear As Integer = 0
            Dim intMonth As Integer = 0

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intMonth = dtDate.Month
            intYear = dtDate.Year

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            If strPayment = String.Empty Then
                strPayment = 0
            Else
                strPayment = CDbl(strPayment)
            End If

            If strDeposit = String.Empty Then
                strDeposit = 0
            Else
                strDeposit = CDbl(strDeposit)
            End If

            If ConvertMonthFromIntegerToString(intMonth) = _Month And intYear = _Year Then
                _Payments += strPayment
                _Deposits += strDeposit
            End If

        Next

    End Sub

    Public Function SumPaymentsMonthly_FromMainFromLedger(ByVal _Month As String, ByVal _Year As Integer)

        Dim dblTotal As Double = 0

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strPayment As String = String.Empty
            Dim dtDate As Date = Nothing
            Dim intYear As Integer = 0
            Dim intMonth As Integer = 0

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intMonth = dtDate.Month
            intYear = dtDate.Year

            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString

            If strPayment = String.Empty Then
                strPayment = 0
            Else
                strPayment = CDbl(strPayment)
            End If

            If ConvertMonthFromIntegerToString(intMonth) = _Month And intYear = _Year Then
                dblTotal += strPayment
            End If

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Public Function SumDepositsMonthly_FromMainFormLedger(ByVal _Month As String, ByVal _Year As Integer)

        Dim dblTotal As Double = 0

        For i As Integer = 0 To MainForm.dgvLedger.RowCount - 1

            Dim strDeposit As String = String.Empty
            Dim dtDate As Date = Nothing
            Dim intMonth As Integer = 0
            Dim intYear As Integer = 0

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intMonth = dtDate.Month
            intYear = dtDate.Year

            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString

            If strDeposit = String.Empty Then
                strDeposit = 0
            Else
                strDeposit = CDbl(strDeposit)
            End If

            If ConvertMonthFromIntegerToString(intMonth) = _Month And intYear = _Year Then
                dblTotal += strDeposit
            End If

        Next

        Return FormatCurrency(dblTotal)
    End Function

    Public Sub DetermineCategoriesAndPayeesbyYear_Deposits(ByVal _Year As Integer)

        m_colGlobalUsedCategories.Clear()
        m_colGlobalUsedPayees.Clear()

        Dim dtDate As Date = Nothing
        Dim strCategory As String = String.Empty
        Dim strPayee As String = String.Empty
        Dim strPayment As String = String.Empty

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer = 0
            i = row.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString
            strPayment = MainForm.dgvLedger.Item("Payment", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _Year And strPayment = String.Empty And Not strCategory = "Uncategorized" Then

                m_colGlobalUsedCategories.Add(strCategory)

            End If

            If dtDate.Year = _Year And strPayment = String.Empty And Not strPayee = "Unknown" Then

                m_colGlobalUsedPayees.Add(strPayee)

            End If

        Next

        RemoveDuplicateCollectionItems(m_colGlobalUsedCategories)
        RemoveDuplicateCollectionItems(m_colGlobalUsedPayees)

    End Sub

    Public Sub DetermineCategoriesAndPayeesbyYear_Payments(ByVal _Year As Integer)

        m_colGlobalUsedCategories.Clear()
        m_colGlobalUsedPayees.Clear()

        Dim dtDate As Date = Nothing
        Dim strCategory As String = String.Empty
        Dim strPayee As String = String.Empty
        Dim strDeposit As String = String.Empty

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer = 0
            i = row.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            strPayee = MainForm.dgvLedger.Item("Payee", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _Year And strDeposit = String.Empty And Not strCategory = "Uncategorized" Then

                m_colGlobalUsedCategories.Add(strCategory)

            End If

            If dtDate.Year = _Year And strDeposit = String.Empty And Not strPayee = "Unknown" Then

                m_colGlobalUsedPayees.Add(strPayee)

            End If

        Next

        RemoveDuplicateCollectionItems(m_colGlobalUsedCategories)
        RemoveDuplicateCollectionItems(m_colGlobalUsedPayees)

    End Sub

    Public Sub DetermineCategoriesbyYear_Payments(ByVal _Year As Integer)

        m_colGlobalUsedCategories.Clear()

        Dim dtDate As Date = Nothing
        Dim strCategory As String = String.Empty
        Dim strDeposit As String = String.Empty

        For Each row As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim i As Integer = 0
            i = row.Index

            strCategory = MainForm.dgvLedger.Item("Category", i).Value.ToString
            strDeposit = MainForm.dgvLedger.Item("Deposit", i).Value.ToString
            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value

            If dtDate.Year = _Year And strDeposit = String.Empty And Not strCategory = "Uncategorized" Then

                m_colGlobalUsedCategories.Add(strCategory)

            End If

        Next

        RemoveDuplicateCollectionItems(m_colGlobalUsedCategories)

    End Sub

    Public Sub GetAndSetColumnWidths()

        Dim intTypeColSize As Integer = 0
        Dim intCategoryColSize As Integer = 0
        Dim intDateColSize As Integer = 0
        Dim intPaymentColSize As Integer = 0
        Dim intDepositColSize As Integer = 0
        Dim intPayeeColSize As Integer = 0
        Dim intDescriptionColSize As Integer = 0

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

    Public Sub CenterFormCenterScreen(ByVal _Object As Object)

        Dim currentArea = Screen.FromControl(_Object).WorkingArea
        _Object.Top = currentArea.Top + CInt((currentArea.Height / 2) - (_Object.Height / 2))
        _Object.Left = currentArea.Left + CInt((currentArea.Width / 2) - (_Object.Width / 2))

    End Sub

    Public Sub CountTotalListBoxItems_Display(ByVal _ListBox As ListBox, ByVal _Label As Label)

        _Label.Text = _ListBox.Items.Count & " total items"

    End Sub

    Public Sub CalculateTotalPayments_Deposits_BeforeProvidedYear(ByVal _Year As Integer, ByRef _TotalPaymentsPrior As Double, ByRef _TotalDespositsPrior As Double)

        _TotalPaymentsPrior = 0
        _TotalDespositsPrior = 0

        Dim dtDate As Date = Nothing

        For Each dgvRow As DataGridViewRow In MainForm.dgvLedger.Rows

            Dim intYear As Integer = 0
            Dim i As Integer = 0
            i = dgvRow.Index

            Dim payment As String = String.Empty
            Dim deposit As String = String.Empty

            dtDate = MainForm.dgvLedger.Item("TransDate", i).Value
            intYear = dtDate.Year

            payment = MainForm.dgvLedger.Item("Payment", i).Value
            deposit = MainForm.dgvLedger.Item("Deposit", i).Value

            If payment = String.Empty Then
                payment = 0
            Else
                payment = CDbl(payment)
            End If

            If deposit = String.Empty Then
                deposit = 0
            Else
                deposit = CDbl(deposit)
            End If

            If intYear < _Year Then

                _TotalPaymentsPrior += payment
                _TotalDespositsPrior += deposit

            End If

        Next

    End Sub

    Public Sub CalculateMonthlyIncome_And_AverageIncome_And_Balance(ByVal _DataGridView As DataGridView, ByVal _Year As Integer, Optional ByVal _IsCalculatingNextYear As Boolean = False, Optional ByVal _CurrentOverallBalance As Double = 0)

        Dim dblMonthlyIncome As Double = 0
        Dim dblTotalIncome As Double = 0
        Dim dblAverageIncome As Double = 0
        Dim dblTotalPayments As Double = 0
        Dim dblTotalDeposits As Double = 0
        Dim dblCurrentOverallBalance As Double = 0
        Dim dblBalance As Double = 0
        Dim dblStartBalance As Double = 0
        Dim dblTotalPaymentsPrior As Double = 0
        Dim dblTotalDepositsPrior As Double = 0
        Dim dblPreviousMonthBalance As Double = 0
        Dim intMonthCounter As Integer = 1

        dblStartBalance = CDbl(MainForm.txtStartingBalance.Text)

        If _IsCalculatingNextYear Then

            dblCurrentOverallBalance = _CurrentOverallBalance

        Else

            dblCurrentOverallBalance = CDbl(MainForm.txtOverallBalance.Text)

        End If

        CalculateTotalPayments_Deposits_BeforeProvidedYear(_Year, dblTotalPaymentsPrior, dblTotalDepositsPrior)

        For Each dgvRow As DataGridViewRow In _DataGridView.Rows

            Dim i As Integer = 0
            i = dgvRow.Index

            dblTotalPayments = _DataGridView.Item("Payments", i).Value
            dblTotalDeposits = _DataGridView.Item("Deposits", i).Value

            dblMonthlyIncome = dblTotalDeposits - dblTotalPayments
            dblTotalIncome += dblMonthlyIncome
            dblAverageIncome = dblTotalIncome / intMonthCounter

            If intMonthCounter = 1 Then

                If _IsCalculatingNextYear Then

                    'CALCULATES OVERALL BALANCE FOR JANUARY
                    dblBalance = dblCurrentOverallBalance - dblTotalPayments + dblTotalDeposits
                    'SETS PREVIOUS MONTH BALANCE FOR USE IN MONTHS GREATER THAN JANUARY
                    dblPreviousMonthBalance = dblBalance

                Else

                    'CALCULATES OVERALL BALANCE FOR JANUARY
                    dblBalance = dblStartBalance - dblTotalPaymentsPrior + dblTotalDepositsPrior - dblTotalPayments + dblTotalDeposits
                    'SETS PREVIOUS MONTH BALANCE FOR USE IN MONTHS GREATER THAN JANUARY
                    dblPreviousMonthBalance = dblBalance

                End If

            Else

                'CALCULATES OVERALL BALANCE FOR MONTHS GREATER THAN JANUARY. USES THE OVERALL BALANCE FROM THE PREVIOUS MONTH
                dblBalance = dblPreviousMonthBalance - dblTotalPayments + dblTotalDeposits
                'SETS PREVIOUS BALANCE FOR USE IN NEXT MONTHS CALCULATION
                dblPreviousMonthBalance = dblBalance

            End If

            intMonthCounter += 1 'ADDS 1 AFTER EACH ROW TO CALCULATE AVERAGE INCOME

            'FORMAT NUMBER TO CURRENCY
            dgvRow.Cells("Payments").Value = FormatCurrency(dblTotalPayments)
            dgvRow.Cells("Deposits").Value = FormatCurrency(dblTotalDeposits)
            dgvRow.Cells("Monthly").Value = FormatCurrency(dblMonthlyIncome)
            dgvRow.Cells("AveMonthlyIncome").Value = FormatCurrency(dblAverageIncome)
            dgvRow.Cells("OverallBalance").Value = FormatCurrency(dblBalance)

        Next

        FormatMonthlyGrid(_DataGridView)

    End Sub

    Public Sub FormatMonthlyGrid(ByVal _DataGridView As DataGridView)

        For Each dgvRow As DataGridViewRow In _DataGridView.Rows

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

            'FORMATS '$0.00' SO YOU DONT SEE IT
            If dgvRow.Cells("OverallBalance").Value = "$0.00" Then

                dgvRow.Cells("OverallBalance").Style.ForeColor = Color.Transparent
                dgvRow.Cells("OverallBalance").Style.SelectionForeColor = Color.Transparent

            Else

                dgvRow.Cells("OverallBalance").Style.ForeColor = Color.Black
                dgvRow.Cells("OverallBalance").Style.SelectionForeColor = Color.Black

            End If

            'FORMATS '$0.00' SO YOU DONT SEE IT
            If dgvRow.Cells("Monthly").Value = "$0.00" Then

                dgvRow.Cells("OverallBalance").Style.ForeColor = Color.Transparent
                dgvRow.Cells("OverallBalance").Style.SelectionForeColor = Color.Transparent

            Else

                dgvRow.Cells("OverallBalance").Style.ForeColor = Color.Black
                dgvRow.Cells("OverallBalance").Style.SelectionForeColor = Color.Black

            End If

        Next

    End Sub

    Public Function GetTotalPaymentsFromMonthlyGrid(ByVal _DataGridView As DataGridView) As Double 'GET TOTAL PAYMENTS TO UPDATE LEDGER STATUS FOR THAT PARTICULAR YEAR

        Dim dblTotal As Double = 0

        For Each dgvRow As DataGridViewRow In _DataGridView.Rows

            Dim strPayment As String = String.Empty
            strPayment = dgvRow.Cells("Payments").Value.ToString

            If strPayment = String.Empty Then
                strPayment = 0
            Else
                strPayment = CDbl(strPayment)
            End If

            dblTotal += strPayment

        Next

        Return dblTotal
    End Function

    Public Function GetTotalDepositsFromMonthlyGrid(ByVal _DataGridView As DataGridView) As Double 'GET TOTAL DEPOSITS TO UPDATE LEDGER STATUS FOR THAT PARTICULAR YEAR

        Dim dblTotal As Double = 0

        For Each dgvRow As DataGridViewRow In _DataGridView.Rows

            Dim strDeposit As String = String.Empty
            strDeposit = dgvRow.Cells("Deposits").Value.ToString

            If strDeposit = String.Empty Then
                strDeposit = 0
            Else
                strDeposit = CDbl(strDeposit)
            End If

            dblTotal += strDeposit

        Next

        Return dblTotal
    End Function

    Public Sub ColorTextboxes(ByVal _List As List(Of TextBox))

        For Each txtTextBox As TextBox In _List

            If txtTextBox.Text > 0 Then
                txtTextBox.BackColor = m_clrMyGreen
            End If
            If txtTextBox.Text < 0 Then
                txtTextBox.BackColor = m_clrMyRed
            End If
            If txtTextBox.Text = 0 Then
                txtTextBox.BackColor = Color.White
            End If

        Next

    End Sub

    Public Sub RemoveDuplicateCollectionItems(ByVal _Collection As Collection)

        For x = _Collection.Count To 2 Step -1

            For y = (x - 1) To 1 Step -1

                If _Collection.Item(x) = _Collection.Item(y) Then

                    _Collection.Remove(x)

                    Exit For

                End If

            Next

        Next

    End Sub

    Public Sub CreateMonthlyGridColumns(ByVal _DataGridView As DataGridView)

        MainModule.DrawingControl.SetDoubleBuffered(_DataGridView)
        MainModule.DrawingControl.SuspendDrawing(_DataGridView)

        _DataGridView.Columns.Clear()

        'CREATE DEFAULT CELL STYLE
        Dim dgvDefaultCellStyle As New DataGridViewCellStyle
        _DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

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
        Dim colBalance As New DataGridViewTextBoxColumn

        'SET NAME
        colMonthColumn.Name = "Month"
        colPaymentsColumn.Name = "Payments"
        colDepositsColumn.Name = "Deposits"
        colIncomeColumn.Name = "Monthly"
        colAverageIncomeColumn.Name = "AveMonthlyIncome"
        colBalance.Name = "OverallBalance"

        'SET HEADER TEXT
        colMonthColumn.HeaderText = "Month"
        colPaymentsColumn.HeaderText = "Payments"
        colDepositsColumn.HeaderText = "Deposits"
        colIncomeColumn.HeaderText = "Monthly Income"
        colAverageIncomeColumn.HeaderText = "Average Income"
        colBalance.HeaderText = "Overall Balance"

        'SET AUTOSIZE
        colMonthColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colPaymentsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDepositsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colIncomeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colAverageIncomeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colBalance.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'SET SORTABLE
        colMonthColumn.SortMode = False
        colPaymentsColumn.SortMode = False
        colDepositsColumn.SortMode = False
        colIncomeColumn.SortMode = False
        colAverageIncomeColumn.SortMode = False
        colBalance.SortMode = False

        'SET READONLY
        colMonthColumn.ReadOnly = True
        colPaymentsColumn.ReadOnly = True
        colDepositsColumn.ReadOnly = True
        colIncomeColumn.ReadOnly = True
        colAverageIncomeColumn.ReadOnly = True
        colBalance.ReadOnly = True

        'SET CELL TEMPLATE
        _DataGridView.DefaultCellStyle = dgvDefaultCellStyle

        'ADD COLUMNS TO DATAGRIDVIEW
        _DataGridView.Columns.Add(colMonthColumn)
        _DataGridView.Columns.Add(colPaymentsColumn)
        _DataGridView.Columns.Add(colDepositsColumn)
        _DataGridView.Columns.Add(colIncomeColumn)
        _DataGridView.Columns.Add(colAverageIncomeColumn)
        _DataGridView.Columns.Add(colBalance)

        MainModule.DrawingControl.ResumeDrawing(_DataGridView)

    End Sub

    Public Sub FormatMyStatementsDataGridView()

        'COLUMN ORDER
        'ID
        'STATEMENTNAME
        'STATEMENTFILENAME

        With caller_frmMyStatements.dgvMyStatements

            .ReadOnly = False

            'ID
            .Columns("ID").Visible = False
            .Columns("ID").ReadOnly = True

            'STATEMENTNAME
            .Columns("StatementName").HeaderText = "Statement Name"
            .Columns("StatementName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("StatementName").Resizable = DataGridViewTriState.False
            .Columns("StatementName").ReadOnly = True
            .Columns("StatementName").SortMode = False

            'STATEMENTFILENAME
            .Columns("StatementFileName").HeaderText = "Statement FileName"
            .Columns("StatementFileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("StatementFileName").Resizable = DataGridViewTriState.False
            .Columns("StatementFileName").Visible = False
            .Columns("StatementFileName").ReadOnly = True
            .Columns("StatementFileName").SortMode = False

        End With

    End Sub

    Public Sub FormatMainFormLedgerDataGridView()

        'COLUMN ORDER
        '(0) ID
        '(1) TYPE
        '(2) CATEGORY
        '(3) TRANSDATE
        '(4) PAYMENT
        '(5) DEPOSIT
        '(6) PAYEE
        '(7) DESCRIPTION
        '(8) CLEARED
        '(9) RECEIPT
        '(10) STATEMENT NAME
        '(11) STATEMENT FILE NAME
        '(12) CLEARED STATUS
        '(13) RECEIPT STATUS


        'FORMATS DATAGRIDVIEW
        With MainForm.dgvLedger

            .ReadOnly = False

            'ADD IMAGE COLUMN TO DATAGRIDVIEW
            Dim colCleared As New DataGridViewTextBoxColumn
            colCleared.CellTemplate = New DataGridViewTextBoxCell
            colCleared.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            colCleared.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colCleared.Resizable = DataGridViewTriState.False
            colCleared.Name = "ClearedStatus"
            colCleared.HeaderText = "Cleared"
            colCleared.Width = 60
            colCleared.DefaultCellStyle.NullValue = Nothing

            MainForm.dgvLedger.Columns.Insert(12, colCleared)

            'ADD IMAGE COLUMN TO DATAGRIDVIEW
            Dim colReceiptColumn As New DataGridViewTextBoxColumn
            colReceiptColumn.CellTemplate = New DataGridViewTextBoxCell
            colReceiptColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            colReceiptColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colReceiptColumn.Resizable = DataGridViewTriState.False
            colReceiptColumn.Name = "ReceiptStatus"
            colReceiptColumn.HeaderText = "Receipt"
            colReceiptColumn.Width = 60
            colReceiptColumn.DefaultCellStyle.NullValue = Nothing

            MainForm.dgvLedger.Columns.Insert(13, colReceiptColumn)

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

            If m_blnLedgerIsBeingBalanced Then

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

            'STATEMENT NAME 
            .Columns("StatementName").HeaderText = "Statement"
            .Columns("StatementName").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("StatementName").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("StatementName").Resizable = DataGridViewTriState.False
            .Columns("StatementName").Visible = True
            .Columns("StatementName").ReadOnly = True
            .Columns("StatementName").SortMode = False

            'STATEMENT FILE NAME 
            .Columns("StatementFileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("StatementFileName").Resizable = DataGridViewTriState.False
            .Columns("StatementFileName").Visible = False
            .Columns("StatementFileName").ReadOnly = True
            .Columns("StatementFileName").SortMode = False

        End With

    End Sub

    Public Function RemoveExtension(ByVal _FileName As String) As String

        Dim Dot As Integer = _FileName.LastIndexOf(".")

        Return _FileName.Substring(0, Dot)
    End Function

    ''' <summary>
    ''' Provides a discrete list of settings that can be read and set.
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
        Public Const DefaultScenarioSaveDirectory As String = "//Settings/DefaultScenarioSaveDirectory"
        Public Const DefaultImportTransactionsDirectory As String = "//Settings/DefaultImportTransactionsDirectory"
        Public Const DefaultExportTransactionsDirectory As String = "//Settings/DefaultExportTransactionsDirectory"
        Public Const DefaultBackupLedgerDirectory As String = "//Settings/DefaultBackupLedgerDirectory"
        Public Const DefaultChooseReceiptDirectory As String = "//Settings/DefaultChooseReceiptDirectory"
        Public Const DefaultChooseStatementDirectory As String = "//Settings/DefaultChooseStatementDirectory"

        'SPENDING OVERVIEW CHARTS
        Public Const ChartExploded As String = "//Settings/ChartExploded"
        Public Const ChartColorPalette As String = "//Settings/ChartColorPalette"
        Public Const ChartBackgroundColor As String = "//Settings/ChartBackgroundColor"
        Public Const ChartType As String = "//Settings/ChartType"

    End Class

    ''' <summary>
    ''' Provide a CheckbookSettings member for the 'setting' parameter.
    ''' Loads the ledger settings .cks file and reads the setting provided as a String value.
    ''' If an optional 'ledgerFileName' is not provided then m_strCurrentFile will be used. Only provide the optional filename if no ledger is currently open.
    ''' </summary>
    ''' <param name="_Setting"></param>
    ''' <param name="_LedgerName"></param>
    ''' <returns></returns>
    Public Function GetCheckbookSettingsValue(ByVal _Setting As String, Optional ByVal _LedgerName As String = Nothing) As String

        Dim file As String = String.Empty
        Dim settingsFile As String = String.Empty

        If _LedgerName Is Nothing Then ' GETS CURRENT FILE IF OPTIONAL PARAMETER WAS NOT PROVIDED, OR GETS THE CURRENTLY SELECTED FILENAME FROM THE OPEN LEDGER LIST

            file = m_strCurrentFile

        Else

            file = AppendLedgerPath(_LedgerName)

        End If

        settingsFile = GetLedgerSettingsFile(file)

        Dim doc As New XmlDocument
        doc.Load(settingsFile)

        Dim value As String = String.Empty

        If Not doc.SelectSingleNode(_Setting) Is Nothing Then

            Dim node As XmlNode = doc.SelectSingleNode(_Setting)

            value = node.InnerText

        End If

        Return value
    End Function

    ''' <summary>
    ''' Provide a CheckbookSettings member for the 'setting' parameter.
    ''' Creates a new setting if it does not already exist.
    ''' If the setting already exists it with be updated with the 'value' param .
    ''' </summary>
    ''' <param name="_Setting"></param>
    ''' <param name="_Value"></param>
    Public Sub SetCheckbookSettingsValue(ByVal _Setting As String, ByVal _Value As String)

        Dim settingsFile As String = String.Empty
        settingsFile = GetLedgerSettingsFile(m_strCurrentFile)

        Dim doc As New XmlDocument()
        doc.Load(settingsFile)

        If doc.SelectSingleNode(_Setting) Is Nothing Then

            ' IF THE SETTING DOES NOT EXIST THEN CREATE IT
            _Setting = _Setting.Replace("//Settings/", "")

            ' Create a new element node.
            Dim newSetting As XmlNode = doc.CreateElement(_Setting)
            newSetting.InnerText = _Value
            doc.DocumentElement.AppendChild(newSetting)
            doc.Save(settingsFile)

        Else

            ' IF THE SETTING EXISTS THEN UPDATE IT
            Dim node As XmlNode = Nothing
            node = doc.SelectSingleNode(_Setting)

            node.InnerText = _Value
            doc.Save(settingsFile)

        End If

    End Sub

    Public Function LedgerSettingsFileExists(ByVal _LedgerName As String) As Boolean

        Dim blnExists As Boolean = False

        If System.IO.File.Exists(GetLedgerSettingsFile(_LedgerName)) Then

            blnExists = True

        Else

            blnExists = False

        End If

        Return blnExists
    End Function

    ''' <summary>
    ''' This file is created when a particular ledger is opened if it does not already exist.
    ''' </summary>
    Public Sub CreateLedgerSettings_SetDefaults(ByVal _LedgerName As String)

        'SETTINGS AND DEFAULTS MUST BE ADDED AS COMMA SEPARATED VALUES
        Dim colLedgerSettings As New Specialized.StringCollection ' EVERY TIME A NEW SETTING IN INTRODUCED IT MUST BE ADDED TO THIS LIST IN THE REGIONS BELOW

        Dim strSettingsFile As String = String.Empty
        strSettingsFile = GetLedgerSettingsFile(_LedgerName)

#Region "LedgerGraphics"

        ' COLORS
        colLedgerSettings.Add("GridColor,#D3D3D3")
        colLedgerSettings.Add("AlternatingRowColor,#F5F5F5")
        colLedgerSettings.Add("RowHighlightColor,#B0C4DE")
        colLedgerSettings.Add("UnclearedColor,#FED8DE")

        ' GRID SETTINGS
        colLedgerSettings.Add("ShowGrids,True")
        colLedgerSettings.Add("CellBorder,True")
        colLedgerSettings.Add("RowGridLines,False")
        colLedgerSettings.Add("ColumnGridLines,False")
        colLedgerSettings.Add("ColorUncleared,True")
        colLedgerSettings.Add("ColorAlternatingRows,True")
        colLedgerSettings.Add("ToolBarButtonList,0|new_ledger,1|open,2|my_statements,3|save_as,4|new_trans,5|delete_trans,6|edit_trans,7|cleared,8|uncleared,9|categories,10|payees,11|receipt,12|statement,13|sum_selected,14|filter,15|balance")

#End Region

#Region "ColumnSizes"

        colLedgerSettings.Add("TypeColSize,100")
        colLedgerSettings.Add("CatColSize,105")
        colLedgerSettings.Add("DateColSize,100")
        colLedgerSettings.Add("PaymentColSize,75")
        colLedgerSettings.Add("DepositColSize,75")
        colLedgerSettings.Add("PayeeColSize,150")
        colLedgerSettings.Add("DescriptionColSize,200")

#End Region

#Region "DefaultDirectories"

        colLedgerSettings.Add("DefaultScenarioSaveDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        colLedgerSettings.Add("DefaultImportTransactionsDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        colLedgerSettings.Add("DefaultExportTransactionsDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        colLedgerSettings.Add("DefaultBackupLedgerDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        colLedgerSettings.Add("DefaultChooseReceiptDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        colLedgerSettings.Add("DefaultChooseStatementDirectory" & "," & My.Computer.FileSystem.SpecialDirectories.MyDocuments)

#End Region

#Region "SpendingOverviewCharts"

        colLedgerSettings.Add("ChartExploded,False")
        colLedgerSettings.Add("ChartColorPalette,Excel")
        colLedgerSettings.Add("ChartBackgroundColor,#FFFFFF")
        colLedgerSettings.Add("ChartType,Pie")

#End Region

        If Not LedgerSettingsFileExists(m_strCurrentFile) Then

            Dim settings As New XmlWriterSettings()

            settings.Indent = True

            Dim XmlWrt As XmlWriter = XmlWriter.Create(strSettingsFile, settings)

            With XmlWrt

                .WriteStartDocument()

                ' SETTINGS FILE TITLE.
                .WriteComment("Ledger Settings.")

                ' WRITE THE ROOT ELEMENT.
                .WriteStartElement("Settings")

                ' EVERY TIME A NEW SETTING IS INTRODUCED TO CHECKBOOK IT MUST BE ADDED TO DEFAULTS IN THE REGIONS BELOW

                Dim arr As String()

                For Each setting As String In colLedgerSettings

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

            XmlWrt = Nothing

        Else

            ' IF THE SETTINGS FILE DOES EXIST, THIS CHECKS TO SEE IF ALL SETTINGS EXIST IN THE FILE.
            Dim xmlDoc As New XmlDocument()

            xmlDoc.Load(strSettingsFile)
            Dim elm As XmlElement = xmlDoc.DocumentElement
            Dim lstSettings As XmlNodeList = elm.ChildNodes
            Dim arr As String()
            Dim nodeNames As New Specialized.StringCollection ' THIS COLLECTION HOLDS ALL SETTINGS IN THE .cks SETTINGS FILE. USED TO CHECK AGAINST LEDGER_SETTINGS_LIST

            For Each node As XmlNode In lstSettings

                nodeNames.Add(node.Name)

            Next

            For Each setting As String In colLedgerSettings

                arr = Split(setting, ",", 2)

                Dim settingName As String = arr(0)
                Dim defaultValue As String = arr(1)

                ' IF THE SETTING DOES NOT EXIST THEN CREATE IT
                If Not nodeNames.Contains(settingName) Then

                    ' Create a new element node.
                    Dim newSetting As XmlNode = xmlDoc.CreateElement(settingName)
                    newSetting.InnerText = defaultValue
                    xmlDoc.DocumentElement.AppendChild(newSetting)
                    xmlDoc.Save(strSettingsFile)

                End If

            Next

        End If

    End Sub

    Public Function Convert_CSV_Button_List_To_Collection(ByVal _CSVList As String) As Specialized.StringCollection

        ' FORMAT TO BE READ FROM SETTINGS
        ' 0|new_ledger,1|open,2|save_as,3|new_trans,4|delete_trans,5|edit_trans,6|cleared,7|uncleared,8|categories,9|payees,10|receipt,11|statement,12|sum_selected,13|filter,14|balance etc...

        Dim colButtons As New System.Collections.Specialized.StringCollection

        Dim chrSeparator As Char() = New Char() {","c}
        Dim arrButtons As String() = _CSVList.Split(chrSeparator, StringSplitOptions.None)

        For index = 0 To arrButtons.Length - 1

            Dim strButton As String = arrButtons(index)
            colButtons.Add(strButton.Replace("|", ","))

            ' BUTTONS WILL BE ADDED TO THE LIST IN THE FORMAT BELOW
            ' 0,new_ledger
            ' 1,open
            ' etc...

        Next

        Return colButtons
    End Function

    Public Function Convert_ButtonCollection_To_Settings_String(ByVal _Collection As Specialized.StringCollection) As String

        Dim strRowIndex As String
        Dim strCommandName As String

        ' Declare new StringBuilder Dim.
        Dim sb As New StringBuilder

        Dim strButtonsList As String = String.Empty
        Dim s As String = String.Empty

        For Each button As String In _Collection

            ' BUTTONS WILL BE READ FROM THE LIST IN THE FORMAT BELOW AND CONVERTED INTO A STRING TO SAVE IN SETTINGS FILE
            ' 0,new_ledger
            ' 1,open
            ' etc...

            ' FORMAT TO BE SAVED IN SETTINGS
            ' 0|new_ledger,1|open,2|save_as,3|new_trans,4|delete_trans,5|edit_trans,6|cleared,7|uncleared,8|categories,9|payees,10|receipt,11|statement,12|sum_selected,13|filter,14|balance etc...

            Dim chrSeparator As Char() = New Char() {","c}
            Dim arrButtons As String() = button.Split(chrSeparator, StringSplitOptions.None)

            strRowIndex = arrButtons(0)
            strCommandName = arrButtons(1)

            Dim strEntry As String = strRowIndex & "|" & strCommandName

            strButtonsList = strEntry & ","

            ' Append a string to the StringBuilder.
            sb.Append(strButtonsList)

            s = sb.ToString

        Next

        Dim chr As Char = ","
        strButtonsList = s.TrimEnd(chr)

        Return strButtonsList
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
