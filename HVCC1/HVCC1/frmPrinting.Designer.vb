<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrinting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrinting))
        Me.dgvAddPrinting = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbUpdate = New System.Windows.Forms.ToolStripButton()
        Me.tbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.cmbPartNo = New System.Windows.Forms.ComboBox()
        Me.cmbCusNo2 = New System.Windows.Forms.ComboBox()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCusNo1 = New System.Windows.Forms.ComboBox()
        Me.txtLeakTest = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCusID = New System.Windows.Forms.ComboBox()
        Me.cmbPartID = New System.Windows.Forms.ComboBox()
        Me.lbID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPrintUse = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        CType(Me.dgvAddPrinting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAddPrinting
        '
        Me.dgvAddPrinting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAddPrinting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvAddPrinting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAddPrinting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgvAddPrinting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvAddPrinting.Location = New System.Drawing.Point(12, 275)
        Me.dgvAddPrinting.Name = "dgvAddPrinting"
        Me.dgvAddPrinting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAddPrinting.Size = New System.Drawing.Size(1247, 362)
        Me.dgvAddPrinting.TabIndex = 29
        '
        'Column1
        '
        Me.Column1.HeaderText = "No."
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbSave, Me.ToolStripSeparator1, Me.tbUpdate, Me.tbDelete, Me.ToolStripSeparator2, Me.tbRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1271, 39)
        Me.ToolStrip1.TabIndex = 30
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbSave
        '
        Me.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSave.Image = CType(resources.GetObject("tbSave.Image"), System.Drawing.Image)
        Me.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(36, 36)
        Me.tbSave.Text = "Save Order No."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'tbUpdate
        '
        Me.tbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbUpdate.Image = CType(resources.GetObject("tbUpdate.Image"), System.Drawing.Image)
        Me.tbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbUpdate.Name = "tbUpdate"
        Me.tbUpdate.Size = New System.Drawing.Size(36, 36)
        Me.tbUpdate.Text = "Update Order Number"
        '
        'tbDelete
        '
        Me.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbDelete.Image = CType(resources.GetObject("tbDelete.Image"), System.Drawing.Image)
        Me.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbDelete.Name = "tbDelete"
        Me.tbDelete.Size = New System.Drawing.Size(36, 36)
        Me.tbDelete.Text = "Delete Order No."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'tbRefresh
        '
        Me.tbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbRefresh.Image = CType(resources.GetObject("tbRefresh.Image"), System.Drawing.Image)
        Me.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbRefresh.Name = "tbRefresh"
        Me.tbRefresh.Size = New System.Drawing.Size(36, 36)
        Me.tbRefresh.Text = "Refresh"
        '
        'cmbPartNo
        '
        Me.cmbPartNo.FormattingEnabled = True
        Me.cmbPartNo.Location = New System.Drawing.Point(169, 123)
        Me.cmbPartNo.Name = "cmbPartNo"
        Me.cmbPartNo.Size = New System.Drawing.Size(211, 21)
        Me.cmbPartNo.TabIndex = 31
        '
        'cmbCusNo2
        '
        Me.cmbCusNo2.FormattingEnabled = True
        Me.cmbCusNo2.Location = New System.Drawing.Point(169, 97)
        Me.cmbCusNo2.Name = "cmbCusNo2"
        Me.cmbCusNo2.Size = New System.Drawing.Size(211, 21)
        Me.cmbCusNo2.TabIndex = 32
        '
        'cmbModel
        '
        Me.cmbModel.FormattingEnabled = True
        Me.cmbModel.Location = New System.Drawing.Point(169, 44)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(211, 21)
        Me.cmbModel.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Part No. :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbPrintUse)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbCusNo1)
        Me.GroupBox1.Controls.Add(Me.txtLeakTest)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbCusID)
        Me.GroupBox1.Controls.Add(Me.cmbPartID)
        Me.GroupBox1.Controls.Add(Me.lbID)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCusNo2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbPartNo)
        Me.GroupBox1.Controls.Add(Me.cmbModel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1247, 227)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Customer Part No.2 :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmbCusNo1
        '
        Me.cmbCusNo1.FormattingEnabled = True
        Me.cmbCusNo1.Location = New System.Drawing.Point(169, 71)
        Me.cmbCusNo1.Name = "cmbCusNo1"
        Me.cmbCusNo1.Size = New System.Drawing.Size(211, 21)
        Me.cmbCusNo1.TabIndex = 44
        '
        'txtLeakTest
        '
        Me.txtLeakTest.Location = New System.Drawing.Point(169, 149)
        Me.txtLeakTest.Name = "txtLeakTest"
        Me.txtLeakTest.Size = New System.Drawing.Size(211, 20)
        Me.txtLeakTest.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(86, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Leak Test :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmbCusID
        '
        Me.cmbCusID.FormattingEnabled = True
        Me.cmbCusID.Location = New System.Drawing.Point(388, 72)
        Me.cmbCusID.Name = "cmbCusID"
        Me.cmbCusID.Size = New System.Drawing.Size(84, 21)
        Me.cmbCusID.TabIndex = 41
        Me.cmbCusID.Visible = False
        '
        'cmbPartID
        '
        Me.cmbPartID.FormattingEnabled = True
        Me.cmbPartID.Location = New System.Drawing.Point(388, 124)
        Me.cmbPartID.Name = "cmbPartID"
        Me.cmbPartID.Size = New System.Drawing.Size(84, 21)
        Me.cmbPartID.TabIndex = 40
        Me.cmbPartID.Visible = False
        '
        'lbID
        '
        Me.lbID.AutoSize = True
        Me.lbID.Location = New System.Drawing.Point(166, 28)
        Me.lbID.Name = "lbID"
        Me.lbID.Size = New System.Drawing.Size(38, 13)
        Me.lbID.TabIndex = 39
        Me.lbID.Text = "ID No."
        Me.lbID.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(105, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Model :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Customer Part No.1 :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmbPrintUse
        '
        Me.cmbPrintUse.FormattingEnabled = True
        Me.cmbPrintUse.Items.AddRange(New Object() {"YES", "NO"})
        Me.cmbPrintUse.Location = New System.Drawing.Point(169, 175)
        Me.cmbPrintUse.Name = "cmbPrintUse"
        Me.cmbPrintUse.Size = New System.Drawing.Size(211, 21)
        Me.cmbPrintUse.TabIndex = 65
        Me.cmbPrintUse.Text = "YES"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(67, 183)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(80, 13)
        Me.Label37.TabIndex = 64
        Me.Label37.Text = "Available Print :"
        '
        'frmPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1271, 642)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvAddPrinting)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmPrinting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Label Printing"
        CType(Me.dgvAddPrinting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvAddPrinting As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbPartNo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCusNo2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbID As System.Windows.Forms.Label
    Friend WithEvents cmbCusID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPartID As System.Windows.Forms.ComboBox
    Friend WithEvents txtLeakTest As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCusNo1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrintUse As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
End Class
