using Microsoft.EntityFrameworkCore;
using Writter.Infrastructure.Mapping;

namespace Writter.Infrastructure
{
    public class WritterContext : DbContext
    {
        public DbSet<Writter.Domain.Entities.User> User { get; set; }
        public DbSet<Writter.Domain.Entities.Post> Post { get; set; }
        public DbSet<Writter.Domain.Entities.Post_User> Post_User { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterContext(DbContextOptions options) : base(options)
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
        }
    }
}