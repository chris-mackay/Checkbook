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

Imports CheckbookMessage.CheckbookMessage
Imports System.Media.SystemSounds
Imports ADOX
Public Class clsLedgerDBFileManager

    Inherits System.Windows.Forms.Form

    'CREATES A LINE OF COMMUNICATION BETWEEN FORMS
    Public caller_frmNewFileFromMenu As frmNewFileFromMenu
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
            FileCon.Fill_Format_DataGrid()
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

            Try

                strSaveAs_fileName = caller_frmSaveAs.txtSaveAs.Text

                strSaveAs_ledger_fullFile = AppendLedgerDirectory(strSaveAs_fileName)

                strSaveAs_budgets_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Budgets\" & strSaveAs_fileName & ".bgt"

                caller_frmSaveAs.Dispose()

                My.Computer.FileSystem.CopyFile(m_strCurrentFile, strSaveAs_ledger_fullFile) 'COPIES CURRENT LEDGER WITH NEW NAME

                CopyDirectory(AppendReceiptDirectory(m_strCurrentFile), AppendReceiptDirectory(strSaveAs_fileName)) 'COPIES CURRENT RECEIPTS DIRECTORY WITH NEW NAME

                If System.IO.File.Exists(strBudgets_fullFile) Then
                    My.Computer.FileSystem.CopyFile(strBudgets_fullFile, strSaveAs_budgets_fullFile) 'COPIES CURRENT BUDGET FILE WITH NEW NAME
                End If

                If LedgerSettingsFileExists(m_strCurrentFile) Then
                    My.Computer.FileSystem.CopyFile(GetLedgerSettingsFile(m_strCurrentFile), GetLedgerSettingsFile(strSaveAs_fileName)) 'COPIES CURRENT SETTINGS FILE WITH NEW NAME
                End If

                m_strCurrentFile = strSaveAs_ledger_fullFile 'SETS CURRENT FILE TO NEW SAVEAS FILE

                'SETS APPLICATION TITLE
                MainForm.Text = "Checkbook - " & strSaveAs_fileName

                UIManager.SetCursor(MainForm, Cursors.WaitCursor)

                'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                FileCon.Connect()
                FileCon.SQLselect(FileCon.strSelectAllQuery)
                FileCon.Fill_Format_DataGrid()
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

    Public Sub NewFileFromMenu(ByVal _filename As String, ByVal _startbalance As String)

        Dim CheckbookMsg As New CheckbookMessage.CheckbookMessage

        If _filename = "" And _startbalance = "" Then

            CheckbookMsg.ShowMessage("Please enter a filename and a value for starting balance", MsgButtons.OK, "", Exclamation)
            caller_frmNewFileFromMenu.txtNewLedger.Focus()

        ElseIf _filename = "" Then

            CheckbookMsg.ShowMessage("Please enter a filename", MsgButtons.OK, "", Exclamation)
            caller_frmNewFileFromMenu.txtNewLedger.Focus()

        ElseIf _startbalance = "" Then

            CheckbookMsg.ShowMessage("Please enter a value for starting balance", MsgButtons.OK, "Enter '0' if you wish to have a starting balance of zero", Exclamation)
            caller_frmNewFileFromMenu.txtStartBalance.Focus()

        Else

            Dim strNew_fullFile As String
            Dim strStartBalance As String
            Dim strNew_fileName As String

            Try

                strNew_fullFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\" & caller_frmNewFileFromMenu.txtNewLedger.Text & ".cbk"

                strNew_fileName = caller_frmNewFileFromMenu.txtNewLedger.Text

                strStartBalance = caller_frmNewFileFromMenu.txtStartBalance.Text

                caller_frmNewFileFromMenu.Dispose()

                MainForm.Show()
                MainForm.Activate()

                m_strCurrentFile = strNew_fullFile 'SAVES NEW NAME FOR LATER USE

                CreateNewLedger_AccessDatabase(m_strCurrentFile) 'CREATES NEW DATABASE WITH ADOX OBJECTS

                IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\My Checkbook Ledgers\Receipts\" & System.IO.Path.GetFileNameWithoutExtension(m_strCurrentFile) & "_Receipts")

                'CREATE SETTINGS FILE
                CreateLedgerSettings_SetDefaults()

                'LOAD TOOLBAR BUTTONS
                MainForm.LoadButtonSettings_Or_CreateDefaultButtons()

                'SETS APPLICATION TITLE
                MainForm.Text = "Checkbook - " & strNew_fileName

                'CONNECTS TO DATABASE AND FILLS DATAGRIDVIEW
                FileCon.Connect()
                FileCon.SQLinsert("INSERT INTO StartBalance (Balance) VALUES('" & strStartBalance & "')")
                FileCon.SQLselect(FileCon.strSelectAllQuery)
                FileCon.Fill_Format_DataGrid()
                FileCon.SQLreadStartBalance("SELECT * FROM StartBalance")

                'CALCULATES TOTAL PAYMENTS, DEPOSITS, AND ACCOUNT STATUS AND DISPLAYS IN TEXTBOXES
                DataCon.LedgerStatus()

            Catch exAlreadyExists As System.IO.IOException

                CheckbookMsg.ShowMessage("Ledger Already Exists", MsgButtons.OK, "A ledger already exists with the name you provided" & vbNewLine & "Please provide a unique name", Exclamation)

            Catch ex As Exception

                CheckbookMsg.ShowMessage("Create New Error", MsgButtons.OK, "An error occurred while creating the new ledger" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.Source, Exclamation)

            Finally

                'CLOSES THE DATABASE
                FileCon.Close()

            Me.AddMyCheckbookLedgerMenuItemsAndEventHandlers()

            UIManager.UpdateStatusStripInfo()

            'ENABLES ALL MENU AND TOOLSTRIP ITEMS IF STRFILE IS NOT EMPTY
            UIManager.Maintain_DisabledMainFormUI()

            End Try

        End If

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

    Private Sub CreateSettingsTable(ByVal _cat As Catalog)

        Dim tblSettings As New Table

        Dim colID As Column = New Column
        Dim colShowGrids As Column = New Column
        Dim colCellBorder As Column = New Column
        Dim colRowGridLines As Column = New Column
        Dim colColumnGridLines As Column = New Column
        Dim colGridColor As Column = New Column
        Dim colUnclearedHighlightColor As Column = New Column
        Dim colRowSelectionColor As Column = New Column
        Dim colAlternatingRowColor As Column = New Column
        Dim colColorUncleared As Column = New Column
        Dim colColorAlternatingRows As Column = New Column

        Dim tableKey_Settings_ID As Key = New Key

        'Define column with AutoIncrement features
        colID.Name = "ID"
        colID.Type = DataTypeEnum.adInteger
        colID.ParentCatalog = _cat
        colID.Properties("AutoIncrement").Value = True

        'Set ID as primary key
        tableKey_Settings_ID.Name = "Primary Key"
        tableKey_Settings_ID.Columns.Append("ID")
        tableKey_Settings_ID.Type = KeyTypeEnum.adKeyPrimary

        colShowGrids.Name = "ShowGrids"
        colShowGrids.Type = DataTypeEnum.adBoolean
        colShowGrids.ParentCatalog = _cat

        colCellBorder.Name = "CellBorder"
        colCellBorder.Type = DataTypeEnum.adBoolean
        colCellBorder.ParentCatalog = _cat

        colRowGridLines.Name = "RowGridLines"
        colRowGridLines.Type = DataTypeEnum.adBoolean
        colRowGridLines.ParentCatalog = _cat

        colColumnGridLines.Name = "ColumnGridLines"
        colColumnGridLines.Type = DataTypeEnum.adBoolean
        colColumnGridLines.ParentCatalog = _cat

        colGridColor.Name = "GridColor"
        colGridColor.Type = DataTypeEnum.adLongVarWChar
        colGridColor.ParentCatalog = _cat

        colUnclearedHighlightColor.Name = "UnclearedHighlightColor"
        colUnclearedHighlightColor.Type = DataTypeEnum.adLongVarWChar
        colUnclearedHighlightColor.ParentCatalog = _cat

        colRowSelectionColor.Name = "RowSelectionColor"
        colRowSelectionColor.Type = DataTypeEnum.adLongVarWChar
        colRowSelectionColor.ParentCatalog = _cat

        colAlternatingRowColor.Name = "AlternatingRowColor"
        colAlternatingRowColor.Type = DataTypeEnum.adLongVarWChar
        colAlternatingRowColor.ParentCatalog = _cat

        colColorUncleared.Name = "ColorUncleared"
        colColorUncleared.Type = DataTypeEnum.adBoolean
        colColorUncleared.ParentCatalog = _cat

        colColorAlternatingRows.Name = "ColorAlternatingRows"
        colColorAlternatingRows.Type = DataTypeEnum.adBoolean
        colColorAlternatingRows.ParentCatalog = _cat

        tblSettings.Name = "tblSettings"
        tblSettings.Columns.Append(colID)
        tblSettings.Columns.Append(colShowGrids)
        tblSettings.Columns.Append(colCellBorder)
        tblSettings.Columns.Append(colRowGridLines)
        tblSettings.Columns.Append(colColumnGridLines)
        tblSettings.Columns.Append(colGridColor)
        tblSettings.Columns.Append(colUnclearedHighlightColor)
        tblSettings.Columns.Append(colRowSelectionColor)
        tblSettings.Columns.Append(colAlternatingRowColor)
        tblSettings.Columns.Append(colColorUncleared)
        tblSettings.Columns.Append(colColorAlternatingRows)

        'APPEND Categories TABLE TO CATALOG
        _cat.Tables.Append(tblSettings)

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
