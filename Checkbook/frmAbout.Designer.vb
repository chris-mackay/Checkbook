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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblIcons = New System.Windows.Forms.Label()
        Me.gbIcons = New System.Windows.Forms.GroupBox()
        Me.lblCCLisense = New System.Windows.Forms.Label()
        Me.lblDisclaimer = New System.Windows.Forms.Label()
        Me.pbCheckbookApp = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblAbout = New System.Windows.Forms.Label()
        Me.gbLicenseAgreement = New System.Windows.Forms.GroupBox()
        Me.lblLicenseAgreement = New System.Windows.Forms.Label()
        Me.lblProgramDisclaimer = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.gbIcons.SuspendLayout()
        CType(Me.pbCheckbookApp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLicenseAgreement.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(502, 366)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblIcons
        '
        Me.lblIcons.AutoSize = True
        Me.lblIcons.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblIcons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIcons.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblIcons.Location = New System.Drawing.Point(32, 29)
        Me.lblIcons.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblIcons.Name = "lblIcons"
        Me.lblIcons.Size = New System.Drawing.Size(328, 13)
        Me.lblIcons.TabIndex = 6
        Me.lblIcons.Text = "Icons used in this application were designed by FatCow Webhosting"
        '
        'gbIcons
        '
        Me.gbIcons.Controls.Add(Me.lblCCLisense)
        Me.gbIcons.Controls.Add(Me.lblDisclaimer)
        Me.gbIcons.Controls.Add(Me.lblIcons)
        Me.gbIcons.Location = New System.Drawing.Point(12, 242)
        Me.gbIcons.Name = "gbIcons"
        Me.gbIcons.Size = New System.Drawing.Size(565, 112)
        Me.gbIcons.TabIndex = 7
        Me.gbIcons.TabStop = False
        Me.gbIcons.Text = "Application Icons"
        '
        'lblCCLisense
        '
        Me.lblCCLisense.AutoSize = True
        Me.lblCCLisense.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCCLisense.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCCLisense.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCCLisense.Location = New System.Drawing.Point(32, 71)
        Me.lblCCLisense.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCCLisense.Name = "lblCCLisense"
        Me.lblCCLisense.Size = New System.Drawing.Size(438, 13)
        Me.lblCCLisense.TabIndex = 9
        Me.lblCCLisense.Text = "The icons have been made available through the Attribution 3.0 Creative Commons L" &
    "icense"
        '
        'lblDisclaimer
        '
        Me.lblDisclaimer.AutoSize = True
        Me.lblDisclaimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisclaimer.Location = New System.Drawing.Point(32, 50)
        Me.lblDisclaimer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblDisclaimer.Name = "lblDisclaimer"
        Me.lblDisclaimer.Size = New System.Drawing.Size(430, 13)
        Me.lblDisclaimer.TabIndex = 7
        Me.lblDisclaimer.Text = "I am in no way affliated with FatCow and the icons used in this application are t" &
    "he originals"
        '
        'pbCheckbookApp
        '
        Me.pbCheckbookApp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbCheckbookApp.Image = CType(resources.GetObject("pbCheckbookApp.Image"), System.Drawing.Image)
        Me.pbCheckbookApp.Location = New System.Drawing.Point(12, 12)
        Me.pbCheckbookApp.Name = "pbCheckbookApp"
        Me.pbCheckbookApp.Size = New System.Drawing.Size(48, 48)
        Me.pbCheckbookApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbCheckbookApp.TabIndex = 14
        Me.pbCheckbookApp.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(12, 88)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 12
        Me.lblVersion.Text = "Version"
        '
        'lblAbout
        '
        Me.lblAbout.AutoSize = True
        Me.lblAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbout.Location = New System.Drawing.Point(12, 67)
        Me.lblAbout.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblAbout.Name = "lblAbout"
        Me.lblAbout.Size = New System.Drawing.Size(276, 13)
        Me.lblAbout.TabIndex = 11
        Me.lblAbout.Text = "Checkbook is a transacton register for Windows Desktop"
        '
        'gbLicenseAgreement
        '
        Me.gbLicenseAgreement.Controls.Add(Me.lblLicenseAgreement)
        Me.gbLicenseAgreement.Controls.Add(Me.lblProgramDisclaimer)
        Me.gbLicenseAgreement.Location = New System.Drawing.Point(12, 150)
        Me.gbLicenseAgreement.Name = "gbLicenseAgreement"
        Me.gbLicenseAgreement.Size = New System.Drawing.Size(565, 86)
        Me.gbLicenseAgreement.TabIndex = 10
        Me.gbLicenseAgreement.TabStop = False
        Me.gbLicenseAgreement.Text = "License Agreement"
        '
        'lblLicenseAgreement
        '
        Me.lblLicenseAgreement.AutoSize = True
        Me.lblLicenseAgreement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLicenseAgreement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseAgreement.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLicenseAgreement.Location = New System.Drawing.Point(32, 47)
        Me.lblLicenseAgreement.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblLicenseAgreement.Name = "lblLicenseAgreement"
        Me.lblLicenseAgreement.Size = New System.Drawing.Size(98, 13)
        Me.lblLicenseAgreement.TabIndex = 7
        Me.lblLicenseAgreement.Text = "License Agreement"
        '
        'lblProgramDisclaimer
        '
        Me.lblProgramDisclaimer.AutoSize = True
        Me.lblProgramDisclaimer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProgramDisclaimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramDisclaimer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgramDisclaimer.Location = New System.Drawing.Point(32, 26)
        Me.lblProgramDisclaimer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblProgramDisclaimer.Name = "lblProgramDisclaimer"
        Me.lblProgramDisclaimer.Size = New System.Drawing.Size(479, 13)
        Me.lblProgramDisclaimer.TabIndex = 6
        Me.lblProgramDisclaimer.Text = "Checkbook is public software. Use of this application shall comply with the licen" &
    "se agreement below."
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(12, 109)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(157, 13)
        Me.lblCopyright.TabIndex = 15
        Me.lblCopyright.Text = "Copyright © 2017 Chris Mackay"
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(589, 401)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.gbLicenseAgreement)
        Me.Controls.Add(Me.pbCheckbookApp)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblAbout)
        Me.Controls.Add(Me.gbIcons)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        Me.gbIcons.ResumeLayout(False)
        Me.gbIcons.PerformLayout()
        CType(Me.pbCheckbookApp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLicenseAgreement.ResumeLayout(False)
        Me.gbLicenseAgreement.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblIcons As System.Windows.Forms.Label
    Friend WithEvents gbIcons As System.Windows.Forms.GroupBox
    Friend WithEvents lblCCLisense As System.Windows.Forms.Label
    Friend WithEvents lblDisclaimer As System.Windows.Forms.Label
    Friend WithEvents pbCheckbookApp As System.Windows.Forms.PictureBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblAbout As System.Windows.Forms.Label
    Friend WithEvents gbLicenseAgreement As GroupBox
    Friend WithEvents lblLicenseAgreement As Label
    Friend WithEvents lblProgramDisclaimer As Label
    Friend WithEvents lblCopyright As Label
End Class
