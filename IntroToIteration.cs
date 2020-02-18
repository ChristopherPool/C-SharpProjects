using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Title: Program3
 * Description: Console Application that will display all the numbers from 19 down to 7 inclusively. 
 * After each iteration (loop) the program will display the number.
 */

namespace IntrotoIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring the variables, giving variables values.
            bool sentinel = true;
            int counter = 19;
            int minValue = 7;

            // while statement executes because the sentinel variable is true
            while (sentinel)
            {
                // if counter variable larger than minValue variable, performs the Console.WriteLine function
                if (counter > minValue)
                    Console.WriteLine(counter);
                else
                    // if sentinel set to false counter decrements by 1
                    sentinel = false;
                counter--;
            }
            Console.ReadLine();
        }
    }
}
