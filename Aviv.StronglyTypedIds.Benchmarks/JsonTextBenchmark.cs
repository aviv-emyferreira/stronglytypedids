namespace Aviv.StronglyTypedIds.Benchmarks;

[RankColumn, Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MinColumn, MaxColumn]
[MemoryDiagnoser(displayGenColumns: false)]
public class JsonTextBenchmark
{
    private static readonly SavedSearchJsonContext JsonContext = new();
    
    [Benchmark(Baseline = true)]
    public GetSavedSearchResponse Deserialize() =>
        JsonSerializer.Deserialize(Database.Json, JsonContext.GetSavedSearchResponse)!;

    [Benchmark]
    public GetSavedSearchResponseWithUserId Deserialize_WithUserId() =>
        JsonSerializer.Deserialize(Database.Json, JsonContext.GetSavedSearchResponseWithUserId)!;
}