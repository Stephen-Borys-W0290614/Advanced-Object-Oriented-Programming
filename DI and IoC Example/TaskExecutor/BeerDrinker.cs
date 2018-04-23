using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskExecutors
{
    public class BeerDrinker : IDrink, INoisy
    {

        private ILoggable logger;

        public BeerDrinker(ILoggable logger)
        {
            this.logger = logger;
        }

        public void MakeNoise()
        {
            logger.Log("SOCIABLE!!!!!");
        }

        public void TakeDrink()
        {
            //some more code here

            logger.Log("Took a drink of Brew at " + DateTime.Now);
        }
    }
}
