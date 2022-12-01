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
        private List<User> userList;
        private User[] loggedInUser;
        User user;
        Window parent;

        public CreateNewUser(MainWindow mainWindow, List<User> userList, User[] loggedInUser)
        {
            InitializeComponent();
            parent = mainWindow;
            this.userList = userList;
            this.loggedInUser = loggedInUser;
        }
        private void clickSubmitButton(object sender, RoutedEventArgs e)
        {
            string name = firstNameBox.Text + " " + lastNameBox.Text;
            string email = emailBox.Text;
            string address = addressBox.Text;
            double phone = double.Parse(phoneBox.Text);
            string password = passwordBoxOne.Password;

            //returnText.Text = "Please enter your first and last name";
            //returnText.Text = "Please enter a correct email address";
            //returnText.Text = "Please enter an address";
            //returnText.Text = "Please enter a phonenumber";
            //returnText.Text = "Please enter the same password twice";
            //returnText.Text = "The password must be at least 6 characters long";

            user = new User(name, password, email, address, phone);
            userList.Add(user);
            loggedInUser[0] = user;
            returnText.Text = "Registration success";
            submitButton.Visibility = Visibility.Collapsed;
            //resetButton.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;
            goBackButton.Visibility = Visibility.Visible;
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
        }
        private void clickCancelButton(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }
        private void ClickContinueShoppingButton(object sender, RoutedEventArgs e)
        {
            returnText.Text = "Continue shopping";
            parent.Show();
            this.Close();
        }
        //private void ClickCheckOutButton()  {}
    }
}
