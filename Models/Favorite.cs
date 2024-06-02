using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string FUserId { get; set; }
        public DefaultUser User { get; set; }
        [ForeignKey("Produs")]
        public int ProdusId { get; set; }
        public Produs? Produs { get; set; }
    }
}
