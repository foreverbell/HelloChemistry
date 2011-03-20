
Namespace formulaToken.char
    Public Class clsCharLowerCase
        Implements IFormulaChar

        Public Function charType() As enumFormulaChar Implements IFormulaChar.charType
            Return enumFormulaChar.charLowerCase
        End Function

        Public Function match(ByVal ch As Char) As Boolean Implements IFormulaChar.match
            Return (ch >= "a" And ch <= "z")
        End Function
    End Class
End Namespace