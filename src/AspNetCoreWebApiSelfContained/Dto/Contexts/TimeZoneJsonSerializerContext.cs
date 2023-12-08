using System.Text.Json.Serialization;

namespace AspNetCoreWebApiSelfContained.Dto.Contexts;

[JsonSerializable(typeof(TimeZoneDto))]
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true)]
public sealed partial class TimeZoneJsonSerializerContext : JsonSerializerContext;
