
public interface IStoreLocationService
{
    Task<bool> AddStoreLocation(StoreLocationCreate model);
    Task<bool> UpdateStoreLocation(int id, StoreLocationEdit model);
    Task<bool> DeleteStoreLocation(int id);
    Task<StoreLocationDetail> GetStoreById(int id);
    Task<List<StoreLocationListItem>> GetStores();
}
