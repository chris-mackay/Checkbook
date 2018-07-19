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

Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds
Imports ADOX
Public Class clsLedgerDBFileManager

    Inherits System.Windows.Forms.Form

    'CREATES A LINE OF COMMUNICATION BETWEEN FORMS
    Public caller_frmSaveAs As frmSaveAs
    Public caller_frmMyCheckbookLedgers As frmMyCheckbookLedgers

    'NEW INSTANCES OF CLASSES
    Private FileCon As New clsLedgerDBConnector
    Private DataCon As New clsLedgerDataManager
    Private UIManager As New clsUIManager

    Public Sub OpenFilefromBackup()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Try

            UIManager.SetCursor(MainForm, Cursors.WaitCursor)

            'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
            FileCon.Connect()
            FileCon.SQLselect(FileCon.strSelectAllQuery)
            FileCon.Fill_Format_LedgerData_DataGrid()
            FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

            'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
            DataCon.LedgerStatus()

            'LOAD TOOLBAR BUTTONS
            MainForm.LoadButtonSettings_Or_CreateDefaultButtons()

        Catch ex As Exception

            CheckbookMsg.ShowMessage("Refresh Error", MsgButtons.OK, "An error occurred while refreshing the current ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

        Finally

            'CLOSES THE DATABASE
            FileCon.Close()
            UIManager.SetCursor(MainForm, Cursors.Default)
            MainForm.dgvLedger.ClearSelection()

            UIManager.UpdateStatusStripInfo()

        End Try

    End Sub

    Public Sub SaveAs()

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        Dim strSaveAs_ledger_fullFile As String
        Dim strSaveAs_budgets_fullFile As String
        Dim strSaveAs_fileName As String
        Dim strBudgets_fullFile As String

        strBudgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & ".bgt"

        If Not My.Computer.FileSystem.FileExists(m_strCurrentFile) Then 'CHECKS TO MAKE SURE THE CURRENT FILE EXISTS IN THE PROGRAM FOLDER

            CheckbookMsg.ShowMessage("Missing Current Ledger", MsgButtons.OK, "The current ledger does not exist in 'My Checkbook Ledgers'" & vbNewLine & "It may have been moved or deleted", Exclamation)

        Else

            strSaveAs_fileName = caller_frmSaveAs.txtSaveAs.Text
            strSaveAs_ledger_fullFile = AppendLedgerDirectory(strSaveAs_fileName)

            If IO.File.Exists(strSaveAs_ledger_fullFile) Then

                CheckbookMsg.ShowMessage("Filename Conflict", MsgButtons.OK, "The ledger '" & strSaveAs_fileName & "' already exists. Provide a unique name for your ledger.", Exclamation)

            Else

                Try

                    strSaveAs_budgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strSaveAs_fileName & ".bgt"

                    caller_frmSaveAs.Dispose()

                    My.Computer.FileSystem.CopyFile(m_strCurrentFile, strSaveAs_ledger_fullFile) 'COPIES CURRENT LEDGER WITH NEW NAME

                    'BUDGETS FILE
                    If System.IO.File.Exists(strBudgets_fullFile) Then
                        My.Computer.FileSystem.CopyFile(strBudgets_fullFile, strSaveAs_budgets_fullFile) 'COPIES CURRENT BUDGET FILE WITH NEW NAME
                    End If

                    'SETTINGS FILE
                    If LedgerSettingsFileExists(m_strCurrentFile) Then
                        My.Computer.FileSystem.CopyFile(GetLedgerSettingsFile(m_strCurrentFile), GetLedgerSettingsFile(strSaveAs_fileName)) 'COPIES CURRENT SETTINGS FILE WITH NEW NAME
                    End If

                    'RECEIPTS DIRECTORY
                    If System.IO.Directory.Exists(AppendReceiptDirectory(m_strCurrentFile)) Then
                        CopyDirectory(AppendReceiptDirectory(m_strCurrentFile), AppendReceiptDirectory(strSaveAs_fileName)) 'COPIES CURRENT RECEIPTS DIRECTORY WITH NEW NAME
                    End If

                    'STATEMENTS DIRECTORY
                    If System.IO.Directory.Exists(AppendStatementDirectory(m_strCurrentFile)) Then
                        CopyDirectory(AppendStatementDirectory(m_strCurrentFile), AppendStatementDirectory(strSaveAs_fileName)) 'COPIES CURRENT STATEMENTS DIRECTORY WITH NEW NAME
                    End If

                    m_strCurrentFile = strSaveAs_ledger_fullFile 'SETS CURRENT FILE TO NEW SAVEAS FILE

                    'SETS APPLICATION TITLE
                    MainForm.Text = "Checkbook - " & strSaveAs_fileName

                    UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                    'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                    FileCon.Connect()
                    FileCon.SQLselect(FileCon.strSelectAllQuery)
                    FileCon.Fill_Format_LedgerData_DataGrid()
                    FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                    'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
                    DataCon.LedgerStatus()

                Catch ex As Exception

                    CheckbookMsg.ShowMessage("Save As Error", MsgButtons.OK, "An error occurred while saving the ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

                Finally

                    'CLOSES THE DATABASE
                    FileCon.Close()

                    Me.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

                    UIManager.SetCursor(MainForm, Cursors.Default)

                    UIManager.UpdateStatusStripInfo()

                End Try

            End If

        End If

    End Sub

    Public Sub LoadMyCheckbookLedgers_IntoDataGridView(ByVal _DatagridView As DataGridView) 'FILLS DATAGRIDVIEW WITH ALL THE LEDGER STORED IN MY DOCUMENTS. USED FOR OPENING LEDGERS

        _DatagridView.Rows.Clear()

        Dim folderInfo As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\")

        Dim arrFilesInFolder() As IO.FileInfo
        Dim fileInFolder As IO.FileInfo

        arrFilesInFolder = folderInfo.GetFiles("*.cbk*")
        For Each fileInFolder In arrFilesInFolder

            _DatagridView.Rows.Add(RemoveExtension(fileInFolder.Name), fileInFolder.LastWriteTime)

        Next

        _DatagridView.ClearSelection()

    End Sub

    Public Sub LoadMyCheckbookLedgers_IntoComboBox(ByVal _ComboBox As ComboBox) 'FILLS COMBOBOX WITH ALL THE LEDGER STORED IN MY DOCUMENTS. USED IN THE IMPORT CATEGORIES AND IMPORT PAYEES FORMS

        _ComboBox.Items.Clear()

        Dim folderInfo As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\")

        Dim arrFilesInFolder() As IO.FileInfo
        Dim fileInFolder As IO.FileInfo

        arrFilesInFolder = folderInfo.GetFiles("*.cbk*")
        For Each fileInFolder In arrFilesInFolder

            If Not RemoveExtension(fileInFolder.Name) = System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) Then

                _ComboBox.Items.Add(RemoveExtension(fileInFolder.Name))

            End If

        Next

    End Sub

    Public Sub CopyDirectory(ByVal _originalLocation As String, ByVal _newLocation As String)

        If Not System.IO.Directory.Exists(_newLocation) Then

            System.IO.Directory.CreateDirectory(_newLocation)

            My.Computer.FileSystem.CopyDirectory(_originalLocation, _newLocation, True)

        End If

    End Sub

    Public Sub AddMyCheckbookLedgerMenuItemsAndEventHandlers()

        MainForm.mnuOpen.DropDownItems.Clear()

        Dim folderInfo As New IO.DirectoryInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\")
        Dim checkbookLedgersList As New List(Of String)

        Dim arrFilesInFolder() As IO.FileInfo
        Dim fileInFolder As IO.FileInfo

        arrFilesInFolder = folderInfo.GetFiles("*.cbk*")

        For Each fileInFolder In arrFilesInFolder

            checkbookLedgersList.Add(RemoveExtension(fileInFolder.Name))

        Next

        For Each fileName As String In checkbookLedgersList

            Dim menuItem As New ToolStripMenuItem
            menuItem.Name = "mnu" & fileName
            menuItem.Text = fileName
            menuItem.Image = My.Resources.table

            MainForm.mnuOpen.DropDownItems.Add(menuItem)

            AddHandler menuItem.Click, AddressOf MainForm.OpenLedger_Click

        Next

    End Sub

    Public Sub CreateNewLedger_AccessDatabase(ByVal _fileName As String)

        Dim cat As New Catalog
        Dim con As New OleDb.OleDbConnection

        Dim connectString As String = String.Empty
        Dim dbProvider As String
        Dim dbSource As String

        dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
        dbSource = "Data Source = " & _fileName

        connectString = dbProvider & dbSource
        con.ConnectionString = connectString

        cat.Create(connectString)

        con.Open()

        'APPEND LEDGER DATA TO CATALOG
        CreateLedgerDataTable(cat)

        'APPEND CATEGORIES TO CATALOG
        CreateCategoryTable(cat)

        'APPEND PAYEES TO CATALOG
        CreatePayeeTable(cat)

        'APPEND STATEMENTS TO CATALOG
        CreateStatementsTable(cat)

        'APPEND STARTBALANCE TO CATALOG
        CreateStartBalanceTable(cat)

    End Sub

    Private Sub CreateLedgerDataTable(ByVal _cat As Catalog)

        Dim tblLedgerData As New Table

        Dim tableKey_LedgerData_ID As Key = New Key

        Dim colID As Column = New Column
        Dim colType As Column = New Column
        Dim colCategory As Column = New Column
        Dim colTransDate As Column = New Column
        Dim colPayment As Column = New Column
        Dim colDeposit As Column = New Column
        Dim colPayee As Column = New Column
        Dim colDescription As Column = New Column
        Dim colCleared As Column = New Column
        Dim colReceipt As Column = New Column
        Dim colStatementName As Column = New Column
        Dim colStatementFileName As Column = New Column

        'SET COLUMN PROPERTIES FOR LedgerData
        'Define column with AutoIncrement features
        colID.Name = "ID"
        colID.Type = DataTypeEnum.adInteger
        colID.ParentCatalog = _cat
        colID.Properties("AutoIncrement").Value = True

        'CREATE LEDGER DATA COLUMNS
        'Set ID as primary key
        tableKey_LedgerData_ID.Name = "Primary Key"
        tableKey_LedgerData_ID.Columns.Append("ID")
        tableKey_LedgerData_ID.Type = KeyTypeEnum.adKeyPrimary

        colType.Name = "Type"
        colType.Type = DataTypeEnum.adLongVarWChar
        colType.Attributes = ColumnAttributesEnum.adColNullable
        colType.ParentCatalog = _cat

        colCategory.Name = "Category"
        colCategory.Type = DataTypeEnum.adLongVarWChar
        colCategory.Attributes = ColumnAttributesEnum.adColNullable
        colCategory.ParentCatalog = _cat

        colTransDate.Name = "TransDate"
        colTransDate.Type = DataTypeEnum.adDate
        colTransDate.Attributes = ColumnAttributesEnum.adColNullable
        colTransDate.ParentCatalog = _cat

        colPayment.Name = "Payment"
        colPayment.Type = DataTypeEnum.adLongVarWChar
        colPayment.Attributes = ColumnAttributesEnum.adColNullable
        colPayment.ParentCatalog = _cat

        colDeposit.Name = "Deposit"
        colDeposit.Type = DataTypeEnum.adLongVarWChar
        colDeposit.Attributes = ColumnAttributesEnum.adColNullable
        colDeposit.ParentCatalog = _cat

        colPayee.Name = "Payee"
        colPayee.Type = DataTypeEnum.adLongVarWChar
        colPayee.Attributes = ColumnAttributesEnum.adColNullable
        colPayee.ParentCatalog = _cat

        colDescription.Name = "Description"
        colDescription.Type = DataTypeEnum.adLongVarWChar
        colDescription.Attributes = ColumnAttributesEnum.adColNullable
        colDescription.ParentCatalog = _cat

        colCleared.Name = "Cleared"
        colCleared.Type = DataTypeEnum.adBoolean
        colCleared.ParentCatalog = _cat

        colReceipt.Name = "Receipt"
        colReceipt.Type = DataTypeEnum.adLongVarWChar
        colReceipt.Attributes = ColumnAttributesEnum.adColNullable
        colReceipt.ParentCatalog = _cat

        colStatementName.Name = "StatementName"
        colStatementName.Type = DataTypeEnum.adLongVarWChar
        colStatementName.Attributes = ColumnAttributesEnum.adColNullable
        colStatementName.ParentCatalog = _cat

        colStatementFileName.Name = "StatementFileName"
        colStatementFileName.Type = DataTypeEnum.adLongVarWChar
        colStatementFileName.Attributes = ColumnAttributesEnum.adColNullable
        colStatementFileName.ParentCatalog = _cat

        'CREATE LedgerData TABLE
        tblLedgerData.Name = "LedgerData"
        tblLedgerData.Columns.Append(colID)
        tblLedgerData.Columns.Append(colType)
        tblLedgerData.Columns.Append(colCategory)
        tblLedgerData.Columns.Append(colTransDate)
        tblLedgerData.Columns.Append(colPayment)
        tblLedgerData.Columns.Append(colDeposit)
        tblLedgerData.Columns.Append(colPayee)
        tblLedgerData.Columns.Append(colDescription)
        tblLedgerData.Columns.Append(colCleared)
        tblLedgerData.Columns.Append(colReceipt)
        tblLedgerData.Columns.Append(colStatementName)
        tblLedgerData.Columns.Append(colStatementFileName)

        'APPEND LedgerData TABLE TO CATALOG
        _cat.Tables.Append(tblLedgerData)

    End Sub

    Private Sub CreateCategoryTable(ByVal _cat As Catalog)

        Dim tblCategories As New Table

        Dim colCategory As Column = New Column
        Dim colID As Column = New Column

        Dim tableKey_Category_ID As Key = New Key

        'Define column with AutoIncrement features
        colID.Name = "ID"
        colID.Type = DataTypeEnum.adInteger
        colID.ParentCatalog = _cat
        colID.Properties("AutoIncrement").Value = True


        'Set ID as primary key
        tableKey_Category_ID.Name = "Primary Key"
        tableKey_Category_ID.Columns.Append("ID")
        tableKey_Category_ID.Type = KeyTypeEnum.adKeyPrimary

        colCategory.Name = "Category"
        colCategory.Type = DataTypeEnum.adLongVarWChar
        colCategory.Attributes = ColumnAttributesEnum.adColNullable
        colCategory.ParentCatalog = _cat

        tblCategories.Name = "Categories"
        tblCategories.Columns.Append(colID)
        tblCategories.Columns.Append(colCategory)

        'APPEND Categories TABLE TO CATALOG
        _cat.Tables.Append(tblCategories)

    End Sub

    Private Sub CreatePayeeTable(ByVal _cat As Catalog)

        Dim tblPayees As New Table

        Dim colPayee As Column = New Column
        Dim colID As Column = New Column

        Dim tableKey_Payee_ID As Key = New Key

        'Define column with AutoIncrement features
        colID.Name = "ID"
        colID.Type = DataTypeEnum.adInteger
        colID.ParentCatalog = _cat
        colID.Properties("AutoIncrement").Value = True

        'Set ID as primary key
        tableKey_Payee_ID.Name = "Primary Key"
        tableKey_Payee_ID.Columns.Append("ID")
        tableKey_Payee_ID.Type = KeyTypeEnum.adKeyPrimary

        colPayee.Name = "Payee"
        colPayee.Type = DataTypeEnum.adLongVarWChar
        colPayee.Attributes = ColumnAttributesEnum.adColNullable
        colPayee.ParentCatalog = _cat

        tblPayees.Name = "Payees"
        tblPayees.Columns.Append(colID)
        tblPayees.Columns.Append(colPayee)

        'APPEND Categories TABLE TO CATALOG
        _cat.Tables.Append(tblPayees)

    End Sub

    Private Sub CreateStatementsTable(ByVal _cat As Catalog)

        Dim tblStatements As New Table

        Dim colStatementName As Column = New Column
        Dim colStatementFileName As Column = New Column
        Dim colID As Column = New Column

        Dim tableKey_Statement_ID As Key = New Key

        'Define column with AutoIncrement features
        colID.Name = "ID"
        colID.Type = DataTypeEnum.adInteger
        colID.ParentCatalog = _cat
        colID.Properties("AutoIncrement").Value = True

        'Set ID as primary key
        tableKey_Statement_ID.Name = "Primary Key"
        tableKey_Statement_ID.Columns.Append("ID")
        tableKey_Statement_ID.Type = KeyTypeEnum.adKeyPrimary

        colStatementName.Name = "StatementName"
        colStatementName.Type = DataTypeEnum.adLongVarWChar
        colStatementName.Attributes = ColumnAttributesEnum.adColNullable
        colStatementName.ParentCatalog = _cat

        colStatementFileName.Name = "StatementFileName"
        colStatementFileName.Type = DataTypeEnum.adLongVarWChar
        colStatementFileName.Attributes = ColumnAttributesEnum.adColNullable
        colStatementFileName.ParentCatalog = _cat

        tblStatements.Name = "Statements"
        tblStatements.Columns.Append(colID)
        tblStatements.Columns.Append(colStatementName)
        tblStatements.Columns.Append(colStatementFileName)

        'APPEND Statements TABLE TO CATALOG
        _cat.Tables.Append(tblStatements)

    End Sub

    Private Sub CreateStartBalanceTable(ByVal _cat As Catalog)

        Dim tblStartBalance As New Table

        Dim colBalance As Column = New Column
        Dim colID As Column = New Column

        Dim tableKey_StartBalance_ID As Key = New Key

        'Define column with AutoIncrement features
        colID.Name = "ID"
        colID.Type = DataTypeEnum.adInteger
        colID.ParentCatalog = _cat
        colID.Properties("AutoIncrement").Value = True

        'Set ID as primary key
        tableKey_StartBalance_ID.Name = "Primary Key"
        tableKey_StartBalance_ID.Columns.Append("ID")
        tableKey_StartBalance_ID.Type = KeyTypeEnum.adKeyPrimary

        colBalance.Name = "Balance"
        colBalance.Type = DataTypeEnum.adLongVarWChar
        colBalance.Attributes = ColumnAttributesEnum.adColNullable
        colBalance.ParentCatalog = _cat

        tblStartBalance.Name = "StartBalance"
        tblStartBalance.Columns.Append(colID)
        tblStartBalance.Columns.Append(colBalance)

        'APPEND Categories TABLE TO CATALOG
        _cat.Tables.Append(tblStartBalance)

    End Sub

End Class
