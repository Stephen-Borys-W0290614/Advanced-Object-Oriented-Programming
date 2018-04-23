using System;

namespace TasksLib
{
    public class ProgressChangedArgs : EventArgs
    {
        public ProgressChangedArgs(int progress)
        {

            Progress = progress;

        }


        public int Progress { get; }//set; }

    }
}