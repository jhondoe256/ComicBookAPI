
public interface IFutureStoreService : IStoreLocationService
{
    Task<List<StoreLocationListItem>> GetStoresByStoreName(string storeName);
}
