using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Writter.Infrastructure.Mapping
{
    public class User_TypeConfiguration : IEntityTypeConfiguration<Writter.Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Writter.Domain.Entities.User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(e => e.id)
                .HasName("id");
            builder.Property(e => e.isEditor)
                 .HasColumnName("isEditor");
            builder.Property(e => e.user_login)
                 .HasColumnName("user_login");
            builder.Property(e => e.password_login)
                 .HasColumnName("password_login");
        }
    }
}