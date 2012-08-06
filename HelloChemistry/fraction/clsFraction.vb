
Imports HelloChemistry.algorithm

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

        Public ReadOnly Property value As Double
            Get
                Return _numerator / _denominator
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

        Public Shared Operator /(ByVal a As clsFraction, ByVal b As clsFraction) As clsFraction
            Return New clsFraction(a.numerator * b.denominator, a.denominator * b.numerator)
        End Operator

        Public Shared Operator >(ByVal a As clsFraction, ByVal b As clsFraction) As Boolean
            Return a.value > b.value
        End Operator

        Public Shared Operator <(ByVal a As clsFraction, ByVal b As clsFraction) As Boolean
            Return a.value < b.value
        End Operator

        Public Shared Operator =(ByVal a As clsFraction, ByVal b As Integer) As Boolean
            Return (a.denominator = 1 And b = a.numerator)
        End Operator

        Public Shared Operator <>(ByVal a As clsFraction, ByVal b As Integer) As Boolean
            Return Not (a = b)
        End Operator

        ' multiply all fractions with a factor to be the simplest
        Public Shared Function simplify(ByVal fraction() As clsFraction) As Integer()
            Dim factor As Integer = 1
            Dim bound As Integer = UBound(fraction)

            For i As Integer = 1 To bound
                factor = clsEuclidGCD.euclidLCM(fraction(i).denominator, factor)
            Next

            For i As Integer = 1 To bound
                fraction(i) *= New clsFraction(factor)
            Next

            Dim result(bound) As Integer

            factor = fraction(1).numerator
            For i As Integer = 1 To bound
                factor = clsEuclidGCD.euclidGCD(factor, fraction(i).numerator)
            Next

            For i As Integer = 1 To bound
                result(i) = fraction(i).numerator / factor
            Next

            Return result
        End Function

        Public Function abs() As clsFraction
            Return New clsFraction(Math.Abs(_numerator), Math.Abs(_denominator))
        End Function

        Public Sub New(ByVal numerator As Integer, ByVal denominator As Integer)
            Dim factor As Integer = clsEuclidGCD.euclidGCD(numerator, denominator)

            _numerator = numerator / factor
            _denominator = denominator / factor
        End Sub

        Public Sub New(ByVal number As Integer)
            _numerator = number
            _denominator = 1
        End Sub

        Public Sub New()
            _numerator = 0
            _denominator = 1
        End Sub
    End Class
End Namespace