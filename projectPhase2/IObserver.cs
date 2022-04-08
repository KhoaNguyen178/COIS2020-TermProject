using System;
using System.Collections.Generic;
using System.Text;
namespace projectPhase2
{
    public interface IObserver
    {
        void Update(ICelebrity subject);
    }
}
