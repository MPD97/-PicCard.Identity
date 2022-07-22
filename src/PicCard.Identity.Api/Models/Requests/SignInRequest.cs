namespace PicCard.Identity.Api.Models.Requests;

public record struct SignInRequest(string Email, string Password);