
Namespace formulaToken.token
    Public Class clsTokenElectron
        Implements IFormulaToken

        Private Const ELECTRON_EXAMPLE As String = "e{-}"

        Public ReadOnly Property length As Integer Implements IFormulaToken.length
            Get
                Return ELECTRON_EXAMPLE.Length
            End Get
        End Property

        Public Function match(ByVal formula As String, ByVal position As Integer) As Boolean Implements IFormulaToken.match
            Return (String.Compare(formula, position, ELECTRON_EXAMPLE, 0, ELECTRON_EXAMPLE.Length) = 0)
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenElectron
        End Function
    End Class
End Namespace