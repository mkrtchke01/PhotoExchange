using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PhotoExchangeApi.Applications.Account.Jwt;

internal class JwtOptions
{
    public const string Issuer = "JwtServer";
    public const string Audience = "JwtClient";
    private const string Key = "photoexchangekey!!!2022";
    public static DateTime Lifetime = DateTime.Now.AddDays(1);

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}