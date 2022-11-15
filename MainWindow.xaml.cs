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
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace TheStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Item> availableItemsList = new List<Item>();

        ArrayList userList = new ArrayList();
        //List<User> userList = new List<User>(); I have commented this list out as the arrayList is the same as used in CreateNewUser-logic and has to be dynamic /Linnea
        ArrayList AvailableItemsList = new ArrayList();
    
        public MainWindow()
        {
            readItemsFromFile();

            User user = new User("Max", "bananer", "max@max.com", "Stan", 0735040590);

            userList.Add(user);

            InitializeComponent();

            testListBox.ItemsSource = availableItemsList;
            outdoorList.ItemsSource = availableItemsList;
            outdoorList.Items.Refresh();

            listAllItemsInMainWindowBody();

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

            CreateNewUser createNewUser = new CreateNewUser(userList);
            createNewUser.Show();
            this.Close();
        }


        private void shoppingCart_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();

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

        private void editItemInFile(Item item, int quantityToBuy, int index) //Tar en item, hur många som ska dras bort, och vilken plats i listan/textfilen den har.
        {
            int Currentquantity = item.getQuantity();
            if (Currentquantity >= quantityToBuy)
            {
                item.setQuantity(Currentquantity - quantityToBuy); //Uppdaterar antalet i objektet.
                
                string name = item.getName();
                string description = item.getDescription();
                int quantity = item.getQuantity();
                int price = item.getPrice();
                double weight = item.getWeight();
                string category = item.getCategory();
                string itemLines = name + "," + description + "," + quantity + ","  + price + "," + weight + "," + category; //En ny string som ska ersätta raden i textfilen

                lineChanger(itemLines, index); // Uppdaterar textfilen. 

                if (item.getQuantity() == 0) //Om saldot på item blir noll tas den bort från listan och från textfilen
                {
                    availableItemsList.Remove(item);
                    lineChanger(null, index);
                }
            }
            else
            {
                MessageBox.Show("Not enough " + item.getName() + " in store" + Environment.NewLine + "Current balance is: " + Currentquantity);
            }
        }
        static void lineChanger(string newText, int line_to_edit)
        {
            string path = "C:\\Users\\jaama\\Documents\\OOPAI\\Objektorienterad programmering grund 2\\Inlämningsuppgift\\The Store\\Files";
            string itemPath = path + @"\Items.txt";
            string[] arrLine = File.ReadAllLines(itemPath); //Hämtar hela textfilen och läser in varje rad som en egen string i en array.
            string[] trimmed = arrLine.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(); //Trimmar bort den första tomma raden om ett saldo skulle gå ner till noll.
            trimmed[line_to_edit] = newText; //Ändrar den stringen i arrayen som motsvarar platsen för den item vi vill ändra
            File.WriteAllLines(itemPath, trimmed); //Skriver en ny textfil med arrayen vi skapade två rader upp.
        }

        private void readItemsFromFile() //Läser in alla items från textfilen
        {
            string path = "C:\\Users\\jaama\\Documents\\OOPAI\\Objektorienterad programmering grund 2\\Inlämningsuppgift\\The Store\\Files";
            string itemPath = path + @"\Items.txt";
            string[] readLine = File.ReadAllLines(itemPath);

            foreach (string itemLine in readLine)
            {
                if (String.IsNullOrEmpty(itemLine))
                {
                    break;
                }
                string[] itemData = itemLine.Split(','); //Varje string som separeras med ett komma blir en string i denna array.
                string name = itemData[0]; //Platsen för var i arrayen avgör vilken typ av string det är.
                string description = itemData[1];
                int quantity = Convert.ToInt32(itemData[2]);
                int price = Convert.ToInt32(itemData[3]);
                double weight = Convert.ToDouble(itemData[4]);
                string category = itemData[5];
                //string toyPic = itemdata[6] ej implementerat
                availableItemsList.Add(new Item(name, description, quantity, price, weight, category));
            }
        }

        private void listAllItemsInMainWindowBody()
        {
            foreach (Item item in availableItemsList)
            {
                Label toyName = new Label();
                Label saldo = new Label();
                CheckBox textBox = new CheckBox();
                textBox.MaxWidth = 15;
                textBox.MaxHeight = 15;
                toyName.Content = item.getName();
                saldo.Content = item.getQuantity();
                /*if (item.getCategory().Equals("Outdoor"))
                {
                    OutLeksakStack.Children.Add(toyName);
                    OutAntalStack.Children.Add(saldo);
                    OutInputStack.Children.Add(textBox);
                }*/
                if (item.getCategory().Equals("Big"))
                {
                    BigLeksakStack.Children.Add(toyName);
                    BigAntalStack.Children.Add(saldo);
                    BigInputStack.Children.Add(textBox);
                }
                if (item.getCategory().Equals("Small"))
                {
                    SmallLeksakStack.Children.Add(toyName);
                    SmallAntalStack.Children.Add(saldo);
                    SmallInputStack.Children.Add(textBox);
                }

            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            int quantityToBuy = 1;
            editItemInFile((Item)availableItemsList[0], quantityToBuy, availableItemsList.IndexOf(availableItemsList[0]));
            string näjm = availableItemsList[0].getName();
          
            
            
            MessageBox.Show("You just bought " + quantityToBuy + " of the first listed toy which was the " + näjm + Environment.NewLine + ""); ;
        }
    }
}
