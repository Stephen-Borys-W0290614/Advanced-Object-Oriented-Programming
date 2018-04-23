using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppToPushToGitHub
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello from the other side!");

            Console.WriteLine("I must have called a thousand times!");

            Console.WriteLine("Haha get it! Like the song by that Adele lady!");

            //Console.ReadKey();

           // int x = 100;

           // if (x == 100)
           // {
            //    Console.WriteLine("Bada Boom");

            //}
          //  else if (x == 150)
           // {
           //     Console.WriteLine("Bada Boom2");
//
           // }

            //else
            //{
            //    Console.WriteLine("Bada Boom3");

            //}

            //Console.ReadKey();

            ConsoleKeyInfo myFavouriteKey = Console.ReadKey(true);

            Console.WriteLine("My fav key is " + myFavouriteKey.Key);

            Console.ReadKey();


            //Console.ReadLine();

        }
    }
}
