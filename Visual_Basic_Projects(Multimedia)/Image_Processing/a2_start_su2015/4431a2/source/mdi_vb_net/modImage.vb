Module modImage

    Public Sub Ripple(ByRef fImageForm As frmImage, ByVal freq As Integer, ByVal magn As Integer)

        Dim Rcolor As Color
        Dim temp As Bitmap = fImageForm.image.Clone()
        fImageForm.RemoveDashRect()


        For x As Integer = fImageForm.selectedArea.Left To fImageForm.selectedArea.Right
            For y As Integer = fImageForm.selectedArea.Top To fImageForm.selectedArea.Bottom

                Dim tmpX As Double = x - (temp.Width - 1) / 2
                Dim tmpY As Double = -(y - (temp.Height - 1) / 2)
                Dim radius As Double = Math.Sqrt(tmpX ^ 2 + tmpY ^ 2)

                Dim currentAngle As Double = Math.Atan2(tmpY, tmpX)

                If (tmpX >= 0) Then
                    currentAngle = currentAngle + 2 * Math.PI
                Else
                    currentAngle = currentAngle + Math.PI
                End If

                Dim newRadius As Double = radius + magn * (Math.Sin(2 * Math.PI * radius / (temp.Width / 2) * freq))

                If (tmpX >= 0) Then
                    currentAngle = currentAngle - 2 * Math.PI
                Else
                    currentAngle = currentAngle - Math.PI
                End If

                tmpX = newRadius * Math.Cos(currentAngle)
                tmpY = newRadius * Math.Sin(currentAngle)



                Dim RetX As Integer = tmpX + (temp.Width - 1) / 2
                Dim RetY As Integer = (temp.Height - 1) / 2 - tmpY


                Rcolor = GetPixel(fImageForm.image, RetX, RetY)
                temp.SetPixel(x, y, Rcolor)
            Next y
        Next x

        fImageForm.SetPicture(temp.Clone)
        fImageForm.DrawDashRect()

    End Sub

    Public Sub Edge(ByRef fImageForm As frmImage, ByVal strength As Integer, ByVal useWhite As Boolean)
        ' *** add your code here
        Dim Rcolor As Color
        Dim temp As Bitmap = fImageForm.image.Clone()
        fImageForm.RemoveDashRect()


        For x As Integer = fImageForm.selectedArea.Left To fImageForm.selectedArea.Right
            For y As Integer = fImageForm.selectedArea.Top To fImageForm.selectedArea.Bottom

                '    tl  t   tr
                '    l   c   r
                '    bl  b   br

                Dim t As Color = GetPixel(fImageForm.image, x, y - 1)
                Dim l As Color = GetPixel(fImageForm.image, x - 1, y)
                Dim r As Color = GetPixel(fImageForm.image, x + 1, y)
                Dim c As Color = GetPixel(fImageForm.image, x, y)
                Dim b As Color = GetPixel(fImageForm.image, x, y + 1)

                Dim tl As Color = GetPixel(fImageForm.image, x - 1, y - 1)
                Dim tr As Color = GetPixel(fImageForm.image, x + 1, y - 1)
                Dim bl As Color = GetPixel(fImageForm.image, x - 1, y + 1)
                Dim br As Color = GetPixel(fImageForm.image, x + 1, y + 1)

                Dim rsum As Integer = c.R * 8 - t.R - b.R - l.R - r.R - tl.R - tr.R - bl.R - br.R
                Dim gsum As Integer = c.G * 8 - t.G - b.G - l.G - r.G - tl.G - tr.G - bl.G - br.G
                Dim bsum As Integer = c.B * 8 - t.B - b.B - l.B - r.B - tl.B - tr.B - bl.B - br.B

                rsum = ClipByte(Math.Abs(rsum * strength))
                gsum = ClipByte(Math.Abs(gsum * strength))
                bsum = ClipByte(Math.Abs(bsum * strength))

                If useWhite Then
                    rsum = 255 - rsum
                    gsum = 255 - gsum
                    bsum = 255 - bsum
                End If
                Rcolor = Color.FromArgb(ClipByte(rsum), ClipByte(gsum), ClipByte(bsum))

                temp.SetPixel(x, y, Rcolor)
            Next y
        Next x

        fImageForm.SetPicture(temp.Clone())
        fImageForm.DrawDashRect()

    End Sub



    ' This function applies roughen on a pixel using a deviation from 0 to 1
    Public Function Roughen(ByVal color As Color, ByVal useH As Boolean, ByVal Hdeviation As Double, ByVal useS As Boolean, ByVal Sdeviation As Double, ByVal useV As Boolean, ByVal Vdeviation As Double) As Color
        Dim red As Integer = color.R
        Dim green As Integer = color.G
        Dim blue As Integer = color.B
        Dim hue As Double
        Dim saturation As Double
        Dim value As Double


        ' Adjust the V component of the colour using the deviation here
        RGB2HSV(red, green, blue, hue, saturation, value)

        If useH Then
            hue += (360.0# * Rnd()) * Hdeviation
        End If

        If useS Then
            saturation += (2.0# * Rnd() - 1.0#) * Sdeviation
        End If

        If useV Then
            value += (2.0# * Rnd() - 1.0#) * Vdeviation
        End If

        HSV2RGB(hue, saturation, value, red, green, blue)

        Return color.FromArgb(ClipByte(red), ClipByte(green), ClipByte(blue))
    End Function



    ' This function applies melt on an input image
    Public Sub Melt(ByRef input As Bitmap, ByRef output As Bitmap, ByVal rect As Rectangle, _
                    ByVal useSine As Boolean, ByVal amplitude As Integer, ByVal cycle As Integer, _
                    ByVal useRandom As Boolean, ByVal offset As Integer, ByVal period As Integer)
        Dim displacement(0 To rect.Width) As Integer

        ' Apply melt to the selected area here
        If useSine Then
            For x As Integer = 0 To rect.Width
                displacement(x) = Math.Abs(amplitude * Math.Sin(2 * Math.PI * cycle * x / rect.Width))
            Next
        End If

        If useRandom Then
            Dim currentOffset As Integer = 0
            Dim currentPeriod As Integer = 0
            Dim sign As Integer = 0

            Dim x As Integer = rect.X
            Do While (x <= rect.X + rect.Width)
                Dim random As Double = Rnd()
                currentPeriod = 1 + random * (period - 1)    ' Set the period with same direction / group movement of offset 
                ' Range of currentPeriod is (1 To 10)

                If random >= 0.5 Then
                    sign = 1
                Else
                    sign = -1
                End If

                For i As Integer = x To x + currentPeriod - 1
                    currentOffset = currentOffset + sign * Rnd() * offset

                    ' handle : When reaching the end of downwards group movement
                    ' -> change the downwards  to upwards
                    If currentOffset < 0 Then
                        currentOffset = -1 * currentOffset
                        sign = -1 * sign
                    End If

                    If i < rect.Right Then
                        displacement(i) = displacement(i) + currentOffset
                    End If
                Next

                x = x + currentPeriod
            Loop
        End If

        Dim replaced(rect.Width, rect.Height) As Boolean

        output = input.Clone

        'For x As Integer = rect.X To rect.X + rect.Width
        'For y As Integer = rect.Y To rect.Y + rect.Height
        'Dim index As Integer = y - displacement(x - rect.X)
        'If index >= 0 Then
        '' index = rect.Height+index
        'output.SetPixel(x, y, input.GetPixel(x, index))
        'replaced(x - rect.X, y - rect.Y) = True
        'End If
        'Next
        'Next

        'For x As Integer = rect.X To rect.X + rect.Width
        'For y As Integer = rect.Y To rect.Y + rect.Height
        'If Not replaced(x - rect.X, y - rect.Y) Then
        'If (y - 1 >= rect.X) Then
        'output.SetPixel(x, y, input.GetPixel(x, y - 1))
        'End If
        'End If
        'Next
        'Next

        For x As Integer = rect.Left To rect.Right
            For y As Integer = rect.Top To rect.Bottom
                output.SetPixel(x, y, GetPixel(input, x, y - displacement(x - rect.Left)))
            Next
        Next

    End Sub

    ' This function applies rotation on an input image
    Public Sub Rotate(ByRef input As Bitmap, ByRef output As Bitmap, ByVal rect As Rectangle, ByVal angle As Integer)


        ' Apply rotation to the selected area here
        Dim maxsize As Integer = Math.Ceiling(Math.Sqrt(rect.Width ^ 2 + rect.Height ^ 2))
        Dim center As New PointF(rect.X + rect.Width / 2.0#, rect.Y + rect.Height / 2.0#)
        Dim outputRect As New Rectangle(Math.Floor(center.X - maxsize / 2.0#), Math.Floor(center.Y - maxsize / 2.0#), maxsize, maxsize)
        Dim radius As Double = angle / 180.0# * Math.PI

        outputRect.Intersect(New Rectangle(0, 0, output.Width - 1, output.Height - 1))
        For x As Integer = outputRect.Left To outputRect.Right
            For y As Integer = outputRect.Top To outputRect.Bottom
                Dim distX As Integer = Math.Ceiling(x - center.X)
                Dim distY As Integer = Math.Ceiling(y - center.Y)

                Dim sourceX As Integer = Math.Ceiling(Math.Cos(radius) * distX + Math.Sin(radius) * distY)
                Dim sourceY As Integer = Math.Ceiling(-Math.Sin(radius) * distX + Math.Cos(radius) * distY)

                sourceX = sourceX + center.X
                sourceY = sourceY + center.Y

                If sourceX >= rect.Left And sourceX <= rect.Right And sourceY >= rect.Top And sourceY <= rect.Bottom Then
                    Dim c As Color = input.GetPixel(sourceX, sourceY)
                    output.SetPixel(x, y, c)
                Else
                    If x >= rect.Left And x <= rect.Right And y >= rect.Top And y <= rect.Bottom Then
                        output.SetPixel(x, y, Color.Black)
                    End If
                End If
            Next
        Next

    End Sub


    Public Sub RGB2HSV(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer, ByRef h As Double, ByRef s As Double, ByRef v As Double)
        Dim max, min As Double
        Dim r As Double, g As Double, b As Double

        r = red / 255.0
        g = green / 255.0
        b = blue / 255.0
        'Convert RGB to [0,1]

        'Then get the max and min of r,g,b
        max = r
        If max < g Then max = g
        If max < b Then max = b
        min = r
        If min > g Then min = g
        If min > b Then min = b

        v = max 'this is value v

        'next calculate saturation, s 
        If max = 0 Then
            s = 0
        Else
            s = (max - min) / max
        End If

        ' The last step is hue, h
        If s = 0 Then
            h = -1
        Else
            If r = max Then
                h = (g - b) / (max - min)
            ElseIf g = max Then
                h = 2 + (b - r) / (max - min)
            ElseIf b = max Then
                h = 4 + (r - g) / (max - min)
            End If

            h = h * 60
            If h < 0 Then
                h = h + 360
            End If
        End If
    End Sub


    Private Sub HSV2RGB(ByVal h As Double, ByVal s As Double, ByVal v As Double, ByRef red As Integer, ByRef green As Integer, ByRef blue As Integer)
        Dim r As Double, g As Double, b As Double
        Dim i As Double, f As Double, p As Double, q As Double, t As Double

        If s = 0 Then
            r = v
            g = v
            b = v
        Else
            If h = 360 Then
                h = 0
            End If
            h = h / 60
            i = Int(h)

            f = h - i
            p = v * (1 - s)
            q = v * (1 - (s * f))
            t = v * (1 - (s * (1 - f)))

            Select Case i
                Case 0
                    r = v
                    g = t
                    b = p
                Case 1
                    r = q
                    g = v
                    b = p
                Case 2
                    r = p
                    g = v
                    b = t
                Case 3
                    r = p
                    g = q
                    b = v
                Case 4
                    r = t
                    g = p
                    b = v
                Case 5
                    r = v
                    g = p
                    b = q
            End Select
        End If

        red = CInt(r * 255.0)
        green = CInt(g * 255.0)
        blue = CInt(b * 255.0)

        red = ClipByte(red)
        green = ClipByte(green)
        blue = ClipByte(blue)
    End Sub

    ' This function clips a value into the range of 0 to 255
    Public Function ClipByte(ByRef value As Integer) As Integer
        If value > 255 Then
            Return 255
        ElseIf value < 0 Then
            Return 0
        End If
        Return value
    End Function

    ' This function clips a value into the range of 0 to 1
    Public Function ClipFloat(ByRef value As Double) As Double
        If value > 1 Then
            Return 1
        ElseIf value < 0 Then
            Return 0
        End If
        Return value
    End Function

    ' This function gets a pixel from the image without going out of bounds
    Public Function GetPixel(ByRef image As Bitmap, ByVal x As Integer, ByVal y As Integer) As Color
        If x < 0 Then
            x = 0
        ElseIf x > image.Width - 1 Then
            x = image.Width - 1
        End If
        If y < 0 Then
            y = 0
        ElseIf y > image.Height - 1 Then
            y = image.Height - 1
        End If
        Return image.GetPixel(x, y)
    End Function

    ' This function returns the interpolation of four pixels around an x and y position
    Private Function Interpolation(ByRef image As Bitmap, ByVal x As Double, ByVal y As Double) As Color
        Dim bx As Integer = Math.Floor(x)
        Dim by As Integer = Math.Floor(y)
        Dim a As Double, b As Double, a0 As Double, a1 As Double, a2 As Double, a3 As Double
        Dim red As Double, green As Double, blue As Double

        a = x - bx
        b = y - by

        a0 = (1 - a) * (1 - b)
        a1 = a * (1 - b)
        a2 = (1 - a) * b
        a3 = a * b

        red = GetPixel(image, bx, by).R * a0 + GetPixel(image, bx + 1, by).R * a1 + GetPixel(image, bx, by + 1).R * a2 + GetPixel(image, bx + 1, by + 1).R * a3
        green = GetPixel(image, bx, by).G * a0 + GetPixel(image, bx + 1, by).G * a1 + GetPixel(image, bx, by + 1).G * a2 + GetPixel(image, bx + 1, by + 1).G * a3
        blue = GetPixel(image, bx, by).B * a0 + GetPixel(image, bx + 1, by).B * a1 + GetPixel(image, bx, by + 1).B * a2 + GetPixel(image, bx + 1, by + 1).B * a3

        Return Color.FromArgb(red, green, blue)
    End Function

End Module

