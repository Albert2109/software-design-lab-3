using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class NetworkImageLoad:IImageLoad
    {
        public byte[] Load(string path)
        {
            Console.WriteLine($"Downloading from URL: {path}");
            using var client = new HttpClient();
            return client.GetByteArrayAsync(path).Result;
        }
    }
}
