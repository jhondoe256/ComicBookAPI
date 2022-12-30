
using Microsoft.EntityFrameworkCore;

public class FutureStoreLocationService : IFutureStoreService
{
    private AppDbContext _context;

    public FutureStoreLocationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddStoreLocation(StoreLocationCreate model)
    {
        var entity = new StoreLocation
        {
            StoreName = model.StoreName
        };

        await _context.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public Task<bool> DeleteStoreLocation(int id)
    {
        throw new NotImplementedException();
    }

    public Task<StoreLocationDetail> GetStoreById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<StoreLocationListItem>> GetStores()
    {
        throw new NotImplementedException();
    }

    public async Task<List<StoreLocationListItem>> GetStoresByStoreName(string storeName)
    {
        var stores = await _context.StoreLocations.Where(s => s.StoreName == storeName).ToListAsync();

        return stores.Select(s => new StoreLocationListItem
        {
            Id = s.Id,
            StoreName = s.StoreName
        }).ToList();
    }

    public Task<bool> UpdateStoreLocation(int id, StoreLocationEdit model)
    {
        throw new NotImplementedException();
    }
}
