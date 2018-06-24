using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServiceProvider.Data
{
    public class Connection
    {
        static SQLiteConnection conn;
        public static SQLiteConnection getInstance()
            {
                if (conn == null)
                {
                 conn = new SQLiteConnection("Data Source=|DataDirectory|\\ServiceDb.db;Version=3;");
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "CREATE TABLE \"Services\" (\"Id\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,\"ServiceName\"  TEXT NOT NULL,\"ServiceType\"  TEXT NOT NULL,\"City\"  TEXT NOT NULL,\"Country\"  TEXT NOT NULL);";
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS \"Services\" (\"Id\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,\"ServiceName\"  TEXT NOT NULL,\"ServiceType\"  TEXT NOT NULL,\"City\"  TEXT NOT NULL,\"Country\"  TEXT NOT NULL);";
            }
                return conn;
            }
    }
}