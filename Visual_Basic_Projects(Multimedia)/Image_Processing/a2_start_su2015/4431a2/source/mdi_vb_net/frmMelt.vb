Public Class frmMelt
    Inherits frmSpatialEffect

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
    Friend WithEvents gbxSine As System.Windows.Forms.GroupBox
    Friend WithEvents tbAmplitude As System.Windows.Forms.TrackBar
    Friend WithEvents lblAmplitude As System.Windows.Forms.Label
    Friend WithEvents lblCycle As System.Windows.Forms.Label
    Friend WithEvents tbCycle As System.Windows.Forms.TrackBar
    Friend WithEvents gbxRandom As System.Windows.Forms.GroupBox
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents tbPeriod As System.Windows.Forms.TrackBar
    Friend WithEvents lblOffset As System.Windows.Forms.Label
    Friend WithEvents cbxSine As System.Windows.Forms.CheckBox
    Friend WithEvents cbxRandom As System.Windows.Forms.CheckBox
    Friend WithEvents btnMeltApply As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblWeak As System.Windows.Forms.Label
    Friend WithEvents lblStrong As System.Windows.Forms.Label
    Friend WithEvents tbMeltRAngle As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbOffset As System.Windows.Forms.TrackBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gbxSine = New System.Windows.Forms.GroupBox()
        Me.cbxSine = New System.Windows.Forms.CheckBox()
        Me.lblCycle = New System.Windows.Forms.Label()
        Me.tbCycle = New System.Windows.Forms.TrackBar()
        Me.lblAmplitude = New System.Windows.Forms.Label()
        Me.tbAmplitude = New System.Windows.Forms.TrackBar()
        Me.gbxRandom = New System.Windows.Forms.GroupBox()
        Me.cbxRandom = New System.Windows.Forms.CheckBox()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.tbPeriod = New System.Windows.Forms.TrackBar()
        Me.lblOffset = New System.Windows.Forms.Label()
        Me.tbOffset = New System.Windows.Forms.TrackBar()
        Me.btnMeltApply = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWeak = New System.Windows.Forms.Label()
        Me.lblStrong = New System.Windows.Forms.Label()
        Me.tbMeltRAngle = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbxSine.SuspendLayout()
        CType(Me.tbCycle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAmplitude, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxRandom.SuspendLayout()
        CType(Me.tbPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbMeltRAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbxSine
        '
        Me.gbxSine.Controls.Add(Me.cbxSine)
        Me.gbxSine.Controls.Add(Me.lblCycle)
        Me.gbxSine.Controls.Add(Me.tbCycle)
        Me.gbxSine.Controls.Add(Me.lblAmplitude)
        Me.gbxSine.Controls.Add(Me.tbAmplitude)
        Me.gbxSine.Location = New System.Drawing.Point(12, 23)
        Me.gbxSine.Name = "gbxSine"
        Me.gbxSine.Size = New System.Drawing.Size(270, 105)
        Me.gbxSine.TabIndex = 10
        Me.gbxSine.TabStop = False
        '
        'cbxSine
        '
        Me.cbxSine.AutoSize = True
        Me.cbxSine.Location = New System.Drawing.Point(6, -1)
        Me.cbxSine.Name = "cbxSine"
        Me.cbxSine.Size = New System.Drawing.Size(114, 17)
        Me.cbxSine.TabIndex = 12
        Me.cbxSine.Text = "Sine Displacement"
        Me.cbxSine.UseVisualStyleBackColor = True
        '
        'lblCycle
        '
        Me.lblCycle.AutoSize = True
        Me.lblCycle.Location = New System.Drawing.Point(12, 64)
        Me.lblCycle.Name = "lblCycle"
        Me.lblCycle.Size = New System.Drawing.Size(36, 13)
        Me.lblCycle.TabIndex = 6
        Me.lblCycle.Text = "Cycle:"
        '
        'tbCycle
        '
        Me.tbCycle.Location = New System.Drawing.Point(74, 61)
        Me.tbCycle.Minimum = 1
        Me.tbCycle.Name = "tbCycle"
        Me.tbCycle.Size = New System.Drawing.Size(184, 45)
        Me.tbCycle.TabIndex = 5
        Me.tbCycle.Value = 1
        '
        'lblAmplitude
        '
        Me.lblAmplitude.AutoSize = True
        Me.lblAmplitude.Location = New System.Drawing.Point(12, 22)
        Me.lblAmplitude.Name = "lblAmplitude"
        Me.lblAmplitude.Size = New System.Drawing.Size(56, 13)
        Me.lblAmplitude.TabIndex = 4
        Me.lblAmplitude.Text = "Amplitude:"
        '
        'tbAmplitude
        '
        Me.tbAmplitude.Location = New System.Drawing.Point(74, 19)
        Me.tbAmplitude.Minimum = 1
        Me.tbAmplitude.Name = "tbAmplitude"
        Me.tbAmplitude.Size = New System.Drawing.Size(184, 45)
        Me.tbAmplitude.TabIndex = 0
        Me.tbAmplitude.Value = 1
        '
        'gbxRandom
        '
        Me.gbxRandom.Controls.Add(Me.cbxRandom)
        Me.gbxRandom.Controls.Add(Me.lblPeriod)
        Me.gbxRandom.Controls.Add(Me.tbPeriod)
        Me.gbxRandom.Controls.Add(Me.lblOffset)
        Me.gbxRandom.Controls.Add(Me.tbOffset)
        Me.gbxRandom.Location = New System.Drawing.Point(12, 145)
        Me.gbxRandom.Name = "gbxRandom"
        Me.gbxRandom.Size = New System.Drawing.Size(270, 105)
        Me.gbxRandom.TabIndex = 11
        Me.gbxRandom.TabStop = False
        '
        'cbxRandom
        '
        Me.cbxRandom.AutoSize = True
        Me.cbxRandom.Location = New System.Drawing.Point(6, -1)
        Me.cbxRandom.Name = "cbxRandom"
        Me.cbxRandom.Size = New System.Drawing.Size(133, 17)
        Me.cbxRandom.TabIndex = 13
        Me.cbxRandom.Text = "Random Displacement"
        Me.cbxRandom.UseVisualStyleBackColor = True
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(12, 64)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(40, 13)
        Me.lblPeriod.TabIndex = 6
        Me.lblPeriod.Text = "Period:"
        '
        'tbPeriod
        '
        Me.tbPeriod.Location = New System.Drawing.Point(74, 61)
        Me.tbPeriod.Maximum = 5
        Me.tbPeriod.Minimum = 1
        Me.tbPeriod.Name = "tbPeriod"
        Me.tbPeriod.Size = New System.Drawing.Size(184, 45)
        Me.tbPeriod.TabIndex = 5
        Me.tbPeriod.Value = 1
        '
        'lblOffset
        '
        Me.lblOffset.AutoSize = True
        Me.lblOffset.Location = New System.Drawing.Point(12, 22)
        Me.lblOffset.Name = "lblOffset"
        Me.lblOffset.Size = New System.Drawing.Size(38, 13)
        Me.lblOffset.TabIndex = 4
        Me.lblOffset.Text = "Offset:"
        '
        'tbOffset
        '
        Me.tbOffset.Location = New System.Drawing.Point(74, 19)
        Me.tbOffset.Maximum = 5
        Me.tbOffset.Minimum = 1
        Me.tbOffset.Name = "tbOffset"
        Me.tbOffset.Size = New System.Drawing.Size(184, 45)
        Me.tbOffset.TabIndex = 0
        Me.tbOffset.Value = 1
        '
        'btnMeltApply
        '
        Me.btnMeltApply.Location = New System.Drawing.Point(100, 356)
        Me.btnMeltApply.Name = "btnMeltApply"
        Me.btnMeltApply.Size = New System.Drawing.Size(103, 32)
        Me.btnMeltApply.TabIndex = 12
        Me.btnMeltApply.Text = "Apply"
        Me.btnMeltApply.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 277)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Angle of Rotation : "
        '
        'lblWeak
        '
        Me.lblWeak.AutoSize = True
        Me.lblWeak.Location = New System.Drawing.Point(31, 324)
        Me.lblWeak.Name = "lblWeak"
        Me.lblWeak.Size = New System.Drawing.Size(13, 13)
        Me.lblWeak.TabIndex = 16
        Me.lblWeak.Text = "0"
        '
        'lblStrong
        '
        Me.lblStrong.AutoSize = True
        Me.lblStrong.Location = New System.Drawing.Point(244, 324)
        Me.lblStrong.Name = "lblStrong"
        Me.lblStrong.Size = New System.Drawing.Size(25, 13)
        Me.lblStrong.TabIndex = 17
        Me.lblStrong.Text = "359"
        '
        'tbMeltRAngle
        '
        Me.tbMeltRAngle.LargeChange = 30
        Me.tbMeltRAngle.Location = New System.Drawing.Point(24, 293)
        Me.tbMeltRAngle.Maximum = 359
        Me.tbMeltRAngle.Name = "tbMeltRAngle"
        Me.tbMeltRAngle.Size = New System.Drawing.Size(246, 45)
        Me.tbMeltRAngle.TabIndex = 15
        Me.tbMeltRAngle.TickFrequency = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(21, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 26)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "I suggest you to choose offset" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and period as the smaller values"
        '
        'frmMelt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(294, 418)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblWeak)
        Me.Controls.Add(Me.lblStrong)
        Me.Controls.Add(Me.tbMeltRAngle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMeltApply)
        Me.Controls.Add(Me.gbxRandom)
        Me.Controls.Add(Me.gbxSine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMelt"
        Me.Text = "Melt"
        Me.gbxSine.ResumeLayout(False)
        Me.gbxSine.PerformLayout()
        CType(Me.tbCycle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAmplitude, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxRandom.ResumeLayout(False)
        Me.gbxRandom.PerformLayout()
        CType(Me.tbPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbMeltRAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnMeltApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeltApply.Click
        ApplyEffect()
    End Sub

    Overrides Sub Process(ByRef input As Bitmap, ByRef output As Bitmap, ByVal rect As Rectangle)

        Dim angle As Integer = tbMeltRAngle.Value
        Dim maxLength As Integer = Math.Max(input.Width, input.Height)
        Dim transformedImage As Bitmap = New Bitmap(maxLength * 2, maxLength * 2)
        Dim rotatedImage As Bitmap = transformedImage.Clone
        Dim meltedImage As Bitmap = transformedImage.Clone
        Dim restoreRotatedImage As Bitmap = transformedImage.Clone
        Dim beginIndex As Integer = Math.Floor(maxLength / 2)

        Dim newRect As Rectangle = New Rectangle()
        newRect.Width = (maxLength - 1) * 2
        newRect.Height = (maxLength - 1) * 2

        For i As Integer = 0 To newRect.Width
            For j As Integer = 0 To newRect.Height
                If (i < beginIndex) Then
                    If (j < beginIndex OrElse j > beginIndex + input.Height - 1) Then
                        If (j < beginIndex) Then
                            transformedImage.SetPixel(i, j, input.GetPixel(0, 0))
                        Else
                            transformedImage.SetPixel(i, j, input.GetPixel(0, input.Height - 1))
                        End If
                    Else
                        transformedImage.SetPixel(i, j, input.GetPixel(0, j - beginIndex))
                    End If
                End If
                If (i > beginIndex + input.Width - 1) Then
                    If (j < beginIndex OrElse j > beginIndex + input.Height - 1) Then
                        If (j < beginIndex) Then
                            transformedImage.SetPixel(i, j, input.GetPixel(input.Width - 1, 0))
                        Else
                            transformedImage.SetPixel(i, j, input.GetPixel(input.Width - 1, input.Height - 1))
                        End If
                    Else
                        transformedImage.SetPixel(i, j, input.GetPixel(input.Width - 1, j - beginIndex))
                    End If
                End If

                If (j < beginIndex) Then
                    If (i < beginIndex OrElse i > beginIndex + input.Width - 1) Then
                        If (i < beginIndex) Then
                            transformedImage.SetPixel(i, j, input.GetPixel(0, 0))
                        Else
                            transformedImage.SetPixel(i, j, input.GetPixel(input.Width - 1, 0))
                        End If
                    Else
                        transformedImage.SetPixel(i, j, input.GetPixel(i - beginIndex, 0))
                    End If
                End If
                If (j > beginIndex + input.Height - 1) Then
                    If (i < beginIndex OrElse i > beginIndex + input.Width - 1) Then
                        If (i < beginIndex) Then
                            transformedImage.SetPixel(i, j, input.GetPixel(0, input.Height - 1))
                        Else
                            transformedImage.SetPixel(i, j, input.GetPixel(input.Width - 1, input.Height - 1))
                        End If
                    Else
                        transformedImage.SetPixel(i, j, input.GetPixel(i - beginIndex, input.Height - 1))
                    End If
                End If

                If (i >= beginIndex AndAlso j >= beginIndex AndAlso i <= beginIndex + input.Width - 1 AndAlso j <= beginIndex + input.Height - 1) Then
                    transformedImage.SetPixel(i, j, input.GetPixel(i - beginIndex, j - beginIndex))
                End If
            Next
        Next
        Rotate(transformedImage, rotatedImage, newRect, angle)

        Melt(rotatedImage, meltedImage, newRect, cbxSine.Checked, tbAmplitude.Value, tbCycle.Value, cbxRandom.Checked, tbOffset.Value, tbPeriod.Value)


        Rotate(meltedImage, restoreRotatedImage, newRect, -angle)

        For i As Integer = rect.Left To rect.Right
            For j As Integer = rect.Top To rect.Bottom
                output.SetPixel(i, j, restoreRotatedImage.GetPixel(i + beginIndex, j + beginIndex))
            Next
        Next

    End Sub
End Class
