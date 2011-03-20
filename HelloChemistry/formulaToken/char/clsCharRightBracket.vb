
Namespace formulaToken.char
    Public Class clsCharRightBracket
        Implements IFormulaChar

        Public Function charType() As enumFormulaChar Implements IFormulaChar.charType
            Return enumFormulaChar.charRightBracket
        End Function

        Public Function match(ByVal ch As Char) As Boolean Implements IFormulaChar.match
            Return (ch = ")")
        End Function
    End Class
End Namespace