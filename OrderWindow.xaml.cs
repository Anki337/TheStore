using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace TheStore
{

    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        TheStoreLists list = new TheStoreLists();

        List<string> shippingInfoList = new List<string>();
       ObservableCollection<string> comboBoxPay = new ObservableCollection<string>();
       
       
       public string AdressInput { get; set; }
       public string PostNrInput { get; set; }
       public string OrtInput { get; set; }
       public string TelefonNrInput { get; set; }
       public string FakturaAdressInput { get; set; }
        public ObservableCollection<string> ComboBoxPay
        {
            get { return comboBoxPay; }
            set
            {
                comboBoxPay = value;
            }
        }

        public OrderWindow(TheStoreLists list)
        {
            this.list = list;
            InitializeComponent();
            itemNameWindow.ItemsSource = list.getShoppingCartList();
            itemNameWindow.Items.Refresh();
            itemQuantityWindow.ItemsSource = list.getShoppingCartList();
            itemQuantityWindow.Items.Refresh();
            comboBoxPay.Add("Klarnare, Lån");
            comboBoxPay.Add("MasterofCards, Kredit med 200% ränta");
            comboBoxPay.Add("Bankkonto, Tillgångar");
            comboBoxPay.Add("Visaren, Kreditkort");
            comboBoxPay.Add("Megacard, Kredit");
            comboBoxPay.Add("Blackcard, Tillgångar");
            comboBoxPay.Add("Kasscard, Kreditkort");

            string[] shippingInfo = shippingInfoList.ToArray();
            
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
    
        public void TextBoxInfo()

        {                  
            shippingInfoList.Add(this.AdressInput);
            shippingInfoList.Add(this.PostNrInput);
            shippingInfoList.Add(this.OrtInput);
            shippingInfoList.Add(this.FakturaAdressInput);
            shippingInfoList.Add(this.TelefonNrInput);
        

        }

        public void WriteShippingListToFile()
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(".");
            string shippInfo = currentdirectory.FullName + "\\Files" + @"\ShippingInfo.txt";
            string[] Customers = shippingInfoList.ToArray();           
            File.WriteAllLines(shippInfo, Customers);
            MessageBox.Show(shippInfo);
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
                MessageBox.Show("Skriv in i alla fält för att spara Användare!");                
            }
            else
            {
                TextBoxInfo();
                MessageBox.Show("Användare sparad!" + " " + "med info" + " " + shippingInfoList[0] + " " + shippingInfoList[1] + " " + shippingInfoList[2] + " " + shippingInfoList[3] + " " + shippingInfoList[4] + "!");
                WriteShippingListToFile();
            }
        }   

        private void logCreateButton_Click(object sender, RoutedEventArgs e)
        {

        }
 
    }
}
