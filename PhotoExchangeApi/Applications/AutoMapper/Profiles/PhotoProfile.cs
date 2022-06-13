using PhotoExchangeApi.Applications.Post.Queries.GetPostDetails;
using PhotoExchangeApi.Applications.Post.Queries.GetPosts;
using AutoMapper;
using PhotoExchangeApi.Applications.Post.Queries.GetUserPosts;

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
                .ForMember(l=>l.Likes, 
                    l=>l.MapFrom(like=>like.Likes.Count))
                .ForMember(p=>p.Photo,
                    ph=>ph.MapFrom(x=> Convert.ToBase64String(x.Photo)))
                .ReverseMap();

            CreateMap<Domain.Post, GetUserPostDto>()
                .ForMember(userName => userName.UserName,
                    userName => userName.MapFrom(un => un.User.UserName))
                .ForMember(l => l.Likes,
                    l => l.MapFrom(like => like.Likes.Count))
                .ForMember(p => p.Photo,
                    ph => ph.MapFrom(x => Convert.ToBase64String(x.Photo)))
                .ReverseMap();
        }
    }
}
