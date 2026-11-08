namespace FTELMarket.Models;

public class Product
{
  public int Id {get; set;}
  public required string Name {get; set;}
  public string? Description {get; set;}
  public decimal Price {get; set;}
  public int Stock {get; set;}
  public DateTime CreatedAt {get; set;}

  // Foreign key: the real column linking the product to its category.
  public int CategoryId {get; set;}

  // Reference navigation: lets you write product.Category.Name. No column in the table.
  public Category Category {get; set;} = null!;
}
