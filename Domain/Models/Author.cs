using Task___Code_81__.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}