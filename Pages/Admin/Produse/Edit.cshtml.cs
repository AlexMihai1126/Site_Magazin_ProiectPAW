using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Produse
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;

       
        [BindProperty]
        public ProdusDto ProdusDto { get; set;} = new ProdusDto();
        public Produs Produs {  get; set; } = new Produs();
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
            ProdusDto.Nume = produs.Nume;
            ProdusDto.Pret = produs.Pret;
            ProdusDto.Memorie = produs.Memorie;
            ProdusDto.Dimensiune = produs.Dimensiune;
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
            produs.Nume = ProdusDto.Nume;
            produs.Pret = ProdusDto.Pret;
            produs.Memorie = ProdusDto.Memorie;
            produs.Dimensiune = ProdusDto.Dimensiune;
            produs.CategorieId = ProdusDto.CategorieId;

            context.SaveChanges();

            Produs = produs;
            Response.Redirect("/Admin/Produse/Index");
        }
    }
}
