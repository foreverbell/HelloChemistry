
Namespace chemicalFormula.formulaToken
    Public Class clsFormulaToken

        Public Shared ReadOnly _formulaTokenList As New HashSet(Of IFormulaToken) From
            {
                New clsTokenElement,
                New clsTokenNumber,
                New clsTokenLeftBracket,
                New clsTokenRightBracket
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
                Throw New Exception("bad token.")
            End Get
        End Property
    End Class
End Namespace