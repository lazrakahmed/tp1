using FTELMarket.Data;
using FTELMarket.Dtos;
using FTELMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly FtelMarketContext _db;

  public ProductsController(FtelMarketContext db)
  {
    _db = db;
  }

  [HttpGet(Name = "GetProducts")]
  public async Task<List<ProductResponse>> Get()
  {
    // Include makes EF JOIN the Categories table so p.Category is filled in.
    var products = await _db.Products
      .Include(p => p.Category)
      .OrderBy(p => p.Id)
      .ToListAsync();

    return products.Select(ToResponse).ToList();
  }

  [HttpPost]
  public async Task<ActionResult<ProductResponse>> Create(ProductPayload payload)
  {
    var category = await _db.Categories.FindAsync(payload.CategoryId);
    if (category is null)
    {
      return BadRequest(new { message = "Cette catégorie n'existe pas." });
    }

    var product = new Product
    {
      Name = payload.Name,
      Description = payload.Description,
      Price = payload.Price,
      Stock = payload.Stock,
      Category = category,
      CreatedAt = DateTime.UtcNow
    };
    _db.Products.Add(product);
    await _db.SaveChangesAsync();   // the INSERT happens here; the database assigns the Id

    return Created($"/api/products/{product.Id}", ToResponse(product));
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<ProductResponse>> Update(int id, ProductPayload payload)
  {
    var product = await _db.Products.FindAsync(id);
    if (product is null)
    {
      return NotFound(new { message = "Ce produit n'existe pas." });
    }

    var category = await _db.Categories.FindAsync(payload.CategoryId);
    if (category is null)
    {
      return BadRequest(new { message = "Cette catégorie n'existe pas." });
    }

    // PUT replaces every field; Id and CreatedAt are kept.
    product.Name = payload.Name;
    product.Description = payload.Description;
    product.Price = payload.Price;
    product.Stock = payload.Stock;
    product.Category = category;
    await _db.SaveChangesAsync();   // EF noticed which properties changed and sends an UPDATE

    return ToResponse(product);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var product = await _db.Products.FindAsync(id);
    if (product is null)
    {
      return NotFound(new { message = "Ce produit n'existe pas." });
    }

    _db.Products.Remove(product);
    await _db.SaveChangesAsync();

    return NoContent();
  }

  // Entity -> JSON shape expected by the front. product.Category must be loaded.
  private static ProductResponse ToResponse(Product product)
  {
    return new ProductResponse
    {
      Id = product.Id,
      Name = product.Name,
      Description = product.Description,
      Price = product.Price,
      Stock = product.Stock,
      CategoryId = product.CategoryId,
      CategoryName = product.Category.Name,
      CreatedAt = product.CreatedAt
    };
  }
}
