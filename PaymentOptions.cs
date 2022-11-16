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
    }


}
