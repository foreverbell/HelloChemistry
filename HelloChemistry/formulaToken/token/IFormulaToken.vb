
Namespace formulaToken.token
    Public Interface IFormulaToken
        ReadOnly Property length() As Integer
        Function tokenType() As enumFormulaToken
        Function match(ByVal formula As String, ByVal position As Integer) As Boolean
    End Interface
End Namespace