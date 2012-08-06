
Imports HelloChemistry.chemicalFormula.parser
Imports HelloChemistry.matterState.state

Namespace chemicalFormula

    Public Class clsChemicalFormula

        Private _strFormula As String
        Private _electron As Integer
        Private _element As clsElementList
        Private _matterState As IMatterState
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

        Public ReadOnly Property strFormula As String
            Get
                Return IIf(factor = 1, "", factor.ToString) & _strFormula
            End Get
        End Property

        Public ReadOnly Property strFormulaWithoutFactor As String
            Get
                Return _strFormula
            End Get
        End Property

        Public ReadOnly Property element As clsElementList
            Get
                Return _element
            End Get
        End Property

        Public ReadOnly Property matterState As IMatterState
            Get
                Return _matterState
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
                       ByVal strFormula As String,
                       ByVal element As clsElementList,
                       ByVal matterState As IMatterState,
                       ByVal factor As Integer)
            _electron = electron
            _strFormula = strFormula
            _element = element
            _matterState = matterState
            _factor = factor
        End Sub
    End Class
End Namespace