using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class DepthFirstIterator : IIterator<LightNode>
    {
        private readonly LightElementNode _root;
        private readonly Stack<IEnumerator<LightNode>> _stack = new();
        public LightNode Current { get; private set; }

        public DepthFirstIterator(LightElementNode root)
        {
            _root = root;
            Reset();
        }

        public bool MoveNext()
        {
            while (_stack.Count > 0)
            {
                var it = _stack.Peek();
                if (!it.MoveNext())
                {
                    _stack.Pop();
                    continue;
                }
                Current = it.Current;
                if (Current is LightElementNode el)
                    _stack.Push(el.Children.GetEnumerator());
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _stack.Clear();
            _stack.Push(new List<LightNode> { _root }.GetEnumerator());
            Current = null;
        }
    }
}
