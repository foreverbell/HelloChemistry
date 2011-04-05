
Imports HelloChemistry.formulaToken.char

Namespace formulaToken.token
    Public Class clsTokenPeriod
        Implements IFormulaToken

        Public ReadOnly Property length As Integer Implements IFormulaToken.length
            Get
                Return 1
            End Get
        End Property

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            Return (clsFormulaChar.charType(formula(position)) = enumFormulaChar.charPeriod)
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenPeriod
        End Function
    End Class
End Namespace