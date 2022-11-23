using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhotoExchangeApi.Applications.Common.Exceptions;
using PhotoExchangeApi.Applications.Responses;
using PhotoExchangeApi.Domain;
using PhotoExchangeApi.Persistence;

namespace PhotoExchangeApi.Applications.Account.Queries.GetProfile;

internal class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
{
    private readonly PostExchangeDbContext _context;
    private readonly IMapper _mapper;

    public GetProfileQueryHandler(PostExchangeDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleOrDefaultAsync(n => n.Id == request.UserId, cancellationToken);
        if (user == null) throw new NotFoundException(nameof(User), user);

        var result = _mapper.Map<GetProfileResponse>(user);
        if (result == null) throw new ArgumentNullException();
        return result;
    }
}