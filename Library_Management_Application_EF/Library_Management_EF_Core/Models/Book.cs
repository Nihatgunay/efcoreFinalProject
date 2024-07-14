namespace Library_Management_EF_Core.Models;

public class Book : BaseModel
{
    public string Title { get; set; }
    public string Desc { get; set; }
    public int? BorrowerId { get; set; }
    public int PublishedYear { get; set; }
    public Borrower Borrower { get; set; }
    public List<LoanItem> LoanItems { get; set; }
    public List<AuthorBook> AuthorBooks { get; set; }
}
