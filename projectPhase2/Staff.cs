using System;
using System.Collections.Generic;
using System.Text;

namespace projectPhase2
{
    class Staff : IObserver
    {
        string nameOfObserver;
        public Staff(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(IObservable book)
        {

            Console.WriteLine($"Staff member {nameOfObserver} notified. For {book.Name}, the number of copies is: {book.Flag}");
        }
    }
}
