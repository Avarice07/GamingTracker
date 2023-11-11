using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTracker
{
    internal static class UserInput
    {
        public static void GetInput() {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("What do you want to do???");
                Console.WriteLine("Type 0 to Quit");
                Console.WriteLine("Type 1 to View all gaming sessions");
                Console.WriteLine("Type 2 to Insert session");
                Console.WriteLine("Type 3 to Modify session");
                Console.WriteLine("Type 4 to Delete session");

                int key = Validation.IsValidInt(Console.ReadLine());
                Console.Clear();

                switch (key)
                {
                    case 0:
                        Console.WriteLine("Thank you for useing the app");
                        Environment.Exit(0);
                        break;
                    case 1:
                        CodingController.View();
                        break;
                    case 2:
                        CodingController.Insert();
                        break;
                    case 3:
                        CodingController.Update();
                        break;
                    case 4:
                        CodingController.Delete();
                        break;

                }
                Console.WriteLine("Please press any key to return to the main menu");
                Console.ReadKey();
                Console.Clear();


            }



        }
    
    }
}
