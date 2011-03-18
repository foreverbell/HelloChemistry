
Imports HelloChemistry.chemicalFormula.formulaToken.formulaChar

Namespace chemicalFormula.formulaToken
    Public Class clsTokenLeftBracket
        Implements IFormulaToken

        Public Function length() As Integer Implements IFormulaToken.length
            Return 1
        End Function

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            Return (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charLeftBracket)
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenLeftBracket
        End Function
    End Class
End Namespace