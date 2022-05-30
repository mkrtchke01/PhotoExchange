using PhotoExchangeApi.Applications.Post.Queries.GetPostDetails;
using PhotoExchangeApi.Applications.Post.Queries.GetPosts;
using AutoMapper;

namespace PhotoExchangeApi.Applications.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Domain.Post, GetPostDetailsVm>()
                .ReverseMap();
            CreateMap<Domain.Post, GetPost>()
                .ForMember(userName => userName.UserName,
                    userName => userName.MapFrom(un=>un.User.UserName))
                .ReverseMap();
        }
    }
}
