using System;

namespace AspNetCoreWebApiSelfContained.Dto;

public sealed class DateTimeOffsetDto
{
    public DateTimeOffset Value { get; set; }

    public TimeZoneDto TimeZone { get; set; } = default!;
}
