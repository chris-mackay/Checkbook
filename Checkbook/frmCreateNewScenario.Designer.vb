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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCreateNewScenario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateNewScenario))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.rbModelCurrentYearKeepValues = New System.Windows.Forms.RadioButton()
        Me.rbModelCurrentYearFromScratch = New System.Windows.Forms.RadioButton()
        Me.rbModelNextYearAndOverallDetails = New System.Windows.Forms.RadioButton()
        Me.gbModelingOptions = New System.Windows.Forms.GroupBox()
        Me.rbModelNextYearFromScratch = New System.Windows.Forms.RadioButton()
        Me.gbModelingOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(348, 158)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCreate.Location = New System.Drawing.Point(267, 158)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 1
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'rbModelCurrentYearKeepValues
        '
        Me.rbModelCurrentYearKeepValues.AutoSize = True
        Me.rbModelCurrentYearKeepValues.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbModelCurrentYearKeepValues.Location = New System.Drawing.Point(23, 27)
        Me.rbModelCurrentYearKeepValues.Name = "rbModelCurrentYearKeepValues"
        Me.rbModelCurrentYearKeepValues.Size = New System.Drawing.Size(156, 17)
        Me.rbModelCurrentYearKeepValues.TabIndex = 0
        Me.rbModelCurrentYearKeepValues.TabStop = True
        Me.rbModelCurrentYearKeepValues.Text = "Model (year) in current state"
        Me.rbModelCurrentYearKeepValues.UseVisualStyleBackColor = True
        '
        'rbModelCurrentYearFromScratch
        '
        Me.rbModelCurrentYearFromScratch.AutoSize = True
        Me.rbModelCurrentYearFromScratch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbModelCurrentYearFromScratch.Location = New System.Drawing.Point(23, 50)
        Me.rbModelCurrentYearFromScratch.Name = "rbModelCurrentYearFromScratch"
        Me.rbModelCurrentYearFromScratch.Size = New System.Drawing.Size(144, 17)
        Me.rbModelCurrentYearFromScratch.TabIndex = 1
        Me.rbModelCurrentYearFromScratch.TabStop = True
        Me.rbModelCurrentYearFromScratch.Text = "Model (year) from scratch"
        Me.rbModelCurrentYearFromScratch.UseVisualStyleBackColor = True
        '
        'rbModelNextYearAndOverallDetails
        '
        Me.rbModelNextYearAndOverallDetails.AutoSize = True
        Me.rbModelNextYearAndOverallDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbModelNextYearAndOverallDetails.Location = New System.Drawing.Point(23, 73)
        Me.rbModelNextYearAndOverallDetails.Name = "rbModelNextYearAndOverallDetails"
        Me.rbModelNextYearAndOverallDetails.Size = New System.Drawing.Size(367, 17)
        Me.rbModelNextYearAndOverallDetails.TabIndex = 2
        Me.rbModelNextYearAndOverallDetails.TabStop = True
        Me.rbModelNextYearAndOverallDetails.Text = "Model next year (year) and keep 'Current Year Details'  as a starting point"
        Me.rbModelNextYearAndOverallDetails.UseVisualStyleBackColor = True
        '
        'gbModelingOptions
        '
        Me.gbModelingOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbModelingOptions.Controls.Add(Me.rbModelCurrentYearFromScratch)
        Me.gbModelingOptions.Controls.Add(Me.rbModelNextYearFromScratch)
        Me.gbModelingOptions.Controls.Add(Me.rbModelNextYearAndOverallDetails)
        Me.gbModelingOptions.Controls.Add(Me.rbModelCurrentYearKeepValues)
        Me.gbModelingOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.gbModelingOptions.Location = New System.Drawing.Point(12, 12)
        Me.gbModelingOptions.Name = "gbModelingOptions"
        Me.gbModelingOptions.Size = New System.Drawing.Size(411, 140)
        Me.gbModelingOptions.TabIndex = 0
        Me.gbModelingOptions.TabStop = False
        Me.gbModelingOptions.Text = "Modeling Options"
        '
        'rbModelNextYearFromScratch
        '
        Me.rbModelNextYearFromScratch.AutoSize = True
        Me.rbModelNextYearFromScratch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.rbModelNextYearFromScratch.Location = New System.Drawing.Point(23, 96)
        Me.rbModelNextYearFromScratch.Name = "rbModelNextYearFromScratch"
        Me.rbModelNextYearFromScratch.Size = New System.Drawing.Size(190, 17)
        Me.rbModelNextYearFromScratch.TabIndex = 3
        Me.rbModelNextYearFromScratch.TabStop = True
        Me.rbModelNextYearFromScratch.Text = "Model next year (year) from scratch"
        Me.rbModelNextYearFromScratch.UseVisualStyleBackColor = True
        '
        'frmScenario
        '
        Me.AcceptButton = Me.btnCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(435, 193)
        Me.Controls.Add(Me.gbModelingOptions)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScenario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create New Scenario"
        Me.gbModelingOptions.ResumeLayout(False)
        Me.gbModelingOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents rbModelCurrentYearKeepValues As RadioButton
    Friend WithEvents rbModelCurrentYearFromScratch As RadioButton
    Friend WithEvents rbModelNextYearAndOverallDetails As RadioButton
    Friend WithEvents gbModelingOptions As GroupBox
    Friend WithEvents rbModelNextYearFromScratch As RadioButton
End Class
