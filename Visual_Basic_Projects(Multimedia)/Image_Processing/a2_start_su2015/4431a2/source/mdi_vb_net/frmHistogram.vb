Public Class frmHistogram
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
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents lblPlanes As System.Windows.Forms.Label
    Friend WithEvents cboPlane As System.Windows.Forms.ComboBox
    Friend WithEvents btnAutoContrast As System.Windows.Forms.Button
    Friend WithEvents picHistogram As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.picHistogram = New System.Windows.Forms.PictureBox()
        Me.lblPlanes = New System.Windows.Forms.Label()
        Me.cboPlane = New System.Windows.Forms.ComboBox()
        Me.btnAutoContrast = New System.Windows.Forms.Button()
        CType(Me.picHistogram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(33, 213)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(80, 29)
        Me.btnShow.TabIndex = 8
        Me.btnShow.Text = "Show"
        '
        'picHistogram
        '
        Me.picHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picHistogram.Location = New System.Drawing.Point(12, 52)
        Me.picHistogram.Name = "picHistogram"
        Me.picHistogram.Size = New System.Drawing.Size(270, 148)
        Me.picHistogram.TabIndex = 10
        Me.picHistogram.TabStop = False
        '
        'lblPlanes
        '
        Me.lblPlanes.AutoSize = True
        Me.lblPlanes.Location = New System.Drawing.Point(12, 17)
        Me.lblPlanes.Name = "lblPlanes"
        Me.lblPlanes.Size = New System.Drawing.Size(69, 12)
        Me.lblPlanes.TabIndex = 12
        Me.lblPlanes.Text = "Histogram of:"
        '
        'cboPlane
        '
        Me.cboPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlane.FormattingEnabled = True
        Me.cboPlane.Items.AddRange(New Object() {"Value", "Red", "Green", "Blue"})
        Me.cboPlane.Location = New System.Drawing.Point(87, 14)
        Me.cboPlane.Name = "cboPlane"
        Me.cboPlane.Size = New System.Drawing.Size(195, 20)
        Me.cboPlane.TabIndex = 11
        '
        'btnAutoContrast
        '
        Me.btnAutoContrast.Location = New System.Drawing.Point(155, 213)
        Me.btnAutoContrast.Name = "btnAutoContrast"
        Me.btnAutoContrast.Size = New System.Drawing.Size(110, 27)
        Me.btnAutoContrast.TabIndex = 13
        Me.btnAutoContrast.Text = "Auto Contrast"
        Me.btnAutoContrast.UseVisualStyleBackColor = True
        '
        'frmHistogram
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(311, 271)
        Me.Controls.Add(Me.btnAutoContrast)
        Me.Controls.Add(Me.lblPlanes)
        Me.Controls.Add(Me.cboPlane)
        Me.Controls.Add(Me.picHistogram)
        Me.Controls.Add(Me.btnShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistogram"
        Me.Text = "Histogram"
        CType(Me.picHistogram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Histogram(0 To 255) As Integer
    Dim isAutoConstract As Boolean = False

    Private Sub frmHistogram_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboPlane.SelectedIndex = 0
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        For i As Integer = 0 To Histogram.Length - 1
            Histogram(i) = 0
        Next

        ' Clear the histogram using Array.Clear here
        ApplyEffect()


        picHistogram.Refresh()



    End Sub

    Overrides Function Process(ByRef image As Bitmap, ByVal x As Integer, ByVal y As Integer) As Color
        Dim color As Color = image.GetPixel(x, y)


        ' Count the histogram using the selected colour plane here
        ' Note: there are 256 boxes in the histogram

        ' Add : 5.Auto Contrast works as discussed in the lectures and notes +3 marks

        Dim red As Integer = color.R
        Dim green As Integer = color.G
        Dim blue As Integer = color.B
        Dim hue As Double
        Dim saturation As Double
        Dim value As Double

        RGB2HSV(red, green, blue, hue, saturation, value)

        Select Case cboPlane.SelectedIndex
            Case 0
                Dim Index As Integer = CInt(value * 255.0#)
                Histogram(Index) = Histogram(Index) + 1
            Case 1
                Histogram(red) = Histogram(red) + 1
            Case 2
                Histogram(green) = Histogram(green) + 1
            Case 3
                Histogram(blue) = Histogram(blue) + 1
        End Select


        Return color
    End Function

    Private Sub picHistogram_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picHistogram.Paint
        Dim g As Graphics = e.Graphics()
        g.Clear(Color.White)

        Dim max As Integer = 0
        Dim i As Integer
        For i = 0 To 255
            If Histogram(i) > max Then
                max = Histogram(i)
            End If
        Next

        If max > 0 Then
            Dim x As Integer, y As Integer
            For x = 0 To picHistogram.ClientRectangle.Width - 1
                y = (1.0# - Histogram(x / (picHistogram.ClientRectangle.Width - 1) * 255) / max) * (picHistogram.ClientRectangle.Height - 1)
                g.DrawLine(Pens.Black, x, picHistogram.ClientRectangle.Height - 1, x, y)
            Next
        End If
    End Sub

    Private Sub btnAutoContrast_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoContrast.Click

        isAutoConstract = True

        If cboPlane.SelectedIndex = 0 Then

            Dim selectedImageForm As frmImage = DirectCast(Me.MdiParent, frmMain).selectedImageForm
            AutoContrast(selectedImageForm.image, selectedImageForm.selectedArea.Top, selectedImageForm.selectedArea.Bottom, selectedImageForm.selectedArea.Left, selectedImageForm.selectedArea.Right)

        End If

    End Sub

    ' Apply for the whoe image
    Private Function AutoContrast(ByRef image As Bitmap, ByVal top As Integer, ByVal bottom As Integer, ByVal left As Integer, ByVal right As Integer) As Color
        Dim Light_R As Integer, Light_G As Integer, Light_B As Integer
        Dim Max_Light_R As Integer = 0
        Dim Min_Light_R As Integer = 255
        Dim Max_Light_G As Integer = 0
        Dim Min_Light_G As Integer = 255
        Dim Max_Light_B As Integer = 0
        Dim Min_Light_B As Integer = 255

        Dim j As Integer
        Dim i As Integer
        For j = top To bottom
            For i = left To right
                Light_R = image.GetPixel(i, j).R
                Light_G = image.GetPixel(i, j).G
                Light_B = image.GetPixel(i, j).B
                If Light_R > Max_Light_R Then
                    Max_Light_R = Light_R
                End If
                If Light_G > Max_Light_G Then
                    Max_Light_G = Light_G
                End If
                If Light_B > Max_Light_B Then
                    Max_Light_B = Light_B
                End If

                If Light_R < Min_Light_R Then
                    Min_Light_R = Light_R
                End If
                If Light_G < Min_Light_G Then
                    Min_Light_G = Light_G
                End If
                If Light_B < Min_Light_B Then
                    Min_Light_B = Light_B
                End If
            Next i
        Next j

        Dim Expansion_R As Double = 255.0 / (Max_Light_R - Min_Light_R)
        Dim Expansion_G As Double = 255.0 / (Max_Light_G - Min_Light_G)
        Dim Expansion_B As Double = 255.0 / (Max_Light_B - Min_Light_B)

        For j = top To bottom
            For i = left To right
                Light_R = image.GetPixel(i, j).R
                Light_R = Math.Floor(CDbl(Light_R - Min_Light_R) * Expansion_R)
                Light_R = Math.Max(0, Math.Min(Light_R, 255))

                Light_G = image.GetPixel(i, j).G
                Light_G = Math.Floor(CDbl(Light_G - Min_Light_G) * Expansion_G)
                Light_G = Math.Max(0, Math.Min(Light_G, 255))

                Light_B = image.GetPixel(i, j).B
                Light_B = Math.Floor(CDbl(Light_B - Min_Light_B) * Expansion_B)
                Light_B = Math.Max(0, Math.Min(Light_B, 255))

                image.SetPixel(i, j, Color.FromArgb(Light_R, Light_G, Light_B))
            Next i
        Next j

        ApplyEffect()

        picHistogram.Refresh()

    End Function
End Class
