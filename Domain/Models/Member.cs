// Models/Member.cs
public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    public ICollection<BorrowTransaction> BorrowTransactions { get; set; } = new List<BorrowTransaction>();


}
