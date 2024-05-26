using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect.ContextModels;
using proiect.Models;
using System.Linq;

namespace proiect.Pages.Admin.Produse
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext context;

        public List<Produs> Produse { get; set; }  = new List<Produs>();

        public IndexModel(ProiectDBContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Produse = context.Produs.OrderByDescending(p => p.Id).ToList();
        }
    }
}
