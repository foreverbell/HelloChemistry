Namespace matterState.state
    Public Class clsMatterStateAqueous
        Implements IMatterState

        Public ReadOnly Property matterStateName As String Implements IMatterState.matterStateName
            Get
                Return "aqueous"
            End Get
        End Property

        Public ReadOnly Property matterStateNameWithBracket As String Implements IMatterState.matterStateNameWithBracket
            Get
                Return "(aq)"
            End Get
        End Property

        Public ReadOnly Property matterStateType As enumMatterState Implements IMatterState.matterStateType
            Get
                Return enumMatterState.aqueous
            End Get
        End Property

        Public Function isNull() As Boolean Implements general.INullable.isNull
            Return False
        End Function
    End Class
End Namespace