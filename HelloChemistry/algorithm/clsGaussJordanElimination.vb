
Imports HelloChemistry.fraction

Namespace algorithm

    '
    ' Reference: http://www.artofproblemsolving.com/blog/13009
    ' Original author: zkw
    '

    Public Class clsGaussJordanElimination

        Public Shared Function gaussJordanElimination(ByVal inMatrix(,) As clsFraction, ByRef solve() As clsFraction) As Boolean
            Dim n As Integer = UBound(inMatrix, 1), m As Integer = UBound(inMatrix, 2)
            Dim maxV As Integer, maxValue As clsFraction, temp As clsFraction
            Dim solvePoint() As Integer

            ReDim solvePoint(m - 1)
            ReDim solve(m - 1)

            For i As Integer = 1 To n
                maxValue = New clsFraction(0)
                For j As Integer = 1 To m - 1
                    temp = inMatrix(i, j).abs()
                    If (temp > maxValue) Then
                        maxValue = temp
                        maxV = j
                    End If
                Next
                If (maxValue = 0) Then
                    If (inMatrix(i, m) = 0) Then
                        Continue For
                    Else
                        Return False
                    End If
                End If

                solvePoint(maxV) = i

                temp = inMatrix(i, maxV)
                For j As Integer = 1 To m
                    inMatrix(i, j) /= temp
                Next
                For j As Integer = 1 To n
                    If (i <> j) Then
                        temp = inMatrix(j, maxV)
                        For k As Integer = 1 To m
                            inMatrix(j, k) -= inMatrix(i, k) * temp
                        Next
                    End If
                Next
            Next

            For i As Integer = 1 To m - 1
                If (solvePoint(i) = 0) Then
                    Return False
                End If
                solve(i) = inMatrix(solvePoint(i), m)
            Next

            Return True

        End Function
    End Class
End Namespace