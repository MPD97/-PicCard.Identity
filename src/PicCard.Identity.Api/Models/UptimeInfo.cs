namespace PicCard.Identity.Api.Models;

internal record struct UptimeInfo
{
    public long TotalYears { get; init; }
    public long TotalMonths { get; init; }
    public long TotalDays { get; init; }
    public long TotalHours { get; init; }
    public long TotalMinutes { get; init; }
    public long TotalSeconds { get; init; }
}