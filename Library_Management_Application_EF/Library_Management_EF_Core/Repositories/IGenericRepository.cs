using Library_Management_EF_Core.Models;

namespace Library_Management_EF_Core.Repositories;

public interface IGenericRepository<T> where T : BaseModel, new()
{
    Task Insert(T entity);
    Task<T?> GetAsync(int id);
    IQueryable<T> GetAll();
    void Delete(T entity);
    Task<int> CommitAsync();
}
