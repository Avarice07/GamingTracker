
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
            DateTime date1 = new DateTime(2023, 11, 7, 22, 30 ,50); 
            Console.WriteLine(DateTime.Now.Subtract(date1)+" " +name);

            CodingController.CreateTable();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("***WELCOME TO GAMING TRACKER***");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("What do you want to do???");
                Console.WriteLine("Type 0 to Quit");
                Console.WriteLine("Type 1 to View all gaming sessions");
                Console.WriteLine("Type 2 to Insert session");
                Console.WriteLine("Type 3 to Modify session");
                Console.WriteLine("Type 4 to Delete session");

                int key = ConvertNum(Console.ReadLine());
                Console.Clear();

                switch (key)
                {
                    case 0:
                        Console.WriteLine("Thank you for useing the app");
                        Environment.Exit(0);
                        break;
                    case 1:
                        View();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;

                }
                Console.WriteLine("Please press any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();


            }
    }
}