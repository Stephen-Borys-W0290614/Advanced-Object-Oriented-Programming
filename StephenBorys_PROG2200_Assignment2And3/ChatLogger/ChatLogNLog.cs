using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ChatLogger
{
    public class ChatLogNLog : ILoggingService
    {


        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// This is a function to log using NLogger
        /// </summary>
        /// <param name="message">This is the message that is being logged to file</param>
        public void Log(string message)
        {

            logger.Log(LogLevel.Info, message);

        }


    }
}
