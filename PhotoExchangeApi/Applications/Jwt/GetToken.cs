using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Applications.Account.Jwt;

internal static class GetToken
{
    public static async Task<string> GetTokenAsync(User user)
    {
        var key = JwtOptions.GetSymmetricSecurityKey();
        var claims = await GetClaims(user);
        var token = new JwtSecurityTokenHandler().WriteToken
        (
            new JwtSecurityToken
            (
                JwtOptions.Issuer,
                JwtOptions.Audience,
                claims,
                expires: JwtOptions.Lifetime,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            )
        );
        return token;
    }

    private static async Task<List<Claim>> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id)
        };
        return claims;
    }
}