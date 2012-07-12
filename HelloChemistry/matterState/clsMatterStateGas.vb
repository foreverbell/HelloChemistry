﻿Namespace matterState
    Public Class clsMatterStateGas
        Implements IMatterState

        Public ReadOnly Property matterStateName As String Implements IMatterState.matterStateName
            Get
                Return "g"
            End Get
        End Property

        Public ReadOnly Property matterStateNameWithBracket As String Implements IMatterState.matterStateNameWithBracket
            Get
                Return "(g)"
            End Get
        End Property

        Public ReadOnly Property matterStateType As enumMatterState Implements IMatterState.matterStateType
            Get
                Return enumMatterState.gas
            End Get
        End Property
    End Class
End Namespace