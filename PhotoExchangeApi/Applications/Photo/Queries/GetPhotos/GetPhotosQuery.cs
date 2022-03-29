

using MediatR;

namespace Applications.Photo.Queries.GetPhotos
{
    public class GetPhotosQuery : IRequest<List<GetPhoto>>
    {
    }
}
