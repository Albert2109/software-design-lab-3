using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace task4
{
    public class SmartTextChecker:SmartTextReader
    {
        public SmartTextChecker(string filePath) : base(filePath) { }

        public new char[][] ReadFile()
        {
            Console.WriteLine("Opening file...");
            char[][] content = base.ReadFile();
            Console.WriteLine("File read successfully.");
            Console.WriteLine($"Total lines: {content.Length}");
            Console.WriteLine($"Total characters: {content.Sum(line => line.Length)}");
            Console.WriteLine("Closing file...");
            return content;
        }
    }
}
