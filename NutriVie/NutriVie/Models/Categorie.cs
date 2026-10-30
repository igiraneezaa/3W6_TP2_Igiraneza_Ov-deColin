using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        public List<Recette>? Recettes { get; set; }
    }
}
