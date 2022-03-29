using AutoMapper;
using MediatR;
using Persistence;

namespace Applications.Photo.Commands.CreatePhoto
{
    internal class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand>
    {
        private readonly PhotoExchangeDbContext _context;
        private readonly IMapper _mapper;

        public CreatePhotoCommandHandler(PhotoExchangeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = new Domain.Photo
            {
                Url = request.Url,
                Description = request.Description
            };
            await _context.AddAsync(photo, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
