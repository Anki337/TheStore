using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace TheStore
{
    internal class FileManager
    {
        static readonly string UserPath = "C:\\Users\\linnea\\Source\\Repos\\TheStore\\Files\\Users.txt";
        static readonly string ItemsPath = "C:\\Users\\linnea\\Source\\Repos\\TheStore\\Files\\Items.txt";
        static readonly string ShippingInfoPath = "C:\\Users\\linnea\\Source\\Repos\\TheStore\\Files\\ShippingInfo.txt";
        static readonly string TestFilePath = "C:\\Users\\linnea\\Source\\Repos\\TheStore\\Files\\TestFile.txt";

        //DirectoryInfo currentdirectory = new DirectoryInfo(".");
        //string itemPath = currentdirectory.FullName + "\\Files" + @"\Items.txt";

        TheStoreLists list = new TheStoreLists();
        MessageBox messagebox;
        private string getPathAddress(string fileName)
        {
            if (fileName == "User")
            {
                return UserPath;
            }
            else if (fileName == "Items")
            {
                return ItemsPath;
            }
            else if (fileName == "ShippingInfo")
            {
                return ShippingInfoPath;
            }
            else {
                return null;
            }
        }
        public void readFromFile(string fileName, List<Object> listName, IParse p)
        {
            //string path = getPathAddress(fileName);
            string path = TestFilePath;
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                    
                    listName.Add(p.parse(line.Split(',')));  
                    
            }
            catch (Exception e) { 
                MessageBox.Show(e.Message);
            }
            foreach (User user in listName)
                Console.WriteLine(user);
        }

        internal void readToFile(string fileName, List<Object> listName, IParse p)
        {
            //string path = getPathAddress(fileName);
            string path = TestFilePath;
            File.WriteAllLines(path, p.toStringArray(listName));
           
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


    }
}
