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
                Book newBook = new Book(name, category, author, publisher);
                getNewBook(newBook);
                Console.WriteLine($"{newBook.Name} is added");
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
                bookList.AddLast(newBook);
                //sort algorithm
                Organize();
                
            }

        }
        public void displayBookInfo()
        {
            Console.WriteLine($"{checkOutClerk}'s library: {bookList.Count} books\n");
            foreach (Book c in bookList)
            {
                Console.WriteLine(c.getName());
            }
            Console.WriteLine("\n***Books are sorted alphabetically.***\n");
        }
        //bubble sort algorithm
        public void Organize()
        {
            string[] a = new string[bookList.Count];
            int count = 0;
            foreach (var book in bookList)
            {
                a[count] = book.getName();
                count++;
            }
            var tempArray = BubbleSort(a);
            var sortedArray = new Book[bookList.Count];
            count = 0;
            foreach (string name in tempArray)
            {
                sortedArray[count] = getBook(name);
                count++;
            }

            bookList = new LinkedList<Book>(sortedArray);
        }

        public Array BubbleSort(string[] ar)
        {
            var arr = ar;
            int length = arr.Length;
            String temp;

            for (int j = 0; j < length - 1; j++)
            {
                for (int i = j + 1; i < length; i++)
                {
                    if (arr[j].CompareTo(arr[i]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
