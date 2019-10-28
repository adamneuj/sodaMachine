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
            payment.Add(new Quarter());
            payment.Add(new Quarter());
            payment.Add(new Quarter());
            payment.Add(new Quarter());
            sodaMachine.TakePayment(payment);
            Soda userSoda = sodaMachine.BuyGrapeSoda();
            payment = sodaMachine.RefundPayment();

        }
    }
}
