using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PhotoExchangeApi.Applications.Account.Jwt;

namespace PhotoExchangeApi.Applications.Account.Commands.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                UserName = request.UserName,
                PhotoProfile = "https://i.pinimg.com/280x280_RS/10/4b/ab/104babfeee3e488391873fe9d3dfb7ac.jpg"
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new NotFoundException(nameof(User), user);
            }

            var token = await GetToken.GetTokenAsync(user);
            return token;
        }
    }
}
