using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Produse
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;
        public List<SelectListItem> Categorii { get; set; }

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
            Categorii = context.CategProdus.Select(CategProdus => new SelectListItem { Text = CategProdus.Nume, Value = CategProdus.Id.ToString() }).ToList();
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
                Brand = ProdusDto.Brand,
                Model = ProdusDto.Model,
                Descriere = ProdusDto.Descriere,
                ImageName = ProdusDto.ImageName,
                Culoare = ProdusDto.Culoare,
                Pret = ProdusDto.Pret,
                Memorie = ProdusDto.Memorie,
                Dimensiune = ProdusDto.Dimensiune,
                Stoc=ProdusDto.Stoc,
                CategorieId = ProdusDto.CategorieId,
            };

            context.Produs.Add(produs);
            context.SaveChanges();
            return RedirectToPage("/Admin/Produse/Index");

        }
    }
}
