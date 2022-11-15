﻿using System;
using System.Collections;
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
using TheStore;


namespace TheStore
{
    /// <summary>
    /// Interaction logic for CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : Window
    {
        private ArrayList userList;
        User user = new User();

        public CreateNewUser(ArrayList userList)
        {
            InitializeComponent();
            this.userList = userList;
        }

        public CreateNewUser() 
        {
            InitializeComponent();
        }

        private void clickSubmitButton(object sender, RoutedEventArgs e)
        {
            
            if (firstNameBox.Text == "" || lastNameBox.Text == "")
            {
                returnText.Text = "Please enter your first and last name";
                return;
            }
            else
            {
                createName();
            }
            if (emailBox.Text.Equals("") && !emailBox.Text.Contains("@"))
            {
                returnText.Text = "Please enter a correct email address";
                return;
            }
            else
            {
                createEmail();

            }
            if (addressBox.Text.Equals(""))
            {
                returnText.Text = "Please enter an address";
                return;
            }
            else
            {
                createAddress();
            }
            if (phoneBox.Text.Equals(""))
            {
                returnText.Text = "Please enter a phonenumber";
                return;
            }
            else
            {
                createPhone();
            }

            if (passwordBoxOne.Password.Equals("") || passwordBoxTwo.Password.Equals("") || !passwordBoxOne.Password.Equals(passwordBoxTwo.Password))
            {
                returnText.Text = "Please enter the same password twice";
                return;
            }
            else if (passwordBoxOne.Password.Length < 6)
            {
                returnText.Text = "The password must be at least 6 caracters long";
                return;
            }
            else
            {
                createPassword();
                returnText.Text = createUser();

                //MainWindow.Show();
                //this.Close();
            }
        }

        private void clickResetButton(object sender, RoutedEventArgs e)
        {
            firstNameBox.Text = null;
            lastNameBox.Text = null;
            emailBox.Text = null;
            addressBox.Text = null;
            phoneBox.Text = null; 
            passwordBoxOne.Password = null;
            passwordBoxTwo.Password = null;
        }

        private void clickCancelButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void createName()
        {
            string name = firstNameBox.Text + " " + lastNameBox.Text;
            user.setName(name);
            returnText.Text = "";
        }

        private void createEmail()
        {
            string email = emailBox.Text;
            if (user.setEmail(email))
            {
                user.setEmail(email);
                returnText.Text = "";
            }
        }

        private void createPassword()
        {
            string password = passwordBoxOne.Password;
            user.setPassword(password);
        }

        private void createAddress()
        {
            string address = addressBox.Text;
            user.setAddress(address);
            returnText.Text = "";
        }

        private void createPhone()
        {
            double phone = double.Parse(phoneBox.Text);
            user.setPhone(phone);
            returnText.Text = "";
        }

        private string createUser() 
        {
            user.setLoggedIn(true);
            user.setUserId();
            userList.Add(user);
            return "Registration success";
        }
    }
}
