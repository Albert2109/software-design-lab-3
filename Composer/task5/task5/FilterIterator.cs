using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class FilterIterator<T> : IIterator<T>
    {
        private readonly IIterator<T> _inner;
        private readonly Func<T, bool> _predicate;
        public T Current { get; private set; }

        public FilterIterator(IIterator<T> inner, Func<T, bool> predicate)
        {
            _inner = inner;
            _predicate = predicate;
            _inner.Reset();
        }

        public bool MoveNext()
        {
            while (_inner.MoveNext())
            {
                var item = _inner.Current;
                if (_predicate(item))
                {
                    Current = item;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            _inner.Reset();
            Current = default;
        }
    }
}
