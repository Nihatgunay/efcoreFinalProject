namespace Library_Management_EF_Core.Models
{
    public class Loan : BaseModel
    {
        public int BorrowerId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime MustReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Borrower Borrower { get; set; }
        public List<Book> Books { get; set; }
        public List<LoanItem> LoanItems { get; set; }
    }
}
