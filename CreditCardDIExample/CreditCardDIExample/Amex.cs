using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    class Amex : ICreditCard
    {
        public void ChargeCard()
        {
            Console.WriteLine("Amex :)");
        }
    }
}
