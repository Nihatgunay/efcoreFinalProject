namespace Library_Management_EF_Core.Models
{
    public class LoanItem : BaseModel
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public Loan Loan { get; set; }
        public Book Book { get; set; }
    }
}
