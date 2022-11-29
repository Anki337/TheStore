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
    /// <summary>
    /// Filereader/-writer for classes implementing IParse
    /// </summary>
    internal class FileManager
    {
        static DirectoryInfo currentdirectory = new DirectoryInfo(".");
        TheStoreLists list = new TheStoreLists();
        public void readFromFile<T>(string fileName, List<T> listName) where T : IParse<T>, new() //Reads a file fileName.txt and creates a list listName<Item> or listName<User>
        {
            string path = currentdirectory.FullName + "\\Files" + @"\" + fileName + ".txt";
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
        internal void writeToFile<T>(string fileName, List<T> listName) //Writes a list listName<Item> or listName<User> to file fileName.txt
        {
            string path = currentdirectory.FullName + "\\Files\\" + fileName + ".txt";
            string line = null;
      
            foreach(T thing in listName)
                line += thing.ToString();
               
            File.WriteAllText(path, line);
        }
    }
}
