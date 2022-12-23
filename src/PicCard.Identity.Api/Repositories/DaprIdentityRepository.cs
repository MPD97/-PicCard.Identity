using Dapr.Client;

namespace PicCard.Identity.Api.Repositories;

public class DaprIdentityRepository : IIdentityRepository
{
    private const string DaprStoreName = "identity-store";
    private readonly DaprClient _daprClient;

    public DaprIdentityRepository(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task<Entities.Identity?> GetStateAsync(string email)
    {
        return await _daprClient.GetStateAsync<Entities.Identity>(DaprStoreName, email);    
    }
    
    public async Task SaveStateAsync(Entities.Identity identity)
    {
        await _daprClient.SaveStateAsync(DaprStoreName, identity.Email, identity);    
    }
}