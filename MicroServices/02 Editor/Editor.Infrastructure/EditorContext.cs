using Editor.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Editor.Infrastructure
{
    public class EditorContext : DbContext
    {
        public DbSet<Editor.Domain.Entities.User> User { get; set; }
        public DbSet<Editor.Domain.Entities.Post> Post { get; set; }
        public DbSet<Editor.Domain.Entities.Post_User> Post_User { get; set; }
        public DbSet<Editor.Domain.Entities.Comment> Comment { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public EditorContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        ///Method in which entity settings are applied with the database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new User_TypeConfiguration());
            modelBuilder.ApplyConfiguration(new Post_TypeConfiguration());
            modelBuilder.ApplyConfiguration(new Post_User_TypeConfiguration());
            modelBuilder.ApplyConfiguration(new Comment_TypeConfiguration());
        }
    }
}