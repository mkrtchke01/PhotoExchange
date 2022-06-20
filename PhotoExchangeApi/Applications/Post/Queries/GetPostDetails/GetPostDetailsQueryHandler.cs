using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Persistence;
using PhotoExchangeApi.Applications.Common.Exceptions;

namespace PhotoExchangeApi.Applications.Post.Queries.GetPostDetails
{
    internal class GetPostDetailsQueryHandler : IRequestHandler<GetPostDetailsQuery, GetPostDetailsVm>
    {
        private readonly PostExchangeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPostDetailsQueryHandler(PostExchangeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetPostDetailsVm> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(id=>id.PostId==request.PostId, cancellationToken);
            if (post == null) throw new NotFoundException(nameof(Post), request.PostId);
            var vm = _mapper.Map<GetPostDetailsVm>(post);
            return vm;
        }
    }
}
