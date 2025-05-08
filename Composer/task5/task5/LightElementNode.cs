using System;
using System.Collections.Generic;
using System.Linq;

namespace task5
{
    public class LightElementNode : LightNode, IAggregate<LightNode>
    {
        public string TagName { get; }
        public bool IsSelfClosing { get; }

        
        public List<string> CssClasses { get; } = new List<string>();
        public Dictionary<string, string> Attributes { get; } = new Dictionary<string, string>();

        
        public List<LightNode> Children { get; } = new List<LightNode>();

        public LightElementNode(string tagName, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsSelfClosing = isSelfClosing;
        }

        public void AddClass(string className) => CssClasses.Add(className);
        public void AddChild(LightNode child) => Children.Add(child);
        public void RemoveChild(LightNode child) => Children.Remove(child);

        public override string OuterHTML
        {
            get
            {
                var classAttr = CssClasses.Any()
                    ? $" class=\"{string.Join(" ", CssClasses)}\""
                    : string.Empty;
                var otherAttrs = Attributes.Any()
                    ? string.Concat(Attributes.Select(kv => $" {kv.Key}=\"{kv.Value}\""))
                    : string.Empty;

                if (IsSelfClosing)
                    return $"<{TagName}{classAttr}{otherAttrs} />";

                return $"<{TagName}{classAttr}{otherAttrs}>{InnerHTML}</{TagName}>";
            }
        }

        public override string InnerHTML
            => string.Concat(Children.Select(c => c.OuterHTML));

        
        public IIterator<LightNode> CreateIterator() => new DepthFirstIterator(this);

        
        public override void Accept(ILightVisitor visitor) => visitor.Visit(this);
    }
}