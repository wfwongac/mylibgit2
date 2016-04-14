Public Class frmRipple
    Inherits frmEffect

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents gbxRandom As System.Windows.Forms.GroupBox
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents tbMagn As System.Windows.Forms.TrackBar
    Friend WithEvents lblOffset As System.Windows.Forms.Label
    Friend WithEvents bnRippleApply As System.Windows.Forms.Button
    Friend WithEvents tbFreq As System.Windows.Forms.TrackBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.gbxRandom = New System.Windows.Forms.GroupBox()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.tbMagn = New System.Windows.Forms.TrackBar()
        Me.lblOffset = New System.Windows.Forms.Label()
        Me.tbFreq = New System.Windows.Forms.TrackBar()
        Me.bnRippleApply = New System.Windows.Forms.Button()
        Me.gbxRandom.SuspendLayout()
        CType(Me.tbMagn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(99, 388)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(80, 27)
        Me.btnApply.TabIndex = 8
        Me.btnApply.Text = "Apply"
        '
        'gbxRandom
        '
        Me.gbxRandom.Controls.Add(Me.lblPeriod)
        Me.gbxRandom.Controls.Add(Me.tbMagn)
        Me.gbxRandom.Controls.Add(Me.lblOffset)
        Me.gbxRandom.Controls.Add(Me.tbFreq)
        Me.gbxRandom.Location = New System.Drawing.Point(12, 12)
        Me.gbxRandom.Name = "gbxRandom"
        Me.gbxRandom.Size = New System.Drawing.Size(270, 121)
        Me.gbxRandom.TabIndex = 11
        Me.gbxRandom.TabStop = False
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(12, 74)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(61, 12)
        Me.lblPeriod.TabIndex = 6
        Me.lblPeriod.Text = "Magnitude :"
        '
        'tbMagn
        '
        Me.tbMagn.Location = New System.Drawing.Point(74, 70)
        Me.tbMagn.Maximum = 20
        Me.tbMagn.Minimum = 1
        Me.tbMagn.Name = "tbMagn"
        Me.tbMagn.Size = New System.Drawing.Size(184, 45)
        Me.tbMagn.TabIndex = 5
        Me.tbMagn.Value = 10
        '
        'lblOffset
        '
        Me.lblOffset.AutoSize = True
        Me.lblOffset.Location = New System.Drawing.Point(12, 25)
        Me.lblOffset.Name = "lblOffset"
        Me.lblOffset.Size = New System.Drawing.Size(60, 12)
        Me.lblOffset.TabIndex = 4
        Me.lblOffset.Text = "Frequency :"
        '
        'tbFreq
        '
        Me.tbFreq.Location = New System.Drawing.Point(74, 22)
        Me.tbFreq.Maximum = 20
        Me.tbFreq.Minimum = 1
        Me.tbFreq.Name = "tbFreq"
        Me.tbFreq.Size = New System.Drawing.Size(184, 45)
        Me.tbFreq.TabIndex = 0
        Me.tbFreq.Value = 10
        '
        'bnRippleApply
        '
        Me.bnRippleApply.Location = New System.Drawing.Point(103, 153)
        Me.bnRippleApply.Name = "bnRippleApply"
        Me.bnRippleApply.Size = New System.Drawing.Size(75, 23)
        Me.bnRippleApply.TabIndex = 12
        Me.bnRippleApply.Text = "Apply"
        Me.bnRippleApply.UseVisualStyleBackColor = True
        '
        'frmRipple
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(294, 372)
        Me.Controls.Add(Me.bnRippleApply)
        Me.Controls.Add(Me.gbxRandom)
        Me.Controls.Add(Me.btnApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRipple"
        Me.Text = "Ripple"
        Me.gbxRandom.ResumeLayout(False)
        Me.gbxRandom.PerformLayout()
        CType(Me.tbMagn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region


    Private Sub bnRippleApply_Click(sender As System.Object, e As System.EventArgs) Handles bnRippleApply.Click

        Dim fImageForm As frmImage = DirectCast(Me.MdiParent, frmMain).selectedImageForm

        Ripple(fImageForm, tbFreq.Value, tbMagn.Value)

    End Sub
End Class
