namespace _16_GenericTypesCollections.Library_management
{
    internal class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();

        }


        public void BorrowBook(Book book)
        {

            BorrowedBooks.Add(book);

            if (BorrowedBooks.Count <= 3)
            {

                Console.WriteLine($"Kitab götürüldü: [{book.Title}],{book.ID}");
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("Maksimum 3 kitab götüre bilersiniz!");
                Console.WriteLine(" ");
            }
        }
        public void ReturnBook(int bookID)
        {
            Book removedBook = null;
            foreach (Book book in BorrowedBooks)
            {
                if (book.ID == bookID)
                {
                    removedBook = book;
                    break;
                }
            }

            if (removedBook != null)
            {
                BorrowedBooks.Remove(removedBook);
                Console.WriteLine($"Kitab qaytarildi: {removedBook.Title}");
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("Kitab tapilmadi.");
                Console.WriteLine(" ");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count > 0)
            {
                int num = 1;
                foreach (Book book in BorrowedBooks)
                {

                    Console.WriteLine($"{num++}) {book.Title}");
                    Console.WriteLine(" ");
                }
            }
            else { Console.WriteLine("Borc kitab yoxdur"); Console.WriteLine(" "); }
        }
    }
}
