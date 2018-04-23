using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static ChatLibV2.Delegates;
using ChatLibV2;
using ChatLogger;

namespace ChatLibV2
{

    public class Client : Messages
    {



        //This was my attempt to put the logger in the Lib
        //private readonly ILoggingService logger;


        //public Client(ILoggingService logger)
        //{
        //    this.logger = logger;


        //}


        TaskExecutor executor = new TaskExecutor();

        /// <summary>
        /// StopExecution is used to stop the excution of the client
        /// </summary>
        public bool StopExecution = false;

        String message;

        /// <summary>
        /// This is the event for when a message is being recieved
        /// </summary>
        public event MessageReciviedEventHandler MessageRecivied;


        string errorMessage;

       


        /// <summary>
        /// This function will connect the client to the server
        /// </summary>
        /// <param name="server">This is the server string</param>
        public string Connect(String server)
        {

            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                client = new TcpClient(server, port);

                stream = client.GetStream();

                checkStream = true;



                //logger.Log("Client connected to server at 127.0.0.1");

                //I hardcode in the server ip because it is hardcoded in the code
                //Could be edited to not be hardcoded in future

                return null;

            }
            catch (ArgumentNullException e)
            {
                errorMessage = "An ArgumentNullException Error Has Occured: " + e;

                return errorMessage;
            }
            catch (SocketException e)
            {
                errorMessage = "An SocketException Error Has Occured: " + e;

                return errorMessage;

            }
            catch
            {

                    errorMessage = "An Error Occured While Trying To Connect To Server";

                    return errorMessage;

              
            }

        }




        /// <summary>
        /// This is the method that will be run on the worker thread to always be looking for if a message has been recieved
        /// </summary>
        public void CheckForMessages()
        {

            while (true)
            {
                if ((message = ReadMessage()) != null)
                {

                    //message = ReadMessage();

                    //raise message event
                    MessageRecivied(this, new MessageRecievedArgs(message));

                    string newMessage = "Server: " + message;

                    //logger.Log(newMessage);



                }
            }

        }



    }
}

