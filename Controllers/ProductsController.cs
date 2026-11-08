using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private static readonly List<Product> Products = new()
  {
    new Product { Id = 1, Name = "The Last of Us Part II", Description = "Boîte et notice, disque sans rayure.", Price = 19.9m, Stock = 3, CategoryId = 1, CategoryName = "PlayStation 5", CreatedAt = new DateTime(2026, 9, 2, 9, 15, 0, DateTimeKind.Utc) },
    new Product { Id = 2, Name = "Gran Turismo 7", Description = null, Price = 29.9m, Stock = 1, CategoryId = 1, CategoryName = "PlayStation 5", CreatedAt = new DateTime(2026, 9, 5, 14, 30, 0, DateTimeKind.Utc) },
    new Product { Id = 3, Name = "The Legend of Zelda: Tears of the Kingdom", Description = "Cartouche seule.", Price = 39.9m, Stock = 2, CategoryId = 2, CategoryName = "Nintendo Switch", CreatedAt = new DateTime(2026, 9, 8, 10, 0, 0, DateTimeKind.Utc) },
    new Product { Id = 4, Name = "Mario Kart 8 Deluxe", Description = "Complet, très bon état.", Price = 34.9m, Stock = 5, CategoryId = 2, CategoryName = "Nintendo Switch", CreatedAt = new DateTime(2026, 9, 10, 16, 45, 0, DateTimeKind.Utc) },
    new Product { Id = 5, Name = "Halo Infinite", Description = null, Price = 14.9m, Stock = 4, CategoryId = 3, CategoryName = "Xbox Series X", CreatedAt = new DateTime(2026, 9, 12, 11, 20, 0, DateTimeKind.Utc) },
    new Product { Id = 6, Name = "Forza Horizon 5", Description = "Édition standard.", Price = 24.9m, Stock = 0, CategoryId = 3, CategoryName = "Xbox Series X", CreatedAt = new DateTime(2026, 9, 15, 8, 5, 0, DateTimeKind.Utc) },
    new Product { Id = 7, Name = "Baldur’s Gate 3", Description = "Clé physique, coffret collector.", Price = 44.9m, Stock = 1, CategoryId = 4, CategoryName = "PC", CreatedAt = new DateTime(2026, 9, 18, 17, 40, 0, DateTimeKind.Utc) },
    new Product { Id = 8, Name = "Hades", Description = null, Price = 9.9m, Stock = 6, CategoryId = 4, CategoryName = "PC", CreatedAt = new DateTime(2026, 9, 21, 13, 10, 0, DateTimeKind.Utc) }
  };

  private static int _nextId = 9;

  [HttpGet(Name = "GetProducts")]
  public List<Product> Get()
  {
    return Products;
  }

  [HttpPost]
  public ActionResult<Product> Create(ProductPayload payload)
  {
    var category = CategoriesController.Categories.FirstOrDefault(c => c.Id == payload.CategoryId);
    if (category is null)
    {
      return BadRequest(new { message = "Cette catégorie n'existe pas." });
    }

    var product = new Product
    {
      Id = _nextId++,
      Name = payload.Name,
      Description = payload.Description,
      Price = payload.Price,
      Stock = payload.Stock,
      CategoryId = category.Id,
      CategoryName = category.Name,
      CreatedAt = DateTime.UtcNow
    };
    Products.Add(product);

    return Created($"/api/products/{product.Id}", product);
  }

  [HttpPut("{id}")]
  public ActionResult<Product> Update(int id, ProductPayload payload)
  {
    var product = Products.FirstOrDefault(p => p.Id == id);
    if (product is null)
    {
      return NotFound(new { message = "Ce produit n'existe pas." });
    }

    var category = CategoriesController.Categories.FirstOrDefault(c => c.Id == payload.CategoryId);
    if (category is null)
    {
      return BadRequest(new { message = "Cette catégorie n'existe pas." });
    }

    product.Name = payload.Name;
    product.Description = payload.Description;
    product.Price = payload.Price;
    product.Stock = payload.Stock;
    product.CategoryId = category.Id;
    product.CategoryName = category.Name;

    return product;
  }
}


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

public class Product
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