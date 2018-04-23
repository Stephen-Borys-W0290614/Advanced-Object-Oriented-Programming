using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    class MasterCard : ICreditCard//, ISwipeable, ITappable
    {
        public void ChargeCard()
        {
            Console.WriteLine("Paid With Master Card");
        }

        public void SwipeMasterCard()
        {


        }

    }
}
