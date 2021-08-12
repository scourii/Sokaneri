using System;
using Npgsql;

namespace Sakuri
{
    class Program
    {
        static void Main(string[] args)
        {
            var ConnectionString = "Host=localhost;Username=postgres;Password=s$cret;Database=Sakuri.db";
            using var Connection = new NpgsqlConnection(ConnectionString);

            var SQL = "SELECT version();";

            using var cmd = new NpgsqlCommand(SQL, Connection);

            var Version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"Postgres version: {Version}");

        }
    }
}
