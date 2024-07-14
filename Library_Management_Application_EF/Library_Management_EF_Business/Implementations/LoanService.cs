using System.Net;
using Library_Management_EF_Business.Interfaces;
using Library_Management_EF_Core.Models;
using Library_Management_EF_Core.Repositories;
using Library_Management_EF_Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_EF_Business.Implementations
{
    public class LoanService : ILoanService
    {
        private ILoanRepository _loanrepository;
        private IBorrowerRepository _borrowerrepository;
        private IBookRepository _bookrepository;
        public LoanService()
        {
            _loanrepository = new LoanRepository();
            _borrowerrepository = new BorrowerRepository();
            _bookrepository = new BookRepository();
        }

        public async Task BorrowBook(int borrowerid, int bookid)
        {
            var book = await _bookrepository.GetAsync(bookid);
            if (book == null)
            {
                throw new NullReferenceException();
            }
            var borrower = await _borrowerrepository.GetAsync(borrowerid);
            if (borrower == null)
            {
                throw new NullReferenceException();
            }
            //if (book.LoanItems.Any(x => x.Loan.ReturnDate == null))
            //{
            //    await Console.Out.WriteLineAsync("book can not be borrowed");
            //}

            var existingloanitem = await _loanrepository.GetAll().Where(x => x.LoanItems
                .Any(x => x.BookId == bookid && x.Loan.ReturnDate == null))
                .FirstOrDefaultAsync();

            if (existingloanitem != null)
            {
                await Console.Out.WriteLineAsync("you cannot borrow this book");
                return;
            }

            var loanitem = new LoanItem { BookId = bookid };
            var loan = new Loan
            {
                BorrowerId = borrowerid,
                LoanDate = DateTime.UtcNow,
                MustReturnDate = DateTime.UtcNow.AddDays(15),
                LoanItems = new List<LoanItem> { loanitem }
            };
            await _loanrepository.Insert(loan);
            await _loanrepository.CommitAsync();
            book.BorrowerId = borrowerid;
            await _bookrepository.CommitAsync();
        }

        public async Task<List<Borrower>> BorrowersWithBooks()
        {
            var borrowedbookds = await _loanrepository.GetAll().Where(x => x.LoanItems.Any()).Select(x => x.Borrower).ToListAsync();
            return borrowedbookds;
        }

        public async Task<List<Borrower>> LateReturnedBorrowers()
        {
            var borrower = await _loanrepository.GetAll().Where(x => x.ReturnDate > x.MustReturnDate).Select(x => x.Borrower).ToListAsync();
            return borrower;
        }

        public async Task ReturnBook(int bookid)
        {
            var loan = _loanrepository.GetAll().FirstOrDefault(x => x.LoanItems.Any(x => x.BookId == bookid && x.Loan.ReturnDate == null));
            if (loan == null)
            {
                throw new NullReferenceException("no book found");
            }
            var loanitem = loan.LoanItems.FirstOrDefault(x => x.BookId == bookid && x.Loan.ReturnDate == null);
            if (loanitem == null)
            {
                throw new NullReferenceException();
            }

            loanitem.Loan.ReturnDate = DateTime.UtcNow;
            loan.ReturnDate = DateTime.UtcNow;
            await _loanrepository.CommitAsync();

            var book = await _bookrepository.GetAsync(bookid);
            if (book == null)
            {
                throw new NullReferenceException();
            }
            book.BorrowerId = null;
            await _bookrepository.CommitAsync();
        }
    }
}
