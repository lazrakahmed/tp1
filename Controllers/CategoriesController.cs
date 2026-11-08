using FTELMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
  public static readonly List<Category> Categories = [
    new Category { Id = 1, Name = "PlayStation 5" },
    new Category { Id = 2, Name = "Nintendo Switch" },
    new Category { Id = 3, Name = "Xbox Series X" },
    new Category { Id = 4, Name = "PC" }
  ];

  [HttpGet(Name = "GetCategories")]
  public List<Category> Get()
  {
    return Categories;
  }

}