
Imports HelloChemistry.general

Namespace matterState.state
    Public Interface IMatterState
        Inherits INullable
        ReadOnly Property matterStateType() As enumMatterState
        ReadOnly Property matterStateName() As String
        ReadOnly Property matterStateNameWithBracket() As String
    End Interface
End Namespace