
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;

namespace GamingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = ConfigurationManager.AppSettings["Key0"];
            DateTime date1 = new DateTime(2023, 11, 7, 22, 30, 50);
            Console.WriteLine(DateTime.Now.Subtract(date1) + " " + name);

            CodingController.CreateTable();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("***WELCOME TO GAMING TRACKER***");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
            Console.Clear();
            
        }
    }
}