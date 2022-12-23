namespace PicCard.Identity.Api.Events;

public record struct IdentitySignedIn(string Email, List<string> Roles);