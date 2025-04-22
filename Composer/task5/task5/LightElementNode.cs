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
        public bool IsBlock { get; }
        public bool IsSelfClosing { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public void AddClass(string className) => CssClasses.Add(className);
        public void AddChild(LightNode child) => Children.Add(child);

        public override string OuterHTML
        {
            get
            {
                string classAttribute = CssClasses.Any() ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
                if (IsSelfClosing)
                    return $"<{TagName}{classAttribute}/>";
                return $"<{TagName}{classAttribute}>{InnerHTML}</{TagName}>";
            }
        }

        public override string InnerHTML => string.Join("", Children.Select(child => child.OuterHTML));
    }
}
