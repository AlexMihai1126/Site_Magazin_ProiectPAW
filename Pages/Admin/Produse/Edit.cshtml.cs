using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Produse
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;
        public List<SelectListItem> Categorii { get; set; }


        [BindProperty]
        public ProdusDto ProdusDto { get; set; } = new ProdusDto();
        public Produs Produs { get; set; } = new Produs();
        public EditModel(IWebHostEnvironment environment, ProiectDBContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Produse/Index");
                return;
            }

            var produs = context.Produs.Find(id);
            if (produs == null)
            {
                Response.Redirect("/Admin/Produse/Index");
                return;
            }
            Categorii = context.CategProdus.Select(CategProdus => new SelectListItem { Text = CategProdus.Nume, Value = CategProdus.Id.ToString() }).ToList();
            ProdusDto.Brand = produs.Brand;
            ProdusDto.Model = produs.Model;
            ProdusDto.Descriere = produs.Descriere;
            ProdusDto.Culoare = produs.Culoare;
            ProdusDto.ImageName = produs.ImageName;
            ProdusDto.Pret = produs.Pret;
            ProdusDto.Memorie = produs.Memorie;
            ProdusDto.Dimensiune = produs.Dimensiune;
            ProdusDto.Stoc = produs.Stoc;
            ProdusDto.CategorieId = produs.CategorieId;

            Produs = produs;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Produse/Index");
                return;
            }

            var produs = context.Produs.Find(id);
            if (produs == null)
            {
                Response.Redirect("/Admin/Produse/Index");
                return;
            }

            // update produs in baza de date 
            produs.Brand = ProdusDto.Brand;
            produs.Model = ProdusDto.Model;
            produs.Descriere = ProdusDto.Descriere;
            produs.Culoare = ProdusDto.Culoare;
            produs.ImageName = ProdusDto.ImageName;
            produs.Pret = ProdusDto.Pret;
            produs.Memorie = ProdusDto.Memorie;
            produs.Dimensiune = ProdusDto.Dimensiune;
            produs.Stoc = ProdusDto.Stoc;
            produs.CategorieId = ProdusDto.CategorieId;

            context.SaveChanges();

            Produs = produs;
            Response.Redirect("/Admin/Produse/Index");
        }
    }
}
