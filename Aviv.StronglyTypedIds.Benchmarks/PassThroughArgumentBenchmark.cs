namespace Aviv.StronglyTypedIds.Benchmarks;

[RankColumn, Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MinColumn, MaxColumn]
[MemoryDiagnoser(displayGenColumns: false)]
public class PassThroughArgumentBenchmark
{
    private readonly Guid _userId = Guid.NewGuid();
    private UserIdReadOnly _userIdReadOnly;
    private List<Guid>? _guids;

    [GlobalSetup]
    public void Setup()
    {
        _userIdReadOnly = new UserIdReadOnly(_userId);
        _guids = new List<Guid>(capacity: 3);
        _guids.AddRange(Enumerable.Range(0, _guids.Capacity).Select(_ => Guid.NewGuid()));
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _guids!.Clear();
        _guids = null;
    }

    private int GetHash(string userId) => HashCode.Combine(GetHash(), userId);
    private int GetHash(Guid userId) => HashCode.Combine(GetHash(), userId);
    private int GetHash(UserId userId) => HashCode.Combine(GetHash(), userId);
    private int GetHash(UserIdReadOnly userId) => HashCode.Combine(GetHash(), userId);
    private int GetHashWithInKeyword(in UserIdReadOnly userId) => HashCode.Combine(GetHash(), userId);

    private int GetHash()
    {
        return HashCode.Combine(_guids![0], _guids![1], _guids![2]);
    }

    [Benchmark(Baseline = true)]
    public int GetHash_String() => GetHash(_userId.ToString());

    [Benchmark]
    public int GetHash_Guid() => GetHash(_userId);

    [Benchmark]
    public int GetHash_UserId() => GetHash(new UserId(_userId));

    [Benchmark]
    public int GetHash_UserIdReadOnly() => GetHash(new UserIdReadOnly(_userId));

    [Benchmark]
    public int GetHash_UserIdReadOnlyInKeyword() => GetHashWithInKeyword(new UserIdReadOnly(_userId));

    [Benchmark]
    public int GetHash_UserIdReadOnly_PreBuilt() => GetHash(_userIdReadOnly);
}