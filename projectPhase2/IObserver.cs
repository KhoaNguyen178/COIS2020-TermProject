using System;
using System.Collections.Generic;
using System.Text;
namespace projectPhase2
{
    //Observer Pattern, IObserver Interface
    public interface IObserver
    {
        void Update(IObservable subject);
    }
}
