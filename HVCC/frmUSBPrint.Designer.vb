<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUSBPrint
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUSBPrint))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbConnect = New System.Windows.Forms.ToolStripButton()
        Me.tbDisconnect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbPrint = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuModelNo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPartNo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRounting = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShift = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZPLIIManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZM400Manual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZM400Quick = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbToday = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tvData = New System.Windows.Forms.TreeView()
        Me.lvData = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgvLabelPrint = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvLabelPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbSave, Me.ToolStripSeparator1, Me.tbConnect, Me.tbDisconnect, Me.ToolStripSeparator2, Me.tbPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1354, 39)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbSave
        '
        Me.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSave.Image = CType(resources.GetObject("tbSave.Image"), System.Drawing.Image)
        Me.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(36, 36)
        Me.tbSave.Text = "Save Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'tbConnect
        '
        Me.tbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbConnect.Image = CType(resources.GetObject("tbConnect.Image"), System.Drawing.Image)
        Me.tbConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbConnect.Name = "tbConnect"
        Me.tbConnect.Size = New System.Drawing.Size(36, 36)
        Me.tbConnect.Text = "Connect PLC"
        '
        'tbDisconnect
        '
        Me.tbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbDisconnect.Image = CType(resources.GetObject("tbDisconnect.Image"), System.Drawing.Image)
        Me.tbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbDisconnect.Name = "tbDisconnect"
        Me.tbDisconnect.Size = New System.Drawing.Size(36, 36)
        Me.tbDisconnect.Text = "Disconnect PLC"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'tbPrint
        '
        Me.tbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbPrint.Image = CType(resources.GetObject("tbPrint.Image"), System.Drawing.Image)
        Me.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbPrint.Name = "tbPrint"
        Me.tbPrint.Size = New System.Drawing.Size(36, 36)
        Me.tbPrint.Text = "Print Label"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1, Me.EditToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1354, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSave, Me.mnuPrint, Me.mnuExit})
        Me.FileToolStripMenuItem.Image = CType(resources.GetObject("FileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'mnuSave
        '
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSave.Size = New System.Drawing.Size(140, 22)
        Me.mnuSave.Text = "Save"
        '
        'mnuPrint
        '
        Me.mnuPrint.Image = CType(resources.GetObject("mnuPrint.Image"), System.Drawing.Image)
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnuPrint.Size = New System.Drawing.Size(140, 22)
        Me.mnuPrint.Text = "Print"
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnuExit.Size = New System.Drawing.Size(140, 22)
        Me.mnuExit.Text = "Exit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuModelNo, Me.mnuAddOrder, Me.mnuPartNo, Me.mnuCustomer, Me.mnuRounting, Me.mnuShift, Me.mnuPrintLabel})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(60, 20)
        Me.ToolStripMenuItem1.Text = "View"
        '
        'mnuModelNo
        '
        Me.mnuModelNo.Image = CType(resources.GetObject("mnuModelNo.Image"), System.Drawing.Image)
        Me.mnuModelNo.Name = "mnuModelNo"
        Me.mnuModelNo.Size = New System.Drawing.Size(192, 22)
        Me.mnuModelNo.Text = "Model No."
        '
        'mnuAddOrder
        '
        Me.mnuAddOrder.Image = CType(resources.GetObject("mnuAddOrder.Image"), System.Drawing.Image)
        Me.mnuAddOrder.Name = "mnuAddOrder"
        Me.mnuAddOrder.Size = New System.Drawing.Size(192, 22)
        Me.mnuAddOrder.Text = "Order No."
        '
        'mnuPartNo
        '
        Me.mnuPartNo.Image = CType(resources.GetObject("mnuPartNo.Image"), System.Drawing.Image)
        Me.mnuPartNo.Name = "mnuPartNo"
        Me.mnuPartNo.Size = New System.Drawing.Size(192, 22)
        Me.mnuPartNo.Text = "Part No."
        '
        'mnuCustomer
        '
        Me.mnuCustomer.Image = CType(resources.GetObject("mnuCustomer.Image"), System.Drawing.Image)
        Me.mnuCustomer.Name = "mnuCustomer"
        Me.mnuCustomer.Size = New System.Drawing.Size(192, 22)
        Me.mnuCustomer.Text = "Customer Part No."
        '
        'mnuRounting
        '
        Me.mnuRounting.Image = CType(resources.GetObject("mnuRounting.Image"), System.Drawing.Image)
        Me.mnuRounting.Name = "mnuRounting"
        Me.mnuRounting.Size = New System.Drawing.Size(192, 22)
        Me.mnuRounting.Text = "Routing Configulation"
        '
        'mnuShift
        '
        Me.mnuShift.Image = CType(resources.GetObject("mnuShift.Image"), System.Drawing.Image)
        Me.mnuShift.Name = "mnuShift"
        Me.mnuShift.Size = New System.Drawing.Size(192, 22)
        Me.mnuShift.Text = "Shift"
        '
        'mnuPrintLabel
        '
        Me.mnuPrintLabel.Image = CType(resources.GetObject("mnuPrintLabel.Image"), System.Drawing.Image)
        Me.mnuPrintLabel.Name = "mnuPrintLabel"
        Me.mnuPrintLabel.Size = New System.Drawing.Size(192, 22)
        Me.mnuPrintLabel.Text = "Label Print Setting"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRefresh})
        Me.EditToolStripMenuItem1.Image = CType(resources.GetObject("EditToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(55, 20)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Image = CType(resources.GetObject("mnuRefresh.Image"), System.Drawing.Image)
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Size = New System.Drawing.Size(113, 22)
        Me.mnuRefresh.Text = "Refresh"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuZPLIIManual, Me.mnuZM400Manual, Me.mnuZM400Quick})
        Me.HelpToolStripMenuItem.Image = CType(resources.GetObject("HelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuZPLIIManual
        '
        Me.mnuZPLIIManual.Image = CType(resources.GetObject("mnuZPLIIManual.Image"), System.Drawing.Image)
        Me.mnuZPLIIManual.Name = "mnuZPLIIManual"
        Me.mnuZPLIIManual.Size = New System.Drawing.Size(213, 22)
        Me.mnuZPLIIManual.Text = "ZPL II PM Manual"
        '
        'mnuZM400Manual
        '
        Me.mnuZM400Manual.Image = CType(resources.GetObject("mnuZM400Manual.Image"), System.Drawing.Image)
        Me.mnuZM400Manual.Name = "mnuZM400Manual"
        Me.mnuZM400Manual.Size = New System.Drawing.Size(213, 22)
        Me.mnuZM400Manual.Text = "ZM400 User Guide Manual"
        '
        'mnuZM400Quick
        '
        Me.mnuZM400Quick.Image = CType(resources.GetObject("mnuZM400Quick.Image"), System.Drawing.Image)
        Me.mnuZM400Quick.Name = "mnuZM400Quick"
        Me.mnuZM400Quick.Size = New System.Drawing.Size(213, 22)
        Me.mnuZM400Quick.Text = "ZM400 Quick Guide"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbToday})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 711)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1354, 22)
        Me.StatusStrip1.TabIndex = 26
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbToday
        '
        Me.lbToday.BackColor = System.Drawing.SystemColors.Control
        Me.lbToday.Name = "lbToday"
        Me.lbToday.Size = New System.Drawing.Size(40, 17)
        Me.lbToday.Text = "Today"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "ZM400 Printing..."
        Me.NotifyIcon1.BalloonTipTitle = "ZM400 Label Print"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Printing Label in Progess... "
        Me.NotifyIcon1.Visible = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 63)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvLabelPrint)
        Me.SplitContainer1.Size = New System.Drawing.Size(1354, 648)
        Me.SplitContainer1.SplitterDistance = 346
        Me.SplitContainer1.TabIndex = 38
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tvData)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lvData)
        Me.SplitContainer2.Size = New System.Drawing.Size(1354, 346)
        Me.SplitContainer2.SplitterDistance = 363
        Me.SplitContainer2.TabIndex = 11
        '
        'tvData
        '
        Me.tvData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvData.Location = New System.Drawing.Point(0, 0)
        Me.tvData.Name = "tvData"
        Me.tvData.Size = New System.Drawing.Size(359, 342)
        Me.tvData.TabIndex = 10
        '
        'lvData
        '
        Me.lvData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvData.Location = New System.Drawing.Point(0, 0)
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(983, 342)
        Me.lvData.TabIndex = 0
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Part No."
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Part No. Detail"
        Me.ColumnHeader5.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Quantity"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Lot Size"
        '
        'dgvLabelPrint
        '
        Me.dgvLabelPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLabelPrint.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvLabelPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLabelPrint.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgvLabelPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvLabelPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabelPrint.Location = New System.Drawing.Point(0, 0)
        Me.dgvLabelPrint.Name = "dgvLabelPrint"
        Me.dgvLabelPrint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvLabelPrint.Size = New System.Drawing.Size(1350, 294)
        Me.dgvLabelPrint.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "No."
        Me.Column1.Name = "Column1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "book_blue.png")
        Me.ImageList1.Images.SetKeyName(1, "book_open.png")
        Me.ImageList1.Images.SetKeyName(2, "book_red.png")
        Me.ImageList1.Images.SetKeyName(3, "bottle.png")
        Me.ImageList1.Images.SetKeyName(4, "box.png")
        Me.ImageList1.Images.SetKeyName(5, "box_closed.png")
        '
        'frmUSBPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUSBPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Label Printer Configulation "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvLabelPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbDisconnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAddOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPartNo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCustomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRounting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShift As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbToday As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvData As System.Windows.Forms.TreeView
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgvLabelPrint As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuZPLIIManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZM400Manual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZM400Quick As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuModelNo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintLabel As System.Windows.Forms.ToolStripMenuItem
End Class
