
namespace PhotoExchangeApi.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
