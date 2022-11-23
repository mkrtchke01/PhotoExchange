using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Applications.Responses;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPostDetails;

internal class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, GetPostDetailsResponse>
{
    private readonly PostExchangeDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPostDetailsQueryHandler(PostExchangeDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetPostDetailsResponse> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
    {
        var post = await _dbContext.Posts.FirstOrDefaultAsync(id => id.PostId == request.PostId, cancellationToken);
        if (post == null) throw new NotFoundException(nameof(Post), request.PostId);
        var vm = _mapper.Map<GetPostDetailsResponse>(post);
        return vm;
    }
}