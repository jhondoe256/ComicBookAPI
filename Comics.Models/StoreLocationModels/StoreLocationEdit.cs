
using System.ComponentModel.DataAnnotations;

public class StoreLocationEdit
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string StoreName { get; set; }
}
