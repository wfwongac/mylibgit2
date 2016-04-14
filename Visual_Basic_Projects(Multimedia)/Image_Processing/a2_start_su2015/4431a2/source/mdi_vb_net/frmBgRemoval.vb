Public Class frmBgRemoval
    Inherits frmEffect

    Private Sub btnBgRemoval_Click(sender As System.Object, e As System.EventArgs) Handles btnBgRemoval.Click

        ApplyEffect()

    End Sub

    Overrides Function Process(ByRef image As Bitmap, ByVal i As Integer, ByVal j As Integer) As Color

        Dim selectedImageForm As frmImage = DirectCast(Me.MdiParent, frmMain).selectedImageForm
        Dim sourceX As Integer = selectedImageForm.selectedArea.Left
        Dim sourceY As Integer = selectedImageForm.selectedArea.Top
        Dim OldColor As Color = selectedImageForm.image.GetPixel(sourceX, sourceY)


        Dim redDiff As Double = Math.Abs(CInt(OldColor.R) - CInt(image.GetPixel(i, j).R))
        Dim greenDiff As Double = Math.Abs(CInt(OldColor.G) - CInt(image.GetPixel(i, j).G))
        Dim blueDiff As Double = Math.Abs(CInt(OldColor.B) - CInt(image.GetPixel(i, j).B))
        Dim totalDiff As Double = (redDiff + greenDiff + blueDiff)

        If (totalDiff < tbBgThreshold.Value) Then
            Return Color.White
        Else
            Return image.GetPixel(i, j)
        End If

    End Function

End Class
