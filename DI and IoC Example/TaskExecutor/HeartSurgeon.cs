using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TaskExecutors
{
    public class HeartSurgeon : IComplicated
    {
        private ILoggable logger;

        public HeartSurgeon(ILoggable logger)
        {
            this.logger = logger;
        }

        public void PerformComplicatedTask()
        {
            logger.Log("Performed Quadruple Bypass surgery...");
        }
    }
}
