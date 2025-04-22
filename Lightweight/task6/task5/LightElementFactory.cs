using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightElementFactory
    {
        private static Dictionary<string, LightElementNode> _elementTemplates = new Dictionary<string, LightElementNode>();

        public static LightElementNode CreateElement(string tagName)
        {
            if (!_elementTemplates.ContainsKey(tagName))
            {
                _elementTemplates[tagName] = new LightElementNode(tagName);
            }
            return _elementTemplates[tagName].Clone(); 
        }
    }
}
