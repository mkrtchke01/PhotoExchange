using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoExchangeApi.Applications.Post.Commands.CreatePost;
using PhotoExchangeApi.Applications.Post.Commands.DeletePost;
using PhotoExchangeApi.Applications.Post.Queries.GetPostDetails;
using PhotoExchangeApi.Applications.Post.Queries.GetPosts;
using PhotoExchangeApi.Applications.Post.Queries.GetUserPosts;
using PhotoExchangeApi.Requests;
using PhotoExchangeApi.Responses;

namespace PhotoExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : PhotoExchangeControllerBase
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult> GetDetails([FromRoute] int postId)
        {
            var queryResult = await _mediator.Send(new GetPostDetailsQuery(postId));
            return Ok(queryResult);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPost>>> GetPosts()
        {
            var queryResult = await _mediator.Send(new GetPostsQuery());
            return Ok(queryResult);
        }
        [HttpGet("GetUserPosts")]
        public async Task<ActionResult<List<GetPost>>> GetUserPosts()
        {
            var queryResult = await _mediator.Send(new GetUserPostsQuery()
            {
                UserId = UserId
            });
            return Ok(queryResult);
        }

        [HttpPost("UploadPost")]
        public async Task<ActionResult> CreatePost([FromForm] CreatePostDto createPostDto)
        {
            await _mediator.Send(new CreatePostCommand()
            {
                UserId = UserId,
                Photo = createPostDto.Photo,
                Text = createPostDto.Text,
            });
            return Ok();
        }

        [HttpDelete("{postId}")]
        public async Task<ActionResult> DeletePost([FromRoute] int postId)
        {
            var commandResult = await _mediator.Send(new DeletePostCommand(postId));
            return NotFound();
        }
        [HttpPost("ImageHandler")]
        public ActionResult<ImageHandlerResponse> ImageHandler([FromForm] ImageHandlerRequest imageHandler)
        {
            byte[] imageBytes = null;
            using (var binaryReader = new BinaryReader(imageHandler.Image.OpenReadStream()))
            {
                imageBytes = binaryReader.ReadBytes((int)imageHandler.Image.Length);
            }

            var image = new ImageHandlerResponse()
            {
                Image = Convert.ToBase64String(imageBytes)
            };
            return Ok(image);
        }
    }
}
