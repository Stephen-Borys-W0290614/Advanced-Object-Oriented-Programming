using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatLib;

namespace ChatConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //Check if in server mode or not

            if (args.Contains("-server"))
            {
                while (true)
                {

                    Server server = new Server();

                    try
                    {

                        //Server mode

                        Console.WriteLine("Waiting for a connection");

                        server.Start();

                        Console.WriteLine("Connected!");

                        Console.WriteLine("***Hello and welcome to the Chat Console Program!***");

                        Console.WriteLine("***Press the I key to send a message***");

                        Console.WriteLine("***If you wanna stop talking Press the I key and type quit***");

                        while (true)
                        {  //while true is an endless loop


                            //Check for messages

                            string messageData = server.ReadMessage();

                            if (!(messageData == null))
                            {
                                Console.WriteLine(messageData);

                            }

                            if (Console.KeyAvailable)
                            { //KeyAvailable is what checks for if a key is pressed but is not a blocker

                                //Check for key presses
                                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                                if (pressedKey.Key == ConsoleKey.I)
                                {

                                    try
                                    {
                                        Console.Write(">>");

                                        string message = Console.ReadLine();

                                        string checkMessageQuit = message.ToUpper();

                                        if (checkMessageQuit == "QUIT")
                                        {

                                            server.QuitApp();

                                            //This is the code to end the program


                                        }
                                        else
                                        {

                                            server.SendMessage(message);

                                            //This will send the users typed message to the client

                                        }
                                    }
                                    catch
                                    {

                                        Console.Write("ERROR ");

                                        Console.WriteLine("Could Not Connect To Client At This Time");

                                        Console.Write("Press Any Key To Exit");

                                        Console.ReadKey();

                                        server.QuitApp();

                                    }



                                }
                                else
                                {
                                }


                            }



                            Thread.Sleep(500);

                            //This makes it so that the program is not always none stop
                            //looking for the messages. It takes a bit of pressure off

                        }





                    }
                    catch
                    {
                        Console.Write("ERROR ");

                        Console.WriteLine("Could Not Start Server At This Time");

                        Console.Write("Press Any Key To Exit");

                        Console.ReadKey();

                        server.QuitApp();
                    }


                }
            }

            else
            {

                //Client mode

                Client client = new Client();

                try
                {


                    client.Connect("127.0.0.1");

                    Console.WriteLine("***Hello and welcome to the Chat Console Program!***");

                    Console.WriteLine("***Press the I key to send a message***");

                    Console.WriteLine("***If you wanna stop talking Press the I key and type quit***");

                    while (true)
                    {  //while true is an endless loop

                        //Check for messages

                        string data = client.ReadMessage();

                        if (!(data == null))
                        {
                            Console.WriteLine(data);

                        }


                        if (Console.KeyAvailable)
                        { //KeyAvailable is what checks for if a key is pressed but is not a blocker

                            //Check for key presses
                            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                            if (pressedKey.Key == ConsoleKey.I)
                            {
                                Console.Write(">>");

                                string message = Console.ReadLine();

                                string checkMessageQuit = message.ToUpper();


                                if (checkMessageQuit == "quit")
                                {

                                    client.QuitApp();

                                    //This is the code to end the program

                                }
                                else
                                {


                                    client.SendMessage(message);

                                    //This will send the users typed message to the server


                                }


                            }
                            else
                            {
                            }


                        }



                        Thread.Sleep(500);

                        //This makes it so that the program is not always none stop
                        //looking for the messages. It takes a bit of pressure off

                    }



                }
                catch
                {
                    Console.Write("ERROR ");

                    Console.WriteLine("Could Not Connect To Server Please Try Again Later");

                    Console.Write("Press Any Key To Exit");

                    Console.ReadKey();

                    client.QuitApp();

                }
            }
        

        }
    }
}
