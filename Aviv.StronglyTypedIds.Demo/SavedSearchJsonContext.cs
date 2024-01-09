namespace Aviv.StronglyTypedIds.Demo;

[JsonSourceGenerationOptions(
    // GenerationMode = JsonSourceGenerationMode.Serialization,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase
    )]
[JsonSerializable(typeof(GetSavedSearchResponseWithUserId))]
[JsonSerializable(typeof(GetSavedSearchResponse))]
public partial class SavedSearchJsonContext : JsonSerializerContext
{
}