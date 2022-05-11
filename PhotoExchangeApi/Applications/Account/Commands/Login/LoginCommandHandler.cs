using MediatR;
using Microsoft.AspNetCore.Identity;
using PhotoExchangeApi.Applications.Account.Jwt;
using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Applications.Account.Commands.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<JwtTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (user == null || !result.Succeeded)
            {
                throw new NotFoundException(nameof(User), user);
            }

            var token = await GetToken.GetTokenAsync(user);
            return new JwtTokenDto () {Token = token};
        }
    }
}
