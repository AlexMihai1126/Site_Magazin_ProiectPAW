using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Produs")]
        public int ProdusId { get; set; }
        public Produs? Produs { get; set; }
        [ForeignKey("DefaultUser")]
        public string RUserId { get; set; }
        public DefaultUser? RUser { get; set; }
        [Required]
        public string Content { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public Review()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
