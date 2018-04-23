using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLibV2;
using ChatLogger;

//This is Ed's ChatLog
//using ChatLog;

namespace ChatClientUI
{
    public partial class Form1 : Form
    {

        private readonly ILoggingService logger; 

        TaskExecutor executor = new TaskExecutor();

        Thread workerThread;

        Client client = new Client();

        private bool pauseThread = false;

        private bool disconnectFirst = false;

        int count = 0;

        string connectText;


        /// <summary>
        /// This function occurs when the form is created
        /// </summary>
        /// <param name="logger">This is the call to the ILoggingServices</param>
        public Form1(ILoggingService logger)
        {
            this.logger = logger;

            client.MessageRecivied += new ChatLibV2.Delegates.MessageReciviedEventHandler(Client_MessageRecieved);

            InitializeComponent();
        }


        /// <summary>
        /// This is the function for when the MessageRecieved event is raised
        /// </summary>
        /// <param name="sender">This is the object</param>
        /// <param name="e">This is the value for MessageRecievedArgs</param>
        private void Client_MessageRecieved(Object sender, MessageRecievedArgs e)
        {
            try
            {

                if (chatBoxArea.InvokeRequired) //This if else will check if you are on the same thread or not and go from there
                {

                    MethodInvoker invoker = new MethodInvoker(
                        //Anonymous function/method
                        delegate ()
                        {
                            
                            chatBoxArea.AppendText(e.Message);
                            logger.Log("Server: " + e.Message);
                            chatBoxArea.AppendText(Environment.NewLine);


                        });


                    chatBoxArea.BeginInvoke(invoker);


                }
                else
                {

                    chatBoxArea.AppendText(e.Message);
                    logger.Log("Server: " + e.Message);
                    chatBoxArea.AppendText(Environment.NewLine);
                }
            }
            catch
            {

                chatBoxArea.AppendText("An Error Has Occured");
                chatBoxArea.AppendText(Environment.NewLine);


            }




        }


        /// <summary>
        /// This is the code that will run when the form opens
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the value for EventArgs</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// This is the code that will run when the menu bar is clicked
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the value for EventArgs</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }



        /// <summary>
        /// This is the function for when the connect button is clicked
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the value for EventArgs</param>
        private void connectMenuBarItem_Click(object sender, EventArgs e)
        {

                connectText = client.Connect("127.0.0.1");


                if(connectText == null)
                {

                    chatBoxArea.AppendText("***CONNECTED TO SERVER***");

                    logger.Log("Client connected to server at 127.0.0.1");

                    chatBoxArea.AppendText(Environment.NewLine);

                    messageTextBox.Enabled = true;

                    sendButton.Enabled = true;

                    connectMenuBarItem.Enabled = false;

                    disconnectMenuBarItem.Enabled = true;

                    client.connected = true;
                

                    if (pauseThread == false)
                    {
                        workerThread = new Thread(client.CheckForMessages);
                        workerThread.Name = "Fred";
                        workerThread.IsBackground = true; //Found online, This will make the workerThread be in the background 
                                                          //so when you close the application it will close no problem
                        workerThread.Start();
                    }
                   
            }
            else
            {
                chatBoxArea.AppendText(connectText);
                chatBoxArea.AppendText(Environment.NewLine);

            }



        }



        /// <summary>
        /// This is the function for when the disconnect button is clicked
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the value for EventArgs</param>
        private void disconnectMenuBarItem_Click(object sender, EventArgs e)
        {

            client.QuitApp("Client Has Disconnected From Server. Chat Closed.");

            logger.Log("Client Has Disconnected From Server.Chat Closed.");

            chatBoxArea.AppendText("***DISCONNECTED TO SERVER***");

            chatBoxArea.AppendText(Environment.NewLine);

            disconnectFirst = true;

            messageTextBox.Enabled = false;

            sendButton.Enabled = false;

            connectMenuBarItem.Enabled = true;

            disconnectMenuBarItem.Enabled = false;

            pauseThread = true;

        }


        /// <summary>
        /// This is the function for when the send button is clicked
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the Value for EventArgs</param>
        private void sendButton_Click(object sender, EventArgs e)
        {

                string text = messageTextBox.Text;

                string newMessage = client.WriteMessage(text);

                logger.Log("Client: " + text);

                chatBoxArea.AppendText(newMessage);

                chatBoxArea.AppendText(Environment.NewLine);

                messageTextBox.Text = "";

                


            }


        /// <summary>
        /// This will close the application
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the value for EventArgs</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            
                Application.Exit();  //This is the only item in here because everytime the app is closed the closing method will run and 
                                     //Do the extra code that would normally be needed here.
        }



        /// <summary>
        /// This is the function for when the X button is clicked
        /// </summary>
        /// <param name="sender">This is the value for Object</param>
        /// <param name="e">This is the value for FormClosingEventArgs</param>
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {

            if (disconnectFirst == false)
            {
                if (count == 0)      //This if is here because this function will run as many times as there are threads
                {                    //So to insure that code is not being excecuted more then once for no reason this if is used
                    count += 1;

                    client.QuitApp("Client Has Closed The Application");

                    logger.Log("Client Has Closed The Application");

                    client.StopExecution = true;

                }

                Application.Exit();

            }
            else
            {
                if (count == 0)
                {
                    count += 1;

                    client.StopExecution = true;
                }


                Application.Exit();

            }


        }

        private void chatBoxArea_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
