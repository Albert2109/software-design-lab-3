using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public interface ISubject
    {
        void Attach(string eventName, IObserver observer);
        void Detach(string eventName, IObserver observer);
        void Notify(string eventName);
    }
}
