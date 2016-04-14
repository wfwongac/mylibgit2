Public Class frmRoughen
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
    Friend WithEvents gbxRoughen As System.Windows.Forms.GroupBox
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents chkValue As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbVRoughen As System.Windows.Forms.TrackBar
    Friend WithEvents tbSRoughen As System.Windows.Forms.TrackBar
    Friend WithEvents chkSaturation As System.Windows.Forms.CheckBox
    Friend WithEvents chkHue As System.Windows.Forms.CheckBox
    Friend WithEvents tbHRoughen As System.Windows.Forms.TrackBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gbxRoughen = New System.Windows.Forms.GroupBox()
        Me.chkValue = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbVRoughen = New System.Windows.Forms.TrackBar()
        Me.tbSRoughen = New System.Windows.Forms.TrackBar()
        Me.chkSaturation = New System.Windows.Forms.CheckBox()
        Me.chkHue = New System.Windows.Forms.CheckBox()
        Me.tbHRoughen = New System.Windows.Forms.TrackBar()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.gbxRoughen.SuspendLayout()
        CType(Me.tbVRoughen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSRoughen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHRoughen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxRoughen
        '
        Me.gbxRoughen.Controls.Add(Me.chkValue)
        Me.gbxRoughen.Controls.Add(Me.Label4)
        Me.gbxRoughen.Controls.Add(Me.Label5)
        Me.gbxRoughen.Controls.Add(Me.Label6)
        Me.gbxRoughen.Controls.Add(Me.tbVRoughen)
        Me.gbxRoughen.Controls.Add(Me.tbSRoughen)
        Me.gbxRoughen.Controls.Add(Me.chkSaturation)
        Me.gbxRoughen.Controls.Add(Me.chkHue)
        Me.gbxRoughen.Controls.Add(Me.tbHRoughen)
        Me.gbxRoughen.Location = New System.Drawing.Point(12, 12)
        Me.gbxRoughen.Name = "gbxRoughen"
        Me.gbxRoughen.Size = New System.Drawing.Size(298, 227)
        Me.gbxRoughen.TabIndex = 9
        Me.gbxRoughen.TabStop = False
        Me.gbxRoughen.Text = "Strength of Roughen"
        '
        'chkValue
        '
        Me.chkValue.AutoSize = True
        Me.chkValue.Location = New System.Drawing.Point(7, 173)
        Me.chkValue.Name = "chkValue"
        Me.chkValue.Size = New System.Drawing.Size(53, 17)
        Me.chkValue.TabIndex = 16
        Me.chkValue.Text = "Value"
        Me.chkValue.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(88, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Weak"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(150, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Medium"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Strong"
        '
        'tbVRoughen
        '
        Me.tbVRoughen.LargeChange = 10
        Me.tbVRoughen.Location = New System.Drawing.Point(81, 163)
        Me.tbVRoughen.Maximum = 50
        Me.tbVRoughen.Name = "tbVRoughen"
        Me.tbVRoughen.Size = New System.Drawing.Size(198, 45)
        Me.tbVRoughen.TabIndex = 12
        Me.tbVRoughen.TickFrequency = 10
        Me.tbVRoughen.Value = 10
        '
        'tbSRoughen
        '
        Me.tbSRoughen.LargeChange = 10
        Me.tbSRoughen.Location = New System.Drawing.Point(81, 89)
        Me.tbSRoughen.Maximum = 50
        Me.tbSRoughen.Name = "tbSRoughen"
        Me.tbSRoughen.Size = New System.Drawing.Size(198, 45)
        Me.tbSRoughen.TabIndex = 8
        Me.tbSRoughen.TickFrequency = 10
        Me.tbSRoughen.Value = 10
        '
        'chkSaturation
        '
        Me.chkSaturation.AutoSize = True
        Me.chkSaturation.Location = New System.Drawing.Point(7, 89)
        Me.chkSaturation.Name = "chkSaturation"
        Me.chkSaturation.Size = New System.Drawing.Size(74, 17)
        Me.chkSaturation.TabIndex = 7
        Me.chkSaturation.Text = "Saturation"
        Me.chkSaturation.UseVisualStyleBackColor = True
        '
        'chkHue
        '
        Me.chkHue.AutoSize = True
        Me.chkHue.Location = New System.Drawing.Point(7, 29)
        Me.chkHue.Name = "chkHue"
        Me.chkHue.Size = New System.Drawing.Size(46, 17)
        Me.chkHue.TabIndex = 6
        Me.chkHue.TabStop = False
        Me.chkHue.Text = "Hue"
        Me.chkHue.UseVisualStyleBackColor = True
        '
        'tbHRoughen
        '
        Me.tbHRoughen.LargeChange = 10
        Me.tbHRoughen.Location = New System.Drawing.Point(81, 19)
        Me.tbHRoughen.Maximum = 50
        Me.tbHRoughen.Name = "tbHRoughen"
        Me.tbHRoughen.Size = New System.Drawing.Size(198, 45)
        Me.tbHRoughen.TabIndex = 0
        Me.tbHRoughen.TickFrequency = 10
        Me.tbHRoughen.Value = 10
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(126, 258)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(80, 24)
        Me.btnApply.TabIndex = 8
        Me.btnApply.Text = "Apply"
        '
        'frmRoughen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(322, 335)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.gbxRoughen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRoughen"
        Me.Text = "Roughen"
        Me.gbxRoughen.ResumeLayout(False)
        Me.gbxRoughen.PerformLayout()
        CType(Me.tbVRoughen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSRoughen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHRoughen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ApplyEffect()
    End Sub

    Overrides Function Process(ByRef image As Bitmap, ByVal x As Integer, ByVal y As Integer) As Color

        Return Roughen(image.
                       GetPixel(x, y), chkHue.Checked, tbHRoughen.Value / 100.0#, chkSaturation.Checked, tbSRoughen.Value / 100.0#, chkValue.Checked, tbVRoughen.Value / 100.0#)
    End Function


End Class
