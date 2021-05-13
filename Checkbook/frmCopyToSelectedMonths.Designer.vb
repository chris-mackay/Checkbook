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
Partial Class frmCopyToSelectedMonths
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyToSelectedMonths))
        Me.ckbJan = New System.Windows.Forms.CheckBox()
        Me.ckbFeb = New System.Windows.Forms.CheckBox()
        Me.ckbMar = New System.Windows.Forms.CheckBox()
        Me.ckbApr = New System.Windows.Forms.CheckBox()
        Me.ckbMay = New System.Windows.Forms.CheckBox()
        Me.ckbJun = New System.Windows.Forms.CheckBox()
        Me.ckbJul = New System.Windows.Forms.CheckBox()
        Me.ckbAug = New System.Windows.Forms.CheckBox()
        Me.ckbSep = New System.Windows.Forms.CheckBox()
        Me.ckbOct = New System.Windows.Forms.CheckBox()
        Me.ckbNov = New System.Windows.Forms.CheckBox()
        Me.ckbDec = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ckbJan
        '
        Me.ckbJan.AutoSize = True
        Me.ckbJan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbJan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbJan.Location = New System.Drawing.Point(42, 83)
        Me.ckbJan.Name = "ckbJan"
        Me.ckbJan.Size = New System.Drawing.Size(63, 17)
        Me.ckbJan.TabIndex = 1
        Me.ckbJan.Text = "January"
        Me.ckbJan.UseVisualStyleBackColor = True
        '
        'ckbFeb
        '
        Me.ckbFeb.AutoSize = True
        Me.ckbFeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbFeb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbFeb.Location = New System.Drawing.Point(42, 106)
        Me.ckbFeb.Name = "ckbFeb"
        Me.ckbFeb.Size = New System.Drawing.Size(67, 17)
        Me.ckbFeb.TabIndex = 2
        Me.ckbFeb.Text = "February"
        Me.ckbFeb.UseVisualStyleBackColor = True
        '
        'ckbMar
        '
        Me.ckbMar.AutoSize = True
        Me.ckbMar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbMar.Location = New System.Drawing.Point(42, 129)
        Me.ckbMar.Name = "ckbMar"
        Me.ckbMar.Size = New System.Drawing.Size(56, 17)
        Me.ckbMar.TabIndex = 3
        Me.ckbMar.Text = "March"
        Me.ckbMar.UseVisualStyleBackColor = True
        '
        'ckbApr
        '
        Me.ckbApr.AutoSize = True
        Me.ckbApr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbApr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbApr.Location = New System.Drawing.Point(42, 152)
        Me.ckbApr.Name = "ckbApr"
        Me.ckbApr.Size = New System.Drawing.Size(46, 17)
        Me.ckbApr.TabIndex = 4
        Me.ckbApr.Text = "April"
        Me.ckbApr.UseVisualStyleBackColor = True
        '
        'ckbMay
        '
        Me.ckbMay.AutoSize = True
        Me.ckbMay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbMay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbMay.Location = New System.Drawing.Point(42, 175)
        Me.ckbMay.Name = "ckbMay"
        Me.ckbMay.Size = New System.Drawing.Size(46, 17)
        Me.ckbMay.TabIndex = 5
        Me.ckbMay.Text = "May"
        Me.ckbMay.UseVisualStyleBackColor = True
        '
        'ckbJun
        '
        Me.ckbJun.AutoSize = True
        Me.ckbJun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbJun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbJun.Location = New System.Drawing.Point(42, 198)
        Me.ckbJun.Name = "ckbJun"
        Me.ckbJun.Size = New System.Drawing.Size(49, 17)
        Me.ckbJun.TabIndex = 6
        Me.ckbJun.Text = "June"
        Me.ckbJun.UseVisualStyleBackColor = True
        '
        'ckbJul
        '
        Me.ckbJul.AutoSize = True
        Me.ckbJul.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbJul.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbJul.Location = New System.Drawing.Point(137, 83)
        Me.ckbJul.Name = "ckbJul"
        Me.ckbJul.Size = New System.Drawing.Size(44, 17)
        Me.ckbJul.TabIndex = 7
        Me.ckbJul.Text = "July"
        Me.ckbJul.UseVisualStyleBackColor = True
        '
        'ckbAug
        '
        Me.ckbAug.AutoSize = True
        Me.ckbAug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbAug.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbAug.Location = New System.Drawing.Point(137, 106)
        Me.ckbAug.Name = "ckbAug"
        Me.ckbAug.Size = New System.Drawing.Size(59, 17)
        Me.ckbAug.TabIndex = 8
        Me.ckbAug.Text = "August"
        Me.ckbAug.UseVisualStyleBackColor = True
        '
        'ckbSep
        '
        Me.ckbSep.AutoSize = True
        Me.ckbSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbSep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbSep.Location = New System.Drawing.Point(137, 129)
        Me.ckbSep.Name = "ckbSep"
        Me.ckbSep.Size = New System.Drawing.Size(77, 17)
        Me.ckbSep.TabIndex = 9
        Me.ckbSep.Text = "September"
        Me.ckbSep.UseVisualStyleBackColor = True
        '
        'ckbOct
        '
        Me.ckbOct.AutoSize = True
        Me.ckbOct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbOct.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbOct.Location = New System.Drawing.Point(137, 152)
        Me.ckbOct.Name = "ckbOct"
        Me.ckbOct.Size = New System.Drawing.Size(64, 17)
        Me.ckbOct.TabIndex = 10
        Me.ckbOct.Text = "October"
        Me.ckbOct.UseVisualStyleBackColor = True
        '
        'ckbNov
        '
        Me.ckbNov.AutoSize = True
        Me.ckbNov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbNov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbNov.Location = New System.Drawing.Point(137, 175)
        Me.ckbNov.Name = "ckbNov"
        Me.ckbNov.Size = New System.Drawing.Size(75, 17)
        Me.ckbNov.TabIndex = 11
        Me.ckbNov.Text = "November"
        Me.ckbNov.UseVisualStyleBackColor = True
        '
        'ckbDec
        '
        Me.ckbDec.AutoSize = True
        Me.ckbDec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbDec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.ckbDec.Location = New System.Drawing.Point(137, 198)
        Me.ckbDec.Name = "ckbDec"
        Me.ckbDec.Size = New System.Drawing.Size(75, 17)
        Me.ckbDec.TabIndex = 12
        Me.ckbDec.Text = "December"
        Me.ckbDec.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblInfo)
        Me.GroupBox1.Controls.Add(Me.ckbDec)
        Me.GroupBox1.Controls.Add(Me.ckbJan)
        Me.GroupBox1.Controls.Add(Me.ckbNov)
        Me.GroupBox1.Controls.Add(Me.ckbFeb)
        Me.GroupBox1.Controls.Add(Me.ckbOct)
        Me.GroupBox1.Controls.Add(Me.ckbMar)
        Me.GroupBox1.Controls.Add(Me.ckbSep)
        Me.GroupBox1.Controls.Add(Me.ckbApr)
        Me.GroupBox1.Controls.Add(Me.ckbAug)
        Me.GroupBox1.Controls.Add(Me.ckbMay)
        Me.GroupBox1.Controls.Add(Me.ckbJul)
        Me.GroupBox1.Controls.Add(Me.ckbJun)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 253)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Months"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(29, 34)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(194, 26)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Select each month below that you want" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to copy your selected totals to." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(190, 277)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(109, 277)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmCopyToSelectedMonths
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(277, 312)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCopyToSelectedMonths"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy To Selected Months"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ckbJan As CheckBox
    Friend WithEvents ckbFeb As CheckBox
    Friend WithEvents ckbMar As CheckBox
    Friend WithEvents ckbApr As CheckBox
    Friend WithEvents ckbMay As CheckBox
    Friend WithEvents ckbJun As CheckBox
    Friend WithEvents ckbJul As CheckBox
    Friend WithEvents ckbAug As CheckBox
    Friend WithEvents ckbSep As CheckBox
    Friend WithEvents ckbOct As CheckBox
    Friend WithEvents ckbNov As CheckBox
    Friend WithEvents ckbDec As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
