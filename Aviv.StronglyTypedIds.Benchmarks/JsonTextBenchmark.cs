namespace Aviv.StronglyTypedIds.Benchmarks;

[RankColumn, Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MinColumn, MaxColumn]
[MemoryDiagnoser(displayGenColumns: false)]
public class JsonTextBenchmark
{
    [Benchmark(Baseline = true)]
    public GetSavedSearchResponse Deserialize() =>
        JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponse)!;

    [Benchmark]
    public GetSavedSearchResponseWithUserId Deserialize_WithUserId() =>
        JsonSerializer.Deserialize(Database.Json, SavedSearchJsonContext.Default.GetSavedSearchResponseWithUserId)!;
}