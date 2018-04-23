using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Recognize flag at startup (-server)
            if (args.Contains("-server"))
            {

                Console.WriteLine("Running as server....");

            }
            else
            {

                Console.WriteLine("Running as client");

            }




            //Recognize when a specific key is pressed


            //Read or take in input

            while (true) {  //while true is an endless loop

                //Check for messages
                Console.WriteLine("Checking For Messages...");

                if (Console.KeyAvailable) { //KeyAvailable is what checks for if a key is pressed but is not a blocker

                    //Check for key presses
                    ConsoleKeyInfo pressedKey = Console.ReadKey();

                    if (pressedKey.Key == ConsoleKey.I)
                    {
                        Console.WriteLine("You Pressed The I Key");

                        break;
                    }
                    else
                    {
                        Console.WriteLine("The I Key ''Twas Not Pressed");
                    }

                    
                }



                Thread.Sleep(250);

            }


            string message = Console.ReadLine(); //Blocking Call


            //Display output

            if(message == "whats it like to live in country side?")
            {
                Console.WriteLine("It's Great!");
            }
            else { 

            Console.WriteLine("WHATS IT LIKE TO LIVE IN COUNTRYSIDE!!!!!!!");

            Console.WriteLine("Here is your original message {0}", message);
            }

            Console.ReadKey();



            

            //Keep the window open
            Console.ReadKey();

        }
    }
}
