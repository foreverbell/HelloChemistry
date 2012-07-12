
Namespace matterState
    Public Class clsMatterStateLiquid
        Implements IMatterState

        Public ReadOnly Property matterStateName As String Implements IMatterState.matterStateName
            Get
                Return "l"
            End Get
        End Property

        Public ReadOnly Property matterStateNameWithBracket As String Implements IMatterState.matterStateNameWithBracket
            Get
                Return "(l)"
            End Get
        End Property

        Public ReadOnly Property matterStateType As enumMatterState Implements IMatterState.matterStateType
            Get
                Return enumMatterState.liquid
            End Get
        End Property
    End Class
End Namespace