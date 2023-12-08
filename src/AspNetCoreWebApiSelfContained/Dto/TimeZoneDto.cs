using System;

namespace AspNetCoreWebApiSelfContained.Dto;

public sealed class TimeZoneDto
{
    public string Id { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public TimeSpan BaseUtcOffset { get; set; }
}
