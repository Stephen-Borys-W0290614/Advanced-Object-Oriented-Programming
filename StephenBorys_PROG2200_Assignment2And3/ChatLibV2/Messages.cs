using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static ChatLibV2.Delegates;
using ChatLogger;
namespace ChatLibV2
{
    public abstract class Messages
    {

        //This was my attempt to put the logger in the Lib

        //private readonly ILoggingService logger;


        //public Messages(ILoggingService logger)
        //{
        //    this.logger = logger;


        //}


        /// <summary>
        /// This is the TCPClient
        /// </summary>
        public static TcpClient client;

        /// <summary>
        /// This is the network stream used for sending and recieveing messages
        /// </summary>
        public static NetworkStream stream;

        /// <summary>
        /// This is used to check if the stream is active or not
        /// </summary>
        public bool checkStream = false;

        /// <summary>
        /// This is used to see if the client is connect to the server or not
        /// </summary>
        public bool connected;

        private string errorMessage;

        /// <summary>
        /// This function will accept the data being sent from the server and 
        /// will take the data, get it ready to be outputed for the user, then
        /// will send the data back to the program to be outputed for the user
        /// </summary>
        /// <returns>
        /// data- This is the message recieved
        /// null
        /// </returns>
        public string ReadMessage()
        {
            try {
                if (checkStream == false)
                {

                    checkStream = true;

                    //connected = true;

                }

                // Start listening for client requests.

                Byte[] bytes = new Byte[256];
                String data = null;


                int i;

                if (connected == true)
                {
                    if (stream.DataAvailable)
                    {
                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            return data;

                        }
                    }

                    return null;
                    //return string.Empty; This is another option for if there is no data available 
                }

                else if (connected == false)
                {

                    return null;

                }

                else
                {

                    errorMessage = "Not Connected";

                    return errorMessage;

                }
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

                errorMessage = "An Error Has Occured With Receving A Message";

                return errorMessage;

            }
        }









        /// <summary>
        /// This will take the message from the message box and then send the message through
        /// The NetworkStream
        /// </summary>
        /// <param name="message">This is the message the user typed</param>
        public string WriteMessage(String message)
        {

            try
            {

                if (checkStream == false)
                {
                    stream = client.GetStream();

                    checkStream = true;

                }

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                string newMessage = "Client: " + message;

                //logger.Log(newMessage);

                return (">>" + message);

            }
            catch (ArgumentNullException e)
            {
                errorMessage = "An ArgumentNullException Error Has Occured: " + e ;

                return errorMessage;
            }
            catch (SocketException e)
            {
                errorMessage = "An SocketException Error Has Occured: " + e;

                return errorMessage;

            }
            catch
            {
                errorMessage = "An Error Occured While Sending A Message";

                return errorMessage;
            }


        }




        /// <summary>
        /// This is the function used to close streams
        /// </summary>
        /// <param name="quitType">This is the string for the type of exit the user did</param>
        public void QuitApp(string quitType)
        {
            if (connected == true)
            {

                //logger.Log(quitType);


                client.Close();

                stream.Close();


                checkStream = false;

                connected = false;



            }
            else
            {
                //This is blank because if they quit right away before connecting it just quits the app
                //Nothing else is needed to be done
            }

        }

    
    }
}
