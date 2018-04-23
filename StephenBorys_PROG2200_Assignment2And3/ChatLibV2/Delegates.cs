using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibV2
{
    public class Delegates
    {
        /// <summary>
        /// This is the event handler for when a message is recieved
        /// </summary>
        /// <param name="sender">This is the value for object</param>
        /// <param name="e">this is the value for MessageRecievedArgs</param>
        public delegate void MessageReciviedEventHandler(object sender, MessageRecievedArgs e);


    }
}
