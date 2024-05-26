using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }

        // Foreign key property for the user
        [ForeignKey("User")]
        public string FUserId { get; set; }

        // Navigation property for the user
        public DefaultUser User { get; set; }

        // Foreign key property for the product
        [ForeignKey("Produs")]
        public int ProdusId { get; set; }

        // Navigation property for the product
        public Produs? Produs { get; set; }
    }
}
