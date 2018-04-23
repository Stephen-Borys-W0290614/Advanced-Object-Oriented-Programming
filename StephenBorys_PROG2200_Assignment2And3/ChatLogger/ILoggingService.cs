using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLogger
{
    public interface ILoggingService
    {
        /// <summary>
        /// This is the function that logs
        /// </summary>
        /// <param name="message">this is the message sent from user or server</param>
        void Log(string message);

    }
}
