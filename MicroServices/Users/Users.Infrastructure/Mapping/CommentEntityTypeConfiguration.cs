﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infrastructure.Mapping
{
    public class Comment_TypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment", "dbo");

            builder.HasKey(e => e.id)
                .HasName("id");
            builder.Property(e => e.body)
                .HasColumnName("body");
            builder.Property(e => e.id_post)
                .HasColumnName("id_post");
        }
    }
}