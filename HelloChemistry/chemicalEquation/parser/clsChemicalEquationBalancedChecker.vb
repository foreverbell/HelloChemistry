
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalEquation.parser
    Public Class clsChemicalEquationBalancedChecker

#Region "Singleton Pattern"
        Private Shared ReadOnly _instance As New clsChemicalEquationBalancedChecker

        Public Shared ReadOnly Property instance As clsChemicalEquationBalancedChecker
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Private _equation As clsChemicalEquation
        Private _elementLeft As clsElementList
        Private _elementRight As clsElementList
        Private _electronLeft As Integer
        Private _electronRight As Integer

        Private Sub mergeElementAndElectron()
            _elementLeft = New clsElementList
            _elementRight = New clsElementList
            _electronLeft = 0
            _electronRight = 0
            For Each f As clsChemicalFormula In _equation.leftList
                _elementLeft.merge(f.element)
                _electronLeft += f.electron
            Next
            For Each f As clsChemicalFormula In _equation.rightList
                _elementRight.merge(f.element)
                _electronRight += f.electron
            Next
        End Sub

        Private Function checkElement(ByVal ele1 As clsElementList, ByVal ele2 As clsElementList) As Boolean
            For Each ele As String In ele1.elementTable.Keys
                If (ele2.elementTable.Contains(ele)) Then
                    If (ele1.elementTable.Item(ele) <> ele2.elementTable.Item(ele)) Then Return False
                Else
                    Return False
                End If
            Next
            Return True
        End Function

        Private Function checkElementAndElectron() As Boolean
            If (_electronLeft <> _electronRight) Then Return False
            If (Not checkElement(_elementLeft, _elementRight)) Then Return False
            If (Not checkElement(_elementRight, _elementLeft)) Then Return False
            Return True
        End Function

        Public Function checkBalanced(ByVal equation As clsChemicalEquation) As Boolean
            _equation = equation
            mergeElementAndElectron()
            Return checkElementAndElectron()
        End Function
    End Class
End Namespace