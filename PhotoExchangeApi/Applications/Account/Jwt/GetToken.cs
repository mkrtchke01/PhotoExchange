using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace Applications.Account.Jwt
{
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
                    issuer: JwtOptions.Issuer,
                    audience: JwtOptions.Audience,
                    claims: claims,
                    expires: JwtOptions.Lifetime,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                )
            );
            return token;
        }

        private async static Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            return claims;
        }
    }
}
