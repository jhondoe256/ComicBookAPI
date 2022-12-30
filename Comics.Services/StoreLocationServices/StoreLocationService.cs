
using Microsoft.EntityFrameworkCore;

public class StoreLocationService : IStoreLocationService
{
    //we need access to the database Global -> we can use this _context anywhere in this code {}
    private AppDbContext _context;

    public StoreLocationService(AppDbContext context)
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

    public async Task<bool> DeleteStoreLocation(int id)
    {
        var store = await _context.StoreLocations.FindAsync(id);
        if (store is null)
            return false;
        else
        {
            _context.StoreLocations.Remove(store);
            return await _context.SaveChangesAsync() > 0;
        }
    }

    public async Task<StoreLocationDetail> GetStoreById(int id)
    {
        var store = await _context.StoreLocations.Include(s => s.ComicBooks).SingleOrDefaultAsync(x => x.Id == id);

        return new StoreLocationDetail
        {
            Id = store.Id,
            StoreName = store.StoreName,
            ComicBooks = store.ComicBooks.Select(c => new ComicBookListItem
            {
                Id = c.Id,
                Title = c.Title,
                Price = c.Price
            }).ToList()
        };
    }

    public async Task<List<StoreLocationListItem>> GetStores()
    {
        var stores = await _context.StoreLocations.Select(s => new StoreLocationListItem
        {
            Id = s.Id,
            StoreName = s.StoreName,
        }).ToListAsync();

        return stores;
    }

    public async Task<bool> UpdateStoreLocation(int id, StoreLocationEdit model)
    {
        var store = await _context.StoreLocations.FindAsync(id);
        if (store is null)
            return false;
        else
        {
            store.StoreName = model.StoreName;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
