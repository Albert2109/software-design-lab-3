using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextReader
    {
        private string _filePath;

        public SmartTextReader(string filePath)
        {
            _filePath = filePath;
        }

        public char[][] ReadFile()
        {
            string[] lines = File.ReadAllLines(_filePath);
            char[][] result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }
            return result;
        }
    }
}
