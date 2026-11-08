namespace FTELMarket.Dtos;

// What the API sends back for a product: the shape the front expects.
// CategoryName is flattened here; in the database it lives only in Categories.
public class ProductResponse
{
  public int Id {get; set;}
  public required string Name {get; set;}
  public string? Description {get; set;}
  public decimal Price {get; set;}
  public int Stock {get; set;}
  public int CategoryId {get; set;}
  public required string CategoryName {get; set;}
  public DateTime CreatedAt {get; set;}
}
