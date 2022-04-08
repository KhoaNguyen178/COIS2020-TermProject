using System;
using System.Collections.Generic;

namespace projectPhase2
{
    class Program
    {
        static List<Users> users = new List<Users>();
        static Library group2 = Library.Instance;
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (args[0] == "1")
                {
                    StartSystem();
                }
                //add other options here and below              
            }
            else
            {
                ShowingFunctionality();
            }

        }
        public static void LoadData()
        {
            users.Add(new Users("checking", "123", Permissions.User));
            users.Add(new Users("Gideon", "3333", Permissions.Admin));
            users.Add(new Users("Theodore", "1111", Permissions.Admin));
            users.Add(new Users("r", "123", Permissions.User));
        }

        public static void StartSystem()
        {
            Console.Clear();
            Users tempuser = new Users();
            LoadData();
            Console.WriteLine("Welcome to Library Management System. \nTo start, please log in.");


            bool successfull = false;
            do
            {
                Console.WriteLine("Please enter your username:");
                var username = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                var password = Console.ReadLine();
                foreach (Users user in users)
                {
                    if (username == user.username && password == user.password)
                    {
                        tempuser = user;
                        successfull = true;
                        break;
                    }
                }

                if (!successfull)
                {
                    Console.WriteLine("\nYour username and/or password is incorect. Please try again.");
                }
            } while (!successfull);

            StartUser(tempuser);

        }

        public static void StartUser(Users user)
        {
            Console.WriteLine($"Welcome back {user.username}.\nYou currently have {user.permissions} Permissions.");
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine($"\nTo add a new book please enter 1. \n" +
                $"To get information on a book enter 2. \nTo display all books enter 3. \nTo log out enter 4.");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Please enter the name of the book.");
                    var bookName = Console.ReadLine();
                    Console.WriteLine("Please enter the book category.");
                    var bookCategory = Console.ReadLine();
                    Console.WriteLine("Please enter the name of the Author.");
                    var bookAuthor = Console.ReadLine();
                    Console.WriteLine("Please enter the name of the book publisher.");
                    var bookPublisher = Console.ReadLine();

                    group2.addBook(bookName, bookCategory, bookAuthor, bookPublisher);
                    Console.WriteLine("The book has been added.");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please enter the name of the book");
                    var name = Console.ReadLine();
                    var book = group2.getBook(name);
                    if (book == null)
                    {
                        Console.WriteLine("Book not found. Please ensure you spelt the name correctly");
                    }
                    else
                    {
                        Console.WriteLine(book.ToString());
                    }
                }
                else if (choice == "3")
                {
                    group2.displayBookInfo();
                }
                else if (choice == "4")
                {
                    logout = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid Input. Please try again.");
                }
            }

            StartSystem();


        }

        public static void ShowingFunctionality()
        {

            Console.WriteLine("Welcome to Group 2's Library Manangement System. \nThese are the default books in the library:\n");
            Book[] a =
            {
                new Book("Object-oriented Software Engineering","CS","Canorus","Pearson"),
                new Book("Data Structures and Algorithm","CS","Tom","New York's Times"),
                new Book("Computer Organization and Design","CS","David","MacMillan"),
                new Book("Introduction to probability","Math","Alice","Oxford"),
                
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
            //System.Diagnostics.Process.Start("projectPhase2.exe", "1");
            Console.WriteLine("\n\nEnter any key to start the program.\n");
            Console.ReadLine();
            StartSystem();

        }
    }
}