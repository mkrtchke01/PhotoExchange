using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence
{
    public class PostExchangeDbContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        public PostExchangeDbContext(DbContextOptions<PostExchangeDbContext> options) 
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => entity.ToTable(name: "Users"));
            modelBuilder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRoles"));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable(name: "UserClaims"));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogins"));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserTokens"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "RoleClaims"));

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
