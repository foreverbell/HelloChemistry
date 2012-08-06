
Imports HelloChemistry.chemicalFormula

Namespace chemicalEquation.heat
    Public Class clsHeatEquation
        Private _chemicalEquation As clsChemicalEquation
        Private _deltaHeat As Double

        Public ReadOnly Property chemicalEquation As clsChemicalEquation
            Get
                Return _chemicalEquation
            End Get
        End Property

        Public ReadOnly Property deltaHeat As Double
            Get
                Return _deltaHeat
            End Get
        End Property

        Public ReadOnly Property strEquation As String
            Get
                Return _chemicalEquation.strEquation & "  ΔH = " & _deltaHeat & " kJ/mol"
            End Get
        End Property

        Private Sub verifyEquation()

            ' Balanced?
            If (_chemicalEquation.isBalanced = False) Then
                Throw New Exception("Chemical equation " & _chemicalEquation.strEquation & " is not balanced.")
            End If

            ' Has Matter State?
            For Each formula As clsChemicalFormula In _chemicalEquation.leftList
                If (formula.matterState.isNull) Then
                    Throw New Exception("Matter state of chemical " & formula.strFormula & " is unclear.")
                End If
            Next
            For Each formula As clsChemicalFormula In _chemicalEquation.rightList
                If (formula.matterState.isNull) Then
                    Throw New Exception("Matter state of chemical " & formula.strFormula & " is unclear.")
                End If
            Next

        End Sub

        Public Function simplify() As Integer
            Dim gcd As Integer = _chemicalEquation.simplify()
            _deltaHeat /= gcd
        End Function

        Public Sub New(ByVal chemicalEquation As clsChemicalEquation, ByVal deltaHeat As Double)
            _chemicalEquation = chemicalEquation
            _deltaHeat = deltaHeat

            verifyEquation()
        End Sub
    End Class
End Namespace