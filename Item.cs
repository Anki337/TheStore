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
        private string _name;
        private string _description;
        private int _quantity;
        private int _price;
        private double _weight;
        private string _category;
        private string _toyPic;
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int Price { get => _price; set => _price = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public string Category { get => _category; set => _category = value; }
        public string ToyPic { get => _toyPic; set => _toyPic = value; }

        public Item(string name, string description, int quantity, int price, double weight, string category)
        {
            this._name = name;
            this._description = description;
            this.Quantity = quantity;
            this._price = price;
            this._weight = weight;
            this._category = category;
            //this._toyPic = imagePath;

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
        /*public void setQuantity(int quantity)
        {
            this._quantity=quantity;
        }
        public int getPrice()
        {

            return _price;
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
        }*/

}
}
