using MediatR;
using PhotoExchangeApi.Applications.Responses;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPosts;

public class GetPostsQuery : IRequest<List<GetPostResponse>>
{
}