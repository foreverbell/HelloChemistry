
Namespace chemicalFormula.formulaToken.formulaChar
    Public Class clsLeftBracket
        Implements IFormulaChar

        Public Function charType() As enumFormulaChar Implements IFormulaChar.charType
            Return enumFormulaChar.charLeftBracket
        End Function

        Public Function match(ByVal ch As Char) As Boolean Implements IFormulaChar.match
            Return (ch = "(")
        End Function
    End Class
End Namespace