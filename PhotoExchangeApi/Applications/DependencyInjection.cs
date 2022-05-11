using System.Reflection;
using PhotoExchangeApi.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhotoExchangeApi.Persistence;
using PhotoExchangeApi.Applications.Account.Jwt;

namespace PhotoExchangeApi.Applications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = JwtOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = JwtOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = JwtOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            var builder = services.AddIdentityCore<User>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<PostExchangeDbContext>()
                .AddDefaultTokenProviders();

            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddSignInManager<SignInManager<User>>();
            return services;
        }
    }
}
