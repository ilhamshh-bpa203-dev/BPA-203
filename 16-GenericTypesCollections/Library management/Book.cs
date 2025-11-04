namespace _16_GenericTypesCollections.Library_management
{
    internal class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

       
        public Book(int id, string title, string author, int year, int pagecount)
        {
            ID = id;
            Title = title;
            Author = author;
            Year = year;
            PageCount = pagecount;

        }
        public void DisplayInfo()
        {
            Console.WriteLine($"[{ID}] {Title}-{Author}({Year})-{PageCount} pages");
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
