using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardDIExample
{
    class Program
    {
        static void Main(string[] args)
        {

            Customer customer = new Customer(new Amex());
            customer.MakePurchase();

            Console.ReadKey();

        }
    }
}
