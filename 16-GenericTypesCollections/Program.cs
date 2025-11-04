using _16_GenericTypesCollections.Library_management;
using System.Collections.Generic;
using System.Threading.Channels;
using static System.Reflection.Metadata.BlobBuilder;

namespace _16_GenericTypesCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member(1, "Ilham", "ilham@gmail.com");

            Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new Book(4, "Ağ Gəmi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new Book(4, "Qırıq Budaq", "Elçin", 1998, 350);

            //1.

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();

            //member.DisplayBorrowedBooks();


            //2.
            Library<Book> library = new Library<Book>("Ali");

            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);
            Console.WriteLine(" ");
            Console.WriteLine(library.Count());
            Console.WriteLine(" ");
            Console.WriteLine(library.FindByIndex(0));
            Console.WriteLine(library.FindByIndex(2));
            Console.WriteLine(" ");
            List<Book> allBooks = library.GetAll();
            foreach (var item in allBooks)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" ");


            //library.Remove(book1);


            //3.
            List<Member> members = new List<Member>
            {
                new Member(1, "Ali Məmmədov", "ali@mail.com"),
                new Member(2, "Leyla Həsənova", "leyla@mail.com"),
                new Member(3, "Vüqar Əliyev", "vuqar@mail.com"),
            };

            members[0].BorrowBook(book1);
            members[0].BorrowBook(book2);

            members[0].DisplayBorrowedBooks();
            members[0].ReturnBook(1);
            members[0].DisplayBorrowedBooks();

            members[0].BorrowBook(book3);
            members[0].BorrowBook(book4);
            members[0].BorrowBook(book5);

            members[0].BorrowBook(book1);

            //4.

            List<Book> books2 = new List<Book>()
            {
            book1,
            book2,
            book3,
            book4,
            book5
            };


            Dictionary<string, List<Book>> booksbyauthor = new Dictionary<string, List<Book>>();

            Queue<string> queue = new Queue<string>();
            Stack<Book> stack = new Stack<Book>();




            BookManager manager = new(books2, booksbyauthor, queue, stack);

            manager.AddBook(book1);
            manager.AddBook(book2);
            manager.AddBook(book3);
            manager.AddBook(book4);
            manager.AddBook(book5);


            List<Book> GeorgeBooks = manager.GetBooksByAuthor("George Orwell");


            Console.WriteLine("George Orwell");
            int num = 1;
            foreach (Book book in GeorgeBooks)
            {
                Console.WriteLine($"{num++}. {book.Title} ({book.Author})");
            }
            List<Book> Cingiz = manager.GetBooksByAuthor("Cingiz Aytmatov");

            Console.WriteLine("Cingiz Aytmatov");
            num = 1;
            foreach (Book book in Cingiz)
            {
                Console.WriteLine($"{num++}. {book.Title} ({book.Author})");
            }
            List<Book> Jack = manager.GetBooksByAuthor("Jack London");

            Console.WriteLine("Jack London");
            num = 1;
            foreach (Book book in Jack)
            {
                Console.WriteLine($"{num++}. {book.Title} ({book.Author})");
            }

            List<Book> Dostoyevski = manager.GetBooksByAuthor("Dostoyevski");

            Console.WriteLine("Dostoyevski");
            num = 1;
            foreach (Book book in Dostoyevski)
            {
                Console.WriteLine($"{num++}. {book.Title} ({book.Author})");
            }

            //5.
            manager.AddToWaitingQueue("Nigar");
            manager.AddToWaitingQueue("Resad");
            manager.AddToWaitingQueue("Sebine");

            Console.WriteLine($"Növbədə {manager.WaitingQueue.Count} nəfər var");

            manager.ServeNextInQueue();

            Console.WriteLine($"Növbədə {manager.WaitingQueue.Count} nəfər var");

            manager.ServeNextInQueue();

            Console.WriteLine($"Növbədə {manager.WaitingQueue.Count} nəfər var");

            manager.ServeNextInQueue();

            Console.WriteLine($"Növbədə {manager.WaitingQueue.Count} nəfər var");


            //6.
            manager.ReturnBook(book1);
            manager.ReturnBook(book2);
            manager.ReturnBook(book3);

            Console.WriteLine($"Stack sayi {manager.RecentlyReturned.Count} qeder kitab var");

            Console.WriteLine(manager.GetLastReturnedBook());

            manager.RecentlyReturned.Pop();
            Console.WriteLine($"Stack sayi {manager.RecentlyReturned.Count} qeder kitab var");

            Console.WriteLine(manager.GetLastReturnedBook());

            //7.


            if (manager.SearchByTitle("1984") != null)
            {
                Console.WriteLine($"{manager.SearchByTitle("1984")}");
            }
            else { Console.WriteLine("NOT Found"); }


            if (manager.SearchByTitle("Harry Potter") != null)
            {
                Console.WriteLine($"Kitab {manager.SearchByTitle("Harry Potter")}");
            }
            else { Console.WriteLine("NOT Found"); }


            //8.

            Console.WriteLine($"Ümumi kitab sayı: {manager.Books.Count}, Ümumi üzv sayı: {members.Count} Növbədə nəfər sayı: {manager.WaitingQueue.Count}, Stackdə kitab sayı: {manager.RecentlyReturned.Count}");

            int minYear = allBooks[0].Year;
            int maxYear = allBooks[0].Year;

            foreach (var book in allBooks)
            {
                if (book.Year < minYear) minYear = book.Year;
                if (book.Year > maxYear) maxYear = book.Year;
            }

            Console.WriteLine($"Ən köhnə kitab: {minYear}");
            Console.WriteLine($"Ən yeni kitab: {maxYear}");





        }
    }
}
