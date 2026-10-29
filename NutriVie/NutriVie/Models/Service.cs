using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }


        [Required]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
