using System;
using Microsoft.Data.Sqlite;

namespace sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "hello.db";
            using (var conn = new SqliteConnection($"Data Source={name}")) 
            {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            CREATE TABLE users (
                id INTEGER PRIMARY KEY,
                login TEXT UNIQUE NOT NULL,
                emial TEXT UNIQUE NOT NULL,
                password TEXT NOT NULL
            );";
            using var reader = cmd.ExecuteReader();
            }
        }
    }
}
