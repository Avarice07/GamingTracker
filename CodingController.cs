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
            Console.WriteLine("What time will you start?? ex. 1995-08-07 24:22");
            var start = Validation.IsValidDate(Console.ReadLine().Trim());
            Console.WriteLine("What time will you end?? ex. 1995-08-07 24:22");
            var end = Validation.IsValidDate(Console.ReadLine().Trim());

            var session = new GamingSession(start, end); 


            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"INSERT INTO game_session(Start, End, Duration)
                  VALUES(@param1, @param2, @param3)";

                command.Parameters.AddWithValue("@param1", session.StartTime);
                command.Parameters.AddWithValue("@param2", session.EndTime);
                command.Parameters.AddWithValue("@param3", session.Duration);
                _ = command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public static void Update()
        {
            Console.WriteLine("What is the ID of the session you want to update??");
            int Id = Validation.IsValidInt(Console.ReadLine().Trim());
            Console.WriteLine("What is the new start time?? ex. 1995-08-07 24:22");
            var start = Validation.IsValidDate(Console.ReadLine().Trim());
            Console.WriteLine("What is the new end time?? ex. 1995-08-07 24:22");
            var end = Validation.IsValidDate(Console.ReadLine().Trim());

            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE game_session 
                                      SET Start=@param1, End=@param2
                                      WHERE Id=@param3";


                command.Parameters.AddWithValue("@param1", start);
                command.Parameters.AddWithValue("@param2", end);
                //command.Parameters.AddWithValue("@param3", start.Subtract(end));
                command.Parameters.AddWithValue("@param3", Id);
                _ = command.ExecuteNonQuery();
                connection.Close();


            }
        }

            public static void Delete()
        {
            Console.WriteLine("What is the ID of the session you want to delete??");
            int Id = Validation.IsValidInt(Console.ReadLine().Trim());
            
            using (var connection = new SqliteConnection(ConfigurationManager.AppSettings["Key0"]))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"DELETE FROM game_session
                  WHERE Id=@param1";

                command.Parameters.AddWithValue("@param1", Id);
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

