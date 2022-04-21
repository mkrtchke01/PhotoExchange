using Applications.Account.Commands.Login;
using Applications.Account.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhotoExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var command = await _mediator.Send(new LoginCommand()
            {
                UserName = loginDto.UserName,
                Password = loginDto.Password
            });
            return Ok(command);
        }

        //public IActionResult Logout()
        //{
        //    return Ok();
        //}

        [HttpPost]
        [Route("api/Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var command = await _mediator.Send(new RegisterCommand()
            {
                UserName = registerDto.UserName,
                Password = registerDto.Password,
                PasswordConfirm = registerDto.PasswordConfirm
            });
            return Ok(command);
        }
    }

    
}
