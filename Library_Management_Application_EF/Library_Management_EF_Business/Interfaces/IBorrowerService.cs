using Library_Management_EF_Core.Models;

namespace Library_Management_EF_Business.Interfaces
{
    public interface IBorrowerService
    {
        Task<List<Borrower>> GetAllBorrowersAsync();
        Task DeleteBorrowerAsync(int id);
        Task CreateBorrowerAsync(Borrower borrower);
        Task UpdateBorrowerAsync(Borrower borrower);
    }
}
