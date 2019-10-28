using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
            List<Coin> payment = new List<Coin>();
            List<Soda> userInventory = new List<Soda>();
            payment.Add(new Quarter());
            payment.Add(new Quarter());
            payment.Add(new Quarter());
            payment.Add(new Quarter());
            sodaMachine.TakePayment(payment);
        }
    }
}
