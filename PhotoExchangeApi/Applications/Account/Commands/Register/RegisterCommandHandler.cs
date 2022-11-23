using MediatR;
using Microsoft.AspNetCore.Identity;
using PhotoExchangeApi.Applications.Account.Jwt;
using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Applications.Account.Commands.Register;

internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly UserManager<User> _userManager;

    public RegisterCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.UserName,
            PhotoProfile =
                "https://images.macrumors.com/t/n4CqVR2eujJL-GkUPhv1oao_PmI=/1600x/article-new/2019/04/guest-user-250x250.jpg"
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) throw new NotFoundException(nameof(User), user);

        var token = await GetToken.GetTokenAsync(user);
        return token;
    }
}