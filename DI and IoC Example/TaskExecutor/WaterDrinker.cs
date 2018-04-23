using System;
using Logger;

namespace TaskExecutors
{
    public class WaterDrinker : IDrink
    {
        private ILoggable logger;

        public WaterDrinker(ILoggable logger)
        {
            this.logger = logger;
        }

        public void TakeDrink()
        {
            //some more code here

            logger.Log("Took a drink of water at " + DateTime.Now);
        }
    }
}