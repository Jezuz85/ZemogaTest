using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Writter.Infrastructure.Mapping
{
    public class Post_TypeConfiguration : IEntityTypeConfiguration<Writter.Domain.Entities.Post>
    {
        public void Configure(EntityTypeBuilder<Writter.Domain.Entities.Post> builder)
        {
            builder.ToTable("Post", "dbo");
            builder.HasKey(e => e.id).HasName("id");
            builder.Property(e => e.body).HasColumnName("body");
            builder.Property(e => e.datePublish).HasColumnName("datePublish");
            builder.Property(e => e.state).HasColumnName("state");
        }
    }
}