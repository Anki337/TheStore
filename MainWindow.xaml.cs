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
        private List<User> userList = new List<User>();
        private List<Item> availableItemList = new List<Item>();
        private List<Item> myCart = new List<Item>();
        private User[] loggedInUser; //= new User[1];

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            ShowData();
        }
        private void LoadData()
        {
            fileManager.readFromFile("Items", list.GetAvailableItemList());
            fileManager.readFromFile("Items", availableItemList);
            fileManager.readFromFile("Users", list.GetUserList());
            fileManager.readFromFile("Users", userList);
            
            //User user1 = new User("Max", "bananer", "max@max.com", "Stan", 0735040590); //test User
            //list.AddToUserList(user1); //for testing
            //user1.LoggedIn = true; //for testing, will be set in loggin
        }

        private void ShowData()
        {
            outdoorList.ItemsSource = list.GetAvailableItemList();
            outdoorList.Items.Refresh();
            listAllItemsInMainWindowBody();
            
        }
        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            string mail = mailBox.Text;
            string password = pwBox.Password;

            foreach (User user in userList)
            {
                if (mail.Equals(user.Email) && password.Equals(user.Password))
                {
                    User[] loggedInUser = {user};
                    userList.Remove(user);
                    mailBox.Visibility = Visibility.Collapsed;
                    pwBox.Visibility = Visibility.Collapsed;
                    userNameText.Text = " back " + user.Name;
                    shoppingCart.Visibility = Visibility.Visible;
                    logButton.Visibility = Visibility.Collapsed;
                    createButton.Visibility = Visibility.Collapsed;
                    logOutButton.Visibility = Visibility.Visible;
                }
            }
        }
        private void createButton_Click(object sender, RoutedEventArgs e)
        {

            CreateNewUser createNewUser = new CreateNewUser(this, userList, loggedInUser);
            createNewUser.Show();
            this.Hide();
        }


        private void shoppingCart_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(this, myCart, loggedInUser);
            orderWindow.Show();
            this.Hide();

        }
        private  void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            mailBox.Visibility = Visibility.Visible;
            pwBox.Visibility = Visibility.Visible;
            User[] loggedInUser = { null };
            userNameText.Text = "";
            logButton.Visibility = Visibility.Visible;
            createButton.Visibility = Visibility.Visible;
            logOutButton.Visibility = Visibility.Collapsed;
            shoppingCart.Visibility = Visibility.Hidden;

        }

        private void listAllItemsInMainWindowBody()
        {
            foreach (Item item in availableItemList)
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
                    addContentToStackPanelByCategory(bigList, item);
                }
                if (item.Category.Equals("Small"))
                {
                    addContentToStackPanelByCategory(smallList, item);
                   
                }
            }
        }

      public void addContentToStackPanelByCategory(ListBox listType, Item item)
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            DockPanel dock = new DockPanel();
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
            
            

            dock.Children.Add(textBlock);
            dock.Children.Add(image);
            dock.Children.Add(button);
            DockPanel.SetDock(textBlock,Dock.Left);
            //DockPanel.SetDock(image,Dock.Top);
            DockPanel.SetDock(button,Dock.Right);

            listBoxItem.Content = dock;
            listType.Items.Add(listBoxItem);
            /*if (listType.Equals("small"))
            {
                smallList.Items.Add(listBoxItem);
            }
            if (listType.Equals("big"))
            {
                bigList.Items.Add(listBoxItem);
            }
            if (listType.Equals("outdoor"))
            {
                outdoorList.Items.Add(listBoxItem);
            }*/
        }

        

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            int quantityToBuy = 1;
            string näjm = availableItemList[0].Name;
            //OrderWindow orderWindow = new OrderWindow(this, myCart, loggedInUser);
            //orderWindow.Show();
            //this.Hide();
            MessageBox.Show("You just bought " + quantityToBuy + " of the first listed toy which was the " + näjm + Environment.NewLine + "");
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

        //these are testbuttons that are called from MainWindow (footer)
        //FEEL FREE to use these testbuttons for implementation testing!
        private void Test1_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in userList)
            {
                Console.WriteLine(user.ToString());
            }
        }
        private void Test2_Click(object sender, RoutedEventArgs e)
        {
            fileManager.writeToFile("Users", list.GetUserList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            DockPanel dock = (DockPanel)butt.Parent;
            TextBlock itenName = (TextBlock)dock.Children[0];
            string name = itenName.Text;
            foreach(Item item in list.GetAvailableItemList())
            {
                if (item.Name.Equals(name))
                {
                    Item clonedItem = item.clone();
                    clonedItem.Quantity = 1;
                    list.AddToShoppingCartList(clonedItem);
                    list.EditQuantityInItem(name);
                    MessageBox.Show(item.Name + " added to shopping cart" + "current quantity is: " + item.Quantity);
                }
            }
            
        }
    }
}
