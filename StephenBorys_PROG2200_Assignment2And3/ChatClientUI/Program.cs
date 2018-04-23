using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLibV2;
using Unity;
using ChatLogger;


//To use Ed's Logger
//using ChatLog;

namespace ChatClientUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            //**********************************************************************
            //This area is the second IOC container
            //Had help from Ed for this part of the assignment. He Led me to resources such as 
            //https://simpleinjector.readthedocs.io/en/latest/quickstart.html#a-quick-example


            //SimpleInjector.Container container = new SimpleInjector.Container();

            //Choose which logger you want
            //container.Register<ILoggingService, ChatLogMade>();
            //container.Register<ILoggingService, ChatLogNLog>();


            //container.Verify();
            //Application.Run(container.GetInstance<Form1>());

            //**********************************************************************





            UnityContainer container = new UnityContainer();

            //container.RegisterType<ILoggingService, LogToFile>();
            //THIS IS EDS LOGGER


            container.RegisterType<ILoggingService, ChatLogMade>();
            //container.RegisterType<ILoggingService, ChatLogNLog>();





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<Form1>());

        }
        }
    }

