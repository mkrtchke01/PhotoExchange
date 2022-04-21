using Applications.Account.Jwt;
using MediatR;

namespace Applications.Account.Commands.Login
{
    public class LoginCommand : IRequest<JwtTokenDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
