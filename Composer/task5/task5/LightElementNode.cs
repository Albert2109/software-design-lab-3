using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightElementNode : LightNode, IAggregate<LightNode>
    {
        public string TagName { get; }
        public bool IsSelfClosing { get; }
        public List<string> Classes { get; }
        public List<LightNode> Children { get; }
        public LightElementNode(string tagName, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsSelfClosing = isSelfClosing;
            Classes = new List<string>();
            Children = new List<LightNode>();
        }
        public void AddClass(string cls) => Classes.Add(cls);
        public void AddChild(LightNode child) => Children.Add(child);
        public override string OuterHTML
        {
            get
            {
                var cls = Classes.Any() ? $" class=\"{string.Join(" ", Classes)}\"" : string.Empty;
                if (IsSelfClosing) return $"<{TagName}{cls}/>";
                return $"<{TagName}{cls}>{InnerHTML}</{TagName}>";
            }
        }
        public override string InnerHTML => string.Concat(Children.Select(c => c.OuterHTML));

        public IIterator<LightNode> CreateIterator() => new DepthFirstIterator(this);
    }
}
