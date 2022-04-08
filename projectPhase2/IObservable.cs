using System;
using System.Collections.Generic;
using System.Text;
namespace projectPhase2
{
    public interface IObservable
    {
        // Name of Subject
        string Name { get; }
        int Flag { get; set; }
        // To register
        void Register(IObserver o);
        // To Unregister
        void Unregister();
        // To notify registered users
        void NotifyRegisteredObserver();
    }
}
