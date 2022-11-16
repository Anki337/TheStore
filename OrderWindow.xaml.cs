using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        List<string> shippingInfoList = new List<string>();


        public string AdressInput { get; set; }
       public string PostNrInput { get; set; }
       public string OrtInput { get; set; }
       public string TelefonNrInput { get; set; }
       public string FakturaAdressInput { get; set; }


        public OrderWindow()
        {

            
            InitializeComponent();

            /* Dessa TextBoxar finns i OrderWindow.
             * 
            "OrderWinAdress"
            "OrderWinPostNr"
            "OrderWinOrt"
            "OrderWinTele"
            "OrderWinCompFaktAdress"
            "OrderWinCompAdress"
            "OrderWinCompPostNr"
            "OrderWinCompOrt"
            "OrderWinCompTele"
            */

            

        }

        private void LogCreateButton_Click(object sender, RoutedEventArgs e)
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
    
        public string TextBoxInfo()
        {
                  
            shippingInfoList.Add(this.AdressInput);
            shippingInfoList.Add(this.PostNrInput);
            shippingInfoList.Add(this.OrtInput);
            shippingInfoList.Add(this.FakturaAdressInput);
            shippingInfoList.Add(this.TelefonNrInput);
            return shippingInfoList.ToString();
        }

        private void OrderWinAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
             AdressInput = OrderWinAdress.Text;
        }

        private void OrderWinPostNr_TextChanged(object sender, TextChangedEventArgs e)
        {
            PostNrInput = OrderWinPostNr.Text;
        }

        private void OrderWinOrt_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrtInput = OrderWinOrt.Text;
        }

        private void OrderWinTele_TextChanged(object sender, TextChangedEventArgs e)
        {

            TelefonNrInput = OrderWinTele.Text;

        }

        private void OrderWinCompFaktAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
            FakturaAdressInput = OrderWinCompFaktAdress.Text;
        }
        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if ((OrderWinAdress.Text == "") && (OrderWinPostNr.Text == "") && (OrderWinOrt.Text == "") && (OrderWinTele.Text == ""))
            {
                MessageBox.Show("Skriv in i alla fält för att spara användare!");
                
            }
            else
            {
                TextBoxInfo();
                MessageBox.Show("Användare sparad!");
                foreach (string item in shippingInfoList)
                {
                    Console.WriteLine(item);
                }


            }
        }   

        private void logCreateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
