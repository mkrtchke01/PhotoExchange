using Microsoft.AspNetCore.Http;

namespace PhotoExchangeApi.Applications.Requests;

public class ImageHandlerRequest
{
    public IFormFile Image { get; set; }
}