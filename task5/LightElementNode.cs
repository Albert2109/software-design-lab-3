using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightElementNode:LightNode,ISubject
    {
        public string TagName { get; }
        public bool IsBlock { get; }
        public bool IsSelfClosing { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }
        private readonly Dictionary<string, List<IObserver>> _observers
          = new Dictionary<string, List<IObserver>>();
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

       

       
        public void Attach(string eventName, IObserver observer)
        {
            if (!_observers.ContainsKey(eventName))
                _observers[eventName] = new List<IObserver>();
            _observers[eventName].Add(observer);
        }

        public void Detach(string eventName, IObserver observer)
        {
            if (_observers.TryGetValue(eventName, out var list))
                list.Remove(observer);
        }

        public void Notify(string eventName)
        {
            if (_observers.TryGetValue(eventName, out var list))
            {
                foreach (var observer in list)
                    observer.Update(eventName, this);
            }
        }
        public void DispatchEvent(string eventName) => Notify(eventName);
        public override string OuterHTML
        {
            get
            {
                var classAttr = CssClasses.Any()
                    ? $" class=\"{string.Join(" ", CssClasses)}\""
                    : string.Empty;
                if (IsSelfClosing)
                    return $"<{TagName}{classAttr}/>";
                return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
            }
        }

        public override string InnerHTML => string.Concat(Children.Select(c => c.OuterHTML));
    }
}
