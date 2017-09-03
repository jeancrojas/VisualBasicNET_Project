Imports System.Data.SqlClient
Imports Microsoft.Office.Interop




Module Module1
    Sub Convertir(ByVal archivoOrigen As String)

        Dim excelFileName As String = "C:\tmp\ficheSalida.xlsx"

        Dim ExcelApp = New Excel.Application
        Dim libro = ExcelApp.Workbooks.Open(Filename:=archivoOrigen, Format:=6, Delimiter:=";")


        'libro.Sheets(1).Cells(1, 1) = "Hola mundo"
        ExcelApp.Visible = False
        ExcelApp.DisplayAlerts = False

        'Dim destinationRange As Excel.Range = ExcelApp.Range("A5")
        ExcelApp.DefaultSheetDirection = Excel.XlDirection.xlToRight
        ExcelApp.Range("A1:A17").TextToColumns(Destination:=ExcelApp.Range("A1"),
                                               DataType:=Excel.XlTextParsingType.xlDelimited,
                                               TextQualifier:=Excel.XlTextQualifier.xlTextQualifierDoubleQuote,
                                               ConsecutiveDelimiter:=False,
                                               Tab:=False,
                                               Semicolon:=True,
                                               Comma:=False,
                                               Space:=False,
                                               Other:=False,
                                               TrailingMinusNumbers:=True)

        ExcelApp.Range("J2:J17").NumberFormat = "m/d/yyyy"
        ExcelApp.Range("K2:K17").NumberFormat = "m/d/yyyy"
        ExcelApp.Range("L2:L17").NumberFormat = "m/d/yyyy"
        ExcelApp.Range("M2:M17").NumberFormat = "m/d/yyyy"


        ExcelApp.Range("A:BH").Columns.EntireColumn.AutoFit()

        'Columns("I:I").EntireColumn.AutoFit

        libro.SaveAs(Filename:=excelFileName, FileFormat:=Excel.XlFileFormat.xlOpenXMLWorkbook, CreateBackup:=False)
        libro.Close()
        ExcelApp.Quit()
        libro = Nothing
        ExcelApp = Nothing


    End Sub
    Public Function conectarBBDD() As SqlClient.SqlConnection
        Try
            Dim conn As New SqlClient.SqlConnection

            conn.ConnectionString = "Data Source=W7-X64-P1\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True"
            conn.Open()

            Return conn
        Catch exc As Exception
            Throw exc
        End Try
    End Function

    Public Function realizarConsultaBBDD() As DataTable

        'realizamos la consulta sql
        Dim conn As SqlClient.SqlConnection = conectarBBDD()
        Dim sql As String = "select * from Paises"
        Dim sqlSp As New SqlClient.SqlCommand
        Dim sqlAdapter As New SqlClient.SqlDataAdapter
        Dim datatable As New DataTable()

        sqlSp = New SqlCommand(sql, conn)
        sqlSp.CommandTimeout = 4000

        'inicializando el sqladapter
        sqlAdapter = New SqlClient.SqlDataAdapter(sqlSp)
        sqlAdapter.Fill(datatable)

        Return datatable
    End Function

    Public Sub mostrarResultadoBBDDToExcel()
        Dim tbpaises As DataTable = realizarConsultaBBDD()
        Dim excelFileName As String = "C:\tmp\salidaPaises.xlsx"

        Dim ExcelApp = New Excel.Application
        Dim libro = ExcelApp.Workbooks.Add

        ExcelApp.Visible = False
        ExcelApp.DisplayAlerts = False
        Dim numCelda As Integer = 2


        Dim idPaisColumnaPaises As String = "IdPais"
        Dim codigoColumnaPaises As String = "Codigo"
        Dim nombreColumnaPaises As String = "Nombre"

        ExcelApp.Range("A1").FormulaR1C1 = nombreColumnaPaises

        For Each row As DataRow In tbpaises.Rows
            Dim strrow As String = String.Format("{0}", row(nombreColumnaPaises))
            ExcelApp.Range("A" & numCelda).FormulaR1C1 = strrow
            numCelda = numCelda + 1
        Next
        'Console.ReadKey()

        'Range("A2").Select
        'ActiveCell.FormulaR1C1 = "2"

        ExcelApp.Range("A:A").Columns.EntireColumn.AutoFit()

        libro.SaveAs(Filename:=excelFileName, FileFormat:=Excel.XlFileFormat.xlOpenXMLWorkbook, CreateBackup:=False)
        libro.Close()
        ExcelApp.Quit()
        libro = Nothing
        ExcelApp = Nothing

    End Sub

    Sub Main()
        Dim archivoOrigen As String = "C:\tmp\ArchivoCSV.csv"
        'Convertir(archivoOrigen)
        mostrarResultadoBBDDToExcel()

        'Console.WriteLine("Mensaje de prueba")
        'Console.ReadLine()

    End Sub

End Module
