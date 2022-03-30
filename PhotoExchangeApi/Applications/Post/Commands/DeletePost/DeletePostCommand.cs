using MediatR;

namespace Applications.Post.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int PostId { get; set; }

        public DeletePostCommand(int postId)
        {
            PostId = postId;
        }
    }
}
