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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInstallAccess
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstallAccess))
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDownloadAccess = New System.Windows.Forms.Button()
        Me.lblGotoMicrosoft = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.DownloadAccessProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(15, 15)
        Me.lblWelcome.Margin = New System.Windows.Forms.Padding(6)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(177, 20)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Welcome to Checkbook"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(16, 56)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(6)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(429, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Checkbook requires Microsoft software to function. Please read below before proce" &
    "eding."
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.Location = New System.Drawing.Point(298, 168)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 23)
        Me.btnFinish.TabIndex = 3
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(379, 168)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDownloadAccess
        '
        Me.btnDownloadAccess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownloadAccess.Location = New System.Drawing.Point(187, 168)
        Me.btnDownloadAccess.Name = "btnDownloadAccess"
        Me.btnDownloadAccess.Size = New System.Drawing.Size(105, 23)
        Me.btnDownloadAccess.TabIndex = 2
        Me.btnDownloadAccess.Text = "Download"
        Me.btnDownloadAccess.UseVisualStyleBackColor = True
        '
        'lblGotoMicrosoft
        '
        Me.lblGotoMicrosoft.AutoSize = True
        Me.lblGotoMicrosoft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGotoMicrosoft.Location = New System.Drawing.Point(16, 81)
        Me.lblGotoMicrosoft.Margin = New System.Windows.Forms.Padding(6)
        Me.lblGotoMicrosoft.MaximumSize = New System.Drawing.Size(440, 0)
        Me.lblGotoMicrosoft.Name = "lblGotoMicrosoft"
        Me.lblGotoMicrosoft.Size = New System.Drawing.Size(431, 39)
        Me.lblGotoMicrosoft.TabIndex = 2
        Me.lblGotoMicrosoft.Text = "Click ""Download"" to download the ""Microsoft Office Access Runtime (English) 2007""" &
    " installer. Once downloading is complete run the installer. When the installatio" &
    "n is complete click ""Finish""."
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.White
        Me.pnlInfo.Controls.Add(Me.lblWelcome)
        Me.pnlInfo.Controls.Add(Me.lblGotoMicrosoft)
        Me.pnlInfo.Controls.Add(Me.lblMessage)
        Me.pnlInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(466, 157)
        Me.pnlInfo.TabIndex = 0
        '
        'DownloadAccessProgressBar
        '
        Me.DownloadAccessProgressBar.Location = New System.Drawing.Point(10, 171)
        Me.DownloadAccessProgressBar.Name = "DownloadAccessProgressBar"
        Me.DownloadAccessProgressBar.Size = New System.Drawing.Size(169, 16)
        Me.DownloadAccessProgressBar.TabIndex = 1
        Me.DownloadAccessProgressBar.Visible = False
        '
        'frmInstallAccess
        '
        Me.AcceptButton = Me.btnDownloadAccess
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(466, 203)
        Me.Controls.Add(Me.DownloadAccessProgressBar)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.btnDownloadAccess)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnFinish)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstallAccess"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Install Microsoft Office Access Runtime 2007"
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDownloadAccess As System.Windows.Forms.Button
    Friend WithEvents lblGotoMicrosoft As System.Windows.Forms.Label
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents DownloadAccessProgressBar As ProgressBar
End Class
