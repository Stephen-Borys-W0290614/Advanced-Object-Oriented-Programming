using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatLogger
{
    public class ChatLogMade : ILoggingService  
    {



        public string dateHoursForFile = DateTime.Now.ToString("HH");

        public string dateMinForFile = DateTime.Now.ToString("mm");

        private string dateSecondsForFile = DateTime.Now.ToString("ss");

        private string pathOne = "C:\\OutPutFolder";


        /// <summary>
        /// This method will take incoming or outgoing messages and write them to a log for safe keeping
        /// </summary>
        /// <param name="message">message is the message that was sent by the user or the server</param>
        /// <returns></returns>
        public void Log(string message)
        {
                     string dateYear = DateTime.Now.ToString("yyyy");

                     string dateMonth = DateTime.Now.ToString("MM");

                     string dateDay = DateTime.Now.ToString("dd");

                     string dateHours = DateTime.Now.ToString("HH");

                     string dateMin = DateTime.Now.ToString("mm");

                     string dateSeconds = DateTime.Now.ToString("ss");


        // This is to make sure that it is known where the file should be to be written.
        string documentForChatLog = Path.Combine(pathOne, "TextFile-" + dateHoursForFile + "-" + dateMinForFile + "-" + dateSecondsForFile + ".txt");
                //Use Path.Combine because if i tried to add dateForUniqueFile to a String above it would give error


            //StreamWriter is what is used for to append things to files
            using (StreamWriter outputFile = new StreamWriter(documentForChatLog, true))

                    //The true is there because you need to append to file!
                    //If you do not have the true there it will re write the file every time!.
            {
                //This will make sure that the file is being written on if the file is open
                //If the file is not open it will create a new one.
             
                    outputFile.WriteLine("\n" + dateYear + "/"
                                        + dateMonth + "/"
                                        + dateDay + "  "
                                        + dateHours + ":"
                                        + dateMin + ":"
                                        + dateSeconds + "    "
                                        + message);

                
            }
                
               
            }


                

        }


    }
