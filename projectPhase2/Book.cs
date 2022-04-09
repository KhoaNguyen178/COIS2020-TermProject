using System;
using System.Collections;
using System.Collections.Generic;
namespace projectPhase2
{
    public class Book : IObservable, IBookFacade
    {
        private string name;
        private string category;
        private string author;
        private string publisher;
        Queue<IObserver> observerList = new Queue<IObserver>();
        private int flag;
        public Book(string _name, string _category, string _author, string _publisher)
        {
            this.name = _name;
            this.category = _category;
            this.author = _author;
            this.publisher = _publisher;
        }
        //properties
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                // Flag value changed. So notify observer(s).
                NotifyRegisteredObserver();
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        //methods
        public string getCategory()
        {
            return category;
        }

        public string getName()
        {
            return name;
        }
        public string getAuthor()
        {
            return author;
        }

        public string getPublisher()
        {
            return publisher;
        }

        public void Register(IObserver anObserver)
        {
            observerList.Enqueue(anObserver);
        }
        // To unregister a subscriber.
        public void Unregister()
        {
            observerList.Dequeue();
            flag -= 1;
            NotifyRegisteredObserver();
        }
        // Notify all registered observers.
        public void NotifyRegisteredObserver()
        {
            foreach (IObserver observer in observerList)
            {
                observer.Update(this);
            }
        }
        //method to print out books details
        public override string ToString()
        {
            return "\nName: " + name + "\nCategory: " + category + "\nAuthor: " + author + "\nPublisher: " + publisher;
        }
    }
}

