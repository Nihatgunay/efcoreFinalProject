using Library_Management_EF_Core.Models;

namespace Library_Management_EF_Business.Interfaces
{
    public interface ILoanService
    {
        Task BorrowBook(int borrowerid, int bookid);
        Task ReturnBook(int bookid, DateTime returndate);
        Task<List<Borrower>> LateReturnedBorrowers();
        Task<List<Borrower>> BorrowersWithBooks();
    }
}
