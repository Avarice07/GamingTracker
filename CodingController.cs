using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTracker
{
    internal static class CodingController
    {
        public static void CreateTable() 
        {
            using (var connection = new SqliteConnection("Data Source=game-Session.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"CREATE TABLE IF NOT EXISTS game_session(
                     Id INTEGER PRIMARY KEY AUTOINCREMENT,
                     Start TEXT,
                     End TEXT,
                     Duration TEXT
                     )";
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
        
    }
}
