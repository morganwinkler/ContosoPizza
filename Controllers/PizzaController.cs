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

  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza == null)
      return NotFound();

    return pizza;
  }

  [HttpPost]
  public IActionResult Create(Pizza pizza)
  {
    PizzaService.Add(pizza);
    // The first parameter in the CreatedAtAction method call represents an action name. The nameof keyword is used to avoid hard-coding the action name. CreatedAtAction uses the action name to generate a location HTTP response header with a URL to the newly created pizza, as explained in the previous unit.
    return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
      return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if (existingPizza is null)
      return NotFound();

    PizzaService.Update(pizza);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza is null)
      return NotFound();

    PizzaService.Delete(id);

    return NoContent();
  }
}