using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{
    internal class Item
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

        //Read items from file, this is a testlist
        /*ArrayList AvailableItemsList = new ArrayList();
        AvailableItemsListt.Add(new Item("Bobby car", "Fun car to play with", 5, 500, 7, "Big"));
        AvailableItemsList.Add(new Item("Bouncy ball", "Small ball to bounce around", 75, 5, 0,2, "Small"));
        AvailableItemsListt.Add(new Item("Bucket", "Great to play with sand", 27, 42, 0,7, "Outdoor"));
        AvailableItemsList.Add(new Item("Spade", "Digging it", 38, 342, 0,3, "Outdoor"));
        */
    }
}
