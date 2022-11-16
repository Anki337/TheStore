using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{
    public class PaymentOptions
    {
        ArrayList cardsOptions = new ArrayList();
        string[] paymentOpt = new string[] { "Klarna, Lån", "Mastercard, Kredit", "Bankkonto, Tillgångar" };
        string[] paymentOpt2 = new string[] { "Visa , Creditkort", "Mastercard, Kredit", "Black card, Tillgångar" };




        public string name { get; set; }
        public string description { get; set; }

        public PaymentOptions(string name, string description)
        {

            
            this.name = name;
            this.description = description;
            cardsOptions.Add(paymentOpt);
            cardsOptions.Add(paymentOpt2);

        }  
        
        public string ListPaymentOptions(string paylist)
        {
            for(int i = 0; i < cardsOptions.Count; i++)
            {
                i= cardsOptions.ToString().Length;
                i++;
                string payList = i.ToString();
                return payList;
            }
            return paylist;

        }
        



        
    
    
    }


}
