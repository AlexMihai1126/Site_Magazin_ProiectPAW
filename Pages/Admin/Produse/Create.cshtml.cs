using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;
using System.Drawing.Drawing2D;

namespace proiect.Pages.Admin.Produse
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;

        [BindProperty]
        public ProdusDto ProdusDto { get; set; }
        public CreateModel(IWebHostEnvironment environment, ProiectDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
            ProdusDto = new ProdusDto();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // save the new product in the database
            Produs produs = new Produs
            {
                Nume = ProdusDto.Nume,
                Pret = ProdusDto.Pret,
                Memorie = ProdusDto.Memorie,
                Dimensiune = ProdusDto.Dimensiune,
                CategorieId = ProdusDto.CategorieId,
            };

            context.Produs.Add(produs);
            context.SaveChanges();
            return RedirectToPage("/Admin/Produse/Index");

        }
    }
}
