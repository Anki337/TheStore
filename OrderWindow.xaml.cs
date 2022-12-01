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
        TheStoreLists list;

        List<string> shippingInfoList; 
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
            itemNameWindow.ItemsSource = list.GetShoppingCartList();
            itemNameWindow.Items.Refresh();
            itemQuantityWindow.ItemsSource = list.GetShoppingCartList();
            itemQuantityWindow.Items.Refresh();
            item1.Content = getNameOfLoggedInUser();
            SavedInfoComboBox.Items.Refresh();
            ComboBoxInfo();
            PopulateTextBoxes();
        }

        private void ContinueShopping_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }

        public void TextBoxInfo()
        {
            list.GetCardInfoList().Add(this.CardNameInput);
            list.GetCardInfoList().Add(this.CardNumInput);
            list.GetCardInfoList().Add(this.CardDateInput);
            list.GetCardInfoList().Add(this.CardCvvInput);
            list.GetShippingInfoList().Add(this.AdressInput);
            list.GetShippingInfoList().Add(this.PostNrInput);
            list.GetShippingInfoList().Add(this.OrtInput);
            list.GetShippingInfoList().Add(this.FakturaAdressInput);
            list.GetShippingInfoList().Add(this.TelefonNrInput);
        }

        public void PopulateTextBoxes()
        {
            
            if (loggedInUser != null) 
            {
                string[] item = list.GetShippingInfoList().ToArray();

                //OrderWinAdress.SelectedText += item[0];
                //OrderWinPostNr.SelectedText += item[1];
                //OrderWinOrt.SelectedText += item[2];
                //OrderWinTele.SelectedText += item[3];
                //OrderWinAdress.AppendText(item[0]);
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
        public string getNameOfLoggedInUser()
        {
            string name = "No logged in user";
            foreach (User user in list.GetUserList())
            {
                if (user.LoggedIn == false) 
                {
                    name = user.Name.ToString();
                    break;
                }
            }
            return name;
        }
        public void WriteShippingListToFile()
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(".");
            string shippInfo = currentdirectory.FullName + "\\Files" + @"\ShippingInfo.txt";
            string[] Customers = list.GetShippingInfoList().ToArray();
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
                MessageBox.Show("Användare sparad!" + " " + "med info" + " " + list.GetShippingInfoList()[0] + " " + list.GetShippingInfoList()[1] + " " + list.GetShippingInfoList()[2] + " " + list.GetShippingInfoList()[3] + " " + list.GetShippingInfoList()[4] + "!");
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
    }
}