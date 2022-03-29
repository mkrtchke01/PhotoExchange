using MediatR;

namespace Applications.Photo.Queries.GetPhotoDetails
{
    public class GetPhotoDetailsQuery : IRequest<GetPhotoDetailsVm>
    {
        public int ImageId { get; set; }

        public GetPhotoDetailsQuery(int imageId)
        {
            ImageId = imageId;
        }
    }
}
