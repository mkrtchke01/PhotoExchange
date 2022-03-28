using Applications.Photo.Queries.GetPhotoDetails;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhotoExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhotoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetDetails([FromRoute] int imageId)
        {
            var queryResult = await _mediator.Send(new GetPhotoDetailsQuery(imageId));
            return Ok(queryResult);
        }
    }
}
