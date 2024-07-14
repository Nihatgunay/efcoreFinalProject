using Library_Management_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_Management_EF_Core.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasColumnType("NVARCHAR(50)");
            builder.Property(x => x.Desc).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.PublishedYear).IsRequired();
            //builder.HasOne(x => x.Borrower).WithMany(x => x.Books).HasForeignKey(x => x.BorrowerId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(x => x.AuthorBooks).WithOne(x => x.Book).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
