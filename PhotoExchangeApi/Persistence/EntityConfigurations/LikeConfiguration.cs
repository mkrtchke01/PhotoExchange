using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
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
