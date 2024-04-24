Imports System.Data.SQLite

Module Program

    Private Const DatabaseFileName As String = "mydatabase.db"

    Sub Main(args As String())
        InsertData("John Doe", "USA")
    End Sub

    Sub InsertData(userName As String, userCountry As String)
        ' Set the connection string
        Dim connectionString As String = $"Data Source={DatabaseFileName};Version=3;"

        ' Set up parameterized SQL query
        ' -----------------------------------------------------------------------------
        ' Security Note: Never concatenate (or join) a string into a SQL statement.
        ' Always use parameterized queries to prevent SQL Injection attacks.
        ' -----------------------------------------------------------------------------
        Dim query As String = "INSERT INTO Users (Name, Country) VALUES (@Name, @Country)"

        Using conn As New SQLiteConnection(connectionString)
            conn.Open()

            Using cmd As New SQLiteCommand(query, conn)
                ' Set parameters
                cmd.Parameters.AddWithValue("@Name", userName)
                cmd.Parameters.AddWithValue("@Country", userCountry)

                ' Run the query
                cmd.ExecuteNonQuery()
            End Using
        End Using

        Console.WriteLine($"User {userName} from {userCountry} added successfully!")
    End Sub

End Module
