using System;
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


namespace TheStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> userList = new List<User>();

        public MainWindow()
        {
            User user = new User("Max", "bananer", "max@max.com", "Stan", 0735040590);
            userList.Add(user);
            InitializeComponent();
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

            this.Hide();
            CreateNewUser createNewUser = new CreateNewUser();
            createNewUser.Show();
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
    }
}
