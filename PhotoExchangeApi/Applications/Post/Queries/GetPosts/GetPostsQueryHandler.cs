using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Applications.Responses;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPosts;

internal class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<GetPostResponse>>
{
    private readonly PostExchangeDbContext _context;
    private readonly IMapper _mapper;

    public GetPostsQueryHandler(PostExchangeDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetPostResponse>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _context.Posts.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<GetPostResponse>>(posts);
        return result;
    }
}