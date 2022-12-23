namespace PicCard.Identity.Api.DomainServices.Interfaces;

public interface IDateTimeProvider
{
    DateTime Now();
    DateTime UtcNow();
}