using Applications.Photo.Queries.GetPhotoDetails;
using Applications.Photo.Queries.GetPhotos;
using AutoMapper;

namespace Applications.AutoMapper.Profiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<Domain.Photo, GetPhotoDetailsVm>()
                .ReverseMap();
            CreateMap<Domain.Photo, GetPhoto>()
                .ReverseMap();
        }
    }
}
