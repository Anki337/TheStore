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
        private List<User> list;
        private User[] loggedInUser;
        User user = new User();
        Window parent;

        public MainWindow MainWindow { get; }
        //public TheStoreLists List { get; }

        /*public CreateNewUser(MainWindow mainWindow, TheStoreLists list)
        {
            InitializeComponent();
            parent = mainWindow;
            this.List = list;
            
        }*/
        public CreateNewUser(MainWindow mainWindow, List<User> list, User[] loggedInUser)
        {
            InitializeComponent();
            parent = mainWindow;
            this.list = list;
            this.loggedInUser = loggedInUser;
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
                returnText.Text = "The password must be at least 6 characters long";
                return;
            }
            else
            {
                createPassword();
                addUserToUserList();
                setLoggedInUser();
                returnText.Text = "Registration success";
                submitButton.Visibility = Visibility.Collapsed;
                //resetButton.Visibility = Visibility.Collapsed;
                cancelButton.Visibility = Visibility.Collapsed;
                goBackButton.Visibility = Visibility.Visible;
            }
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
            user.Email = email;
            returnText.Text = "";
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
        private void createPassword()
        {
            string password = passwordBoxOne.Password;
            user.Password = password;
        }

        private void addUserToUserList() 
        {
            list.Add(user);
        }

        private void setLoggedInUser()
        {
            User[] loggedInUser = { user };
        }

        private void clickResetButton(object sender, RoutedEventArgs e)
        {
            foreach (TextBox box in boxes.Children)
            {
                if (box != null)
                    box.Clear();
            }
            foreach (PasswordBox pBox in boxes.Children)
            {
                if (pBox != null)
                    pBox.Clear();
            }
        }

        private void clickCancelButton(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }
        private void ClickGoBackButton(object sender, RoutedEventArgs e)
        {
            returnText.Text = "Go Back";
            //list.RemoveAt(list.Count - 1);
            parent.Show();
            this.Close();
        }
    }
}
