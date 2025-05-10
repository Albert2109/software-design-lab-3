using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class EventObserver: IObserver
    {
        private readonly Action<string, LightElementNode> _handler;
        public EventObserver(Action<string, LightElementNode> handler) => _handler = handler;
        public void Update(string eventName, LightElementNode element) => _handler(eventName, element);
    }
}
