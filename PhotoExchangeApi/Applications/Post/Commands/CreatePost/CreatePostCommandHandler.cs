using MediatR;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Post.Commands.CreatePost
{
    internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly PostExchangeDbContext _context;

        public CreatePostCommandHandler(PostExchangeDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Domain.Post
            {
                Photo = request.Photo,
                Text = request.Text,
                Date = DateTime.Now
            };
            await _context.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
