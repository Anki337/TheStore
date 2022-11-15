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
        public int price;
        private double weight;
        private string category;
        private string toyPic;

        public Item(string name, string description, int quantity, int price, double weight, string category)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
            this.weight = weight;
            this.category = category;
            //this.toyPic = imagePath;

        }

        public string getName()
        {

            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getDescription()
        {

            return description;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }

        public int getQuantity()
        {

            return quantity;
        }
        public void setQuantity(int quantity)
        {
            this.quantity=quantity;
        }
        public int getPrice()
        {

            return price;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public double getWeight()
        {

            return weight;
        }
        public void setWeight(double weight)
        {
            this.weight = weight;
        }

        public string getCategory()
        {

            return category;
        }
        public void setCategory(string category)
        {
            this.category = category;
        }

    }
}
