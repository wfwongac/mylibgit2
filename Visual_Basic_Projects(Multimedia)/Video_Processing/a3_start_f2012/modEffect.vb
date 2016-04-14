Module modEffect

    Public Function IsKeyframe(ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal threshold As Double, ByVal similarity As Double) As Boolean


        ' input1 and input2 are successive frames in the video
        ' threshold is the percentage of colour difference between two pixels in order to consider that they are different
        ' similarity is the percentage of same/similar pixels in the frame so that the two frames are considered similar

        ' *** Add your code here

        ' Remember you only have to compare the central area of the frames

        Dim diff As Integer = 0
        Dim total As Integer = 0
        For x As Integer = input1.Width / 4 To input1.Width * 3 / 4
            For y As Integer = input1.Height / 4 To input1.Height * 3 / 4
                total += 1
                Dim c1 As Color = input1.GetPixel(x, y)
                Dim c2 As Color = input2.GetPixel(x, y)
                Dim deltaR As Integer = Math.Abs(CInt(c1.R) - CInt(c2.R))
                Dim deltaG As Integer = Math.Abs(CInt(c1.G) - CInt(c2.G))
                Dim deltaB As Integer = Math.Abs(CInt(c1.B) - CInt(c2.B))
                Dim colorDiff As Double = CDbl(deltaB + deltaG + deltaR) / CDbl(255 * 3) 'change to double

                If colorDiff > threshold Then
                    diff += 1
                End If
            Next
        Next

        If CDbl(diff) / CDbl(total) > similarity Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function FadeIn(ByRef input As Bitmap, ByVal startRate As Double, _
                           ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)


        ' *** Add your code here
        Dim red, green, blue As Integer
        Dim ratio As Double = CDbl(currentIndex - startFrame) / CDbl(endFrame - startFrame)

        For x As Integer = 0 To input.Width - 1
            For y As Integer = 0 To input.Height - 1
                Dim c As Color = GetPixel(input, x, y)
                red = c.R * (startRate + (1 - startRate) * ratio)
                green = c.G * (startRate + (1 - startRate) * ratio)
                blue = c.B * (startRate + (1 - startRate) * ratio)

                output.SetPixel(x, y, Color.FromArgb(red, green, blue))
            Next
        Next

        Return output
    End Function

    Public Function FadeOut(ByRef input As Bitmap, ByVal endRate As Double, _
                            ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)


        ' *** Add your code here
        Dim red, green, blue As Integer
        Dim ratio As Double = CDbl(currentIndex - startFrame) / CDbl(endFrame - startFrame)

        For x As Integer = 0 To input.Width - 1
            For y As Integer = 0 To input.Height - 1
                Dim c As Color = GetPixel(input, x, y)
                red = c.R * (endRate + (1 - endRate) * (1 - ratio))
                green = c.G * (endRate + (1 - endRate) * (1 - ratio))
                blue = c.B * (endRate + (1 - endRate) * (1 - ratio))

                output.SetPixel(x, y, Color.FromArgb(red, green, blue))
            Next
        Next


        Return output
    End Function

    Public Function MotionBlur(ByRef input As Bitmap, ByVal blurCount As Integer, ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean, ByVal dirname As String) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)

        Static Dim bufferR(input.Width - 1, input.Height - 1) As Integer
        Static Dim bufferG(input.Width - 1, input.Height - 1) As Integer
        Static Dim bufferB(input.Width - 1, input.Height - 1) As Integer


        ' *** Add your code here
        ' Queue (data tpye/ class) is FIFO
        Static Dim frames As Queue

        ' You need to initialize the buffers at the start of the operation
        If newOp Then
            Array.Clear(bufferR, 0, bufferR.Length)
            Array.Clear(bufferG, 0, bufferG.Length)
            Array.Clear(bufferB, 0, bufferB.Length)
            frames = New Queue()
        End If

        ' Put the input(frame)'s color info into bufferR/G/B
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                Dim c As Color = GetPixel(input, x, y)
                bufferR(x, y) += c.R
                bufferG(x, y) += c.G
                bufferB(x, y) += c.B
            Next
        Next
        ' Add this frame into Queue
        frames.Enqueue(input.Clone())

        ' Remove the earliest frame inside the Queue
        ' and also clean / remove its color info. in bufferR/G/B
        If frames.Count() > blurCount Then
            Dim frame As Bitmap = frames.Dequeue()
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color = GetPixel(frame, x, y)
                    bufferR(x, y) -= c.R
                    bufferG(x, y) -= c.G
                    bufferB(x, y) -= c.B
                Next
            Next
        End If

        ' Use the info in bufferR/G/B to set pixel in output
        Dim red, green, blue As Integer
        For x As Integer = 0 To output.Width - 1
            For y As Integer = 0 To output.Height - 1
                red = bufferR(x, y) / frames.Count()
                green = bufferG(x, y) / frames.Count()
                blue = bufferB(x, y) / frames.Count()
                output.SetPixel(x, y, Color.FromArgb(red, green, blue))
            Next
        Next

        Return output
    End Function


    Public Function Melt(ByRef input As Bitmap, _
                         ByVal useSine As Boolean, ByVal amplitude As Integer, ByVal cycle As Integer, _
                         ByVal useRandom As Boolean, ByVal offset As Integer, ByVal period As Integer, _
                         ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input.Width, input.Height, Imaging.PixelFormat.Format24bppRgb)
        Static Dim displacement() As Integer = Nothing

        ' *** Add your code here
        If newOp Then

            ' Using code the previous lab (Melt Effect)
            ReDim displacement(input.Width - 1)

            If useSine Then
                For x As Integer = 0 To input.Width - 1
                    displacement(x) = displacement(x) + Math.Abs(amplitude * Math.Sin(2.0# * Math.PI * cycle * x / (input.Width - 1)))
                Next
            End If

            If useRandom Then
                Dim currentOffset As Integer
                Dim currentPeriod As Integer
                Dim sign As Integer

                Dim x As Integer = 0

                ' is "<" but not "<=". If not, there is a overflow
                While x < input.Width
                    currentPeriod = 1 + Rnd() * (period - 1)

                    If Rnd() >= 0.5 Then
                        sign = 1
                    Else
                        sign = -1
                    End If
                    For i As Integer = x To x + currentPeriod - 1
                        currentOffset = currentOffset + sign * Rnd() * offset
                        If currentOffset < 0 Then
                            currentOffset = -1 * currentOffset
                            sign = sign * (-1)
                        End If
                        If i < input.Width Then
                            displacement(i) = displacement(i) + currentOffset
                        End If
                    Next

                    x = x + currentPeriod
                End While
            End If
        End If

        Dim ratio As Double = (currentIndex - startFrame) / (endFrame - startFrame)

        For x As Integer = 0 To input.Width - 1
            For y As Integer = 0 To input.Height - 1
                Dim c As Color = GetPixel(input, x, y - CInt(displacement(x) * ratio))
                output.SetPixel(x, y, c)
            Next
        Next



        Return output
    End Function

    Public Function Transition(ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal type As Integer, ByVal duration As Double, _
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input1.Width, input1.Height, Imaging.PixelFormat.Format24bppRgb)
        Static Dim points() As Point
        Static Dim lines() As Integer
        ' The parameter duration is the time spanned by the transition effect
        ' at the middle of the selected video segment
        '
        ' For example,
        ' if startFrame = 20, endFrame = 80 and duration = 0.5,
        ' the transition lasts for (80 - 20) * 0.5 = 30 frames and
        ' the transition starts at frame (80 - 20 - 30) / 2 + 20 = 35
        '
        ' Similarly,
        ' if startFrame = 60, endFrame = 100 and duration = 0.25,
        ' the transition lasts for (100 - 60) * 0.25 = 10 frames and
        ' the transition starts at frame (100 - 60 - 10) / 2 + 60 = 75

        ' *** Add your code here

        If type = 4 Then
            ' Point Dissolve
            If newOp Then
                Dim done(input1.Width - 1, input1.Height - 1) As Boolean
                ReDim points(input1.Width * input1.Height - 1)
                For i As Integer = 0 To points.Length - 1
                    Dim p As Point
                    Do
                        p = New Point(Int(Rnd() * input1.Width), Int(Rnd() * input1.Height))
                    Loop While done(p.X, p.Y)
                    done(p.X, p.Y) = True
                    points(i) = p
                Next
            End If

        ElseIf type = 5 Then
            ' Line Dissolve
            If newOp Then
                Dim done(input1.Height - 1) As Boolean
                ReDim lines(input1.Height - 1)
                For i As Integer = 0 To lines.Length - 1
                    Dim y As Integer
                    Do
                        y = Int(Rnd() * input1.Height)
                    Loop While done(y)
                    done(y) = True
                    lines(i) = y
                Next
            End If
        End If


        Dim length As Integer = CInt((endFrame - startFrame) * duration)
        Dim start As Integer = CInt((endFrame - startFrame - length) / 2) + startFrame

        If currentIndex < start Then
            Dim g As Graphics = Graphics.FromImage(output)
            g.DrawImageUnscaled(input1, 0, 0)
            Return output
        End If
        If currentIndex >= start + length Then
            Dim g As Graphics = Graphics.FromImage(output)
            g.DrawImage(input2, 0, 0, input1.Width, input1.Height)
            Return output
        End If

        If type = 0 Then
            'top to bottem wipe
            Dim percentage As Double = CDbl(currentIndex - start) / CDbl(length)    ' increasing
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color
                    If y / input1.Height < percentage Then
                        c = GetPixel(input2, x * input2.Width / input1.Width, y * input2.Height / input1.Height)
                    Else
                        c = GetPixel(input1, x, y)
                    End If
                    output.SetPixel(x, y, c)
                Next
            Next

        ElseIf type = 1 Then
            ' bottom to top wipe
            Dim percentage As Double = 1 - CDbl(currentIndex - start) / CDbl(length)
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color
                    If y / input1.Height < percentage Then
                        c = GetPixel(input1, x, y)
                    Else
                        c = GetPixel(input2, x * input2.Width / input1.Width, y * input2.Height / input1.Height)
                    End If
                    output.SetPixel(x, y, c)
                Next
            Next

        ElseIf type = 2 Then
            ' left to right wipe
            Dim percentage As Double = CDbl(currentIndex - start) / CDbl(length)
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color
                    If x / input1.Width < percentage Then
                        c = GetPixel(input2, x * input2.Width / input1.Width, y * input2.Height / input1.Height)
                    Else
                        c = GetPixel(input1, x, y)
                    End If
                    output.SetPixel(x, y, c)
                Next
            Next

        ElseIf type = 3 Then
            ' right to left wipe
            Dim percentage As Double = 1 - CDbl(currentIndex - start) / CDbl(length)
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color
                    If x / input1.Width < percentage Then
                        c = GetPixel(input1, x, y)
                    Else
                        c = GetPixel(input2, x * input2.Width / input1.Width, y * input2.Height / input1.Height)
                    End If
                    output.SetPixel(x, y, c)
                Next
            Next

        ElseIf type = 4 Then
            'Point dissolve
            Dim index As Integer = Int(CDbl(currentIndex - start) / CDbl(length) * (points.Length - 1))
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color = GetPixel(input1, x, y)
                    output.SetPixel(x, y, c)
                Next
            Next
            For i As Integer = 0 To index
                Dim c As Color = GetPixel(input2, points(i).X * input2.Width / input1.Width, points(i).Y * input2.Height / input1.Height)
                output.SetPixel(points(i).X, points(i).Y, c)
            Next

        ElseIf type = 5 Then
            'line dissolve
            Dim index As Integer = Int(CDbl(currentIndex - start) / CDbl(length) * (lines.Length - 1))
            For x As Integer = 0 To output.Width - 1
                For y As Integer = 0 To output.Height - 1
                    Dim c As Color = GetPixel(input1, x, y)
                    output.SetPixel(x, y, c)
                Next
            Next
            For i As Integer = 0 To index

                For x As Integer = 0 To output.Width - 1
                    Dim c As Color = GetPixel(input2, x * input2.Width / input1.Width, lines(i) * input2.Height / input1.Height)
                    output.SetPixel(x, lines(i), c)
                Next
            Next

        End If



        Return output
    End Function

    Public Function TimeShift(ByRef input1 As Bitmap, ByRef input2 As Bitmap, ByVal cutOffPos As Double, _
                               ByVal currentIndex As Integer, ByVal startFrame As Integer, ByVal endFrame As Integer, ByVal newOp As Boolean) As Bitmap
        Dim output As New Bitmap(input1.Width, input1.Height, Imaging.PixelFormat.Format24bppRgb)

        Return output
    End Function

    ' Get the pixel from the bitmap with the boundary pixels correctly handled
    Private Function GetPixel(ByRef bitmap As Bitmap, ByVal x As Short, ByVal y As Short) As Color
        If x < 0 Then
            x = 0
        ElseIf x > bitmap.Width - 1 Then
            x = bitmap.Width - 1
        End If

        If y < 0 Then
            y = 0
        ElseIf y > bitmap.Height - 1 Then
            y = bitmap.Height - 1
        End If

        GetPixel = bitmap.GetPixel(x, y)
    End Function

    ' Clipping function
    Private Function Clip(ByVal value As Integer) As Integer
        If value > 255 Then
            Return 255
        ElseIf value < 0 Then
            Return 0
        End If
        Return value
    End Function

End Module
