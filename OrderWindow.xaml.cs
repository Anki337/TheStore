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

namespace TheStore
{

    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        TheStoreLists list;
        
        List<string> shippingInfoList = new List<string>();
        List<string> cardInfoList = new List<string>();
        

        Window parent;
        
        ObservableCollection<string> comboBoxPay = new ObservableCollection<string>();
        
        
        User user = new User("aaa", "bbb", "ccc", "ddd", 32);
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
        /*public ObservableCollection<string> SavedPersons
        {
            get { return savedPersons; }
            set
            {
                savedPersons = value;
            }                        
        }*/

       
        

        public OrderWindow(Window mainWindow, TheStoreLists list)
        {
            user.LoggedIn= true;
            parent = mainWindow;
            this.list = list;
            InitializeComponent();
            itemNameWindow.ItemsSource = list.GetShoppingCartList();
            itemNameWindow.Items.Refresh();
            itemQuantityWindow.ItemsSource = list.GetShoppingCartList();
            itemQuantityWindow.Items.Refresh();           
            item1.Content = getNameOfLoggedInUser();
            SavedInfoComboBox.Items.Refresh();
            ComboBoxInfo();
            
            //WriteSavedNameToFile();
            
        }

        private void LogCreateButton_Click(object sender, RoutedEventArgs e)
        {

            CreateNewUser createNewUser = new CreateNewUser();
            createNewUser.Show();
            this.Close();
        }

        private void ContinueShopping_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.Close();
        }

        public void TextBoxInfo()
        {
            cardInfoList.Add(this.CardNameInput);
            cardInfoList.Add(this.CardNumInput);
            cardInfoList.Add(this.CardDateInput);
            cardInfoList.Add(this.CardCvvInput);
            shippingInfoList.Add(this.AdressInput);
            shippingInfoList.Add(this.PostNrInput);
            shippingInfoList.Add(this.OrtInput);
            shippingInfoList.Add(this.FakturaAdressInput);
            shippingInfoList.Add(this.TelefonNrInput);

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
                if (user.LoggedIn == true)
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

        private void CardName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardNameInput = CardName.Text;
        }

        private void CardNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardNumInput = CardNum.Text;
        }

        private void CardDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardDateInput = CardDate.Text;
        }

        private void CardCvv_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardCvvInput = CardCvv.Text;
        }

        /*private void logCreateButton_Click(object sender, RoutedEventArgs e) //The user needs to be loggedIn before getting to this window
         {
             //CreateNewUser createNewUser = new CreateNewUser(this, list.GetUserList());
             createNewUser.Show();
             this.Hide();
         }*/
    }
}