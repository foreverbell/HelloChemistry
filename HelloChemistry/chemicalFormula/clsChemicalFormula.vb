
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalFormula

    Public Class clsChemicalFormula

        Private _chemicalFormula As String
        Private _mass As Double
        Private _electron As Integer
        Private _element As clsElementList

        Public ReadOnly Property mass As Double
            Get
                Return _mass
            End Get
        End Property

        Public ReadOnly Property electron As Integer
            Get
                Return _electron
            End Get
        End Property

        Public ReadOnly Property chemicalFormula As String
            Get
                Return _chemicalFormula
            End Get
        End Property

        Public ReadOnly Property element As clsElementList
            Get
                Return _element
            End Get
        End Property

        Public Sub New(ByVal mass As Double,
                       ByVal electron As Integer,
                       ByVal chemicalFormula As String,
                       ByVal element As clsElementList)
            _mass = mass
            _electron = electron
            _chemicalFormula = chemicalFormula
            _element = element
        End Sub
    End Class
End Namespace