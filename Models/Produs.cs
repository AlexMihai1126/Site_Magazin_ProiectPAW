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
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Pret { get; set; }
        public int Memorie { get; set; }
        public string Dimensiune { get; set; }
        public string ImageName { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        public CategorieProdus? Categorie { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public Produs()
        {
            Reviews = new List<Review>();
        }
    }
}
