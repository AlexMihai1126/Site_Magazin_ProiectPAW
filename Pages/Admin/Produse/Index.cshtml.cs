using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;
using System.Linq;

namespace proiect.Pages.Admin.Produse
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext context;

        public List<Produs> Produs { get; set; } = new List<Produs>();

        public IndexModel(ProiectDBContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Produs = context.Produs
                        .Include(p => p.Categorie)
                        .OrderByDescending(p => p.Id)
                        .ToList();
        }
    }
}