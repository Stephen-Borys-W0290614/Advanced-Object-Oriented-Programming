using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibV2
{
    public class MessageRecievedArgs : EventArgs
    {

        /// <summary>
        /// This is the event for when a message is recieved it accepts the message from the user
        /// </summary>
        /// <param name="message">Message is the message that was recieved or sent from users</param>
        public MessageRecievedArgs(string message)
        {

            Message = message;

        }


        public string Message { get; }//set; }

    }
}
