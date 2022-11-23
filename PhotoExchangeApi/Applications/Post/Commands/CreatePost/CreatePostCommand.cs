using MediatR;
using Microsoft.AspNetCore.Http;

namespace PhotoExchangeApi.Applications.Post.Commands.CreatePost;

public class CreatePostCommand : IRequest
{
    public string UserId { get; set; }
    public IFormFile Photo { get; set; }
    public string Text { get; set; }
}