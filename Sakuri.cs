using System;
using Npgsql;

namespace Sakuri
{
    public static class Program
    {
        static void Main(string[] args)
        {   
            if (args.Length == 0)
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

                    if (Exception.SqlState == "42P07")
                    {
                        Connection = new NpgsqlConnection(ConnectionString);

                        var ReadDatabase = new NpgsqlCommand("SELECT * FROM sakuridb");

                        Connection.Open();
                        ReadDatabase.ExecuteNonQuery();

                    }
                }
            }

        }
        
    }
    
}
