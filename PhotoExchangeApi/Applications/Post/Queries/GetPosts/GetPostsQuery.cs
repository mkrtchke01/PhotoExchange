
using MediatR;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<List<GetPost>>
    {
    }
}
