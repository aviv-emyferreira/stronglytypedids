using Aviv.StronglyTypedIds.Demo;

Console.WriteLine($"Json: {Database.Json}");

SavedSearchJsonContext jsonContext = new();
GetSavedSearchResponse getSavedSearchResponse =
    JsonSerializer.Deserialize(Database.Json, jsonContext.GetSavedSearchResponse)!;

Console.WriteLine($"Deserialized: {getSavedSearchResponse}");