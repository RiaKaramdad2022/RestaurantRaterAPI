using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterAPI
{
    public class RestaurantDbContext : DbContext 
    {
        //This will also need a constructor that inherits from the base (DbContext) controller.
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) :base(options) {}
        public DbSet<Restaurant> Restaurants {get; set; }
        public DbSet<Rating> Ratings {get; set; }
    }
}