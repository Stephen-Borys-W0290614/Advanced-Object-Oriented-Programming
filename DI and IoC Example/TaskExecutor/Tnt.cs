using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TaskExecutors
{
    public class Tnt : INoisy
    {
        private ILoggable logger;

        public Tnt(ILoggable logger)
        {
            this.logger = logger;
        }

        public void MakeNoise()
        {
            logger.Log("BOOOOM!!!!");
        }
    }
}
