using System;
using System.Collections.Generic;
using System.Text;

namespace projectPhase2
{
    class ObserverType2 : IObserver
    {
        string nameOfObserver;
        public ObserverType2(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(ICelebrity book)
        {

            Console.WriteLine($"{nameOfObserver} notified.Inside {book.Name}, the updated value is: {book.Flag}");
        }
    }
}
