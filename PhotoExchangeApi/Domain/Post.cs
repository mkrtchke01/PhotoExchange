namespace PhotoExchangeApi.Domain;

public class Post
{
    public int PostId { get; set; }
    public byte[] Photo { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
}