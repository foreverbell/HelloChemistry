
Imports HelloChemistry.fraction
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalEquation.parser
Imports HelloChemistry.chemicalFormula.parser
Imports HelloChemistry.algorithm

Namespace chemicalEquation
    Public Class clsChemicalEquation

        Dim _parser As New clsChemicalEquation1
        Dim _equation As String

        Public Function balance() As Boolean
            Dim _elementTotal As New clsElementList
            Dim matrix(,) As clsFraction
            Dim pointer1 As Integer, pointer2 As Integer

            For Each f As clsChemicalFormula In _parser.leftList
                _elementTotal.merge(f.element)
            Next

            For Each f As clsChemicalFormula In _parser.rightList
                _elementTotal.merge(f.element)
            Next

            ReDim matrix(_elementTotal.elementTable.Count + 1, _parser.leftList.Count + _parser.rightList.Count + 1)

            For Each ele As String In _elementTotal.elementTable.Keys

                pointer1 += 1
                pointer2 = 0

                For Each f As clsChemicalFormula In _parser.leftList
                    pointer2 += 1
                    If (f.element.elementTable.Contains(ele)) Then
                        matrix(pointer1, pointer2) = New clsFraction(f.element.elementTable.Item(ele))
                    End If
                Next

                For Each f As clsChemicalFormula In _parser.rightList
                    pointer2 += 1
                    If (f.element.elementTable.Contains(ele)) Then
                        matrix(pointer1, pointer2) = New clsFraction(-f.element.elementTable.Item(ele))
                    End If
                Next
            Next

            matrix(pointer1 + 1, 1) = New clsFraction(1)
            matrix(pointer1 + 1, pointer2 + 1) = New clsFraction(1)

            For i As Integer = 1 To pointer1 + 1
                For j As Integer = 1 To pointer2 + 1
                    If (matrix(i, j) Is Nothing) Then
                        matrix(i, j) = New clsFraction
                    End If
                Next
            Next

            Dim solve(0) As clsFraction, result(0) As Integer

            If (clsGaussJordanElimination.gaussJordanElimination(matrix, solve)) Then
                result = clsFraction.simple(solve)

                _equation = ""
                pointer1 = 0
                For Each f As clsChemicalFormula In _parser.leftList
                    pointer1 += 1
                    _equation &= result(pointer1).ToString & f.chemicalFormula & " + "
                Next
                _equation = Left(_equation, _equation.Length - 3) & " = "
                For Each f As clsChemicalFormula In _parser.rightList
                    pointer1 += 1
                    _equation &= result(pointer1).ToString & f.chemicalFormula & " + "
                Next
                _equation = Left(_equation, _equation.Length - 3)

                Debug.Print("Balanced equation: " & _equation)

                Return True
            Else
                Return False
            End If

        End Function

        Public Sub New(ByVal equation As String)
            Dim stream As clsFormulaTokenStream = New clsFormulaTokenStream(equation)

            Debug.Print("Equation: " & equation)
            _parser.parseFormula(stream)
        End Sub

    End Class
End Namespace