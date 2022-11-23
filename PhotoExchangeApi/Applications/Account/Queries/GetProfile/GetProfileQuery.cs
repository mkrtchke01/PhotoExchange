using MediatR;
using PhotoExchangeApi.Applications.Responses;

namespace PhotoExchangeApi.Applications.Account.Queries.GetProfile;

public class GetProfileQuery : IRequest<GetProfileResponse>
{
    public string UserId { get; set; }
}