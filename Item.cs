using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{
    public class Item
    {
        private string name;
        private string description;
        private int quantity;
        private int price;
        private double weight;
        private string category;

        public Item(string name, string description, int quantity, int price, double weight, string category)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
            this.weight = weight;
            this.category = category;
        }

        public string getName()
        {

            return name;
        }
        public int getQuantity()
        {

            return quantity;
        }
        public string getCategory()
        {

            return category;
        }

    }
}
