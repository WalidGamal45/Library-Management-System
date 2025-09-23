namespace Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublisherName { get; set; }
        public BookStatus Status { get; set; }
        public int CopiesAvailable { get; set; }
        public string Description { get; set; }
        public int PublisherId { get; set; }
    }

}
