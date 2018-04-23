using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib
{
    public class Server
    {

        private TcpListener server;

        private TcpClient client;

        private NetworkStream stream;


        /// <summary>
        /// This is the funsction that starts up the server
        /// and gets it ready for a client to connect
        /// </summary>
        public void Start()
        {
            


            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

       
            // Perform a blocking call to accept requests.
            // You could also user server.AcceptSocket() here.
            client = server.AcceptTcpClient();

            

        }

        /// <summary>
        /// This function will accept the data being sent from the client and 
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
          
            stream = client.GetStream();

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
        }



        /// <summary>
        /// This function takes what the user inputs in the program and will 
        /// get it ready to send to the client, then will send the message to
        /// the client
        /// </summary>
        /// <param name="message">This is the message the user inputs</param>
        public void SendMessage(String message)
        {

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);

            // Send back a response.
            stream.Write(msg, 0, msg.Length);
            

        }

        /// <summary>
        /// This function stoped the server and closes the TCPClient and
        /// the NetworkStream then ends the program
        /// </summary>
        public void QuitApp()
        {

            client.Close();

            server.Stop();

            stream.Close();

            //Environment.Exit(0);


        }

    }
}
