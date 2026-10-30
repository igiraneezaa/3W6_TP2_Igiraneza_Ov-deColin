using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Recette
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int TempsPreparation { get; set; }

        public int TempsCuisson { get; set; }

        public string? Image { get; set; }

        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

    }
}
