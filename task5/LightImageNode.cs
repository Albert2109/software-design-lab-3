using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightImageNode:LightNode
    {
        public string path { get; }
        private readonly string _srcData;
        public LightImageNode(string path)
        {
            this.path = path;
            IImageLoad strategy = path.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? new NetworkImageLoad()
                : new FileImageLoad();

            byte[] data = strategy.Load(path);
            string mime = Path.GetExtension(path).ToLower() switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                _ => "image/png"
            };

            
            string base64 = Convert.ToBase64String(data);
            _srcData = $"data:{mime};base64,{base64}";
        }
        public override string OuterHTML => $"<img src=\"{_srcData}\"/>";
        public override string InnerHTML => string.Empty;
    }
}
