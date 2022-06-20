using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(i => i.CommentId);
            builder.HasOne(l => l.Post).WithMany(l => l.Comments);
            builder.HasOne(p => p.User).WithMany(u => u.Comments).HasForeignKey(u=>u.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
