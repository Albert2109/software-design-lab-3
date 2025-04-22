using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task4
{
    internal class SmartTextReaderLocker : SmartTextReader
    {
        private Regex _restrictionPattern;
        private string _filePath;

        public SmartTextReaderLocker(string filePath, string restrictionPattern) : base(filePath)
        {
            _filePath = filePath;
            _restrictionPattern = new Regex(restrictionPattern, RegexOptions.IgnoreCase);
        }

        public new char[][] ReadFile()
        {
            if (_restrictionPattern.IsMatch(_filePath))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }
            return base.ReadFile();
        }
    }
}
