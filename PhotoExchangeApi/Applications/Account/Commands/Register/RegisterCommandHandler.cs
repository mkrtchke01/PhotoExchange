using Applications.Account.Jwt;
using Applications.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Applications.Account.Commands.Register
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
                UserName = request.UserName
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
