using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingTracker
{
    internal static class Validation
    {
        public static DateTime IsValidDate(string value)
        {
            
            while (!DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture,DateTimeStyles.None,out _))
            {
                Console.WriteLine("The format should be yyyy-MM-dd HH:mm ex. 1995-08-07 22:10");
                Console.Write("Please enter the proper date and time format: ");
                value = Console.ReadLine().Trim();
            }
            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture);
        }

        public static int IsValidInt(string value)
        {
            while (!int.TryParse(value, out _))
            {
                Console.Write("Please enter a number from 1-4: ");
                value = Console.ReadLine().Trim();
            }
            return int.Parse(value);
        }
    }
}
