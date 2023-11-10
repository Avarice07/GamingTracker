using ConsoleTableExt;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GamingTracker
{
    internal static class CodingController
    {

        public static void CreateTable() 
        {
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"])) 
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

        public static void Insert()
        {
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"INSERT INTO game_session (Id, Start, End, Duration)
                  VALUES (@param1, @param2, @param3, @param4)
                     )";

                //command.Parameters.AddWithValue("@param1", Name);
                //command.Parameters.AddWithValue("@param2", Name);
                //command.Parameters.AddWithValue("@param3", Name);
                //command.Parameters.AddWithValue("@param4", Name);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static void Update()
        {
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"UPDATE gaming_session SET Start=@param2, End=@param3, Duration=@param4 WHERE Id=@param1)";

                //command.Parameters.AddWithValue("@param1", Name);
                //command.Parameters.AddWithValue("@param2", Name);
                //command.Parameters.AddWithValue("@param3", Name);
                //command.Parameters.AddWithValue("@param4", Name);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static void Delete()
        {
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"DELETE FROM game_session
                  WHERE Id=@param1";

                //command.Parameters.AddWithValue("@param1", Name);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static void View()
        {
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                List<GamingSession> tableData = new();
                var command = connection.CreateCommand();
                command.CommandText =
                @"SELECT * FROM game_session";
                SqliteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(
                            new GamingSession
                            {
                                Id = reader.GetInt32(0),
                                StartTime = DateTime.Parse(reader.GetString(1)),
                                EndTime = DateTime.Parse(reader.GetString(2)),
                                Duration = TimeSpan.Parse(reader.GetString(3))

                            });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                ConsoleTableBuilder
                .From(tableData)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);
            }
        }
        }


    }

