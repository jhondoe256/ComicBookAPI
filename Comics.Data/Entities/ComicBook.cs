
using System.ComponentModel.DataAnnotations.Schema;

public class ComicBook
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public GenereType Genre { get; set; }
    public int ItemsInStock { get; set; } = 100;

    [ForeignKey(nameof(StoreLocation))]
    public int StoreLocationId { get; set; }
    public virtual StoreLocation StoreLocation { get; set; }
}
