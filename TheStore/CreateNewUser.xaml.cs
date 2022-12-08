using System;
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
        private bool wantsToCheckOut;
        private List<User> userList;
        private User[] loggedInUser;
        List<Item> myCart;
        List<Item> allItems;
        User user;
        MainWindow parent;

        public CreateNewUser(MainWindow mainWindow, List<User> userList, User[] loggedInUser)
        {
            InitializeComponent();
            parent = mainWindow;
            this.userList = userList;
            this.loggedInUser = loggedInUser;
            wantsToCheckOut = false;
        }
        public CreateNewUser(MainWindow mainWindow, List<Item> myCart, List<Item>allItems )
        {
            InitializeComponent();
            parent = mainWindow;
            wantsToCheckOut=true;
            this.myCart = myCart;

            this.allItems = allItems;

        }

        private void clickSubmitButton(object sender, RoutedEventArgs e)
        {

            if (firstNameBox.Text == "" || lastNameBox.Text == "")
            {
                returnText.Text = "Please enter your first and last name";
                return;
            }
            else if (emailBox.Text.Equals("") && !emailBox.Text.Contains("@"))
            {
                returnText.Text = "Please enter a correct email address";
                return;
            }
            else if (addressBox.Text.Equals("") || addressBox.Text.Contains(","))
            {
                returnText.Text = "Please enter a correct address";
                return;
            }
            else if (phoneBox.Text.Equals(""))
            {
                returnText.Text = "Please enter a phone number";
                return;
            }
            else if (passwordBoxOne.Password.Equals("") || passwordBoxTwo.Password.Equals("") || !passwordBoxOne.Password.Equals(passwordBoxTwo.Password))
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
                createUser();
                userList.Add(user);
                loggedInUser[0] = user;
                userWantsToCheckOut();
            }
        }

        private void createUser() 
        {
            string name = firstNameBox.Text + " " + lastNameBox.Text;
            string email = emailBox.Text;
            string address = addressBox.Text;
            string phone = phoneBox.Text;
            string password = passwordBoxOne.Password;
            bool isAdmin = false;
            user = new User(name, password, email, address, phone, isAdmin);
        }
        private void userWantsToCheckOut()
        {
            if (wantsToCheckOut == true)
            {
                OrderWindow orderWindow = new OrderWindow(parent, myCart, loggedInUser, allItems);
                orderWindow.Show();
                this.Close();
            }
            if (wantsToCheckOut == false)
            {
                returnText.Text = "Registration success";
                submitButton.Visibility = Visibility.Collapsed;
                resetButton.Visibility = Visibility.Collapsed;
                cancelButton.Visibility = Visibility.Collapsed;
                ContinueShoppingButton.Visibility = Visibility.Visible;
            }
        }

        private void clickResetButton(object sender, RoutedEventArgs e)
        {
            foreach (TextBox box in boxes.Children.OfType<TextBox>())
            {
                box.Clear();
            }
            foreach (PasswordBox pBox in boxes.Children.OfType<PasswordBox>())
            {
                pBox.Clear();
            }
            returnText.Text = "";
        }
        private void clickCancelButton(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }
        private void ClickContinueShoppingButton(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
        }
        

    }
}
