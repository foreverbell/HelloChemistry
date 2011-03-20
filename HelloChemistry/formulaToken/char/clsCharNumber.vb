
Namespace formulaToken.char
    Public Class clsCharNumber
        Implements IFormulaChar

        Public Function charType() As enumFormulaChar Implements IFormulaChar.charType
            Return enumFormulaChar.charNumber
        End Function

        Public Function match(ByVal ch As Char) As Boolean Implements IFormulaChar.match
            Return (ch >= "0" And ch <= "9")
        End Function
    End Class
End Namespace