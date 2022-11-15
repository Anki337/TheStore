using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{
    public class PaymentOptions
    {
        public string name { get; set; }
        public string description { get; set; }

        public PaymentOptions(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        PaymentOptions paymentOptionsOne = new PaymentOptions("Klarna", "Lån");
        PaymentOptions paymentOptionsTwo = new PaymentOptions("Mastercard", "Kredit");
        PaymentOptions paymentOptionsThree = new PaymentOptions("Bankkonto", "Tillgångar");

        public string PayInfoOne
        {
            get { return paymentOptionsOne.PayInfoOne; }

        }
        public string PayInfoTwo
        {
            get { return paymentOptionsTwo.PayInfoTwo; }
        }
        public string PayInfoThree
        {
            get { return paymentOptionsThree.PayInfoThree; }
        }

    }


}
