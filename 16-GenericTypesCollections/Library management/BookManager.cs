using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GenericTypesCollections.Library_management
{
    internal class BookManager
    {
        public List<Book> Books { get; set; }
        public Dictionary<string, List<Book>> BooksByAuthor;
        public Queue<string> WaitingQueue;
        public Stack<Book> RecentlyReturned { get; set; }
        List<Book> AutherKey = new List<Book>();
        public BookManager(List<Book> books, Dictionary<string, List<Book>> booksByAuthor, Queue<string> waitingQueue, Stack<Book> recentlyReturned)
        {
            Books = books;
            BooksByAuthor = booksByAuthor;
            RecentlyReturned = recentlyReturned;
            WaitingQueue = waitingQueue;

        }


        #region Sual1
        // niye sehvdir bu

        //public void AddBook(Book book)
        //{
        //    Books.Add(book);
        //    BooksByAuthor.Add(book.Author, Books);
        //    AutherKey.Add(book);
        //}
        #endregion



        public void AddBook(Book book)
        {
            Books.Add(book);

            if (!BooksByAuthor.ContainsKey(book.Author))
            {
                BooksByAuthor[book.Author] = new List<Book>();
            }

            BooksByAuthor[book.Author].Add(book);
        }

        public Book SearchByTitle(string title)
        {
            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    return book;
                }

            }

            return null;

        }

        #region Sual2
        //bu da niye olmur


        //public List<Book> GetBooksByAuthor(string author)
        //{
        //    if (AutherKey != null)
        //    {
        //        return Books;
        //    }
        //    return null;
        //}
        #endregion



        public List<Book> GetBooksByAuthor(string author)
        {
            if (BooksByAuthor.ContainsKey(author))
            {
                return BooksByAuthor[author];
            }

            return new List<Book>();
        }



        public void AddToWaitingQueue(string memberName)
        {
            WaitingQueue.Enqueue(memberName);
            Console.WriteLine($"[{memberName}] növbəyə əlavə olundu");
        }
        public string ServeNextInQueue()
        {
            if (WaitingQueue.Count > 0)
            {
                return WaitingQueue.Dequeue();
            }
            return null;
        }
        public void ReturnBook(Book book)
        {
            RecentlyReturned.Push(book);
            Console.WriteLine($"Kitab qəbul edildi: [{book.Title}]");
        }
        public Book GetLastReturnedBook()
        {
            if (RecentlyReturned.Count > 0)
            {
                return RecentlyReturned.Peek();
            }
            return null;
        }

    }
}
