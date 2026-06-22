using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

class DatabaseTest
{
    public static void Test()
    {
        string connectionString =
            "Server=(localdb)\\MSSQLLocalDB;\r\nDatabase=ManagementSystemDB;\r\nTrusted_Connection=True;";

        using SqlConnection conn =
            new SqlConnection(connectionString);

        conn.Open();

        Console.WriteLine("Connected!");
    }
}