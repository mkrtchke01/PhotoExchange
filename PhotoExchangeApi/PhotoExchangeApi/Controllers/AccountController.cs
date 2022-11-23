using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoExchangeApi.Applications.Account.Commands.Login;
using PhotoExchangeApi.Applications.Account.Commands.Register;
using PhotoExchangeApi.Applications.Account.Queries.GetProfile;
using PhotoExchangeApi.Applications.Requests;
using PhotoExchangeApi.Applications.Responses;

namespace PhotoExchangeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : PhotoExchangeControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var command = await _mediator.Send(new LoginCommand
        {
            UserName = loginRequest.UserName,
            Password = loginRequest.Password
        });
        var token = new TokenResponse
        {
            Token = command
        };
        return Ok(token);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = await _mediator.Send(new RegisterCommand
        {
            UserName = registerRequest.UserName,
            Password = registerRequest.Password,
            PasswordConfirm = registerRequest.PasswordConfirm
        });
        var token = new TokenResponse
        {
            Token = command
        };
        return Ok(token);
    }

    [HttpGet]
    [Route("Profile")]
    public async Task<IActionResult> Profile()
    {
        var query = await _mediator.Send(new GetProfileQuery
        {
            UserId = UserId
        });
        return Ok(query);
    }
}