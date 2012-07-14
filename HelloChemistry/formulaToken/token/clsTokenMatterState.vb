
Imports HelloChemistry.matterState.state
Imports HelloChemistry.matterState

Namespace formulaToken.token
    Public Class clsTokenMatterState
        Implements IFormulaToken

        Private _stateType As IMatterState

        Public ReadOnly Property length As Integer Implements IFormulaToken.length
            Get
                Return _stateType.matterStateNameWithBracket.Length
            End Get
        End Property

        Public ReadOnly Property stateType As IMatterState
            Get
                Return _stateType
            End Get
        End Property

        Public Function match(formula As String, position As Integer) As Boolean Implements IFormulaToken.match
            _stateType = clsMatterStateManager.instance.matchMatterStateWithBracket(formula, position)
            If (_stateType.isNull()) Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Function tokenType() As enumFormulaToken Implements IFormulaToken.tokenType
            Return enumFormulaToken.tokenMatterState
        End Function

        Public Function toStr() As String Implements IFormulaToken.toStr
            Return _stateType.matterStateNameWithBracket
        End Function
    End Class
End Namespace