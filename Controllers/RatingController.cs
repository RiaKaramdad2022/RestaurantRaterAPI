using Microsoft.AspNetCore.Mvc;

namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController
    {
        private RestaurantDbContext _context;
        public RatingController(RestaurantDbContext context) {
            _context = context;

        }
    }
    [HttpPost]
    public async Task<IActionResult> PostRating([FromForm] RatingEdit model) {
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        _context.Rating.Add(new Rating(){
            FoodScore = model.FoodScore,
            CleanlinessScore = model.CleanlinessScore,
            AtmosphereScore = model.AtmosphereScore,
            RestaurantId = model.RestaurantId
        });
        await _context.SaveChangesAsync();
        return Ok();
    }
}