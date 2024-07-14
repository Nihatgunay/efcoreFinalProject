using Library_Management_EF_Core.Models;
using Library_Management_EF_Core.Repositories;

namespace Library_Management_EF_Data.Repositories
{
    public class BorrowerRepository : GenericRepository<Borrower>, IBorrowerRepository
    {
    }
}
