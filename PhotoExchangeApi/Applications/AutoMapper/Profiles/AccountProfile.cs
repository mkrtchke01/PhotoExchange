using AutoMapper;
using PhotoExchangeApi.Applications.Responses;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Applications.AutoMapper.Profiles;

internal class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<User, GetProfileResponse>()
            .ReverseMap();
    }
}