using System.ComponentModel.DataAnnotations;
namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id {get; set; }
        [Required]
        [MaxLength(100)]
        public string Name {get; set; }
        [Required]
        [MaxLength(100)]
        public string Location {get; set; }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
        public double AverageScore
        {
            get
            {
                return(AverageFoodScore + AverageCleanlinessScore + AverageAtmosphereScore) /3;
            }
        }
        public double AverageFoodScore
        {
            get 
            {
                if(Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.FoodScore;
                }
                return total / Ratings.Count;
            }
        }
        public double AverageAtmosphereScore
        {
            get 
            {
                if(Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.FoodScore;
                }
                return total / Ratings.Count;
        }
        }
        public double AverageCleanlinessScore
        {
            get 
            {
                if(Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.FoodScore;
                }
                return total / Ratings.Count;
        }
        }
    }
}