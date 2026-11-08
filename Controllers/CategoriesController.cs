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

  [HttpGet(Name = "GetCategories")]
  public async Task<List<Category>> Get()
  {
    return await _db.Categories.OrderBy(c => c.Id).ToListAsync();
  }

}