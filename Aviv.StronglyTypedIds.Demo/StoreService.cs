namespace Aviv.StronglyTypedIds.Demo;

public class StoreService
{
    private readonly DataService _dataService;

    public StoreService(DataService dataService)
    {
        _dataService = dataService;
    }

    public ValueTask SellAsync(StoreId storeId, string productId)
    {
        return ValueTask.CompletedTask;
    }

    public async ValueTask SellAndRestock()
    {
        var id = await _dataService.GetStoreId();
        var productId = await _dataService.GetProductId();

        await SellAsync(id, productId);
    } 
}