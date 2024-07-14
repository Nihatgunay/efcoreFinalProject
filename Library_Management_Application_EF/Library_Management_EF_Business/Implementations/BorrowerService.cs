using Library_Management_EF_Business.Interfaces;
using Library_Management_EF_Core.Models;
using Library_Management_EF_Core.Repositories;
using Library_Management_EF_Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_EF_Business.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        private IBorrowerRepository _repository;
        public BorrowerService()
        {
            _repository = new BorrowerRepository();
        }
        public async Task CreateBorrowerAsync(Borrower borrower)
        {
            await _repository.Insert(borrower);
            await _repository.CommitAsync();
        }

        public async Task DeleteBorrowerAsync(int id)
        {
            var wantedborr = await _repository.GetAsync(id);
            if (wantedborr == null)
            {
                throw new NullReferenceException();
            }
            _repository.Delete(wantedborr);
            await _repository.CommitAsync();
        }

        public async Task<List<Borrower>> GetAllBorrowersAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task UpdateBorrowerAsync(Borrower borrower)
        {
            var data = await _repository.GetAsync(borrower.Id);
            if (data == null)
            {
                throw new NullReferenceException();
            }
            data.Name = borrower.Name;
            data.Email = borrower.Email;
            await _repository.CommitAsync();
        }
    }
}
