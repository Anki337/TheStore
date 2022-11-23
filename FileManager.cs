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
 
        TheStoreLists list = new TheStoreLists();
        private string getPathAddress(string fileName)
        {
            if (fileName == "Users")
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
            else if (fileName == "TestFile")
            {
                return TestFilePath;
            }
            else
            {
                return null;
            }
        }
        public void readFromFile<T>(string fileName, List<T> listName) where T : IParse<T>, new()
        {
            string path = getPathAddress(fileName);
            T thing = new T();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                    
                    listName.Add(thing.parse(line.Split(',')));  
                    
            }
            catch (Exception e) { 
                MessageBox.Show(e.Message);
            }
            foreach (T t in listName)
                Console.WriteLine(t);
        }

        internal void writeToFile<T>(string fileName, List<T> listName)
        {
            string path = getPathAddress(fileName);
            string line = "";
      
            foreach(T thing in listName)
                line += thing.ToString();
               
            File.WriteAllText(path, line);
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
