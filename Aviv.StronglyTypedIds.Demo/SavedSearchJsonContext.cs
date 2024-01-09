namespace Aviv.StronglyTypedIds.Demo;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(GetSavedSearchResponseWithUserId))]
[JsonSerializable(typeof(GetSavedSearchResponse))]
public partial class SavedSearchJsonContext : JsonSerializerContext
{
}