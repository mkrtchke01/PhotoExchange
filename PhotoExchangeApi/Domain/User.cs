using Microsoft.AspNetCore.Identity;

namespace PhotoExchangeApi.Domain
{
    public class User : IdentityUser
    {
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }  
    }
}
