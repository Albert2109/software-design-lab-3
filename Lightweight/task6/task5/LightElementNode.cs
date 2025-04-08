using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightElementNode:LightNode
    {
        public string TagName { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName)
        {
            TagName = tagName;
            Children = new List<LightNode>();
        }

        public void AddChild(LightNode child) => Children.Add(child);

        public override string OuterHTML => $"<{TagName}>{string.Join("", Children.Select(c => c.OuterHTML))}</{TagName}>";

        public LightElementNode Clone()
        {
            return new LightElementNode(TagName);
        }
    }
}
