using Applications.Post.Queries.GetPostDetails;
using Applications.Post.Queries.GetPosts;
using AutoMapper;

namespace Applications.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Domain.Post, GetPostDetailsVm>()
                .ReverseMap();
            CreateMap<Domain.Post, GetPost>()
                .ReverseMap();
        }
    }
}
