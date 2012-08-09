
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.fraction
Imports HelloChemistry.algorithm

Namespace chemicalEquation.heat
    Public Class clsHeatEquationSolver

#Region "Singleton Pattern"
        Private Shared ReadOnly _instance As New clsHeatEquationSolver

        Public Shared ReadOnly Property instance As clsHeatEquationSolver
            Get
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub
#End Region

        Private _sourceEquationList As New HashSet(Of clsHeatEquation)
        Private _destinationEquation As clsChemicalEquation

        Public Sub clearSourceEquationList()
            _sourceEquationList.Clear()
        End Sub

        Public Sub addEquationToSourceList(ByVal equation As clsHeatEquation)
            Debug.Print("Source: " & equation.strEquation)
            _sourceEquationList.Add(equation)
        End Sub

        Public Sub setDestinationEquation(ByVal equation As clsChemicalEquation)
            Debug.Print("Destination: " & equation.strEquation)
            _destinationEquation = equation
        End Sub

        Public Function solve() As clsHeatEquation
            Dim _formulaList As New List(Of String)
            Dim _formulaMissingList As New List(Of String)
            Dim _matrix(,) As clsFraction
            Dim n As Integer, m As Integer

            For Each formula As clsChemicalFormula In _destinationEquation.leftList
                _formulaList.Add(formula.strFormulaWithoutFactor)
            Next
            For Each formula As clsChemicalFormula In _destinationEquation.rightList
                _formulaList.Add(formula.strFormulaWithoutFactor)
            Next

            m = _sourceEquationList.Count
            For Each heatEquation As clsHeatEquation In _sourceEquationList
                For Each formula As clsChemicalFormula In heatEquation.chemicalEquation.leftList
                    If Not _formulaList.Contains(formula.strFormulaWithoutFactor) Then
                        _formulaMissingList.Add(formula.strFormulaWithoutFactor)
                    End If
                Next
                For Each formula As clsChemicalFormula In heatEquation.chemicalEquation.rightList
                    If Not _formulaList.Contains(formula.strFormulaWithoutFactor) Then
                        _formulaMissingList.Add(formula.strFormulaWithoutFactor)
                    End If
                Next
            Next
            n = _formulaMissingList.Count
            ReDim _matrix(n + 1, m + 1)

            Dim iPos As Integer, jPos As Integer
            For Each missingFormula As String In _formulaMissingList
                iPos += 1
                jPos = 0
                For Each heatEquation As clsHeatEquation In _sourceEquationList
                    jPos += 1
                    For Each formula As clsChemicalFormula In heatEquation.chemicalEquation.leftList
                        If (formula.strFormulaWithoutFactor = missingFormula) Then
                            _matrix(iPos, jPos) = New clsFraction(formula.factor)
                        End If
                    Next
                    For Each formula As clsChemicalFormula In heatEquation.chemicalEquation.rightList
                        If (formula.strFormulaWithoutFactor = missingFormula) Then
                            _matrix(iPos, jPos) = New clsFraction(-formula.factor)
                        End If
                    Next
                Next
            Next

            _matrix(n + 1, 1) = New clsFraction(1)
            _matrix(n + 1, m + 1) = New clsFraction(1)

            For i As Integer = 1 To n + 1
                For j As Integer = 1 To m + 1
                    If (_matrix(i, j) Is Nothing) Then
                        _matrix(i, j) = New clsFraction
                    End If
                Next
            Next

            Dim ret(0) As clsFraction
            Dim result(0) As Integer, retDeltaHeat As Double, finalFactor(_formulaList.Count) As Integer
            If (clsGaussJordanElimination.gaussJordanElimination(_matrix, ret)) Then
                result = clsFraction.simplify(ret)
                iPos = 0
                For Each heatEquation As clsHeatEquation In _sourceEquationList
                    iPos += 1
                    retDeltaHeat += result(iPos) * heatEquation.deltaHeat
                Next

                iPos = 0
                For Each dstFormula As String In _formulaList
                    iPos += 1
                    jPos = 0
                    For Each heatEquation As clsHeatEquation In _sourceEquationList
                        jPos += 1
                        For Each formula As clsChemicalFormula In heatEquation.chemicalEquation.leftList
                            If (formula.strFormulaWithoutFactor = dstFormula) Then
                                finalFactor(iPos) += formula.factor * result(jPos)
                            End If
                        Next
                        For Each formula As clsChemicalFormula In heatEquation.chemicalEquation.rightList
                            If (formula.strFormulaWithoutFactor = dstFormula) Then
                                finalFactor(iPos) -= formula.factor * result(jPos)
                            End If
                        Next
                    Next
                Next

                If (finalFactor(1) < 0) Then
                    retDeltaHeat = -retDeltaHeat
                    For i As Integer = 1 To _formulaList.Count
                        finalFactor(i) = -finalFactor(i)
                    Next
                End If

                Dim retLeftList As List(Of clsChemicalFormula) = _destinationEquation.leftList
                Dim retRightList As List(Of clsChemicalFormula) = _destinationEquation.rightList
                iPos = 0
                For Each formula As clsChemicalFormula In retLeftList
                    iPos += 1
                    formula.factor = finalFactor(iPos)
                Next
                For Each formula As clsChemicalFormula In retRightList
                    iPos += 1
                    formula.factor = -finalFactor(iPos)
                Next

                Dim retEquation As New clsHeatEquation(New clsChemicalEquation(retLeftList, retRightList, True), retDeltaHeat)
                retEquation.simplify()

                Return retEquation
            Else
                Throw New Exception("Information not enough, solve equation " + _destinationEquation.strEquation + " failed.")
            End If
        End Function
    End Class
End Namespace