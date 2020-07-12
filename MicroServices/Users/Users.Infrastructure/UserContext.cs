using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Infrastructure.Mapping;

namespace Users.Infrastructure
{
    public class UserContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Users.Domain.Entities.Post> Post { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        ///Method in which entity settings are applied with the database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Comment_TypeConfiguration());
            modelBuilder.ApplyConfiguration(new Post_TypeConfiguration());
        }
    }
}