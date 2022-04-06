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
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(key => key.PostId);
            builder.HasOne(p => p.User).WithMany(u => u.Posts);
            builder.HasMany(l => l.Comments).WithOne(p => p.Post);
            builder.HasMany(l => l.Likes).WithOne(p => p.Post);
        }
    }
}
