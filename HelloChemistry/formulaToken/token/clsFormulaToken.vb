
Namespace formulaToken.token
    Public Class clsFormulaToken

        Public Shared ReadOnly _formulaTokenList As New List(Of IFormulaToken) From
            {
                New clsTokenElement,
                New clsTokenNumber,
                New clsTokenLeftBracket,
                New clsTokenRightBracket,
                New clsTokenPeriod,
                New clsTokenPlus,
                New clsTokenEqual
            }

        Public Shared ReadOnly Property token(ByVal formula As String, ByVal position As Integer) As IFormulaToken
            Get
                For Each formulaToken As IFormulaToken In _formulaTokenList
                    If (formulaToken.match(formula, position)) Then
                        Dim result As IFormulaToken = System.Activator.CreateInstance(formulaToken.GetType)
                        result.match(formula, position)
                        Return result
                    End If
                Next
                Throw New ArgumentException("Bad token.")
            End Get
        End Property
    End Class
End Namespace