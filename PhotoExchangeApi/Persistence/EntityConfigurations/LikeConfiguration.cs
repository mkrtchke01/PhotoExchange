using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Persistence.EntityConfigurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(i => i.LikeId);
            builder.HasOne(l => l.Post).WithMany(l => l.Likes);
            builder.HasOne(p => p.User).WithMany(u => u.Likes).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
