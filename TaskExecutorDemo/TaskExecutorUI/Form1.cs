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
using TasksLib;

namespace TaskExecutorUI
{
    public partial class progressForm : Form
    {

        TaskExecutor executor = new TaskExecutor();

        Thread workerThread;

        public progressForm()
        {

            executor.ProgressChanged += new TasksLib.ProgressChangedEventHandler(Executor_ProgressChanged);

            executor.TaskCompleted += new TasksLib.TaskCompleteEventHandler(Executor_TaskComplete);


            InitializeComponent();
        }

        private void Executor_TaskComplete(Object sender, EventArgs e)
        {
            //Re-enable the button
            if (startButton.InvokeRequired) //This if else will check if you are on the same thread or not and go from there
            {

                MethodInvoker invoker = new MethodInvoker(
                    //Anonymous function/method
                    delegate ()
                    {

                        startButton.Enabled = true;

                        cancelButton.Enabled = false;


                    });

                startButton.BeginInvoke(invoker);
            }
            else
            {

                startButton.Enabled = true;

                cancelButton.Enabled = false;


            }

        }

        private void Executor_ProgressChanged(Object sender, ProgressChangedArgs e)
        {
            if (taskProgressBar.InvokeRequired) //This if else will check if you are on the same thread or not and go from there
            {

                MethodInvoker invoker = new MethodInvoker(
                    //Anonymous function/method
                    delegate ()
                    {

                        taskProgressBar.Value = e.Progress;

                    });

                //taskProgressBar.Invoke(invoker);
                taskProgressBar.BeginInvoke(invoker);
            }
            else
            {

                taskProgressBar.Value = e.Progress;

            }

        }

        private void startButton_Click(object sender, EventArgs e)
        {

            //executor.StopExecution = false;  ****ONE WAY TO DO THIS**** 
            //BETTER WAY IS IN TaskExecutor IN CLEANUP CODE in DoSomethingThatTakesAWhile()

            //Define a worker thread for our Do something method
            workerThread = new Thread(executor.DoSomethingThatTakesAWhile);
            workerThread.Name = "Fred";
            workerThread.Start();


            startButton.Enabled = false;

            cancelButton.Enabled = true;

            //Make an even to re enable the button when complete



            //Call the method
            //DoSomethingThatTakesAWhile();

        }


        public void ExecuteSomeMethod()
        {

            //This is code

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Premeturely cancel the worker thread so 
            //that it stops running before it finished

            //workerThread.Abort(); *****NEVER DO THIS*****

            executor.StopExecution = true;

            cancelButton.Enabled = false;



        }

        private void progressForm_Load(object sender, EventArgs e)
        {

        }


      
        private void progressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(workerThread != null && workerThread.IsAlive) { 
            //Set the worker thread to finish
            executor.StopExecution = true;
            workerThread.Join();

            }

        }

        private void progressForm_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
