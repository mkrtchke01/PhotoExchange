using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Persistence.EntityConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(p => p.Posts).WithOne(u => u.User).HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Likes).WithOne(u => u.User).HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Comments).WithOne(u => u.User).HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}