
namespace PhotoExchangeApi.Applications.Post.Queries.GetUserPosts
{
    public class GetUserPostDto
    {
        public int PostId { get; set; }
        public string Photo { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public int Likes { get; set; }
    }
}
