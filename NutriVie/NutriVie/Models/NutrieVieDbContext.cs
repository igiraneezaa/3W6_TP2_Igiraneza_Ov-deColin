using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models
{
    public class NutrieVieDbContext : DbContext
    {
        public NutrieVieDbContext(DbContextOptions<NutrieVieDbContext>options)
            : base(options)
        {

        }
        
    }
}
