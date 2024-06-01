using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class ProdusDto
    {
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Culoare is required")]
        public string Culoare { get; set; }
        [Required(ErrorMessage = "Descriere is required")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Pret is required")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Memorie is required")]
        public int Memorie { get; set; }

        [Required(ErrorMessage = "Dimensiune is required")]
        public string Dimensiune { get; set; }

        public int Stoc { get; set; }

        [Required(ErrorMessage = "Imagine is required")]
        public string ImageName { get; set; }

        // Foreign key property
        [Required, ForeignKey("Categorie")]
        public int CategorieId { get; set; }
    }
}
