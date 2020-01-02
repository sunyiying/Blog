using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infra.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person")
                .Property(c => c.Id).HasColumnName("Id");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PersonCode).HasMaxLength(30);
            builder.Property(c => c.PassWord).HasMaxLength(100);
            builder.Property(c => c.PersonCode).HasMaxLength(30);
            builder.Property(c => c.PassWord).HasColumnName("PassWord").HasMaxLength(100);
            builder.OwnsMany(c => c.BookStore,
                a =>
                {
                    a.HasForeignKey(c => c.personId);
                    a.HasKey(c => c.Id);
                    a.Property(c => c.BookName).HasColumnName("BName").HasMaxLength(200);
                    a.Property(c => c.BookPrice).HasColumnName("BPrice").HasColumnType("decimal(18,6)");
                });
        }
    }
}
