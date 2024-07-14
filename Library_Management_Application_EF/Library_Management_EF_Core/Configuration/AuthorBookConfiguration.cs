using Library_Management_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_Management_EF_Core.Configuration
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(x => new { x.AuthorId, x.BookId });
            builder.HasOne(x => x.Book).WithMany(x => x.AuthorBooks).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Author).WithMany(x => x.AuthorBooks).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
