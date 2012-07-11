
Imports HelloChemistry.algorithm
Imports HelloChemistry.chemicalFormula
Imports HelloChemistry.fraction
Imports HelloChemistry.chemicalFormula.parser

Namespace chemicalEquation.parser
    Public Class clsChemicalEquationBalancer

        Private Shared ReadOnly _instance As New clsChemicalEquationBalancer

        Public Shared ReadOnly Property instance As clsChemicalEquationBalancer
            Get
                Return _instance
            End Get
        End Property

        Public Function balance(ByVal equation As clsChemicalEquation) As clsChemicalEquation
            Dim elementTotal As New clsElementList
            Dim matrix(,) As clsFraction
            Dim pointer1 As Integer, pointer2 As Integer

            ' Count element
            For Each f As clsChemicalFormula In equation.leftList
                elementTotal.merge(f.element)
            Next

            For Each f As clsChemicalFormula In equation.rightList
                elementTotal.merge(f.element)
            Next

            ReDim matrix(elementTotal.elementTable.Count + 2, equation.leftList.Count + equation.rightList.Count + 1)

            ' Create matrix for all chemical formulas
            For Each ele As String In elementTotal.elementTable.Keys

                pointer1 += 1
                pointer2 = 0

                For Each f As clsChemicalFormula In equation.leftList
                    pointer2 += 1
                    If (f.element.elementTable.Contains(ele)) Then
                        matrix(pointer1, pointer2) = New clsFraction(f.element.elementTable.Item(ele))
                    End If
                Next

                For Each f As clsChemicalFormula In equation.rightList
                    pointer2 += 1
                    If (f.element.elementTable.Contains(ele)) Then
                        matrix(pointer1, pointer2) = New clsFraction(-f.element.elementTable.Item(ele))
                    End If
                Next
            Next

            ' Create matrix for electron
            pointer1 += 1
            pointer2 = 0

            For Each f As clsChemicalFormula In equation.leftList
                pointer2 += 1
                matrix(pointer1, pointer2) = New clsFraction(f.electron)
            Next

            For Each f As clsChemicalFormula In equation.rightList
                pointer2 += 1
                matrix(pointer1, pointer2) = New clsFraction(-f.electron)
            Next

            ' We assume that the factor of the first chemical formula is 1
            matrix(pointer1 + 1, 1) = New clsFraction(1)
            matrix(pointer1 + 1, pointer2 + 1) = New clsFraction(1)

            ' Fill empty fractions as 0
            For i As Integer = 1 To pointer1 + 1
                For j As Integer = 1 To pointer2 + 1
                    If (matrix(i, j) Is Nothing) Then
                        matrix(i, j) = New clsFraction
                    End If
                Next
            Next

            ' Solve the equations
            Dim solve(0) As clsFraction, result(0) As Integer
            Dim retStr As String = vbNullString
            Dim retEquationLeftList As New List(Of clsChemicalFormula)
            Dim retEquationRightList As New List(Of clsChemicalFormula)

            If (clsGaussJordanElimination.gaussJordanElimination(matrix, solve)) Then
                result = clsFraction.simple(solve)

                ' Reform the expression
                pointer1 = 0
                For Each f As clsChemicalFormula In equation.leftList
                    pointer1 += 1
                    retStr &= IIf(result(pointer1) = 1, "", result(pointer1).ToString) & f.strChemicalFormula & " + "
                    f.factor = result(pointer1)
                    retEquationLeftList.Add(f)
                Next
                retStr = Left(retStr, retStr.Length - 3) & " = "
                For Each f As clsChemicalFormula In equation.rightList
                    pointer1 += 1
                    retStr &= IIf(result(pointer1) = 1, "", result(pointer1).ToString) & f.strChemicalFormula & " + "
                    f.factor = result(pointer1)
                    retEquationRightList.Add(f)
                Next
                retStr = Left(retStr, retStr.Length - 3)

                Debug.Print("Balanced equation: " & retStr)
                Return New clsChemicalEquation(retEquationLeftList,
                                               retEquationRightList,
                                               retStr,
                                               True)
            Else
                Throw New Exception("Information not enough, balance equation " + equation.strChemicalEquation + "failed.")
            End If

        End Function

        Private Sub New()
        End Sub
    End Class
End Namespace