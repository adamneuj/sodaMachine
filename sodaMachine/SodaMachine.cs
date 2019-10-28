using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodaMachine
{
    class SodaMachine
    {
        double paymentValue;
        double refundAmount;
        List<Coin> refund;
        List<Penny> pennies;
        List<Nickle> nickles;
        List<Dime> dimes;
        List<Quarter> quarters;
        List<GrapeSoda> grapeInventory;
        List<OrangeSoda> orangeInventory;
        List<LemonSoda> lemonInventory;

        public SodaMachine()
        {
            refund = new List<Coin>();
            pennies = new List<Penny>();
            nickles = new List<Nickle>();
            dimes = new List<Dime>();
            quarters = new List<Quarter>();
            grapeInventory = new List<GrapeSoda>();
            orangeInventory = new List<OrangeSoda>();
            lemonInventory = new List<LemonSoda>();
            CreateInitialInventory();
        }

        private void CreateInitialInventory()
        {
            int initialInventory = 50;
            int nickelsAndQuarters = 20;
            int dimesAndSodas = 10;
            while(initialInventory != 0)
            {
                pennies.Add(new Penny());
                if (initialInventory <= nickelsAndQuarters)
                {
                    //nickles.Add(new Nickle());
                    //quarters.Add(new Quarter());
                    if (initialInventory <= dimesAndSodas)
                    {
                        //dimes.Add(new Dime());
                        grapeInventory.Add(new GrapeSoda());
                        orangeInventory.Add(new OrangeSoda());
                        lemonInventory.Add(new LemonSoda());
                    }
                }
                initialInventory--;
            }
        }
        public void TakePayment(List<Coin> payment)
        {
            for(int i = 0; i < payment.Count(); i++)
            {
                paymentValue += payment[i].value;
            }
            payment.Clear();
        }
        public List<Coin> RefundPayment()
        {
            return refund;
        }

        public GrapeSoda BuyGrapeSoda()
        {
            if (grapeInventory.Count() != 0)
            {
                CheckPaymentToSodaPrice(grapeInventory[0]);
                grapeInventory.RemoveAt(0);
                return new GrapeSoda();
            }
            else
            {
                refundAmount = paymentValue;
                Refund();
                return null;
            }
        }
        public OrangeSoda BuyOrangeSoda()
        {

            if (orangeInventory.Count() != 0)
            {
                CheckPaymentToSodaPrice(orangeInventory[0]);
                orangeInventory.RemoveAt(0);
                return new OrangeSoda();
            }
            else
            {
                refundAmount = paymentValue;
                Refund();
                return null;
            }
        }
        public LemonSoda BuyLemonSoda()
        {
            if (lemonInventory.Count() != 0)
            {
                CheckPaymentToSodaPrice(lemonInventory[0]);
                lemonInventory.RemoveAt(0);
                return new LemonSoda();
            }
            else
            {
                refundAmount = paymentValue;
                Refund();
                return null;
            }
        }
        public void CheckPaymentToSodaPrice(Soda soda)
        {

            if (paymentValue >= soda.value)
            {
                refundAmount = paymentValue - soda.value;
                Refund();
            }
            else
            {
                refundAmount = paymentValue;
                Refund();
                Console.WriteLine("Not enough money to buy soda.");
                Console.ReadLine();
            }
        }
        public void Refund()
        {
            bool change = CheckForChange();
            if(change == false)
            {
                Console.WriteLine("Not enough change in machine.");
                Console.ReadLine();
                return;
            }
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickle nickle = new Nickle();
            Penny penny = new Penny();
            while(refundAmount > 0)
            {
                refundAmount = Math.Round(refundAmount, 2);
                if (refundAmount - quarter.value >= quarter.value)
                {
                    refundAmount -= quarter.value;
                    refund.Add(new Quarter());
                    quarters.RemoveAt(0);
                }
                else if(refundAmount - dime.value >= dime.value)
                {
                    refundAmount -= dime.value;
                    refund.Add(new Dime());
                    dimes.RemoveAt(0);
                }
                else if(refundAmount - nickle.value >= nickle.value)
                {
                    refundAmount -= nickle.value;
                    refund.Add(new Nickle());
                    nickles.RemoveAt(0);
                }
                else
                {
                    refundAmount -= penny.value;
                    refund.Add(new Penny());
                    pennies.RemoveAt(0);
                }
            }
        }
        public bool CheckForChange()
        {
            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickle nickle = new Nickle();
            Penny penny = new Penny();
            double machineChange;
            machineChange = quarters.Count() * quarter.value;
            machineChange = machineChange + (dimes.Count() * dime.value);
            machineChange = machineChange + (nickles.Count() * nickle.value);
            machineChange = machineChange + (pennies.Count() * penny.value);
            if(machineChange < refundAmount)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
