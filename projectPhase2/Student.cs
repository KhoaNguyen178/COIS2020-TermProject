using System;
using System.Collections.Generic;
using System.Text;

namespace projectPhase2
{
    //Observer pattern, student is a type of observer
    class Student : IObserver
    {
        string nameOfObserver;
        public Student(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(IObservable book)
        {
            Console.WriteLine($"Student {nameOfObserver} has received an alert from{ book.Name}. There are {book.Flag} copies available for borrow.");
        }
    }
}
