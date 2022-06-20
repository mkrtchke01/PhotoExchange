
using AutoMapper;
using PhotoExchangeApi.Applications.Account.Queries.GetProfile;
using PhotoExchangeApi.Domain;

namespace PhotoExchangeApi.Applications.AutoMapper.Profiles
{
    internal class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<User, GetProfileDto>()
                .ReverseMap();
        }
    }
}
