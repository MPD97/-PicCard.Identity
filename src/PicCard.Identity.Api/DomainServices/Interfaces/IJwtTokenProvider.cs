using PicCard.Identity.Api.Common.DomainModels;

namespace PicCard.Identity.Api.DomainServices.Interfaces;

public interface IJwtTokenProvider
{
    public JwtResponse Create(string userId, string role, IDictionary<string, IEnumerable<string>> claims);
}