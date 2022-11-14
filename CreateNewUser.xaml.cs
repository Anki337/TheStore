using System;
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
                string firstName = firstNameBox.Text;
                string lastName = lastNameBox.Text;
                returnText.Text = "";
            }
            if (emailBox.Text.Equals(""))
            {
                returnText.Text = "Please enter your email address";
                return;
            }
            else
            {
                string email = emailBox.Text;
                returnText.Text = "";
            }
            if (addressBox.Text.Equals(""))
            {
                returnText.Text = "Please enter an address";
                return;
            }
            else
            {
                string address = addressBox.Text;
                returnText.Text = "";
            }
            if (passwordBoxOne.Password.Equals("") || passwordBoxTwo.Password.Equals("") || !passwordBoxOne.Password.Equals(passwordBoxTwo.Password))
            {
                returnText.Text = "Please enter the same password twice";
                return;
            }
            else
            {
                string password = passwordBoxOne.Password;
                returnText.Text = "Registration success";
            }
        }

        private void clickResetButton(object sender, RoutedEventArgs e)
        {
            firstNameBox.Text = null;
            lastNameBox.Text = null;
            emailBox.Text = null;
            addressBox.Text = null;
            passwordBoxOne.Password = null;
            passwordBoxTwo.Password = null;
        }

        private void clickCancelButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
