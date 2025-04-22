using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class FileWriter:IFileWriter
    {
        private string filename = Path.GetFullPath("file.txt");

        public void ClearFile()
        {
            File.WriteAllText(filename, string.Empty); 
            Console.WriteLine("Файл очищено!");
        }

        public void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter(filename, true)) 
            {
                sw.Write(text + " ");
            }
           
        }

        public void WriteLine(string text)
        {
            using (StreamWriter sw = new StreamWriter(filename, true)) 
            {
                sw.WriteLine(text);
            }
          
        }
    }
}
