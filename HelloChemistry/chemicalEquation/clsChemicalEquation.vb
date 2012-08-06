
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.chemicalEquation.parser
Imports HelloChemistry.algorithm

Namespace chemicalEquation
    Public Class clsChemicalEquation

        Private _leftList As New List(Of clsChemicalFormula)
        Private _rightList As New List(Of clsChemicalFormula)
        Private _balanced As Boolean

        Public ReadOnly Property leftList As List(Of clsChemicalFormula)
            Get
                Return _leftList
            End Get
        End Property

        Public ReadOnly Property rightList As List(Of clsChemicalFormula)
            Get
                Return _rightList
            End Get
        End Property

        Public ReadOnly Property strEquation As String
            Get
                Dim ret As String = vbNullString
                For Each f As clsChemicalFormula In _leftList
                    ret &= f.strFormula & " + "
                Next
                ret = Left(ret, ret.Length - 3) & " = "
                For Each f As clsChemicalFormula In _rightList
                    ret &= f.strFormula & " + "
                Next
                ret = Left(ret, ret.Length - 3)
                Return ret
            End Get
        End Property

        Public Function balance() As clsChemicalEquation
            If (_balanced) Then
                Throw New Exception("Equation already balanced.")
            Else
                Return clsChemicalEquationBalancer.instance.balance(Me)
            End If
        End Function

        Public Function simplify() As Integer
            Dim gcd As Integer = _leftList.First.factor
            For Each f As clsChemicalFormula In _leftList
                gcd = clsEuclidGCD.euclidGCD(gcd, f.factor)
            Next
            For Each f As clsChemicalFormula In _rightList
                gcd = clsEuclidGCD.euclidGCD(gcd, f.factor)
            Next
            If (gcd <> 1) Then
                For Each f As clsChemicalFormula In _leftList
                    f.factor = f.factor / gcd
                Next
                For Each f As clsChemicalFormula In _rightList
                    f.factor = f.factor / gcd
                Next
            End If
            Return gcd
        End Function

        Public Function isBalanced() As Boolean
            If (Not _balanced) Then
                Dim result As Boolean = clsChemicalEquationBalancedChecker.instance.checkBalanced(Me)
                _balanced = result
            End If
            Return _balanced
        End Function

        Public Sub New(ByVal leftList As List(Of clsChemicalFormula),
                       ByVal rightList As List(Of clsChemicalFormula),
                       ByVal balanced As Boolean)
            _leftList = leftList
            _rightList = rightList
            _balanced = balanced
        End Sub
    End Class
End Namespace