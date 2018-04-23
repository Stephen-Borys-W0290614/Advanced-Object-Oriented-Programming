using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibV2
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

    }
}
