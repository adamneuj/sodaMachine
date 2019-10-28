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
        List<Penny> pennies;
        List<Nickle> nickles;
        List<Dime> dimes;
        List<Quarter> quarters;
        List<GrapeSoda> grapeInventory;
        List<OrangeSoda> orangeInventory;
        List<LemonSoda> lemonInventory;

        public SodaMachine()
        {
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
                if(initialInventory <= nickelsAndQuarters)
                {
                    nickles.Add(new Nickle());
                    quarters.Add(new Quarter());
                    if(initialInventory <= dimesAndSodas)
                    {
                        dimes.Add(new Dime());
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

        public void BuyGrapeSoda(GrapeSoda soda)
        {
            if(paymentValue >= soda.value)
            {

            }
        }
    }
}
