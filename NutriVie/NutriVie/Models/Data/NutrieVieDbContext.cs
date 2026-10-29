using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.Data
{
    public class NutrieVieDbContext : DbContext
    {
        public NutrieVieDbContext(DbContextOptions<NutrieVieDbContext>options)
            : base(options)
        {

        }
        
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Nom = "Recettes Saines", Description = "Découvrez des centaines de recettes équilibrées, savoureuses et faciles à préparer pour tous les goûts." },
                new Service { Id = 2, Nom = "Plans Nutritionnels", Description = "Bénéficiez de plans de repas personnalisés selon vos objectifs et vos besoins caloriques quotidiens." },
                new Service { Id = 3, Nom = "Conseils d’Experts", Description = "Consultez nos diététiciens et nutritionnistes certifiés pour un accompagnement sur mesure." }
            );

        }




    }

}

