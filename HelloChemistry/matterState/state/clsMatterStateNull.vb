
Namespace matterState.state
    Public Class clsMatterStateNull
        Implements IMatterState

        Public ReadOnly Property matterStateName As String Implements IMatterState.matterStateName
            Get
                Return "null"
            End Get
        End Property

        Public ReadOnly Property matterStateNameWithBracket As String Implements IMatterState.matterStateNameWithBracket
            Get
                Return "(null)"
            End Get
        End Property

        Public ReadOnly Property matterStateType As enumMatterState Implements IMatterState.matterStateType
            Get
                Return enumMatterState.null
            End Get
        End Property

        Public Function isNull() As Boolean Implements general.INullable.isNull
            Return True
        End Function
    End Class
End Namespace