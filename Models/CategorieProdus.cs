using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class CategorieProdus
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        // Navigation property for products in this category
        public ICollection<Produs> Produse { get; set; }

        public CategorieProdus()
        {
            Produse = new List<Produs>();
        }
    }
}
