Imports System.Data.SQLite

Module DatabaseInitializer

    Sub InitializeDb()
        ' Designate a new database file named "mydatabase.db"
        Dim connectionString As String = "Data Source=mydatabase.db;Version=3;"
        Using conn As New SQLiteConnection(connectionString)
            conn.Open()

            ' Create Users table
            Dim createTableQuery As String = "CREATE TABLE IF NOT EXISTS Users (UserID INTEGER PRIMARY KEY, Name TEXT, Country TEXT)"
            Using cmd As New SQLiteCommand(createTableQuery, conn)
                cmd.ExecuteNonQuery()
            End Using

            ' Insert initial users
            Dim insertUsers As String = "INSERT INTO Users (Name, Country) VALUES (?, ?)"
            Using cmd As New SQLiteCommand(insertUsers, conn)
                cmd.Parameters.AddWithValue("Name", "Alice")
                cmd.Parameters.AddWithValue("Country", "USA")
                cmd.ExecuteNonQuery()

                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("Name", "Bob")
                cmd.Parameters.AddWithValue("Country", "UK")
                cmd.ExecuteNonQuery()

                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("Name", "Charlie")
                cmd.Parameters.AddWithValue("Country", "Canada")
                cmd.ExecuteNonQuery()

                cmd.Parameters.Clear()
            End Using

            Console.WriteLine("Database and initial data created successfully!")
        End Using
    End Sub

End Module