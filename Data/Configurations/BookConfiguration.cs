using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.BookId);
            builder
                .Property(b => b.BookId)
                .UseIdentityColumn();
            builder
                .HasIndex(b => b.BookISBN)
                .IsUnique();
            builder
                .Property(b => b.BookName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(b => b.BookISBN)
                .IsRequired()
                .HasMaxLength(16);
            builder
                .Property(b => b.BookDescription)
                .HasMaxLength(50);
            builder
                .Property(b => b.BookTakeDate)
                .HasColumnType("date");
            builder
                .Property(b => b.BookReturnDate)
                .HasColumnType("date");
            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.BookAuthorId);
            builder
                .HasMany(b => b.BookGenres)
                .WithOne(bg => bg.Book);
            builder
                .ToTable("Book");
        }
    }
}
