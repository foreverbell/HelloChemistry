
Namespace fraction
    Public Class clsFraction

        Private _numerator As Integer
        Private _denominator As Integer

        Public ReadOnly Property numerator As Integer
            Get
                Return _numerator
            End Get
        End Property

        Public ReadOnly Property denominator As Integer
            Get
                Return _denominator
            End Get
        End Property

        Public Shared Operator +(ByVal a As clsFraction, ByVal b As clsFraction) As clsFraction
            Return New clsFraction(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator)
        End Operator

        Public Shared Operator -(ByVal a As clsFraction, ByVal b As clsFraction) As clsFraction
            Return New clsFraction(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator)
        End Operator

        Public Shared Operator *(ByVal a As clsFraction, ByVal b As clsFraction) As clsFraction
            Return New clsFraction(a.numerator * b.numerator, a.denominator * b.denominator)
        End Operator

        Public Sub New(ByVal numerator As Integer, ByVal denominator As Integer)
            Dim factor As Integer = clsEuclidAlgorithm.euclidGCD(numerator, denominator)

            _numerator = numerator / factor
            _denominator = denominator / factor

            Debug.Print("New fraction: " & _numerator.ToString & "/" & _denominator.ToString)
        End Sub

        Public Sub New(ByVal number As Integer)
            _numerator = number
            _denominator = 1

            Debug.Print("New fraction: " & _numerator.ToString & "/" & _denominator.ToString)
        End Sub
    End Class
End Namespace