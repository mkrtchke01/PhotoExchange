using MediatR;

namespace Applications.Post.Queries.GetPostDetails
{
    public class GetPostDetailsQuery : IRequest<GetPostDetailsVm>
    {
        public int PostId { get; set; }

        public GetPostDetailsQuery(int postId)
        {
            PostId = postId;
        }
    }
}
