namespace Aviv.StronglyTypedIds.Demo;

public class DataService
{
    public ValueTask<StoreId> GetStoreId() => ValueTask.FromResult(StoreId.New());

    public ValueTask<string> GetProductId() => ValueTask.FromResult(Guid.NewGuid().ToString());
}