
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenRightBracket
        Implements IFormulaToken

        Public ReadOnly Property length As Integer Implements IFormulaToken.length
            Get
                Return 1
            End Get
        End Property

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            Return (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charRightBracket)
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenRightBracket
        End Function
    End Class
End Namespace