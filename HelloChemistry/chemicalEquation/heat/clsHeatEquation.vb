
Imports HelloChemistry.chemicalFormula

Namespace chemicalEquation.heat
    Public Class clsHeatEquation
        Private _chemicalEquation As clsChemicalEquation
        Private _deltaHeat As Double

        Private Sub verifyEquation()

            ' Balanced?
            If (_chemicalEquation.isBalanced = False) Then
                Throw New Exception("Chemical equation " & _chemicalEquation.strChemicalEquation & " is not balanced.")
            End If

            ' Has Matter State?
            For Each formula As clsChemicalFormula In _chemicalEquation.leftList
                If (formula.matterState.isNull) Then
                    Throw New Exception("Matter state of chemical " & formula.strChemicalFormula & " is unclear.")
                End If
            Next
            For Each formula As clsChemicalFormula In _chemicalEquation.rightList
                If (formula.matterState.isNull) Then
                    Throw New Exception("Matter state of chemical " & formula.strChemicalFormula & " is unclear.")
                End If
            Next

        End Sub

        Public Sub New(ByVal chemicalEquation As clsChemicalEquation, ByVal deltaHeat As Double)
            _chemicalEquation = chemicalEquation
            _deltaHeat = deltaHeat

            verifyEquation()
        End Sub
    End Class
End Namespace