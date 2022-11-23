using MediatR;

namespace PhotoExchangeApi.Applications.Post.Commands.DeletePost;

public class DeletePostCommand : IRequest
{
    public DeletePostCommand(int postId)
    {
        PostId = postId;
    }

    public int PostId { get; set; }
}