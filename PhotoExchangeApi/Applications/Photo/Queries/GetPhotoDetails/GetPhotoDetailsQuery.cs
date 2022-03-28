using MediatR;

namespace Applications.Photo.Queries.GetPhotoDetails
{
    public class GetPhotoDetailsQuery : IRequest<Domain.Photo>
    {
        public int ImageId { get; set; }

        public GetPhotoDetailsQuery(int imageId)
        {
            ImageId = imageId;
        }
    }
}
