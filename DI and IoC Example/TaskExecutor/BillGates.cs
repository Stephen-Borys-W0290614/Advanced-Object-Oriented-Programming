using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TaskExecutors
{
    public class BillGates : ICharitable
    {
        private ILoggable logger;

        public BillGates(ILoggable logger)
        {
            this.logger = logger;
        }

        public void DoSomethingGood()
        {
            logger.Log("Bill Gates donated $1000000 to fight crime");
        }
    }
}
