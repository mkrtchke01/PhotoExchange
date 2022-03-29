using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Applications.Photo.Commands.DeletePhoto
{
    internal class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand>
    {
        private readonly PhotoExchangeDbContext _context;

        public DeletePhotoCommandHandler(PhotoExchangeDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var onDelete = await _context.Photos.FirstOrDefaultAsync(id => id.ImageId == request.ImageId, cancellationToken);
            if (onDelete == null) throw new NotFoundException(nameof(Photo), request.ImageId);
            _context.Remove(onDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
