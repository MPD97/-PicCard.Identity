namespace PicCard.Identity.Api.Events;

public record struct IdentitySignedUp(string Email, List<string> Roles);