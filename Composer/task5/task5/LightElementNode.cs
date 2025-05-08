using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task5
{
    public class LightElementNode : LightNode, IAggregate<LightNode>
    {
        public string TagName { get; }
        public bool IsSelfClosing { get; }

        public List<string> CssClasses { get; }
        public Dictionary<string, string> Attributes { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, bool isSelfClosing = false)
            : base()
        {
            TagName = tagName;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            Attributes = new Dictionary<string, string>();
            Children = new List<LightNode>();
        }

        public void AddClass(string className) => CssClasses.Add(className);
        public void AddChild(LightNode child) => child.InsertInto(this);
        public void RemoveChild(LightNode child) => child.RemoveFrom(this);

        internal void InternalAddChild(LightNode child) => Children.Add(child);
        internal void InternalRemoveChild(LightNode child) => Children.Remove(child);

        
        protected override void ApplyStyles()
        {
           
        }

        protected override void ApplyClassList()
        {
            Console.WriteLine($"Applying class list: {string.Join(" ", CssClasses)} to <{TagName}>");
        }

        protected override void OnInserted(LightElementNode parent)
        {
            Console.WriteLine($"<{TagName}> inserted into <{parent.TagName}>");
        }

        protected override void OnRemoved(LightElementNode parent)
        {
            Console.WriteLine($"<{TagName}> removed from <{parent.TagName}>");
        }

        protected override string RenderCore(int indentLevel)
        {
            var indent = new string(' ', indentLevel);
            var classAttr = CssClasses.Any() ? $" class=\"{string.Join(" ", CssClasses)}\"" : string.Empty;
            var otherAttrs = Attributes.Any() ? string.Concat(Attributes.Select(kv => $" {kv.Key}=\"{kv.Value}\"")) : string.Empty;

            if (IsSelfClosing)
                return indent + $"<{TagName}{classAttr}{otherAttrs}/>";

            var sb = new StringBuilder();
            sb.AppendLine(indent + $"<{TagName}{classAttr}{otherAttrs}>");
            foreach (var child in Children)
                sb.AppendLine(child.Render(indentLevel + 2));
            sb.Append(indent + $"</{TagName}>");
            return sb.ToString();
        }

        public IIterator<LightNode> CreateIterator() => new DepthFirstIterator(this);

        public override void Accept(ILightVisitor visitor) => visitor.Visit(this);
    }
}