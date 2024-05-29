using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class ProdusDto
    {
        [Required(ErrorMessage = "Nume is required")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Pret is required")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Memorie is required")]
        public int Memorie { get; set; }

        [Required(ErrorMessage = "Dimensiune is required")]
        public string Dimensiune { get; set; }

        // Foreign key property
        [Required, ForeignKey("Categorie")]
        public int CategorieId { get; set; }
    }
}
