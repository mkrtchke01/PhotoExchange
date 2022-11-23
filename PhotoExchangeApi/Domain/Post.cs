namespace PhotoExchangeApi.Domain;

public class Post
{
    public int PostId { get; set; }
    public byte[] Photo { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public string UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}