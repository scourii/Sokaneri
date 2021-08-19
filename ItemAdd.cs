using System;
using Npgsql;

namespace Sakuri
{
    public class ItemAdd
    {
        public void AddItems(string ItemName, int ItemPrice)
        {
            var ConnectionString = "Host=localhost;Username=scouri;Password=PASSWORD;";
            using var Connection = new NpgsqlConnection(ConnectionString);
        }
    }
}
