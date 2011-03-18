
Namespace data
    Public Class clsDataReaderManager

        Private Shared ReadOnly _instance As New clsDataReaderManager

        Private ReadOnly _dataReaderList As New HashSet(Of clsDataReader) From
            {
                New clsDataReader(enumDataReaderArgment.elementSymbol, My.Resources.resElement.symbol),
                New clsDataReader(enumDataReaderArgment.elementWeight, My.Resources.resElement.weight),
                New clsDataReader(enumDataReaderArgment.elementElectronShell, My.Resources.resElement.shell)
            }

        Public Shared ReadOnly Property instance As clsDataReaderManager
            Get
                Return _instance
            End Get
        End Property

        Public ReadOnly Property dataReader(ByVal index As enumDataReaderArgment) As clsDataReader
            Get
                For Each reader As clsDataReader In _dataReaderList
                    If reader.dataIndex = index Then
                        Return reader
                    End If
                Next
                Throw New ArgumentException
            End Get
        End Property

        Private Sub New()
        End Sub
    End Class
End Namespace