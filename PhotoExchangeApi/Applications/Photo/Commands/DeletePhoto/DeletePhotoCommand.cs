using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Applications.Photo.Commands.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public int ImageId { get; set; }

        public DeletePhotoCommand(int imageId)
        {
            ImageId = imageId;
        }
    }
}
