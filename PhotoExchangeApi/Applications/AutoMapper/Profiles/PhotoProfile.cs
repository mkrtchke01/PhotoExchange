using AutoMapper;
using PhotoExchangeApi.Applications.Responses;

namespace PhotoExchangeApi.Applications.AutoMapper.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Domain.Post, GetPostDetailsResponse>()
            .ReverseMap();

        CreateMap<Domain.Post, GetPostResponse>()
            .ForMember(userName => userName.UserName,
                userName => userName.MapFrom(un => un.User.UserName))
            .ForMember(l => l.Likes,
                l => l.MapFrom(like => like.Likes.Count))
            .ForMember(userPhoto => userPhoto.UserPhoto,
                up => up.MapFrom(u => u.User.PhotoProfile))
            .ForMember(p => p.Photo,
                ph => ph.MapFrom(x => Convert.ToBase64String(x.Photo)))
            .ReverseMap();

        CreateMap<Domain.Post, GetUserPostResponse>()
            .ForMember(userName => userName.UserName,
                userName => userName.MapFrom(un => un.User.UserName))
            .ForMember(l => l.Likes,
                l => l.MapFrom(like => like.Likes.Count))
            .ForMember(p => p.Photo,
                ph => ph.MapFrom(x => Convert.ToBase64String(x.Photo)))
            .ReverseMap();
    }
}