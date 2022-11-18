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
        public List<User> userList;
        User user = new User();
        Window parent;

        public CreateNewUser(Window mainWindow, List<User> userList)
        {
            InitializeComponent();
            this.userList = userList;
            parent = mainWindow;
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
                createUser(returnText.Text);
                submitButton.Visibility = Visibility.Collapsed;
                resetButton.Visibility = Visibility.Collapsed;
                cancelButton.Visibility = Visibility.Collapsed;
                goBackButton.Visibility = Visibility.Visible;
            }
        }

        private void clickResetButton(object sender, RoutedEventArgs e)
        {
            foreach (TextBox box in boxes.Children)
            {
                box.Clear();
            }

            foreach (PasswordBox pBox in boxes.Children)
            {
                pBox.Clear();
            }
        }

        private void clickCancelButton(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            parent.Show();
            this.Close();
        }




        private void createName()
        {
            string name = firstNameBox.Text + " " + lastNameBox.Text;
            user.Name = name;
            returnText.Text = "";
        }

        private void createEmail()
        {
            string email = emailBox.Text;
            if (user.Email == email)
            {
                user.Email = email; ;
                returnText.Text = "";
            }
        }

        private void createPassword()
        {
            string password = passwordBoxOne.Password;
            user.Password = password;
        }

        private void createAddress()
        {
            string address = addressBox.Text;
            user.Address = address;
            returnText.Text = "";
        }

        private void createPhone()
        {
            double phone = double.Parse(phoneBox.Text);
            user.Phone = phone;
            returnText.Text = "";
        }

        private string createUser(string _name)
        {
            user.LoggedIn = true;
            user.Name = _name;
            userList.Add(user);
            return "Registration success";
        }

        private void ClickGoBackButton(object sender, RoutedEventArgs e)
        {
            returnText.Text = "Go Back";
            parent.Show();
            this.Close();
        }
    }
}
