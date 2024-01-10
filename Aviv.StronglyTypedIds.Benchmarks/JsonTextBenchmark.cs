namespace Aviv.StronglyTypedIds.Benchmarks;

[Config(typeof(BenchmarkConfig))]
public class JsonTextBenchmark
{
    [Benchmark(Baseline = true)]
    public GetSavedSearchResponse? Deserialize() =>
        JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponse);

    [Benchmark]
    public GetSavedSearchResponseWithUserId? Deserialize_WithUserId() =>
        JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponseWithUserId);
}