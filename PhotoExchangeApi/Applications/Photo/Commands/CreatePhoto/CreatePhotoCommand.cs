using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Applications.Photo.Commands.CreatePhoto
{
    public class CreatePhotoCommand : IRequest
    {
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
