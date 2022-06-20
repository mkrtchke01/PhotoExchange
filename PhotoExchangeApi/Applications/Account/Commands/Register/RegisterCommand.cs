using MediatR;

namespace PhotoExchangeApi.Applications.Account.Commands.Register
{
    public class RegisterCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
