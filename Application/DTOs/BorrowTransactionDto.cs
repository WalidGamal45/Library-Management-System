namespace Application.DTOs
{
    public class BorrowTransactionDto
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public string BookTitle { get; set; }

        public int MemberId { get; set; }
        public string MemberName { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

       
    }

}
