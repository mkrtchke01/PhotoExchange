using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence
{
    public class PostExchangeDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostExchangeDbContext(DbContextOptions<PostExchangeDbContext> options) 
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
