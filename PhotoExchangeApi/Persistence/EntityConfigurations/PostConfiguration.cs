using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Persistence.EntityConfigurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(key => key.PostId);
        builder.HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(l => l.Comments).WithOne(p => p.Post);
        builder.HasMany(l => l.Likes).WithOne(p => p.Post);
    }
}