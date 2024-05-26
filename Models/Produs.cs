using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proiect.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        public decimal Pret { get; set; }

        // Foreign key property
        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        // Navigation property for the category of the product
        public CategorieProdus? Categorie { get; set; }

        // Navigation property for reviews
        public ICollection<Review> Reviews { get; set; }

        public Produs()
        {
            Reviews = new List<Review>();
        }
    }
}
