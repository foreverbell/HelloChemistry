
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalFormula

    Public Class clsChemicalFormula

        Private _strChemicalFormula As String
        Private _mass As Double
        Private _electron As Integer
        Private _element As clsElementList
        Private _factor As Integer

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

        Public ReadOnly Property strChemicalFormula As String
            Get
                Return _strChemicalFormula
            End Get
        End Property

        Public ReadOnly Property element As clsElementList
            Get
                Return _element
            End Get
        End Property

        Public Property factor As Integer
            Get
                Return _factor
            End Get
            Set(value As Integer)
                _factor = value
            End Set
        End Property

        Public Sub New(ByVal mass As Double,
                       ByVal electron As Integer,
                       ByVal strChemicalFormula As String,
                       ByVal element As clsElementList)
            _mass = mass
            _electron = electron
            _strChemicalFormula = strChemicalFormula
            _element = element
            _factor = 1
        End Sub
    End Class
End Namespace