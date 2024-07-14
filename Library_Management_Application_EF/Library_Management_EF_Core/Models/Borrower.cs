namespace Library_Management_EF_Core.Models
{
    public class Borrower : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
