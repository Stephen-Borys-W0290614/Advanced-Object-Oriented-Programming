using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksLib
{
    public class TaskExecutor
    {

        public event ProgressChangedEventHandler ProgressChanged;

        //Define an event for when the task is complete

        public event TaskCompleteEventHandler TaskCompleted;

        public bool StopExecution = false;

        public void DoSomethingThatTakesAWhile()
        {

            //Simulate doing something that takes a while

            int i;

            for (i = 1; i <= 100; i++)
            {

                if (StopExecution == false)
                {

                    //Simulate something that takes a bit of time
                    Thread.Sleep(100);


                    //Raise an event to broadcast that progress has been updated/changed
                    if (ProgressChanged != null)
                    {
                        ProgressChanged(this, new ProgressChangedArgs(i));
                    }




                }

                else
                {

                    break;

                }
            }

            StopExecution = false;

            //Do any cleanup...Close connection...Other stuff
            //Before the method completes

                //Fire an event that the task is done

                if (TaskCompleted != null && i > 100)
                {
                    TaskCompleted(this, EventArgs.Empty);
                }

            }
        }
    }

