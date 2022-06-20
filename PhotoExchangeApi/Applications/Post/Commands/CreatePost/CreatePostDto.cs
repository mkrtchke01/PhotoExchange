
using Microsoft.AspNetCore.Http;

namespace PhotoExchangeApi.Applications.Post.Commands.CreatePost
{
    public class CreatePostDto
    {
        public IFormFile Photo { get; set; }
        public string Text { get; set; }
    }
}
