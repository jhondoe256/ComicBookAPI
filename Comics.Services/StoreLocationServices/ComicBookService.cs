
using Microsoft.EntityFrameworkCore;

public class ComicBookService : IComicBookService
{
    private AppDbContext _context;

    public ComicBookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddComicBook(ComicCreate model)
    {
        var entity = new ComicBook
        {
            StoreLocationId = model.StoreLocationId,
            Title = model.Title,
            Price = model.Price,
            ReleaseDate = DateTime.Now,
            Genre = model.Genre,
            ItemsInStock = model.ItemsInStock,
        };
        await _context.ComicBooks.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteComicBook(int id)
    {
        var book = await _context.ComicBooks.FindAsync(id);
        if (book is null)
            return false;
        else
        {
            _context.ComicBooks.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }
    }

    public async Task<ComicDetail> GetComicBookById(int id)
    {
        var book = await _context.ComicBooks.Include(c => c.StoreLocation).FirstOrDefaultAsync(c => c.Id == id);

        return new ComicDetail
        {
            Id = book.Id,
            Title = book.Title,
            Price = book.Price,
            ReleaseDate = book.ReleaseDate,
            Genre = book.Genre.ToString(),
            ItemsInStock = book.ItemsInStock,
            StoreLocation = new StoreLocationListItem
            {
                Id = book.StoreLocation.Id,
                StoreName = book.StoreLocation.StoreName
            }
        };
    }

    public async Task<List<ComicBookListItem>> GetComicBooks()
    {
        return await _context.ComicBooks.Select(c => new ComicBookListItem
        {
            Id = c.Id,
            Title = c.Title,
            Price = c.Price
        }).ToListAsync();
    }
}
