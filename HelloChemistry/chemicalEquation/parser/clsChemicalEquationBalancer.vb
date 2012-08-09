
Imports HelloChemistry.algorithm
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.fraction
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalEquation.parser
    Public Class clsChemicalEquationBalancer

#Region "Singleton Pattern"
        Private Shared ReadOnly _instance As New clsChemicalEquationBalancer

        Public Shared ReadOnly Property instance As clsChemicalEquationBalancer
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Private _elementTotal As clsElementList
        Private _equation As clsChemicalEquation
        Private _matrix(,) As clsFraction
        Private _lineCount As Integer
        Private _rowCount As Integer

        Private Sub mergeElement()
            _elementTotal = New clsElementList
            For Each f As clsChemicalFormula In _equation.leftList
                _elementTotal.merge(f.element)
            Next
            For Each f As clsChemicalFormula In _equation.rightList
                _elementTotal.merge(f.element)
            Next
        End Sub

        Private Sub createChemicalMatrix()
            ReDim _matrix(_elementTotal.elementTable.Count + 2, _equation.leftList.Count + _equation.rightList.Count + 1)

            _lineCount = 0
            _rowCount = 0

            For Each ele As String In _elementTotal.elementTable.Keys
                _lineCount += 1
                _rowCount = 0
                For Each f As clsChemicalFormula In _equation.leftList
                    _rowCount += 1
                    If (f.element.elementTable.Contains(ele)) Then
                        _matrix(_lineCount, _rowCount) = New clsFraction(f.element.elementTable.Item(ele))
                    End If
                Next
                For Each f As clsChemicalFormula In _equation.rightList
                    _rowCount += 1
                    If (f.element.elementTable.Contains(ele)) Then
                        _matrix(_lineCount, _rowCount) = New clsFraction(-f.element.elementTable.Item(ele))
                    End If
                Next
            Next
        End Sub

        Private Sub createElectronMatrix()
            _lineCount += 1
            _rowCount = 0

            For Each f As clsChemicalFormula In _equation.leftList
                _rowCount += 1
                _matrix(_lineCount, _rowCount) = New clsFraction(f.electron)
            Next

            For Each f As clsChemicalFormula In _equation.rightList
                _rowCount += 1
                _matrix(_lineCount, _rowCount) = New clsFraction(-f.electron)
            Next
        End Sub

        Private Sub completeMatrix()
            ' We assume that the factor of the first chemical formula is 1
            _matrix(_lineCount + 1, 1) = New clsFraction(1)
            _matrix(_lineCount + 1, _rowCount + 1) = New clsFraction(1)

            ' Fill empty fractions as 0
            For i As Integer = 1 To _lineCount + 1
                For j As Integer = 1 To _rowCount + 1
                    If (_matrix(i, j) Is Nothing) Then
                        _matrix(i, j) = New clsFraction
                    End If
                Next
            Next
        End Sub

        Private Function solveEquationAndReturn()
            ' Solve the equations
            Dim solve(0) As clsFraction, result(0) As Integer
            Dim retEquationLeftList As New List(Of clsChemicalFormula)
            Dim retEquationRightList As New List(Of clsChemicalFormula)
            Dim pointer As Integer
            If (clsGaussJordanElimination.gaussJordanElimination(_matrix, solve)) Then
                result = clsFraction.simplify(solve)
                ' Reform the expression
                pointer = 0
                For Each f As clsChemicalFormula In _equation.leftList
                    pointer += 1
                    f.factor *= result(pointer)
                    retEquationLeftList.Add(f)
                Next
                For Each f As clsChemicalFormula In _equation.rightList
                    pointer += 1
                    f.factor *= result(pointer)
                    retEquationRightList.Add(f)
                Next

                Return New clsChemicalEquation(retEquationLeftList,
                                               retEquationRightList,
                                               True)
            Else
                Throw New Exception("Information not enough, balance equation " + _equation.strEquation + "failed.")
            End If
        End Function

        Public Function balance(ByVal equation As clsChemicalEquation) As clsChemicalEquation
            _equation = equation
            mergeElement()
            createChemicalMatrix()
            createElectronMatrix()
            completeMatrix()
            Return solveEquationAndReturn()
        End Function
    End Class
End Namespace