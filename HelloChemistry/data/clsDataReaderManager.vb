
Namespace data
    Public Class clsDataReaderManager

#Region "Singleton Pattern"
        Private Shared ReadOnly _instance As New clsDataReaderManager

        Public Shared ReadOnly Property instance As clsDataReaderManager
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Private _dataReaderList As New List(Of clsDataReader) From
            {
                New clsDataReader(enumDataReaderArgment.elementSymbol, My.Resources.resElement.symbol),
                New clsDataReader(enumDataReaderArgment.elementWeight, My.Resources.resElement.weight),
                New clsDataReader(enumDataReaderArgment.elementElectronShell, My.Resources.resElement.shell),
                New clsDataReader(enumDataReaderArgment.elementMeltingAndBoilingPoint, My.Resources.resElement.melting_boiling_point)
            }

        Public ReadOnly Property dataReader(ByVal type As enumDataReaderArgment) As clsDataReader
            Get
                For Each reader As clsDataReader In _dataReaderList
                    If reader.dataType = type Then
                        Return reader
                    End If
                Next
                Throw New ArgumentException("Bad data type.")
            End Get
        End Property
    End Class
End Namespace