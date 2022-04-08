using System;
using System.Collections.Generic;
using System.Text;

namespace projectPhase2
{
    class ObserverType1 : IObserver
    {
        string nameOfObserver;
        public ObserverType1(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(ICelebrity book)
        {
            Console.WriteLine($"{nameOfObserver} has received an alert from{ book.Name}. Updated value is: {book.Flag}");
        }
    }
}
