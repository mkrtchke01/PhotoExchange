using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace PhotoExchangeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class PhotoExchangeControllerBase : ControllerBase
{
    protected string UserId => User.FindFirstValue(JwtRegisteredClaimNames.Sub);
}