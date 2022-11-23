using MediatR;
using PhotoExchangeApi.Applications.Responses;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPostDetails;

public class GetPostDetailsQuery : IRequest<GetPostDetailsResponse>
{
    public GetPostDetailsQuery(int postId)
    {
        PostId = postId;
    }

    public int PostId { get; set; }
}