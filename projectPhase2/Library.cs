using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace projectPhase2
{
    public class Library
    {
        private string checkOutClerk;
        private LinkedList<Book> bookList = new LinkedList<Book>();
        private static Library instance = new Library("Group 2");
        private Stack<Book> bookToBeAdded = new Stack<Book>();
        private int capacity = 10;

        private Library(string _checkOutClerk)
        {
            this.checkOutClerk = _checkOutClerk;
        }

        public static Library Instance   // singleton class
        {
            get
            {
                return instance;
            }
        }

        public bool addBook(string name, string category, string author, string publisher)
        {
            //If the name of the book is not in the library, add it
            if (name != null)
            {
                Book newContact = new Book(name, category, author, publisher);
                getNewBook(newContact);
                Console.WriteLine("Book added.");
                return true;
            }

            Console.WriteLine("Invalid Book details.");
            return false;
        }

        public Book getBook(string name)
        {
            foreach (var book in bookList)
            {
                if (book.getName() == name)
                    return book;
            }

            return null;
        }

        private void getNewBook(Book newBook)
        {
            if (bookList.Count == capacity)
            {
                bookToBeAdded.Push(newBook);
                Console.WriteLine("The library is full.");
            }
            else
            {
                // sorting algorithm here
                bookList.AddLast(newBook);
                Organize();
            }

        }

        public void displayBookInfo()
        {
            Console.WriteLine($"{checkOutClerk}'s library: {bookList.Count} books");
            foreach (Book c in bookList)
            {
                Console.WriteLine(c.getName());
            }
        }
        //bubble sort algorithm
       
    }
}
