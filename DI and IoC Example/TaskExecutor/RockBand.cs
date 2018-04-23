using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TaskExecutors
{
    public class RockBand : INoisy
    {
        private ILoggable logger;

        public RockBand(ILoggable logger)
        {
            this.logger = logger;
        }

        public void MakeNoise()
        {
            logger.Log("TNT!!!! DYNOMITE!!!");
        }
    }
}
