using System;
using Npgsql;
using System.Diagnostics;


namespace Sakuri
{
    public static class Program
    {
        static void Main(string[] args)
        {    
            var ConnectionString = "Host=localhost;Username=scouri;Password=PASSWORD;";
            var Connection = new NpgsqlConnection(ConnectionString);
            var CreateDatabase = new NpgsqlCommand("CREATE DATABASE sakuridb", Connection);
            try
            {
                Connection.Open();
                CreateDatabase.ExecuteNonQuery();
                Connection.Close();
            }
            catch (NpgsqlException Exception)
            {
                if (Exception.SqlState == "42P04")
                {
                    ConnectionString = "Host=localhost;Username=scouri;Password=PASSWORD;Database=sakuridb";
                    Connection = new NpgsqlConnection(ConnectionString);
                    CreateDatabase = new NpgsqlCommand("CREATE TABLE table1(ID CHAR(256) CONSTRAINT id PRIMARY KEY, Title CHAR)", Connection);
                    Connection.Open();
                    CreateDatabase.ExecuteNonQuery();
                    var SQL = "SELECT version();";

                    using var cmd = new NpgsqlCommand(SQL, Connection);

                    var Version = cmd.ExecuteScalar().ToString();

                    Console.WriteLine($"Postgres version: {Version}");

                    Connection.Close();
                }
            }
        }
        
    }
    
}
