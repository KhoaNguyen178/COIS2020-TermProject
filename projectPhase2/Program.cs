using System;

namespace projectPhase2
{
    class Program
    {
        static void Main(string[] args)
        {
            Library group2 = Library.Instance;
            Book[] a =
            {
                new Book("Computer Organization and Design","CS","David","MacMillan"),
                new Book("Data Structures and Algorithm","CS","Tom",""),
                new Book("Introduction to probability","Math","Rivem","Oxford"),
                new Book("Object-oriented Software Engineering","CS","Jason","Pearson"),
            };

            foreach (var c in a)
            {
                group2.addBook(c.getName(), c.getCategory(), c.getAuthor(), c.getPublisher());
            }

            Console.WriteLine();
            Console.WriteLine("***Sorting Algorithm.***\n");

            Console.WriteLine("List of books in the library are: \n");
            group2.displayBookInfo();

            Console.WriteLine();
            Console.WriteLine("***Observer Pattern Demonstration.***\n");
            // We have 4 observers - 2 of them are ObserverType1, 1 is of
            // ObserverType2
            IObserver myObserver1 = new ObserverType1("Roy");
            IObserver myObserver2 = new ObserverType1("Kevin");
            IObserver myObserver3 = new ObserverType2("Bose");
            IObserver myObserver4 = new ObserverType2("Jacklin");
            Console.WriteLine("Subscribe a person to a book now.");
            ICelebrity book1 = new Book("Metamorphosis","Kafka","","");
            // Registering the observers - Roy, Kevin, Bose
            book1.Register(myObserver1);
            book1.Register(myObserver2);
            book1.Register(myObserver3);
            Console.WriteLine(" Book 1 currently has 5 copies available.");
            book1.Flag = 5;
            /*
            Kevin doesn't want to get further notification.
            So, unregistering the observer(Kevin)).
            */
            Console.WriteLine("\nKevin is no longer interested in borrowing this book. He is removed from the subscriber list now.");
            book1.Unregister(myObserver2);
            // No notification is sent to Kevin this time. He has
            // unregistered.
            Console.WriteLine("\n Book 1 currently has 50 copies available.");
            book1.Flag = 50;
            // Kevin is registering himself again
            book1.Register(myObserver2);
            Console.WriteLine("\n Book 1 currently has 100 copies available.");
            book1.Flag = 100;

        }
    }
}
