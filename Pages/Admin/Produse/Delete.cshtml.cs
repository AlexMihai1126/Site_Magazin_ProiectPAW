using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Admin.Produse
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ProiectDBContext context;

        public DeleteModel(IWebHostEnvironment environment, ProiectDBContext context)
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

            context.Produs.Remove(produs);
            context.SaveChanges();

            Response.Redirect("/Admin/Produse/Index");
        }
    }
}
