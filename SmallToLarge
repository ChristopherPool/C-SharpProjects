using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Title: Program1
 * Description: Console Application that reads from the console a series of three integers and displays the smallest and largest of them
 */

namespace SmallToLarge
{
    class Program
    {
        // Main Method
        static void Main(string[] args)
        {
            // Declaring the num integers variables
            int num1;
            int num2;
            int num3;

            // Declares the keyboard inputs that the user will put in
            bool keyBoardInput1;
            bool keyBoardInput2;
            bool keyBoardInput3;

            // Prints the Console.Write text then gets keyboard input from the user, stores the keyboard input as that integer.
            Console.Write("Enter the first number: ");
            keyBoardInput1 = int.TryParse(Console.ReadLine(), out num1);

            Console.Write("Enter the second number: ");
            keyBoardInput2 = int.TryParse(Console.ReadLine(), out num2);

            Console.Write("Enter the third number: ");
            keyBoardInput3 = int.TryParse(Console.ReadLine(), out num3);

            // Will run if the keyboard inputs are valid,  if proved true, performs a function
            if (keyBoardInput1 && keyBoardInput2 && keyBoardInput3)
            {
                // if this statement is proved true, performs the function of Console.Write if it's proved true
                if ((num1 > num2) && (num1 > num3))
                {
                    Console.Write(" The first number is the largest");
                    // If the num2 variable is larger than num3 variable it will output the text
                    if ((num2 > num3))
                    {
                        Console.Write(" The third number is the smallest");
                    }
                    // If the num2 variable is smaller than num3 it will output the text
                    else
                    {
                        Console.Write(" The second number is the smallest");
                    }
                }
                // If the num2 variable is larger than the num1 variable and the num2 variable is larger than the num3 variable it will perform this function
                if ((num2 > num1) && (num2 > num3))
                {
                    Console.Write(" The second number is the largest");
                    // If the num1 variable is larger than num3 will output the Console.Write text
                    if ((num1 > num3))
                    {
                        Console.Write(" The third number is the smallest");
                    }
                    // If not proved true will perform this Console.Write function
                    else
                    {
                        Console.Write(" The first number is the smallest");
                    }
                }
                // If the num3 variable is larger than the num1 variable and the num3 variable is larger than the num2 variable it will perform this function
                if ((num3 > num1) && (num3 > num2))
                {
                    Console.Write(" The third number is the largest");
                    // If the num1 variable is larger than the num2 variable it will output the Console.Write text
                    if ((num1 > num2))
                    {
                        Console.Write(" The second number is the smallest");
                    }
                    // If not proved true will perform this Console.Write function
                    else
                    {
                        Console.Write(" The first number is the smallest");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
