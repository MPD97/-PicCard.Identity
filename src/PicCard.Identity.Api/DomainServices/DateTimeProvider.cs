using PicCard.Identity.Api.DomainServices.Interfaces;
using IDateTimeProvider = PicCard.Identity.Api.DomainServices.Interfaces.IDateTimeProvider;

namespace PicCard.Identity.Api.DomainServices;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now()
    {
        return DateTime.Now;
    }

    public DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}