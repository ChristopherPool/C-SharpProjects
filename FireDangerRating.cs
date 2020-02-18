using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Title: Fire Danger Rating
 * Description: Console Application that reads the Fire Danger Rating (integer input) and then displays 
 * the Fire Danger Category as a message with the corresponding colour and text which is done using case statements. 
 */

namespace FireDangerRating
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Press q to quit");

            bool quitApp = false;
            while (!quitApp)
            {
                

                int fireLevel;
                bool keyBoardInput;


                    Console.Write("Enter the fire level: ");
                keyBoardInput = int.TryParse(Console.ReadLine(), out fireLevel);


                    switch (fireLevel)
                {
                    case 1:
                        Console.WriteLine("Green : Low-Moderate");
                        break;

                    case 2:
                        Console.WriteLine("Blue : High");
                        break;

                    case 3:
                        Console.WriteLine("Yellow : Very High");
                        break;

                    case 4:
                        Console.WriteLine("Orange : Severe");
                        break;

                    case 5:
                        Console.WriteLine("Pink : Extreme");
                        break;

                    case 6:
                        Console.WriteLine("Red-Black : Catastrophic");
                        break;


                    default:
                        Console.WriteLine("That value does not compute!");
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
