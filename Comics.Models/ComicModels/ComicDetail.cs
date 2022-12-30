
public class ComicDetail
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public int ItemsInStock { get; set; }
    public StoreLocationListItem StoreLocation { get; set; }
}
