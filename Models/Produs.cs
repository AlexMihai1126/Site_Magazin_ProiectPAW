using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class Produs
    {
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        public decimal Pret { get; set; }
        [ForeignKey("CategorieProdus")]
        public int CategorieId { get; set; }

    }
}