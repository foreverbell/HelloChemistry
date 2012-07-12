
Namespace matterState
    Public Class clsMatterStateSolid
        Implements IMatterState

        Public ReadOnly Property matterStateName As String Implements IMatterState.matterStateName
            Get
                Return "s"
            End Get
        End Property

        Public ReadOnly Property matterStateNameWithBracket As String Implements IMatterState.matterStateNameWithBracket
            Get
                Return "(s)"
            End Get
        End Property

        Public ReadOnly Property matterStateType As enumMatterState Implements IMatterState.matterStateType
            Get
                Return enumMatterState.solid
            End Get
        End Property
    End Class
End Namespace