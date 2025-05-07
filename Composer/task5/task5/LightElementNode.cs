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
        public bool IsSelfClosing { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, bool isSelfClosing = false) : base()
        {
            TagName = tagName;
            IsSelfClosing = isSelfClosing;
            CssClasses = new();
            Children = new();
        }

        public void AddClass(string className) => CssClasses.Add(className);

        public void AddChild(LightNode child) => child.InsertInto(this);

        public void RemoveChild(LightNode child) => child.RemoveFrom(this);

        internal void InternalAddChild(LightNode child) => Children.Add(child);
        internal void InternalRemoveChild(LightNode child) => Children.Remove(child);

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
            var classAttr = CssClasses.Any() ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";

            if (IsSelfClosing)
                return indent + $"<{TagName}{classAttr}/>";

            var sb = new StringBuilder();
            sb.AppendLine(indent + $"<{TagName}{classAttr}>");
            foreach (var child in Children)
                sb.AppendLine(child.Render(indentLevel + 2));
            sb.Append(indent + $"</{TagName}>");
            return sb.ToString();
        }
    }
}
