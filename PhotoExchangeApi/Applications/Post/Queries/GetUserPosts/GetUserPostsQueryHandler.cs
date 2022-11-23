using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Applications.Responses;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Post.Queries.GetUserPosts;

internal class GetUserPostsQueryHandler : IRequestHandler<GetUserPostsQuery, List<GetUserPostResponse>>
{
    private readonly PostExchangeDbContext _context;
    private readonly IMapper _mapper;

    public GetUserPostsQueryHandler(PostExchangeDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetUserPostResponse>> Handle(GetUserPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _context.Posts.Where(ui => ui.UserId == request.UserId).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<GetUserPostResponse>>(posts);
        if (result == null) throw new NotFoundException(nameof(Post), posts);
        return result;
    }
}