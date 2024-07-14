using Library_Management_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_Management_EF_Core.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasOne(x => x.Borrower).WithMany(x => x.Loans).HasForeignKey(x => x.BorrowerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
