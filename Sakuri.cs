using System;
using Npgsql;
using System.Diagnostics;

namespace Sakuri
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var OutPut = "psql -lqt | cut -d \\| -f 1 | grep -qw SakuriDB".Bash();
            var ConnectionString = "Host=localhost;Username=scouri;Password=PASSWORD;";
            var Connection = new NpgsqlConnection(ConnectionString);
            var CreateDatabase = new NpgsqlCommand("CREATE DATABASE SakuriDB WITH OWNER=scouri ENCODING = 'UTF8'", Connection);
            Connection.Open();
            CreateDatabase.ExecuteNonQuery();
            Connection.Close();
            
            ConnectionString = "Server=localhost;User Id=scouri;Password=PASSWORD;Database=SakuriDB";
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
        public static string Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
            StartInfo = new ProcessStartInfo
            {
            FileName = "/bin/bash",
            Arguments = "",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }
    
}
