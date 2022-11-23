using Microsoft.AspNetCore.SignalR;
using PhotoExchangeApi.Domain;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.HubConfiguration;

public class LikeHub : Hub
{
    private readonly PostExchangeDbContext _context;

    public LikeHub(PostExchangeDbContext context)
    {
        _context = context;
    }

    public async Task LikeHubServer(string userName, int postId)
    {
        var post = _context.Posts.SingleOrDefault(id => id.PostId == postId);
        var user = _context.Users.SingleOrDefault(un => un.UserName == userName);
        var likesCount = 0;
        if (post != null && user != null)
        {
            var like = new Like
            {
                UserId = user.Id,
                PostId = post.PostId
            };
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            likesCount = post.Likes.Count;
        }

        await Clients.Clients(Context.ConnectionId).SendAsync("askServerResponse", likesCount);
    }
}