using Applications.Common.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Applications.Photo.Queries.GetPhotoDetails
{
    internal class GetPhotoDetailsQueryHandler : IRequestHandler<GetPhotoDetailsQuery, GetPhotoDetailsVm>
    {
        private readonly PhotoExchangeDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPhotoDetailsQueryHandler(PhotoExchangeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetPhotoDetailsVm> Handle(GetPhotoDetailsQuery request, CancellationToken cancellationToken)
        {
            var photo = await _dbContext.Photos.FirstOrDefaultAsync(id=>id.ImageId==request.ImageId, cancellationToken);
            if (photo == null) throw new NotFoundException(nameof(photo), request.ImageId);
            var vm = _mapper.Map<GetPhotoDetailsVm>(photo);
            return vm;
        }
    }
}
