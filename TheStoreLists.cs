using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{

    public class TheStoreLists
    {
        List<User> userList = new List<User>();
        List<Item> availableItemsList = new List<Item>();
        List<Item> shoppingCartList = new List<Item>();
        public TheStoreLists()
        {

        }

        public void AddToUserList(User user)
        {
            userList.Add(user);
        }

        public List<User> GetUserList()
        {
            return userList;
        }

        public void RemoveInAvailableItemsList(Item item)
        {
            availableItemsList.Remove(item);
        }
        public void AddToAvailableItemsList(Item item)
        {
            availableItemsList.Add(item);
        }
        public List<Item> GetAvailableItemList()
        {
            return availableItemsList;
        }
        public void AddToShoppingCartList(Item item)
        {
            item.Quantity = 1;
            shoppingCartList.Add(item);
        }
        public List<Item> GetShoppingCartList()
        {
            return shoppingCartList;
        }
        public void EditQuantityInItem(string name)
        {
            foreach(Item item in availableItemsList)
            {
                if(item.Name.Equals(name))
                {
                    item.Quantity--;
                }
            }
        }
    }
}
