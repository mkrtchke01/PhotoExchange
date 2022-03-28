using Applications.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Applications.Photo.Queries.GetPhotoDetails
{
    internal class GetPhotoDetailsQueryHandler : IRequestHandler<GetPhotoDetailsQuery, Domain.Photo>
    {
        private readonly PhotoExchangeDbContext _dbContext;

        public GetPhotoDetailsQueryHandler(PhotoExchangeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Domain.Photo> Handle(GetPhotoDetailsQuery request, CancellationToken cancellationToken)
        {
            var photo = await _dbContext.Photos.FirstOrDefaultAsync(id=>id.ImageId==request.ImageId, cancellationToken);
            if (photo == null) throw new NotFoundException(nameof(photo), request.ImageId);
            return photo;
        }
    }
}
