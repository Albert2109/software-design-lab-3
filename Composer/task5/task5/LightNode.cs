using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public abstract class LightNode
    {
        protected LightNode()
        {
            OnCreated();
        }

        public string Render(int indentLevel = 0)
        {
            OnBeforeApplyStyles();
            ApplyStyles();
            OnStylesApplied();

            OnBeforeApplyClasses();
            ApplyClassList();
            OnClassListApplied();

            var output = RenderCore(indentLevel);
            OnAfterRender(output);
            return output;
        }

        protected abstract string RenderCore(int indentLevel);

        protected virtual void ApplyStyles() { }
        protected virtual void ApplyClassList() { }

        protected virtual void OnCreated() { Console.WriteLine($"{GetType().Name} created."); }
        protected virtual void OnInserted(LightElementNode parent) { }
        protected virtual void OnRemoved(LightElementNode parent) { }

        protected virtual void OnBeforeApplyStyles() { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnBeforeApplyClasses() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnAfterRender(string renderedHtml) { }

        internal void InsertInto(LightElementNode parent)
        {
            parent.InternalAddChild(this);
            OnInserted(parent);
        }

        internal void RemoveFrom(LightElementNode parent)
        {
            parent.InternalRemoveChild(this);
            OnRemoved(parent);
        }
    }
}
