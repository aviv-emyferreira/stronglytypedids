using Aviv.StronglyTypedIds.Demo;

Console.WriteLine($"Json: {Database.Json}");

GetSavedSearchResponse getSavedSearchResponse =
    JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponse)!;

Console.WriteLine($"Deserialized: {getSavedSearchResponse}");