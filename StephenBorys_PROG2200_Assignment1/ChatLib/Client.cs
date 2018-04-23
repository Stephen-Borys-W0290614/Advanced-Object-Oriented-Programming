using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Client
    {
        private TcpClient client;

        private NetworkStream stream;


            /// <summary>
            /// This function will connect the client to the server
            /// </summary>
            /// <param name="server"></param>
            public void Connect(String server)
            {
                    // Create a TcpClient.
                    // Note, for this client to work you need to have a TcpServer 
                    // connected to the same address as specified by the server, port
                    // combination.
                    Int32 port = 13000;
                    client = new TcpClient(server, port);

                    stream = client.GetStream();

          

        }


        /// <summary>
        /// This function takes what the user inputs in the program and will 
        /// get it ready to send to the server, then will send the message to
        /// the server
        /// </summary>
        /// <param name="message">This is the message the user inputs</param>
        public void SendMessage(String message)
        { 

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();


            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);

        
        }


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



            // Start listening for client requests.

            Byte[] bytes = new Byte[256];
            String data = null;



            int i;

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


        /// <summary>
        /// This function closes the TCPClient and the
        /// NetworkStream then ends the program
        /// </summary>
        public void QuitApp()
        {

            client.Close();

            stream.Close();

            Environment.Exit(0);


        }


    }
    }


    
