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
        public string name { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public double weight { get; set; }
        public string category { get; set; }
        public string toyPic;

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

        /*public string getName()
        {

            return Name;
        }
        public void setName(string name)
        {
            this.Name = name;
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
        }*/
        public void setQuantity(int quantity)
        {
            this.quantity=quantity;
        }
        public int getPrice()
        {

            return price;
        }/*
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
        }*/

    }
}
