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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;



namespace TheStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TheStoreLists list = new TheStoreLists();

        FileManager fileManager = new FileManager();


        public MainWindow()
        {
            InitializeComponent();
            readItemsFromFile();

            outdoorList.ItemsSource = list.GetAvailableItemList();
            outdoorList.Items.Refresh();

            User user = new User("Max", "bananer", "max@max.com", "Stan", 0735040590); //test User
            list.AddToUserList(user); //for testing
            user.LoggedIn = true; //for testing, will be set in loggin

            listAllItemsInMainWindowBody();
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {

            string mail = mailBox.Text;
            string password = pwBox.Password;

            foreach (User user in list.GetUserList())
            {
                if (mail.Equals(user.Email) && password.Equals(user.Password))
                {
                    mailBox.Visibility = Visibility.Collapsed;
                    pwBox.Visibility = Visibility.Collapsed;

                    userNameText.Text = " back " + user.Name;

                    //user.setLoggedIn(true);

                    logButton.Visibility = Visibility.Collapsed;
                    createButton.Visibility = Visibility.Collapsed;
                    logOutButton.Visibility = Visibility.Visible;
                }
            }

        }
        private void createButton_Click(object sender, RoutedEventArgs e)
        {

            CreateNewUser createNewUser = new CreateNewUser(this, list);
            createNewUser.Show();
            this.Hide();
        }


        private void shoppingCart_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(this, list);
            orderWindow.Show();
            this.Hide();

        }
        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            mailBox.Visibility = Visibility.Visible;
            pwBox.Visibility = Visibility.Visible;
            //user.setLoggedIn(false);
            userNameText.Text = "";
            logButton.Visibility = Visibility.Visible;
            createButton.Visibility = Visibility.Visible;
            logOutButton.Visibility = Visibility.Collapsed;

        }

        private void editItemInFile(Item item, int quantityToBuy, int index) //Tar en item, hur många som ska dras bort, och vilken plats i listan/textfilen den har.
        {
            int Currentquantity = item.Quantity;
            if (Currentquantity >= quantityToBuy)
            {
                item.Quantity = Currentquantity - quantityToBuy; //Uppdaterar antalet i objektet.

                string name = item.Name;
                string description = item.Description;
                int quantity = item.Quantity;
                int price = item.Price;
                double weight = item.Weight;
                string category = item.Category;
                string itemLines = name + "," + description + "," + quantity + "," + price + "," + weight + "," + category; //En ny string som ska ersätta raden i textfilen

                lineChanger(itemLines, index); // Uppdaterar textfilen. 

                if (item.Quantity == 0) //Om saldot på item blir noll tas den bort från listan och från textfilen
                {
                    list.RemoveInAvailableItemsList(item);
                    lineChanger(null, index);
                }
            }
            else
            {
                MessageBox.Show("Not enough " + item.Name + " in store" + Environment.NewLine + "Current balance is: " + Currentquantity);
            }
        }
        static void lineChanger(string newText, int line_to_edit)
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(".");
            string itemPath = currentdirectory.FullName + "\\Files" + @"\Items.txt";
            string[] arrLine = File.ReadAllLines(itemPath); //Hämtar hela textfilen och läser in varje rad som en egen string i en array.
            string[] trimmed = arrLine.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(); //Trimmar bort den första tomma raden om ett saldo skulle gå ner till noll.
            trimmed[line_to_edit] = newText; //Ändrar den stringen i arrayen som motsvarar platsen för den item vi vill ändra
            File.WriteAllLines(itemPath, trimmed); //Skriver en ny textfil med arrayen vi skapade två rader upp.
        }

        private void readItemsFromFile() //Läser in alla items från textfilen
        {
            DirectoryInfo currentdirectory = new DirectoryInfo(".");
            string itemPath = currentdirectory.FullName + "\\Files" + @"\Items.txt";
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
                list.AddToAvailableItemsList(new Item(name, description, quantity, price, weight, category));
            }
        }

        private void listAllItemsInMainWindowBody()
        {
            foreach (Item item in list.GetAvailableItemList())
            {
                Label toyName = new Label();
                Label saldo = new Label();
                CheckBox checkbox = new CheckBox();
                checkbox.MaxWidth = 15;
                checkbox.MaxHeight = 15;
                toyName.Content = item.Name;

                toyName.Style = (Style)Resources["ItemLabel"];
                saldo.Content = item.Quantity;
                /*if (item.getCategory().Equals("Outdoor"))
                {
                    addContentToStackPanelByCategory("outdoor", item);
                }*/
                if (item.Category.Equals("Big"))
                {
                    addContentToStackPanelByCategory("big", item);
                }
                if (item.Category.Equals("Small"))
                {
                    addContentToStackPanelByCategory("small", item);
                   
                }
            }
        }

      public void addContentToStackPanelByCategory(string listType, Item item)
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            StackPanel stack = new StackPanel();
            TextBlock textBlock = new TextBlock();
            Button button = new Button();
            System.Windows.Controls.Image image = new System.Windows.Controls.Image()
            {
                Name = "pic",
                Source = new BitmapImage(new Uri("pack://application:,,,/Images/thunder.png")),
                Stretch = Stretch.Uniform
            };
            image.Height = 30;
            image.Width = 30;

            textBlock.Text = item.Name;
            textBlock.ToolTip = item.Description;
            textBlock.Style = (Style)Resources["itemName"];

            button.Style = (Style)Resources["itemButton"];

            stack.Orientation = Orientation.Horizontal;
            stack.Children.Add(textBlock);
            stack.Children.Add(image);
            stack.Children.Add(button);

            listBoxItem.Content = stack;
            if (listType.Equals("small"))
            {
                smallList.Items.Add(listBoxItem);
            }
            if (listType.Equals("big"))
            {
                bigList.Items.Add(listBoxItem);
            }
            /*if (listType.Equals("outdoor"))
            {
                outdoorList.Items.Add(listBoxItem);
            }*/

        }


        private void readUsersFromFile()
        {
            string path = "C:\\Users\\linnea\\source\\repos\\TheStore\\Files\\Users.txt";
            string itemPath = path + @"\Items.txt";
            string[] readLine = File.ReadAllLines(path);

            foreach (string itemLine in readLine)
            {
                string[] itemData = itemLine.Split(',');
                string name = itemData[0];
                string password = itemData[1];
                string email = itemData[2];
                string address = itemData[3];
                double phone = Convert.ToDouble(itemData[4]);
                list.AddToUserList(new User(name, password, email, address, phone));
            }
        }


        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            int quantityToBuy = 1;


            editItemInFile((Item)list.GetAvailableItemList().ElementAt(0), quantityToBuy, list.GetAvailableItemList().IndexOf(list.GetAvailableItemList().ElementAt(0)));
            string näjm = list.GetAvailableItemList().ElementAt(0).Name;

            MessageBox.Show("You just bought " + quantityToBuy + " of the first listed toy which was the " + näjm + Environment.NewLine + ""); ;

        }


        private void outdoorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox box = (ListBox)sender;
            Item addedItem = (Item)box.SelectedItem;
            list.AddToShoppingCartList(addedItem);
            MessageBox.Show(addedItem.Name + " added to shopping cart");
            string cartList = "";
            foreach (Item item in list.GetShoppingCartList())
            {
                cartList += item.Name + " ";
            }
            MessageBox.Show("Shoppingcart cointains: " + cartList);

        }



        private void ReadFromFile_Click(object sender, RoutedEventArgs e)
        {
            fileManager.readFromFile("Users", list.GetUserList());
        }

        private void WriteToFile_Click(object sender, RoutedEventArgs e)
        {
            fileManager.writeToFile("Users", list.GetUserList());
        }
    }
}
