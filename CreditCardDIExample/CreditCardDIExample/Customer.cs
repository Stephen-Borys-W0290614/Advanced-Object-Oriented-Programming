using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    class Customer
    {

        //private Visa creditCard = new Visa();
        private ICreditCard creditCard;// = new MasterCard();


        //constructor
        public Customer(ICreditCard creditCard)
        {

            this.creditCard = creditCard;

        }


        //public void setCreditCard(CreditCard creditCard)
        //{

        //    this.creditCard = creditCard;

        //}


        //public int Foo(string bar, int blah, CreditCard c)
        //{

        //    this.creditCard = c;
        //    return 0;

        //}


        public void MakePurchase()
        {

            creditCard.ChargeCard();

        }

    }
}
