using Library_Management_EF_Core.Models;

namespace Library_Management_EF_Business.Interfaces;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task DeleteAuthorAsync(int id);
    Task CreateAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
}
