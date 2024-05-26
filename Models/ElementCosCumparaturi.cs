using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class ElementCosCumparaturi
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CosCumparaturi")]
        public int CosCumparaturiId { get; set; }

        public CosCumparaturi CosCumparaturi { get; set; }

        [ForeignKey("Produs")]
        public int ProdusId { get; set; }

        public Produs Produs { get; set; }

        public int Cantitate { get; set; }
    }
}
