using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Title: Program4
 * Description: Console Application that will loop through a series of numbers and divide each one with a Divisor. \
 * If the division has no remainder then displays the value
 */

namespace IntegerDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring the divisor variable and the keyboard input variables to get input from user
            int divisor;
            int numLoops;
            bool keyBoardInput1;
            bool keyBoardInput2;

            // Display text and gets input from user from keyboard and stores it as the divisor variable
            Console.Write("Enter Divisor: ");
            keyBoardInput1 = int.TryParse(Console.ReadLine(), out divisor);

            // Display text and gets input from user from keyboard and stores it as the numLoops variable
            Console.Write("Enter Number: ");
            keyBoardInput2 = int.TryParse(Console.ReadLine(), out numLoops);

            int result;

            // if statement that executes if numLoops variable is greater to or equal to the divisor variable
            if (numLoops >= divisor)
               {
                //  loop through the numbers and divide each one with a Divisor. If the division has no remainder then it displays the value
                for (int x = 1; x < numLoops; x++)
                   {
                       result = x % divisor;
                       if (result == 0)
                       Console.WriteLine(x);

                   }
                Console.ReadLine();
               }

        }
    }
}
