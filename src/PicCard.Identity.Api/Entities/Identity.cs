namespace PicCard.Identity.Api.Entities;

public record Identity(string Email, string Password, List<string> Roles, DateTime CreatedAt, DateTime? LastLogin,
    bool Blocked = false);