
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.formulaToken

Namespace chemicalEquation.parser
    Public Class clsChemicalEquation3

        Public Sub parseFormula(ByVal stream As clsFormulaTokenStream, ByVal formulaList As List(Of clsChemicalFormula))
            formulaList.Add(New clsChemicalFormula(stream))
        End Sub
    End Class
End Namespace