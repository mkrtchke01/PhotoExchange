using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence
{
    public class PhotoExchangeDbContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }

        public PhotoExchangeDbContext(DbContextOptions<PhotoExchangeDbContext> options) 
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
