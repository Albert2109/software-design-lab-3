using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class FileImageLoad:IImageLoad
    {
        public byte[] Load(string path)
        {
            Console.WriteLine($"[FileStrategy] Loading from file: {path}");
            return File.ReadAllBytes(path);
        }
    }
}
