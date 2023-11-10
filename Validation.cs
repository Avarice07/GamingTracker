﻿using System;
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
            DateTime d2;
            while (DateTime.TryParse(value, out d2))
            {
                Console.WriteLine("The format should be yyyy-MM-dd HH:mm ex. 1995-08-07 24:22");
                Console.Write("Please enter the proper date and time format: ");
                value = value.Trim();
            }
            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture);
        }

        public static int IsValidInt(string value)
        {
            while (true)
            {
                try
                {
                   return int.Parse(value);
                }
                catch (Exception e)
                {
                    Console.Write("Please enter the proper command: ");
                    value = Console.ReadLine().Trim();
                } 
                
    
            }
            return 0;
        }

    }
}
