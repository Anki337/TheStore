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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TheStore
{

    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {

        List<string> shippingInfoList = new List<string>();
        List<string> cardInfoList = new List<string>(); // 
        List<Item> myCart;
        User[] loggedInUser;
        User user;
        Window parent;     
        ObservableCollection<string> comboBoxPay = new ObservableCollection<string>();      
        
        public string AdressInput { get; set; }
        public string PostNrInput { get; set; }
        public string OrtInput { get; set; }
        public string TelefonNrInput { get; set; }
        public string FakturaAdressInput { get; set; }
        public new string Name { get; set; }
        public string CardNameInput { get; set; }
        public string CardNumInput { get; set; }
        public string CardDateInput { get; set; }
        public string CardCvvInput { get; set; }
        public ObservableCollection<string> ComboBoxPay  
        {
            get { return comboBoxPay; }
            set
            {
                comboBoxPay = value;
            }
        }
     
        //Constructor that uses array LoggedInUser and myCartList referensed(sent) from Main Window
        public OrderWindow(MainWindow mainWindow, List<Item> myCart, User[] loggedInUser)
        {
            InitializeComponent();
            parent = mainWindow;
            this.myCart = myCart;
            this.loggedInUser = loggedInUser;
            itemNameWindow.ItemsSource = myCart;
            itemNameWindow.Items.Refresh();
            itemQuantityWindow.ItemsSource = myCart;
            itemQuantityWindow.Items.Refresh();
            item1.Content = loggedInUser[0].Name;
            SavedInfoComboBox.Items.Refresh();
            ComboBoxInfo();
            
        }
        
        private void ContinueShopping_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }

        public void TextBoxInfo()
        {
            cardInfoList.Add(CardNameInput);
            cardInfoList.Add(CardNumInput);
            cardInfoList.Add(CardDateInput);
            cardInfoList.Add(CardCvvInput);
            shippingInfoList.Add(AdressInput);
            shippingInfoList.Add(PostNrInput);
            shippingInfoList.Add(OrtInput);          
            shippingInfoList.Add(TelefonNrInput);
        }

        public void PopulateTextBoxes()
        {
            try
            {
                if (loggedInUser != null)
                {
                    string[] item = shippingInfoList.ToArray();
                    OrderWinAdress.AppendText(item[0]);
                    OrderWinPostNr.AppendText(item[1]);
                    OrderWinOrt.AppendText(item[2]);
                    OrderWinTele.AppendText(item[3]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                if (e == null) 
                {
                   throw;
                }
                MessageBox.Show("Du har inte fyllt i några fält att spara!");
            }
            
        }


        public void ComboBoxInfo()
        {
            string[] comboBoxList = new string[] { "Klarnare, Lån", "MasterofCards, Kredit med 200% ränta", "Bankkonto, Tillgångar", "Visaren, Kreditkort", "Megacard, Kredit", "Blackcard, Tillgångar", "Kasscard, Kreditkort" };
            
            
            foreach (string item in comboBoxList)
            {
                ComboBoxPay.Add(item);
            }
        }

        public void WriteShippingListToFile()
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(".");
            string shippInfo = currentdirectory.FullName + "\\Files" + @"\ShippingInfo.txt";
            string[] Customers = shippingInfoList.ToArray();
            File.WriteAllLines(shippInfo, Customers);
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if ((OrderWinAdress.Text == "") && (OrderWinPostNr.Text == "") && (OrderWinOrt.Text == "") && (OrderWinTele.Text == ""))
            {
                MessageBox.Show("Skriv in i alla fält för att spara Användare!");
            }
            else
            {

                TextBoxInfo();
                MessageBox.Show("Användare sparad!" + " " + "med info" + " " + shippingInfoList[0] + " " + shippingInfoList[1] + " " + shippingInfoList[2] + " " + shippingInfoList[3] + " !");
                WriteShippingListToFile();
                
            }
            ClearAllFields();

        }

        private void CardName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardNameInput = CardName.Text;
        }

        private void CardNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardNumInput = CardNum.Text;
        }

        private void CardDate1_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardDateInput = CardDate1.Text;
        }
        private void CardDate2_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardDateInput = CardDate2.Text;
        }
        private void CardCvv_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardCvvInput = CardCvv.Text;
        }

        public void ClearAllFields()
        {
            OrderWinAdress.Clear();
            OrderWinPostNr.Clear();
            OrderWinOrt.Clear();
            OrderWinTele.Clear();
        }

        private void SavedInfoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateTextBoxes();
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Varor kommer att skickas till: " + shippingInfoList[0] + " " + shippingInfoList[1] + " " + shippingInfoList[2] + " " + shippingInfoList[3]);
            }
            catch (ArgumentOutOfRangeException a)
            {
                if (a == null)
                {
                    throw;
                }
                MessageBox.Show("Du måste fylla i vart dina varor skall skeppas till innan du kan betala!");
            }
            ClearAllFields();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
        }
    }
}