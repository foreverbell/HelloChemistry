
Namespace formulaToken.char
    Public Class clsCharMinus
        Implements IFormulaChar

        Public Function charType() As enumFormulaChar Implements IFormulaChar.charType
            Return enumFormulaChar.charMinus
        End Function

        Public Function match(ByVal ch As Char) As Boolean Implements IFormulaChar.match
            Return (ch = "-")
        End Function
    End Class
End Namespace