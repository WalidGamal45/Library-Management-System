    // Models/Book.cs
    using Task___Code_81__.Models;

    public enum BookStatus { Available = 0, Borrowed = 1, Lost = 2 }
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        public BookStatus Status { get; set; } = BookStatus.Available;
        public int Copies { get; set; } = 1;
        public DateTime? PublishedDate { get; set; }
        public string Description { get; set; }
        // Models/Book.cs
        public int CopiesAvailable { get; set; }

    }
