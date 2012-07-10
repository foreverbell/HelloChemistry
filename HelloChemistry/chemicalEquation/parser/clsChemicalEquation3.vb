
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalEquation.parser
    Public Class clsChemicalEquation3

        Public Sub parseFormula(ByVal stream As clsFormulaTokenStream, ByVal formulaList As List(Of clsChemicalFormula))
            formulaList.Add(clsChemicalFormulaParser.instance.parse(stream))
        End Sub
    End Class
End Namespace