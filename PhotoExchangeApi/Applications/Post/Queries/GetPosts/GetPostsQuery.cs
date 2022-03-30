

using MediatR;

namespace Applications.Post.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<List<GetPost>>
    {
    }
}
