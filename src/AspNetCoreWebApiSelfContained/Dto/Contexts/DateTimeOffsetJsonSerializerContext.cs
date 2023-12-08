using System.Text.Json.Serialization;

namespace AspNetCoreWebApiSelfContained.Dto.Contexts;

[JsonSerializable(typeof(DateTimeOffsetDto))]
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true)]
public sealed partial class DateTimeOffsetJsonSerializerContext : JsonSerializerContext;
