Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click

        Dim valor As String = String.Empty
        'irectory.GetFiles(@"C:\Ficheros").Count().ToString()
        For Each item In Directory.GetDirectories("c:\Windows")
            valor = item.ToString
            System.Console.WriteLine(valor)
        Next

        For Each item In Directory.GetFiles("c:\Windows")
            valor = item.ToString
            System.Console.WriteLine(valor)
        Next

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
