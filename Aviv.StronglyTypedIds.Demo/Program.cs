using Aviv.StronglyTypedIds.Demo;

Console.WriteLine($"Json: {Database.Json}");

GetSavedSearchResponseWithUserId getSavedSearchResponse =
    JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponseWithUserId)!;

Console.WriteLine($"Deserialized: {getSavedSearchResponse}");