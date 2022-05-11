using MediatR;

namespace PhotoExchangeApi.Applications.Post.Commands.CreatePost
{
    public class CreatePostCommand : IRequest
    {
        public string Photo { get; set; }
        public string Text { get; set; }
    }
}
