using System;

namespace projectPhase2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Adding book to the library.***\n");
            //Singleton Pattern
            Library group2 = Library.Instance;
            Book[] a =
            {
                new Book("Computer Organization and Design","CS","David","MacMillan"),
                new Book("Data Structures and Algorithm","CS","Tom","New York's Times"),
                new Book("Introduction to probability","Math","Alice","Oxford"),
                new Book("Object-oriented Software Engineering","CS","Canorus","Pearson"),
            };
            foreach (var c in a)
            {
                group2.addBook(c.getName(), c.getCategory(), c.getAuthor(), c.getPublisher());
            }
            Console.ReadLine();

            //Sorting Algorithm Demonstration
            Console.WriteLine("***Sorting Algorithm.***\n");
            group2.displayBookInfo();
            Console.ReadLine();

            //Observer Pattern Demonstration
            Console.WriteLine("***Observer Pattern Demonstration.***\n");
            // We have 4 observers - 2 of them are ObserverType1, 1 is of
            // ObserverType2
            IObserver myObserver1 = new Student("Roy");
            IObserver myObserver2 = new Student("Kevin");
            IObserver myObserver3 = new Staff("Bose");
            Console.WriteLine("Subscribe a person to a book now.\n");

            // Registering the observers - Roy, Kevin, Bose
            a[1].Register(myObserver1);
            a[1].Register(myObserver2);
            a[1].Register(myObserver3);
            Console.WriteLine($"{a[1].getName()} currently has 5 copies available.\n");
            a[1].Flag = 5;
            Console.ReadLine();
            /*
            The list of subscriber is a queue,
            We make an assumption that the first person in the list 
            would be prioritized to get the book after getting notified.
            */
            Console.WriteLine("A student has gotten themself a copy; they are removed from the subscriber list now.\n");
            a[1].Unregister();
            // No notification is sent to Roy this time. He has
            // unregistered.

        }
    }
}
