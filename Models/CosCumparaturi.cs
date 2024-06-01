using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace proiect.Models
{
    public class CosCumparaturi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string CUserID { get; set; }

        // Navigation property for the user
        public DefaultUser? User { get; set; }

        // Navigation property for the products in the cart
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