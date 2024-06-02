using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Categorii
{
    public class EditCategModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;
        [BindProperty]
        public CategorieDto CategorieDto { get; set; } = new CategorieDto();
        public CategorieProdus CategorieProdus { get; set; } = new CategorieProdus();
        public EditCategModel(IWebHostEnvironment environment, ProiectDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Categorii/ViewCateg");
                return;
            }
            var categ = context.CategProdus.Find(id);
            if (categ == null)
            {
                Response.Redirect("/Admin/Categorii/ViewCateg");
                return;
            }
            CategorieDto.Nume = categ.Nume;
            CategorieProdus = categ;
        }
        public void OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                Response.Redirect("/Admin/Categorii/ViewCateg");
                return;
            }
            var categ = context.CategProdus.Find(id);
            if (categ == null)
            {
                Response.Redirect("/Admin/Categorii/ViewCateg");
                return;
            }
            categ.Nume = CategorieDto.Nume;
            context.SaveChanges();
            Response.Redirect("/Admin/Categorii/ViewCateg");
        }
    }
}
