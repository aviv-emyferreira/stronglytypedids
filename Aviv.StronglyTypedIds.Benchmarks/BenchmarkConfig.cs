namespace Aviv.StronglyTypedIds.Benchmarks;

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        Create(DefaultConfig.Instance);
        AddJob(Job.MediumRun
            .WithToolchain(InProcessNoEmitToolchain.Instance));
        AddDiagnoser(MemoryDiagnoser.Default);
        AddColumn([StatisticColumn.Min, StatisticColumn.Max, RankColumn.Arabic]);
        WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest));
    }
}