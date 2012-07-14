
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenLeftBracket
        Implements IFormulaToken

        Public ReadOnly Property length As Integer Implements IFormulaToken.length
            Get
                Return 1
            End Get
        End Property

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            Return (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charLeftBracket)
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenLeftBracket
        End Function

        Public Function toStr() As String Implements IFormulaToken.toStr
            Return "("
        End Function
    End Class
End Namespace