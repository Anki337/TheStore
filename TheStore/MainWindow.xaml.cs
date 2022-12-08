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
using System.Security;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace TheStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> userList = new List<User>();
        private List<Item> allItems = new List<Item>();
        private List<Item> myCart = new List<Item>();
        private User[] loggedInUser = new User[1];


        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            ShowData();
        }
        private void LoadData()
        {
            FileManager fileManager = new FileManager();
            Thread mainThread = Thread.CurrentThread;
            Thread thread1 = new Thread(() => fileManager.readFromFile("Items", allItems));
            Thread thread2 = new Thread(() => fileManager.readFromFile("Users", userList));
            thread1.IsBackground = true;
            thread2.IsBackground = true;
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }

        private void ShowData()
        {
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
                    loggedInUser[0] = user;

                    mailBox.Visibility = Visibility.Collapsed;
                    pwBox.Visibility = Visibility.Collapsed;
                    userNameText.Text = " back " + loggedInUser[0].Name;
                    logButton.Visibility = Visibility.Collapsed;
                    createButton.Visibility = Visibility.Collapsed;
                    logOutButton.Visibility = Visibility.Visible;
                    if (user.IsAdmin == true)
                    {
                        adminButton.Visibility = Visibility.Visible;
                        ReloadItems.Visibility = Visibility.Visible;

                    }
                    /*if (adminList.Contains(user))
                    {
                    }*/
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

            if (loggedInUser[0] == null)
            {
                CreateNewUser createNewUser = new CreateNewUser(this, myCart, allItems);
                this.Hide();
                createNewUser.Show();
            }
            if (loggedInUser[0] != null)
            {
                OrderWindow orderWindow = new OrderWindow(this, myCart, loggedInUser, allItems);
                orderWindow.Show();
                this.Hide();
            }
        }
        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            mailBox.Visibility = Visibility.Visible;
            pwBox.Visibility = Visibility.Visible;
            loggedInUser[0] = null;
            userNameText.Text = "";
            logButton.Visibility = Visibility.Visible;
            createButton.Visibility = Visibility.Visible;
            logOutButton.Visibility = Visibility.Collapsed;
            adminButton.Visibility = Visibility.Collapsed;
            ReloadItems.Visibility = Visibility.Collapsed;
        }

        private void listAllItemsInMainWindowBody()
        {
            foreach (Item item in allItems)
            {
                Label toyName = new Label();
                Label saldo = new Label();
                CheckBox checkbox = new CheckBox();
                checkbox.MaxWidth = 15;
                checkbox.MaxHeight = 15;
                toyName.Content = item.Name;

                toyName.Style = (Style)Resources["ItemLabel"];
                saldo.Content = item.Quantity;
                if (item.Category.Equals("Outdoor"))
                {
                    addContentToStackPanelByCategory(outdoorList, item);
                }
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

            Grid itemgrid = new Grid();
            itemgrid.Width = 250;

            TextBlock textBlock = new TextBlock();
            textBlock.HorizontalAlignment = HorizontalAlignment.Left;
            Button button = new Button();
            button.HorizontalAlignment = HorizontalAlignment.Right;
            System.Windows.Controls.Image image;
            
            try
            {
                image = new System.Windows.Controls.Image()
                {
                    Name = "pic",
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/Toys/" + item.Name + ".png")),
                    Stretch = Stretch.Uniform
                };
            }
            catch
            {
                image = new System.Windows.Controls.Image()
                {
                    Name = "pic",
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/thunder.png")),
                    Stretch = Stretch.Uniform
                };
            }
            image.Height = 30;
            image.Width = 30;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.Text = item.Name;
            textBlock.ToolTip = item.Description;
            textBlock.Style = (Style)Resources["itemName"];
            button.Style = (Style)Resources["itemButton"];
            itemgrid.Children.Add(textBlock);
            itemgrid.Children.Add(image);
            itemgrid.Children.Add(button);
            listBoxItem.Content = itemgrid;
            listType.Items.Add(listBoxItem);
            if (item.Quantity <= 0)
            {
                textBlock.Foreground = Brushes.Red;
                itemgrid.Children.Remove(button);
                TextBlock soldOut = new TextBlock();
                soldOut.Text = "Sold Out";
                soldOut.FontSize = 14;
                soldOut.Foreground = Brushes.Red;
                soldOut.HorizontalAlignment = HorizontalAlignment.Right;
                itemgrid.Children.Add(soldOut);
            }
        }

        public void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (loggedInUser[0] == null)
            {
                CreateNewUser createNewUser = new CreateNewUser(this, myCart, allItems);
                this.Hide();
                createNewUser.Show();
            }
            if (loggedInUser[0] != null)
            {
                OrderWindow orderWindow = new OrderWindow(this, myCart, loggedInUser, allItems);
                orderWindow.Show();
                this.Hide();
            }
            //OrderWindow orderWindow = new OrderWindow(this, myCart, loggedInUser);
            //orderWindow.Show();
            //this.Hide();
        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button butt = (Button)sender;
            Grid grid = (Grid)butt.Parent;
            TextBlock itemName = (TextBlock)grid.Children[0];
            string name = itemName.Text;
            ListBoxItem listBoxItem = (ListBoxItem)grid.Parent;
            ListBox list = (ListBox)listBoxItem.Parent;
            foreach (Item item in allItems)
            {
                if (item.Name.Equals(name))
                {
                    Item clonedItem = item.clone();
                    clonedItem.Quantity = 1;
                    if (myCart.Count == 0)
                    {
                        myCart.Add(clonedItem);

                    }
                    else if (myCart.Count > 0)
                    {
                        bool newItem = true;
                        foreach (Item cartItem in myCart)
                        {
                            if (clonedItem.Name.Equals(cartItem.Name))
                            {
                                cartItem.Quantity++;
                                newItem = false;
                                break;
                            }
                        }
                        if (newItem)
                        {
                            myCart.Add(clonedItem);
                        }
                    }

                    item.Quantity--;
                    MessageBox.Show(item.Name + " added to shopping cart" + "current quantity is: " + item.Quantity);
                    if (item.Quantity <= 0)
                    {
                        itemName.Foreground = Brushes.Red;
                        grid.Children.Remove(butt);
                        TextBlock soldOut = new TextBlock();
                        soldOut.Text = "Sold Out";
                        soldOut.FontSize = 14;
                        soldOut.Foreground = Brushes.Red;
                        soldOut.HorizontalAlignment = HorizontalAlignment.Right;
                        grid.Children.Add(soldOut);
                        list.Items.Refresh();
                    }
                }
            }
        }

 

        private void mailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logButton_Click(this, e);
            }

        }

        private void shoppingCart_MouseEnter(object sender, MouseEventArgs e)
        {
            string tooltip = "Shoppingcart i empty. Click on a toy to add it to your cart!";
            if (myCart.Count > 0)
            {
                tooltip = "Toys in shoppingcart: \n";
                foreach (Item item in myCart)
                {
                    tooltip += item.Name.ToString() + "\n";
                }
            }
            shoppingCart.ToolTip = tooltip;
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin(this, allItems, userList);
            admin.Show();
            this.Hide();

        }

        private void ReloadItems_Click(object sender, RoutedEventArgs e)
        {

            outdoorList.Items.Clear();
            bigList.Items.Clear();
            smallList.Items.Clear();
            listAllItemsInMainWindowBody();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FileManager fm = new FileManager();
            fm.writeToFile("Users", userList);
            fm.writeToFile("Items", allItems);

        }
    }
}
