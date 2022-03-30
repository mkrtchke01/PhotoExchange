using MediatR;

namespace Applications.Post.Commands.CreatePost
{
    public class CreatePostCommand : IRequest
    {
        public string Photo { get; set; }
        public string Text { get; set; }
    }
}
