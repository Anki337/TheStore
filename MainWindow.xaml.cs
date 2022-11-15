﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace TheStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ArrayList userList = new ArrayList();
        //List<User> userList = new List<User>(); I have commented this list out as the arrayList is the same as used in CreateNewUser-logic and has to be dynamic /Linnea
        ArrayList availableItemsList = new ArrayList();
    
        public MainWindow()
        {
            readItemsFromFile();
            


            User user = new User("Max", "bananer", "max@max.com", "Stan", 0735040590);

            userList.Add(user);

            InitializeComponent();
            availableItemsList.Add(new Item("Bobby car", "Fun car to play with", 5, 500, 7, "Big"));
            availableItemsList.Add(new Item("Bouncy ball", "Small ball to bounce around", 75, 5, 2, "Small"));
            availableItemsList.Add(new Item("Bucket", "Great to play with sand", 27, 42, 7, "Outdoor"));
            availableItemsList.Add(new Item("Spade", "Digging it", 38, 342, 3, "Outdoor"));




            testListBox.ItemsSource = availableItemsList;
            outdoorList.ItemsSource = availableItemsList;
            outdoorList.Items.Refresh();

            listAllItemsInMainWindowBody();

        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {

            string mail = mailBox.Text;
            string password = pwBox.Password;

            foreach (User user in userList)
            {
                if (mail.Equals(user.getEmail()) && password.Equals(user.getPassword()))
                {
                    mailBox.Visibility = Visibility.Collapsed;
                    pwBox.Visibility = Visibility.Collapsed;
                    userNameText.Text = " back " + user.getName();
                    logButton.Visibility = Visibility.Collapsed;
                    createButton.Visibility = Visibility.Collapsed;
                    logOutButton.Visibility = Visibility.Visible;
                }
            }

        }
        private void createButton_Click(object sender, RoutedEventArgs e)
        {

            CreateNewUser createNewUser = new CreateNewUser(userList);
            createNewUser.Show();
            this.Close();
        }


        private void shoppingCart_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();

        }
        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            mailBox.Visibility = Visibility.Visible;
            pwBox.Visibility = Visibility.Visible;
            userNameText.Text = "";
            logButton.Visibility = Visibility.Visible;
            createButton.Visibility = Visibility.Visible;
            logOutButton.Visibility = Visibility.Collapsed;

        }

        private void readItemsFromFile()
        {
            string path = "C:\\Users\\linnea\\source\\repos\\TheStore\\Files\\Items.txt";
            string itemPath = path + @"\Items.txt";
            string[] readLine = File.ReadAllLines(path);

            foreach (string itemLine in readLine)
            {
                string[] itemData = itemLine.Split(',');
                string name = itemData[0];
                string description = itemData[1];
                int quantity = Convert.ToInt32(itemData[2]);
                int price = Convert.ToInt32(itemData[3]);
                double weight = Convert.ToDouble(itemData[4]);
                string category = itemData[5];
                //string toyPic = itemdata[6] ej implementerat
                availableItemsList.Add(new Item(name, description, quantity, price, weight, category));
            }
        }

        private void listAllItemsInMainWindowBody()
        {
            foreach (Item item in availableItemsList)
            {
                Label toyName = new Label();
                Label saldo = new Label();
                CheckBox textBox = new CheckBox();
                textBox.MaxWidth = 15;
                textBox.MaxHeight = 15;
                toyName.Content = item.getName();
                saldo.Content = item.getQuantity();
                /*if (item.getCategory().Equals("Outdoor"))
                {
                    OutLeksakStack.Children.Add(toyName);
                    OutAntalStack.Children.Add(saldo);
                    OutInputStack.Children.Add(textBox);
                }*/
                if (item.getCategory().Equals("Big"))
                {
                    BigLeksakStack.Children.Add(toyName);
                    BigAntalStack.Children.Add(saldo);
                    BigInputStack.Children.Add(textBox);
                }
                if (item.getCategory().Equals("Small"))
                {
                    SmallLeksakStack.Children.Add(toyName);
                    SmallAntalStack.Children.Add(saldo);
                    SmallInputStack.Children.Add(textBox);
                }

            }
        }


    }
}
