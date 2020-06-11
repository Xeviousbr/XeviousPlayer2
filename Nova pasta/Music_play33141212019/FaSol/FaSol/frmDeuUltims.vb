Public Class frmDeuUltims

    Private Sub frmDeuUltims_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        ListBox1.Items.Clear()
        For i = 0 To 9
            ListBox1.Items.Add(DeuUltims(i))
        Next
    End Sub
End Class