using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Persistence;
using PhotoExchangeApi.Applications.Common.Exceptions;

namespace PhotoExchangeApi.Applications.Post.Commands.DeletePost
{
    internal class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly PostExchangeDbContext _context;

        public DeletePostCommandHandler(PostExchangeDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var onDelete = await _context.Posts.FirstOrDefaultAsync(id => id.PostId == request.PostId, cancellationToken);
            if (onDelete == null) throw new NotFoundException(nameof(Post), request.PostId);
            _context.Remove(onDelete);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
