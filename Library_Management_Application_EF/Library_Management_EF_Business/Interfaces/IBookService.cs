using Library_Management_EF_Core.Models;

namespace Library_Management_EF_Business.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> GetAllBooksWhereAsync();
        Task<List<Book>> GetAllBooksWhereNoBorrowerAsync();
        Task DeleteBookAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task<List<Book>> FilterBooksByTitle(string title);
        Task<List<Book>> FilterBooksByAuthor(string authorname);
        Task<Book> GetMostBorrowedBook();
    }
}
