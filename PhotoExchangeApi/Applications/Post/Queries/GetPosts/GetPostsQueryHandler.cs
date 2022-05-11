using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPosts
{
    internal class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<GetPost>>
    {
        private readonly PostExchangeDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(PostExchangeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetPost>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.ToListAsync(cancellationToken);
            var result = _mapper.Map<List<GetPost>>(post);
            return result;

        }
    }
}
