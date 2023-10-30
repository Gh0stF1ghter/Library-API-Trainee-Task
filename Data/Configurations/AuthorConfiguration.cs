﻿
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
                .HasMany(a => a.Books)
                .WithOne(b => b.Author);
            builder
                .ToTable("Author");
        }
    }
}
