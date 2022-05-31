
using System.Security.AccessControl;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPosts
{
    public class GetPost
    {
        public int PostId { get; set; }
        public string Photo { get; set; }
        public string Text { get; set; }
        public string UserName  { get; set; }
        public int  Likes { get; set; }
    }
}
