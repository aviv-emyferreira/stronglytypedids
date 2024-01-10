namespace Aviv.StronglyTypedIds.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class JsonTextBenchmark
{
    [Benchmark(Baseline = true)]
    public GetSavedSearchResponse? Deserialize_WithString() =>
        JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponse);

    [Benchmark]
    public GetSavedSearchResponseWithUserId? Deserialize_WithStruct() =>
        JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponseWithUserId);
}