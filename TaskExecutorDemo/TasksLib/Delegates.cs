using System;

namespace TasksLib
{

    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedArgs e);

    //define a new delegate for when the task is complete
    public delegate void TaskCompleteEventHandler(object sender, EventArgs e);

}