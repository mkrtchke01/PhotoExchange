using MediatR;
using PhotoExchangeApi.Applications.Responses;

namespace PhotoExchangeApi.Applications.Post.Queries.GetUserPosts;

public class GetUserPostsQuery : IRequest<List<GetUserPostResponse>>
{
    public string UserId { get; set; }
}