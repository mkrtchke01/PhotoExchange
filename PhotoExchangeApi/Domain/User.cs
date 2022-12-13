using Microsoft.AspNetCore.Identity;

namespace PhotoExchangeApi.Domain;

public class User : IdentityUser
{
    public string PhotoProfile { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
}