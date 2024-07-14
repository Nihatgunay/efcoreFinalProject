using Library_Management_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_Management_EF_Core.Configuration
{
    public class LoanItemConfiguration : IEntityTypeConfiguration<LoanItem>
    {
        public void Configure(EntityTypeBuilder<LoanItem> builder)
        {
            builder.HasOne(x => x.Book).WithMany(x => x.LoanItems).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Loan).WithMany(x =>x.LoanItems).HasForeignKey(x => x.LoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
