using System;

namespace task5
{
    public class LightTextNode : LightNode
    {
        private readonly string _text;

        public LightTextNode(string text) : base()
        {
            _text = text;
        }

        protected override string RenderCore(int indentLevel)
        {
            var indent = new string(' ', indentLevel);
            OnBeforeTextRendered();
            var result = indent + _text;
            OnTextRendered(result);
            return result;
        }

        protected virtual void OnBeforeTextRendered() { }
        protected virtual void OnTextRendered(string text)
        {
            Console.WriteLine($"Text rendered: {text}");
        }

      
        public override void Accept(ILightVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
