namespace PicCard.Identity.Api.Models.Requests;

public record struct SignUpRequest(string Email, string Password, string RepeatPassword, List<string> Roles);