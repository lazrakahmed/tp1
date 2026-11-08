using FTELMarket.Data;
using FTELMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
  private readonly FtelMarketContext _db;

  // ASP.NET sees this parameter and passes the context registered in Program.cs.
  public CategoriesController(FtelMarketContext db)
  {
    _db = db;
  }

  // Temporary: ProductsController still reads this list until it moves to the database too.
  public static readonly List<Category> Categories = [
    new Category { Id = 1, Name = "PlayStation 5" },
    new Category { Id = 2, Name = "Nintendo Switch" },
    new Category { Id = 3, Name = "Xbox Series X" },
    new Category { Id = 4, Name = "PC" }
  ];

  [HttpGet(Name = "GetCategories")]
  public async Task<List<Category>> Get()
  {
    return await _db.Categories.OrderBy(c => c.Id).ToListAsync();
  }

}