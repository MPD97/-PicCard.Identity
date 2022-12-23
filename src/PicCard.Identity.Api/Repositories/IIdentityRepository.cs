namespace PicCard.Identity.Api.Repositories;

public interface IIdentityRepository
{
    Task<Entities.Identity?> GetStateAsync(string email);
    Task SaveStateAsync(Entities.Identity identity);
}