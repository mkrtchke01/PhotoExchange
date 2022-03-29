using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Applications.Photo.Queries.GetPhotos
{
    internal class GetPhotosQueryHandler : IRequestHandler<GetPhotosQuery, List<GetPhoto>>
    {
        private readonly PhotoExchangeDbContext _context;
        private readonly IMapper _mapper;

        public GetPhotosQueryHandler(PhotoExchangeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetPhoto>> Handle(GetPhotosQuery request, CancellationToken cancellationToken)
        {
            var photos = await _context.Photos.ToListAsync(cancellationToken);
            var result = _mapper.Map<List<GetPhoto>>(photos);
            return result;

        }
    }
}
