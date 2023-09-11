Imports System
Imports System.Data.SQLite

Module Program
    Sub Main(args As String())
        Dim connectionString As String = "Data Source=mydatabase.db;Version=3;"
        Try
            Using conn As New SQLiteConnection(connectionString)
                conn.Open()
                Console.WriteLine("Successfully connected to the database!")
                'You can perform database operations here.
            End Using
        Catch ex As SQLiteException
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub
End Module