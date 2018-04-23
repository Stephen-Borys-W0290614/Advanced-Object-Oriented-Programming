using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using System.Configuration;

namespace ChatLogger 
{
    public class Log4NetLogger : ILoggingService
    {

        static protected ILog log = LogManager.GetLogger("Task");

        /// <summary>
        /// This is where you set up the config for log4net
        /// </summary>
        static void getInfo()
        {

           // FileInfo fi = new FileInfo("log4net.xml");
            //XmlConfigurator.Configure(new FileInfo(ConfigurationSettings.AppSettings["log4net-config-file"]));
            //log4net.Config.XmlConfigurator.(fi);
            //log4net.GlobalContext.Properties["host"] = Environment.MachineName;

            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.xml"));

        }

        


        /// <summary>
        /// this is the function that would log using log4net
        /// </summary>
        /// <param name="message">this is the message sent from user or server</param>
        public void Log(string message)
        {

            getInfo();

            log.Debug(message);


        }



    }
}
