namespace PicCard.Identity.Api.Common.DomainModels;

public record struct JwtResponse(string Token, string Role, DateTime Expiries,
    IDictionary<string, IEnumerable<string>> Claims);