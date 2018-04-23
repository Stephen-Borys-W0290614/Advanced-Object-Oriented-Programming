using System;
using Logger;

namespace TaskExecutors
{
    public class CarHorn : INoisy
    {
        private ILoggable logger;

        public CarHorn(ILoggable logger)
        {
            this.logger = logger;
        }

        public void MakeNoise()
        {
            //code to make some noise.


            logger.Log("Honked car horn at " + DateTime.Now);
        }
    }
}