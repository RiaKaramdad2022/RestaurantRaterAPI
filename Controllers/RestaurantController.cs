using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : Controller
    {
        //this is where we will create API endpoint(CRUD Methods)
        private RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }
    }

    public async Task<IActionResult> PostRestaurant([FromForm] RestaurantEdit model )
    {
        [HttpPost]
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Restaurants.Add(new Restaurant()
        {
            Name = model.Name,
            Location = model.Location,
        });
        await _context.SaveChangesAsync();
        return Ok();

    }
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await _context.Restaurants.ToListAsync();
        return Ok(restaurants);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetRestaurantById(int Id)
    {
        var restaurants = await _context.Restaurants.FindAsync(id);
        if(restaurant == null) {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateRestaurant([FromForm] RestaurantEdit model, [FromRoute] int id)
    {

    }
    var oldRestaurant = await _context.Restaurants.FindAsync(id);
    if(oldRestaurant == null)
    {
        return NotFound();
    }
    if(!ModelState.IsValid)
    {
        return BadRequest();
    }
    if(!string.IsNullOrEmpty(model.Name))
    {
        oldRestaurant.Name = model.Name;
    }
    if(!string.IsNullOrEmpty(model.Location))
    {
        oldRestaurant.Location = model.Location;
    }
    await _context.SaveChangesAsync();
    return Ok();

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> DeleteRestaurant([FromForm]) int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if(restaurant == null)
        {
            return NotFound();
        }
        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
        return Ok();
    }

}