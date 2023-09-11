Imports System.Data.SQLite

Module Program

    Private Const DatabaseFileName As String = "mydatabase.db"

    Sub Main(args As String())
        LoadDataIntoArray()
    End Sub

    Sub LoadDataIntoArray()
        ' Set the connection string
        Dim connectionString As String = $"Data Source={DatabaseFileName};Version=3;"

        ' Set up the SQL query
        Dim query As String = "SELECT Name FROM Users"

        ' Create a list to store names retrieved from the database
        Dim names As New List(Of String)()

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()

            Using cmd As New SQLiteCommand(query, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    ' Add all the names from the database to the list
                    While reader.Read()
                        names.Add(reader("Name").ToString())
                    End While

                End Using

            End Using
        End Using

        ' So far the 'names' list has been populated with usernames from the database.
        ' You can convert this list to an array if you want:
        Dim namesArray() As String = names.ToArray()

        ' Print array content for testing purposes
        For Each name In namesArray
            Console.WriteLine(name)
        Next
    End Sub

End Module
