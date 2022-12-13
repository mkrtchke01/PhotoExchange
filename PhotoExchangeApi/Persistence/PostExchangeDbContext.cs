using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Domain;
using PhotoExchangeApi.Persistence.EntityConfigurations;

namespace PhotoExchangeApi.Persistence;

public class PostExchangeDbContext : IdentityDbContext<User>
{
    public PostExchangeDbContext(DbContextOptions<PostExchangeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}