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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(p => p.Posts).WithOne(u => u.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.Likes).WithOne(u => u.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.Comments).WithOne(u => u.User).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
