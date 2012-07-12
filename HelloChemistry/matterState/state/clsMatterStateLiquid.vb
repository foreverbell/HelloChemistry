
Namespace matterState.state
    Public Class clsMatterStateLiquid
        Implements IMatterState

        Public ReadOnly Property matterStateName As String Implements IMatterState.matterStateName
            Get
                Return "liquid"
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

        Public Function isNull() As Boolean Implements general.INullable.isNull
            Return False
        End Function
    End Class
End Namespace