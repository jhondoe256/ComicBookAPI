
using System.ComponentModel.DataAnnotations;

public class ComicCreate
{
    [Required]
    public string Title { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public GenereType Genre { get; set; }

    [Required]
    public int ItemsInStock { get; set; } = 100;

    [Required]
    public int StoreLocationId { get; set; }

}
