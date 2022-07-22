namespace PicCard.Identity.Api.Repositories;

public interface IIdentityRepository
{
    Task<SignUpResponse> SingUpAsync(SignUpRequest request);
    Task<SignInResponse> SingInAsync(SignInRequest request);
}