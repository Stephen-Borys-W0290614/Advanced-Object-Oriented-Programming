using System;
using Logger;

namespace TaskExecutors
{
    public class MedicalResearcher : IComplicated
    {
        private ILoggable logger;

        public MedicalResearcher(ILoggable logger)
        {
            this.logger = logger;
        }

        public void PerformComplicatedTask()
        {
            //some more code here...

            logger.Log("Cured the Common Cold at " + DateTime.Now);
        }
    }
}