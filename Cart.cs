using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{
    public class Cart
    {

        private int cartId = 0;

        private int getCartId() 
        { 
            return cartId;
        }

        public ArrayList itemList;
        readonly User user;  
        
        public Cart(User user, ArrayList itemList) 
        {
            cartId = cartId + 1;
            this.user = user;
            this.itemList = itemList;
        }   

    }
}
