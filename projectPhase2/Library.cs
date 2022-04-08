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
                //sort algorithm
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
        public void Organize()
        {
            int length = bookList.Count;
            for (int i = 0; i < length - 1; i++)
            {
                var recentNode = bookList.First;
                for (int j = 0; j < length - i - 1; j++)//loop through contacts
                {
                    //get the 2 names
                    char[] c1 = bookList.ElementAt(j).getName().ToLower().ToCharArray();
                    char[] c2 = bookList.ElementAt(j + 1).getName().ToLower().ToCharArray();

                    //loop through letters
                    if (c1.Length < c2.Length)
                    {
                        for (int n = 0; n < c1.Length; n++)
                        {
                            if (c2[n] < c1[n])
                            {
                                //swap
                                var temp = recentNode.Next;
                                bookList.Remove(temp);
                                bookList.AddBefore(recentNode, temp);
                                break;
                            }
                            else if (c2[n] > c1[n])
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int n = 0; n < c2.Length; n++)
                        {
                            if (c2[n] < c1[n])
                            {
                                //swap
                                var temp = recentNode.Next;
                                bookList.Remove(temp);
                                bookList.AddBefore(recentNode, temp);
                                break;
                            }
                            else if (c2[n] > c1[n])
                            {
                                break;
                            }
                            else if (n == c2.Length - 1)
                            {
                                //swap because c2 is shorter, so it should come before the other one
                                var temp = recentNode.Next;
                                bookList.Remove(temp);
                                bookList.AddBefore(recentNode, temp);
                            }
                        }
                    }

                    recentNode = recentNode.Next;
                }
            }
        }
    }
}
