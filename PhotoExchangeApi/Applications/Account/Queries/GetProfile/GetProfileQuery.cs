
using MediatR;

namespace PhotoExchangeApi.Applications.Account.Queries.GetProfile
{
    public class GetProfileQuery: IRequest<GetProfileDto>
    {
        public string UserId { get; set; }
    }
}
