<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderKiosk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderKiosk))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.timer_clock = New System.Windows.Forms.Timer(Me.components)
        Me.refresh_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_auditTrail = New System.Windows.Forms.TextBox()
        Me.marquee = New System.Windows.Forms.Timer(Me.components)
        Me.audit_timer = New System.Windows.Forms.Timer(Me.components)
        Me.stockReceive_timer = New System.Windows.Forms.Timer(Me.components)
        Me.reminder_PendingOrders = New System.Windows.Forms.Timer(Me.components)
        Me.reminder_transferOrders = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Black
        Me.FlowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(13, 66)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(528, 522)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Black
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(547, 66)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(524, 501)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.White
        Me.lblTime.Location = New System.Drawing.Point(780, 0)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTime.Size = New System.Drawing.Size(303, 51)
        Me.lblTime.TabIndex = 4
        Me.lblTime.Text = "Date and Time"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'timer_clock
        '
        '
        'refresh_timer
        '
        Me.refresh_timer.Interval = 30000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 34.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(154, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 53)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Monitoring Screen"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_auditTrail
        '
        Me.txt_auditTrail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_auditTrail.BackColor = System.Drawing.Color.Black
        Me.txt_auditTrail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_auditTrail.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_auditTrail.ForeColor = System.Drawing.Color.White
        Me.txt_auditTrail.Location = New System.Drawing.Point(0, 587)
        Me.txt_auditTrail.Name = "txt_auditTrail"
        Me.txt_auditTrail.Size = New System.Drawing.Size(1083, 32)
        Me.txt_auditTrail.TabIndex = 7
        Me.txt_auditTrail.Text = "Status"
        '
        'marquee
        '
        Me.marquee.Interval = 400
        '
        'audit_timer
        '
        Me.audit_timer.Interval = 600000
        '
        'stockReceive_timer
        '
        Me.stockReceive_timer.Interval = 3600000
        '
        'reminder_PendingOrders
        '
        Me.reminder_PendingOrders.Interval = 1800000
        '
        'reminder_transferOrders
        '
        Me.reminder_transferOrders.Interval = 2400000
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BCVR_Kiosk.My.Resources.Resources.bcvr
        Me.PictureBox1.Location = New System.Drawing.Point(13, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(135, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'OrderKiosk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1083, 619)
        Me.Controls.Add(Me.txt_auditTrail)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OrderKiosk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents timer_clock As System.Windows.Forms.Timer
    Friend WithEvents refresh_timer As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_auditTrail As System.Windows.Forms.TextBox
    Friend WithEvents marquee As System.Windows.Forms.Timer
    Friend WithEvents audit_timer As System.Windows.Forms.Timer
    Friend WithEvents stockReceive_timer As System.Windows.Forms.Timer
    Friend WithEvents reminder_PendingOrders As System.Windows.Forms.Timer
    Friend WithEvents reminder_transferOrders As System.Windows.Forms.Timer

End Class
