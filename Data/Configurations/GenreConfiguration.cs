using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasKey(g => g.GenreId);
            builder
                .Property(g => g.GenreId)
                .UseIdentityColumn();
            builder
                .Property(g => g.GenreName)
                .IsRequired()
                .HasMaxLength(30);
            builder
                .HasMany(g => g.BookGenres)
                .WithOne(bg => bg.Genre);
            builder
                .ToTable("Genre");
        }
    }
}
