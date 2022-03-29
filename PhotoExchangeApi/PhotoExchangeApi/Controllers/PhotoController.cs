using Applications.Dtos;
using Applications.Photo.Commands.CreatePhoto;
using Applications.Photo.Commands.DeletePhoto;
using Applications.Photo.Queries.GetPhotoDetails;
using Applications.Photo.Queries.GetPhotos;
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
        public async Task<ActionResult> GetDetails([FromRoute] int imageId)
        {
            var queryResult = await _mediator.Send(new GetPhotoDetailsQuery(imageId));
            return Ok(queryResult);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPhoto>>> GetPhotos()
        {
            var queryResult = await _mediator.Send(new GetPhotosQuery());
            return Ok(queryResult);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePhoto([FromBody] CreatePhotoDto createPhotoDto)
        {
            var commandResult = await _mediator.Send(new CreatePhotoCommand()
            {
                Url = createPhotoDto.Url,
                Description = createPhotoDto.Description
            });
            return Ok();
        }

        [HttpDelete("{imageId}")]
        public async Task<ActionResult> DeletePhoto([FromRoute] int imageId)
        {
            var commandResult = await _mediator.Send(new DeletePhotoCommand(imageId));
            return NotFound();
        }
    }
}
