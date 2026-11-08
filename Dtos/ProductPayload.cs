using System.ComponentModel.DataAnnotations;

namespace FTELMarket.Dtos;

// What the front sends for POST and PUT. The attributes are the validation rules:
// [ApiController] answers 400 by itself when one is broken.
public class ProductPayload
{
  [Required, StringLength(200)]
  public string Name { get; set; } = "";

  [StringLength(1000)]
  public string? Description { get; set; }

  [Range(0.01, 1_000_000)]
  public decimal Price { get; set; }

  [Range(0, int.MaxValue)]
  public int Stock { get; set; }

  [Range(1, int.MaxValue)]
  public int CategoryId { get; set; }
}
