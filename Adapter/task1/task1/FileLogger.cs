using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
   public class FileLogger:ILogger
    {
        FileWriter fileWriter;
        public FileLogger() => this.fileWriter = new FileWriter();
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            fileWriter.WriteLine(message);
            Console.ResetColor();
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            fileWriter.WriteLine(message);
            Console.ResetColor();
        }
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            fileWriter.WriteLine(message);
            Console.ResetColor();
        }
    }

}
