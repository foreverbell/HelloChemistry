
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalFormula

    Public Class clsChemicalFormula

        Private _strChemicalFormula As String
        Private _electron As Integer
        Private _element As clsElementList
        Private _factor As Integer

        Public ReadOnly Property mass As Double
            Get
                Return _element.mass
            End Get
        End Property

        Public ReadOnly Property electron As Integer
            Get
                Return _electron
            End Get
        End Property

        Public ReadOnly Property strChemicalFormula As String
            Get
                Return _factor.ToString & _strChemicalFormula
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
                _element.divide(_factor)
                _electron /= factor
                _factor = value
                _element.multiply(_factor)
                _electron *= factor
            End Set
        End Property

        Public Sub New(ByVal electron As Integer,
                       ByVal strChemicalFormula As String,
                       ByVal element As clsElementList)
            _electron = electron
            _strChemicalFormula = strChemicalFormula
            _element = element
            _factor = 1
        End Sub
    End Class
End Namespace