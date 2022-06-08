using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Domain;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Account.Queries.GetProfile
{
    internal class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileDto>
    {
        private readonly PostExchangeDbContext _context;
        private readonly IMapper _mapper;

        public GetProfileQueryHandler(PostExchangeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(n => n.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), user);
            }

            var result = _mapper.Map<GetProfileDto>(user);
            if (result == null)
            {
                throw new ArgumentNullException();
            }
            return result;
        }
    }
}
