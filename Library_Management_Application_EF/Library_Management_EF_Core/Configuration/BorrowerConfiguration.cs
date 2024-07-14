using Library_Management_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_Management_EF_Core.Configuration
{
    public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("NVARCHAR(40)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("NVARCHAR(40)");
        }
    }
}
