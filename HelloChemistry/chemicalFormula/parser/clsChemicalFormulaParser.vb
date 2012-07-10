﻿
Imports HelloChemistry.formulaToken
Imports HelloChemistry.chemicalFormula.parser.internal

Namespace chemicalFormula.parser

    Public Class clsChemicalFormulaParser

        Private Shared ReadOnly _instance As New clsChemicalFormulaParser

        Public Shared ReadOnly Property instance As clsChemicalFormulaParser
            Get
                Return _instance
            End Get
        End Property

        Public Function parse(ByVal stream As clsFormulaTokenStream) As clsChemicalFormula
            Dim _parser As New clsChemicalFormula1
            Dim startPos As Integer = stream.position

            _parser.parseFormula(stream)

            Dim chemicalFormula As String = Mid(stream.formula, startPos + 1, stream.position - startPos)

            Return New clsChemicalFormula(_parser._element.mass, _parser._electron, chemicalFormula, _parser._element)
        End Function

        Public Function parse(ByVal formula As String) As clsChemicalFormula
            Return parse(New clsFormulaTokenStream(formula))
        End Function
    End Class
End Namespace