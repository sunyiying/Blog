using Blog.Domain.Models.UserInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infra.Data.Mappings
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserToken");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Id).HasMaxLength(50);
            builder.Property(c => c.IssuedAt).HasColumnType("datetime");
            builder.Property(c => c.Expires).HasColumnType("datetime");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Token).HasMaxLength(4000);
        }
    }
}
