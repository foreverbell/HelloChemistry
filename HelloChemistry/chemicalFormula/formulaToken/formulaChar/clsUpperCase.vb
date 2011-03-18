
Namespace chemicalFormula.formulaToken.formulaChar
    Public Class clsUpperCase
        Implements IFormulaChar

        Public Function charType() As enumFormulaChar Implements IFormulaChar.charType
            Return enumFormulaChar.charUpperCase
        End Function

        Public Function match(ByVal ch As Char) As Boolean Implements IFormulaChar.match
            Return (ch >= "A" And ch <= "Z")
        End Function
    End Class
End Namespace