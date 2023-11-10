
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Data.Sqlite;

namespace GamingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //CodingController.CreateTable();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("***WELCOME TO GAMING TRACKER***");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
            Console.Clear();

            UserInput.GetInput();
            
        }
    }
}