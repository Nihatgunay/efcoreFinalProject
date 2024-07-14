using System;
using Library_Management_EF_Core.Models;
using Library_Management_EF_Core.Repositories;

namespace Library_Management_EF_Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel, new()
    {
        public AppDbContext _context;

        public GenericRepository()
        {
            _context = new AppDbContext();
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
    }
}
