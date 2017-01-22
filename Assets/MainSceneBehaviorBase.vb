Imports UnityEngine
Imports UnityEngine.UI

Public Class MainSceneBehaviorBase
    Inherits MonoBehaviour

    Dim calc As New AnalysisHelper.ExpressionCalculator
    Dim justEvaled As Boolean
    Dim justFaulted As Boolean

    Public TblValue As Text

    Private Sub Start()
        Debug.Log($"提示：游戏对象 {gameObject.name} 是用 Visual Basic 2017 写的！")
    End Sub

    Private Sub AppendChar(ch As Char)
        Dim txt = TblValue.text
        If justFaulted Then
            TblValue.text = String.Empty
            justEvaled = True
        End If
        If justEvaled Then
            If Char.IsDigit(ch) Then
                TblValue.text = ch
            ElseIf ch = "."c Then
                TblValue.text = "0."
            Else
                TblValue.text += ch
            End If
        Else
            If txt = "0" AndAlso ch <> "." Then
                TblValue.text = ch
            Else
                TblValue.text += ch
            End If
        End If
        justEvaled = False
        justFaulted = False
    End Sub

    Public Sub BtnAdd_Click()
        AppendChar("+"c)
    End Sub

    Public Sub BtnMinus_Click()
        AppendChar("-"c)
    End Sub

    Public Sub BtnMultiply_Click()
        AppendChar("*"c)
    End Sub

    Public Sub BtnDivide_Click()
        AppendChar("/"c)
    End Sub

    Public Sub BtnDot_Click()
        AppendChar("."c)
    End Sub

    Public Sub Btn0_Click()
        AppendChar("0"c)
    End Sub

    Public Sub Btn1_Click()
        AppendChar("1"c)
    End Sub

    Public Sub Btn2_Click()
        AppendChar("2"c)
    End Sub

    Public Sub Btn3_Click()
        AppendChar("3"c)
    End Sub

    Public Sub Btn4_Click()
        AppendChar("4"c)
    End Sub

    Public Sub Btn5_Click()
        AppendChar("5"c)
    End Sub

    Public Sub Btn6_Click()
        AppendChar("6"c)
    End Sub

    Public Sub Btn7_Click()
        AppendChar("7"c)
    End Sub

    Public Sub Btn8_Click()
        AppendChar("8"c)
    End Sub

    Public Sub Btn9_Click()
        AppendChar("9"c)
    End Sub

    Public Sub BtnCalculate_Click()
        Try
            TblValue.text = calc.Eval(TblValue.text).ToString("#.######")
            justFaulted = False
        Catch ex As Exception
            TblValue.text = ex.Message
            justFaulted = True
        End Try
        justEvaled = True
    End Sub

    Public Sub BtnRightDiv_Click()
        AppendChar("\"c)
    End Sub

    Public Sub BtnLeftParenthesis_Click()
        AppendChar("("c)
    End Sub

    Public Sub BtnRightParenthesis_Click()
        AppendChar(")"c)
    End Sub

    Public Sub BtnPow_Click()
        AppendChar("^"c)
    End Sub

    Public Sub BtnBackspace_Click()
        If TblValue.text.Length > 1 Then
            TblValue.text = TblValue.text.Substring(0, TblValue.text.Length - 1)
        Else
            TblValue.text = "0"
        End If
        justEvaled = False
        justFaulted = False
    End Sub

    Public Sub BtnClear_Click()
        TblValue.text = "0"
        justEvaled = False
        justFaulted = False
    End Sub
End Class
