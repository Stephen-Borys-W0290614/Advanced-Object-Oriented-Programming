using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    class Visa : ICreditCard
    {
        public void ChargeCard()
        {
            Console.WriteLine("Paid With Visa");
        }

        public void SwipeCard()
        {


        }

    }
}
