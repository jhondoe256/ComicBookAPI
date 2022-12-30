
public interface IComicBookService
{
    Task<bool> AddComicBook(ComicCreate model);
    Task<bool> DeleteComicBook(int id);
    Task<ComicDetail> GetComicBookById(int id);
    Task<List<ComicBookListItem>> GetComicBooks();
}
