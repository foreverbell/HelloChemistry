
Namespace algorithm

    Public Class clsEuclidGCD
        Public Shared Function euclidGCD(ByVal a As Integer, ByVal b As Integer) As Integer
            If (b = 0) Then
                Return a
            Else
                Return euclidGCD(b, a Mod b)
            End If
        End Function

        Public Shared Function euclidLCM(ByVal a As Integer, ByVal b As Integer) As Integer
            Return a * b / euclidGCD(a, b)
        End Function
    End Class
End Namespace