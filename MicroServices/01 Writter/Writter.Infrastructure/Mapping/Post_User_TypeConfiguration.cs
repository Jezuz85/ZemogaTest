using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Writter.Infrastructure.Mapping
{
    public class Post_User_TypeConfiguration : IEntityTypeConfiguration<Writter.Domain.Entities.Post_User>
    {
        public void Configure(EntityTypeBuilder<Writter.Domain.Entities.Post_User> builder)
        {
            builder.ToTable("Post_User", "dbo");
            builder.HasKey(e => e.id).HasName("id");
            builder.Property(e => e.id_editor).HasColumnName("id_editor");
            builder.Property(e => e.id_post).HasColumnName("id_post");
            builder.Property(e => e.id_writter).HasColumnName("id_writter");
        }
    }
}