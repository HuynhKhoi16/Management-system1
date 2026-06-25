using System;
using System.Collections.Generic;
using System.Text;

namespace Management_system1
{
    public class InputHelper
    {
        public static int GetInt(string prompt)
        {
            int val;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out val) && val > 0) return val;
                Console.WriteLine("\nError: Input invalid. It's must be an interger and larger than 0.\n");
            }
        }

        public static string GetString(string prompt)
        {
            while (true)
            {
                string val = Console.ReadLine();
                Console.WriteLine(prompt);
                if (string.IsNullOrEmpty(val)) return val;
                Console.WriteLine("\nError: The input cannot be null.\n");

            }
        }

        public static string GetCW(string prompt)
        {
            
            while (true)
            {
                Console.Write(prompt);
                string id = Console.ReadLine();
                if (id.Length != 6 && string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("\nError: Invalid Id length, must have 6 characters start with CW and then 4 numbers.\n");
                    continue;
                }
                int check;
                if (id.Substring(0, 2) != "CW" || !int.TryParse(id.Substring(2), out check))
                {
                    Console.WriteLine("\nError: Invalid ID, must start with CW and then 4 numbers.\n");
                    continue;
                }
                return id;
            }
            
        }



        public static string GetGS(string prompt)
        {

            while (true)
            {
                Console.Write(prompt);
                string id = Console.ReadLine();
                if (id.Length != 6 && string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Invalid Id length, must have 6 characters start with GS and then 4 numbers.");
                    continue;
                }
                int check;
                if (id.Substring(0, 2) != "GS" || !int.TryParse(id.Substring(2), out check))
                {
                    Console.WriteLine("Invalid ID, must start with GS and then 4 numbers.");
                    continue;
                }
                return id;
            }

        }

        public static double GetRating(string prompt)
        {
            double rating;
            while (true)
            {
                Console.Write(prompt);
                if(double.TryParse(Console.ReadLine(), out rating) && rating > 0 && rating < 5) return Math.Round(rating,1);
                Console.WriteLine("\nError:invalid input, The value must be a decimal between 0 and 5.\n");
            }
        }
    }
}
