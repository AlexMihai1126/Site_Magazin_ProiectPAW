using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect.ContextModels;
using proiect.Models;

namespace proiect.Pages.Telefoane
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext _context;

        public IndexModel(ProiectDBContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get; set; }

        public async Task OnGet()
        {
            Produs = _context.Produs
                .Include(p => p.Categorie)
                .Where(p => p.Categorie.Nume == "Telefoane")
                .ToList();
        }
    }
}
