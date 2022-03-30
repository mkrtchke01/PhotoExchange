using Applications.Dtos;
using Applications.Post.Commands.CreatePost;
using Applications.Post.Commands.DeletePost;
using Applications.Post.Queries.GetPostDetails;
using Applications.Post.Queries.GetPosts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
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

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            var commandResult = await _mediator.Send(new CreatePostCommand()
            {
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
    }
}
