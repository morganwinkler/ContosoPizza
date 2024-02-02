using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
  public PizzaController()
  {
  }
  // Returns an ActionResult instance of type List<Pizza>. The ActionResult type is the base class for all action results in ASP.NET Core.
  [HttpGet]
  public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

  // GET by Id action

  // POST action

  // PUT action

  // DELETE action
}