namespace PicCard.Identity.Api.Models.Responses;

internal record struct UptimeInfoResponse(long TotalYears, long TotalMonths, long TotalDays, long TotalHours,
    long TotalMinutes, long TotalSeconds);