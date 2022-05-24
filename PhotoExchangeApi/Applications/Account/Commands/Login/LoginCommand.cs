using MediatR;
using PhotoExchangeApi.Applications.Account.Jwt;

namespace PhotoExchangeApi.Applications.Account.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
