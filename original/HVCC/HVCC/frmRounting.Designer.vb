<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRouting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRouting))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRouting = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGSDB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbSave, Me.ToolStripSeparator1, Me.tbRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(353, 39)
        Me.ToolStrip1.TabIndex = 28
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
        'tbRefresh
        '
        Me.tbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbRefresh.Image = CType(resources.GetObject("tbRefresh.Image"), System.Drawing.Image)
        Me.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbRefresh.Name = "tbRefresh"
        Me.tbRefresh.Size = New System.Drawing.Size(36, 36)
        Me.tbRefresh.Text = "Refresh"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtGSDB)
        Me.GroupBox1.Controls.Add(Me.txtRouting)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 89)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'txtRouting
        '
        Me.txtRouting.Location = New System.Drawing.Point(99, 27)
        Me.txtRouting.Name = "txtRouting"
        Me.txtRouting.Size = New System.Drawing.Size(167, 20)
        Me.txtRouting.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Rounting :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtGSDB
        '
        Me.txtGSDB.Location = New System.Drawing.Point(99, 53)
        Me.txtGSDB.Name = "txtGSDB"
        Me.txtGSDB.Size = New System.Drawing.Size(167, 20)
        Me.txtGSDB.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "GSDB Code :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'frmRouting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(353, 161)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.Name = "frmRouting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Routing Name Configulation"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRouting As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGSDB As System.Windows.Forms.TextBox
End Class
