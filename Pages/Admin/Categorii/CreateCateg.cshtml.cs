using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Categorii
{
    public class CreateCategModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;
        public List<SelectListItem> Categorii { get; set; }

        [BindProperty]
        public CategorieProdus Categorie { get; set; }
        public CreateCategModel(IWebHostEnvironment environment, ProiectDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
            Categorie = new CategorieProdus();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.CategProdus.Add(Categorie);
            context.SaveChanges();
            return RedirectToPage("/Admin/Categorii/ViewCateg");

        }
    }
}
