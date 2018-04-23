using System;
using Logger;

namespace TaskExecutors
{
    public class DoGooder : ICharitable
    {
        private ILoggable logger;

        public DoGooder(ILoggable logger)
        {
            this.logger = logger;
        }

        public void DoSomethingGood()
        {
            //more code here...
            logger.Log("Donated time to good cause at " + DateTime.Now);
        }
    }
}