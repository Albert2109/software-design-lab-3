using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public bool IsBlock { get; }
        public bool IsSelfClosing { get; }
        public List<string> CssClasses { get; } = new List<string>();
        public List<LightNode> Children { get; } = new List<LightNode>();

        public Dictionary<string, string> Attributes { get; } = new Dictionary<string, string>();

        public LightElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
        }

        public void AddClass(string cn) => CssClasses.Add(cn);
        public void AddChild(LightNode child) => Children.Add(child);

        public override string OuterHTML
        {
            get
            {
                var cls = CssClasses.Any() ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
                var attrs = string.Concat(Attributes.Select(kv => $" {kv.Key}=\"{kv.Value}\""));
                if (IsSelfClosing)
                    return $"<{TagName}{cls}{attrs} />";
                return $"<{TagName}{cls}{attrs}>{InnerHTML}</{TagName}>";
            }
        }
        public override string InnerHTML
            => string.Concat(Children.Select(c => c.OuterHTML));

        public override void Accept(ILightVisitor visitor)
            => visitor.Visit(this);
    }
}
