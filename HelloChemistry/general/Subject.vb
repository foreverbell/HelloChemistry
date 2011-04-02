
Namespace general

    Public MustInherit Class Subject
        Private _observers As New List(Of Observer)

        Public Overridable Sub attach(ByVal o As Observer)
            _observers.Add(o)
            o.update(Me)
        End Sub

        Public Overridable Sub detach(ByVal o As Observer)
            _observers.Remove(o)
        End Sub

        Public Overridable Sub notify()
            For Each o As Observer In _observers
                o.update(Me)
            Next
        End Sub
    End Class

End Namespace