﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheStore
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        MainWindow parent;
        List<User> userList;
        List<Item> allItems;
        public Admin(MainWindow parent, List<Item> allItems, List<User> userList)
        {
            InitializeComponent();
            this.parent = parent;
            this.UserList = userList;
            this.allItems = allItems;
            itemCombo.ItemsSource = allItems;
            userCombo.ItemsSource = userList;

        }

        public List<User> UserList { get => userList; set => userList = value; }

        private void itemCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemStack.Visibility = Visibility.Visible;
            newItemStack.Visibility = Visibility.Visible;
            userStack.Visibility = Visibility.Hidden;
            Item item = itemCombo.SelectedItem as Item;
            itemName.Text = item.Name;
            itemDescription.Text = item.Description;
            itemQuantity.Text = item.Quantity.ToString();
            itemPrice.Text = item.Price.ToString();
            itemWeight.Text = item.Weight.ToString();
            itemCategory.Text = item.Category;


        }
        private void userCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userStack.Visibility = Visibility.Visible;
            itemStack.Visibility = Visibility.Hidden;
            newItemStack.Visibility = Visibility.Hidden;
            User user = userCombo.SelectedItem as User;
            userName.Text = user.Name;
            userPassword.Text = user.Password;
            userEmail.Text = user.Email;
            userAdress.Text = user.Address;
            userPhone.Text = user.Phone.ToString();

        }

        private void ChangeItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            StackPanel stack = (StackPanel)button.Parent;
            TextBox textBox = (TextBox)stack.Children[1];
            Item item = itemCombo.SelectedItem as Item;
            if (textBox.Name.Equals("itemName"))
            {
                item.Name = textBox.Text;
            }
            if (textBox.Name.Equals("itemDescription"))
            {
                item.Description = textBox.Text;
            }
            if (textBox.Name.Equals("itemQuantity"))
            {
                try
                {
                    item.Quantity = Convert.ToInt32(textBox.Text);

                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);

                }
            }
            if (textBox.Name.Equals("itemPrice"))
            {
                try
                {
                    item.Price = Convert.ToInt32(textBox.Text);

                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);

                }
            }
            if (textBox.Name.Equals("itemWeight"))
            {
                try
                {
                    item.Weight = Convert.ToInt32(textBox.Text);

                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);

                }
            }
            if (textBox.Name.Equals("itemCategory"))
            {
                item.Category = textBox.Text;
            }
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            StackPanel stack = (StackPanel)button.Parent;
            TextBox textBox = (TextBox)stack.Children[1];
            User user = itemCombo.SelectedItem as User;
            if (textBox.Name.Equals("userName"))
            {
                user.Name = textBox.Text;
            }
            if (textBox.Name.Equals("userPassword"))
            {
                user.Password = textBox.Text;
            }
            if (textBox.Name.Equals("userEmail"))
            {
                user.Email = textBox.Text;
            }
            if (textBox.Name.Equals("userAdress"))
            {
                user.Address = textBox.Text;
            }
            if (textBox.Name.Equals("userPhone"))
            {
                try
                {
                    user.Phone = Convert.ToInt16(textBox.Text);
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);

                }
            }
        }

        private void createNewItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            StackPanel stack = (StackPanel)button.Parent;
            string name = newItemName.Text;
            string description = newItemDescription.Text;
            int quantity = Convert.ToInt32(newItemQuantity.Text);
            int price = Convert.ToInt32(newItemPrice.Text);
            double weight = Convert.ToDouble(newItemWeight.Text);
            string category = newItemCategory.Text;
            try
            {
                Item item = new Item(name, description, quantity, price, weight, category);
                allItems.Add(item);
                MessageBox.Show(name + " was created succesfully");
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }

        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }
    }
}
