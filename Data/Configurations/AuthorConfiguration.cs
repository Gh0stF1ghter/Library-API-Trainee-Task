
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasKey(a => a.AuthorId);
            builder
                .Property(a => a.AuthorId)
                .UseIdentityColumn();
            builder
                .Property(a => a.AuthorFirstMidName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(a => a.AuthorLastName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .ToTable("Author");
            builder.
                HasData(
    new Author { AuthorId = 1, AuthorFirstMidName = "Douglas", AuthorLastName = "Adams" },
    new Author { AuthorId = 2, AuthorFirstMidName = "Suzanne", AuthorLastName = "Collins" },
    new Author { AuthorId = 3, AuthorFirstMidName = "Dan", AuthorLastName = "Brown" },
    new Author { AuthorId = 4, AuthorFirstMidName = "Joanne", AuthorLastName = "Rowling" },
    new Author { AuthorId = 5, AuthorFirstMidName = "Jerome David", AuthorLastName = "Salinger" },
    new Author { AuthorId = 6, AuthorFirstMidName = "Harper", AuthorLastName = "Lee" },
    new Author { AuthorId = 7, AuthorFirstMidName = "John", AuthorLastName = "Tolkien" },
    new Author { AuthorId = 8, AuthorFirstMidName = "George", AuthorLastName = "Orwell" },
    new Author { AuthorId = 9, AuthorFirstMidName = "Khaled", AuthorLastName = "Hosseini" },
    new Author { AuthorId = 10, AuthorFirstMidName = "Stieg", AuthorLastName = "Larsson" });
        }
    }
}
