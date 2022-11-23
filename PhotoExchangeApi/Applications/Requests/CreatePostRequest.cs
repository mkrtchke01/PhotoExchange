using Microsoft.AspNetCore.Http;

namespace PhotoExchangeApi.Applications.Requests;

public class CreatePostRequest
{
    public IFormFile Photo { get; set; }
    public string Text { get; set; }
}