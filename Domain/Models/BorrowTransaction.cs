public class BorrowTransaction
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public int MemberId { get; set; }
    public Member Member { get; set; }

    public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public string CreatedByUserId { get; set; }
    public ApplicationUser CreatedByUser { get; set; }

    public string ProcessedByUserId { get; set; }
    public ApplicationUser ProcessedByUser { get; set; }
}
