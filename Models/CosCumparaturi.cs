
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class CosCumparaturi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DefaultUser User { get; set; }

        public ICollection<ElementCosCumparaturi> Produse { get; set; }

        public CosCumparaturi()
        {
            Produse = new List<ElementCosCumparaturi>();
        }

        public decimal PretCos()
        {
            return Produse.Sum(item => item.Produs.Pret * item.Cantitate);
        }
    }
}
