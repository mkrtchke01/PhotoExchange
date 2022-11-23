using MediatR;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Post.Commands.CreatePost;

internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
{
    private readonly PostExchangeDbContext _context;

    public CreatePostCommandHandler(PostExchangeDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        byte[] imageBytes = null;
        using (var binaryReader = new BinaryReader(request.Photo.OpenReadStream()))
        {
            imageBytes = binaryReader.ReadBytes((int) request.Photo.Length);
        }

        var post = new Domain.Post
        {
            UserId = request.UserId,
            Photo = imageBytes,
            Text = request.Text,
            Date = DateTime.Now
        };
        await _context.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}