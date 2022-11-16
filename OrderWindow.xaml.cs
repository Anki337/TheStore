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

namespace TheStore
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        List<string> billOpt = new List<string>();

        public OrderWindow()
        {
            InitializeComponent();
            string payOne = "Klarna, Lån";
            string payTwo = "Mastercard, Kredit";
            string payThree = "Bankkonto, Tillgångar";
            billOpt.Add(payOne);
            billOpt.Add(payTwo);
            billOpt.Add(payThree);
        }

        private void logCreateButton_Click(object sender, RoutedEventArgs e)
        {
            
            CreateNewUser createNewUser = new CreateNewUser();
            createNewUser.Show();
            this.Close();
        }

        private void ContinueShopping_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }
}
