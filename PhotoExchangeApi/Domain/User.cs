using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {
        public string Photo { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
