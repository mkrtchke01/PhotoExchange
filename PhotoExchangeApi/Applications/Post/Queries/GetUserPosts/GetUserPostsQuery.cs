using MediatR;

namespace PhotoExchangeApi.Applications.Post.Queries.GetUserPosts
{
    public class GetUserPostsQuery : IRequest<List<GetUserPostDto>>
    {
        public string UserId { get; set; }
    }
}
