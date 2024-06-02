using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class CategorieDto
    {
        [Required(ErrorMessage = "Nume is required")]
        public string Nume { get; set; }
    }
}
